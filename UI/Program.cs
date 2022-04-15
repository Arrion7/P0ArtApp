using UI;
using DL;
using BL;

string connectionString = File.ReadAllText("./connectionString.txt");

IRepository repo = new DBRepository(connectionString);

new ArtHome((IAsbl)new Asbl(repo)).Account();
