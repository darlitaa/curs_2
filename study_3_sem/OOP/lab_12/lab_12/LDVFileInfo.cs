using System;

namespace StreamFile
{
	internal class LDVFileInfo
	{
		private readonly LDVLog logger;
		public LDVFileInfo()
		{
			logger = new LDVLog();
		}
		
		public void GetFullPath(string filePath)
		{
			var FullFilePath = $"Полный путь к файлу: {Path.GetFullPath(filePath)}";
			logger.WriteLog("GetFullPath", FullFilePath);
		}

		public void GetFileSizeExtensionName(string filePath)
		{

			FileInfo fileInfo = new FileInfo(filePath);

			var FullFileInfo = $"\nИмя файла по пути {Path.GetFileNameWithoutExtension(filePath)}" +
				$"\nРасширение: {Path.GetExtension(filePath)}" +
				$"\nРазмер: {fileInfo.Length}";
			logger.WriteLog("Get FullName, Extension, Size", FullFileInfo);
		}

		public void GetFileCreationModificationDate(string filePath)
		{

			FileInfo fileInfo = new FileInfo(filePath);

			var FileCreationModification = $"\nДата создания файла: {fileInfo.CreationTime}"+
				$"\nДата последнего изменения файла: {fileInfo.LastWriteTime}";
			logger.WriteLog("Creation and Modification File Date", FileCreationModification);
		}
	}
}
