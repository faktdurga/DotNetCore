document.querySelector("#load-list-button").addEventListener("click",
   async function () {
        var response = await fetch("loadList", { method: "GET" })
        var responseBody = await response.text();
        document.querySelector("#list").innerHTML = responseBody;
    }
);