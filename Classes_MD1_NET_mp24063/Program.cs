// .NET 1. MD
// Māris Priede mp24063

using User;
using Users;

string path = @"..\..\data.txt"; 
var dm = new FigureXMLDataManager(path); 
dm.createTestData();
Console.WriteLine(dm.Print());
dm.Save(path);
dm.reset();
Console.WriteLine(dm.Print());
dm.Load(path);
Console.WriteLine(dm.Print());
Console.ReadLine();