// Parell

function Parell(number) {
  if (number % 2 == 0) {
    return `El numero ${number} ES parell`;
  } else {
    return `El numero ${number} NO es parell`;
  }
}

const resulParell = Parell(25748);
console.log(resulParell);

// Traduccio graus Celsius a Fahrenheit i a l’inrevés

function CalculGraus(graus, tipus) {
  if (tipus == undefined) {
    console.error("Te que haber un valor");
  } else if (!(typeof tipus == "string")) {
    console.error("Te que ser un STRING");
  } else if (tipus.length < 1) {
    console.error("No pot ser un string buit");
  } else {
    if (tipus === "f" || tipus === "c") {
      if (tipus === "f") {
        let resul = (graus - 32) * 0.5555555555555556;
        return `${graus} Fareheit son ${resul} graus Celsius`;
      } else {
        let resul = graus * 1.8 + 32;
        return `${graus} Celsius son ${resul} graus Fareheit`;
      }
    } else {
      console.error("Tens que ficar els graus F o C");
    }
  }
}

const resulFormulaGraus = CalculGraus(25, "c");

console.log(resulFormulaGraus);

// Traduccio BINARI / DECIMAL

function Calcul(number, banda) {
  if (banda === undefined || number === undefined) {
    console.error("No pot haber valors undefined");
  } else if (typeof banda !== "number" || typeof number !== "number") {
    console.error("Tenen que ser valors numerics");
  } else if (banda === 2 || banda === 10) {
    if (banda === 2) {
      const numberstring = number.toString();
      let numberstringarray = numberstring.split("");
      for (let index = 0; index < numberstringarray.length; index++) {
        numberstringarray[index] = parseInt(numberstringarray[index]);
      }
      let exponents = new Array(numberstring.length);

      let i = 0;
      for (let index = exponents.length - 1; index >= 0; index--) {
        exponents[index] = i;
        i++;
      }
      let arrayResultats = new Array();
      for (let index = 0; index < numberstringarray.length; index++) {
        let potencia = Math.pow(2, exponents[index]);
        arrayResultats[index] = numberstringarray[index] * potencia;
      }
      let resuLtatFINAL = 0;
      for (let i = 0; i < arrayResultats.length; i++) {
        resuLtatFINAL = resuLtatFINAL + arrayResultats[i];
      }
      return resuLtatFINAL;
    } else {
      let resul = 0;
      let residus = new Array();
      let i = 0;
      while (number > 0) {
        resul = number / 2;
        resul = Math.floor(resul);
        residus[i] = number - (resul + resul);
        number = resul;
        i++;
      }

      residus.reverse(); // giral l'ordre de l'array
      let arrayInt = new Array();
      for (let index = 0; index < residus.length; index++) {
        arrayInt[index] = residus[index].toString();
      }
      let string = arrayInt.join("");
      const resuLtatFINAL = parseInt(string);

      return resuLtatFINAL;
    }
  } else {
    console.error("La banda te que ser 2 o 10");
  }
}

const resulCalcul = Calcul(10111, 2); // 2 = binari, 10 = decimal

console.log(`El resultat del calcul es ${resulCalcul}`);

// Capital Final

function CapitalFinal(capitalInicial, interes, temps) {
  if (
    capitalInicial === undefined ||
    interes === undefined ||
    temps === undefined
  ) {
    console.error("NO pot haber undefineds");
  } else if (
    typeof capitalInicial !== "number" ||
    typeof interes !== "number" ||
    typeof temps !== "number"
  ) {
    console.error("Tenen que ser numerics");
  } else if (capitalInicial === 0) {
    console.error("El capital no pot ser 0");
  } else {
    interes = interes / 100;
    temps = temps / 365;
    let part = 1 + interes;
    let res = Math.pow(part, temps);
    return res * capitalInicial;
  }
}

const capitalFinal = CapitalFinal(536.12, 6, 92);

console.log(`El resultat del calcul de capital Final es: ${capitalFinal}`);
