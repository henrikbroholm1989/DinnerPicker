export function filterRecipes(recipes, selectedTags, mode) {

    // Ingen filtre valgt → vis alle retter
    if (selectedTags.size === 0)
        return recipes;

    return recipes.filter(recipe => {

        const matches =
            recipe.tags.filter(tag => selectedTags.has(tag)).length;

        if (mode === "all") {
            return matches === selectedTags.size;
        }

        return matches > 0;
    });
}