﻿/*/*Created By Er. Pramod kumar Behera*/
/*    email address validated using 'onchange='emailValidate(txtEmail,llbError)'' inside controller*/
//and check its true or false if(emailValidate(txtEmail,llbError)==true){ } at javascript
function emailValidate(txtEmail,llbError) {
    var email = $("#" + txtEmail).val();
  
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (regex.test(email)) {
        $("#" + llbError).text("");
       // alert("okk");
        return true;
    } else {

        $("#" + llbError).text("Invalid email address.");
        return false;
       
    }
}
/* phone number validated  using 'onchange=' Phonevalidate(txtPhone,llbError)'' inside controller*/
//and check its true or false if(Phonevalidate(txtPhone,llbError)==true){ } at javascript
function Phonevalidate(txtPhone,llbError) {
    var phoneText = $("#" + txtPhone).val();

    var filter = /^([0-9]{10})$/;
    if (filter.test(phoneText)) {
        $("#" + llbError).text("");
        return true;

    }
    else {
      
        $("#" + llbError).text("Invalid phone Number");
        return false;
    }
}
//check the validation of textbox is empty or not 
//using 'onkeypress=txtChkValidation('txtBoxID')' inside textbox controller 
//and used at submit time and check its true or false if(txtChkValidation(txtBox)==true){ }
function txtChkValidation(txtBox) {
    if ($("#" + txtBox).val().trim() == "") {
        $("#" + txtBox).css("background-color", "red");
        return false;
    } else {
        $("#" + txtBox).css("background-color", "");
        return true;
    }
}
//this funcitoin copy past on inside file nad call using 'onchange='dropDownValidation(drpID)''
//for this used separeted js file
//function dropDownValidation(id) {
//    var x = $("#" + id).val();
//    if (x == 0) {
//        $("#" + id).css("background-color", "red");
//        return false;
//    } else {
//        $("#" + id).css("background-color", "");
//        return true;
//    }
//    }
