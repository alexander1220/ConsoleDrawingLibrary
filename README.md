![Banner](https://user-images.githubusercontent.com/47181191/218121404-1d86b636-49a9-414f-81c7-7885038e15ba.png)


# Console Drawer Library

 [![C#](https://img.shields.io/badge/Language-C%23-blue?style=for-the-badge&logo=.net)](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)) 

### Table of contents:
- [Project Overview](#project-overview)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Tips](#tips)
- [Demos](#demos)

<a name="project-overview"/>

## :open_book: Project Overview :

This is a DLL written in C#, it uses the most basic methods to **draw simple, colored forms** in the console.

It can be used to quickly draw simple forms, when creating e.g. user interfaces.

You can draw:

 - Points
 - Lines
 - Rectangles
 - Circles
 - Bezier Curves
 - Text
 - (more coming soon...)

<a name="getting-started"/>

## 🚀 Getting Started :

**First**, grab the .dll file [HERE](https://github.com/alexander1220/ConsoleDrawingLibrary/blob/master/ConsoleDrawingLibrary/bin/Release/ConsoleDrawingLibrary.dll) (or download the project and compile it yourself or just copy the code).

### Visual Studio :

1. Right-click on your project
2. Select Add > Project Reference
3. Click "Browse" > select the .dll > click "Ok"
3. Done 🎉

<a name="usage"/>

## 🧪 Usage :

### How to use the library :

**Import it:**

```cs
using ConsoleDrawingLibrary;
```
**Use it:**
```cs
string[] arr = { "Home", "Tools", "Data" };
int selected = 0;

ConsoleDrawer.DrawRect(10, 10, 60, 40);
ConsoleDrawer.DrawRect(10, 10, 13, 40);
for (int i = 0; i < arr.Length; i++)
{
    ConsoleDrawer.DrawText(14, 15 + (i * 3), i == selected ? "> " + arr[i] : arr[i]);
}
if(selected == 0)
{
    ConsoleDrawer.DrawBezier(30, 30, 64, 30, 47, 45);
    ConsoleDrawer.DrawBezier(30, 30, 64, 30, 47, 15);
    ConsoleDrawer.DrawCircle(41, 29, 6);
    ConsoleDrawer.DrawFilledCircle(44, 29, 3);
}
```

![image](https://user-images.githubusercontent.com/47181191/218500518-9cbcc880-b65d-4f34-b530-10cf3270b41e.png)

<a name="tips"/>

## 💡 Tip:

Set your console font (Right click on the window > Preferences > Font) to "Raster Fonts" and use a quadratic size (e.g. 8x8) to prevent distortion

<a name="demos"/>

### Demos :

Really simple example login form:

https://user-images.githubusercontent.com/47181191/218248467-70ef012c-6077-417a-9c83-6eaed0c9f3c7.mp4

