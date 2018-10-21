var UserName = "", randomsymptom = "";
var symptomsarray = [];
function GetRandomSymtopmsFromList() {
    $.ajax({
        type: 'GET',
        url: '@Url.Action("GetRandomSymptom")',
        data: { "data": JSON.stringify(symptomsarray.join(",")) },
        dataType: 'json',
        success: function (data) {
            $("#dynamicquestionspan").text(data);
            //$('#id').text(emp.employee.Id);
            //$('#firstName').text(emp.employee.FirstName);
            //$('#lastName').text(emp.employee.LastName);
        },
        error: function (emp) {
            alert('error');
        }
    });
}
$("#startAss_second").hide();
$("#startAss_third").hide();
$("#startAss_dynamic_yesno").hide();
$("#startAss_dynamic_question_screen").hide();
$('a#startassessment').click(function () {
    var name = $("#Name").val();
    var age = $("#Age").val();
    localStorage.setItem("localStorage_Name", name);
    UserName = localStorage.getItem("localStorage_Name");
    $("#UserName").text(UserName);
    localStorage.setItem("localStorage_Age", age);
    $("#startAss_first").hide();    
    $("#startAss_second").show();
})
$("#submitbasesymptom").click(function () {
    var base_symptom = $("#base_symtomps option:selected").text();
    localStorage.setItem("localStorage_base_symptom", base_symptom);
    symptomsarray.push(base_symptom);   
    $("#startAss_second").hide();
    $("#startAss_third").show();
    
})
$("#btnsubmitbasesymptomduration").click(function () {
    var base_symptomduration = $("#txtbasesymptomduration").val();
    localStorage.setItem("localStorage_base_symptom_duration", base_symptomduration);
    $("#startAss_third").hide();
    $("#startAss_dynamic_yesno").show();
})

//$(".btnstopfurtherassessment").click(function () {

//    //$.ajax({
//    //    type: 'GET',
//    //    url: '@Url.Action("GetDiagnostics")',
//    //    data: { "data": JSON.stringify(symptomsarray.join(",")) },
//    //    dataType: 'json',
//    //    success: function (data) {
//    //        //$("#dynamicquestionspan").text(data);
//    //        //$('#id').text(emp.employee.Id);
//    //        //$('#firstName').text(emp.employee.FirstName);
//    //        //$('#lastName').text(emp.employee.LastName);
//    //    },
//    //    error: function (emp) {
//    //        alert('error');
//    //    }
//    //});
//    $(location).attr('href', 'http://localhost:59044/Home/Diagnosis');
//})