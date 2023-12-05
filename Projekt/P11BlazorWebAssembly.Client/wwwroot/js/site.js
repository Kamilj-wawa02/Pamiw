export function setTheme(themeName) {

    // dodajemy link css dla naszego motywu
    let newLink = document.createElement("link");
    newLink.setAttribute("id", "theme");
    newLink.setAttribute("rel", "stylesheet");
    newLink.setAttribute("type", "text/css");
    newLink.setAttribute("href", `css/${themeName}-theme.css`);

    // usuwamy i podmieniamy motyw
    let head = document.getElementsByTagName("head")[0];
    head.querySelector("#theme").remove();
    head.appendChild(newLink);

}