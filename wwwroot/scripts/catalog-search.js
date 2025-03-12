$(document).ready(function(){
    var debounceTimer;

    // Функция, выполняющая AJAX-запрос для поиска товаров
    function searchProducts(term) {
        $.ajax({
            url: '/Home/SearchProductsPage',
            data: { searchTerm: term },
            success: function(result) {
                $('#productsContainer').html(result);
            },
            error: function(xhr, status, error) {
                console.error("Ошибка при обновлении товаров: " + error);
            }
        });
    }

    // Обработка ввода в поле поиска с задержкой 1500 мс
    $("#productSearch").on("input", function(){
        var term = $(this).val().trim();

        // Если поле пустое, скрываем автоподсказки и не ищем
        if(term.length === 0){
            $("#searchSuggestions").empty().hide();
            return;
        }

        // Запрос для автоподсказок (без задержки)
        $.ajax({
            url: '/Home/SearchProducts',
            data: { term: term },
            success: function(data){
                var suggestions = $("#searchSuggestions");
                suggestions.empty();
                if(data.length > 0){
                    $.each(data, function(index, item){
                        suggestions.append('<li data-id="'+item.id+'">'+item.name+'</li>');
                    });
                    suggestions.show();
                } else {
                    suggestions.hide();
                }
            },
            error: function(xhr, status, error){
                console.error("Ошибка при поиске подсказок: " + error);
            }
        });

        // Устанавливаем debounce на обновление карточек товаров
        clearTimeout(debounceTimer);
        debounceTimer = setTimeout(function(){
            searchProducts(term);
        }, 1500);
    });

    // При клике на элемент списка автоподсказок
    $("#searchSuggestions").on("click", "li", function(){
        var selectedName = $(this).text();
        // Заполняем поле поиска выбранным значением
        $("#productSearch").val(selectedName);
        // Скрываем автоподсказки
        $("#searchSuggestions").empty().hide();
        // Отменяем ожидающий таймер и выполняем поиск сразу
        clearTimeout(debounceTimer);
        searchProducts(selectedName);
    });

    // Скрываем подсказки при клике вне поля
    $(document).on("click", function(e){
        if(!$(e.target).closest("#productSearch, #searchSuggestions").length){
            $("#searchSuggestions").empty().hide();
        }
    });
});
