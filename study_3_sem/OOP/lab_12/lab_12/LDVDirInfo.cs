using System;

namespace StreamFile
{
	internal class LDVDirInfo
	{

		private readonly LDVLog logger;
		public LDVDirInfo()
		{
			logger = new LDVLog();
		}

		public void GetFilesAmount(string path)
		{
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                var FilesAmount = $"Количество файлов в директории {dir}: {Directory.GetFiles(path).Length}";
                logger.WriteLog("Get Files Amount", FilesAmount);
            }

            else
            {
                logger.WriteLog("Get Files Amount", $"Каталога {path} не существует");
            }
        }

		public void GetDirectoryCreationTime(string path)
		{
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                var CreationTime = $"Время создания директория {dir} {dir.CreationTime}";
                logger.WriteLog("Get Directory Creation Date", CreationTime);
            }

            else
            {
                logger.WriteLog("Get Directory Creation Date", $"Каталога {path} не существует");
            }
        }

		public void GetSubdirectoriesAmount(string path)
		{
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                var SubdirectoriesAmount = $"Количество файлов в директории {dir} {Directory.GetDirectories(path).Length}";
                logger.WriteLog("Get Subdirectories Amount", SubdirectoriesAmount);
            }

            else
            {
                logger.WriteLog("Get Subdirectories Amount", $"Каталога {path} не существует");
            }
        }

		public void GetDirectoryParents(string path)
		{
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                string DirectoryParents = $"Родительский каталог директория {path}: {dir.Root}";
                logger.WriteLog("Get Directory Parents", DirectoryParents);
            }
            else
            {
                logger.WriteLog("Get Directory Parents", $"Каталог {path} не существует");
            }
        }

	}
}
