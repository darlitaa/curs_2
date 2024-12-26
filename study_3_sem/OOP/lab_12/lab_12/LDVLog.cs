using System;
using System.Globalization;

namespace StreamFile
{
	internal class LDVLog
	{
		static string path = @"..\..\..\ldvlogfile.txt";
		static readonly string separator = "----------------------------";

		public void WriteLog(string action, string result)
		{
			string LogInfo = $"Дата запроса: {DateTime.Now}" +
						$"\nДействие: {action}" +
						$"\n{result}"+
						$"\n\nПуть к файлу: {path}" +
						$"\n{separator}";

			using (StreamWriter sw = new StreamWriter(path, true))
			{
				sw.WriteLine(LogInfo);
			}

			Console.WriteLine(LogInfo);
		}

		public static List<Record> GetLogRecord()
		{
			if (!File.Exists(path)) return new List<Record>();

			var data = File.ReadAllLines(path);
			var datas = new List<Record>();

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].StartsWith("Действие"))
				{

					var action = data[i].Substring("Действие: ".Length);

					var dateString = data[i - 1];
					var dateParts = dateString.Substring("Дата запроса: ".Length).Trim();

					var date = DateTime.ParseExact(dateParts, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

					datas.Add(new Record(action, date));
				}
			}

			return datas;
		}

		public static void GetLogRecordByTime(DateTime time)
		{
			var data = GetLogRecord();
			var filteredData = data.Where(d => d.Date.Date == time.Date).ToList();

			foreach (var record in filteredData)
			{
				Console.WriteLine($"Действие: {record.Action} Дата: {record.Date:yyyy-MM-dd HH:mm:ss}");
			}

		}

		public static void CountRecords()
		{
			var data = GetLogRecord();
			Console.WriteLine($"Количество записей в log-файле: {data.Count}"); 
		}

	}

	public class Record
	{
        public string Action { get; set; }
        public DateTime Date { get; set; }

        public Record(string action, DateTime date)
        {
            Action = action ?? "undefined";
            Date = date;
        }
    }
}
