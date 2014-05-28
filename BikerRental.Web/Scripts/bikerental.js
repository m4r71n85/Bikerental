//Quick reservation
function styleDateTimePicker() {
    $('.datetime-picker').datetimepicker('option', 'beforeShowDay');

    $('.datetime-picker').datetimepicker({
        minDate: 0,
        minTime: '08:00',
        maxTime: '19:01',
        step: 30,
    });
}

function styleDateTimePickerAdvanced() {
    function unavailable(date) {
        return 'xdsoft_disabled';
    }

    $('.datetime-picker-advanced').each(function(item){
        var self = $(this);
        var allowedTimes = self.data('allow-times').split(',');
        allowedTimes = allowedTimes[0] == "" ? [] : allowedTimes;
        var allowedWeekdays = self.data('allow-weekdays').split(',');
        allowedWeekdays = allowedWeekdays[0] == "" ? ['1', '2', '3', '4', '5', '6', '7'] : allowedWeekdays;
        self.datetimepicker({
            minDate: 0,
            allowTimes: allowedTimes,
            beforeShowDay: function (date) {
                if (allowedWeekdays.indexOf((date.getDay() + 1).toString()) == -1) {
                    return 'xdsoft_disabled';
                }
                return;
            }
        });
    });
}


function styleScroller() {
    $('.scroll-pane').jScrollPane();
}

function chooseTourOrRentalSuccess() {
    styleScroller();
    styleDateTimePicker();
    styleDateTimePickerAdvanced();
}
//END Quick reservation

var timeout = 500;
var closetimer = 0;
var ddmenuitem = 0;

// open hidden layer
function mopen(id) {
    // cancel close timer
    mcancelclosetime();

    // close old layer
    if (ddmenuitem) ddmenuitem.style.visibility = 'hidden';

    // get new layer and show it
    ddmenuitem = document.getElementById(id);
    ddmenuitem.style.visibility = 'visible';

}
// close showed layer
function mclose() {
    if (ddmenuitem) ddmenuitem.style.visibility = 'hidden';
}

// go close timer
function mclosetime() {
    closetimer = window.setTimeout(mclose, timeout);
}

// cancel close timer
function mcancelclosetime() {
    if (closetimer) {
        window.clearTimeout(closetimer);
        closetimer = null;
    }
}

// close layer when click-out
document.onclick = mclose;
// -->

enl_gifpath = "http://localhost:28321/Content/Images/Bikerental/Front/cal.gif";
enl_ani = 4;
enl_brdsize = 20;
enl_maxstep = 30;
enl_speed = 12;
enl_shadow = 1;
enl_shadowintens = 20;
enl_shadowsize = 1;
enl_center = 0;
enl_preload = 1;
enl_drgdrop = 0;
enl_darksteps = 5;
enl_buttonurl[0] = 'prev';
enl_buttontxt[0] = 'Previous picture [left arrow key]';
enl_buttonoff[0] = -216;
enl_buttonurl[1] = 'next';
enl_buttontxt[1] = 'Next picture [right arrow key]';
enl_buttonoff[1] = -234;
enl_buttonurl[2] = 'close';
enl_buttontxt[2] = 'Close [Esc key]';
enl_buttonoff[2] = -0;



function showimgmodal(imgid) {
    alert(imgid);
    document.getElementById(imgid).click();

}

