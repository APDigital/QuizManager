window.onload = function ClearAllInputboxes() {
    document.getElementsByTagName('input')[0].focus();
    var a = document.getElementById('CheckboxControl');
    for (var i = 0; i < a.length; i++) {
        if (a[i].type == 'text') a[i].value = "";
    }
    for (var i = 0; i < a.length; i++) {
        if (a[i].type == 'checkbox') a[i].checked = false;
    }
}