
    var acc = document.getElementsByClassName("accorblog");
    var i;
    
    for (i = 0; i < acc.length; i++) {
      acc[i].addEventListener("click", function() {
        this.classList.toggle("active");
        var blog = this.nextElementSibling;
        if (blog.style.display === "block") {
          blog.style.display = "none";
        } else {
          blog.style.display = "block";
        }
      });
    }
   
      
       
