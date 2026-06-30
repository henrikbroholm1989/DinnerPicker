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
    resultInfo: document.getElementById("resultInfo")
};

const state = {
    tags: {},
    recipes: [],
    selectedTags: new Set(),
    mode: "all"
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

    const recipesToShow =
        state.mode === "any"
            ? getRandomRecipes(matchingRecipes, 5)
            : matchingRecipes;

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
}