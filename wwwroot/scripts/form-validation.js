document.getElementById('submit-btn').addEventListener('click', function(event) {
    event.preventDefault(); // Отменить стандартное действие кнопки (не отправлять форму сразу)

    // Очистить предыдущие сообщения об ошибках
    clearErrors();

    let isValid = true;

    // Проверки полей
    // 1. Проверка обязательных полей
    const requiredFields = [
        { id: 'first_name', name: 'Имя' },
        { id: 'last_name', name: 'Фамилия' },
        { id: 'email', name: 'Электронная почта' },
        { id: 'address', name: 'Адрес доставки' },
        { id: 'delivery_date', name: 'Дата доставки' },
        { id: 'delivery_time', name: 'Время доставки' },
        { id: 'phone', name: 'Номер телефона' }
    ];

    requiredFields.forEach(field => {
        const value = document.getElementById(field.id).value.trim();
        if (!value) {
            showError(field.id, `Поле "${field.name}" обязательно для заполнения.`);
            isValid = false;
        }
    });

    // 2. Проверка формата имени и фамилии
    const namePattern = /^[A-Za-zА-Яа-яЁё]{2,50}$/;
    const firstName = document.getElementById('first_name').value.trim();
    const lastName = document.getElementById('last_name').value.trim();

    if (firstName && !namePattern.test(firstName)) {
        showError('first_name', 'Имя должно содержать только буквы и быть от 2 до 50 символов.');
        isValid = false;
    }

    if (lastName && !namePattern.test(lastName)) {
        showError('last_name', 'Фамилия должна содержать только буквы и быть от 2 до 50 символов.');
        isValid = false;
    }

    // 3. Проверка формата электронной почты
    const email = document.getElementById('email').value.trim();
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (email && !emailPattern.test(email)) {
        showError('email', 'Электронная почта введена неверно.');
        isValid = false;
    }

    // 4. Проверка формата номера телефона
    const phone = document.getElementById('phone').value.trim();
    const phonePattern = /^\+7\s\d{3}\s\d{3}-\d{2}-\d{2}$/;

    if (phone && !phonePattern.test(phone)) {
        showError('phone', 'Номер телефона должен быть в формате +7 123 456-78-90.');
        isValid = false;
    }

    // 5. Проверка даты доставки
    const deliveryDateValue = document.getElementById('delivery_date').value;
    if (deliveryDateValue) {
        const deliveryDate = new Date(deliveryDateValue);
        const today = new Date();
        today.setHours(0, 0, 0, 0); // Устанавливаем время на начало дня
        const maxDate = new Date();
        maxDate.setDate(today.getDate() + 30); // Допустим, доставка не более чем через 30 дней

        if (deliveryDate < today) {
            showError('delivery_date', 'Дата доставки не может быть в прошлом.');
            isValid = false;
        }

        if (deliveryDate > maxDate) {
            showError('delivery_date', 'Дата доставки не может быть более чем через 30 дней.');
            isValid = false;
        }
    }

    // Дополнительно: Проверка адреса (минимальная длина уже проверена как обязательное поле)
    const address = document.getElementById('address').value.trim();
    if (address && address.length < 5) {
        showError('address', 'Адрес доставки должен быть не короче 5 символов.');
        isValid = false;
    }

    // Если все проверки прошли, отправляем форму
    if (isValid) {
        document.getElementById('catalog-form').submit();
        alert("Заказ успешно оформлен!");
    }
});

// Функция для отображения ошибок
function showError(fieldId, message) {
    const errorElement = document.getElementById(`${fieldId}_error`);
    if (errorElement) {
        errorElement.textContent = message;
        errorElement.style.display = 'block';
    }
}

// Функция для очистки предыдущих ошибок
function clearErrors() {
    const errorMessages = document.querySelectorAll('.error-message');
    errorMessages.forEach(function(element) {
        element.textContent = '';
        element.style.display = 'none';
    });
}
