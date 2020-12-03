const mostRecentScore = localStorage.getItem('mostRecentScore');
    // Функция установки ссылки на конкретную html страницу
    function ChangeHref() {

        if (mostRecentScore >= 0 && mostRecentScore < 6) {
            document.getElementById("url").setAttribute("href", "SriLanka");
            
        }
        else if (mostRecentScore >= 6 && mostRecentScore < 12) {
            document.getElementById("url").setAttribute("href", "Budapest");
            
        }
        else if (mostRecentScore >= 12 && mostRecentScore < 18) {
            document.getElementById("url").setAttribute("href", "Skopje");
            
        }
        else if (mostRecentScore >= 18 && mostRecentScore < 24) {
            document.getElementById("url").setAttribute("href", "Belgrade");
            
        }
        else if (mostRecentScore >= 24 && mostRecentScore < 30) {
            document.getElementById("url").setAttribute("href", "Salzburg");
            
        }
        else {
            document.getElementById("url").setAttribute("href", "HighTatras");
            
        }
    }

    // Функция 
function saveTour() {
    
    if (mostRecentScore >= 0 && mostRecentScore < 6) document.getElementById("tourId").value = "1";
    else if (mostRecentScore >= 6 && mostRecentScore < 12) document.getElementById("tourId").value = "2";
    else if (mostRecentScore >= 12 && mostRecentScore < 18) document.getElementById("tourId").value = "3";
    else if (mostRecentScore >= 18 && mostRecentScore < 24) document.getElementById("tourId").value = "4";
    else if (mostRecentScore >= 24 && mostRecentScore < 30) document.getElementById("tourId").value = "5";
    else document.getElementById("tourId").value = "6";
}
          




   
