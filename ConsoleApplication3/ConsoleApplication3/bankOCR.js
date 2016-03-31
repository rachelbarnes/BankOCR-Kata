
var ParseRawAccountNumber = function (textfile)
{
    var textfile = new []; 
    var readTheFile = FileReader(textfile); 
    for (var line in textfile)
    {
        textfile.push(line); 
    }
    return ParseRawAccountNumberToDigits(textfile); 
}   

var GetSingleCharacterFromAccountNumber = function (index, textfileArray){
    var singleMatrixedRawCharacter; 
    for (var line in textfileArray){
        var substringedLine = line.substring(index * 3, 3); 
        singleMatrixedRawCharacter += substringedLine; 
    }
    return singleMatrixedRawCharacter; 
}
 
var ParseRawAccountNumberToDigits = function (textfile){
    var lengthOfLineInTextFile = ((textfile[0].length) / 3); 
    var getGeneratedNumber;
    for (var characterMatrixIndex = 0; characterMatrixIndex < lengthOfLineInTextFile; characterMatrixIndex++){
        var rawCharacter = GetSingleCharacterFromAccountNumber(characterMatrixIndex, textfile);
        getGeneratedNumber += generatableNumbers[rawCharacter].tostring();
    }
    return getGeneratedNumber; 

    
    //CheckSum Code Below: 
    var addDigits = function (digits) {
        var sum = 0;
        for (var i = 0; i < 9; i++) {
            sum += parseInt(digits.toString()[i]);
        }
        return sum;
    };

    var addAndMultiplyDigits = function (digits) {
        var sum = 0;
        for (var i = 0; i < 9; i++) {
            sum += parseInt(digits.toString()[i]) * (i + 1);
        }
        return sum;
    }

    var checkForValidSum = function (number) {

        if (addAndMultiplyDigits(number) % 11 == 0) {
            true;
        }
    }

    var checkValidityOfAccountNumber = function (number) {
        if ('number'.includes('?')) {
            return 'number' + ' ILL';
        }
        if (checkForValidSum(number) == false) {
            return 'number' + ' ERR';
        }
        if (checkForValidSum(number) == true) {
            'number'; 
        }
    }


    //Dictionary of Generatable Characters
    var generatableNumbers = {};
    
    generatableNumbers["     |  |   "] = 1;
    generatableNumbers[" _  _||_    "] = 2;
    generatableNumbers[" _  _| _|   "] = 3;
    generatableNumbers["   |_|  |   "] = 4;
    generatableNumbers[" _ |_  _|   "] = 5;
    generatableNumbers[" _ |_ |_|   "] = 6;
    generatableNumbers[" _   |  |   "] = 7;
    generatableNumbers[" _ |_||_|   "] = 8;
    generatableNumbers[" _ |_| _|   "] = 9;
    generatableNumbers[" _ | ||_|   "] = 0;


    // tests // 
    var assertEqual = function (expected, actual) {
        var ret = expected === actual;
        if (ret) { return true; }

        console.log("Failed: " + expected + " not equal to " + actual);
        return false;
    };
    var runTests = function () {
        return assertEqual(9, addDigits(111111111))
            && assertEqual(10, addDigits(211111111))
            && assertEqual(45, addAndMultiplyDigits(111111111))
            //&& assertEqual("     |  |   ", GetSingleCharacterFromAccountNumber(0, )
            //I need to have this read a local file before I pass the last 2 tests which
            //require the parser
            && assertEqual(12789, checkValidityOfAccountNumber(12789))
            && assertEqual('554433985 ERR', checkValidityOfAccountNumber(554433985))
            && assertEqual('12345?789 ILL', checkValidityOfAccountNumber('12345?789'));
    };

    document.getElementById("results").innerHTML = runTests();
}