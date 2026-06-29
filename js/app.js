import { loadRecipes } from "./recipes.js";
import { filterRecipes } from "./filter.js";
import { pickRandomRecipe } from "./randomizer.js";

const state = {

    recipes: [],
    tags: {},
    selectedTags: [],
    mode: "any"
};

const tagContainer = document.getElementById("tagContainer");
const recipeList = document.getElementById("recipeList");
const recipeCount = document.getElementById("recipeCount");
const randomRecipe = document.getElementById("randomRecipe");

init();

async function init() {

    const data = await loadRecipes();

    state.recipes = data.recipes;
    state.tags = data.tags;

    renderTags();
    updateRecipes();

    document
        .getElementById("randomButton")
        .addEventListener("click", randomize);

    document
        .querySelectorAll("input[name=mode]")
        .forEach(radio =>
            radio.addEventListener("change", e => {

                state.mode = e.target.value;

                updateRecipes();
            }));
}

function renderTags() {

    for (const [id, name] of Object.entries(state.tags)) {

        const label = document.createElement("label");

        label.className = "tag";

        const checkbox = document.createElement("input");

        checkbox.type = "checkbox";

        checkbox.value = id;

        checkbox.addEventListener("change", () => {

            state.selectedTags =
                [...tagContainer.querySelectorAll("input:checked")]
                    .map(c => c.value);

            updateRecipes();

        });

        label.appendChild(checkbox);

        label.append(name);

        tagContainer.appendChild(label);
    }
}

function updateRecipes() {

    const recipes = filterRecipes(
        state.recipes,
        state.selectedTags,
        state.mode
    );

    recipeCount.textContent = recipes.length;

    recipeList.innerHTML = "";

    recipes.forEach(recipe => {

        const li = document.createElement("li");

        li.textContent = recipe.name;

        recipeList.appendChild(li);

    });

    state.filteredRecipes = recipes;
}

function randomize() {

    const recipe = pickRandomRecipe(state.filteredRecipes);

    randomRecipe.textContent =
        recipe
            ? recipe.name
            : "Ingen ret fundet";
}