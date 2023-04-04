function soloTelefono(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key <= 31 || (key >= 48 && key <= 57) || (key === 43) || (key === 45));
}

function soloLogin(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key <= 31 || (key >= 97 && key <= 122) || (key === 95) || (key === 46));
}

function soloValidos(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key === 95 || key <= 32 || (key >= 48 && key <= 57) || (key === 35) || (key === 44) || (key === 39) || (key === 46) || (key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key === 209) || (key === 241) || key === 193 || key === 201 || key === 205 || key === 211 || key === 218 || key === 225 || key === 233 || key === 237 || key === 243 || key === 250 || key === 196 || key === 203 || key === 207 || key === 214 || key === 220 || key === 228 || key === 235 || key === 239 || key === 246 || key === 252);
}

function soloNumeros(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key <= 31 || (key >= 48 && key <= 58));
}

function soloNumpunto(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key <= 31 || ((key >= 48 && key <= 58) || (key === 46)));
}

function soloRUT(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key <= 31 || (key >= 48 && key <= 57) || key === 75 || key === 107);
}

function soloNada(evt) {
    var key = evt.keyCode ? evt.keyCode : evt.which;
    return (key === 0);
}

function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal === '')
        return false;

    //Declare Regex  
    var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray === null)
        return false;

    //Checks for mm/dd/yyyy format.
    dtMonth = dtArray[3];
    dtDay = dtArray[1];
    dtYear = dtArray[5];

    if (dtYear > 2030 || dtYear < 1990)
        return false;
    else if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth === 4 || dtMonth === 6 || dtMonth === 9 || dtMonth === 11) && dtDay === 31)
        return false;
    else if (dtMonth === 2) {
        var isleap = (dtYear % 4 === 0 && (dtYear % 100 !== 0 || dtYear % 400 === 0));
        if (dtDay > 29 || (dtDay === 29 && !isleap))
            return false;
    }
    return true;
}