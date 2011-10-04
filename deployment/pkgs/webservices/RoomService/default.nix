{dotnetenv}:

dotnetenv.buildSolution {
  name = "RoomService";
  src = ../../../../services/webservices/RoomService;
  baseDir = "RoomService";
  slnFile = "RoomService.csproj";
  targets = "Package";
}
