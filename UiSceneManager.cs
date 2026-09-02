using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Kpose.Blueprint;
using AkiClient.Game.Aki.Map.UISceneLevel.UI_Scene.UI_BP;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C5D RID: 11357
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiSceneManager : Singleton<UiSceneManager>, ITickable
{
	// Token: 0x06016C5F RID: 93279 RVA: 0x006510C4 File Offset: 0x0064F2C4
	public void Initialize()
	{
		GlobalData.SetUiState(EKuroUI3DState.NotLoaded);
		this.CurUiSceneId = string.Empty;
		this.CurUiScenePathSet.Clear();
		Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleAfterResetToBattleView, new Action(this.ForceCloseUiSceneImmediately));
	}

	// Token: 0x06016C60 RID: 93280 RVA: 0x00651100 File Offset: 0x0064F300
	private unsafe void UnloadLastAndRecordCurrentUiScene(string sceneId)
	{
		UKuroUiSceneSystem kuroUiSceneSystem = UKuroUiSceneSystem.GetKuroUiSceneSystem(GlobalData.World);
		UiSceneCsv? sceneConfig = ConfigBase<UiViewConfig>.Instance.GetSceneConfig(sceneId);
		if (sceneConfig == null)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>(sceneConfig.Value.SceneList());
		foreach (string text in this.CurUiScenePathSet)
		{
			if (!hashSet.Contains(text))
			{
				kuroUiSceneSystem.UnloadUiScene(text);
			}
		}
		this.CurUiScenePathSet = hashSet;
		this.GlobalGiMainScene = sceneConfig.Value.MainScene;
		kuroUiSceneSystem.CurrentShowScenePath = this.GlobalGiMainScene;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiSceneManager;
		ELogAuthor author = ELogAuthor.LYX;
		string message = "当前应用到GlobalGI的场景路径";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("sceneId", sceneId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GlobalGIMainScene", this.GlobalGiMainScene);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06016C61 RID: 93281 RVA: 0x0065121C File Offset: 0x0064F41C
	private void PreloadAllUiScene()
	{
		UKuroUiSceneSystem kuroUiSceneSystem = UKuroUiSceneSystem.GetKuroUiSceneSystem(GlobalData.World);
		FVectorDouble kuroUiSceneLoadOffset = ControllerBase<RenderModuleController>.Instance.GetKuroUiSceneLoadOffset();
		foreach (string scenePath in this.CurUiScenePathSet)
		{
			kuroUiSceneSystem.PreloadUiScene(scenePath, kuroUiSceneLoadOffset);
		}
	}

	// Token: 0x06016C62 RID: 93282 RVA: 0x0065128C File Offset: 0x0064F48C
	private void EndAllUiSceneRendering()
	{
		UKuroUiSceneSystem kuroUiSceneSystem = UKuroUiSceneSystem.GetKuroUiSceneSystem(GlobalData.World);
		foreach (string text in this.CurUiScenePathSet)
		{
			if (kuroUiSceneSystem.AllStreamingLevelInfo.Get(text) == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiSceneManager;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "退出3d ui 关卡，关卡不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ScenePath", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
		}
		kuroUiSceneSystem.EndUiSceneRendering();
		this.CurUiScenePathSet.Clear();
		this.GlobalGiMainScene = string.Empty;
	}

	// Token: 0x06016C63 RID: 93283 RVA: 0x00651338 File Offset: 0x0064F538
	private void StartAllUiSceneRendering()
	{
		UKuroUiSceneSystem kuroUiSceneSystem = UKuroUiSceneSystem.GetKuroUiSceneSystem(GlobalData.World);
		foreach (string text in this.CurUiScenePathSet)
		{
			if (kuroUiSceneSystem.AllStreamingLevelInfo.Get(text) == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiSceneManager;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "渲染3d ui 场景，关卡不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ScenePath", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
		}
		kuroUiSceneSystem.StartUiSceneRendering();
	}

	// Token: 0x06016C64 RID: 93284 RVA: 0x006513CC File Offset: 0x0064F5CC
	private bool CheckOpenUiScene(string sceneId)
	{
		if (GlobalData.World == null)
		{
			return false;
		}
		if (GlobalData.IsUiSceneLoading)
		{
			return false;
		}
		if (ConfigBase<UiViewConfig>.Instance.GetScenePathList(sceneId).Length == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiSceneManager;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "检查ui场景id配置，场景列表不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sceneId", sceneId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x06016C65 RID: 93285 RVA: 0x00651424 File Offset: 0x0064F624
	private void SetKuroUiSceneLoadOffset(string sceneId)
	{
		UiSceneCsv? sceneConfig = ConfigBase<UiViewConfig>.Instance.GetSceneConfig(sceneId);
		if (sceneConfig == null)
		{
			return;
		}
		FVectorDouble kuroUiSceneLoadOffset = new FVectorDouble((double)sceneConfig.Value.WorldOffset.Value.X, (double)sceneConfig.Value.WorldOffset.Value.Y, (double)sceneConfig.Value.WorldOffset.Value.Z);
		ControllerBase<RenderModuleController>.Instance.SetKuroUiSceneLoadOffset(kuroUiSceneLoadOffset);
	}

	// Token: 0x06016C66 RID: 93286 RVA: 0x006514BC File Offset: 0x0064F6BC
	private bool DisableClvForUiScene(string sceneId)
	{
		if (!this.DisableClvUiSceneIds.Contains(sceneId))
		{
			return false;
		}
		if (this.LastClvEnableValue == null)
		{
			this.LastClvEnableValue = new int?(UKismetSystemLibrary.GetConsoleVariableIntValue("r.clv.enable"));
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.clv.enable 0", null);
		return true;
	}

	// Token: 0x06016C67 RID: 93287 RVA: 0x0065150C File Offset: 0x0064F70C
	private void RestoreClvEnableValue()
	{
		if (this.LastClvEnableValue == null)
		{
			return;
		}
		UObject world = GlobalData.World;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
		defaultInterpolatedStringHandler.AppendLiteral("r.clv.enable ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.LastClvEnableValue.Value);
		UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		this.LastClvEnableValue = null;
	}

	// Token: 0x06016C68 RID: 93288 RVA: 0x00651570 File Offset: 0x0064F770
	public bool OpenUiScene(string sceneId, [Nullable(2)] Action successCallBack = null)
	{
		if (!this.CheckOpenUiScene(sceneId))
		{
			return false;
		}
		if (this.CurUiSceneId == sceneId)
		{
			if (successCallBack != null)
			{
				successCallBack();
			}
			return true;
		}
		bool flag = this.DisableClvForUiScene(sceneId);
		this.SetKuroUiSceneLoadOffset(sceneId);
		FVectorDouble kuroUiSceneLoadOffset = ControllerBase<RenderModuleController>.Instance.GetKuroUiSceneLoadOffset();
		this.UnloadLastAndRecordCurrentUiScene(sceneId);
		if (!flag)
		{
			this.RestoreClvEnableValue();
		}
		this.PreloadAllUiScene();
		this.HandleEnterUiSceneParams();
		this.CurUiSceneId = sceneId;
		FTransformDouble value = ControllerBase<RenderModuleController>.Instance.UiSceneOffsetTransform.Value;
		value.SetLocation(kuroUiSceneLoadOffset);
		ControllerBase<RenderModuleController>.Instance.UiSceneOffsetTransform = new FTransformDouble?(value);
		ControllerBase<RenderModuleController>.Instance.DebugUiSceneLoadOffset = new FVectorDouble?(kuroUiSceneLoadOffset);
		ControllerBase<RenderModuleController>.Instance.DebugInUiSceneRendering = true;
		this.LoadSuccessFunction = successCallBack;
		GlobalData.SetUiState(EKuroUI3DState.Loading);
		Singleton<EventSystem>.Instance.Emit(EEventName.UiSceneStartLoad);
		return true;
	}

	// Token: 0x06016C69 RID: 93289 RVA: 0x0065163C File Offset: 0x0064F83C
	public void SwitchUiScene(string sceneId, [Nullable(2)] Action<bool> callBack = null)
	{
		this.SwitchUiSceneFunction = callBack;
		if (!this.OpenUiScene(sceneId, delegate
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiSceneManager;
			ELogAuthor author2 = ELogAuthor.LZK;
			string message2 = "切换3d ui场景成功";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("sceneId", sceneId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Action<bool> switchUiSceneFunction2 = this.SwitchUiSceneFunction;
			if (switchUiSceneFunction2 != null)
			{
				switchUiSceneFunction2(true);
			}
			this.SwitchUiSceneFunction = null;
		}))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiSceneManager;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "切换3d ui场景失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sceneId", sceneId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<bool> switchUiSceneFunction = this.SwitchUiSceneFunction;
			if (switchUiSceneFunction != null)
			{
				switchUiSceneFunction(false);
			}
			this.SwitchUiSceneFunction = null;
		}
	}

	// Token: 0x06016C6A RID: 93290 RVA: 0x006516C4 File Offset: 0x0064F8C4
	public UniTask SwitchUiSceneWithBlackScreen(string sceneId, [Nullable(2)] Func<bool, UniTask> callBack = null)
	{
		UiSceneManager.<SwitchUiSceneWithBlackScreen>d__18 <SwitchUiSceneWithBlackScreen>d__;
		<SwitchUiSceneWithBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SwitchUiSceneWithBlackScreen>d__.<>4__this = this;
		<SwitchUiSceneWithBlackScreen>d__.sceneId = sceneId;
		<SwitchUiSceneWithBlackScreen>d__.callBack = callBack;
		<SwitchUiSceneWithBlackScreen>d__.<>1__state = -1;
		<SwitchUiSceneWithBlackScreen>d__.<>t__builder.Start<UiSceneManager.<SwitchUiSceneWithBlackScreen>d__18>(ref <SwitchUiSceneWithBlackScreen>d__);
		return <SwitchUiSceneWithBlackScreen>d__.<>t__builder.Task;
	}

	// Token: 0x06016C6B RID: 93291 RVA: 0x00651717 File Offset: 0x0064F917
	public void CloseUiScene()
	{
		this.ForceHandleScene();
	}

	// Token: 0x06016C6C RID: 93292 RVA: 0x0065171F File Offset: 0x0064F91F
	private void ForceCloseUiSceneImmediately()
	{
		this.ForceHandleScene();
	}

	// Token: 0x06016C6D RID: 93293 RVA: 0x00651728 File Offset: 0x0064F928
	private void ForceHandleScene()
	{
		if (StringUtils.IsEmpty(this.CurUiSceneId))
		{
			return;
		}
		this.CurUiSceneId = string.Empty;
		if (GlobalData.World != null)
		{
			this.HandleExitUiSceneParams();
			ControllerBase<RenderModuleController>.Instance.DebugInUiSceneRendering = false;
			ControllerBase<RenderModuleController>.Instance.DebugStartShowingUiSceneRendering = false;
			this.EndAllUiSceneRendering();
			this.RestoreClvEnableValue();
			GlobalData.SetUiState(EKuroUI3DState.NotLoaded);
		}
		if (this.SwitchUiSceneFunction != null)
		{
			this.SwitchUiSceneFunction(false);
			this.SwitchUiSceneFunction = null;
		}
		this.LoadSuccessFunction = null;
		if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.MOBILERESOLUTION, EGameSettingsApplyReason.AnyTime, true);
			ULGUIBPLibrary.FreeUnusedResourcesInRenderTargetPool();
		}
	}

	// Token: 0x06016C6E RID: 93294 RVA: 0x006517C8 File Offset: 0x0064F9C8
	public void Tick(float delta)
	{
		if (!GlobalData.IsUiSceneLoading)
		{
			return;
		}
		EKuroUiSceneLoadingState allUiSceneLoadingState = UKuroUiSceneSystem.GetKuroUiSceneSystem(GlobalData.World).GetAllUiSceneLoadingState();
		if (allUiSceneLoadingState == EKuroUiSceneLoadingState.NotLoaded || allUiSceneLoadingState == EKuroUiSceneLoadingState.Loading)
		{
			GlobalData.SetUiState(EKuroUI3DState.Loading);
			return;
		}
		if (allUiSceneLoadingState == EKuroUiSceneLoadingState.LoadedNotVisible && !ControllerBase<RenderModuleController>.Instance.DebugStartShowingUiSceneRendering)
		{
			this.StartAllUiSceneRendering();
			ControllerBase<RenderModuleController>.Instance.DebugStartShowingUiSceneRendering = true;
			GlobalData.SetUiState(EKuroUI3DState.Loading);
			return;
		}
		if (allUiSceneLoadingState == EKuroUiSceneLoadingState.LoadedAndVisible)
		{
			GlobalData.SetUiState(EKuroUI3DState.Loaded);
			Action loadSuccessFunction = this.LoadSuccessFunction;
			if (loadSuccessFunction != null)
			{
				loadSuccessFunction();
			}
			if (!Singleton<Info>.Instance.IsPcOrGamepadPlatform())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.TemporalAA.Sharpness 1.0", null);
				if (Singleton<GameSettingsDeviceRender>.Instance.IsAndroidPlatformLowest())
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 80", null);
				}
				else
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenPercentage 100", null);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.UiSceneLoaded);
			ControllerBase<RenderModuleController>.Instance.DebugStartShowingUiSceneRendering = false;
			return;
		}
		GlobalData.SetUiState(EKuroUI3DState.Loading);
	}

	// Token: 0x06016C6F RID: 93295 RVA: 0x006518A8 File Offset: 0x0064FAA8
	private void HandleEnterUiSceneParams()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = true;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = false;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = true;
		}
	}

	// Token: 0x06016C70 RID: 93296 RVA: 0x00651900 File Offset: 0x0064FB00
	private void HandleExitUiSceneParams()
	{
		UKuroGISystem kuroGISystem = UKuroGISystem.GetKuroGISystem(GlobalData.World);
		if (kuroGISystem == null)
		{
			return;
		}
		BP_GlobalGI_C bp_GlobalGI_C = kuroGISystem.GetKuroGlobalGIActor() as BP_GlobalGI_C;
		bp_GlobalGI_C.UINeedLerpData = false;
		if (bp_GlobalGI_C.GlobalUiScenePostProcess != null)
		{
			bp_GlobalGI_C.GlobalUiScenePostProcess.bEnabled = true;
		}
		if (bp_GlobalGI_C.GlobalPostProcessVolume != null)
		{
			bp_GlobalGI_C.GlobalPostProcessVolume.bIsUISceneRendering = false;
		}
	}

	// Token: 0x06016C71 RID: 93297 RVA: 0x00651958 File Offset: 0x0064FB58
	private SkeletalObserverHandle SpawnSkeletalObserverHandle(EUiModelUseWay useWay)
	{
		if (GlobalData.World == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiSceneManager, ELogAuthor.TL, "SpawnSkeletalObserverHandle failed, GlobalData.World is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return SkeletalObserverManager.NewSkeletalObserver(useWay);
	}

	// Token: 0x06016C72 RID: 93298 RVA: 0x00651990 File Offset: 0x0064FB90
	public SkeletalObserverHandle InitWeaponObserver(bool needMeshStreaming = false)
	{
		EUiModelUseWay useWay = needMeshStreaming ? EUiModelUseWay.WeaponWithLoadingIcon : EUiModelUseWay.WeaponInWeaponView;
		SkeletalObserverHandle skeletalObserverHandle = this.SpawnSkeletalObserverHandle(useWay);
		this.WeaponObserverStack.Push(skeletalObserverHandle);
		return skeletalObserverHandle;
	}

	// Token: 0x06016C73 RID: 93299 RVA: 0x006519BC File Offset: 0x0064FBBC
	public SkeletalObserverHandle GetWeaponObserver()
	{
		if (this.WeaponObserverStack.Empty)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[WeaponObserverStack]为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.WeaponObserverStack.Peek();
	}

	// Token: 0x06016C74 RID: 93300 RVA: 0x006519FF File Offset: 0x0064FBFF
	public void DestroyWeaponObserver(SkeletalObserverHandle weaponObserver)
	{
		if (this.WeaponObserverStack.Empty)
		{
			return;
		}
		this.WeaponObserverStack.Delete(weaponObserver);
		SkeletalObserverManager.DestroySkeletalObserver(weaponObserver);
	}

	// Token: 0x06016C75 RID: 93301 RVA: 0x00651A24 File Offset: 0x0064FC24
	public void DestroyAllWeaponObserver()
	{
		while (!this.WeaponObserverStack.Empty)
		{
			SkeletalObserverHandle weaponObserver = this.WeaponObserverStack.Pop();
			this.DestroyWeaponObserver(weaponObserver);
		}
	}

	// Token: 0x06016C76 RID: 93302 RVA: 0x00651A54 File Offset: 0x0064FC54
	public SkeletalObserverHandle InitWeaponScabbardObserver()
	{
		SkeletalObserverHandle skeletalObserverHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.WeaponInWeaponView);
		this.WeaponScabbardStack.Push(skeletalObserverHandle);
		return skeletalObserverHandle;
	}

	// Token: 0x06016C77 RID: 93303 RVA: 0x00651A78 File Offset: 0x0064FC78
	public SkeletalObserverHandle GetWeaponScabbardObserver()
	{
		if (this.WeaponScabbardStack.Empty)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[WeaponScabbardStack]为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.WeaponScabbardStack.Peek();
	}

	// Token: 0x06016C78 RID: 93304 RVA: 0x00651ABB File Offset: 0x0064FCBB
	public void DestroyWeaponScabbardObserver(SkeletalObserverHandle weaponScabbard)
	{
		if (this.WeaponScabbardStack.Empty)
		{
			return;
		}
		this.WeaponScabbardStack.Delete(weaponScabbard);
		SkeletalObserverManager.DestroySkeletalObserver(weaponScabbard);
	}

	// Token: 0x06016C79 RID: 93305 RVA: 0x00651AE0 File Offset: 0x0064FCE0
	public void DestroyAllWeaponScabbardObserver()
	{
		while (!this.WeaponScabbardStack.Empty)
		{
			SkeletalObserverHandle weaponScabbard = this.WeaponScabbardStack.Pop();
			this.DestroyWeaponScabbardObserver(weaponScabbard);
		}
	}

	// Token: 0x06016C7A RID: 93306 RVA: 0x00651B10 File Offset: 0x0064FD10
	public void InitPhantomObserver()
	{
		if (this.PhantomObserver != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[PhantomObserver]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PhantomObserver = this.SpawnSkeletalObserverHandle(EUiModelUseWay.VisionInRoleView);
	}

	// Token: 0x06016C7B RID: 93307 RVA: 0x00651B50 File Offset: 0x0064FD50
	public SkeletalObserverHandle GetPhantomObserver()
	{
		if (this.PhantomObserver == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[PhantomObserver]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.PhantomObserver;
	}

	// Token: 0x06016C7C RID: 93308 RVA: 0x00651B89 File Offset: 0x0064FD89
	public void DestroyPhantomObserver()
	{
		if (this.PhantomObserver == null)
		{
			return;
		}
		SkeletalObserverManager.DestroySkeletalObserver(this.PhantomObserver);
		this.PhantomObserver = null;
	}

	// Token: 0x06016C7D RID: 93309 RVA: 0x00651BA6 File Offset: 0x0064FDA6
	public SkeletalObserverHandle InitHuluObserver()
	{
		this.HuluObserver = Singleton<UiSceneManager>.Instance.SpawnSkeletalObserverHandle(EUiModelUseWay.HuluInSkinView);
		return this.HuluObserver;
	}

	// Token: 0x06016C7E RID: 93310 RVA: 0x00651BC0 File Offset: 0x0064FDC0
	[NullableContext(2)]
	public SkeletalObserverHandle GetHuluObserver()
	{
		if (this.HuluObserver == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[HuluObserver]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.HuluObserver;
	}

	// Token: 0x06016C7F RID: 93311 RVA: 0x00651BF9 File Offset: 0x0064FDF9
	public void DestroyHuluObserver()
	{
		if (this.HuluObserver == null)
		{
			return;
		}
		SkeletalObserverManager.DestroySkeletalObserver(this.HuluObserver);
		this.HuluObserver = null;
	}

	// Token: 0x06016C80 RID: 93312 RVA: 0x00651C18 File Offset: 0x0064FE18
	public void InitHandBookObserver()
	{
		if (this.HandBookObserver != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[HandBookObserver]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.HandBookObserver = this.SpawnSkeletalObserverHandle(EUiModelUseWay.VisionInRoleView);
	}

	// Token: 0x06016C81 RID: 93313 RVA: 0x00651C58 File Offset: 0x0064FE58
	public SkeletalObserverHandle GetHandBookObserver()
	{
		if (this.HandBookObserver == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[HandBookObserver]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.HandBookObserver;
	}

	// Token: 0x06016C82 RID: 93314 RVA: 0x00651C91 File Offset: 0x0064FE91
	public void DestroyHandBookObserver()
	{
		if (this.HandBookObserver == null)
		{
			return;
		}
		SkeletalObserverManager.DestroySkeletalObserver(this.HandBookObserver);
		this.HandBookObserver = null;
	}

	// Token: 0x06016C83 RID: 93315 RVA: 0x00651CB0 File Offset: 0x0064FEB0
	public TsUiSceneRoleActor InitRoleSystemRoleActor(EUiModelUseWay useWay)
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.RoleSystemActorStack.Peek();
		if (tsUiSceneRoleActor != null)
		{
			tsUiSceneRoleActor.SetMoveOutActor();
		}
		TsUiSceneRoleActor tsUiSceneRoleActor2 = Singleton<UiSceneRoleActorManager>.Instance.CreateUiSceneRoleActor(useWay);
		this.RoleSystemActorStack.Push(tsUiSceneRoleActor2);
		return tsUiSceneRoleActor2;
	}

	// Token: 0x06016C84 RID: 93316 RVA: 0x00651CEC File Offset: 0x0064FEEC
	[NullableContext(2)]
	public TsUiSceneRoleActor GetRoleSystemRoleActor()
	{
		if (this.RoleSystemActorStack.Empty)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[RoleSystemActorStack]为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.RoleSystemActorStack.Peek();
	}

	// Token: 0x06016C85 RID: 93317 RVA: 0x00651D2F File Offset: 0x0064FF2F
	public bool HasRoleSystemRoleActor()
	{
		return !this.RoleSystemActorStack.Empty;
	}

	// Token: 0x06016C86 RID: 93318 RVA: 0x00651D40 File Offset: 0x0064FF40
	public void HideRoleSystemRoleActor()
	{
		if (this.RoleSystemActorStack.Empty)
		{
			return;
		}
		UiModelBase model = this.RoleSystemActorStack.Peek().Model;
		Singleton<UiModelUtil>.Instance.SetVisible(model, false);
	}

	// Token: 0x06016C87 RID: 93319 RVA: 0x00651D7C File Offset: 0x0064FF7C
	public void ShowRoleSystemRoleActor()
	{
		if (this.RoleSystemActorStack.Empty)
		{
			return;
		}
		UiModelBase model = this.RoleSystemActorStack.Peek().Model;
		Singleton<UiModelUtil>.Instance.SetVisible(model, true);
	}

	// Token: 0x06016C88 RID: 93320 RVA: 0x00651DB8 File Offset: 0x0064FFB8
	public bool DestroyRoleSystemRoleActor(TsUiSceneRoleActor roleActor)
	{
		bool result = false;
		bool flag = false;
		if (!this.RoleSystemActorStack.Empty)
		{
			flag = (this.RoleSystemActorStack.Peek() == roleActor);
			this.RoleSystemActorStack.Delete(roleActor);
			int roleActorIndex = roleActor.GetRoleActorIndex();
			result = Singleton<UiSceneRoleActorManager>.Instance.DestroyUiSceneRoleActor(roleActorIndex);
		}
		if (!this.RoleSystemActorStack.Empty && flag)
		{
			this.RoleSystemActorStack.Peek().SetMoveInActor();
		}
		return result;
	}

	// Token: 0x06016C89 RID: 93321 RVA: 0x00651E28 File Offset: 0x00650028
	public void DestroyAllRoleSystemRoleActor()
	{
		while (!this.RoleSystemActorStack.Empty)
		{
			int roleActorIndex = this.RoleSystemActorStack.Pop().GetRoleActorIndex();
			Singleton<UiSceneRoleActorManager>.Instance.DestroyUiSceneRoleActor(roleActorIndex);
		}
	}

	// Token: 0x06016C8A RID: 93322 RVA: 0x00651E64 File Offset: 0x00650064
	public unsafe TsUiSceneRoleActor InitRoleFormationActor(EUiModelUseWay useWay)
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = Singleton<UiSceneRoleActorManager>.Instance.CreateUiSceneRoleActor(useWay);
		this.RoleFormationActorList.Add(tsUiSceneRoleActor);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiSceneManager;
		ELogAuthor author = ELogAuthor.BB;
		string message = "InitRoleFormationRoleActor";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActorIndex", tsUiSceneRoleActor.GetRoleActorIndex());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("UseWay", useWay);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return tsUiSceneRoleActor;
	}

	// Token: 0x06016C8B RID: 93323 RVA: 0x00651EEC File Offset: 0x006500EC
	public bool DestroyRoleFormationActor(TsUiSceneRoleActor roleActor)
	{
		int num = this.RoleFormationActorList.IndexOf(roleActor);
		if (num != -1)
		{
			this.RoleFormationActorList.RemoveAt(num);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiSceneManager;
		ELogAuthor author = ELogAuthor.BB;
		string message = "DestroyRoleFormationRoleActor";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorIndex", num);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return Singleton<UiSceneRoleActorManager>.Instance.DestroyUiSceneRoleActor(roleActor.GetRoleActorIndex());
	}

	// Token: 0x06016C8C RID: 93324 RVA: 0x00651F52 File Offset: 0x00650152
	[NullableContext(2)]
	public TsUiSceneRoleActor GetCurrentSelectFormationRoleActor()
	{
		if (this.SelectFormationPosition == -1)
		{
			return null;
		}
		return this.GetRoleFormationActor(this.SelectFormationPosition);
	}

	// Token: 0x06016C8D RID: 93325 RVA: 0x00651F6C File Offset: 0x0065016C
	[NullableContext(2)]
	public TsUiSceneRoleActor GetRoleFormationActor(int position)
	{
		for (int i = this.RoleFormationActorList.Count - 1; i >= 0; i--)
		{
			TsUiSceneRoleActor tsUiSceneRoleActor = this.RoleFormationActorList[i];
			UiFormationRoleDataComponent uiFormationRoleDataComponent = tsUiSceneRoleActor.Model.CheckGetComponent<UiFormationRoleDataComponent>();
			if (uiFormationRoleDataComponent != null && uiFormationRoleDataComponent.Position == position)
			{
				return tsUiSceneRoleActor;
			}
		}
		return null;
	}

	// Token: 0x06016C8E RID: 93326 RVA: 0x00651FBC File Offset: 0x006501BC
	private void DestroyAllRoleFormationActor()
	{
		foreach (TsUiSceneRoleActor tsUiSceneRoleActor in this.RoleFormationActorList)
		{
			int roleActorIndex = tsUiSceneRoleActor.GetRoleActorIndex();
			Singleton<UiSceneRoleActorManager>.Instance.DestroyUiSceneRoleActor(roleActorIndex);
		}
		this.RoleFormationActorList.Clear();
	}

	// Token: 0x06016C8F RID: 93327 RVA: 0x00652024 File Offset: 0x00650224
	public void InitGachaItemObserver()
	{
		if (this.GachaItemObserver != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[GachaItemObserver]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.GachaItemObserver = this.SpawnSkeletalObserverHandle(EUiModelUseWay.WeaponInWeaponView);
	}

	// Token: 0x06016C90 RID: 93328 RVA: 0x00652064 File Offset: 0x00650264
	public SkeletalObserverHandle GetGachaItemObserver()
	{
		SkeletalObserverHandle gachaItemObserver = this.GachaItemObserver;
		if (gachaItemObserver == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[GachaItemObserver]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return gachaItemObserver;
	}

	// Token: 0x06016C91 RID: 93329 RVA: 0x0065209A File Offset: 0x0065029A
	public void DestroyGachaItemObserver()
	{
		if (this.GachaItemObserver != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.GachaItemObserver);
			this.GachaItemObserver = null;
		}
	}

	// Token: 0x06016C92 RID: 93330 RVA: 0x006520B8 File Offset: 0x006502B8
	public void InitDreamLinkRoleSkeletalHandle()
	{
		if (this.DreamLinkRoleSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.DreamLink, ELogAuthor.LPH, "[DreamLinkRoleSkeletalHandle]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.DreamLinkRoleSkeletalHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.RoleInDreamLinkView);
	}

	// Token: 0x06016C93 RID: 93331 RVA: 0x006520FC File Offset: 0x006502FC
	public SkeletalObserverHandle GetDreamLinkRoleSkeletalHandle()
	{
		if (this.DreamLinkRoleSkeletalHandle == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LPH, "[DreamLinkRoleSkeletalHandle]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return this.DreamLinkRoleSkeletalHandle;
	}

	// Token: 0x06016C94 RID: 93332 RVA: 0x00652135 File Offset: 0x00650335
	public bool HasDreamLinkRoleSkeletalHandle()
	{
		return this.DreamLinkRoleSkeletalHandle != null;
	}

	// Token: 0x06016C95 RID: 93333 RVA: 0x00652140 File Offset: 0x00650340
	public void DestroyDreamLinkRoleSkeletalHandle()
	{
		if (this.DreamLinkRoleSkeletalHandle != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.DreamLinkRoleSkeletalHandle);
			this.DreamLinkRoleSkeletalHandle = null;
		}
	}

	// Token: 0x06016C96 RID: 93334 RVA: 0x0065215C File Offset: 0x0065035C
	public SkeletalObserverHandle InitDreamLinkWeaponSkeletalHandle()
	{
		SkeletalObserverHandle skeletalObserverHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.WeaponInDreamLinkView);
		this.DreamLinkWeaponSkeletalHandleStack.Add(skeletalObserverHandle);
		return skeletalObserverHandle;
	}

	// Token: 0x06016C97 RID: 93335 RVA: 0x0065217F File Offset: 0x0065037F
	public bool HasDreamLinkWeaponSkeletalHandle()
	{
		return this.DreamLinkWeaponSkeletalHandleStack.Count > 0;
	}

	// Token: 0x06016C98 RID: 93336 RVA: 0x00652190 File Offset: 0x00650390
	public void DestroyAllDreamLinkWeaponSkeletalHandle()
	{
		foreach (SkeletalObserverHandle skeletalObserverHandle in this.DreamLinkWeaponSkeletalHandleStack)
		{
			SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
		}
		this.DreamLinkWeaponSkeletalHandleStack.Clear();
	}

	// Token: 0x06016C99 RID: 93337 RVA: 0x006521EC File Offset: 0x006503EC
	public void CreateHandBookVision(UClass csClass)
	{
		BP_KposeBase_C bp_KposeBase_C = Singleton<ActorSystem>.Instance.Spawn<BP_KposeBase_C>(csClass.ClassStackOnlyPtr, new FTransformDouble(), null);
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("MonsterCase").Value, ECollectActorType.UI);
		TArray<UActorComponent> tarray = (bp_KposeBase_C != null) ? bp_KposeBase_C.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass()) : null;
		if (tarray != null)
		{
			for (int i = 0; i < tarray.Num(); i++)
			{
				tarray.Get(i).SetTickableWhenPaused(true);
			}
		}
		TArray<UActorComponent> tarray2 = (bp_KposeBase_C != null) ? bp_KposeBase_C.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass()) : null;
		if (tarray2 != null)
		{
			for (int j = 0; j < tarray2.Num(); j++)
			{
				tarray2.Get(j).SetTickableWhenPaused(true);
			}
		}
		FVectorDouble newLocation = actorWithTag.D_K2_GetActorLocation();
		FRotator newRotation = actorWithTag.K2_GetActorRotation();
		bp_KposeBase_C.D_K2_SetActorLocationAndRotation(newLocation, newRotation, false, ref WorldGlobal.SweepHitResult, false);
		if (this.HandBookVision != null)
		{
			this.DestroyHandBookVision();
		}
		this.HandBookVision = bp_KposeBase_C;
	}

	// Token: 0x06016C9A RID: 93338 RVA: 0x006522DB File Offset: 0x006504DB
	[NullableContext(2)]
	public BP_KposeBase_C GetHandBookVision()
	{
		return this.HandBookVision;
	}

	// Token: 0x06016C9B RID: 93339 RVA: 0x006522E4 File Offset: 0x006504E4
	[NullableContext(2)]
	public AActor GetHandBookCaseActor()
	{
		return UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("MonsterCase").Value, ECollectActorType.UI);
	}

	// Token: 0x06016C9C RID: 93340 RVA: 0x00652309 File Offset: 0x00650509
	public void DestroyHandBookVision()
	{
		if (this.HandBookVision == null)
		{
			return;
		}
		this.HandBookVision.PlayEnd();
		Singleton<ActorSystem>.Instance.Put("UiSceneManager.DestroyHandBookVision", this.HandBookVision, null);
		this.HandBookVision = null;
	}

	// Token: 0x06016C9D RID: 93341 RVA: 0x00652340 File Offset: 0x00650540
	public void InitVisionSkeletalHandle()
	{
		if (this.VisionSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Phantom, ELogAuthor.TL, "[VisionSkeletalHandle]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.VisionSkeletalHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.VisionInRoleView);
	}

	// Token: 0x06016C9E RID: 93342 RVA: 0x0065237F File Offset: 0x0065057F
	public bool HasVisionSkeletalHandle()
	{
		return this.VisionSkeletalHandle != null;
	}

	// Token: 0x06016C9F RID: 93343 RVA: 0x0065238C File Offset: 0x0065058C
	[NullableContext(2)]
	public SkeletalObserverHandle GetVisionSkeletalHandle()
	{
		SkeletalObserverHandle visionSkeletalHandle = this.VisionSkeletalHandle;
		if (visionSkeletalHandle == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.TL, "[VisionSkeletalHandle]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return visionSkeletalHandle;
	}

	// Token: 0x06016CA0 RID: 93344 RVA: 0x006523C2 File Offset: 0x006505C2
	public void DestroyVisionSkeletalHandle()
	{
		if (this.VisionSkeletalHandle != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.VisionSkeletalHandle);
			this.VisionSkeletalHandle = null;
		}
	}

	// Token: 0x06016CA1 RID: 93345 RVA: 0x006523E0 File Offset: 0x006505E0
	public void InitAbyssDangoObserver()
	{
		if (this.AbyssDangoObserver != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.YZY, "[AbyssDangoObserver]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.AbyssDangoObserver = this.SpawnSkeletalObserverHandle(EUiModelUseWay.AbyssDango);
	}

	// Token: 0x06016CA2 RID: 93346 RVA: 0x00652420 File Offset: 0x00650620
	[NullableContext(2)]
	public SkeletalObserverHandle GetAbyssDangoObserver()
	{
		SkeletalObserverHandle abyssDangoObserver = this.AbyssDangoObserver;
		if (abyssDangoObserver == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.YZY, "[AbyssDangoObserver]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return abyssDangoObserver;
	}

	// Token: 0x06016CA3 RID: 93347 RVA: 0x00652456 File Offset: 0x00650656
	public void DestroyAbyssDangoObserver()
	{
		if (this.AbyssDangoObserver != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.AbyssDangoObserver);
			this.AbyssDangoObserver = null;
		}
	}

	// Token: 0x06016CA4 RID: 93348 RVA: 0x00652474 File Offset: 0x00650674
	public void InitLordSkeletalHandle()
	{
		if (this.LordSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LZK, "[LordSkeletalHandle]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.LordSkeletalHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.VisionInLordGymView);
	}

	// Token: 0x06016CA5 RID: 93349 RVA: 0x006524B4 File Offset: 0x006506B4
	public bool HasLordSkeletalHandle()
	{
		return this.LordSkeletalHandle != null;
	}

	// Token: 0x06016CA6 RID: 93350 RVA: 0x006524C0 File Offset: 0x006506C0
	[NullableContext(2)]
	public SkeletalObserverHandle GetLordSkeletalHandle()
	{
		SkeletalObserverHandle lordSkeletalHandle = this.LordSkeletalHandle;
		if (lordSkeletalHandle == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LZK, "[LordSkeletalHandle]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return lordSkeletalHandle;
	}

	// Token: 0x06016CA7 RID: 93351 RVA: 0x006524F6 File Offset: 0x006506F6
	public void DestroyLordSkeletalHandle()
	{
		if (this.LordSkeletalHandle != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.LordSkeletalHandle);
			this.LordSkeletalHandle = null;
		}
	}

	// Token: 0x06016CA8 RID: 93352 RVA: 0x00652514 File Offset: 0x00650714
	public void InitAdamSmasherSkeletalHandle()
	{
		if (this.AdamSmasherSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.SWC, "[AdamSmasherSkeletalHandle]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.AdamSmasherSkeletalHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.AdamSmasher);
	}

	// Token: 0x06016CA9 RID: 93353 RVA: 0x00652554 File Offset: 0x00650754
	public bool HasAdamSmasherSkeletalHandle()
	{
		return this.AdamSmasherSkeletalHandle != null;
	}

	// Token: 0x06016CAA RID: 93354 RVA: 0x00652560 File Offset: 0x00650760
	[NullableContext(2)]
	public SkeletalObserverHandle GetAdamSmasherSkeletalHandle()
	{
		SkeletalObserverHandle adamSmasherSkeletalHandle = this.AdamSmasherSkeletalHandle;
		if (adamSmasherSkeletalHandle == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.SWC, "[AdamSmasherSkeletalHandle]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return adamSmasherSkeletalHandle;
	}

	// Token: 0x06016CAB RID: 93355 RVA: 0x00652596 File Offset: 0x00650796
	public void DestroyAdamSmasherSkeletalHandle()
	{
		if (this.AdamSmasherSkeletalHandle != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.AdamSmasherSkeletalHandle);
			this.AdamSmasherSkeletalHandle = null;
		}
	}

	// Token: 0x06016CAC RID: 93356 RVA: 0x006525B2 File Offset: 0x006507B2
	public TsUiSceneDangoActor InitDangoActor(EUiModelUseWay useWay)
	{
		return UiSceneDangoActorManager.CreateUiSceneDangoActor(useWay);
	}

	// Token: 0x06016CAD RID: 93357 RVA: 0x006525BA File Offset: 0x006507BA
	public void DestroyDangoActor(TsUiSceneDangoActor dango)
	{
		UiSceneDangoActorManager.DestroyUiSceneDangoActor(dango.GetActorIndex());
	}

	// Token: 0x06016CAE RID: 93358 RVA: 0x006525C8 File Offset: 0x006507C8
	[NullableContext(2)]
	public TsUiSceneDangoActor RayTraceDangoActor(FVector viewportPosition)
	{
		TsCharacterController characterController = Global.CharacterController;
		if (characterController == null)
		{
			return null;
		}
		FVector fvector = new FVector();
		FVector fvector2 = new FVector();
		this.ScreenPosition.Set(viewportPosition.X, viewportPosition.Y);
		if (!UGameplayStatics.DeprojectScreenToWorld(characterController, this.ScreenPosition, ref fvector, ref fvector2))
		{
			return null;
		}
		FVector fvector3 = fvector;
		FVector fvector4 = fvector2;
		global::Vector locationOffset = this.LocationOffset;
		FVector fvector5 = characterController.GetViewTarget().K2_GetActorLocation();
		FVectorDouble fvectorDouble = fvector5;
		locationOffset.DeepCopy(fvectorDouble);
		ControllerBase<CameraController>.Instance.MainModel.CameraLocation.Subtraction(this.LocationOffset, this.LocationOffset);
		global::Vector commonStartLocation = ModelBase<TraceElementModel>.Instance.CommonStartLocation;
		global::Vector vector = commonStartLocation;
		fvectorDouble = fvector3;
		vector.DeepCopy(fvectorDouble);
		commonStartLocation.Addition(this.LocationOffset, commonStartLocation);
		global::Vector commonEndLocation = ModelBase<TraceElementModel>.Instance.CommonEndLocation;
		fvector5 = fvector4 * 5000f;
		fvector3 = fvector3 + fvector5;
		global::Vector vector2 = commonEndLocation;
		fvectorDouble = fvector3;
		vector2.DeepCopy(fvectorDouble);
		commonEndLocation.Addition(this.LocationOffset, commonEndLocation);
		UTraceLineElement lineTrace = ModelBase<TraceElementModel>.Instance.GetLineTrace();
		lineTrace.WorldContextObject = GlobalData.World;
		lineTrace.ActorsToIgnore.Empty(true);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, commonStartLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, commonEndLocation);
		if (!Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "RayTraceDangoActor"))
		{
			lineTrace.ClearCacheData(false);
			return null;
		}
		TsUiSceneDangoActor tsUiSceneDangoActor = lineTrace.HitResult.Actors.Get(0).Get() as TsUiSceneDangoActor;
		if (tsUiSceneDangoActor != null)
		{
			return tsUiSceneDangoActor;
		}
		return null;
	}

	// Token: 0x06016CAF RID: 93359 RVA: 0x00652760 File Offset: 0x00650960
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public UniTask<List<TsUiSceneDangoActor>> LoadDangoActorList(List<IRacingBetsDangoActorData> dangoOddsList, Action<TsUiSceneDangoActor> createCallback = null)
	{
		UiSceneManager.<LoadDangoActorList>d__105 <LoadDangoActorList>d__;
		<LoadDangoActorList>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<TsUiSceneDangoActor>>.Create();
		<LoadDangoActorList>d__.<>4__this = this;
		<LoadDangoActorList>d__.dangoOddsList = dangoOddsList;
		<LoadDangoActorList>d__.createCallback = createCallback;
		<LoadDangoActorList>d__.<>1__state = -1;
		<LoadDangoActorList>d__.<>t__builder.Start<UiSceneManager.<LoadDangoActorList>d__105>(ref <LoadDangoActorList>d__);
		return <LoadDangoActorList>d__.<>t__builder.Task;
	}

	// Token: 0x06016CB0 RID: 93360 RVA: 0x006527B4 File Offset: 0x006509B4
	public void InitGliderSkeletalHandle()
	{
		if (this.GliderSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LZK, "[GliderSkeletalHandle]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.GliderSkeletalHandle = this.SpawnSkeletalObserverHandle(EUiModelUseWay.GliderInSkinView);
	}

	// Token: 0x06016CB1 RID: 93361 RVA: 0x006527F4 File Offset: 0x006509F4
	public bool HasGliderSkeletalHandle()
	{
		return this.GliderSkeletalHandle != null;
	}

	// Token: 0x06016CB2 RID: 93362 RVA: 0x00652800 File Offset: 0x00650A00
	public SkeletalObserverHandle GetGliderSkeletalHandle()
	{
		SkeletalObserverHandle gliderSkeletalHandle = this.GliderSkeletalHandle;
		if (gliderSkeletalHandle == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LZK, "[GliderSkeletalHandle]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return gliderSkeletalHandle;
	}

	// Token: 0x06016CB3 RID: 93363 RVA: 0x00652836 File Offset: 0x00650A36
	public void DestroyGliderSkeletalHandle()
	{
		if (this.GliderSkeletalHandle != null)
		{
			SkeletalObserverManager.DestroySkeletalObserver(this.GliderSkeletalHandle);
			this.GliderSkeletalHandle = null;
		}
	}

	// Token: 0x06016CB4 RID: 93364 RVA: 0x00652854 File Offset: 0x00650A54
	public void InitMotorSkeletalHandle(EUiModelUseWay useWay = EUiModelUseWay.MotorInMotorView)
	{
		if (this.MotorSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LZK, "[MotorSkeletalHandle]重复初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.UiSceneManager, ELogAuthor.LZK, "InitMotorSkeletalHandle", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.MotorSkeletalHandle = this.SpawnSkeletalObserverHandle(useWay);
	}

	// Token: 0x06016CB5 RID: 93365 RVA: 0x006528B0 File Offset: 0x00650AB0
	[NullableContext(2)]
	public SkeletalObserverHandle GetMotorSkeletalHandle()
	{
		SkeletalObserverHandle motorSkeletalHandle = this.MotorSkeletalHandle;
		if (motorSkeletalHandle == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.UiSceneManager, ELogAuthor.LZK, "[MotorSkeletalHandle]未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return motorSkeletalHandle;
	}

	// Token: 0x06016CB6 RID: 93366 RVA: 0x006528E8 File Offset: 0x00650AE8
	public void DestroyMotorSkeletalHandle()
	{
		if (this.MotorSkeletalHandle != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiSceneManager, ELogAuthor.LZK, "DestroyMotorSkeletalHandle", default(ReadOnlySpan<ValueTuple<string, object>>));
			SkeletalObserverManager.DestroySkeletalObserver(this.MotorSkeletalHandle);
			this.MotorSkeletalHandle = null;
		}
	}

	// Token: 0x06016CB7 RID: 93367 RVA: 0x0065292C File Offset: 0x00650B2C
	[NullableContext(2)]
	public void AddUiShowRoomShowActor(AActor actor, bool includeFromChildActors)
	{
		FName? dynamicFName = FNameUtil.GetDynamicFName("BP_UIShowRoom");
		BP_UIShowRoom_C bp_UIShowRoom_C = (dynamicFName == null) ? null : (UKuroCollectActorComponent.GetActorWithTag(dynamicFName.Value, ECollectActorType.UI) as BP_UIShowRoom_C);
		if (bp_UIShowRoom_C == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiSceneManager, ELogAuthor.XXJ, "当前场景找不到反射地板蓝图类BP_UIShowRoom", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		bp_UIShowRoom_C.AddShowActor(ref actor, includeFromChildActors);
	}

	// Token: 0x06016CB8 RID: 93368 RVA: 0x0065298C File Offset: 0x00650B8C
	public UniTask LoadScene(string sceneId, Action callBack)
	{
		UiSceneManager.<LoadScene>d__117 <LoadScene>d__;
		<LoadScene>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadScene>d__.<>4__this = this;
		<LoadScene>d__.sceneId = sceneId;
		<LoadScene>d__.callBack = callBack;
		<LoadScene>d__.<>1__state = -1;
		<LoadScene>d__.<>t__builder.Start<UiSceneManager.<LoadScene>d__117>(ref <LoadScene>d__);
		return <LoadScene>d__.<>t__builder.Task;
	}

	// Token: 0x06016CB9 RID: 93369 RVA: 0x006529E0 File Offset: 0x00650BE0
	public UniTask ExitScene()
	{
		UiSceneManager.<ExitScene>d__118 <ExitScene>d__;
		<ExitScene>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExitScene>d__.<>4__this = this;
		<ExitScene>d__.<>1__state = -1;
		<ExitScene>d__.<>t__builder.Start<UiSceneManager.<ExitScene>d__118>(ref <ExitScene>d__);
		return <ExitScene>d__.<>t__builder.Task;
	}

	// Token: 0x06016CBA RID: 93370 RVA: 0x00652A23 File Offset: 0x00650C23
	private void RecordAndLandscapeValue()
	{
		this.LastHideLandscapeValue = UKismetSystemLibrary.GetConsoleVariableIntValue("r.Kuro.HideLandscape");
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.HideLandscape 0", null);
	}

	// Token: 0x06016CBB RID: 93371 RVA: 0x00652A48 File Offset: 0x00650C48
	private void ResetLandscapeValue()
	{
		UObject world = GlobalData.World;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
		defaultInterpolatedStringHandler.AppendLiteral("r.Kuro.HideLandscape ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.LastHideLandscapeValue);
		UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
	}

	// Token: 0x06016CBC RID: 93372 RVA: 0x00652A8C File Offset: 0x00650C8C
	private void SetEnterSceneCamera()
	{
		if (GlobalData.World != null)
		{
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_EaseIn, 0f, null, "MainCamera", null);
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_EaseIn, 0f, null, false, "MainCamera", null);
		}
	}

	// Token: 0x06016CBD RID: 93373 RVA: 0x00652ADD File Offset: 0x00650CDD
	public void SetUiStartSequenceFrame(int startSequenceFrame)
	{
		if (this.StartSequenceFrame == 0)
		{
			this.StartSequenceFrame = startSequenceFrame;
		}
	}

	// Token: 0x06016CBE RID: 93374 RVA: 0x00652AEE File Offset: 0x00650CEE
	public void SetUiEndSequenceFrame(int endSequenceFrame)
	{
		if (this.EndSequenceFrame == 0)
		{
			this.EndSequenceFrame = endSequenceFrame;
		}
	}

	// Token: 0x06016CBF RID: 93375 RVA: 0x00652AFF File Offset: 0x00650CFF
	public void ClearUiSequenceFrame()
	{
		this.StartSequenceFrame = 0;
		this.EndSequenceFrame = 0;
	}

	// Token: 0x06016CC0 RID: 93376 RVA: 0x00652B0F File Offset: 0x00650D0F
	public int GetUiStartSequenceFrame()
	{
		return this.StartSequenceFrame;
	}

	// Token: 0x06016CC1 RID: 93377 RVA: 0x00652B17 File Offset: 0x00650D17
	public int GetUiEndSequenceFrame()
	{
		return this.EndSequenceFrame;
	}

	// Token: 0x06016CC2 RID: 93378 RVA: 0x00652B20 File Offset: 0x00650D20
	public void HideObserver(SkeletalObserverHandle observer, string effectId)
	{
		if (observer == null)
		{
			return;
		}
		UiModelBase model = observer.Model;
		if (Singleton<UiModelUtil>.Instance.SetVisible(model, false))
		{
			Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, effectId);
		}
	}

	// Token: 0x06016CC3 RID: 93379 RVA: 0x00652B54 File Offset: 0x00650D54
	public void HideObserverWithCallback(SkeletalObserverHandle observer, string effectId, Action<SkeletalObserverHandle> callback)
	{
		if (observer == null)
		{
			return;
		}
		UiModelBase model = observer.Model;
		if (Singleton<UiModelUtil>.Instance.SetVisible(model, false))
		{
			Singleton<UiModelUtil>.Instance.PlayEffectOnRootWithCallback(model, effectId, delegate(int _)
			{
				callback(observer);
			});
		}
	}

	// Token: 0x06016CC4 RID: 93380 RVA: 0x00652BB0 File Offset: 0x00650DB0
	[return: Nullable(2)]
	public AActor GetActorByTag(string tag)
	{
		FName? dynamicFName = FNameUtil.GetDynamicFName(tag);
		if (dynamicFName == null)
		{
			return null;
		}
		return UKuroCollectActorComponent.GetActorWithTag(dynamicFName.Value, ECollectActorType.UI);
	}

	// Token: 0x06016CC5 RID: 93381 RVA: 0x00652BDC File Offset: 0x00650DDC
	public void Clear()
	{
		SkeletalObserverManager.ClearAllSkeletalObserver();
		Singleton<UiSceneRoleActorManager>.Instance.ClearAllUiSceneRoleActor();
		UiSceneDangoActorManager.ClearAllUiSceneDangoActor();
		DangoAbyssActorManager.ClearAllDangoSkeletalObserverHandle();
		this.DestroyGachaItemObserver();
		this.DestroyHandBookObserver();
		this.DestroyHandBookVision();
		this.DestroyPhantomObserver();
		this.DestroyAllRoleSystemRoleActor();
		this.DestroyAllRoleFormationActor();
		this.DestroyAllWeaponObserver();
		this.DestroyAllWeaponScabbardObserver();
		this.DestroyHuluObserver();
	}

	// Token: 0x0400AF82 RID: 44930
	private readonly HashSet<string> DisableClvUiSceneIds = new HashSet<string>
	{
		"Instance_ChouKa_01",
		"UL_UIMap_ChallengeUI",
		"UL_UIMap_Bosslevel",
		"UL_UIMap_DaoGuanUI",
		"UL_UIMap_HologramUI"
	};

	// Token: 0x0400AF83 RID: 44931
	private int? LastClvEnableValue;

	// Token: 0x0400AF84 RID: 44932
	public string CurUiSceneId = string.Empty;

	// Token: 0x0400AF85 RID: 44933
	public HashSet<string> CurUiScenePathSet = new HashSet<string>();

	// Token: 0x0400AF86 RID: 44934
	public string GlobalGiMainScene = string.Empty;

	// Token: 0x0400AF87 RID: 44935
	[Nullable(2)]
	protected Action LoadSuccessFunction;

	// Token: 0x0400AF88 RID: 44936
	[Nullable(2)]
	protected Action<bool> SwitchUiSceneFunction;

	// Token: 0x0400AF89 RID: 44937
	private readonly global::Stack<SkeletalObserverHandle> WeaponObserverStack = new global::Stack<SkeletalObserverHandle>();

	// Token: 0x0400AF8A RID: 44938
	private readonly global::Stack<SkeletalObserverHandle> WeaponScabbardStack = new global::Stack<SkeletalObserverHandle>();

	// Token: 0x0400AF8B RID: 44939
	private SkeletalObserverHandle PhantomObserver;

	// Token: 0x0400AF8C RID: 44940
	[Nullable(2)]
	private SkeletalObserverHandle HuluObserver;

	// Token: 0x0400AF8D RID: 44941
	private SkeletalObserverHandle HandBookObserver;

	// Token: 0x0400AF8E RID: 44942
	private readonly global::Stack<TsUiSceneRoleActor> RoleSystemActorStack = new global::Stack<TsUiSceneRoleActor>();

	// Token: 0x0400AF8F RID: 44943
	public int SelectFormationPosition = -1;

	// Token: 0x0400AF90 RID: 44944
	private readonly List<TsUiSceneRoleActor> RoleFormationActorList = new List<TsUiSceneRoleActor>();

	// Token: 0x0400AF91 RID: 44945
	private SkeletalObserverHandle GachaItemObserver;

	// Token: 0x0400AF92 RID: 44946
	[Nullable(2)]
	private SkeletalObserverHandle DreamLinkRoleSkeletalHandle;

	// Token: 0x0400AF93 RID: 44947
	private readonly List<SkeletalObserverHandle> DreamLinkWeaponSkeletalHandleStack = new List<SkeletalObserverHandle>();

	// Token: 0x0400AF94 RID: 44948
	[Nullable(2)]
	private BP_KposeBase_C HandBookVision;

	// Token: 0x0400AF95 RID: 44949
	[Nullable(2)]
	private SkeletalObserverHandle VisionSkeletalHandle;

	// Token: 0x0400AF96 RID: 44950
	[Nullable(2)]
	private SkeletalObserverHandle AbyssDangoObserver;

	// Token: 0x0400AF97 RID: 44951
	[Nullable(2)]
	private SkeletalObserverHandle LordSkeletalHandle;

	// Token: 0x0400AF98 RID: 44952
	[Nullable(2)]
	private SkeletalObserverHandle AdamSmasherSkeletalHandle;

	// Token: 0x0400AF99 RID: 44953
	private readonly global::Vector LocationOffset = global::Vector.Create();

	// Token: 0x0400AF9A RID: 44954
	private FVector2D ScreenPosition = new FVector2D();

	// Token: 0x0400AF9B RID: 44955
	private SkeletalObserverHandle GliderSkeletalHandle;

	// Token: 0x0400AF9C RID: 44956
	[Nullable(2)]
	private SkeletalObserverHandle MotorSkeletalHandle;

	// Token: 0x0400AF9D RID: 44957
	private int LastStencilFixedValue;

	// Token: 0x0400AF9E RID: 44958
	private int LastHideLandscapeValue;

	// Token: 0x0400AF9F RID: 44959
	private int StartSequenceFrame;

	// Token: 0x0400AFA0 RID: 44960
	private int EndSequenceFrame;
}