function tt() {

    //alert(document.reservation.targetDate.value);
    //document.reservation.submit();
    //return false;
    if (document.reservation.targetDate.value == "Date *" || false) {
        alert("Date Field Left empty");
        document.reservation.targetDate.focus();
        return;
    }

    if (document.reservation.interestedIn.value == "0") {
        alert("InterestedIn Field Left empty");
        document.reservation.interestedIn.focus();
        return;
    }


    if (document.reservation.duration.value == "0") {
        alert("Duration Field Left empty");
        document.reservation.duration.focus();
        return;
    }
        //if (document.getElementById('InterestedType').value == "NYC Tours") {

        //    if (document.reservation.adults.value == "Adults *") {
        //        alert("Adults Field Left empty");
        //        document.reservation.adults.focus();
        //        return;
        //    }
        //}
        //    // additional added
        //else if (document.getElementById('InterestedType').value == "Bike Rentals") {

        //    if (document.reservation.adults1.value == "# of Bikes *") {
        //        alert("Number of Bikes not selected");
        //        document.reservation.adults1.focus();
        //        return;
        //    }
        //}
        // additional added ends here
    else {



        if (document.reservation.male.value == "Male *") {
            alert("Male Field Left empty");
            document.reservation.male.focus();
            return;
        }
        if (document.reservation.female.value == "Female *") {
            alert("Female Field Left empty");
            document.reservation.female.focus();
            return;
        }

    }
    //if (document.getElementById('InterestedType').value != "NYC Tours") {
    //    if (isEquipmentSelected() == false) {
    //        alert("Please select at least one Equipment.");
    //        return;
    //    }
    //}

    if (document.reservation.bookingName.value == "Name *") {
        alert("Booking Name Field Left empty");
        document.reservation.bookingName.focus();
        return;
    }
    if (document.reservation.bookingEmail.value == "Email Address *") {
        alert("Booking Email Field Left empty");
        document.reservation.bookingEmail.focus();
        return;
    }
    if (validateEmail1(document.reservation.bookingEmail.value) == false) {
        alert("In-Valid Email id");
        document.reservation.bookingEmail.focus();
        return false;
    }
    if (document.reservation.bookingPhone.value == "Phone Number *") {
        alert("Booking Phone Field Left empty");
        document.reservation.bookingPhone.focus();
        return;
    }
    //alert(document.reservation.reservationType.value);
    document.reservation.submit();
}
function validateEmail1(email) {

    var reg = /^([A-Za-z0-9_\-\.])+\@@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (reg.test(email) == false) {
        return false;
    }
    else {
        return true;
    }
}
function showhide(id, idx) {
    //alert(idx);
    if (id == "0") {
        return;
    }
    var sel = document.getElementById('interestedIn');
    //document.getElementById('InterestedType').value = sel.options[idx].parentNode.label;
    document.reservation.reservationType.value = sel.options[idx].parentNode.label;


    if (sel.options[idx].parentNode.label == "NYC Tours") {
        showRow('rowAdult');
        hideRow('rowMale');
        hideRow('rowFemale');
        var nyctourequipmentdata = 'selectedtype=' + sel.options[idx].parentNode.label + '&selecteditem=' + id;
        $.ajax({
            url: 'http://itechnoweb.com/bikerental/bike/getnyctourequipments',
            type: 'POST',
            data: nyctourequipmentdata,
            success: function (output_string) {
                // alert(output_string);
                document.getElementById('equipments').innerHTML = output_string;
            } // End of success function of ajax form
        }); // End of ajax call
        //data: 'type='+sel.options[idx].parentNode.label + '&item='+val,
        //alert(document.getElementById('equipments').innerHTML);

        //showRow('nyctourscroller');
        //hideRow('biketourscroller');
        //hideRow('bikerentalscroller');
    }
    else {


        if (sel.options[idx].parentNode.label == "Bike Rentals") {
            hideRow('rowMale');
            hideRow('rowFemale');
            hideRow('rowChild');
            hideRow('rowAdult');
            showRow('rowNum');

            var bikerentalequipmentdata = 'selectedtype=' + sel.options[idx].parentNode.label + '&selecteditem=' + id;
            $.ajax({
                url: 'http://itechnoweb.com/bikerental/bike/getBikeRentalEquipmets',
                type: 'POST',
                data: bikerentalequipmentdata,
                success: function (output_string) {
                    //alert(url);
                    //  alert(output_string);
                    document.getElementById('equipments').innerHTML = output_string;
                } // End of success function of ajax form
            }); // End of ajax call
            //data: 'type='+sel.options[idx].parentNode.label + '&item='+val,
            //alert(document.getElementById('equipments').innerHTML);


            //showRow('bikerentalscroller');
            //hideRow('biketourscroller');
            //hideRow('nyctourscroller');
        }
        else {
            showRow('rowMale');
            showRow('rowFemale');
            hideRow('rowAdult');
            var biketourequipmentdata = 'selectedtype=' + sel.options[idx].parentNode.label + '&selecteditem=' + id;
            $.ajax({
                url: 'http://itechnoweb.com/bikerental/bike/getbiketourequipments',
                type: 'POST',
                data: biketourequipmentdata,
                success: function (output_string) {
                    //alert(output_string);
                    document.getElementById('equipments').innerHTML = output_string;
                } // End of success function of ajax form
            }); // End of ajax call
            //data: 'type='+sel.options[idx].parentNode.label + '&item='+val,
            //alert(document.getElementById('equipments').innerHTML);
            //showRow('biketourscroller');
            //hideRow('bikerentalscroller');
            //hideRow('nyctourscroller');
        }
    }
    //alert('val='+val);

    var data = 'selectedtype=' + sel.options[idx].parentNode.label + '&selecteditem=' + id;
    $.ajax({
        url: 'http://itechnoweb.com/bikerental/bike/getDuration',
        type: 'POST',
        data: data,
        success: function (output_string) {
            var temp = new Array();
            temp = output_string.split(",");
            removeOptions(document.getElementById('duration'));
            for (a in temp) {
                //alert(temp[a]);
                if (temp[a].indexOf("Hour") !== -1) {
                    $("#duration").append("<option value=" + temp[a] + ">" + temp[a] + "</option>");
                }
                else {
                    $("#duration").append("<option value=" + temp[a] + ">" + temp[a] + " Hours" + "</option>");
                }
            }
        } // End of success function of ajax form
    }); // End of ajax call
    //data: 'type='+sel.options[idx].parentNode.label + '&item='+val,
}

function removeOptions(obj) {
    var i;
    for (i = obj.length - 1; i >= 0; i--) {
        if (obj.options[i].value != "0") {
            obj.remove(i);
        }
    }
}

function showRow(rowId) {
    document.getElementById(rowId).style.display = "";
}
function hideRow(rowId) {
    document.getElementById(rowId).style.display = "none";
}
function isEquipmentSelected() {
    var chks = document.getElementsByName('selectedEquipments[]');
    if (chks.length > 0) {
        var hasChecked = false;
        for (var i = 0; i < chks.length; i++) {
            if (chks[i].checked) {
                hasChecked = true;
                break;
            }
        }
        if (hasChecked == false) {
            return false;
        }
    }
    return true;
}
function populatediv() {
    //document.getElementById('equipments').innerHTML = "test";
    //alert("here");
    $.ajax({
        url: 'http://itechnoweb.com/bikerental/bike/getEquipmets',
        type: 'POST',
        success: function (output_string) {
            //alert(output_string);
            document.getElementById('equipments').innerHTML = output_string;
        } // End of success function of ajax form
    }); // End of ajax call
}