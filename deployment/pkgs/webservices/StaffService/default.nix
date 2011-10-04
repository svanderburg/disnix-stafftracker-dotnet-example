{staff}:
{dotnetenv}:

dotnetenv.buildSolution {
  name = "StaffService";
  src = ../../../../services/webservices/StaffService;
  baseDir = "StaffService";
  slnFile = "StaffService.csproj";
  targets = "Package";
  preBuild = ''
    sed -e 's|.\SQLEXPRESS|${staff.target.hostname}\SQLEXPRESS|' \
        -e 's|Initial Catalog=staff|Initial catalog=${staff.name}|' \
	-e 's|User ID=sa|User ID=${staff.target.msSqlUsername}|' \
	-e 's|Password=admin123$|Password=${staff.target.msSqlPassword}|' Web.config
  '';

}
