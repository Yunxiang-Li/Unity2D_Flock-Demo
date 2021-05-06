# Unity2D_Flock-Demo

[![standard-readme compliant](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

A simple 2d flock demo based on Unity2D game engine.

## Table of Contents

- [Background](#Background)
- [Exhibition](#Exhibition)
- [Install](#install)
- [Usage](#usage)
- [Structure](#Structure)
- [Maintainers](#Maintainers)
- [License](#license)

## Background

In this game demo, there are altogether 3 different flocks (orange, blue and green). For each single frame, every flock agent (single bird) will try to fly in a circle area with all its neighbors (same color), first gather, then align at same direction, next avoid colliding with each other. Each flock will ignore any other flocks.

## Exhibition

<div align="center"> <img src="https://github.com/Yunxiang-Li/Unity3D_A-Simple-3D-Platform-Game-Demo/blob/master/Screenshots%20and%20GIFs/Level001Succeed.gif"/> </div>

## Install

I use Unity2019.3.11f1 and JetBrain's Rider IDE for this project under Windows 10 environment.<br>
[Unity and Unity hub download](https://unity3d.com/get-unity/download)<br>
[archived Unity download ](https://unity3d.com/get-unity/download/archive)<br>
[Jetbrains Rider download](https://www.jetbrains.com/rider/download/#section=windows)

## Usage

1. Download this repo, open(or unzip and open) the **Unity2D_Flock-Demo** folder.

2. Open the **Unity Hub**, from the Home Screen, click **Projects** to view the **Projects** tab.

3. To open an existing Unity Project stored on your computer, click the Project name in the **Projects** tab, or click **Open** to browse your computer for the Project folder.

4. Note that a Unity Project is a collection of files and directories, rather than just one specific Unity Project file. To open a Project, you must select the main Project folder, rather than a specific file.

5. For this game, just select the **Unity2D_Flock-Demo** folder and open this project.

## Structure

The whole project in Unity contains two main folders, **Assets** folder and **Package** folder.

Under **Assets** folder, there are altogether **6** subfolders:

1. Behavior Objects folder: contains **15** behavior objects (Alignment behavior object, stay in radius behavior object and so on) created by scriptable objects in Unity as assets.

2. Filter Objects folder: contains **2** filter objects (same flock filter and obstacle layer filter) also created by scriptable objects in Unity as assets.

3. Prefabs Objects folder: contains **4** prefabs (orange, green, blue and default white prefabs).

4. Scenes folder: contains **1** main scene of this game demo.

5. Scripts folder: contains **18** C# scripts I write for this game demo. Under **Behavior Scripts** subfolder, there are altogether **12** C# scripts about flock behaviors. Under **Editor** subfolder, there is **1** C# script called CompositeBehaviorEditor which uses Unity GUI module to generate a custom behaviors editor. Under **Filter Scripts** subfolder, there are **3** C# scripts about filters. In addition to these C# scripts, there are also **Flock.cs** and **FlockAgent.cs** files to represent a flock and each single bird.

6. Sprites folder: contains **1** sprite for a single flock agent.

## Maintainers

[@Yunxiang-Li](https://github.com/Yunxiang-Li).

## License

[MIT license](https://github.com/Yunxiang-Li/Unity2D_Flock-Demo/blob/master/LICENSE)
