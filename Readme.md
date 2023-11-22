# Below the Stone - Mod Template

This is a template repository for Below the Stone Mods. It Is a clone of [PitchDark](https://github.com/MSchmoecker/PitchDark), stripped down to the minimum. 

![Showcase](Docs/BtS_Logo.png)

Put showcase image there ^

## How to use this repository

1. Fork or Clone it
2. Change the following:
   - `AssemblyTitle` and `AssemblyProduct` in `Properties\AsssemblyInfo.cs`
   - `RootNameSpace` and `AssemblyName` in `BtSModTemplate.csproj`
   - Change `namespace BtsModTemplate` in `Plugin.cs` to `namespace <YourPluginName>`
   - Optionally: Rename `BtSModTemplate.csproj`. If you do, also change all instances of `BtsModTemplate` in `BtsModTemplate.sln`
   - Optionally: Rename `BtSModTemplate.sln`

## Installation

This mod requires BepInEx to work, it's a modding framework that allows multiple mods being loaded. Furthermore, Harmony is used to patch into the game, which means no game code is distributed and allows multiple mods to change it interdependent.

1. Download BepInEx from https://github.com/BepInEx/BepInEx/releases
2. Extract all files to your Below The Stone folder. It should look like this:\
   ![BepInEx folder](Docs/BepInExSetup.png)
3. Optional: start the game once. Afterwards you will see a config file in BepInEx/config/ called `BepInEx.cfg`. Open it and set `Enabled = true` under `[Logging.Console]` to see loaded mods and errors immediately.
4. Download this mod from [Releases](https://github.com/MSchmoecker/PitchDark/releases) and extract it into BepInEx/plugins/
5. Launch the game!

## Configuration

The config file is located in `BepInEx/config/<Your Plugin Name>.cfg` after you launched the game once with the mod installed.

Add more instructions about your configuration options in here

## Development

1. Install BepInEx
2. Create a file called `Environment.props` in the root folder (one folder above the PitchDark.csproj file) and add the following content:
   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
       <PropertyGroup>
           <BELOW_THE_STONE_INSTALL>C:/Program Files/Steam/steamapps/common/Below The Stone</BELOW_THE_STONE_INSTALL>
           <MOD_DEPLOYPATH>$(BELOW_THE_STONE_INSTALL)/BepInEx/plugins</MOD_DEPLOYPATH>
       </PropertyGroup>
   </Project>
   ```
3. Compile the project. This copies the resulting dll into the `MOD_DEPLOYPATH`, if set

## Changelog

0.1.0
- Release
