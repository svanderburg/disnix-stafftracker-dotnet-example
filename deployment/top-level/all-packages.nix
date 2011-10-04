{system, pkgs}:

rec {
### Databases

  rooms = import ../pkgs/databases/rooms {
    inherit (pkgs) stdenv;
  };
  
  staff = import ../pkgs/databases/staff {
    inherit (pkgs) stdenv;
  };
  
  zipcodes = import ../pkgs/databases/zipcodes {
    inherit (pkgs) stdenv;
  };
  
### Web services + Clients

  GeolocationService = import ../pkgs/webservices/GeolocationService {
    inherit (pkgs) dotnetenv;
  };
  
  RoomService = import ../pkgs/webservices/RoomService {
    inherit (pkgs) dotnetenv;
  };
  
  StaffService = import ../pkgs/webservices/StaffService {
    inherit (pkgs) dotnetenv;
  };
  
  ZipcodeService = import ../pkgs/webservices/ZipcodeService {
    inherit (pkgs) dotnetenv;
  };
  
### Web applications

  StaffTracker = import ../pkgs/webapplications/StaffTracker {
    inherit (pkgs) dotnetenv;
  };
}
