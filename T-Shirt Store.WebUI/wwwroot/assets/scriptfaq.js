var acc = document.getElementsByClassName("faq");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function() {
    this.classList.toggle("active");
    var yeni = this.nextElementSibling;
    if (yeni.style.display === "block") {
      yeni.style.display = "none";
    } else {
      yeni.style.display = "block";
    }
  });
}