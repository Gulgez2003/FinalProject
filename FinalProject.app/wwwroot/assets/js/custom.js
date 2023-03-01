const loadMoreBtn = document.querySelector(".load-more")
loadMoreBtn.addEventListener("click", LoadMore)

function LoadMore() {
    let productCount = $(".blogs").children().length
    fetch("/News/LoadMore?skip=" + productCount)
        .then(response => response.text())
        .then(text => {
            $(".blogs").append(text)
            let lastProductsCount = $(".blogs").children().length
            let count = $(".count").val()
            if (count == lastProductsCount) {
                $(".load-more").remove()
            }
        })
}