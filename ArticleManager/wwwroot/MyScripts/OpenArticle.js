
function openArticle(fileName) {
    let newWindow = window.open(document.location.href);
    newWindow.addEventListener('DOMContentLoaded', () => {
        newWindow.document.body.innerHTML = '<embed src="/Articles/' + fileName + '" style="width:100%;height:100%;position: fixed;" type="application/pdf"/>'
    })
}
