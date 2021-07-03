const btn = document.getElementById('btn');

function toggleMenu(){
    const nav = document.getElementById('nav');
    nav.classList.toggle('active');

}

btn.addEventListener('click', toggleMenu);

const html = document.querySelector('html');
const checkbox = document.querySelector('#switch');

checkbox.addEventListener('change', function(){
    html.classList.toggle('dark-mode');
});
