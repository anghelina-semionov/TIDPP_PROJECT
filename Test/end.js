const saveTour = document.getElementById('saveTour');
const finalScore = document.getElementById('finalScore');
const mostRecentScore = localStorage.getItem('mostRecentScore');
    // Функция установки ссылки на конкретную html страницу
    function ChangeHref() {

       if(mostRecentScore >= 0 && mostRecentScore < 6) document.getElementById("url").setAttribute("href", "game.html");
       else if(mostRecentScore >= 6 && mostRecentScore < 12) document.getElementById("url").setAttribute("href", "");
       else if(mostRecentScore >= 12 && mostRecentScore < 18) document.getElementById("url").setAttribute("href", "");
       else if(mostRecentScore >= 18 && mostRecentScore < 24) document.getElementById("url").setAttribute("href", "");
       else if(mostRecentScore >= 24 && mostRecentScore < 30) document.getElementById("url").setAttribute("href", "");
       else document.getElementById("url").setAttribute("href", "");
     }
          




   
