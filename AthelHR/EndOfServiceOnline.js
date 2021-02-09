


    jQuery(document).ready(function(){

        $('#salary').on('invalid', function() {
            var input = $(this);
            if(input.val() == ''){
                this.setCustomValidity('هذا الحقل مطلوب');
            }
            else if(input.val() > 99999 || input.val() < 1){
                this.setCustomValidity('القيمة المدخلة يجب أن تكون أكبر من 0 وأقل من 99999');
            } else{
                this.setCustomValidity('');
            }
            return true;
        });

        $('#yearsPeriod').on('invalid', function() {
            var input = $(this);
            if(input.val() == ''){
                this.setCustomValidity('هذا الحقل مطلوب');
            }
            else if(input.val() > 90 || input.val() < 0){
                this.setCustomValidity('القيمة المدخلة يجب أن تكون أكبر من 0 وأقل من 90');
            } else{
                this.setCustomValidity('');
            }
            return true;
        });

        $('#inputPeriod').on('invalid', function() {
            var input = $('#inputPeriod option:selected').val();
            if(input == ''){
                this.setCustomValidity('هذا الحقل مطلوب');
            } else{
                this.setCustomValidity('');
            }
            return true;
        });


        $("#inputPeriod").on('change', function() {
            var $states = $("#inputState");
            $('#preloader-logo').removeClass('hidden');
            var inputPeriod = $('#inputPeriod option:selected').val();
            $states.find('option').remove().end();
            $.post( "get-options/"+inputPeriod )
            .done(function( data ) {
                $('#preloader-logo').addClass('hidden');
                var result = data.data;
                if(result.length > 0 ){
                    $states.append($("<option />").val('').text('حدد السبب').attr('disabled',true));
                    $.each(result, function(key, value) {
                        $states.append($("<option />").val(value.id).text(value.name));
                    }); 
                }
            });
        });


        // jQuery(".onlyNumbers").on("keypress keyup blur",function (event) {
        //   validateNumber(event);

        // });
        $(".btn-reset").click(function(e) {
            e.preventDefault();
            clearCalc();
        });         
        $( "#calculatorForm" ).submit(function( event ) {
            var form = document.getElementById('calculatorForm'); 
            event.preventDefault();
            if (form[0].checkValidity() === true) {
                var inputPeriod = $('#inputPeriod option:selected').val();
                var inputState = $('#inputState option:selected').val();
                var salary = $('#salary').val();
                var yearsPeriod = $('#yearsPeriod').val();
                var monthsPeriod = $('#monthsPeriod').val();
                var daysPeriod = $('#daysPeriod').val();
                sumbitCalc(inputPeriod,inputState,salary,Number(yearsPeriod),Number(monthsPeriod),Number(daysPeriod)); 
            } 
        });
    });

function sumbitCalc(inputPeriod,inputState,salary,yearsPeriod,monthsPeriod,daysPeriod) { 
    var totalDays = getTotalDays(yearsPeriod,monthsPeriod,daysPeriod);
    let result = 0;
    if(inputState === '39' || inputState === '43' || inputState === '45'){
        result = 0;
    } 
    else if (inputPeriod == '47' && inputState === '46') {
        result = 0;
    }
    else if (inputPeriod == '48' && inputState === '46') {
        if (totalDays < 2 * 360 ){
            result = 0;
        }
        else if (totalDays >= 2 * 360 && totalDays <= 5 * 360){
            result = (salary / 6) * totalDays;

        }
        else if (totalDays > 5 * 360 && totalDays < 10 * 360){
            var resultFirstFiveYears =  (salary / 3) * ( 5 * 360 );
            var yearsGreaterThanFive  = totalDays - ( 5 * 360 );
            var resultGreaterFiveYears = ((salary / 3) * 2 ) * yearsGreaterThanFive;
            result = resultFirstFiveYears + resultGreaterFiveYears;

        }
        else if (totalDays >= 10 * 360){
            var resultFirstFiveYears =  (salary / 2) * ( 5 * 360 );
            var yearsGreaterThanFive  = totalDays - ( 5 * 360 );
            var resultGreaterFiveYears = salary * yearsGreaterThanFive;
            result = resultFirstFiveYears + resultGreaterFiveYears;

        }
    }             
    else if((inputPeriod == '47' || inputPeriod == '48') && totalDays <= 5 * 360){
        result = (salary / 2) * totalDays;
    } 
    else if((inputPeriod == '47' || inputPeriod == '48') && totalDays > 5 * 360){
        var resultFirstFiveYears =  (salary / 2) * ( 5 * 360 );
        var yearsGreaterThanFive  = totalDays - ( 5 * 360 );
        var resultGreaterFiveYears = salary * yearsGreaterThanFive;
        result = resultFirstFiveYears + resultGreaterFiveYears;
    } 

    var Final_result = result / 360;
    // console.log(Final_result);
    $('#resultCalc').val(Final_result.toFixed(2));
    $('#resultCalc').html(Final_result.toFixed(2));
}



function getTotalDays(years,months,days) { 
    let result = 0;
    result += years * 360;
    result += months * 30;
    result += days;
    // console.log(result);
    return result;
}


function clearCalc() { 
    var $states = $("#inputState");
    $states.find('option').remove().end();
    $states.append($("<option />").val('').text('حدد السبب').attr('disabled',true));

    $('#resultCalc').val(0);
    $('#resultCalc').html(0);
    $('.onlyNumbers.is-invalid').removeClass('is-invalid');
    $('#calculatorForm').find("input[type=number], select").val("");}

function validateNumber(event) {
    var target = event.target;
    var key = window.event ? event.keyCode : event.which;
    if (event.keyCode === 8 || event.keyCode === 46 || event.keyCode === 13 || event.keyCode === 9 || event.keyCode === 37 || event.keyCode === 39) {
        return true;
    }
    else if ( key < 48 || key > 57 ) {
        $(target).addClass('is-invalid');
        alert('عفوا عزيزي العميل، هذا الحقل يقبل أرقام فقط .');
        event.preventDefault();
    }
    else {
        $(target).removeClass('is-invalid');
        return true;
    }
}



