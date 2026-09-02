using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Util;
using UnrealEngine;

// Token: 0x020034E6 RID: 13542
[NullableContext(1)]
[Nullable(0)]
public class LauncherFileLib : IStaticVariableResetter
{
	// Token: 0x0601C9F9 RID: 117241 RVA: 0x0089625B File Offset: 0x0089445B
	static LauncherFileLib()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LauncherFileLib.CreateStaticDefaultValue), new Action(LauncherFileLib.ResetStaticDefaultValue));
	}

	// Token: 0x0601C9FA RID: 117242 RVA: 0x0089627A File Offset: 0x0089447A
	public static void CreateStaticDefaultValue()
	{
		LauncherFileLib.HadDeletion = false;
	}

	// Token: 0x0601C9FB RID: 117243 RVA: 0x00896282 File Offset: 0x00894482
	public static void ResetStaticDefaultValue()
	{
		LauncherFileLib.HadDeletion = false;
	}

	// Token: 0x0601C9FC RID: 117244 RVA: 0x0089628C File Offset: 0x0089448C
	public unsafe static void ClearOldPackageResDir(string oldVer = "")
	{
		string appVersion = UKuroLauncherLibrary.GetAppVersion();
		string text = UKuroLauncherLibrary.GameSavedDir() + "Resources/";
		TArray<string> directories = UKuroStaticLibrary.GetDirectories(text);
		string text2 = Singleton<LauncherStorageLib>.Instance.GetDeviceSaved<string>(ELauncherStorageDeviceKey.PreDownloadConfig, "") ?? "";
		LauncherLog instance = Singleton<LauncherLog>.Instance;
		string message = "pre download record";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("preVer", text2);
		instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!string.IsNullOrEmpty(text2))
		{
			VersionInfo item = VersionInfo.TryParse(appVersion).Item2;
			VersionInfo item2 = VersionInfo.TryParse(text2).Item2;
			if (item != null && item2 != null && VersionInfo.LessThanOrEqual(item2, item))
			{
				text2 = "";
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "pre download record is <= appVer, preVer reset.";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("appVer", appVersion);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("preVer", text2);
				instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		int num = directories.Num();
		for (int i = 0; i < num; i++)
		{
			string text3 = directories.Get(i);
			if (!(text3 == appVersion) && !(text3 == EResType.Video.ToEnumString()) && (string.IsNullOrEmpty(text2) || !(text3 == text2)) && (string.IsNullOrEmpty(oldVer) || !(text3 == oldVer)))
			{
				UKuroLauncherLibrary.DeleteDirectory(text + text3);
				LauncherFileLib.HadDeletion = true;
			}
		}
	}

	// Token: 0x0601C9FD RID: 117245 RVA: 0x008963F8 File Offset: 0x008945F8
	public static void ClearResDirs(string resDir, ISet<string> retainVersions)
	{
		TArray<string> directories = UKuroStaticLibrary.GetDirectories(resDir);
		int num = directories.Num();
		for (int i = 0; i < num; i++)
		{
			string text = directories.Get(i);
			if (!retainVersions.Contains(text))
			{
				UKuroLauncherLibrary.DeleteDirectory(resDir + text);
				LauncherFileLib.HadDeletion = true;
			}
		}
	}

	// Token: 0x0601C9FE RID: 117246 RVA: 0x00896444 File Offset: 0x00894644
	public static void RemoveDownloadFile(string filePath)
	{
		if (!string.IsNullOrEmpty(filePath) && UBlueprintPathsLibrary.FileExists(filePath))
		{
			UKuroLauncherLibrary.DeleteFile(filePath);
		}
		string text = filePath + ".download";
		if (!string.IsNullOrEmpty(filePath) && UBlueprintPathsLibrary.FileExists(text))
		{
			UKuroLauncherLibrary.DeleteFile(text);
		}
	}

	// Token: 0x0400E683 RID: 59011
	public static bool HadDeletion;
}
