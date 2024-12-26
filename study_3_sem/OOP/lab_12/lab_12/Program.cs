namespace StreamFile
{
    class Program
    {
        static void Main()
        {
            string path = @"..\..\..\ldvlogfile.txt";
            string C = "C:";
            string D = "D:";

            LDVDiskInfo diskInfo = new LDVDiskInfo();
            diskInfo.GetFreeSpaceInfo(C);
            diskInfo.GetFileSystemInfo(C);
            diskInfo.PrintAllDrivesInfo();

            LDVFileInfo fileInfo = new LDVFileInfo();
            fileInfo.GetFullPath(path);
            fileInfo.GetFileSizeExtensionName(path);
            fileInfo.GetFileCreationModificationDate(path);

            LDVDirInfo dirInfo = new LDVDirInfo();
            dirInfo.GetFilesAmount(C);
            dirInfo.GetDirectoryCreationTime(C);
            dirInfo.GetSubdirectoriesAmount(C);
            dirInfo.GetDirectoryParents(C);


            LDVFileManager fileManager = new LDVFileManager(D);
            fileManager.InspectDrive();

            LDVLog.GetLogRecordByTime(new DateTime(2024, 12, 20));
        }

    }
}