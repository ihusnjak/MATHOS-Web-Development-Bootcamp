function openCloseNav() {
    const mobileBtn = document.getElementById('mobile-cta')
    nav = document.querySelector('nav')
    mobileBtnExit = document.getElementById('mobile-exit');

    mobileBtn.addEventListener('click', () => {
        nav.classList.add('menu-btn');
    })
    mobileBtnExit.addEventListener('click', () => {
        nav.classList.remove('menu-btn');
    })
}


function modifyQuote() {
    const elementsToChange = document.querySelectorAll('.mod-with-js');
  for (let i = 0; i < elementsToChange.length; i++) {
    const currentElement = elementsToChange[i];
    currentElement.innerText = "In hac habitasse platea dictumst. In varius magna sapien, sed euismod mi tincidunt et. Phasellus facilisis nunc at est ullamcorper mollis. Aliquam erat volutpat. Fusce interdum, tortor id vehicula faucibus, purus tellus blandit tellus, id imperdiet nisi metus fringilla arcu. Suspendisse quis sapien suscipit, fermentum ligula iaculis, ultricies metus. Nulla dapibus, justo convallis congue semper, arcu nisl convallis odio, non tincidunt lacus turpis eget nibh.";
  }
}