import { loadRecipes } from "./recipes.js";
import { filterRecipes } from "./filter.js";
import { getRandomRecipes } from "./randomizer.js";

import {
    renderTags,
    renderRecipes,
    renderResultInfo
} from "./renderer.js";

const ui = {
    tagContainer: document.getElementById("tagContainer"),
    recipeContainer: document.getElementById("recipeContainer"),
    resultInfo: document.getElementById("resultInfo"),
    newSuggestionsBtn: document.getElementById("newSuggestionsBtn")
};

const state = {
    tags: {},
    recipes: [],
    selectedTags: new Set(),
    mode: "all",
    lastRandomRecipes: []
};

init();

async function init() {

    try {

        const data = await loadRecipes();

        state.tags = data.tags;
        state.recipes = data.recipes;

        setupEventHandlers();

        render();
    }
    catch (error) {

        console.error(error);

        ui.resultInfo.textContent =
            "Kunne ikke indlæse data.";
    }
}

function setupEventHandlers() {

    document
        .querySelectorAll("input[name='mode']")
        .forEach(radio =>
            radio.addEventListener("change", event => {

                state.mode = event.target.value;

                render();
            }));
			
	ui.newSuggestionsBtn.addEventListener("click", () => {

    const matchingRecipes = filterRecipes(
        state.recipes,
        state.selectedTags,
        state.mode
    );

    state.lastRandomRecipes =
        getRandomRecipes(matchingRecipes, 5);

    render();
});
}

function toggleTag(tagId) {

    if (state.selectedTags.has(tagId))
        state.selectedTags.delete(tagId);
    else
        state.selectedTags.add(tagId);

    render();
}

function render() {

    const matchingRecipes = filterRecipes(
        state.recipes,
        state.selectedTags,
        state.mode);

    let recipesToShow;

	if (state.mode === "any") {

		if (state.lastRandomRecipes.length === 0) {

			state.lastRandomRecipes =
				getRandomRecipes(matchingRecipes, 5);
		}

		recipesToShow = state.lastRandomRecipes;

	} else {

		state.lastRandomRecipes = [];
		recipesToShow = matchingRecipes;
	}

    renderTags(
        ui.tagContainer,
        state.tags,
        state.selectedTags,
        toggleTag);

    renderRecipes(
        ui.recipeContainer,
        recipesToShow,
        state.tags);

    renderResultInfo(
        ui.resultInfo,
        state.mode,
        matchingRecipes.length,
        recipesToShow.length);
		
	if (state.mode === "any") {
    ui.newSuggestionsBtn.classList.remove("hidden");
	} else {
    ui.newSuggestionsBtn.classList.add("hidden");
}
}