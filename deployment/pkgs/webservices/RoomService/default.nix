{dotnetenv}:
{rooms}:

dotnetenv.buildSolution {
  name = "RoomService";
  src = ../../../../services/webservices/RoomService;
  baseDir = "RoomService";
  slnFile = "RoomService.csproj";
  targets = "Package";
  preBuild = ''
    sed -e 's|.\SQLEXPRESS|${rooms.target.hostname}\SQLEXPRESS|' \
        -e 's|Initial Catalog=rooms|Initial catalog=${rooms.name}|' \
	-e 's|User ID=sa|User ID=${rooms.target.msSqlUsername}|' \
	-e 's|Password=admin123$|Password=${rooms.target.msSqlPassword}|' Web.config
  '';
}
