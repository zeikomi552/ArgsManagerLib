# ArgsManagerLib
[![C#](https://img.shields.io/badge/csharp-black?style=for-the-badge&logo=csharp)](https://github.com/zeikomi552/ArgsManagerLib)

Easy to Use Command Line Paramters for Console Application



<div id="top"></div>

## Setup

[Nuget - ArgsManagerLib](https://www.nuget.org/packages/ArgsManagerLib/)

```
dotnet add package ArgsManagerLib --version 1.0.3
```

## How to Use

```
// Commad Line Parameters → -p1 test       -p3 -p4 -p2 123
string[] keys = new string[] { "-p1", "-p2", "-p3", "-p4", "-p5" };
ArgsManager test = new ArgsManager(keys, args);

foreach (var key in keys)
{
    Console.WriteLine(key + " --> " + test[key]);
}

// 出力結果
// -p1 --> test
// -p2 --> 123
// -p3 --> true
// -p4 --> true
// -p5 --> false
```

<p align="right">(<a href="#top">トップへ</a>)</p>