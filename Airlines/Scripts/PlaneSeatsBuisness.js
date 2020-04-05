// план зала по рядам общая вместительность 300 мест
// планов может быть и больше... и разные...
k = 1;
var cinemaHall = {
    row: [2, 2, 2, 2, 2, 2, 2]
},
    cinemaHallMap = '';
$.each(cinemaHall.row, function (row, numberOfSeats) {
    cinemaHallRow = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        cinemaHallRow += '<div class="Bseat" data-row="' +
            k + '" data-seat="' +
            i + '"></div>';
    }
    cinemaHallRow += '<div class="emptyBtwSeatsBuisness"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        cinemaHallRow += '<div class="Bseat" data-row="' +
            k + '" data-seat="' +
            i + '"></div>';
    }
    cinemaHallRow += '<div class="emptyBuisness"></div>';
    //собираем зал с проходами между рядами
    cinemaHallMap += cinemaHallRow + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

//заполняем в html зал номер 1
$('.buisness').html(cinemaHallMap);
// тут по клику определяем что место выкуплено
$('.Bseat').on('click', function (e) {
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    $(e.currentTarget).toggleClass('Bbay');
    //показываем сколько билетов выкуплено
    showBayBSeat();
});

function showBayBSeat() {
    result = '';
    //ищем все места купленные и показываем список выкупленных мест
    $.each($('.Bseat.Bbay'), function (key, item) {
        result += '<div class="ticket">Ряд: ' +
            $(item).data().row + ' Место:' +
            $(item).data().seat + ' БК' + '</div>';
    });

    $('.Bresult').html(result);
}