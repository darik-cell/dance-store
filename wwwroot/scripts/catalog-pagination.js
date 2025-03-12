$(document).ready(function(){
    // Обработка клика по ссылкам пагинации с учетом фильтров
    $('#paginationControls').on('click', '.page-link', function(e) {
        e.preventDefault();
        var page = $(this).data('page');
        // Получаем все данные из формы фильтра
        var filterData = $(".catalog-sidebar").serializeArray();
        // Добавляем параметр страницы
        filterData.push({name: "page", value: page});
        $.ajax({
            url: '/Home/GetProductsPage',
            data: filterData,
            success: function(result) {
                $('#productsContainer').html(result);
                // Обновление активного элемента пагинации
                $('#paginationControls').find('span.current-page').each(function(){
                    $(this).replaceWith('<a href="#" class="page-link" data-page="'+ $(this).text() +'">'+ $(this).text() +'</a>');
                });
                $('#paginationControls').find('a.page-link').each(function(){
                    if ($(this).data('page') == page) {
                        $(this).replaceWith('<span class="current-page">'+ page +'</span>');
                    }
                });
            },
            error: function(xhr, status, error) {
                alert("Ошибка при загрузке страницы: " + error);
            }
        });
    });
});
