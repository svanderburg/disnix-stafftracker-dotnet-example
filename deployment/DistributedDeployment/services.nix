{distribution, invDistribution, system, pkgs}:

let customPkgs = import ../top-level/all-packages.nix { inherit system pkgs; };
in
rec {
### Databases

  rooms = {
    name = "rooms";
    pkg = customPkgs.rooms;
    dependsOn = {};
    type = "mssql-database";
  };
  
  staff = {
    name = "staff";
    pkg = customPkgs.staff;
    dependsOn = {};
    type = "mssql-database";
  };
  
  zipcodes = {
    name = "zipcodes";
    pkg = customPkgs.zipcodes;
    dependsOn = {};
    type = "mssql-database";
  };
  
### Web services

  GeolocationService = {
    name = "GeolocationService";
    pkg = customPkgs.GeolocationService;
    dependsOn = {};
    type = "iis-webapplication";
  };
  
  RoomService = {
    name = "RoomService";
    pkg = customPkgs.RoomService;
    dependsOn = {
      inherit rooms;
    };
    type = "iis-webapplication";
  };
  
  StaffService = {
    name = "StaffService";
    pkg = customPkgs.StaffService;
    dependsOn = {
      inherit staff;
    };
    type = "iis-webapplication";
  };
  
  ZipcodeService = {
    name = "ZipcodeService";
    pkg = customPkgs.ZipcodeService;
    dependsOn = {
      inherit zipcodes;
    };
    type = "iis-webapplication";
  };
  
### Web applications

  StaffTracker = {
    name = "StaffTracker";
    pkg = customPkgs.StaffTracker;
    dependsOn = {
      inherit GeolocationService RoomService StaffService ZipcodeService;
    };
    type = "iis-webapplication";
  };
}
