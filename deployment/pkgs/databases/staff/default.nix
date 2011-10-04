{stdenv}:

stdenv.mkDerivation {
  name = "staff";
  src = ../../../../services/databases/staff;
  installPhase = ''
    ensureDir $out/mssql-databases
    cp *.sql $out/mssql-databases
  '';
}
