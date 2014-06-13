function ShowNormalAlert(message) {
    $(document).ready(function () {
        $.jnotify(message);
    });
}


function ShowWarningAlert(message) {
    $(document).ready(function () {
        $.jnotify(message, 'warning');
    });
}


function ShowNormalNotification(message) {
    $(document).ready(function () {
        $.jnotify(message, 'error');
    });
}


function ShowNormalAlert(message, delaySpan) {
    $(document).ready(function () {
        $.jnotify(message, delaySpan);
    });
}


function ShowWarningAlert(message, delaySpan) {
    $(document).ready(function () {
        $.jnotify(message, 'warning', delaySpan);
    });
}


function ShowNormalNotification(message, delaySpan) {
    $(document).ready(function () {
        $.jnotify(message, 'error', delaySpan);
    });
}