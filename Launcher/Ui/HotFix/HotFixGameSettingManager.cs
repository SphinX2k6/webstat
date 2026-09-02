using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004505 RID: 17669
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixGameSettingManager
	{
		// Token: 0x0602E8FB RID: 190715 RVA: 0x00B08218 File Offset: 0x00B06418
		public void ApplyGameSettings()
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
			if (!Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
			{
				this.Apply(dictionary, 6);
			}
		}

		// Token: 0x0602E8FC RID: 190716 RVA: 0x00B08278 File Offset: 0x00B06478
		[NullableContext(2)]
		private Dictionary<int, double> LoadPlayMenuInfo()
		{
			Dictionary<int, double> global = Singleton<LauncherStorageLib>.Instance.GetGlobal<Dictionary<int, double>>(ELauncherStorageGlobalKey.MenuData, null);
			if (global == null)
			{
				string global2 = Singleton<LauncherStorageLib>.Instance.GetGlobal<string>(ELauncherStorageGlobalKey.PlayMenuInfo, "");
				if (global2 != null && global2 != "")
				{
					return LaunchUtil.ObjToMap<string, double>(LauncherJson.Parse<Dictionary<string, double>>(global2, null) ?? new Dictionary<string, double>());
				}
			}
			return global;
		}

		// Token: 0x0602E8FD RID: 190717 RVA: 0x00B082D0 File Offset: 0x00B064D0
		[NullableContext(2)]
		private Dictionary<int, double> LoadGameSetting()
		{
			Dictionary<int, double> dictionary = this.LoadPlayMenuInfo();
			if (dictionary == null)
			{
				Singleton<LauncherLog>.Instance.Info("[HotFixGameSettingManager][GameSettings]找不到玩家保存数据，从默认配置表中读取", default(ReadOnlySpan<ValueTuple<string, object>>));
				dictionary = new Dictionary<int, double>();
			}
			this.SetGameDataMap(dictionary, 1, ELauncherStorageGlobalKey.MasterVolume, 100);
			this.SetGameDataMap(dictionary, 2, ELauncherStorageGlobalKey.VoiceVolume, 100);
			this.SetGameDataMap(dictionary, 3, ELauncherStorageGlobalKey.MusicVolume, 100);
			this.SetGameDataMap(dictionary, 4, ELauncherStorageGlobalKey.SFXVolume, 100);
			this.SetGameDataMap(dictionary, 69, ELauncherStorageGlobalKey.AMBVolume, 100);
			this.SetGameDataMap(dictionary, 70, ELauncherStorageGlobalKey.UIVolume, 100);
			this.SetGameDataMap(dictionary, 6, ELauncherStorageGlobalKey.PcResolutionIndex, 0);
			return dictionary;
		}

		// Token: 0x0602E8FE RID: 190718 RVA: 0x00B0835C File Offset: 0x00B0655C
		private unsafe void SetGameDataMap(Dictionary<int, double> gameDataMapRef, int functionId, ELauncherStorageGlobalKey launcherStorageGlobalKey, int NotFoundValue = 0)
		{
			double global = Singleton<LauncherStorageLib>.Instance.GetGlobal<double>(launcherStorageGlobalKey, double.NaN);
			if (!double.IsNaN(global))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[HotFixGameSettingManager][GameSettings]设置游戏数据Map时，存在新版本的游戏设置，将读取新版本的游戏设置数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", global);
				instance.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				gameDataMapRef[functionId] = global;
				return;
			}
			if (!gameDataMapRef.ContainsKey(functionId))
			{
				double? defaultGameSetttingsValue = this.GetDefaultGameSetttingsValue(functionId);
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "[HotFixGameSettingManager][GameSettings]设置游戏数据Map";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("defaultValue", defaultGameSetttingsValue);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("NotFoundValue", NotFoundValue);
				instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				gameDataMapRef[functionId] = (defaultGameSetttingsValue ?? ((double)NotFoundValue));
			}
		}

		// Token: 0x0602E8FF RID: 190719 RVA: 0x00B08494 File Offset: 0x00B06694
		private double? GetDefaultGameSetttingsValue(int functionId)
		{
			LaunchGameSettingMenuConfig gameSettingsMenuConfigByFunctionId = Singleton<LauncherConfigLib>.Instance.GetGameSettingsMenuConfigByFunctionId(functionId);
			if (gameSettingsMenuConfigByFunctionId == null)
			{
				return null;
			}
			return new double?((double)gameSettingsMenuConfigByFunctionId.GetDefaultValue());
		}

		// Token: 0x0602E900 RID: 190720 RVA: 0x00B084C8 File Offset: 0x00B066C8
		private unsafe void Apply(Dictionary<int, double> gameDataMap, int functionId)
		{
			double num;
			if (!gameDataMap.TryGetValue(functionId, out num))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[HotFixGameSettingManager][GameSettings]找不到对应热更游戏设置数据";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("functionId", functionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", null);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			LauncherLog instance2 = Singleton<LauncherLog>.Instance;
			string message2 = "[HotFixGameSettingManager][GameSettings]应用热更游戏设置数据";
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

		// Token: 0x0602E901 RID: 190721 RVA: 0x00B08615 File Offset: 0x00B06815
		private void ApplyRTPCValue(string rtpc, float value)
		{
			UAkGameplayStatics.SetRTPCValue(null, value, 0, null, new FName(rtpc));
		}

		// Token: 0x0602E902 RID: 190722 RVA: 0x00B08628 File Offset: 0x00B06828
		private unsafe void ApplyResolution(int value)
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				return;
			}
			List<FIntPoint> resolutionList = this.GetResolutionList();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[HotFixGameSettingManager][GameSettings]当前分辨率列表";
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
			string message2 = "[HotFixGameSettingManager][GameSettings]热更时应用分辨率";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("value", value);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("resolution", fintPoint);
			instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
			gameUserSettings.SetScreenResolution(fintPoint);
			gameUserSettings.ApplySettings(true);
		}

		// Token: 0x0602E903 RID: 190723 RVA: 0x00B0871E File Offset: 0x00B0691E
		public List<FIntPoint> GetResolutionList()
		{
			return Singleton<LauncherGameSettingLib>.Instance.GetResolutionList();
		}

		// Token: 0x0401A735 RID: 108341
		private const int MASTERVOLUMEFUNCTION = 1;

		// Token: 0x0401A736 RID: 108342
		private const int VOICEVOLUMEFUNCTION = 2;

		// Token: 0x0401A737 RID: 108343
		private const int MUSICVOLUMEFUNCTION = 3;

		// Token: 0x0401A738 RID: 108344
		private const int SFXVOLUMEFUNCTION = 4;

		// Token: 0x0401A739 RID: 108345
		private const int RESOLUTION = 6;

		// Token: 0x0401A73A RID: 108346
		private const int AMBVOLUMEFUNCTION = 69;

		// Token: 0x0401A73B RID: 108347
		private const int UIVOLUMEFUNCTION = 70;

		// Token: 0x0401A73C RID: 108348
		private const int DEFAULT_VOLUME_VALUE = 100;
	}
}
