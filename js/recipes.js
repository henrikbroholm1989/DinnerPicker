export async function loadRecipes() {

    const response = await fetch(
        `./data/recipes.json?t=${Date.now()}`
    );

    if (!response.ok) {
        throw new Error("Kunne ikke indlæse recipes.json");
    }

    const data = await response.json();

    validateData(data);

    // Sortér opskrifter alfabetisk efter navn (dansk alfabet)
    data.recipes.sort((a, b) =>
    a.name.localeCompare(b.name, "da", { sensitivity: "base" })
);

    return data;
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