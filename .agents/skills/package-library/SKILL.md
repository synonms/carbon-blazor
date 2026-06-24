---
name: package-library
description: Guide for packaging and publishing the CarbonBlazor library. Use this when asked to package or publish the library.
---

To package CarbonBlazor, follow this process:

1. Update the version number in the Synonms.CarbonBlazor.csproj file. The version number should follow semantic versioning (MAJOR.MINOR.PATCH) and be incremented appropriately based on the changes made since the last release.
2. Run the pack command to create a NuGet package. This can be done using the following command in the terminal:

   ```
   dotnet pack Synonms.CarbonBlazor.csproj -c Release -o ./nupkg
   ```

   This will create a .nupkg file in the ./nupkg directory.

3. (Optional) If you want to publish the package to the public NuGet feed, you can use the following command:

   ```
   dotnet nuget push ./nupkg/Synonms.CarbonBlazor.<version>.nupkg -k <API_KEY> -s https://api.nuget.org/v3/index.json
   ```

   The <API_KEY> parameter should be replaced with the Synonms NuGet API key, which must be obtained from the user and kept secure.

