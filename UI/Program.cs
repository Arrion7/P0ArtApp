using BL;
using DL; 

namespace UI;


string connectionString = File.ReadAllText("./connectionString.txt");
IRepository repo = new DBRepository(connectionString);
IAsbl bl = new IAsbl(repo);
ArtHomeMain bl = new ArtHomeMain(repo).Start();
