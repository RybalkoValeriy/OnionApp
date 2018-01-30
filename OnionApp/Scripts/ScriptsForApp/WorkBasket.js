// Добавляет в корзину выбранный товар ajax: id-номер товара, count-количество единиц
function ajaxBasket(id, count) {
    var id = id;
    var count = count;
    if ((id !== null & count !== null) && (id !== undefined & count !== undefined)) {
        var dataToSend = 'id=' + encodeURIComponent(id) + '&count=' + encodeURIComponent(count);
        var xhr = new XMLHttpRequest();
        xhr.open("POST", '/Basket/Add', true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.onreadystatechange = function () {
            if (xhr.status === 200 && xhr.readyState === 4) {
                alert('Product added in basket');
                setInterval(AnimateBasketRed, 1000);
                setInterval(AnimateBasketBlue, 2000);

                var data = xhr.responseText;
                var tableName = "insTabl";
                insertTable(data, tableName);
            }
        }
        xhr.send(dataToSend);
    }
}

// Вспомогательная функция для вставки данных в таблицу: data-данные, tableName-имя таблицы
function insertTable(data, tableName) {
    var dataObject = JSON.parse(data);

    var insTabl = document.getElementById(tableName);
    insTabl.innerHTML = '';
    var fullsumm = 0;
    var pcount = 0;
    for (var i = 0; i < dataObject.length; i++) {
        if (dataObject[i].Car !== null && dataObject[i].Car !== undefined) {
            insertRowTable(dataObject[i], dataObject[i].Car, i + 1);
            var sm = dataObject[i].Car.Price * dataObject[i].Count;
            fullsumm += parseFloat(sm.toFixed(2));
            pcount += (dataObject[i].Count);
        }
    }
    insTabl.innerHTML += '<tr class="bg-info"><td colspan="2"></td><td>' + fullsumm + '</td><td>' + pcount + '</td></tr>';
}

// Вспомогательная функция которая добавляет строку в таблицу: object-елемент массива транзакции(сессия, объект-массив товар, номер по списку), object-товар с описанием, id-номер товара в корзине
function insertRowTable(object, object2, id) {
    var insTabl = document.getElementById("insTabl");
    if (insTabl !== null) {
        insTabl.innerHTML += '<tr id="product-' + id + '"></tr>';
        var product = document.getElementById("product-" + id);
        if (product !== null) {
            product.innerHTML += '<td>' + id + '</td>';
            product.innerHTML += '<td>' + object2.Name + '</td>';
            product.innerHTML += '<td>' + object2.Price + '</td>';
            product.innerHTML += '<td>' + object.Count + '</td>';
            product.innerHTML += '<td><button class="btn btn-default btn-xs" onclick="removeProductFromBasket(' + object2.Id + ',' + object.Count + ')"><span class="glyphicon glyphicon-remove"></span></button></td>';
        }
    }
}

// Удаление строки из корзины: id-номер count-количество
function removeProductFromBasket(id, count) {
    if (id !== null && count !== null) {
        var id = id;
        var count = count;
        var dataToSend = 'id=' + encodeURIComponent(id) + '&count=' + encodeURIComponent(count);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Basket/Remove', true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.onreadystatechange = function () {
            if (xhr.status === 200 && xhr.readyState === 4) {
                var data = xhr.responseText;
                var tablname = "insTabl";
                var CartCount = document.getElementById("CartCount");
                var cartcount = CartCount.innerText - count;
                CartCount.innerText = cartcount;
                insertTable(data, tablname);
            }
        };
        xhr.send(dataToSend);
    }
}

// Добавляем данные в корзину: elem-елемент который был нажат
function addProductToBasket(elem) {
    var idProduct = elem.getAttribute("data-number");
    var inputNumberProduct = document.getElementById("countProduct-" + idProduct);
    var warning = document.getElementById("mess-" + idProduct);
    var CartCount = document.getElementById("CartCount");

    if (inputNumberProduct.value !== '0') {
        warning.innerText = '';
        ajaxBasket(idProduct, inputNumberProduct.value);
        var cartСount = +CartCount.innerText;
        var accumulate = +inputNumberProduct.value;
        var resultBasket = cartСount + accumulate;

        CartCount.innerText = resultBasket;
        warning.innerText = "Product added in basket";
        inputNumberProduct.value = '0';
    }
    else if (warning !== null) {
        warning.innerText = "plase, add count product";
    }
}


var orderElement = document.getElementById("toOrder");
orderElement.addEventListener("click", validateBuyer);
// submit ReserveOrdered
function validateBuyer() {
    var firstName = document.getElementById("fistName");
    var lastName = document.getElementById("lasetName");
    var phone = document.getElementById("phone");
}
