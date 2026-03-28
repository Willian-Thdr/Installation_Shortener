using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Avalonia.Controls.Documents;

public class InstallDeb
{
    public InstallDeb(string pathway)
    {
        bool IsDependencyError(string error)
        {
            return error.Contains("Depends:") ||
                error.Contains("dependências desencontradas") ||
                error.Contains("but it is not installable");
        }

        string path = pathway;

        var psi = new ProcessStartInfo
            {
                FileName = "pkexec",
                Arguments = $"apt -instal -y \"{path}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(psi);

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrWhiteSpace(error))
            {
                new NotificationWindow(error, "ERROR", "Red").Show();

            if (IsDependencyError(error))
            {
                new NotificationWindow(error, "DEPENDENCY ERROR", "Red").Show();
            }
            }
            else
            {
                var notific = new NotificationWindow("Instalado com sucesso!", "Notification", "Lime");
                notific.Timer();
            }
    }

    public static List<string> ExtractDependencies(string error)
    {
        var dependencies = new List<string>();

        var matches = Regex.Matches(error, @"Depends:\s*([a-zA-Z0-9\-\._]+)");

        foreach (Match match in matches)
        {
            dependencies.Add(match.Groups[1].Value);
        }

        return dependencies;
    }
}