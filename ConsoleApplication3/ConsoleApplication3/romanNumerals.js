// Polyfills
if (!String.prototype.includes) {
    String.prototype.includes = function (search, start) {
        'use strict';
        if (typeof start !== 'number') {
            start = 0;
        }

        if (start + search.length > this.length) {
            return false;
        } else {
            return this.indexOf(search, start) !== -1;
        }
    };
}


//to Roman
var toRoman = function (arabic) {
    if (arabic === 1000) {
        return "M";
    }
    if (arabic === 500) {
        return "D";
    }
    if (arabic === 100) {
        return "C";
    }
    if (arabic === 50) {
        return "L";
    }
    if (arabic === 10) {
        return "X";
    }
    if (arabic === 5) {
        return "V";
    }
    if (arabic === 1) {
        return "I";
    }
    else return subtracteggate(arabic)

    //return "I";   
}

var subtracteggate = function (arabicNumber) {
    if (arabicNumber > 1000) {
        var newArabicNumber = arabicNumber - 1000;
        anyThousands = toRoman(newArabicNumber);
        return "M" + anyThousands;
    }
    if (arabicNumber > 500) {
        var newArabicNumber = arabicNumber - 500;
        anyFiveHundreds = toRoman(newArabicNumber);
        return "D" + anyFiveHundreds;
    }
    if (arabicNumber > 100) {
        var newArabicNumber = arabicNumber - 100;
        anyHundreds = toRoman(newArabicNumber);
        return "C" + anyHundreds;
    }
    if (arabicNumber > 50) {
        var newArabicNumber = arabicNumber - 50;
        anyFifties = toRoman(newArabicNumber);
        return "L" + anyFifties;
    }
    if (arabicNumber > 10) {
        var newArabicNumber = arabicNumber - 10;
        var anyTens = toRoman(newArabicNumber);
        return "X" + anyTens;
    }
    if (arabicNumber === 9) {
        return "IX";
    }
    if (arabicNumber > 5) {
        var newArabicNumber = arabicNumber - 5;
        var anyFives = toRoman(newArabicNumber);
        return "V" + anyFives;
    }
    if (arabicNumber === 4) {
        return "IV";
    }
    if (arabicNumber < 4) {
        if (arabicNumber - 1 > 0) {
            var newArabicNumber = arabicNumber - 1;
            var anyOnes = toRoman(newArabicNumber);
            return "I" + anyOnes;
        }
    }
}

//to Arabic
var RomanNumerals = ["I", "V", "X", "L", "C", "D", "M"];
var toArabic = function (number) {
    if (number === "M") {
        return 1000;
    }
    if (number === "D") {
        return 500;
    }
    if (number === "C") {
        return 100;
    }
    if (number === "L") {
        return 50;
    }
    if (number === "X") {
        return 10;
    }
    if (number === "V") {
        return 5;
    }
    if (number === "I") {
        return 1;
    }
}

var parseNumberString = function (numberToParse) {
    var collection = 0;
    for (var i = 0; i < numberToParse.length; i++) {
        var nextNumber = toArabic(numberToParse[i + 1]);
        var currentNumber = toArabic(numberToParse[i]);
        if (nextNumber > currentNumber) {
            collection -= currentNumber;
        }
        else {
            collection += currentNumber;
        }
    }
    return collection;
}

var parseNumberStringBackwards = function (numberToParse) {
    var collection = 0;
    for (var i = numberToParse.length - 1; i >= 0; i--) {
        if (toArabic(numberToParse[i]) < toArabic(numberToParse[i + 1])) {
            collection -= toArabic(numberToParse[i]);
        } else {
            collection += toArabic(numberToParse[i]);
        }
    }
    return collection;
}


//tests
var assertEqual = function (expected, actual) {
    var ret = expected === actual;
    if (ret) { return true; }
    console.log("Failed: " + expected + " not equal to " + actual);
    return false;
};

var RunArabicToRomanTests = function () {
    return assertEqual("I", toRoman(1))
        && assertEqual("V", toRoman(5))
        && assertEqual("X", toRoman(10))
        && assertEqual("L", toRoman(50))
        && assertEqual("C", toRoman(100))
        && assertEqual("D", toRoman(500))
        && assertEqual("M", toRoman(1000))
        && assertEqual("IV", toRoman(4))
        && assertEqual("II", toRoman(2))
        && assertEqual("XX", toRoman(20))
        && assertEqual("XI", toRoman(11))
        && assertEqual("XIV", toRoman(14))
        && assertEqual("CIX", toRoman(109))
        && assertEqual("MDXXIV", toRoman(1524));
};

var RunRomanToArabicTests = function () {
    return assertEqual(1, toArabic("I"))
        && assertEqual(5, toArabic("V"))
        && assertEqual(10, toArabic("X"))
        && assertEqual(5, toArabic("V"))
        && assertEqual(50, toArabic("L"))
        && assertEqual(100, toArabic("C"))
        && assertEqual(500, toArabic("D"))
        && assertEqual(1000, toArabic("M"))
        && assertEqual(10, toArabic("X"))
        && assertEqual(5, toArabic("V"))
        && assertEqual(10, toArabic("X"));
}
var RunParser = function () {
    return assertEqual(1, parseNumberString("I"))
        && assertEqual(5, parseNumberString("V"))
        && assertEqual(10, parseNumberString("X"))
        && assertEqual(50, parseNumberString("L"))
        && assertEqual(100, parseNumberString("C"))
        && assertEqual(500, parseNumberString("D"))
        && assertEqual(1000, parseNumberString("M"))
        && assertEqual(15, parseNumberString("XV"))
        && assertEqual(6, parseNumberString("VI"))
        && assertEqual(16, parseNumberString("XVI"))
        && assertEqual(4, parseNumberString("IV"))
        && assertEqual(90, parseNumberString("XC"))
        && assertEqual(9, parseNumberString("IX"))
        && assertEqual(24, parseNumberString("XXIV"))
        && assertEqual(83, parseNumberString("LXXXIII"))
        && assertEqual(109, parseNumberString("CIX"))
    ;
}

document.getElementById("results").innerHTML = RunParser();