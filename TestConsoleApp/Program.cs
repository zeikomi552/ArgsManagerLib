// See https://aka.ms/new-console-template for more information
using ArgsManagerLib;
using System.Diagnostics;


// コマンドライン引数 → -p1 test       -p3 -p4 -p2 123
string[] keys = new string[] { "-p1", "-p2", "-p3", "-p4", "-p5" };
ArgsManager test = new ArgsManager(keys, args);

foreach (var key in keys)
{
    Console.WriteLine(key + " --> " + test[key]);
}
