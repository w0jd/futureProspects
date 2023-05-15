function validateform(){
    integer = 0;


    var company_name = document.register_form.company_name.value; //
    if (company_name==null || company_name==""){
        document.getElementById("error_company_name").innerHTML = "Incorrect company name";
        if (integer==0) document.register_form.company_name.focus();
        integer++;
    }
    else document.getElementById("error_company_name").innerHTML = "";



    var name = document.register_form.name.value;
    if (name==null || name=="" || isNumber(name)){
        document.getElementById("error_name").innerHTML = "Incorrect name";
        if (integer==0) document.register_form.name.focus();
        integer++;
    }
    else document.getElementById("error_name").innerHTML = "";



    var surname = document.register_form.surname.value;
    if (surname==null || surname=="" || isNumber(surname)){
        document.getElementById("error_surname").innerHTML = "Incorrect surname";
        if (integer==0) document.register_form.surname.focus();
        integer++;
    }
    else document.getElementById("error_surname").innerHTML = "";



    var email = document.register_form.email.value;
    if (email==null || email==""){
        document.getElementById("error_email").innerHTML = "Incorrect email";
        if (integer==0) document.register_form.email.focus();
        integer++;
    }
    else document.getElementById("error_email").innerHTML = "";



    var password = document.register_form.password.value;
    if (password==null || password==""){
        document.getElementById("error_password").innerHTML = "Incorrect password";
        if (integer==0) document.register_form.password.focus();
        integer++;
    }
    else document.getElementById("error_password").innerHTML = "";



    var phone_number = document.register_form.phone_number.value;
    if (phone_number==null || phone_number=="" || isLetter(phone_number) || (phone_number.length!=9 && phone_number.length!=0)){
        document.getElementById("error_phone_number").innerHTML = "Incorrect phone number";
        if (integer==0) document.register_form.phone_number.focus();
        integer++;
    }
    else document.getElementById("error_phone_number").innerHTML = "";



    var address = document.register_form.address.value;
    if (address==null || address==""){
        document.getElementById("error_address").innerHTML = "Incorrect address";
        if (integer==0) document.register_form.address.focus();
        integer++;
    }
    else document.getElementById("error_address").innerHTML = "";





    if (integer > 0) {
        return false;
    }
}





function isNumber(inputText){
    for (var i=0; i < inputText.length; i++){ 
        if(!isNaN(inputText[i])) return true;
    } 
    return false;
}
function isLetter(inputText){
    for (var i=0; i < inputText.length; i++){ 
        if(isNaN(inputText[i])) return true;
    } 
    return false;
}