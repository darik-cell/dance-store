$(document).ready(function(){
    // Открытие модального окна
    $("#addProductBtn").click(function(e){
        e.preventDefault();
        $("#addProductModal").fadeIn();
    });

    // Закрытие модального окна по клику на крестик
    $(".modal .close").click(function(){
        $("#addProductModal").fadeOut();
    });

    // Обработка отправки формы для добавления товара
    $("#addProductForm").on("submit", function(e){
        e.preventDefault();
        if (this.checkValidity() === false) {
            this.reportValidity();
            return;
        }
        var formData = new FormData(this);
        $.ajax({
            url: '/Product/AddProduct', // URL действия контроллера для добавления товара
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function(response) {
                alert("Товар успешно добавлен!");
                $("#addProductModal").fadeOut();
                // После добавления товара обновляем список, используя текущие фильтры
                var currentPage = $(".current-page").text() || "1";
                var filterData = $(".catalog-sidebar").serializeArray();
                filterData.push({name: "page", value: currentPage});
                $.ajax({
                    url: '/Home/GetProductsPage',
                    data: filterData,
                    success: function(result) {
                        $('#productsContainer').html(result);
                    },
                    error: function(xhr, status, error) {
                        alert("Ошибка при обновлении списка товаров: " + error);
                    }
                });
            },
            error: function(xhr, status, error) {
                alert("Ошибка при добавлении товара: " + error);
            }
        });
    });
});
