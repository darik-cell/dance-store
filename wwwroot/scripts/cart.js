document.addEventListener('DOMContentLoaded', function () {
    // Функция для пересчета цен в корзине
    function updateCart() {
        let totalPrice = 0; // Общая стоимость всех товаров
        let totalItems = 0; // Общее количество товаров

        // Получаем все строки товаров в корзине
        const cartItems = document.querySelectorAll('.cart-item');

        cartItems.forEach(item => {
            const pricePerItem = parseFloat(item.querySelector('.cart-item-unit-price').textContent.replace(' &#8381;/шт', '').replace(' ', ''));
            const quantity = parseInt(item.querySelector('.cart-item-count').value);
            const totalItemPrice = pricePerItem * quantity;

            // Обновляем цену каждого товара
            item.querySelector('.cart-item-price-total').textContent = `${Math.round(totalItemPrice)} ₽`; // Используем Math.round для целых чисел

            totalPrice += totalItemPrice; // Добавляем к общей стоимости
            totalItems += quantity; // Добавляем количество товаров
        });

        // Обновляем отображение общей стоимости и количества товаров
        document.querySelector('.total-price').textContent = Math.round(totalPrice); // Также округляем общую цену
        document.querySelector('.items-total-count').textContent = totalItems;
    }

    // Функция для удаления товара из корзины
    function deleteItem(event) {
        const itemRow = event.target.closest('.cart-item');
        itemRow.remove(); // Удаляем строку товара из таблицы

        // После удаления пересчитываем корзину
        updateCart();
    }

    // Слушатели событий для изменения количества товара
    document.querySelectorAll('.cart-item-count').forEach(input => {
        input.addEventListener('input', updateCart);
    });

    // Добавляем обработчики на кнопки удаления
    document.querySelectorAll('.cart-item-btn-delete').forEach(button => {
        button.addEventListener('click', deleteItem);
    });

    // Инициализация
    updateCart();
});
