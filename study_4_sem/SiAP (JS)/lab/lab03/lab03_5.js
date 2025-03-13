var LogLevel;
(function (LogLevel) {
    LogLevel["INFO"] = "INFO";
    LogLevel["WARNING"] = "WARNING";
    LogLevel["ERROR"] = "ERROR";
})(LogLevel || (LogLevel = {}));
;
function logEvent(event) {
    var timestamp = event[0], level = event[1], message = event[2];
    console.log("[".concat(timestamp.toISOString(), "] [").concat(level, "]: ").concat(message));
}
logEvent([new Date(), LogLevel.INFO, "Система запущена"]);
