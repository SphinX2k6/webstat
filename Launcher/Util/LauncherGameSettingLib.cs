using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Ui;
using UnrealEngine;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A0 RID: 17568
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherGameSettingLib : Singleton<LauncherGameSettingLib>
	{
		// Token: 0x0602E530 RID: 189744 RVA: 0x00ADFB32 File Offset: 0x00ADDD32
		public void Initialize()
		{
			this.ApplyGameSettings();
		}

		// Token: 0x0602E531 RID: 189745 RVA: 0x00ADFB3A File Offset: 0x00ADDD3A
		public void InitInLaunch(UWorld world)
		{
			this.TryApplyMobileContentScaleFactor(world);
		}

		// Token: 0x0602E532 RID: 189746 RVA: 0x00ADFB44 File Offset: 0x00ADDD44
		private void ApplyGameSettings()
		{
			Dictionary<int, double> dictionary = this.LoadGameSetting();
			if (dictionary == null)
			{
				return;
			}
			this.Apply(dictionary, 1);
			this.Apply(dictionary, 2);
			this.Apply(dictionary, 3);
			this.Apply(dictionary, 4);
			this.Apply(dictionary, 69);
			this.Apply(dictionary, 70);
			this.Apply(dictionary, 6);
		}

		// Token: 0x0602E533 RID: 189747 RVA: 0x00ADFB98 File Offset: 0x00ADDD98
		[NullableContext(2)]
		public Dictionary<int, double> LoadPlayMenuInfo()
		{
			Dictionary<int, double> global = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<int, double>>(ELauncherStorageGlobalKey.MenuData, null);
			if (global == null)
			{
				string global2 = Singleton<LauncherStorageLib>.Instance.GetGlobal<string>(ELauncherStorageGlobalKey.PlayMenuInfo, string.Empty);
				if (!string.IsNullOrEmpty(global2))
				{
					return LaunchUtil.ObjToMap<int, double>(LauncherJson.Parse<Dictionary<int, double>>(global2, null));
				}
			}
			return global;
		}

		// Token: 0x0602E534 RID: 189748 RVA: 0x00ADFBE0 File Offset: 0x00ADDDE0
		[NullableContext(2)]
		private Dictionary<int, double> LoadGameSetting()
		{
			Dictionary<int, double> dictionary = this.LoadPlayMenuInfo();
			if (dictionary == null)
			{
				Singleton<LauncherLog>.Instance.Info("[LauncherGameSettingLib][GameSettings]找不到玩家保存数据，从默认配置表中读取????", default(ReadOnlySpan<ValueTuple<string, object>>));
				dictionary = new Dictionary<int, double>();
				this.SetGameDataMap(dictionary, 1, ELauncherStorageGlobalKey.MasterVolume, 100);
				this.SetGameDataMap(dictionary, 2, ELauncherStorageGlobalKey.VoiceVolume, 100);
				this.SetGameDataMap(dictionary, 3, ELauncherStorageGlobalKey.MusicVolume, 100);
				this.SetGameDataMap(dictionary, 4, ELauncherStorageGlobalKey.SFXVolume, 100);
				this.SetGameDataMap(dictionary, 69, ELauncherStorageGlobalKey.AMBVolume, 100);
				this.SetGameDataMap(dictionary, 70, ELauncherStorageGlobalKey.UIVolume, 100);
				this.SetGameDataMap(dictionary, 6, ELauncherStorageGlobalKey.PcResolutionIndex, 0);
			}
			else if (Singleton<LauncherStorageLib>.Instance.GetGlobal<bool>(ELauncherStorageGlobalKey.HasLocalGameSettings, false))
			{
				this.SetGameDataMap(dictionary, 6, ELauncherStorageGlobalKey.PcResolutionIndex, 0);
			}
			return dictionary;
		}

		// Token: 0x0602E535 RID: 189749 RVA: 0x00ADFC88 File Offset: 0x00ADDE88
		private unsafe void SetGameDataMap(Dictionary<int, double> gameDataMapRef, int functionId, ELauncherStorageGlobalKey launcherStorageGlobalKey, int NotFoundValue = 0)
		{
			double? global = Singleton<LauncherStorageLib>.Instance.GetGlobal<double?>(launcherStorageGlobalKey, null);
			if (global != null)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[LauncherGameSettingLib][GameSettings]设置游戏数据Map时，存在新版本的游戏设置，将读取新版本的游戏设置数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", global);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				gameDataMapRef[functionId] = global.Value;
				return;
			}
			LaunchGameSettingMenuConfig gameSettingsMenuConfigByFunctionId = Singleton<LauncherConfigLib>.Instance.GetGameSettingsMenuConfigByFunctionId(functionId);
			if (gameSettingsMenuConfigByFunctionId == null)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "[LauncherGameSettingLib][GameSettings]找不到设置系统表配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("NotFoundValue", NotFoundValue);
				instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				gameDataMapRef[functionId] = (double)NotFoundValue;
				return;
			}
			float defaultValue = gameSettingsMenuConfigByFunctionId.GetDefaultValue();
			LauncherLog instance3 = Singleton<LauncherLog>.Instance;
			string message3 = "[LauncherGameSettingLib][GameSettings]设置游戏数据Map";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("functionId", functionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("defaultValue", defaultValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("NotFoundValue", NotFoundValue);
			instance3.Info(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			gameDataMapRef[functionId] = (double)defaultValue;
		}

		// Token: 0x0602E536 RID: 189750 RVA: 0x00ADFE18 File Offset: 0x00ADE018
		private unsafe void Apply(Dictionary<int, double> gameDataMap, int functionId)
		{
			double num;
			if (!gameDataMap.TryGetValue(functionId, out num))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[LauncherGameSettingLib][GameSettings]找不到对应热更游戏设置数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", null);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[LauncherGameSettingLib][GameSettings]应用热更游戏设置数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", functionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("value", num);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			switch (functionId)
			{
			case 1:
				this.ApplyRTPCValue("volume_master", (float)num);
				return;
			case 2:
				this.ApplyRTPCValue("volume_voice", (float)num);
				return;
			case 3:
				this.ApplyRTPCValue("volume_music", (float)num);
				return;
			case 4:
				this.ApplyRTPCValue("volume_sfx", (float)num);
				return;
			case 5:
				break;
			case 6:
				this.ApplyResolution((int)num);
				break;
			default:
				if (functionId == 69)
				{
					this.ApplyRTPCValue("volume_sfx_amb", (float)num);
					return;
				}
				if (functionId != 70)
				{
					return;
				}
				this.ApplyRTPCValue("volume_sfx_ui", (float)num);
				return;
			}
		}

		// Token: 0x0602E537 RID: 189751 RVA: 0x00ADFF65 File Offset: 0x00ADE165
		private void ApplyRTPCValue(string rtpc, float value)
		{
			UAkGameplayStatics.SetRTPCValue(null, value, 0, null, new FName(rtpc));
		}

		// Token: 0x0602E538 RID: 189752 RVA: 0x00ADFF78 File Offset: 0x00ADE178
		private unsafe void ApplyResolution(int value)
		{
			List<FIntPoint> resolutionList = this.GetResolutionList();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[LauncherGameSettingLib][GameSettings]当前分辨率列表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("resolutionList", resolutionList);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (value < 0 || value >= resolutionList.Count)
			{
				return;
			}
			FIntPoint fintPoint = resolutionList[value];
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[LauncherGameSettingLib][GameSettings]热更时应用分辨率";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("resolution", fintPoint);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetScreenResolution(fintPoint);
			gameUserSettings.ApplySettings(true);
		}

		// Token: 0x0602E539 RID: 189753 RVA: 0x00AE0064 File Offset: 0x00ADE264
		public List<FIntPoint> GetResolutionList()
		{
			List<FIntPoint> list = new List<FIntPoint>();
			TArray<FIntPoint> tarray = new TArray<FIntPoint>();
			if (UKismetSystemLibrary.GetSupportedFullscreenResolutions(ref tarray))
			{
				for (int i = tarray.Num() - 1; i >= 0; i--)
				{
					FIntPoint fintPoint = tarray.Get(i);
					list.Add(fintPoint);
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "具体分辨率";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("resolution", fintPoint);
					instance.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			if (list.Count == 0)
			{
				Singleton<LauncherLog>.Instance.Info("[LauncherGameSettingLib][GameSettings]获取当前分辨率列表失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				list.Add(UGameUserSettings.GetGameUserSettings().GetDesktopResolution());
			}
			else
			{
				List<FIntPoint> list2 = list;
				Comparison<FIntPoint> comparison;
				if ((comparison = LauncherGameSettingLib.<>O.<0>__CompareResolution) == null)
				{
					comparison = (LauncherGameSettingLib.<>O.<0>__CompareResolution = new Comparison<FIntPoint>(LauncherGameSettingLib.CompareResolution));
				}
				list2.Sort(comparison);
			}
			if (list.Count > 0 && list[0].X == 3620 && list[0].Y == 2036)
			{
				list.RemoveAt(0);
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "最后的分辨率列表结果";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("resolutionList", list);
			instance2.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return list;
		}

		// Token: 0x0602E53A RID: 189754 RVA: 0x00AE0186 File Offset: 0x00ADE386
		private static int CompareResolution(FIntPoint a, FIntPoint b)
		{
			if (a.X == b.X)
			{
				return b.Y - a.Y;
			}
			return b.X - a.X;
		}

		// Token: 0x0602E53B RID: 189755 RVA: 0x00AE01B4 File Offset: 0x00ADE3B4
		private void TryApplyMobileContentScaleFactor(UWorld world)
		{
			if (Singleton<Platform>.Instance.IsRedMagicDevice())
			{
				return;
			}
			if (Singleton<Platform>.Instance.IsFoldingScreen() && (Singleton<Platform>.Instance.IsAndroidPlatform() || Singleton<Platform>.Instance.IsOpenHarmonyPlatform()))
			{
				string deviceProfileBaseProfileName = UKuroRenderingRuntimeBPPluginBPLibrary.GetDeviceProfileBaseProfileName();
				if (deviceProfileBaseProfileName == "Android_Low")
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(world, "r.MobileContentScaleFactor 2", null);
					return;
				}
				if (deviceProfileBaseProfileName == "Android_Mid")
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(world, "r.MobileContentScaleFactor 2.5", null);
					return;
				}
				if (deviceProfileBaseProfileName == "Android_High" || deviceProfileBaseProfileName == "Android_VeryHigh")
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(world, "r.MobileContentScaleFactor 3", null);
					return;
				}
				UKismetSystemLibrary.ExecuteConsoleCommand(world, "r.MobileContentScaleFactor 2", null);
			}
		}

		// Token: 0x0401A4F7 RID: 107767
		private const int MASTERVOLUMEFUNCTION = 1;

		// Token: 0x0401A4F8 RID: 107768
		private const int VOICEVOLUMEFUNCTION = 2;

		// Token: 0x0401A4F9 RID: 107769
		private const int MUSICVOLUMEFUNCTION = 3;

		// Token: 0x0401A4FA RID: 107770
		private const int SFXVOLUMEFUNCTION = 4;

		// Token: 0x0401A4FB RID: 107771
		private const int RESOLUTION = 6;

		// Token: 0x0401A4FC RID: 107772
		private const int AMBVOLUMEFUNCTION = 69;

		// Token: 0x0401A4FD RID: 107773
		private const int UIVOLUMEFUNCTION = 70;

		// Token: 0x0401A4FE RID: 107774
		private const int DEFAULT_VALUE_VALUE = 100;

		// Token: 0x0200A67C RID: 42620
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403377E RID: 210814
			[Nullable(0)]
			public static Comparison<FIntPoint> <0>__CompareResolution;
		}
	}
}
