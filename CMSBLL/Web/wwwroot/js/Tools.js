
function DateStrToDate(dateStr) {
    var newDateObj
    var month, day

    newDateObj = new Date(dateStr.replace(new RegExp("-", "gi"), "/"))
    if (newDateObj == "NaN") {
        return DateStrToDate("1970-01-01");
    } else {
        return newDateObj;
    }
}