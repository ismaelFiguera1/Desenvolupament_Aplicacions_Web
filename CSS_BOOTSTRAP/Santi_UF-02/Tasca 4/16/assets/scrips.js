$(document).ready(function(){
    // Animación de la primera imagen: mover 100px a la derecha
    $("#imatge1").animate({
      left: "+=300"
    }, 3000, function(){
      // Cuando termine la animación de la primera imagen, animamos la segunda imagen:
      // mover 100px a la izquierda y reducir su opacidad a 0.5
      $("#imatge2").animate({
        left: "-=300",
        opacity: 0.2
      }, 1000);
    });
  });