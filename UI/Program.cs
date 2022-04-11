using BL;

namespace UI;

string connectionString = File.ReadAllText("./connectionstring");
IRepositoryrepo = new DbRepository(connectionString);
IAsbl bl = IAsbl(repo);

new ArtHome(bl).Start();
