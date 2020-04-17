// план зала по рядам общая вместительность 300 мест
// планов может быть и больше... и разные...
k = 1;
kb = 1;
counter = 0;
var PlaneHalle = {
    row: [6, 6, 6, 6, 6, 6, 6, 6]
},
    PlaneHallMape = '';
$.each(PlaneHalle.row, function (row, numberOfSeats) {
    PlaneHallRowe = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        PlaneHallRowe += '<div class="Eseat" id="' + 'a'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
    PlaneHallRowe += '<div class="emptyBtwSeatsEconom"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRowe += '<div class="Eseat" id="' + 'a' + k + '/' + i + '/' + 'e' + '"></div>';
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
        PlaneHallRowb += '<div class="Bseat" id="' + 'a' + kb + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRowb += '<div class="emptyBtwSeatsBuisness"></div>';
    for (i = numberOfSeats / 2 + 1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRowb += '<div class="Bseat" id="' + 'a' + kb + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRowb += '<div class="emptyBuisness"></div>';
    //собираем отсек с проходами между рядами
    PlaneHallMapb += PlaneHallRowb + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

//заполняем в html зал номер 1
$('.econom').html(PlaneHallMape);
$('.buisness').html(PlaneHallMapb);
// тут по клику определяем что место выкуплено
$('.Eseat').on('click', function (e) {
    var counter = $('#c').val();
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter < $('#p').val() && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
            //показываем сколько билетов выкуплено
            counter++;
            $('#c').val(counter);
        }
        else {
            if (e.currentTarget.classList.contains('bay')) {
                $(e.currentTarget).toggleClass('bay', false);
                //показываем сколько билетов выкуплено
                counter--;
                $('#c').val(counter);
            }
        }
    }
});

$('.Bseat').on('click', function (e) {
    var counter = $('#c').val();
    // fl полуячаем из e e.currentTarget.GetAttr('а');
    //
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter < $('#p').val() && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
            //показываем сколько билетов выкуплено
            counter++;
            $('#c').val(counter);
        }
        else {
            if (e.currentTarget.classList.contains('bay')) {
                $(e.currentTarget).toggleClass('bay', false);
                //показываем сколько билетов выкуплено
                counter--;
                $('#c').val(counter);
            }
        }
    }
});

for (i = 0; i <= $('#ListSeats').length; i++) {
    var valu = document.getElementById("ListSeats").options[i].text;
    document.getElementById("a"+valu).classList.add("no");
}