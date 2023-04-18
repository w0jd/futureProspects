const openModalButtons = document.querySelectorAll('[data-popup-target]')
const closeModalButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.getElementById('overlay')
const body = document.querySelector('body')

openModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        const popup = document.querySelector(button.dataset.popupTarget)
        openPopup(popup)
    })
})

overlay.addEventListener('click', () => {
    const modals = document.querySelectorAll('.popup.active')
    modals.forEach(modal => {
        closePopup(modal)
    })
})

closeModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        const popup = button.closest('.popup')
        closePopup(popup)
    })
})

function openPopup(popup) {
    if (popup == null) return
    popup.classList.add('active')
    overlay.classList.add('active')
    body.classList.add('stop-scrolling')
}

function closePopup(popup) {
    if (popup == null) return
    popup.classList.remove('active')
    overlay.classList.remove('active')
    body.classList.remove('stop-scrolling')
}





const font_changing = document.querySelector('[font-changing]')
// const blank_changing = document.querySelector('[blank-changing]')

window.addEventListener('scroll', () => {
    const current = window.scrollY;
    font_changing.style.fontSize = `clamp(5vh, ${current*0.3}px, 12vh)`;
    font_changing.style.transition = '100ms ease';
    
    // blank_changing.style.height = `clamp(5vh, ${current}vh, 50vh)`;
})
