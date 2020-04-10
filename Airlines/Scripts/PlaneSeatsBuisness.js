
k = 1;
var PlaneHall = {
    row: [2, 2, 2]
},
    PlaneHallMap = '';
$.each(PlaneHall.row, function (row, numberOfSeats) {
    PlaneHallRow = '';
    for (i = 1; i <= numberOfSeats/2; i++) {
        // собираем ряды
        PlaneHallRow += '<div class="Bseat" data-row="' +
            k + '" data-seat="' +
            i + '"></div>';
    }
    PlaneHallRow += '<div class="emptyBtwSeatsBuisness"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        // собираем ряды
        PlaneHallRow += '<div class="Bseat" data-row="' +
            k + '" data-seat="' +
            i + '"></div>';
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
    var counter = $('#p').val();
    // fl полуячаем из e e.currentTarget.GetAttr('а');
    //
    // если первый раз кликнули билет выкупили, 
    // если повторно значит вернули билет
    if (counter <= 3 && e.currentTarget.classList.contains('Bbay') == false) {
        $(e.currentTarget).toggleClass('Bbay', true);
        //показываем сколько билетов выкуплено
        EshowBaySeat();
        counter++;
        $('#p').val(counter);
    }
    else {
        if (e.currentTarget.classList.contains('Bbay')) {
            $(e.currentTarget).toggleClass('Bbay', false);
            //показываем сколько билетов выкуплено
            EshowBaySeat();
            counter--;
            $('#p').val(counter);
        }
    }
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