enum LogLevel {
    INFO = "INFO",
    WARNING = "WARNING",
    ERROR = "ERROR",
};
type LogEntry = [Date, LogLevel, string];


function logEvent(event: LogEntry): void {
    const [timestamp, level, message] = event;
    console.log(`[${timestamp.toISOString()}] [${level}]: ${message}`);
}

logEvent([new Date(), LogLevel.INFO, "Система запущена"]);