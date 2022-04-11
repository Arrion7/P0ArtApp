using BL;
using DL;     

namespace UI;

string connectionString = File.ReadAllText("./connectionstring");
IReporitory repo = new DBRepository(connectionString);
IASBL b1 = IASBL(repo);
new ArtHome(b1).Start();