{stdenv}:

stdenv.mkDerivation {
  name = "rooms";
  src = ../../../../services/databases/rooms;
  installPhase = ''
    ensureDir $out/mssql-databases
    cp *.sql $out/mssql-databases
  '';
}
