<div align="center">

# Multiple File Launcher

**One list. One click. Your daily files and apps — without duplicates.**

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Windows](https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://www.microsoft.com/windows)
[![WinForms](https://img.shields.io/badge/UI-WinForms-00A4EF?style=for-the-badge)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)

<br>

<img src="docs/screenshot.png" alt="Multiple File Launcher screenshot" width="720" />

</div>

---

## What this is

A small Windows desktop app for people who open the same files every day.

You build a personal library — nested folders of documents, solutions, shortcuts, and programs — then launch everything with **Alle starten**, or let Windows do it for you at login. Entries you disable stay in the tree but are skipped. Files that are already open are skipped too.

The UI is German (`Datei-Launcher`). Settings live as JSON in `%AppData%\MultipleFileLauncher`.

---

## The problem it solves

Morning (and every other repeatable setup) looks like this:

1. Click a dozen shortcuts, one by one.
2. Some windows were already open → duplicates, locked-file dialogs, extra Excel instances.
3. Some apps ignore “start minimized” and land in the middle of the screen.
4. Tomorrow you do it again.

This app turns that ritual into a list you define once.

---

## How it is built

A single WinForms project on **.NET 10** (`net10.0-windows`). No NuGet packages. Persistence is `System.Text.Json`. Anything Windows does not give you for free is a thin P/Invoke.

```
MultipleFileLauncher/
├── Program.cs              Entry: UI, or silent --startup
├── Form1.cs                Tree, details, drag-and-drop
├── Models/LaunchItem.cs    Polymorphic folder / file tree
├── AppSettings.cs          Load, save, migrate, tree ops
├── FileLauncher.cs         Orchestration + window-state fallback
├── ShellLauncher.cs        ShellExecuteEx
├── RunningFileChecker.cs   Duplicate detection
├── WindowFinder.cs         EnumWindows by process
├── StartupManager.cs       HKCU Run key
├── ThemeColors.cs          Forest-green / cream palette
├── WindowStateTexts.cs     DE display ↔ stored state ↔ nShow
└── InputPrompt.cs          Folder-name dialog
```

Two modes from one executable:

| Mode | How | Behavior |
|---|---|---|
| Interactive | Double-click / `dotnet run` | Shows the library UI |
| Silent | `--startup` (registry Run key) | Loads settings, launches, exits — no window |

---

## Logic: which piece solves what

### 1. Organize without a spreadsheet — the tree

`LaunchFolder` and `LaunchFile` share `LaunchItem` (id + name). JSON uses a `$type` discriminator (`folder` / `file`), so the nested list round-trips as one document.

- Add into the selected folder, or next to the selected file.
- Drag-and-drop moves items; dropping onto a folder nests them; dropping onto a file inserts after it. Folders cannot be dropped into themselves.
- Per-file **Beim Starten einbeziehen** keeps an entry in the library without launching it.

### 2. Open anything Windows can open — ShellExecute

`ShellLauncher` calls `ShellExecuteEx` with verb `open`. That is the same path Explorer uses: `.sln` goes to Visual Studio, `.xlsx` to Excel, `.exe` starts the program. `SEE_MASK_NOCLOSEPROCESS` keeps a process handle for the next step; `SEE_MASK_FLAG_NOUI` keeps error dialogs out of silent startup.

If ShellExecute fails, `Process.Start` with `UseShellExecute = true` is the fallback.

### 3. Do not launch twice — Restart Manager + process name

`RunningFileChecker.IsAlreadyOpen` branches on file type:

| Target | How “already open” is decided |
|---|---|
| `.exe` / `.bat` / `.cmd` / `.com` | A running process whose `MainModule` path matches |
| Documents and everything else | Windows **Restart Manager** (`rstrtmgr.dll`): register the path, ask which processes hold it. Same family of API Task Manager uses for “this file is in use.” If that says idle, process-name matching is tried as a second pass. |

Enabled files whose path is missing on disk are skipped silently.

### 4. Honor minimized / maximized — poll, then force

Many apps ignore `nShow` on `ShellExecuteEx`. For Minimized and Maximized, `FileLauncher` keeps the process id, then for up to ~5 seconds (20 × 250 ms) enumerates visible titled windows of that process and calls `ShowWindowAsync`. Normal skips the fallback.

Default stored state is **Minimized**, so a login launch can populate the taskbar without covering the desktop.

### 5. Survive a reboot — Run key, not a service

`StartupManager` writes `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` to `"<exe>" --startup`. On login the UI never appears; only the launch sequence runs. Unchecking the box deletes the value.

Legacy flat `filePaths` arrays in old settings files are migrated into `LaunchFile` nodes on load.

---

## What makes it iconic

Not the feature count. The personality.

**It looks like a desk, not a dashboard.** Cream paper, sage sidebar, forest-green chrome. Folder and file glyphs are 16×16 bitmaps painted in GDI+ at runtime — no icon pack, no SVG pipeline.

**It is stubborn about Windows, in a small way.** Duplicate-safe launch via Restart Manager, and a window-state poll because `nShow` is a suggestion. That is the kind of detail people notice on the second morning, not the first screenshot.

**It disappears when it should.** `--startup` is a launcher that does not launch itself. The product is the files on your taskbar, not another window in the way.

**It stays tiny.** One project, no dependencies, JSON in AppData, Win32 only where the BCL stops. The whole idea fits in a handful of classes you can read in one sitting.

---

## Getting started

Requires Windows 10+ and the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet build
dotnet run --project MultipleFileLauncher
```

Publish a self-contained exe:

```bash
dotnet publish MultipleFileLauncher -c Release -r win-x64 --self-contained
```

### Using it

| Action | How |
|---|---|
| Add a folder | **+ Ordner**, enter a name |
| Add files | **+ Datei**, pick one or more |
| Edit | Select in the tree, change name/path/enabled, **Änderungen übernehmen** |
| Reorder | Drag and drop |
| Launch one | Double-click a file |
| Launch all | **Alle starten** |
| At login | **Mit Windows starten** |

Settings file:

```
%AppData%\MultipleFileLauncher\settings.json
```

---

<div align="center">

Made for people who open the same files every day — and want that back.

</div>
