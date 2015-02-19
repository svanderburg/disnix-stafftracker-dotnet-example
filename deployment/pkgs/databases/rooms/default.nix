{stdenv}:

stdenv.mkDerivation {
  name = "rooms";
  src = ../../../../services/databases/rooms;
  installPhase = ''
    mkdir -p $out/mssql-databases
    cp *.sql $out/mssql-databases
  '';
}
