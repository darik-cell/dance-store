// Получаем кнопку прокрутки
const scrollToTopBtn = document.getElementById('scrollToTopBtn');

// Функция для показа кнопки прокрутки
function toggleScrollToTopButton() {
    if (window.scrollY > 200) {  // Если прокрутка больше 200px
        scrollToTopBtn.style.display = 'block';  // Показываем кнопку
    } else {
        scrollToTopBtn.style.display = 'none';  // Скрываем кнопку
    }
}

// Функция для прокрутки наверх
function scrollToTop() {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'  // Плавная прокрутка
    });
}

// Добавляем слушатель события прокрутки страницы
window.addEventListener('scroll', toggleScrollToTopButton);

// Добавляем слушатель события на клик по кнопке
scrollToTopBtn.addEventListener('click', scrollToTop);
