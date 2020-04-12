
k = 1;
var PlaneHall = {
    row: [2, 2, 2]
},
    PlaneHallMap = '';
$.each(PlaneHall.row, function (row, numberOfSeats) {
    PlaneHallRow = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        PlaneHallRow += '<div class="Bseat" id="' + k + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRow += '<div class="emptyBtwSeatsBuisness"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRow += '<div class="Bseat" id="' + k + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRow += '<div class="emptyBuisness"></div>';
    //собираем отсек с проходами между рядами
    PlaneHallMap += PlaneHallRow + '<div class="passageBetween">&nbsp;</div>';
    k++;
});

//заполняем в html зал отсек
$('.buisness').html(PlaneHallMap);
// тут по клику определяем что место выкуплено
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
            showBayBSeat();
            counter++;
            $('#c').val(counter);
        }
        else {
            if (e.currentTarget.classList.contains('bay')) {
                $(e.currentTarget).toggleClass('bay', false);
                //показываем сколько билетов выкуплено
                showBayBSeat();
                counter--;
                $('#c').val(counter);
            }
        }
    }
});

function showBayBSeat() {
    result = '';
    //ищем все места купленные и показываем список выкупленных мест
    $.each($('.Bseat.bay'), function (key, item) {
        result += '<div class="ticket">Ряд: ' +
            $(item).data().row + ' Место:' +
            $(item).data().seat + ' БК' + '</div>';
    });

    $('.Bresult').html(result);
}