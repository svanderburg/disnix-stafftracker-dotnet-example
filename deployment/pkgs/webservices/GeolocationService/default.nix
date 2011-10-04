{dotnetenv}:

dotnetenv.buildSolution {
  name = "GeolocationService";
  src = ../../../../services/webservices/GeolocationService;
  baseDir = "GeolocationService";
  slnFile = "GeolocationService.csproj";
  targets = "Package";
}