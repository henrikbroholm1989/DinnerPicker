export async function loadRecipes() {

    const response = await fetch("./data/recipes.json");

    if (!response.ok)
        throw new Error("Kunne ikke indlæse recipes.json");

    return await response.json();
}