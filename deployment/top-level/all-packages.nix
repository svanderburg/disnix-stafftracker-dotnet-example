{system, pkgs}:

let
  callPackage = pkgs.lib.callPackageWith (pkgs // self);
  
  self = {
    ### Databases

    rooms = callPackage ../pkgs/databases/rooms { };
  
    staff = callPackage ../pkgs/databases/staff { };
  
    zipcodes = callPackage ../pkgs/databases/zipcodes { };
  
    ### Web services + Clients

    GeolocationService = callPackage ../pkgs/webservices/GeolocationService { };
  
    RoomService = callPackage ../pkgs/webservices/RoomService { };
  
    StaffService = callPackage ../pkgs/webservices/StaffService { };
  
    ZipcodeService = callPackage ../pkgs/webservices/ZipcodeService { };
  
    ### Web applications

    StaffTracker = callPackage ../pkgs/webapplications/StaffTracker { };
  };
in
self
