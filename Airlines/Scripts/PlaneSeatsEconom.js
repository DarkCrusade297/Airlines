﻿// план зала по рядам общая вместительность 300 мест
// планов может быть и больше... и разные...
k = 1;
var cinemaHall = {
    row: [6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6]
},
    cinemaHallMap = '';
$.each(cinemaHall.row, function (row, numberOfSeats) {
    cinemaHallRow = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        cinemaHallRow += '<div class="Eseat" data-row="' +
            k + '" data-seat="' +
            i + '"></div>';
    }
    cinemaHallRow += '<div class="emptyBtwSeatsEconom"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        cinemaHallRow += '<div class="Eseat" data-row="' +
            k + '" data-seat="' +
            i + '"></div>';
    }
    //собираем зал с проходами между рядами
    cinemaHallMap += cinemaHallRow + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

//заполняем в html зал номер 1
$('.econom').html(cinemaHallMap);
// тут по клику определяем что место выкуплено
$('.Eseat').on('click', function (e) {
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    $(e.currentTarget).toggleClass('Ebay');
    //показываем сколько билетов выкуплено
    EshowBaySeat();
});

function EshowBaySeat() {
    resultt = '';
    //ищем все места купленные и показываем список выкупленных мест
    $.each($('.Eseat.Ebay'), function (key, item) {
        resultt += '<div class="ticket">Ряд: ' +
            $(item).data().row + ' Место:' +
            $(item).data().seat + ' ЭК' + '</div>';
    });

    $('.Eresult').html(resultt);
}