let burger;
let navDropdown;
let jsonData;
let tree;

window.addEventListener('load', init_Burger());

function init_Index(result) {
    ;
    displayJson(result, "main-pre");
}

function init_ApiPage(jsonResultSuccess, jsonResultFailed) {
    displayJson(jsonResultSuccess, "success-pre");
    displayJson(jsonResultFailed, "failed-pre");
}

function init_Burger() {
    burger = document.getElementById('hamburger');
    navDropdown = document.getElementById('nav-left');
    burger.addEventListener('click', BurgerClick);
}

function BurgerIconAnimation() {
    let burgerLines = burger.children;
    burgerLines[1].classList.toggle('visibility-hidden');
    burgerLines[0].classList.toggle('rotate-layer-top');
    burgerLines[2].classList.toggle('rotate-layer-bottom');
}

function BurgerClick() {
    BurgerIconAnimation();
    navDropdown.classList.toggle('drop-nav');
}

function setUrlBar(url) {
    document.getElementById('searchInput').value = url;
}

function displayJson(json, preElement) {
    tree = JsonView.createTree(json);
    JsonView.render(tree, document.getElementById(preElement));
    if (tryParseJson(json)) {
        var serializedJson = JSON.parse(json);
        if (serializedJson.StatusCode == 404) {
            document.getElementById('response-title').innerText = serializedJson.StatusCode + ": " + serializedJson.ReasonPhrase;
        }
    }
    JsonView.expandChildren(tree);
}

function tryParseJson(json) {
    try {
        JSON.parse(json);
    }
    catch (e) {
        return false;
    }
    return true;
}