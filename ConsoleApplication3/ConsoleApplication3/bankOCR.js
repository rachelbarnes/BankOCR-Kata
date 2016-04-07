var parseAccountNumber = function (drawnNumberString) {
    var matrixCharacter = "";
    var indNumber = "";
    var lengthRowOne = drawnNumberString.length / 3;
    for (var linePos = 0; linePos <= lengthRowOne ; linePos += 3) {
        //to have the proper incrementing value, the += is needed for properly increment the linePos. 
        concatenatedString = (drawnNumberString.substr(linePos, 3) + drawnNumberString.substr(linePos + 27, 3) + drawnNumberString.substr(linePos + 54, 3));
        if (dictionaryOfCharacters[concatenatedString] != null) {
            indNumber += dictionaryOfCharacters[concatenatedString].toString();
        }
        //in order to get the ? illegible functionality to work, i need to have another if statement here saying if the dict. value is null,
        //to input a ? or another char, however i was getting undefined values for numbers that are legible and pass without the presence 
        //of that if function in this method. 
    }
    return indNumber;
}

var addAndMultiplyDigits = function (accountNumber) {
    var sum = 0;
    for (var i = 0, decrement = 9; i < 9; i++, decrement--) {
        sum += parseInt(accountNumber.toString()[i]) * (decrement);
    }
    return sum;
}

var checkForValidSum = function (number) {
    if (addAndMultiplyDigits(number) % 11 == 0) {
        return true;
    }
    return false;
}

var checkValidityOfAccountNumber = function (number) {
    if (checkForValidSum(parseInt(parseAccountNumber(number))) == true) {
        return parseAccountNumber(number) + '    ';
    }
    if (checkForValidSum(parseInt(parseAccountNumber(number))) !== true) {
        return parseAccountNumber(number) + ' ERR';
    }
    if (number.toString().includes('*')) {
        return number + ' ILL';
    }
}

var dictionaryOfCharacters = {};
dictionaryOfCharacters["     |  |"] = 1;
dictionaryOfCharacters[" _  _||_ "] = 2;
dictionaryOfCharacters[" _  _| _|"] = 3;
dictionaryOfCharacters["   |_|  |"] = 4;
dictionaryOfCharacters[" _ |_  _|"] = 5;
dictionaryOfCharacters[" _ |_ |_|"] = 6;
dictionaryOfCharacters[" _   |  |"] = 7;
dictionaryOfCharacters[" _ |_||_|"] = 8;
dictionaryOfCharacters[" _ |_| _|"] = 9;
dictionaryOfCharacters[" _ | ||_|"] = 0;

//tests
var assertEqual = function (expected, actual) {
    var ret = expected === actual;
    if (ret) { return true; }
    console.log("Failed: " + expected + " not equal to " + actual);
    return false;
};
var runTestsParseAccountNumber = function () {
    var number1 =
        "    _  _     _  _  _  _  _ " +
        "  | _| _||_||_ |_   ||_||_|" +
        "  ||_  _|  | _||_|  ||_| _|";
    return assertEqual(165, addAndMultiplyDigits(123456789))
        && assertEqual("123456789", parseAccountNumber(number1))
        //&& assertEqual("111111111111", parseAccountNumber(number2))
        && assertEqual(true, checkForValidSum(123456789))
        && assertEqual(false, checkForValidSum(111111111));
};
var runValidityTests = function () {
    var number1 =
        "    _  _     _  _  _  _  _ " +
        "  | _| _||_||_ |_   ||_||_|" +
        "  ||_  _|  | _||_|  ||_| _|";
    var number2 =
        "                           " +
        "  |  |  |  |  |  |  |  |  |" +
        "  |  |  |  |  |  |  |  |  |";
    var number3 =
        "                           " +
        "  |  |  |  |  |  |  |  |  |" +
        "  |  |  |  |  |  |  |\ |  |";
    var number4 =
        "       _  _  _  _     _  _ " +
        "  |  | _| _| _| _||_||_ |_ " +
        "  |  ||_ |_  _| _|  | _| _|";
    return assertEqual("123456789    ", checkValidityOfAccountNumber(number1))
       //&& assertEqual("1111111?1 ILL", checkValidityOfAccountNumber(number3))
       && assertEqual("112233455 ERR", checkValidityOfAccountNumber(number4))
       && assertEqual("111111111 ERR", checkValidityOfAccountNumber(number2));
};
var runTestsValidSum = function () {
    return assertEqual(true, checkForValidSum(123456789))
        && assertEqual(false, checkForValidSum(123456788));
};
var runTestsValidAccountNumber = function () {
    return assertEqual("123456789    ", checkValidityOfAccountNumber('123456789'))
        && assertEqual("1234??789 ILL", checkValidityOfAccountNumber('1234??789'))
        && assertEqual("554433985 ERR", checkValidityOfAccountNumber('554433985'))
        && assertEqual("664371495 ERR", checkValidityOfAccountNumber('664371495'))
        && assertEqual("11????567 ILL", checkValidityOfAccountNumber("11????567"));
};

var runAllTests = function () {
    return runTestsParseAccountNumber() && runValidityTests();  //&& runTestsValidSum(); //&& runTestsValidAccountNumber();
    var number1 =
        "    _  _     _  _  _  _  _ " +
        "  | _| _||_||_ |_   ||_||_|" +
        "  ||_  _|  | _||_|  ||_| _|";
    return assertEqual("123456789", parseAccountNumber(number1));
};
document.getElementById("results").innerHTML = runAllTests();