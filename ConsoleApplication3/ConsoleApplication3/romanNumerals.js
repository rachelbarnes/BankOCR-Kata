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
    if (arabicNumber > 5) {
        var newArabicNumber = arabicNumber - 5;
        var anyFives = toRoman(newArabicNumber);
        return "V" + anyFives;
    }
    if (arabicNumber === 4) {
        return "IV";
    }
    if (arabicNumber < 4){
        if (arabicNumber - 1 > 0) {
            var newArabicNumber = arabicNumber - 1;
            var anyOnes = toRoman(newArabicNumber);
            return "I" + anyOnes;
        }
    }

}

//var concat = function (tens, fives, ones) {
//    return 
//}





//tests
var assertEqual = function (expected, actual) {
    var ret = expected === actual;
    if (ret) { return true; }
    console.log("Failed: " + expected + " not equal to " + actual);
    return false;
};

var runAllTests = function () {
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
        && assertEqual("MDXXIV", toRoman(1524))

    ;
};
document.getElementById("results").innerHTML = runAllTests();