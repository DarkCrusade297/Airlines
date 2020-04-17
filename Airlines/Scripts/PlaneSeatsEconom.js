// план зала по рядам общая вместительность 300 мест
// планов может быть и больше... и разные...
k = 1;
kb = 1;
tbk = 0;
counter = 0;
$('#btn').attr("disabled", true);
var PlaneHalle = {
    row: [6, 6, 6, 6, 6, 6, 6, 6]
},
    PlaneHallMape = '';
$.each(PlaneHalle.row, function (row, numberOfSeats) {
    PlaneHallRowe = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        PlaneHallRowe += '<div class="Eseat" id="'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
    PlaneHallRowe += '<div class="emptyBtwSeatsEconom"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRowe += '<div class="Eseat" id="'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
    //собираем зал с проходами между рядами
    PlaneHallMape += PlaneHallRowe + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

var PlaneHallb = {
    row: [2, 2, 2]
},
    PlaneHallMapb = '';
$.each(PlaneHallb.row, function (row, numberOfSeats) {
    PlaneHallRowb = '';
    for (i = 1; i <= numberOfSeats / 2; i++) {
        // собираем ряды
        PlaneHallRowb += '<div class="Bseat" id="'+ kb + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRowb += '<div class="emptyBtwSeatsBuisness"></div>';
    for (i = numberOfSeats / 2 + 1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRowb += '<div class="Bseat" id="'+ kb + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRowb += '<div class="emptyBuisness"></div>';
    //собираем отсек с проходами между рядами
    PlaneHallMapb += PlaneHallRowb + '<div class="passageBetween">&nbsp;</div>';
    kb++;
});

//заполняем в html зал номер 1
$('.econom').html(PlaneHallMape);
$('.buisness').html(PlaneHallMapb);
// тут по клику определяем что место выкуплено
$('.Eseat').on('click', function (e) {
    var counter = $('#c').val();
    var id = e.currentTarget.id;
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter < $('#p').val() && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
            //показываем сколько билетов выкуплено
            counter++;
            $('#c').val(counter);
            for (i = 0; i < $('#p').val(); i++) {
                if ($('#seats_' + i + '_').val() == "") {
                    $('#seats_' + i + '_').val(id);
                    break;
                }
            }
            if (counter < $('#p').val()) {
                $('#btn').attr("disabled", true);
            }
            else {
                $('#btn').attr("disabled", false);
            }
        }
        else {
            if (e.currentTarget.classList.contains('bay')) {
                var empty = "";
                $(e.currentTarget).toggleClass('bay', false);
                //показываем сколько билетов выкуплено
                counter--;
                $('#c').val(counter);
                for (i = 0; i < $('#p').val(); i++) {
                    if ($('#seats_' + i + '_').val() == id) {
                        $('#seats_' + i + '_').val(empty);
                        break;
                    }
                }
                $('#btn').attr("disabled", true);
            }
        }
    }
});

$('.Bseat').on('click', function (e) {
    var counter = $('#c').val();
    var id = e.currentTarget.id;
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter < $('#p').val() && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
            //показываем сколько билетов выкуплено
            counter++;
            $('#c').val(counter);
            for (i = 0; i < $('#p').val(); i++) {
                if ($('#seats_' + i + '_').val() == "") {
                    $('#seats_' + i + '_').val(id);
                    break;
                }
            }
            if (counter < $('#p').val()) {
                $('#btn').attr("disabled", true);
            }
            else {
                $('#btn').attr("disabled", false);
            }
        }
        else {
            if (e.currentTarget.classList.contains('bay')) {
                var empty = "";
                $(e.currentTarget).toggleClass('bay', false);
                //показываем сколько билетов выкуплено
                counter--;
                $('#c').val(counter);
                for (i = 0; i < $('#p').val(); i++) {
                    if ($('#seats_' + i + '_').val() == id) {
                        $('#seats_' + i + '_').val(empty);
                        break;
                    }
                }
                $('#btn').attr("disabled", true);
            }
        }
    }
});

for (i = 0; i <= $('#ListSeats').length; i++) {
    var valu = document.getElementById("ListSeats").options[i].text;
    document.getElementById(valu).classList.add("no");
}

//$('#btn').onmouseover(function (e) {
//    if (e.currentTarget.hasAttribute("disabled")) {
//        alert('Выбрано недостаточно мест в самолете, пожалуйста, выберите недостующие места. Количество выбранных мест должно быть равным количеству пассажиров.');
//    }
//});