function navbarContextHighlight(){
    const currentPathname = window.location.pathname
    const navLinks = document.querySelectorAll(".navBarElement");

    navLinks.forEach(navLink =>{
        if (navLink.href && navLink.href.includes(currentPathname)) {
        navLink.classList.add("textHighlight");
    }
});
    };

document.addEventListener('DOMContentLoaded', function() {
        navbarContextHighlight()});