{dotnetenv}:
{GeolocationService, RoomService, StaffService, ZipcodeService}:

dotnetenv.buildSolution {
  name = "StaffTracker";
  src = ../../../../services/webapplications/StaffTracker;
  baseDir = "StaffTracker";
  slnFile = "StaffTracker.csproj";
  targets="Package";
  preBuild = ''
    sed -i -e "s|localhost:50974|${StaffService.target.hostname}/${StaffService.name}|" \
           -e "s|localhost:49302|${RoomService.target.hostname}/${RoomService.name}|" \
	   -e "s|localhost:50174|${ZipcodeService.target.hostname}/${ZipcodeService.name}|" \
	   -e "s|localhost:50760|${GeolocationService.target.hostname}/${GeolocationService.name}|" Web.config
  '';
}
