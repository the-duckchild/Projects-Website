function navbarContextHighlight(){
    const currentPathname = window.location.href
    const navLinks = document.querySelectorAll(".navBarElement");

    navLinks.forEach(navLink =>{
        navLink.classList.remove("textHighlight");
        if (navLink.href === currentPathname) {
        navLink.classList.add("textHighlight");
    }
});
    };

document.addEventListener('DOMContentLoaded', function() {
        navbarContextHighlight()});