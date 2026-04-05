using System.IO;
using System.Linq;

namespace EncurtadorDownload;

public class FlatpakPackages
{
    public string GetFlatpakFile(string file)
    {
        string[] lines = File.ReadAllLines(file);

            string? id = lines
                .FirstOrDefault(l => l.StartsWith("Name="))
                ?.Replace("Name=","")
                .Trim();

        return id ?? "";
    }
}