const container = document.querySelector('.container');
const signupButton = document.querySelector('.signup-section header');
const loginButton = document.querySelector('.login-section header');

loginButton.addEventListener('click', ()=>{
    container.classList.add('active');
});


signupButton.addEventListener('click', ()=>{
    container.classList.remove('active');
});

const loginsubmit = document.querySelector('.login-section header');
loginsubmit.addEventListener("click", () => {

});


document.querySelector(".signup-section header").addEventListener("click", function (event) {
    event.preventDefault(); // Prevent the default behavior of the browser
    fetch("/Identity/Account/Register")
        .then(response => response.text())
        .then(html => document.body.innerHTML = html); // Replace the entire page content with the fetched HTML
});

document.querySelector(".login-section header").addEventListener("click", function (event) {
    event.preventDefault(); // Prevent the default behavior of the browser
    fetch("/Identity/Account/Login")
        .then(response => response.text())
        .then(html => document.body.innerHTML = html); // Replace the entire page content with the fetched HTML
});