using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C2F RID: 11311
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiCameraAnimationController : ControllerBase<UiCameraAnimationController>
{
	// Token: 0x06016A4F RID: 92751 RVA: 0x0064942C File Offset: 0x0064762C
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<EUiTabViewName?, UiTabViewBase>(EEventName.OpenTabView, new Action<EUiTabViewName?, UiTabViewBase>(this.OnOpenTabView));
		Singleton<EventSystem>.Instance.Add<EUiViewName>(EEventName.OnViewLoadCompleted, new Action<EUiViewName>(this.OnViewLoadCompleted));
		Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
		Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleAfterResetToBattleView, new Action(this.OnResetCameraByResetToBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Add(EEventName.DestroyAllUiCameraAnimationHandles, new Action(this.OnDestroyAllUiCameraAnimationHandles));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectedRoleChanged, new Action(this.OnRoleSystemChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleMorphTypeChanged, new Action(this.OnRoleMorphTypeChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.UiSceneLoaded, new Action(this.OnUiSceneLoaded));
		Singleton<UiCameraAnimationManager>.Instance.Initialize();
		return true;
	}

	// Token: 0x06016A50 RID: 92752 RVA: 0x00649570 File Offset: 0x00647770
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenTabView, new Action<EUiTabViewName?, UiTabViewBase>(this.OnOpenTabView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnViewLoadCompleted, new Action<EUiViewName>(this.OnViewLoadCompleted));
		Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
		Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleAfterResetToBattleView, new Action(this.OnResetCameraByResetToBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.DestroyAllUiCameraAnimationHandles, new Action(this.OnDestroyAllUiCameraAnimationHandles));
		Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Remove(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectedRoleChanged, new Action(this.OnRoleSystemChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleMorphTypeChanged, new Action(this.OnRoleMorphTypeChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.UiSceneLoaded, new Action(this.OnUiSceneLoaded));
		this.ResetDelayPush();
		Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
		return true;
	}

	// Token: 0x06016A51 RID: 92753 RVA: 0x006496B8 File Offset: 0x006478B8
	protected override bool OnLeaveLevel()
	{
		this.ResetDelayPush();
		Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
		return true;
	}

	// Token: 0x06016A52 RID: 92754 RVA: 0x006496CC File Offset: 0x006478CC
	public unsafe void PushCameraHandle(EUiViewName viewName, int? viewId = null, bool bBlend = true)
	{
		if (viewName == Singleton<UiModel>.Instance.MainViewName)
		{
			if (Singleton<UiCameraAnimationManager>.Instance.IsActivate())
			{
				Singleton<Log>.Instance.Error(ELogModule.CameraAnimation, ELogAuthor.BB, "当打开主界面时，Ui镜头栈有未抛出的数据，检查是否没有关闭界面，或手动播放了Ui镜头但没有手动抛出", default(ReadOnlySpan<ValueTuple<string, object>>));
				foreach (UiCameraHandleData uiCameraHandleData in Singleton<UiCameraAnimationManager>.Instance.GetHandleDataStack())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.CameraAnimation;
					ELogAuthor author = ELogAuthor.BB;
					string message = "未抛出的Ui镜头数据";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("HandleName", uiCameraHandleData.HandleName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", uiCameraHandleData.ViewName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
			}
			return;
		}
		UiCameraMappingData cameraMappingData = Singleton<UiCameraAnimationManager>.Instance.GetCameraMappingData(viewName);
		if (cameraMappingData == null)
		{
			return;
		}
		float uiCameraDelayTime = cameraMappingData.GetUiCameraDelayTime();
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.CameraAnimation;
		ELogAuthor author2 = ELogAuthor.BB;
		string message2 = "当打开界面时";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("viewName", viewName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("delayTime", uiCameraDelayTime);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		if (uiCameraDelayTime > 0f && bBlend)
		{
			this.DelayPushCameraHandleByOpenView(uiCameraDelayTime, viewName, viewId);
			return;
		}
		this.ResetDelayPush();
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByOpenView(viewName, viewId, bBlend);
	}

	// Token: 0x06016A53 RID: 92755 RVA: 0x00649874 File Offset: 0x00647A74
	private unsafe void OnOpenTabView(EUiTabViewName? tabViewName, UiTabViewBase uiTabViewBase)
	{
		UiCameraMappingData cameraMappingData = Singleton<UiCameraAnimationManager>.Instance.GetCameraMappingData(tabViewName.Value);
		if (cameraMappingData == null)
		{
			return;
		}
		float uiCameraDelayTime = cameraMappingData.GetUiCameraDelayTime();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "当打开页签界面时";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tabViewName", tabViewName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("delayTime", uiCameraDelayTime);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (uiCameraDelayTime > 0f)
		{
			this.DelayPushCameraHandleByOpenView(uiCameraDelayTime, tabViewName.Value, null);
			return;
		}
		this.ResetDelayPush();
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByOpenView(tabViewName.Value, null, true);
	}

	// Token: 0x06016A54 RID: 92756 RVA: 0x0064994C File Offset: 0x00647B4C
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "当隐藏界面时";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ResetDelayPush();
		UiCameraAnimationManager instance2 = Singleton<UiCameraAnimationManager>.Instance;
		string closeViewName = viewName;
		EUiViewName? euiViewName = (stackTopInfo != null) ? new EUiViewName?(stackTopInfo.Name) : null;
		instance2.PopCameraHandleByCloseView(closeViewName, (euiViewName != null) ? euiViewName.GetValueOrDefault() : null, closeViewId, popOrDelete);
	}

	// Token: 0x06016A55 RID: 92757 RVA: 0x006499D0 File Offset: 0x00647BD0
	public void EnterUiCameraMode()
	{
		UiCamera uiCamera = Singleton<UiCameraAnimationManager>.Instance.UiCamera;
		UiCameraStructure uiCameraStructure = (uiCamera != null) ? uiCamera.GetStructure() : null;
		if (uiCameraStructure != null)
		{
			uiCameraStructure.Activate();
		}
		UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
		if (lastHandleData != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.ActivateCameraHandle(lastHandleData, false, false);
		}
	}

	// Token: 0x06016A56 RID: 92758 RVA: 0x00649A18 File Offset: 0x00647C18
	public void ExitUiCameraMode()
	{
		UiCamera uiCamera = Singleton<UiCameraAnimationManager>.Instance.UiCamera;
		UiCameraStructure uiCameraStructure = (uiCamera != null) ? uiCamera.GetStructure() : null;
		if (uiCameraStructure != null)
		{
			uiCameraStructure.Deactivate();
		}
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
	}

	// Token: 0x06016A57 RID: 92759 RVA: 0x00649A64 File Offset: 0x00647C64
	public void DeepCopyCamera(ACameraActor cameraActor)
	{
		UiCameraAnimationHandle currentCameraHandle = Singleton<UiCameraAnimationManager>.Instance.GetCurrentCameraHandle();
		if (currentCameraHandle == null)
		{
			return;
		}
		currentCameraHandle.DeepCopyCameraInfo(cameraActor);
	}

	// Token: 0x06016A58 RID: 92760 RVA: 0x00649A88 File Offset: 0x00647C88
	private void OnViewLoadCompleted(EUiViewName viewName)
	{
		UiCameraAnimationHandle currentCameraHandle = Singleton<UiCameraAnimationManager>.Instance.GetCurrentCameraHandle();
		if (currentCameraHandle == null)
		{
			return;
		}
		if (currentCameraHandle.GetHandleData() == null)
		{
			return;
		}
		if (!currentCameraHandle.GetIsActivate())
		{
			return;
		}
		if (currentCameraHandle.GetViewName() != viewName)
		{
			return;
		}
		if (!currentCameraHandle.IsViewInLoading)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "当界面加载完成时,重新激活镜头状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiCameraAnimationManager>.Instance.ReactivateCameraHandle(false, true);
	}

	// Token: 0x06016A59 RID: 92761 RVA: 0x00649AFC File Offset: 0x00647CFC
	private void DelayPushCameraHandleByOpenView(float delayTime, string viewName, int? viewId = null)
	{
		if (!Singleton<UiCameraAnimationManager>.Instance.CanPushCameraHandle(viewName))
		{
			return;
		}
		this.ResetDelayPush();
		this.DelayViewName = viewName;
		this.DelayViewId = viewId;
		this.DelayPushCameraHandleTimerId = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnUiCameraDelayFinished), delayTime, null, null, true, 1f);
	}

	// Token: 0x06016A5A RID: 92762 RVA: 0x00649B50 File Offset: 0x00647D50
	private void ResetDelayPush()
	{
		if (!TimerSystem.GameplayTimeInstance.Has(this.DelayPushCameraHandleTimerId))
		{
			return;
		}
		TimerSystem.GameplayTimeInstance.Remove(this.DelayPushCameraHandleTimerId);
		this.DelayViewName = null;
		this.DelayViewId = null;
		this.DelayPushCameraHandleTimerId = null;
	}

	// Token: 0x06016A5B RID: 92763 RVA: 0x00649B90 File Offset: 0x00647D90
	private void OnUiCameraDelayFinished(float delta)
	{
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByOpenView(this.DelayViewName, this.DelayViewId, true);
		this.ResetDelayPush();
	}

	// Token: 0x06016A5C RID: 92764 RVA: 0x00649BAF File Offset: 0x00647DAF
	private void OnBeforeLoadMap()
	{
		Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
	}

	// Token: 0x06016A5D RID: 92765 RVA: 0x00649BBB File Offset: 0x00647DBB
	private void OnResetCameraByResetToBattleView()
	{
		this.ResetDelayPush();
		Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
	}

	// Token: 0x06016A5E RID: 92766 RVA: 0x00649BEB File Offset: 0x00647DEB
	private void OnActiveBattleView()
	{
		this.ResetDelayPush();
	}

	// Token: 0x06016A5F RID: 92767 RVA: 0x00649BF3 File Offset: 0x00647DF3
	private void OnDestroyAllUiCameraAnimationHandles()
	{
		this.ResetDelayPush();
		Singleton<UiCameraAnimationManager>.Instance.ClearDisplay();
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Widget, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
	}

	// Token: 0x06016A60 RID: 92768 RVA: 0x00649C24 File Offset: 0x00647E24
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return;
		}
		if (handle.Id != getCurrentEntity.Id)
		{
			return;
		}
		Singleton<UiCameraAnimationManager>.Instance.DeactivateCurrentCameraHandle();
	}

	// Token: 0x06016A61 RID: 92769 RVA: 0x00649C5C File Offset: 0x00647E5C
	private void OnAddEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return;
		}
		if (handle.Id != getCurrentEntity.Id)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "当玩家角色添加实体时,重新激活镜头状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiCameraAnimationManager>.Instance.ReactivateCameraHandle(false, false);
	}

	// Token: 0x06016A62 RID: 92770 RVA: 0x00649CB0 File Offset: 0x00647EB0
	private void OnRoleSystemChangeRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "当角色系统切换角色时,尝试重新激活镜头状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiCameraAnimationManager>.Instance.ReactivateCameraHandle(false, false);
	}

	// Token: 0x06016A63 RID: 92771 RVA: 0x00649CE8 File Offset: 0x00647EE8
	private void OnRoleMorphTypeChanged()
	{
		Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.LRC, "当角色形态改变时,尝试重新激活镜头状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiCameraAnimationManager>.Instance.ReactivateCameraHandle(false, false);
	}

	// Token: 0x06016A64 RID: 92772 RVA: 0x00649D20 File Offset: 0x00647F20
	private void OnUiSceneLoaded()
	{
		Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "当Ui场景加载完成时,尝试重新激活镜头状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<UiCameraAnimationManager>.Instance.ReactivateCameraHandle(false, false);
	}

	// Token: 0x0400AEC3 RID: 44739
	[Nullable(2)]
	private string DelayViewName = "";

	// Token: 0x0400AEC4 RID: 44740
	private int? DelayViewId;

	// Token: 0x0400AEC5 RID: 44741
	[Nullable(2)]
	private TimerHandle DelayPushCameraHandleTimerId;
}
