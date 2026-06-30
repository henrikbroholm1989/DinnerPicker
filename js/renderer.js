export function renderTags(container, tags, selectedTags, onTagClicked) {

    container.replaceChildren();

    const sortedTags = Object.entries(tags)
        .sort((a, b) => a[1].localeCompare(b[1], "da"));

    for (const [id, name] of sortedTags) {

        const button = document.createElement("button");

        button.type = "button";
        button.className = "tag-chip";
        button.textContent = name;

        if (selectedTags.has(id))
            button.classList.add("selected");

        button.addEventListener("click", () => onTagClicked(id));

        container.appendChild(button);
    }
}

export function renderRecipes(container, recipes, tags) {

    container.replaceChildren();

    if (recipes.length === 0) {
        renderEmptyState(container);
        return;
    }

    for (const recipe of recipes) {

        const card = document.createElement("article");
        card.className = "recipe-card";

        const title = document.createElement("h3");
        title.textContent = recipe.name;

        card.appendChild(title);

        if (recipe.tags.length > 0) {

            const tagContainer = document.createElement("div");
            tagContainer.className = "recipe-tags";

            for (const tagId of recipe.tags) {

                const tag = document.createElement("span");
                tag.className = "recipe-tag";
                tag.textContent = tags[tagId];

                tagContainer.appendChild(tag);
            }

            card.appendChild(tagContainer);
        }

        container.appendChild(card);
    }
}

export function renderResultInfo(container, mode, totalMatches, shownCount) {

    container.replaceChildren();

    const count = document.createElement("p");

    count.textContent =
        totalMatches === 1
            ? "1 ret matcher"
            : `${totalMatches} retter matcher`;

    container.appendChild(count);

    if (mode === "any") {

        const info = document.createElement("p");

        info.textContent =
            `Viser ${shownCount} tilfældige forslag`;

        container.appendChild(info);
    }
}

export function renderEmptyState(container) {

    const message = document.createElement("p");

    message.className = "empty-state";
    message.textContent = "Ingen retter matcher de valgte filtre.";

    container.appendChild(message);
}