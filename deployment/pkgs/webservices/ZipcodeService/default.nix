{zipcodes}:
{dotnetenv}:

dotnetenv.buildSolution {
  name = "ZipcodeService";
  src = ../../../../services/webservices/ZipcodeService;
  baseDir = "ZipcodeService";
  slnFile = "ZipcodeService.csproj";
  targets = "Package";
  preBuild = ''
    sed -e 's|.\SQLEXPRESS|${zipcodes.target.hostname}\SQLEXPRESS|' \
        -e 's|Initial Catalog=zipcodes|Initial catalog=${zipcodes.name}|' \
	-e 's|User ID=sa|User ID=${zipcodes.target.msSqlUsername}|' \
	-e 's|Password=admin123$|Password=${zipcodes.target.msSqlPassword}|' Web.config
  '';
}
