using UI;
using DL;
using BL;
using IAsbl = BL.IAsbl;

string connectionString = File.ReadAllText("./connectionString.txt");

IRepository repo = new DBRepository(connectionString);
IAsbl bl = new Asbl(repo);

new ArtHome((IAsbl)bl).Home();