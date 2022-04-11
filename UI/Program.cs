using BL;

namespace UI;

string connectionString = File.ReadAllText("./connectionstring");
IRepositoryrepo = new DbRepository(connectionString);
IAsbl bl = IAsbl(repo);

new ArtHome(bl).Start();
#pragma warning restore CS1022 // Type or namespace definition, or end-of-file expected
#pragma warning restore CS1001 // Identifier expected
#pragma warning restore CS1002 // ; expected