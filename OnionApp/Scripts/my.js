function BtnPlas(t) {
    var btn = t.getAttribute("data-number");
    var Inp = document.getElementById("countProduct-" + btn);
    if (Inp !== null) {
        var a = +Inp.value;
        var b = 1;
        var c = a + b;
        if (c <= 99) {
            Inp.value = c;
        }
        else {
            Inp.value = 99;
        }
    }
}

function BtnMinus(t) {
    var btn = t.getAttribute("data-number");
    var Inp = document.getElementById("countProduct-" + btn);

    if (Inp !== null) {
        var a = +Inp.value;
        var b = 1;
        if (a > 0) {
            var c = a - b;
            Inp.value = c;
        }
        else {
            Inp.value = 0;
        }
    }
}

function BtnAdd(t) {
    var btn = t.getAttribute("data-number");
    var Inp = document.getElementById("countProduct-" + btn);
    var warning = document.getElementById("mess-" + btn);
    var CartCount = document.getElementById("CartCount");

    if (Inp.value !== '0') {
        warning.innerText = '';

        var cartcount = +CartCount.innerText;
        var inp = +Inp.value;
        var res = cartcount + inp;

        CartCount.innerText = res;
        ajaxBasket(btn, inp);
        warning.innerText = "Product added in basket";
        Inp.value = '0';
    }
    else if (warning !== null) {
        warning.innerText = "plase, add count product";
    }
}

function AnimateBasketRed()
{
    var basket = document.getElementById("btncart");
        basket.style.backgroundColor = "red";
        basket.style.borderColor = "red";
}

function AnimateBasketBlue() {
    var basket = document.getElementById("btncart");
    basket.style.backgroundColor = "#337ab7";
    basket.style.borderColor = "#337ab7";
}


function DelProduct(id,count) {
    if (id !== null && count != null)
    {
        var id = id;
        var count = count;

        var xhr = new XMLHttpRequest();
        xhr.open('GET', '/Home/Remove?id=' + id + '&count=' + count, true);
        xhr.onreadystatechange = function ()
        {
            if (xhr.status == 200 && xhr.readyState == 4)
            {
                var data = xhr.responseText;
                var tablname = "insTabl";
                var CartCount = document.getElementById("CartCount");
                var cartcount = CartCount.innerText - count;
                CartCount.innerText = cartcount;
                Insert(data, tablname);
            }
        }
        xhr.send();
    }
}


