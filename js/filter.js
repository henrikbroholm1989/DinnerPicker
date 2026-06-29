export function filterRecipes(recipes, selectedTags, mode) {

    if (selectedTags.length === 0)
        return recipes;

    if (mode === "all") {

        return recipes.filter(recipe =>
            selectedTags.every(tag =>
                recipe.tags.includes(tag)
            )
        );
    }

    return recipes.filter(recipe =>
        selectedTags.some(tag =>
            recipe.tags.includes(tag)
        )
    );
}