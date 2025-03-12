$(document).ready(function(){
    // Обработка отправки формы фильтров
    $(".catalog-sidebar").on("submit", function(e){
        e.preventDefault(); // Отменяем стандартную отправку формы
        // Собираем данные из формы
        var filterData = $(this).serializeArray();
        // При отправке фильтра всегда начинаем с первой страницы
        filterData.push({name: "page", value: 1});
        // Выполняем AJAX-запрос для получения отфильтрованных товаров
        $.ajax({
            url: '/Home/GetProductsPage', // URL для подгрузки товаров
            data: filterData,
            success: function(result) {
                $('#productsContainer').html(result);
                // Если нужно, обновляем и пагинацию – можно вернуть обновлённую разметку с сервера
            },
            error: function(xhr, status, error) {
                alert("Ошибка при фильтрации: " + error);
            }
        });
    });
});
