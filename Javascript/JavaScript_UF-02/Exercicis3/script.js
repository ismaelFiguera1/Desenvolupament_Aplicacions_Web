// Random

function random(min, max) {
  const e = Math.random();

  return e;
}

const numRand = random(2, 4);
console.log(numRand);

// Cap_i_cua

function capIcua(numero) {
  let text = numero.toString();
  text = text.split("");
  console.log(text.length);

  if (text.length % 2 == 0) {
    let meitat = text.length / 2 - 1;
    let meitat2 = text.length / 2;
    while (meitat2 < text.length) {
      if (text[meitat2] == text[meitat]) {
        meitat2++;
        meitat--;
      } else {
        console.log(`NO es CAPICUA ${numero}`);
        return;
      }
    }
    console.log(`Èl numero ${numero} ES CAPICUA`);
  } else {
    console.log("NO divisible per 2");
  }
}

capIcua(253693396352);

// Es Primer

function Primer(numero) {
  if (numero % 2 == 0) {
    console.log(`el ${numero} NO es primer`);
  } else {
    console.log(`el ${numero} ES primer`);
  }
}

Primer(25869);

// Factorial

function Factorial(numero) {
  let i = 1;
  let resulOperacio = 1;
  while (i <= numero) {
    resulOperacio = i * resulOperacio;
    i++;
  }
  return resulOperacio;
}

const resulFactorial = Factorial(1);
console.log(resulFactorial);
