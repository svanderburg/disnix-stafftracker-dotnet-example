{stdenv}:

stdenv.mkDerivation {
  name = "zipcodes";
  src = ../../../../services/databases/zipcodes;
  installPhase = ''
    mkdir -p $out/mssql-databases
    cp *.sql $out/mssql-databases
  '';
}
