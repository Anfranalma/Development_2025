const hamburgerMenu = document.querySelector('#navigation .nav-icon');
const navContenct = document.querySelector('#nav-contenct');
const closeNavButton = document.querySelector('#nav-content .close-btn');
const navLinks = document.querySelector('#nav-content nav ul li a')

hamburgerMenu.addEventListener('click', ()=>{
    navContenct.classList.add('show');
    document.body.style.overflow="hidden"; //this will prevent to keep scrolling when the menu is open
})

closeNavButton.addEventListener('click0', ()=>{
    navContenct.classList.remove('Show');
    document.body.style.overflow="initial";
})
navLinks.foreach( link =>{
    link.addEventListener('click', ()=>{
        navContenct.classList.remove('Show');
        document.body.style.overflow="initial";
    })
})