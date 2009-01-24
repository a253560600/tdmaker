#include "scripts\products.iss"

#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"
//#include "scripts\products\iis.iss"
//#include "scripts\products\kb835732.iss"

#include "scripts\products\msi20.iss"
#include "scripts\products\msi31.iss"
//#include "scripts\products\ie6.iss"

//#include "scripts\products\dotnetfx11.iss"
//#include "scripts\products\dotnetfx11lp.iss"
//#include "scripts\products\dotnetfx11sp1.iss"

#include "scripts\products\dotnetfx20.iss"
#include "scripts\products\dotnetfx20lp.iss"
#include "scripts\products\dotnetfx20sp1.iss"
#include "scripts\products\dotnetfx20sp1lp.iss"

#include "scripts\products\dotnetfx35.iss"
//#include "scripts\products\dotnetfx35lp.iss"
//#include "scripts\products\dotnetfx35sp1.iss"
//#include "scripts\products\dotnetfx35sp1lp.iss"

//#include "scripts\products\mdac28.iss"
//#include "scripts\products\jet4sp8.iss"

[CustomMessages]
win2000sp3_title=Windows 2000 Service Pack 3
winxpsp2_title=Windows XP Service Pack 2


[Setup]
AppName=TDMaker
AppVerName=TDMaker 1.7
VersionInfoVersion=1.7.1.0
VersionInfoTextVersion=1.7.1.0
VersionInfoCompany=BetaONE
VersionInfoDescription=Torrent Description Maker
AppPublisher=BetaONE
AppPublisherURL=http://code.google.com/p/tdmaker
AppSupportURL=http://code.google.com/p/tdmaker
AppUpdatesURL=http://code.google.com/p/tdmaker
DefaultDirName={pf}\TDMaker
DefaultGroupName=BetaONE\TDMaker
AllowNoIcons=yes
InfoBeforeFile=..\TorrentDescriptionMaker\VersionHistory.txt
InfoAfterFile=..\TorrentDescriptionMaker\ReleaseInfo.txt
SolidCompression=yes
;PrivilegesRequired=none
OutputDir=..\..\Output\
ArchitecturesInstallIn64BitMode=x64 ia64
DirExistsWarning=no
CreateAppDir=true
UsePreviousGroup=yes
UsePreviousAppDir=yes
ShowUndisplayableLanguages=no
LanguageDetectionMethod=uilanguage
InternalCompressLevel=fast
Compression=lzma

;required by products
MinVersion=4.1,5.0
PrivilegesRequired=admin
;ArchitecturesAllowed=x86

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\TorrentDescriptionMaker\bin\Release\TDMaker.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\TorrentDescriptionMaker\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\MTN\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\MTN\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\MediaInfo\x86\MediaInfo.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Not IsWin64
Source: "..\..\MediaInfo\x64\MediaInfo.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: IsWin64

[Icons]
Name: "{group}\TDMaker"; Filename: "{app}\TDMaker.exe"
;Name: "{group}\TDMaker Manual"; Filename: "{app}\TDMaker-manual.pdf"
Name: "{userdesktop}\TDMaker"; Filename: "{app}\TDMaker.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\TDMaker"; Filename: "{app}\TDMaker.exe."; Tasks: quicklaunchicon

[Run]
Filename: "{app}\TDMaker.exe."; Description: "{cm:LaunchProgram,TDMaker}"; Flags: nowait postinstall skipifsilent
;Filename: "{app}\TDMaker-manual.pdf"; Description: "{cm:LaunchProgram,TDMaker Manual}"; Flags: nowait unchecked postinstall shellexec skipifsilent

[Code]
function InitializeSetup(): Boolean;
begin
	initwinversion();

	if (not minspversion(5, 0, 3)) then begin
		MsgBox(FmtMessage(CustomMessage('depinstall_missing'), [CustomMessage('win2000sp3_title')]), mbError, MB_OK);
		exit;
	end;
	if (not minspversion(5, 1, 2)) then begin
		MsgBox(FmtMessage(CustomMessage('depinstall_missing'), [CustomMessage('winxpsp2_title')]), mbError, MB_OK);
		exit;
	end;
	
	//if (not iis()) then exit;
	
	msi20('2.0');
	msi31('3.0');
//	ie6('5.0.2919');
	
	//dotnetfx11();
	//dotnetfx11lp();
	//dotnetfx11sp1();
	
//	kb835732();
	
	if (minwinversion(5, 0) and minspversion(5, 0, 4)) then begin
		dotnetfx20sp1();
		dotnetfx20sp1lp();
	end else begin
		dotnetfx20();
		dotnetfx20lp();
	end;
	
dotnetfx35();
// dotnetfx35lp();
	//dotnetfx35sp1();
	//dotnetfx35sp1lp();
	
//	mdac28('2.7');
//	jet4sp8('4.0.8015');
	
	Result := true;
end;
