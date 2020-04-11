// план зала по рядам общая вместительность 300 мест
// планов может быть и больше... и разные...
k = 1;
var cinemaHall = {
    row: [6, 6, 6, 6, 6, 6, 6, 6]
},
    cinemaHallMap = '';
$.each(cinemaHall.row, function (row, numberOfSeats) {
    cinemaHallRow = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        cinemaHallRow += '<div class="Eseat" id="'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
    cinemaHallRow += '<div class="emptyBtwSeatsEconom"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        cinemaHallRow += '<div class="Eseat" id="' + k + '/' + i + '/' + 'e' + '"></div>';
    }
    //собираем зал с проходами между рядами
    cinemaHallMap += cinemaHallRow + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

//заполняем в html зал номер 1
$('.econom').html(cinemaHallMap);
// тут по клику определяем что место выкуплено
$('.Eseat').on('click', function (e) {
    var counter = $('#p').val();
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter <= 3 && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
            //показываем сколько билетов выкуплено
            EshowBaySeat();
            counter++;
            $('#p').val(counter);
        }
        else {
            if (e.currentTarget.classList.contains('bay')) {
                $(e.currentTarget).toggleClass('bay', false);
                //показываем сколько билетов выкуплено
                EshowBaySeat();
                counter--;
                $('#p').val(counter);
            }
        }
    }
});

function EshowBaySeat() {
    resultt = '';
    //ищем все места купленные и показываем список выкупленных мест
    $.each($('.Eseat.bay'), function (key, item) {
        resultt += '<div class="ticket">Ряд: ' +
            $(item).data().row + ' Место:' +
            $(item).data().seat + ' ЭК' + '</div>';
    });

    $('.Eresult').html(resultt);
}