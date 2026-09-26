# Toast

C# VS 2015 solution for Windows toast-style notifications plus a Win10-style Action Center. CreateToastNotifications demo pops near-tray toasts with slide/fade/roll/center animations, duration, and sounds. Action Center is a WCF-hosted message list with tray icon. Core toast UI from a 2009 vbforums sample (no license stated), used with EDGE Shop Flag Notifier; my copy adds Action Center, Contracts, Native, ControlLibrary.

**Source last updated:** 2016-10-02 · **Language:** C# · **Target:** .NET Framework 4.5.2 · **Output:** WinForms exes + class libraries

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `CreateToastNotifications` | C# | WinForms exe | Demo launcher: near-tray toasts with slide/fade/roll/center, duration, and WAV sounds |
| `Action Center` | C# | WinForms exe + WCF host | Win10-style action-center list with tray icon; named-pipe `IToastMessageService` inbox |
| `Native` | C# | Class library | `FormAnimator` plus P-Invoke helpers (chrome colour, window APIs) |
| `Contracts` | C# | Class library | WCF `IToastMessageService` / `ToastMessage` / `ToastBehavior` |
| `ControlLibrary` | C# | Class library | `ListPanel` / `ListPanelItem` WinForms controls used by Action Center |
| `Test` | C# | WinForms exe | Scratch host that references the other projects |
| `ACControls` | C# | Class library (sibling repo) | Not in this tree; clone [VaderConsulting/ACControls](https://github.com/VaderConsulting/ACControls) beside this folder |

## How to open

Open `WindowsToastNotifications.sln` in Visual Studio 2015 (solution format 12.00 / Visual Studio 14). C# projects target .NET Framework 4.5.2; most are ToolsVersion 14.0 (`CreateToastNotifications` is ToolsVersion 12.0). `Action Center/Action Center.csproj` was reconstructed because the OneDrive zip contained `Action Center.csproj_Error.txt` instead of the original. The solution expects the sibling project at `..\ACControls\ACControls\ACControls.csproj` (publish that repo next to this one). MSDN toast/Action Center links are kept in `ReadMe.txt`.

## Requirements

- Visual Studio 2015, .NET Framework 4.5.2

## Attribution and provenance

Working copy from my Historical Dev folder `Toast`. Original README attributes the core toast UI to a 2009 vbforums sample at http://www.vbforums.com/showthread.php?t=547778 (no license information supplied), later modified for [EDGE Shop Flag Notifier](http://www.mpiworldclass.com/customer-center/beta-widgets.aspx). `ToastNotifications/NotificationInfo.cs` is copyright 2007-2011 Service Repair Solutions, Inc., namespace `Mpi.Edge.ShopFlagNotifier`. Assembly copyrights: ToastNotifications © 2012; Action Center, Native, Contracts, ControlLibrary, and Test © 2016. My copy adds Action Center (WCF named-pipe host and tray UI), Contracts, Native, and ControlLibrary.

## License

MIT © 2026 VaderConsulting for Dave Robinson's code. See `LICENSE`. The vbforums toast core (no license supplied) and the Service Repair Solutions copyright in `NotificationInfo.cs` are described in `THIRD_PARTY_NOTICES.md`.
