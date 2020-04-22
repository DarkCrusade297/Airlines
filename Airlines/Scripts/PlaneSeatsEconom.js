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
        PlaneHallRowe += '<div class="Eseat" id="'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
    PlaneHallRowe += '<div class="emptyBtwSeatsEconom"></div>';
    for (i = numberOfSeats / 2 +1; i <= numberOfSeats; i++) {
        PlaneHallRowe += '<div class="Eseat" id="'+ k + '/' + i + '/' + 'e' + '"></div>';
    }
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
        PlaneHallRowb += '<div class="Bseat" id="'+ kb + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRowb += '<div class="emptyBtwSeatsBuisness"></div>';
    for (i = numberOfSeats / 2 + 1; i <= numberOfSeats; i++) {
        PlaneHallRowb += '<div class="Bseat" id="'+ kb + '/' + i + '/' + 'b' + '"></div>';
    }
    PlaneHallRowb += '<div class="emptyBuisness"></div>';
    PlaneHallMapb += PlaneHallRowb + '<div class="passageBetween">&nbsp;</div>';
    kb++;
});

$('.econom').html(PlaneHallMape);
$('.buisness').html(PlaneHallMapb);
$('.Eseat').on('click', function (e) {
    var counter = $('#c').val();
    var id = e.currentTarget.id;
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter < $('#p').val() && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
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
    if (e.currentTarget.classList.contains('no') == true) { }
    else {
        if (counter < $('#p').val() && e.currentTarget.classList.contains('bay') == false) {
            $(e.currentTarget).toggleClass('bay', true);
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
for (i = 0; i < $('#ListSeats').children().length; i++) {
    var valu = document.getElementById("ListSeats").options[i].text;
    document.getElementById(valu).classList.add("no");
}