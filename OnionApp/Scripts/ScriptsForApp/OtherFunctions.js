// Добавляет количество едениц товара в поле: elem-this сам елемент
function BtnPlas(elem) {
    var idProduct = elem.getAttribute("data-number");
    var inputNumberProduct = document.getElementById("countProduct-" + idProduct);
    if (inputNumberProduct !== null) {
        var a = +inputNumberProduct.value;
        var b = 1;
        var c = a + b;
        if (c <= 99) {
            inputNumberProduct.value = c;
        }
        else {
            inputNumberProduct.value = 99;
        }
    }
}
// Удаляет количество едениц товара в поле: elem-this сам елемент
function BtnMinus(elem) {
    var idProduct = elem.getAttribute("data-number");
    var inputNumberProduct = document.getElementById("countProduct-" + idProduct);

    if (inputNumberProduct !== null) {
        var a = +inputNumberProduct.value;
        var b = 1;
        if (a > 0) {
            var c = a - b;
            inputNumberProduct.value = c;
        }
        else {
            inputNumberProduct.value = 0;
        }
    }
}

// Анимация изменение цвета корзины (red)
function AnimateBasketRed()
{
    var basket = document.getElementById("btncart");
        basket.style.backgroundColor = "red";
        basket.style.borderColor = "red";
}
// Анимация изменение цвета корзины (blue)
function AnimateBasketBlue() {
    var basket = document.getElementById("btncart");
    basket.style.backgroundColor = "#337ab7";
    basket.style.borderColor = "#337ab7";
}





