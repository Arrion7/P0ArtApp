using UI;
using DL;
using BL;

string connectionString = File.ReadAllText("./connectionString.txt");

IRepository repo = new DBRepository(connectionString);
IRepository bl = new Asbl(repo);

new ArtHome(bl).Home();