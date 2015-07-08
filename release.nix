{ nixpkgs ? <nixpkgs>
, disnix_stafftracker_dotnet_example ? {outPath = ./.; rev = 1234;}
, officialRelease ? false
}:

let
  jobs = rec {
    tarball =
      let
        pkgs = import nixpkgs {};
        
        disnixos = import "${pkgs.disnixos}/share/disnixos/testing.nix" {
          inherit nixpkgs;
        };
      in
      disnixos.sourceTarball {
        name = "disnix-stafftracker-dotnet-example";
        version = builtins.readFile ./version;
        src = disnix_stafftracker_dotnet_example;
        inherit officialRelease;
      };
  };
in
jobs
