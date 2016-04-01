var addAndMultiplyDigits = function (accountNumber) {
    //in the future for loops, i can have 2 conditions, 
    //but they have to be linked with || or &&
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
}

var checkValidityOfAccountNumber = function (number) {
    switch (number) {
        case illegibleCase:
            'number'.includes('?')
            return 'number' + ' ILL';
        case errorCase:
            checkForValidSum(number) !== true
            return number + ' ERR';
        default:
            checkFOrValidSum(number) == true
            return number;
            // if ('number'.includes('?')) {
            //      return 'number' + ' ILL';
            // }
            // if (checkForValidSum(number) !== true) {
            //     return number + ' ERR';
            //} 
            // if (checkForValidSum(number) == true) {
            //     number;
            // }
    }
}
    // tests // 
var assertEqual = function (expected, actual) {
    var ret = expected === actual; //=== doesn't do type conversion; == does type conversion 
    if (ret) { return true; }

    console.log("Failed: " + expected + " not equal to " + actual);
    return false;
};
var runTests = function () {
    return assertEqual(165, addAndMultiplyDigits(123456789));
}
var runTestsValidSum = function () {
    return assertEqual(true, checkForValidSum(123456789))
        && assertEqual(false, checkForValidSum(123456788));
}
var runTestsValidAccountNumber = function () {
    return assertEqual(123456789, checkValidityOfAccountNumber(123456789))
        && assertEqual("1234??789 ILL", checkForQuestionMarks('1234??789'))
        && assertEqual("554433985 ERR", checkValidityOfAccountNumber('554433985'));
}

 document.getElementById("results").innerHTML = runTests();

