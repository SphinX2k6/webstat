using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

// Token: 0x02000E88 RID: 3720
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GameSettingsController : ControllerBase<GameSettingsController>
{
	// Token: 0x06005AD1 RID: 23249 RVA: 0x00164790 File Offset: 0x00162990
	protected override bool OnInit()
	{
		Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.ZJF, "GameSettingsController-OnInit", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.AddEvents();
		this.KuroRenderQualityVolumeManager = (UKuroRenderingRuntimeBPPluginBPLibrary.GetEngineSubsystem(UKuroRenderQualityVolumeManager.StaticClass()) as UKuroRenderQualityVolumeManager);
		this.AddKuroRenderQualityVolumeEvents();
		return true;
	}

	// Token: 0x06005AD2 RID: 23250 RVA: 0x001647E0 File Offset: 0x001629E0
	protected override bool OnClear()
	{
		this.RemoveEvents();
		this.RemoveKuroRenderQualityVolumeEvents();
		return true;
	}

	// Token: 0x06005AD3 RID: 23251 RVA: 0x001647F0 File Offset: 0x001629F0
	private unsafe void KuroRenderQualityVolumeReApplyGameSettings()
	{
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NPCDENSITY, EGameSettingsApplyReason.AnyTime, false);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NVIDIADLSSQUALITY, EGameSettingsApplyReason.AnyTime, false);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NIAGARAQUALITY, EGameSettingsApplyReason.AnyTime, false);
		if (Singleton<Info>.Instance.IsWindowsPlatform())
		{
			if (((this.KuroRenderQualityLocalIndex >= 80 && this.KuroRenderQualityLocalIndex < 100) || (this.KuroRenderQualityLocalIndex >= 110 && this.KuroRenderQualityLocalIndex < 120)) && UKismetSystemLibrary.GetConsoleVariableIntValue("r.RayTracing.Enable") == 0)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "UBInstancing.Enabled 0", null);
			}
			else
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "UBInstancing.Enabled 1", null);
			}
		}
		if (Singleton<GameSettingsDeviceRender>.Instance.DeviceVideoGbRam <= 12 && this.KuroRenderQualityLocalIndex >= 70 && this.KuroRenderQualityLocalIndex < 90)
		{
			float consoleVariableFloatValue = UKismetSystemLibrary.GetConsoleVariableFloatValue("wp.Runtime.LoadingRangeScale");
			if (consoleVariableFloatValue > 1f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Render;
				ELogAuthor author = ELogAuthor.LQX;
				string message = "[局部性能盒子-TS] 低显存限制流送系数";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OldValue:", consoleVariableFloatValue);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Value:", 1);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				UKuroStaticLibrary.SetConsoleVariableWithCurrentPriority_Float("wp.Runtime.LoadingRangeScale", 1f);
			}
		}
		if (Singleton<Info>.Instance.IsWindowsPlatform() && Singleton<GameSettingsDeviceRender>.Instance.DeviceVideoGbRam >= 7 && UKismetSystemLibrary.GetConsoleVariableIntValue("sg.TextureQuality") == 3)
		{
			if (this.KuroRenderQualityLocalIndex >= 100 && this.KuroRenderQualityLocalIndex < 110)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.PoolSize 1350", null);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Render;
				ELogAuthor author2 = ELogAuthor.LQX;
				string message2 = "[局部性能盒子-TS] 高显存提升池子";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PoolSize:", 1350);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.PoolSize 1000", null);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Render;
			ELogAuthor author3 = ELogAuthor.LQX;
			string message3 = "[局部性能盒子-TS] 高显存恢复池子";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PoolSize:", 1000);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
	}

	// Token: 0x06005AD4 RID: 23252 RVA: 0x001649FC File Offset: 0x00162BFC
	private void AddKuroRenderQualityVolumeEvents()
	{
		Action callback = delegate()
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "[局部性能盒子-TS] 进入盒子", default(ReadOnlySpan<ValueTuple<string, object>>));
		};
		this.KuroRenderQualityVolumeManager.OnEnterVolumeBlueprintEvent.Add(callback);
		Action<int> callback2 = delegate(int localIndex)
		{
			this.KuroRenderQualityLocalIndex = localIndex;
			this.KuroRenderQualityVolumeReApplyGameSettings();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.LQX;
			string message = "[局部性能盒子-TS] 盒子应用索引";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LocalIndex:", localIndex);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		};
		this.KuroRenderQualityVolumeManager.OnApplyKuroRenderLocalSettingsBlueprintEvent.Add(callback2);
		Action callback3 = delegate()
		{
			this.KuroRenderQualityLocalIndex = -1;
			this.KuroRenderQualityVolumeReApplyGameSettings();
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LQX, "[局部性能盒子-TS] 离开盒子", default(ReadOnlySpan<ValueTuple<string, object>>));
		};
		this.KuroRenderQualityVolumeManager.OnLeaveVolumeBlueprintEvent.Add(callback3);
	}

	// Token: 0x06005AD5 RID: 23253 RVA: 0x00164A76 File Offset: 0x00162C76
	private void RemoveKuroRenderQualityVolumeEvents()
	{
		this.KuroRenderQualityVolumeManager.OnEnterVolumeBlueprintEvent.Clear();
		this.KuroRenderQualityVolumeManager.OnApplyKuroRenderLocalSettingsBlueprintEvent.Clear();
		this.KuroRenderQualityVolumeManager.OnLeaveVolumeBlueprintEvent.Clear();
	}

	// Token: 0x06005AD6 RID: 23254 RVA: 0x00164AA8 File Offset: 0x00162CA8
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnStartLoadingState, new Action(this.OnOpenLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnOpenLevel));
		Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSubLevelAdded, new Action(this.OnSubLevelAdded));
		Singleton<EventSystem>.Instance.Add(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnBeforeOpenLoginView;
		Action handle;
		if ((handle = GameSettingsController.<>O.<0>__OnBeforeOpenLoginView) == null)
		{
			handle = (GameSettingsController.<>O.<0>__OnBeforeOpenLoginView = new Action(GameSettingsController.OnBeforeOpenLoginView));
		}
		instance.Add(name, handle);
		Singleton<Application>.Instance.AddWindowActivationHandler(new Action<bool>(this.OnWindowActive));
	}

	// Token: 0x06005AD7 RID: 23255 RVA: 0x00164B84 File Offset: 0x00162D84
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnStartLoadingState, new Action(this.OnOpenLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnOpenLevel));
		Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSubLevelAdded, new Action(this.OnSubLevelAdded));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnBeforeOpenLoginView;
		Action handle;
		if ((handle = GameSettingsController.<>O.<0>__OnBeforeOpenLoginView) == null)
		{
			handle = (GameSettingsController.<>O.<0>__OnBeforeOpenLoginView = new Action(GameSettingsController.OnBeforeOpenLoginView));
		}
		instance.Remove(name, handle);
		Singleton<Application>.Instance.RemoveWindowActivationHandler(new Action<bool>(this.OnWindowActive));
	}

	// Token: 0x06005AD8 RID: 23256 RVA: 0x00164C60 File Offset: 0x00162E60
	private void OnOpenLoading()
	{
		if (Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading)
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.WZ, "游戏设置已经初始化应用过", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.ZJF, "初始化-应用设置参数1111", default(ReadOnlySpan<ValueTuple<string, object>>));
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.FullyLoadUsedTextures 0", null);
		if (UKuroStaticLibrary.IsLowMemoryDevice())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.RenderAssetMinKuroBoostFactor 0.1", null);
		}
		if (Singleton<Platform>.Instance.IsAndroidPlatform())
		{
			string deviceCPU = UKuroStaticLibrary.GetDeviceCPU();
			if (deviceCPU.StartsWith("mt68", StringComparison.OrdinalIgnoreCase) || deviceCPU.StartsWith("mt69", StringComparison.OrdinalIgnoreCase))
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.CLV.RuntimeSeamlessLODBlend 0", null);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Render;
				ELogAuthor author = ELogAuthor.LQX;
				string message = "天玑设备-关闭CLV无缝LOD混合";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DeviceCPU:", deviceCPU);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.ViewDistanceQuality 2", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.AntiAliasingQuality 2", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.PostProcessQuality 2", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.TextureQuality 2", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.EffectsQuality 3", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.FoliageQuality 2", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.CapsuleKuroAO 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.LandscapeReverseLODScaleFactor 0", null);
		}
		Singleton<GameSettingsManager>.Instance.HandleInitDataOnOpenLoading();
		Singleton<EventSystem>.Instance.Emit(EEventName.AfterGameSettingsAppliedOnOpenLoading);
		if (Singleton<Info>.Instance.IsPlayInEditor && false)
		{
			string command = "wp.Runtime.OverrideMultipleRuntimeGridNames Grid_Near&Grid_Middle&Grid_Middle_Far&Grid_Far&Grid_SuperFar&Grid_SSuperFar&Grid_HLOD_Small&Grid_HLOD_Middle&Grid_HLOD&Grid_HLOD_Volume_Small&Grid_HLOD_Volume_Middle&Grid_HLOD_Volume&Grid_Water&Grid_Impostor&Grid_ISM_Near&Grid_ISM_Middle&Grid_ISM_Far&Grid_ISM_SuperFar&Grid_Foliage_Near&Grid_Foliage_Grass&Grid_Foliage_Middle&Grid_Foliage_Far&Grid_ReverseFar&Grid_SSuperFarReverse&Grid_EnclosedSpaceNear&Grid_EnclosedSpaceMiddle&Grid_EnclosedSpaceFar&Grid_EnclosedSpaceSuperFar&Grid_EnclosedSpaceSSuperFar";
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
			command = "wp.Runtime.OverrideMultipleRuntimeGridLoadingRangeValues 50&80&180&100&450&1800&150&200&300&150&200&300&480&250&50&80&100&150&40&80&100&100&300&1800&50&80&100&450&600";
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
			command = "r.Kuro.SkeletalMesh.LODDistanceScale 1.0";
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
			command = "r.Kuro.Foliage.GrassCullDistanceMax 3000";
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
			command = "r.Kuro.MaterialDesktopQualityShoulderRender 0";
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
			command = "r.Kuro.GlobalPointCloudStreamEnabled 0";
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, command, null);
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.XMC, "Editor: TopSpeedMode is on.", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		Singleton<GameSettingsDeviceRender>.Instance.CancelAllPerformanceLimit();
		Singleton<GameSettingsManager>.Instance.IsGameSettingsAppliedOnOpenLoading = true;
	}

	// Token: 0x06005AD9 RID: 23257 RVA: 0x00164E9C File Offset: 0x0016309C
	private void OnOpenLevel()
	{
		if (!ModelBase<GameModeModel>.Instance.UseWorldPartition)
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.ZYT, "进入副本-调整渲染参数", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Mobile.EnableKuroSpotlightsShadow 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FogVisibilityCulling.Enable 0", null);
			}
			Singleton<GameSettingsLevelRender>.Instance.SetLevelRenderSettings();
			ALandscapeProxy.SetKuroLandscapeFOVFactor(0f);
			UStreamableRenderAsset.SetKuroStreamingLevelState(1);
			this.RemoveTimer();
			this.AddTimer();
		}
		else
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.ZYT, "进入大世界-调整渲染参数", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Mobile.EnableKuroSpotlightsShadow 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FogVisibilityCulling.Enable 1", null);
			}
			ALandscapeProxy.SetKuroLandscapeFOVFactor(-1f);
			UStreamableRenderAsset.SetKuroStreamingLevelState(0);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CacheWholeSceneShadows 1", null);
			this.RemoveTimer();
		}
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.SCENEAO, EGameSettingsApplyReason.WhenLoading, true);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.VegetationDither, EGameSettingsApplyReason.WhenLoading, true);
		GameSettingsUtils.ReApplyMaterialQualityLevel(null);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.GamepadLeftStickDeadZone, EGameSettingsApplyReason.WhenLoading, false);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.GamepadRightStickDeadZone, EGameSettingsApplyReason.WhenLoading, false);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.GamepadLeftTriggerDeadZone, EGameSettingsApplyReason.WhenLoading, false);
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.GamepadRightTriggerDeadZone, EGameSettingsApplyReason.WhenLoading, false);
	}

	// Token: 0x06005ADA RID: 23258 RVA: 0x0016500C File Offset: 0x0016320C
	private void OnClearWorld()
	{
		if (!ModelBase<GameModeModel>.Instance.UseWorldPartition)
		{
			Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.ZYT, "退出副本-调整渲染参数", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<GameSettingsLevelRender>.Instance.RevertLevelRenderSetting();
			ALandscapeProxy.SetKuroLandscapeFOVFactor(-1f);
			UStreamableRenderAsset.SetKuroStreamingLevelState(0);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CacheWholeSceneShadows 1", null);
			this.RemoveTimer();
		}
	}

	// Token: 0x06005ADB RID: 23259 RVA: 0x00165071 File Offset: 0x00163271
	private void OnSubLevelAdded()
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CacheWholeSceneShadows 0", null);
		this.RemoveTimer();
		this.AddTimer();
	}

	// Token: 0x06005ADC RID: 23260 RVA: 0x0016508F File Offset: 0x0016328F
	private void OnTimer(float _)
	{
		this.TimerId = null;
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.CacheWholeSceneShadows 1", null);
	}

	// Token: 0x06005ADD RID: 23261 RVA: 0x001650A8 File Offset: 0x001632A8
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		if (last == EInputControllerMainType.Gamepad || now == EInputControllerMainType.Gamepad)
		{
			GameSettingsUtils.RefreshViewRevertState(now);
		}
	}

	// Token: 0x06005ADE RID: 23262 RVA: 0x001650B8 File Offset: 0x001632B8
	private void OnWindowActive(bool bIsActive)
	{
		if (Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.BackendVolume, 0, true) == 1)
		{
			if (bIsActive)
			{
				Singleton<AudioSystem>.Instance.SetState("master_bus_by_focus_state", "none", true);
				return;
			}
			Singleton<AudioSystem>.Instance.SetState("master_bus_by_focus_state", "mute_all_sound", true);
		}
	}

	// Token: 0x06005ADF RID: 23263 RVA: 0x00165107 File Offset: 0x00163307
	public void OnGameUserSettingsUINeedsUpdate()
	{
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			this.OnUEGameUserSettingsUpdate();
		}, null, null);
	}

	// Token: 0x06005AE0 RID: 23264 RVA: 0x00165124 File Offset: 0x00163324
	public void OnUEGameUserSettingsUpdate()
	{
		UGameUserSettings gameUserSettings = UGameUserSettings.GetGameUserSettings();
		if (gameUserSettings == null)
		{
			return;
		}
		int num = ((gameUserSettings.GetFullscreenMode() == EWindowMode.Windowed) > false) ? 1 : 0;
		int? num2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.DISPLAYMODE, true, true);
		int num3 = num;
		if (!(num2.GetValueOrDefault() == num3 & num2 != null))
		{
			Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.DISPLAYMODE, num, EGameSettingsApplyReason.AnyTime);
		}
		int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.RESOLUTION, true, true);
		int resolutionIndexByList = Singleton<GameSettingsDeviceRender>.Instance.GetResolutionIndexByList(gameUserSettings.GetScreenResolution());
		num2 = currentValue;
		num3 = resolutionIndexByList;
		if (!(num2.GetValueOrDefault() == num3 & num2 != null))
		{
			Singleton<GameSettingsManager>.Instance.HandleValueChange(EFunction.RESOLUTION, resolutionIndexByList, EGameSettingsApplyReason.AnyTime);
		}
	}

	// Token: 0x06005AE1 RID: 23265 RVA: 0x001651C7 File Offset: 0x001633C7
	private void AddTimer()
	{
		this.TimerId = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnTimer), 1000f, null, null, true, 1f);
	}

	// Token: 0x06005AE2 RID: 23266 RVA: 0x001651F2 File Offset: 0x001633F2
	private void RemoveTimer()
	{
		if (this.TimerId != null)
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			}
			this.TimerId = null;
		}
	}

	// Token: 0x06005AE3 RID: 23267 RVA: 0x00165228 File Offset: 0x00163428
	private static void OnBeforeOpenLoginView()
	{
		Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "在打开登录界面之前-执行预设置逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (Singleton<Platform>.Instance.IsCloudGame())
		{
			Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "在云游戏平台下，执行预设置60FPS", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<GameSettingsDeviceRender>.Instance.ApplyFrameRate(60);
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.GameSettings, ELogAuthor.TZJ, "在非云游戏平台下，执行预设置FPS", default(ReadOnlySpan<ValueTuple<string, object>>));
		GameSettingsUtils.ApplyHighestFps(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.HIGHESTFPS, 0, true));
	}

	// Token: 0x04002A51 RID: 10833
	private TimerHandle TimerId;

	// Token: 0x04002A52 RID: 10834
	private UKuroRenderQualityVolumeManager KuroRenderQualityVolumeManager;

	// Token: 0x04002A53 RID: 10835
	public int KuroRenderQualityLocalIndex = -1;

	// Token: 0x020072C8 RID: 29384
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027C97 RID: 162967
		[Nullable(0)]
		public static Action <0>__OnBeforeOpenLoginView;
	}
}
