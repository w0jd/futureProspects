function validateform(){
    integer = 0;


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
    if (isLetter(phone_number) || (phone_number.length!=9 && phone_number.length!=0)){
        document.getElementById("error_phone_number").innerHTML = "Incorrect phone number";
        if (integer==0) document.register_form.phone_number.focus();
        integer++;
    }
    else document.getElementById("error_phone_number").innerHTML = "";



    var city = document.register_form.city.value;
    if (isNumber(city)){
        document.getElementById("error_city").innerHTML = "Incorrect city";
        if (integer==0) document.register_form.city.focus();
        integer++;
    }
    else document.getElementById("error_city").innerHTML = "";



    var major = document.register_form.major.value;
    if (isNumber(major)){
        document.getElementById("error_major").innerHTML = "Incorrect major";
        if (integer==0) document.register_form.major.focus();
        integer++;
    }
    else document.getElementById("error_major").innerHTML = "";



    var graduation_year = document.register_form.graduation_year.value;
    if (isLetter(graduation_year) || (graduation_year.length!=4 && graduation_year.length!=0)){
        document.getElementById("error_graduation_year").innerHTML = "Incorrect graduation year";
        if (integer==0) document.register_form.graduation_year.focus();
        integer++;
    }
    else document.getElementById("error_graduation_year").innerHTML = "";



    var university = document.register_form.university.value;
    if (isNumber(university)){
        document.getElementById("error_university").innerHTML = "Incorrect university";
        if (integer==0) document.register_form.university.focus();
        integer++;
    }
    else document.getElementById("error_university").innerHTML = "";


    
    var faculty = document.register_form.faculty.value;
    if (isNumber(faculty)){
        document.getElementById("error_faculty").innerHTML = "Incorrect faculty";
        if (integer==0) document.register_form.faculty.focus();
        integer++;
    }
    else document.getElementById("error_faculty").innerHTML = "";





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