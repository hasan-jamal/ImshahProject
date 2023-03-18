const count = document.getElementById('count');

updateVisitCount();

function updateVisitCount() {
    fetch('https://api.countapi.xyz/update/danielazocardev/codepen/?amount=1')
        .then(res => res.json())
        .then(res => {
            count.innerHTML = res.value
        });
}

const artDesc = document.getElementById("text");
const copiedTxt = artDesc.textContent;
artDesc.textContent = `${artDesc.textContent.slice(0, 1100)}...`;
function toggleText(btn) {
    if (artDesc.textContent.length > 1650) {
        artDesc.textContent = `${artDesc.textContent.slice(0, 1100)}...`;
        btn.textContent = "Read more";
    } else {
        artDesc.textContent = copiedTxt;
        btn.textContent = "Read less";
    }

    return artDesc.textContent;
}
function toggleTextAr(btn) {

    if (artDesc.textContent.length > 1650) {
        artDesc.textContent = `${artDesc.textContent.slice(0, 1100)}...`;
        btn.textContent = "قراءة المزيد";
    } else {
        artDesc.textContent = copiedTxt;
        btn.textContent = "قراءة أقل";
    }

    return artDesc.textContent;
}