{dotnetenv}:

dotnetenv.buildSolution {
  name = "StaffTracker";
  src = ../../../../services/webapplications/StaffTracker;
  baseDir = "StaffTracker";
  slnFile = "StaffTracker.csproj";
  targets="Package";
}
