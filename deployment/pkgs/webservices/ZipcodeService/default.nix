{dotnetenv}:

dotnetenv.buildSolution {
  name = "ZipcodeService";
  src = ../../../../services/webservices/ZipcodeService;
  baseDir = "ZipcodeService";
  slnFile = "ZipcodeService.csproj";
  targets = "Package";
}
