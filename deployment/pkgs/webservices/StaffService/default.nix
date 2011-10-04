{dotnetenv}:

dotnetenv.buildSolution {
  name = "StaffService";
  src = ../../../../services/webservices/StaffService;
  baseDir = "StaffService";
  slnFile = "StaffService.csproj";
  targets = "Package";
}
