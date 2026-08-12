using System;
using System.Threading.Tasks;
using NineshaftLightIntel.Validation;
using NineshaftLightIntel.Services;

Console.WriteLine("=== Nineshaft Light Intel v1.0 ===");

Console.Write("Enter target nickname: ");
string? inputNickname = Console.ReadLine();

if (!InputValidator.IsValidNickname(inputNickname))
{
    Console.WriteLine("[!] Error: Invalid input format detected.");
    return; 
}

string targetNickname = inputNickname!.Trim();
Console.WriteLine($"[*] Initiating scan for: {targetNickname}\n");

var scanner = new ProfileScanner();
await scanner.ExecuteScanAsync(targetNickname);

Console.WriteLine("\n[+] Scan completed successfully.");
