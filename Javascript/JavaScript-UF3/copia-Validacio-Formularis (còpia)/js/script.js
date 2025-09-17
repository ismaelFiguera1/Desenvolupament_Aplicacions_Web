const d = document;

function contactFormValidations() {
  const $form = d.querySelector(".contact-form"),
    $inputs = d.querySelectorAll(".contact-form [required]");
  console.log($inputs);

  $inputs.forEach((input) => {
    const $span = d.createElement("span");
    $span.id = input.name;
    $span.textContent = input.title;
    $span.classList.add("contact-form-error", "none");
    input.insertAdjacentElement("afterend", $span);
  });
}

d.addEventListener("DOMContentLoaded", contactFormValidations);

d.addEventListener("keyup", (e) => {
  if (e.target.matches(".contact-form [required]")) {
    let $input = e.target;
    pattern = $input.pattern || $input.dataset.pattern;
    console.log($input, pattern);
    if (pattern) {
      console.log("input amb pattern");
      let regex = new RegExp(pattern);
      //  Si el valor de l'input n compleix la expressio regular, afegeix l'atribut is-active, en cas contrari l'afegeix
      !regex.exec($input.value)
        ? d.getElementById($input.name).classList.add("is-active")
        : d.getElementById($input.name).classList.remve("is-active");
    }
    if (!pattern) {
      console.log("input sense patern");
      $input.value === ""
        ? d.getElementById($input.name).classList.add("is-active")
        : d.getElementById($input.name).classList.remve("is-active");
    }
  }
});

d.addEventListener("submit", (e) => {
  /*
  e.preventDefault();
  alert("enviant formulari");
  */
  ($loader = d.querySelector(".contact-form-loader")),
    ($resposta = d.querySelector(".contact-form-response"));

  $loader.classList.remove("none");

  setTimeout(() => {
    $loader.classList.add("none");
    /*
    $resposta.classList.remove("none");

    setTimeout(() => {
      $resposta.classList.add("none");
    }, 3000);
    */
  }, 3000);
});
