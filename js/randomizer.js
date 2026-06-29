export function pickRandomRecipe(recipes) {

    if (recipes.length === 0)
        return null;

    const index = Math.floor(Math.random() * recipes.length);

    return recipes[index];
}