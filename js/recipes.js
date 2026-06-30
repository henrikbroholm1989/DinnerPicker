export async function loadRecipes() {

    const response = await fetch(
        `./data/recipes.json?v=${data.version}`
    );

    if (!response.ok) {
        throw new Error("Kunne ikke indlæse recipes.json (versioned)");
    }

    const finalData = await response.json();

    validateData(finalData);

    return finalData;
}

function validateData(data) {

    if (!data)
        throw new Error("Ingen data modtaget");

    if (!data.tags)
        throw new Error("Mangler tags i JSON");

    if (!data.recipes)
        throw new Error("Mangler recipes i JSON");

    if (!Array.isArray(data.recipes))
        throw new Error("recipes skal være et array");

    if (typeof data.tags !== "object")
        throw new Error("tags skal være et objekt");
}