// план зала по рядам общая вместительность 300 мест
// планов может быть и больше... и разные...
k = 1;
counter = 0;
var PlaneHall = {
    row: [6, 6, 6, 6, 6, 6, 6, 6]
},
    PlaneHallMap = '';
$.each(PlaneHall.row, function (row, numberOfSeats) {
    PlaneHallRow = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        PlaneHallRow += '<div class="Eseat" id="'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
    PlaneHallRow += '<div class="emptyBtwSeatsEconom"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRow += '<div class="Eseat" id="' + k + '/' + i + '/' + 'e' + '"></div>';
    }
    //собираем зал с проходами между рядами
    PlaneHallMap += PlaneHallRow + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

//заполняем в html зал номер 1
$('.econom').html(PlaneHallMap);
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