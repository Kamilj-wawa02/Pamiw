export function setTheme(themeName) {
    
    let newLink = document.createElement("link");
    newLink.setAttribute("id", "theme");
    newLink.setAttribute("rel", "stylesheet");
    newLink.setAttribute("type", "text/css");
    newLink.setAttribute("href", `css/${themeName}-theme.css`);
    
    let head = document.getElementsByTagName("head")[0];
    head.querySelector("#theme").remove();
    head.appendChild(newLink);

    let newAppLink = document.createElement("link");
    newAppLink.setAttribute("id", "appstyle");
    newAppLink.setAttribute("rel", "stylesheet");
    newAppLink.setAttribute("type", "text/css");
    newAppLink.setAttribute("href", `css/app.css`);

    head.querySelector("#appstyle").remove();
    head.appendChild(newAppLink);

}