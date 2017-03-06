var OrderModule = (function () {
    var response = {};
    var order = [];
    var orderLineItem = {value:"", id:""};
    response.createOrder = function (value, id, price) {
        orderLineItem.id = id;
        orderLineItem.value = value;
        order.push(orderLineItem);
        $("#orderContent").append("<div class='col-sm-6'><a href='#' id=" + id + " class='list-group-item'>" + value + "</a>" +
            "</div><div class='col-sm-6'><a href='#' id=" + id + " class='list-group-item'>" + price + "</a></div>");
        orderLineItem.value = "";
        orderLineItem.id = "";
    };
    response.showDrinks = function (state, drinksList) {
        if (state.Drinks == false) {
            $("#drinksContent").html("");
            var html = "<ul>";
            var list = "";
            $.each(drinksList, function (index, value) {
                list = list + "<li class='selectItem' data-price='"+value.price+"' data-id='"+value.id+"' data-val='"+value.name+"'>" + value.name + "</li>";
            });
            list = list + "</ul>";
            html = html + list;
            $("#drinksContent").append(html);
            state.Drinks = true;
        }
        if (state.Food === true) {
            $("#foodContent").html("");
            $("#foodContent").append('Food');
            state.Food = false;
        }
        if (state.Sweets === true) {
            $("#sweetsContent").html("");
            $("#sweetsContent").append('Sweets');
            state.Sweets = false;
        }
    }
    response.showFood = function (state, foodList) {
        if (state.Food == false) {
            $("#foodContent").html("");
            var html = "<ul>";
            var list = "";
            $.each(foodList, function (index, value) {
                list = list + "<li class='selectItem' data-price=" + value.price + " data-id=" + value.id + " data-val='" + value.name + "'>" + value.name + "</li>";
            });
            list = list + "</ul>";
            html = html + list;
            $("#foodContent").append(html);
            state.Food = true;
        }
        if (state.Drinks === true) {
            $("#drinksContent").html("");
            $("#drinksContent").append('Drinks');
            state.Drinks = false;
        }
        if (state.Sweets === true) {
            $("#sweetsContent").html("");
            $("#sweetsContent").append('Sweets');
            state.Sweets = false;
        }
    }
    response.showSweets = function (state, sweetsList) {
        if (state.Sweets == false) {
            $("#sweetsContent").html("");
            var html = "<ul>";
            var list = "";
            $.each(sweetsList, function (index, value) {
                list = list + "<li class='selectItem' data-price=" + value.price + " data-id=" + value.id + " data-val='" + value.name + "'>" + value.name + "</li>";
            });
            list = list + "</ul>";
            html = html + list;
            $("#sweetsContent").append(html);
            state.Sweets = true;
        }
        if (state.Food === true) {
            $("#foodContent").html("");
            $("#foodContent").append('Food');
            state.Food = false;
        }
        if (state.Drinks === true) {
            $("#drinksContent").html("");
            $("#drinksContent").append('Drinks');
            state.Drinks = false;
        }

    }
    response.order = order;
    return response;
})();