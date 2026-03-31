using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace EncurtadorDownload;
public partial class RepairWindow : Window
{
    public RepairWindow()
    {
        InitializeComponent();

        var btnRepair = this.FindControl<Button>("RepairButton");
        var btnFinalize = this.FindControl<Button>("FinalizeButton");
        var btnSearch = this.FindControl<Button>("SearchButton");
        var btnUpdate = this.FindControl<Button>("UpdateButton");

        if (btnFinalize != null && btnRepair != null && btnSearch != null)
        {
            btnRepair.Background = Brushes.White;
            btnRepair.BorderBrush = Brushes.Black;
            btnRepair.Foreground = Brushes.Black;

            btnFinalize.Background = Brushes.White;
            btnFinalize.BorderBrush = Brushes.Black;
            btnFinalize.Foreground = Brushes.Black;

            btnSearch.Background = Brushes.White;
            btnSearch.BorderBrush = Brushes.Black;
            btnSearch.Foreground = Brushes.Black;

            btnUpdate.Background = Brushes.White;
            btnUpdate.BorderBrush = Brushes.Black;
            btnUpdate.Foreground = Brushes.Black;

             new Efeito(btnRepair);
             new Efeito(btnFinalize);
             new Efeito(btnSearch);
             new Efeito(btnUpdate);
        }
    }

    private void RepairDep(object? sender, RoutedEventArgs e)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "pkexec",
            ArgumentList = {"apt install -f"},
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = Process.Start(psi);

        string error = process.StandardError.ReadToEnd();
        string output = process.StandardOutput.ReadToEnd();

        if (!string.IsNullOrWhiteSpace(error))
        {
            new NotificationWindow("Ocorreu um erro ao corrigir dependências", "ERROR", "Red").Show();
        }
         else
        {
            new NotificationWindow("Dependências corrigidas com sucesso", "SUCESSO", "Lime").Show();
        }
    }

    private void FinishDownload(object? sender, RoutedEventArgs e)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "pkexec",
            ArgumentList = {"dpkg --configure -a"},
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = Process.Start(psi);

        string error = process.StandardError.ReadToEnd();
        string output = process.StandardOutput.ReadToEnd();

        if (!string.IsNullOrWhiteSpace(error))
        {
            new NotificationWindow("Ocorreu um erro ao corrigir dependências", "ERROR", "Red").Show();
        }
         else
        {
            new NotificationWindow("Dependências corrigidas com sucesso", "Sucesso", "Lime").Show();
        }
    }

    private async void SearchBroken(object? sender, RoutedEventArgs e)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "pkexec",
            ArgumentList = {"bash", "-c", "dpkg -l | grep '^..r'"},
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process { StartInfo = psi };

        process.Start();

        string output = await process.StandardOutput.ReadToEndAsync();
        string error = await process.StandardError.ReadToEndAsync();

        await process.WaitForExitAsync();

        if (!string.IsNullOrWhiteSpace(error))
        {
            new NotificationWindow(error, "ERROR", "Red").Show();
        }         else if (!string.IsNullOrWhiteSpace(output))
        {
            new NotificationWindow(output, "Pacotes Encontrados", "Orage").Show();
        } 
        else
        {
            new NotificationWindow("Nenhum pacote quebrado encontrado.", "Sucesso", "Lime").Show();
        }
    }

    private void SearchUpdates(object? sender, RoutedEventArgs e)
    {
        var (upgrateOutput, upgradeError) = ExecuteCommand("apt-get", "-s upgrade");
        var (autoOutput, autoError) = ExecuteCommand("apt-get", "-s autoremove");

        bool hasUpdates = !upgrateOutput.Contains("0 upgraded");
        bool hasTrash = !autoOutput.Contains("0 to remove");

        if (!string.IsNullOrWhiteSpace(upgradeError))
        {
            new NotificationWindow(upgradeError, "ERROR", "Red").Show();
            return;
        }

        string menssage = "";

        menssage += hasUpdates ? "Atualizações disponíveis:\n" : "Nenhuma atualização disponível.\n";
        
        menssage += hasTrash ? "Pacotes para remoção automática:\n" : "Nenhum pacote para remoção automática.";

        new NotificationWindow(menssage, "Satatus do Sistema", "Lime").Show();
    }

    private (string output, string error) ExecuteCommand(string arg1, string arg2)
    {
        var psi = new ProcessStartInfo
        {
            FileName = arg1,
            Arguments = arg2,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = Process.Start(psi);

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        return (output, error);
    }
}
