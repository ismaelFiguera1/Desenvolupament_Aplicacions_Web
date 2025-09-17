const persona = {
  nom: "Ismael",
  cognom: "Figuera",
  edat: 21,
  saludar: () => {
    console.log("Hola");
  },
};
console.log(persona.nom);
console.log(persona.edat);
persona.saludar();
console.log(persona);
console.log(persona.hasOwnProperty("saludar"));
