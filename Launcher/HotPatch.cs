using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AkiClient.Game.Aki.Core;
using CSharpScript.Game;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.DiffPatch.Procedure;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.HotPatchPushSdk;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Launcher
{
	// Token: 0x02004480 RID: 17536
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotPatch : Singleton<HotPatch>
	{
		// Token: 0x0602E4DC RID: 189660 RVA: 0x00ADD9B8 File Offset: 0x00ADBBB8
		public void Start(UObject worldContext, UGameInstance gameInstance)
		{
			UKuroRenderingRuntimeBPPluginBPLibrary.SetSceneRenderingState(worldContext, true);
			UKismetSystemLibrary.ExecuteConsoleCommand(worldContext, "r.fog 1", null);
			this.WorldContext = worldContext;
			this.GameInstance = (gameInstance as BP_MainGameInstance_C);
			Singleton<LauncherLog>.Instance.Info("初始化Push", default(ReadOnlySpan<ValueTuple<string, object>>));
			HotPatchPushSdk.StartPush();
			Singleton<LauncherLog>.Instance.Info("结束Push", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<HotPatchKuroSdk>.Instance.Init();
			Singleton<LauncherAudio>.Instance.Init();
			HotPatchLoginReport.Report(HotPatchLoginReport.CreateHotPatchLog("device_startup", "success", null, null, null, null));
			this.HotFixSceneManager.SetupScene(worldContext);
			this.HotFixGameSettingManager.ApplyGameSettings();
			Singleton<LauncherLog>.Instance.Info("播放启动进入镜头(睁开眼睛)", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				Singleton<LauncherLog>.Instance.Info("CloudGame HotPatchEnterGame", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKuroCloudGameWrapper.SendDataToPipeBinary("HotPatchEnterGame");
			}
			this.HotFixSceneManager.PlayStartLaunchSeq();
			this.HotFixSceneManager.PlayBlackSeq(delegate
			{
				this.ProcessLineDiff(worldContext);
			});
		}

		// Token: 0x0602E4DD RID: 189661 RVA: 0x00ADDAF4 File Offset: 0x00ADBCF4
		public void StartLogin()
		{
			this.GameInstance.MountGamePak();
			Singleton<LauncherLog>.Instance.Info("Game Pak mounted, preloading Blueprint Types.", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroLauncherLibrary.ReloadShaderLibrary();
			UKuroLauncherLibrary.PreloadRequiredBp();
			if (!UKuroStaticLibrary.IsEditor(this.GameInstance))
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(this.GameInstance.GetWorld(), "DisableAllScreenMessages", null);
			}
			AActor.SetKuroNetMode(EKuroNetMode.KNM_Net);
			Singleton<LauncherLog>.Instance.Info("Launch success, ready to call main. Byebye launcher.", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<BaseConfigController>.Instance.LoadConfigVersion();
			Singleton<BaseConfigController>.Instance.LoadPatchBuildInfo(true);
			UWwiseExternalSourceStatics.InitExternalSourceConfigs();
			UPuertsBlueprintLibrary.SetEnableBlueprintBind(true);
			Main.DoMain(this.GameInstance);
		}

		// Token: 0x0602E4DE RID: 189662 RVA: 0x00ADDB9C File Offset: 0x00ADBD9C
		[NullableContext(2)]
		private void OnHotPatchFinish(bool updated, IDiffPatchProcedure procedure, bool? hasDiskChange = null)
		{
			UKismetSystemLibrary.ControlScreensaver(true);
			this.State = EHotPatchState.Finish;
			Singleton<LauncherLog>.Instance.Info("热更完成", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.HotFixSceneManager.Destroy();
			if (updated && procedure != null && procedure is OpenHarmonyDiffPatchProcedure)
			{
				(procedure as OpenHarmonyDiffPatchProcedure).CleanupPresetResources();
			}
			if (Singleton<Platform>.Instance.IsCloudGameRunningHotPatch())
			{
				AppUtil.QuitGameOnPatchSuccess("HotPatchFinish", hasDiskChange.GetValueOrDefault(updated));
				return;
			}
			this.StartLogin();
		}

		// Token: 0x0602E4DF RID: 189663 RVA: 0x00ADDC18 File Offset: 0x00ADBE18
		public UniTask ProcessLineDiff(UObject worldContext)
		{
			HotPatch.<ProcessLineDiff>d__10 <ProcessLineDiff>d__;
			<ProcessLineDiff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessLineDiff>d__.<>4__this = this;
			<ProcessLineDiff>d__.worldContext = worldContext;
			<ProcessLineDiff>d__.<>1__state = -1;
			<ProcessLineDiff>d__.<>t__builder.Start<HotPatch.<ProcessLineDiff>d__10>(ref <ProcessLineDiff>d__);
			return <ProcessLineDiff>d__.<>t__builder.Task;
		}

		// Token: 0x0602E4E0 RID: 189664 RVA: 0x00ADDC64 File Offset: 0x00ADBE64
		private unsafe int GetGLDriverVersion(int derfaultVersion, bool onlyAdreno)
		{
			string rhideviceName = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDeviceName();
			if (onlyAdreno && !rhideviceName.Contains("Adreno"))
			{
				return derfaultVersion;
			}
			string rhidriverVersion = UKuroRenderingRuntimeBPPluginBPLibrary.GetRHIDriverVersion();
			string[] array = rhidriverVersion.Split(new string[]
			{
				"V@"
			}, StringSplitOptions.None);
			string input = "";
			if (array.Length > 1)
			{
				input = array[1];
			}
			int num = derfaultVersion;
			MatchCollection matchCollection = Regex.Matches(input, "\\d+");
			if (matchCollection.Count > 0)
			{
				num = int.Parse(matchCollection[0].Value);
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DriverVersion", rhidriverVersion);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("glVersion", num);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return num;
		}

		// Token: 0x0602E4E1 RID: 189665 RVA: 0x00ADDD3C File Offset: 0x00ADBF3C
		[return: Nullable(0)]
		private UniTask<bool> CheckIosDeviceSupport(string platform, HotFixManager view, bool noHotPatchProcedure = false)
		{
			HotPatch.<CheckIosDeviceSupport>d__12 <CheckIosDeviceSupport>d__;
			<CheckIosDeviceSupport>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckIosDeviceSupport>d__.platform = platform;
			<CheckIosDeviceSupport>d__.view = view;
			<CheckIosDeviceSupport>d__.noHotPatchProcedure = noHotPatchProcedure;
			<CheckIosDeviceSupport>d__.<>1__state = -1;
			<CheckIosDeviceSupport>d__.<>t__builder.Start<HotPatch.<CheckIosDeviceSupport>d__12>(ref <CheckIosDeviceSupport>d__);
			return <CheckIosDeviceSupport>d__.<>t__builder.Task;
		}

		// Token: 0x0602E4E2 RID: 189666 RVA: 0x00ADDD90 File Offset: 0x00ADBF90
		private UniTask CheckGLDriver(HotFixManager view)
		{
			HotPatch.<CheckGLDriver>d__13 <CheckGLDriver>d__;
			<CheckGLDriver>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckGLDriver>d__.<>4__this = this;
			<CheckGLDriver>d__.view = view;
			<CheckGLDriver>d__.<>1__state = -1;
			<CheckGLDriver>d__.<>t__builder.Start<HotPatch.<CheckGLDriver>d__13>(ref <CheckGLDriver>d__);
			return <CheckGLDriver>d__.<>t__builder.Task;
		}

		// Token: 0x0602E4E3 RID: 189667 RVA: 0x00ADDDDC File Offset: 0x00ADBFDC
		private UniTask ShowCompileShadersProgress(HotFixManager view)
		{
			HotPatch.<ShowCompileShadersProgress>d__14 <ShowCompileShadersProgress>d__;
			<ShowCompileShadersProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowCompileShadersProgress>d__.view = view;
			<ShowCompileShadersProgress>d__.<>1__state = -1;
			<ShowCompileShadersProgress>d__.<>t__builder.Start<HotPatch.<ShowCompileShadersProgress>d__14>(ref <ShowCompileShadersProgress>d__);
			return <ShowCompileShadersProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602E4E4 RID: 189668 RVA: 0x00ADDE20 File Offset: 0x00ADC020
		public void ClearPatch()
		{
			Singleton<LauncherLog>.Instance.Info("开始清理补丁！", default(ReadOnlySpan<ValueTuple<string, object>>));
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = "clear_patch_resources";
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			ResPackageInfo.LauncherInfo.ClearRecord();
			ResPackageInfo.ResourceInfo.ClearRecord();
			foreach (ResPackageInfo resPackageInfo in ResPackageInfo.GetAllLanguageInfos())
			{
				resPackageInfo.ClearRecord();
			}
			foreach (KeyValuePair<string, ResPackageInfo> keyValuePair in ResPackageInfo.OptionalDownLoadInfo)
			{
				keyValuePair.Value.ClearRecord();
			}
			Singleton<LauncherLog>.Instance.Info("清理全量包,精简包选择记录", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LauncherStorageLib>.Instance.DeleteDeviceSaved(ELauncherStorageDeviceKey.SelectedMaxOrMinPackType);
			HotPatchLog hotPatchLog2 = new HotPatchLog();
			hotPatchLog2.s_step_id = "clear_patch_check";
			List<string> list = new List<string>();
			foreach (string item in UKuroStaticLibrary.GetFilesRecursive(UKuroLauncherLibrary.GameSavedDir() + "Resources/" + UKuroLauncherLibrary.GetAppVersion(), "*", true, false))
			{
				list.Add(item);
			}
			string text = LauncherJson.Stringify<List<string>>(list, null);
			hotPatchLog2.s_step_result = text;
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog2);
			string item2 = null;
			if (UKuroLauncherLibrary.Encrypt(text, ref item2))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "clear patch!";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ret", item2);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "clear patch!";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ret", text);
				instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			LauncherProcedure.Destroy();
			UKuroSqliteLibrary.CloseAllConnections();
			UKuroPrepareStatementLib.CloseAllConnection();
			UKuroGameBudgetBlueprintDefine.Clear();
			Action onClearPatch = HotPatch.OnClearPatch;
			if (onClearPatch != null)
			{
				onClearPatch();
			}
			HotFixSceneManager.StopHotPatchBgm();
			UKuroLauncherLibrary.WillClearPatchPaks();
			UGameplayStatics.OpenLevel(this.WorldContext, new FName("/Game/Aki/Map/Launch/Bootstrap"), true, "");
		}

		// Token: 0x0401A455 RID: 107605
		[Nullable(2)]
		[StaticVariableRuleIgnore]
		public static Action OnClearPatch;

		// Token: 0x0401A456 RID: 107606
		[Nullable(2)]
		private UObject WorldContext;

		// Token: 0x0401A457 RID: 107607
		[Nullable(2)]
		private BP_MainGameInstance_C GameInstance;

		// Token: 0x0401A458 RID: 107608
		protected EHotPatchState State;

		// Token: 0x0401A459 RID: 107609
		private readonly AppPathMisc PathModule = new AppPathMisc();

		// Token: 0x0401A45A RID: 107610
		public readonly HotFixSceneManager HotFixSceneManager = new HotFixSceneManager();

		// Token: 0x0401A45B RID: 107611
		private readonly HotFixGameSettingManager HotFixGameSettingManager = new HotFixGameSettingManager();
	}
}
