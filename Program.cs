string path = @"C:\Windows\Cursors";
int fileCount = 0;

Console.Write("Input Cursor Path (leave blank for default Windows path): ");
var input = "" + Console.ReadLine();

if (input.Length > 0)
{
    path = input;
}

try
{
    fileCount = Directory.GetFiles(path, "*.cur*", SearchOption.TopDirectoryOnly).Length;
    string[] fileArray = Directory.GetFiles(path);

    int i = 0;
    while (i < fileCount)
    {
        File.Copy("replacement-cursor.cur", fileArray[i], true);
        i++;
    }
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Insufficient permissions");
    return;
}
catch (DirectoryNotFoundException)
{
    Console.WriteLine("'{0}' not found", path);
    return;
}

Console.WriteLine("{0} cursors replaced", fileCount);