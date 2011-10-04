{stdenv}:

stdenv.mkDerivation {
  name = "zipcodes";
  src = ../../../../services/databases/zipcodes;
  installPhase = ''
    ensureDir $out/mssql-databases
    cp *.sql $out/mssql-databases
  '';
}
