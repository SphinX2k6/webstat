using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Enum;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C32 RID: 11314
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiCameraAnimationManager : Singleton<UiCameraAnimationManager>, ITickable
{
	// Token: 0x06016A8C RID: 92812 RVA: 0x0064A8BC File Offset: 0x00648ABC
	public void Initialize()
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("LoadingViewCameraAnimationLength");
		this.LoadingViewCameraAnimationLength = ((intConfig != null) ? new float?((float)intConfig.GetValueOrDefault()) : null);
		this.LoadingViewManualFocusDistance = ConfigCommonParamById.GetFloatConfig("LoadingViewManualFocusDistance");
		this.LoadingViewAperture = ConfigCommonParamById.GetFloatConfig("LoadingViewAperture");
		this.InitializeUiCameraMappingData();
		this.InitializeTargetTypeMap();
	}

	// Token: 0x06016A8D RID: 92813 RVA: 0x0064A927 File Offset: 0x00648B27
	public void Clear()
	{
		this.ClearDisplay();
		this.ClearUiCameraMappingData();
		this.TargetTypeMap.Clear();
	}

	// Token: 0x06016A8E RID: 92814 RVA: 0x0064A940 File Offset: 0x00648B40
	private void InitializeUiCameraMappingData()
	{
		foreach (UiCameraMapping config in ConfigBase<UiCameraAnimationConfig>.Instance.GetAllUiCameraMappingConfig())
		{
			UiCameraMappingData value = new UiCameraMappingData(config);
			this.CameraMappingDataMap.Add(config.ViewName, value);
		}
		foreach (ChildUiCameraMapping config2 in ConfigBase<UiCameraAnimationConfig>.Instance.GetAllChildUiCameraMappingConfig())
		{
			UiCameraMappingData value2 = new UiCameraMappingData(config2);
			this.CameraMappingDataMap.Add(config2.ViewName, value2);
		}
	}

	// Token: 0x06016A8F RID: 92815 RVA: 0x0064A9FC File Offset: 0x00648BFC
	private void InitializeTargetTypeMap()
	{
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.Player, new UiCameraTargetTypePlayer());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.Npc, new UiCameraTargetTypeNpc());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiSceneRole, new UiCameraTargetTypeUiSceneRole());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiSceneSkeletal, new UiCameraTargetTypeUiSceneSkeletal());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiVisionHandBook, new UiCameraTargetTypeUiVisionHandBook());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiGlider, new UiCameraTargetTypeUiGlider());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.SailDock, new UiCameraTargetTypeSailDock());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiSceneHulu, new UiCameraTargetTypeUiSceneHulu());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiInfrastructure, new UiCameraTargetTypeUiSceneInfr());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiSceneActor, new UiCameraTargetTypeUiSceneActor());
		this.TargetTypeMap.Add(EUiCameraAnimationTargetType.UiSceneFormationRole, new UiCameraTargetTypeUiSceneFormationRole());
	}

	// Token: 0x06016A90 RID: 92816 RVA: 0x0064AAC7 File Offset: 0x00648CC7
	public void SetDynamicDisablePushCamera(string viewName, bool disable)
	{
		if (disable)
		{
			if (!this.DynamicDisablePushCamera.Contains(viewName))
			{
				this.DynamicDisablePushCamera.Add(viewName);
				return;
			}
		}
		else if (this.DynamicDisablePushCamera.Contains(viewName))
		{
			this.DynamicDisablePushCamera.Remove(viewName);
		}
	}

	// Token: 0x06016A91 RID: 92817 RVA: 0x0064AB03 File Offset: 0x00648D03
	[return: Nullable(2)]
	public UiCameraMappingData GetCameraMappingData(string viewName)
	{
		if (this.DynamicDisablePushCamera.Contains(viewName))
		{
			return null;
		}
		return this.CameraMappingDataMap.GetValueOrDefault(viewName);
	}

	// Token: 0x06016A92 RID: 92818 RVA: 0x0064AB21 File Offset: 0x00648D21
	private void ClearUiCameraMappingData()
	{
		this.CameraMappingDataMap.Clear();
	}

	// Token: 0x06016A93 RID: 92819 RVA: 0x0064AB2E File Offset: 0x00648D2E
	private void PushHandleData(UiCameraHandleData handleData)
	{
		this.HandleDataStack.Push(handleData);
	}

	// Token: 0x06016A94 RID: 92820 RVA: 0x0064AB3C File Offset: 0x00648D3C
	private UiCameraHandleData PopHandleData(UiCameraHandleData handleData)
	{
		UiCameraHandleData uiCameraHandleData = this.HandleDataStack.Peek();
		int uniqueId = handleData.UniqueId;
		while (uiCameraHandleData != null && uiCameraHandleData.UniqueId != uniqueId)
		{
			this.HandleDataStack.Pop();
			uiCameraHandleData = (this.HandleDataStack.Any<UiCameraHandleData>() ? this.HandleDataStack.Peek() : null);
		}
		this.HandleDataStack.Pop();
		return this.GetLastHandleData();
	}

	// Token: 0x06016A95 RID: 92821 RVA: 0x0064ABA4 File Offset: 0x00648DA4
	private bool DeleteHandleDataByVieId(int viewId)
	{
		UiCameraHandleData handleDataByViewId = this.GetHandleDataByViewId(viewId);
		if (handleDataByViewId == null)
		{
			return false;
		}
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(handleDataByViewId.OwnerViewName);
		List<UiCameraHandleData> list = new List<UiCameraHandleData>();
		bool flag = false;
		foreach (UiCameraHandleData uiCameraHandleData in this.HandleDataStack)
		{
			if (uiCameraHandleData.UniqueId == viewId)
			{
				list.Add(uiCameraHandleData);
				flag = true;
			}
			else if (flag)
			{
				if (!this.IsDynamicTabListContainView(viewTabList, uiCameraHandleData.OwnerViewName) && !(handleDataByViewId.OwnerViewName == uiCameraHandleData.OwnerViewName))
				{
					break;
				}
				list.Add(uiCameraHandleData);
			}
		}
		foreach (UiCameraHandleData element in list)
		{
			this.HandleDataStack.Delete(element);
		}
		return true;
	}

	// Token: 0x06016A96 RID: 92822 RVA: 0x0064ACA4 File Offset: 0x00648EA4
	private bool IsDynamicTabListContainView(List<UiDynamicTab> uiDynamicTabList, string tabViewName)
	{
		foreach (UiDynamicTab uiDynamicTab in uiDynamicTabList)
		{
			if (uiDynamicTab.ChildViewName == tabViewName)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016A97 RID: 92823 RVA: 0x0064AD04 File Offset: 0x00648F04
	[NullableContext(2)]
	private UiCameraHandleData GetHandleDataByViewId(int viewId)
	{
		foreach (UiCameraHandleData uiCameraHandleData in this.HandleDataStack)
		{
			if (uiCameraHandleData.UniqueId == viewId)
			{
				return uiCameraHandleData;
			}
		}
		return null;
	}

	// Token: 0x06016A98 RID: 92824 RVA: 0x0064AD5C File Offset: 0x00648F5C
	[NullableContext(2)]
	public UiCameraHandleData GetLastHandleData()
	{
		if (!this.HandleDataStack.Any<UiCameraHandleData>())
		{
			return null;
		}
		return this.HandleDataStack.Peek();
	}

	// Token: 0x06016A99 RID: 92825 RVA: 0x0064AD78 File Offset: 0x00648F78
	public UiCameraAnimationHandle NewCameraHandle()
	{
		UiCameraAnimationHandle uiCameraAnimationHandle = new UiCameraAnimationHandle();
		uiCameraAnimationHandle.Initialize();
		return uiCameraAnimationHandle;
	}

	// Token: 0x06016A9A RID: 92826 RVA: 0x0064AD85 File Offset: 0x00648F85
	public void ActivateCameraHandle(UiCameraHandleData handleData, bool bBlend = true, bool bPlayBlendInSequence = true)
	{
		if (this.CurrentCameraHandle != null)
		{
			this.CurrentCameraHandle.Deactivate();
		}
		else
		{
			this.CurrentCameraHandle = this.NewCameraHandle();
		}
		this.CurrentCameraHandle.Activate(handleData, bBlend, bPlayBlendInSequence);
	}

	// Token: 0x06016A9B RID: 92827 RVA: 0x0064ADB8 File Offset: 0x00648FB8
	private void ActivateCameraHandleWaitAnimation(UiCameraHandleData handleData, bool bBlend = true, bool bPlayBlendInSequence = true)
	{
		if (this.IsPlayingAnimation())
		{
			this.CurrentUiCameraAnimation.WaitCameraAnimationFinished().ContinueWith(delegate(UiCameraAnimationDefine.IFinishData finishData)
			{
				if (finishData.FinishType == UiCameraAnimationDefine.ECameraAnimationFinishType.Finished)
				{
					this.ActivateCameraHandle(handleData, bBlend, bPlayBlendInSequence);
				}
			});
			return;
		}
		this.ActivateCameraHandle(handleData, bBlend, bPlayBlendInSequence);
	}

	// Token: 0x06016A9C RID: 92828 RVA: 0x0064AE28 File Offset: 0x00649028
	public unsafe void PushCameraHandleByOpenView(string viewName, int? viewId = null, bool bBlend = true)
	{
		if (!this.CanPushCameraHandle(viewName))
		{
			return;
		}
		UiCameraHandleData lastHandleData = this.GetLastHandleData();
		if (lastHandleData != null)
		{
			if (!(lastHandleData.ViewName == viewName))
			{
				int uniqueId = lastHandleData.UniqueId;
				int? num = viewId;
				if (!(uniqueId == num.GetValueOrDefault() & num != null))
				{
					goto IL_A5;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "此界面已经在栈顶";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PushHandleData", (lastHandleData != null) ? lastHandleData.ToString() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("viewId", viewId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		IL_A5:
		if (viewId != null)
		{
			UiCameraHandleData handleDataByViewId = this.GetHandleDataByViewId(viewId.Value);
			if (handleDataByViewId != null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.CameraAnimation;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "此界面已经入栈,直接返回";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PushHandleData", handleDataByViewId.ToString());
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
		}
		UiCameraHandleData newHandleData = UiCameraHandleData.NewByView(viewName, viewId, null);
		string blendName = null;
		string text = (lastHandleData != null) ? lastHandleData.ViewName : null;
		if (!string.IsNullOrEmpty(text))
		{
			blendName = this.GetBlendName(text, viewName);
		}
		this.PushCameraHandle(newHandleData, bBlend, true, blendName, true, null);
	}

	// Token: 0x06016A9D RID: 92829 RVA: 0x0064AF64 File Offset: 0x00649164
	public unsafe UiCameraHandleData PushCameraHandleByHandleName(string handleName, bool bBlend = true, bool bPlayBlendInSequence = true, string blendName = "1001", bool bCheckSameHandleData = false, Action<UiCameraAnimationDefine.IFinishData> cameraAnimationFinishedCallback = null, FTransformDouble? externalTransformInternal = null)
	{
		if (StringUtils.IsBlank(handleName))
		{
			Singleton<Log>.Instance.Error(ELogModule.CameraAnimation, ELogAuthor.BB, "镜头动画的HandleName为空，镜头动画异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		UiCameraHandleData uiCameraHandleData = UiCameraHandleData.NewByHandleName(handleName, externalTransformInternal);
		UiCameraHandleData lastHandleData = this.GetLastHandleData();
		if (lastHandleData != null)
		{
			string viewName = lastHandleData.ViewName;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "手动播放镜头动画，将镜头数据的ViewName设置为栈顶的数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("HandleName", handleName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", viewName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			uiCameraHandleData.ViewName = viewName;
			uiCameraHandleData.OwnerViewName = lastHandleData.OwnerViewName;
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "手动播放镜头动画时，当前没有播放任何Ui镜头状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("HandleName", handleName);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.PushCameraHandle(uiCameraHandleData, bBlend, bPlayBlendInSequence, blendName, bCheckSameHandleData, cameraAnimationFinishedCallback);
		return uiCameraHandleData;
	}

	// Token: 0x06016A9E RID: 92830 RVA: 0x0064B054 File Offset: 0x00649254
	public unsafe void PushCameraHandle(UiCameraHandleData newHandleData, bool bBlend = true, bool bPlayBlendInSequence = true, string blendName = null, bool bCheckSameHandleData = false, Action<UiCameraAnimationDefine.IFinishData> cameraAnimationFinishedCallback = null)
	{
		UiCameraHandleData lastHandleData = this.GetLastHandleData();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "镜头状态数据------入栈";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PushHandleData", newHandleData.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LastTopHandleData", (lastHandleData != null) ? lastHandleData.ToString() : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (bCheckSameHandleData && this.TryRefreshSameHandleData(newHandleData))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "镜头状态数据------新的镜头状态和旧的镜头状态一致，不会再次播放推入镜头状态表现";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item = "CurrentHandleData";
			UiCameraAnimationHandle currentCameraHandle = this.CurrentCameraHandle;
			ptr = new ValueTuple<string, object>(item, (currentCameraHandle != null) ? currentCameraHandle.GetHandleData().ToString() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("NewHandleData", newHandleData.ToString());
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		this.PushHandleData(newHandleData);
		this.StopUiCameraAnimation();
		this.PlayCameraHandle(newHandleData, lastHandleData, bBlend, bPlayBlendInSequence, blendName, cameraAnimationFinishedCallback);
	}

	// Token: 0x06016A9F RID: 92831 RVA: 0x0064B164 File Offset: 0x00649364
	public unsafe void PopCameraHandleByCloseView(string closeViewName, string toViewName, int closeViewId, bool popOrDelete = true)
	{
		if (!this.CanPushCameraHandle(closeViewName))
		{
			return;
		}
		UiCameraHandleData handleDataByViewId = this.GetHandleDataByViewId(closeViewId);
		if (popOrDelete || (handleDataByViewId != null && this.HandleDataStack.Count<UiCameraHandleData>() <= 1))
		{
			string blendName = this.GetBlendName(closeViewName, toViewName);
			this.PopCameraHandle(handleDataByViewId, blendName);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "仅删除镜头状态，不做任何表现";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("closeViewName", closeViewName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("closeViewId", closeViewId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.DeleteHandleDataByVieId(closeViewId);
	}

	// Token: 0x06016AA0 RID: 92832 RVA: 0x0064B20C File Offset: 0x0064940C
	public unsafe void PopCameraHandle(UiCameraHandleData popHandleData, string blendName = null)
	{
		if (popHandleData == null)
		{
			this.ClearDisplay();
			return;
		}
		UiCameraHandleData lastHandleData = this.GetLastHandleData();
		UiCameraHandleData uiCameraHandleData = this.PopHandleData(popHandleData);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "镜头状态数据------出栈";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("popHandleData", popHandleData.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TopHandleData", (uiCameraHandleData != null) ? uiCameraHandleData.ToString() : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendName", blendName);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.RefreshHandleDataByMappingData(uiCameraHandleData);
		this.StopUiCameraAnimation();
		this.PlayCameraHandle(uiCameraHandleData, lastHandleData, blendName != null, true, blendName, null);
	}

	// Token: 0x06016AA1 RID: 92833 RVA: 0x0064B2CC File Offset: 0x006494CC
	private void RefreshHandleDataByMappingData(UiCameraHandleData handleData)
	{
		if (handleData == null)
		{
			return;
		}
		string viewName = handleData.ViewName;
		if (StringUtils.IsEmpty(viewName))
		{
			return;
		}
		UiCameraMappingData cameraMappingData = this.GetCameraMappingData(viewName);
		UiCameraAnimationDefine.IUiCameraMapping uiCameraMapping = (cameraMappingData != null) ? cameraMappingData.GetUiCameraMappingConfig() : null;
		if (cameraMappingData == null || (uiCameraMapping != null && uiCameraMapping.BodyTargetType == 0))
		{
			return;
		}
		if (cameraMappingData.GetTargetBodyKey() != null)
		{
			handleData.HandleName = cameraMappingData.GetSourceHandleName();
		}
		handleData.Refresh();
	}

	// Token: 0x06016AA2 RID: 92834 RVA: 0x0064B32C File Offset: 0x0064952C
	private bool TryRefreshSameHandleData(UiCameraHandleData newHandleData)
	{
		if (this.CurrentCameraHandle == null)
		{
			return false;
		}
		UiCameraHandleData uiCameraHandleData = this.HandleDataStack.Any<UiCameraHandleData>() ? this.HandleDataStack.Peek() : null;
		if (uiCameraHandleData == null)
		{
			return false;
		}
		UiCamera uiCamera = this.UiCamera;
		if (uiCamera == null || !uiCamera.GetIsEntered())
		{
			return false;
		}
		if (!uiCameraHandleData.IsEqual(newHandleData))
		{
			return false;
		}
		this.CurrentCameraHandle.SetHandleData(newHandleData);
		return true;
	}

	// Token: 0x06016AA3 RID: 92835 RVA: 0x0064B398 File Offset: 0x00649598
	private unsafe UiCameraAnimationDefine.EPlayCameraHandleResult PlayCameraHandle(UiCameraHandleData toHandleData = null, UiCameraHandleData fromHandleData = null, bool bBlend = true, bool bPlayBlendInSequence = true, string blendName = null, Action<UiCameraAnimationDefine.IFinishData> cameraAnimationFinishedCallback = null)
	{
		this.UiCamera = UiCameraManager.Get();
		this.UiCameraPostEffectComponent = this.UiCamera.GetUiCameraComponent<UiCameraPostEffectComponent>();
		this.UiCameraSequenceComponent = this.UiCamera.GetUiCameraComponent<UiCameraSequenceComponent>();
		if (this.CurrentPopCameraHandle != null)
		{
			this.CurrentPopCameraHandle.StopSequence();
			this.CurrentPopCameraHandle = null;
			this.UiCamera.Exit(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f);
		}
		if (toHandleData == null)
		{
			UiCameraAnimationHandle currentCameraHandle = this.GetCurrentCameraHandle();
			if (currentCameraHandle != null)
			{
				this.CurrentPopCameraHandle = currentCameraHandle;
				currentCameraHandle.Revert(true, new Action(this.ClearDisplay));
			}
			else
			{
				this.ClearDisplay();
			}
			return UiCameraAnimationDefine.EPlayCameraHandleResult.RevertAnimation;
		}
		toHandleData.Refresh();
		this.TryPushCameraSpringStructure(toHandleData);
		if (string.IsNullOrEmpty(blendName))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "镜头状态数据------入栈是BlendName为空，直接激活镜头状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PushHandleData", toHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendName", blendName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.ActivateCameraHandleWaitAnimation(toHandleData, bBlend, bPlayBlendInSequence);
			return UiCameraAnimationDefine.EPlayCameraHandleResult.Activate;
		}
		if (fromHandleData == null)
		{
			this.ActivateCameraHandleWaitAnimation(toHandleData, bBlend, bPlayBlendInSequence);
			return UiCameraAnimationDefine.EPlayCameraHandleResult.Activate;
		}
		if (!bBlend)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "镜头状态数据------不需要播放镜头动画，直接激活镜头状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("LastHandleData", fromHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PushHandleData", toHandleData.ToString());
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.ActivateCameraHandle(toHandleData, false, false);
			return UiCameraAnimationDefine.EPlayCameraHandleResult.Activate;
		}
		SUiCameraAnimationBlendSettings uiCameraAnimationBlendData = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraAnimationBlendData(blendName);
		if (uiCameraAnimationBlendData == null || uiCameraAnimationBlendData.Time <= 0f)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.CameraAnimation;
			ELogAuthor author3 = ELogAuthor.BB;
			string message3 = "没有混合配置或播放界面摄像机动画时间<=0，直接激活镜头";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("blendName", blendName);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ActivateCameraHandle(toHandleData, false, false);
			return UiCameraAnimationDefine.EPlayCameraHandleResult.Activate;
		}
		this.AsyncPlayCameraAnimation(fromHandleData, toHandleData, blendName).ContinueWith(delegate(UiCameraAnimationDefine.IFinishData finishData)
		{
			this.OnPlayCameraAnimationFinish(finishData, cameraAnimationFinishedCallback);
		});
		return UiCameraAnimationDefine.EPlayCameraHandleResult.PlayAnimation;
	}

	// Token: 0x06016AA4 RID: 92836 RVA: 0x0064B5B4 File Offset: 0x006497B4
	private void TryPushCameraSpringStructure(UiCameraHandleData toHandleData)
	{
		if ((this.UiCameraSpringStructure == null || !this.UiCameraSpringStructure.IsValid()) && !toHandleData.IsEmptyState)
		{
			this.UiCameraSpringStructure = this.UiCamera.PushStructure<UiCameraSpringStructure>();
		}
	}

	// Token: 0x06016AA5 RID: 92837 RVA: 0x0064B5E4 File Offset: 0x006497E4
	private unsafe void OnPlayCameraAnimationFinish(UiCameraAnimationDefine.IFinishData finishData, Action<UiCameraAnimationDefine.IFinishData> cameraAnimationFinishedCallback = null)
	{
		UiCameraHandleData fromHandleData = finishData.FromHandleData;
		UiCameraHandleData toHandleData = finishData.ToHandleData;
		if (finishData.FinishType == UiCameraAnimationDefine.ECameraAnimationFinishType.Finished)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "镜头状态数据------入栈动画结束";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastHandleData", fromHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PushHandleData", toHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FinishType", finishData.FinishType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.ActivateCameraHandle(toHandleData, false, false);
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CameraAnimation;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "镜头状态数据------入栈动画被停止";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("LastHandleData", fromHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PushHandleData", toHandleData.ToString());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("FinishType", finishData.FinishType);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		if (cameraAnimationFinishedCallback != null)
		{
			cameraAnimationFinishedCallback(finishData);
		}
		Singleton<EventSystem>.Instance.Emit<UiCameraAnimationDefine.IFinishData>(EEventName.OnPlayCameraAnimationFinish, finishData);
	}

	// Token: 0x06016AA6 RID: 92838 RVA: 0x0064B730 File Offset: 0x00649930
	public bool CanPushCameraHandle(string viewName)
	{
		UiCameraMappingData cameraMappingData = this.GetCameraMappingData(viewName);
		return cameraMappingData != null && cameraMappingData.CanPushCameraHandle();
	}

	// Token: 0x06016AA7 RID: 92839 RVA: 0x0064B750 File Offset: 0x00649950
	public void ReactivateCameraHandle(bool bBlend = false, bool bPlayBlendInSequence = false)
	{
		if (this.CurrentCameraHandle == null)
		{
			return;
		}
		if (this.CurrentCameraHandle.GetIsPendingRevert())
		{
			return;
		}
		UiCameraHandleData handleData = this.CurrentCameraHandle.GetHandleData();
		if (handleData == null)
		{
			return;
		}
		string viewName = handleData.ViewName;
		if (!StringUtils.IsEmpty(viewName))
		{
			UiCameraMappingData cameraMappingData = this.GetCameraMappingData(viewName);
			if (cameraMappingData != null)
			{
				if (cameraMappingData.GetTargetBodyKey() != null)
				{
					handleData.HandleName = cameraMappingData.GetSourceHandleName();
				}
				handleData.Refresh();
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "重新激活镜头状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handleData", handleData.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.CurrentCameraHandle.Activate(handleData, bBlend, bPlayBlendInSequence);
	}

	// Token: 0x06016AA8 RID: 92840 RVA: 0x0064B7F2 File Offset: 0x006499F2
	public void DeactivateCurrentCameraHandle()
	{
		if (this.CurrentCameraHandle == null)
		{
			return;
		}
		this.CurrentCameraHandle.Deactivate();
	}

	// Token: 0x06016AA9 RID: 92841 RVA: 0x0064B808 File Offset: 0x00649A08
	public UiCameraAnimationHandle GetCurrentCameraHandle()
	{
		return this.CurrentCameraHandle;
	}

	// Token: 0x06016AAA RID: 92842 RVA: 0x0064B810 File Offset: 0x00649A10
	public string GetBlendName(string fromViewName, string toViewName)
	{
		UiCameraMappingData cameraMappingData = this.GetCameraMappingData(fromViewName);
		if (cameraMappingData == null)
		{
			return null;
		}
		return cameraMappingData.GetToBlendName(toViewName);
	}

	// Token: 0x06016AAB RID: 92843 RVA: 0x0064B831 File Offset: 0x00649A31
	public bool IsPlayingAnimation()
	{
		return this.CurrentUiCameraAnimation != null && this.CurrentUiCameraAnimation.IsPlaying();
	}

	// Token: 0x06016AAC RID: 92844 RVA: 0x0064B848 File Offset: 0x00649A48
	public bool IsPlayingBlendInSequence()
	{
		return this.CurrentCameraHandle != null && this.CurrentCameraHandle.GetIsPlayingBlendInSequence();
	}

	// Token: 0x06016AAD RID: 92845 RVA: 0x0064B860 File Offset: 0x00649A60
	public void ClearDisplay()
	{
		this.StopUiCameraAnimation();
		this.ResetPlayerHiddenDisplay();
		UiCameraManager.Destroy(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f);
		foreach (UiCameraHandleData uiCameraHandleData in this.HandleDataStack)
		{
			uiCameraHandleData.Reset();
		}
		this.HandleDataStack.Clear();
		UiCameraAnimationHandle currentCameraHandle = this.CurrentCameraHandle;
		if (currentCameraHandle != null)
		{
			currentCameraHandle.Reset();
		}
		this.UiCamera = null;
		this.UiCameraSpringStructure = null;
		this.UiCameraPostEffectComponent = null;
		this.CurrentCameraHandle = null;
		this.CurrentPopCameraHandle = null;
		this.PlayerActorDisableHandleIdMap.Clear();
		this.CustomCreatureActorHandleIdMap.Clear();
	}

	// Token: 0x06016AAE RID: 92846 RVA: 0x0064B91C File Offset: 0x00649B1C
	public int GenerateHandleDataUniqueId()
	{
		int handleDataUniqueId = this.HandleDataUniqueId;
		this.HandleDataUniqueId = handleDataUniqueId + 1;
		return handleDataUniqueId;
	}

	// Token: 0x06016AAF RID: 92847 RVA: 0x0064B93C File Offset: 0x00649B3C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<UiCameraAnimationDefine.IFinishData> AsyncPlayCameraAnimation(UiCameraHandleData fromHandleData, UiCameraHandleData toHandleData, string blendName)
	{
		UiCameraAnimationManager.<AsyncPlayCameraAnimation>d__53 <AsyncPlayCameraAnimation>d__;
		<AsyncPlayCameraAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiCameraAnimationDefine.IFinishData>.Create();
		<AsyncPlayCameraAnimation>d__.<>4__this = this;
		<AsyncPlayCameraAnimation>d__.fromHandleData = fromHandleData;
		<AsyncPlayCameraAnimation>d__.toHandleData = toHandleData;
		<AsyncPlayCameraAnimation>d__.blendName = blendName;
		<AsyncPlayCameraAnimation>d__.<>1__state = -1;
		<AsyncPlayCameraAnimation>d__.<>t__builder.Start<UiCameraAnimationManager.<AsyncPlayCameraAnimation>d__53>(ref <AsyncPlayCameraAnimation>d__);
		return <AsyncPlayCameraAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06016AB0 RID: 92848 RVA: 0x0064B998 File Offset: 0x00649B98
	public UiCameraHandleData PlayCameraAnimationFromCurrent(string toHandleName, string blendName)
	{
		UiCameraHandleData lastHandleData = this.GetLastHandleData();
		this.PushCameraHandleByHandleName(toHandleName, true, true, blendName, false, null, null);
		return lastHandleData;
	}

	// Token: 0x06016AB1 RID: 92849 RVA: 0x0064B9C4 File Offset: 0x00649BC4
	public void PlayBackCurrent(string blendName = "1001")
	{
		UiCameraAnimationManager.<>c__DisplayClass55_0 CS$<>8__locals1 = new UiCameraAnimationManager.<>c__DisplayClass55_0();
		CS$<>8__locals1.<>4__this = this;
		UiCameraAnimationManager.<>c__DisplayClass55_0 CS$<>8__locals2 = CS$<>8__locals1;
		UiCameraAnimationHandle currentCameraHandle = this.CurrentCameraHandle;
		CS$<>8__locals2.currentHandleData = ((currentCameraHandle != null) ? currentCameraHandle.GetHandleData() : null);
		if (CS$<>8__locals1.currentHandleData == null)
		{
			return;
		}
		SUiCameraAnimationBlendSettings uiCameraAnimationBlendData = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraAnimationBlendData(blendName);
		if (uiCameraAnimationBlendData == null || uiCameraAnimationBlendData.Time <= 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CameraAnimation;
			ELogAuthor author = ELogAuthor.BB;
			string message = "没有混合配置或播放界面摄像机动画时间<=0，直接激活镜头";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("blendName", blendName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ActivateCameraHandle(CS$<>8__locals1.currentHandleData, false, false);
			return;
		}
		this.AsyncPlayCameraAnimation(CS$<>8__locals1.currentHandleData, CS$<>8__locals1.currentHandleData, blendName).ContinueWith(delegate(UiCameraAnimationDefine.IFinishData finishData)
		{
			if (finishData.FinishType == UiCameraAnimationDefine.ECameraAnimationFinishType.Finished)
			{
				CS$<>8__locals1.<>4__this.ActivateCameraHandle(CS$<>8__locals1.currentHandleData, true, true);
			}
		});
	}

	// Token: 0x06016AB2 RID: 92850 RVA: 0x0064BA7C File Offset: 0x00649C7C
	public void StopUiCameraAnimation()
	{
		if (this.CurrentUiCameraAnimation == null)
		{
			return;
		}
		this.CurrentUiCameraAnimation.StopUiCameraAnimation();
		this.CurrentUiCameraAnimation = null;
	}

	// Token: 0x06016AB3 RID: 92851 RVA: 0x0064BA9C File Offset: 0x00649C9C
	public void Tick(float delta)
	{
		float delta2 = delta * Singleton<Time>.Instance.InverseSelfCenteredTimeDilation;
		if (this.CurrentUiCameraAnimation != null)
		{
			this.CurrentUiCameraAnimation.Tick(delta2);
		}
		if (this.CurrentCameraHandle != null)
		{
			this.CurrentCameraHandle.Tick(delta2);
		}
	}

	// Token: 0x06016AB4 RID: 92852 RVA: 0x0064BADE File Offset: 0x00649CDE
	public void BroadUiCameraSequenceEvent(string sequenceEventName)
	{
		UiCameraManager.Get().GetUiCameraComponent<UiCameraSequenceComponent>().ExecuteUiCameraSequenceEvent(sequenceEventName);
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnExecuteUiCameraSequenceEvent, sequenceEventName);
	}

	// Token: 0x06016AB5 RID: 92853 RVA: 0x0064BB01 File Offset: 0x00649D01
	public bool IsActivate()
	{
		return this.HandleDataStack.Any<UiCameraHandleData>();
	}

	// Token: 0x06016AB6 RID: 92854 RVA: 0x0064BB0E File Offset: 0x00649D0E
	public global::Stack<UiCameraHandleData> GetHandleDataStack()
	{
		return this.HandleDataStack;
	}

	// Token: 0x06016AB7 RID: 92855 RVA: 0x0064BB18 File Offset: 0x00649D18
	public AActor GetTargetActor(EUiCameraAnimationTargetType targetType, SUiCameraAnimationSettings config)
	{
		UiCameraTargetTypeBase uiCameraTargetTypeBase;
		if (this.TargetTypeMap.TryGetValue(targetType, out uiCameraTargetTypeBase))
		{
			return uiCameraTargetTypeBase.GetTargetActor(config);
		}
		return null;
	}

	// Token: 0x06016AB8 RID: 92856 RVA: 0x0064BB40 File Offset: 0x00649D40
	public string GetTargetBodyKey(EUiCameraAnimationTargetType targetType)
	{
		UiCameraTargetTypeBase uiCameraTargetTypeBase;
		if (this.TargetTypeMap.TryGetValue(targetType, out uiCameraTargetTypeBase))
		{
			return uiCameraTargetTypeBase.GetTargetBodyKey();
		}
		return null;
	}

	// Token: 0x06016AB9 RID: 92857 RVA: 0x0064BB68 File Offset: 0x00649D68
	public USkeletalMeshComponent GetTargetActorSkeletalMesh(EUiCameraAnimationTargetType targetType, SUiCameraAnimationSettings config)
	{
		UiCameraTargetTypeBase uiCameraTargetTypeBase;
		if (this.TargetTypeMap.TryGetValue(targetType, out uiCameraTargetTypeBase))
		{
			return uiCameraTargetTypeBase.GetTargetSkeletalMesh(config);
		}
		return null;
	}

	// Token: 0x06016ABA RID: 92858 RVA: 0x0064BB8E File Offset: 0x00649D8E
	private void ResetPlayerHiddenDisplay()
	{
		this.EnablePlayerActor();
		this.EnableCustomCreatureActor();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return;
		}
		baseCharacter.SetDitherEffect(1f, ECharacterDitherType.Sequence);
	}

	// Token: 0x06016ABB RID: 92859 RVA: 0x0064BBB4 File Offset: 0x00649DB4
	public unsafe void DisablePlayerActor()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "Ui镜头隐藏玩家Actor-失败，因为找不到当前玩家EntityHandle", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		WorldEntity entity = getCurrentEntity.Entity;
		if (entity == null || !entity.Valid)
		{
			Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "Ui镜头隐藏玩家Actor-失败，因为找不到当前玩家Entity", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.CameraAnimation, ELogAuthor.BB, "Ui镜头隐藏玩家Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component != null)
		{
			int id = entity.Id;
			if (this.PlayerActorDisableHandleIdMap.ContainsKey(id))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CameraAnimation;
				ELogAuthor author = ELogAuthor.BB;
				string message = "已经隐藏过对应的玩家Actor";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlayerActorDisableHandleIdMap", this.PlayerActorDisableHandleIdMap);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			int value = component.DisableActor("Ui镜头Sequence中隐藏角色");
			this.PlayerActorDisableHandleIdMap.Add(id, value);
		}
	}

	// Token: 0x06016ABC RID: 92860 RVA: 0x0064BCE1 File Offset: 0x00649EE1
	public bool IsDisablePlayer()
	{
		return this.IsActivate() && this.PlayerActorDisableHandleIdMap.Count > 0;
	}

	// Token: 0x06016ABD RID: 92861 RVA: 0x0064BCFC File Offset: 0x00649EFC
	public void EnablePlayerActor()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CameraAnimation;
		ELogAuthor author = ELogAuthor.BB;
		string message = "Ui镜头在清理表现时显示玩家Actor";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DisableHandleId", this.PlayerActorDisableHandleIdMap);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (KeyValuePair<int, int> keyValuePair in this.PlayerActorDisableHandleIdMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			Entity entity = Singleton<EntitySystem>.Instance.Get(key);
			if (entity == null || !entity.Valid)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.CameraAnimation;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "Ui镜头在清理表现时显示玩家Actor-失败，因为找不到当前玩家Entity";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", key);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			if (component != null)
			{
				component.EnableActor(value);
			}
			else
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.CameraAnimation;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "Ui镜头在清理表现时显示玩家Actor-失败，因为当前玩家实体找不到BaseActorComponent";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("EntityId", key);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
		}
		this.PlayerActorDisableHandleIdMap.Clear();
	}

	// Token: 0x06016ABE RID: 92862 RVA: 0x0064BE28 File Offset: 0x0064A028
	public void DisableCustomCreatureActor(int position)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return;
		}
		CreatureDataComponent component = getCurrentEntity.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		IList<long> customServerEntityIds = component.CustomServerEntityIds;
		if (position > customServerEntityIds.Count || position == 0)
		{
			return;
		}
		int id = getCurrentEntity.Entity.Id;
		long creatureDataId = customServerEntityIds[position - 1];
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		BaseActorComponent component2 = entity.Entity.GetComponent<BaseActorComponent>();
		if (component2 == null)
		{
			return;
		}
		Dictionary<int, int> dictionary;
		if (!this.CustomCreatureActorHandleIdMap.TryGetValue(id, out dictionary))
		{
			dictionary = new Dictionary<int, int>();
			this.CustomCreatureActorHandleIdMap.Add(id, dictionary);
		}
		if (!dictionary.ContainsKey(position))
		{
			int value = component2.DisableActor("Ui镜头Sequence中隐藏角色伴生物");
			dictionary.Add(position, value);
		}
	}

	// Token: 0x06016ABF RID: 92863 RVA: 0x0064BF00 File Offset: 0x0064A100
	public void EnableCustomCreatureActor()
	{
		foreach (KeyValuePair<int, Dictionary<int, int>> keyValuePair in this.CustomCreatureActorHandleIdMap)
		{
			int key = keyValuePair.Key;
			Dictionary<int, int> value = keyValuePair.Value;
			Entity entity = Singleton<EntitySystem>.Instance.Get(key);
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent == null)
			{
				return;
			}
			IList<long> customServerEntityIds = creatureDataComponent.CustomServerEntityIds;
			foreach (KeyValuePair<int, int> keyValuePair2 in value)
			{
				int key2 = keyValuePair2.Key;
				int value2 = keyValuePair2.Value;
				long creatureDataId = customServerEntityIds[key2 - 1];
				EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
				if (entity2 == null)
				{
					return;
				}
				BaseActorComponent component = entity2.Entity.GetComponent<BaseActorComponent>();
				if (component == null)
				{
					return;
				}
				component.EnableActor(value2);
			}
		}
		this.CustomCreatureActorHandleIdMap.Clear();
	}

	// Token: 0x06016AC0 RID: 92864 RVA: 0x0064C024 File Offset: 0x0064A224
	public void ResetFightCameraRotation()
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
		if (logicComponent != null)
		{
			CameraGuideController cameraGuideController = logicComponent.CameraGuideController;
			if (((cameraGuideController != null) ? new bool?(cameraGuideController.IsLockCameraInput()) : null).GetValueOrDefault())
			{
				return;
			}
		}
		logicComponent.SetRotation(CameraUtility.GetCameraDefaultFocusUeRotator());
		logicComponent.ResetFightCameraLogic(false, false);
	}

	// Token: 0x0400AED0 RID: 44752
	private int HandleDataUniqueId;

	// Token: 0x0400AED1 RID: 44753
	private Dictionary<string, UiCameraMappingData> CameraMappingDataMap = new Dictionary<string, UiCameraMappingData>();

	// Token: 0x0400AED2 RID: 44754
	private HashSet<string> DynamicDisablePushCamera = new HashSet<string>();

	// Token: 0x0400AED3 RID: 44755
	private global::Stack<UiCameraHandleData> HandleDataStack = new global::Stack<UiCameraHandleData>();

	// Token: 0x0400AED4 RID: 44756
	public UiCameraAnimationHandle CurrentCameraHandle;

	// Token: 0x0400AED5 RID: 44757
	private UiCameraAnimation CurrentUiCameraAnimation;

	// Token: 0x0400AED6 RID: 44758
	private UiCameraAnimationHandle CurrentPopCameraHandle;

	// Token: 0x0400AED7 RID: 44759
	public float? LoadingViewCameraAnimationLength = new float?(0f);

	// Token: 0x0400AED8 RID: 44760
	public float? LoadingViewManualFocusDistance = new float?(0f);

	// Token: 0x0400AED9 RID: 44761
	public float? LoadingViewAperture;

	// Token: 0x0400AEDA RID: 44762
	private Dictionary<int, int> PlayerActorDisableHandleIdMap = new Dictionary<int, int>();

	// Token: 0x0400AEDB RID: 44763
	private Dictionary<int, Dictionary<int, int>> CustomCreatureActorHandleIdMap = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x0400AEDC RID: 44764
	[Nullable(2)]
	public UiCamera UiCamera;

	// Token: 0x0400AEDD RID: 44765
	public UiCameraSpringStructure UiCameraSpringStructure;

	// Token: 0x0400AEDE RID: 44766
	public UiCameraPostEffectComponent UiCameraPostEffectComponent;

	// Token: 0x0400AEDF RID: 44767
	[Nullable(2)]
	public UiCameraSequenceComponent UiCameraSequenceComponent;

	// Token: 0x0400AEE0 RID: 44768
	public UiCameraDebugTool UiCameraDebugTool;

	// Token: 0x0400AEE1 RID: 44769
	private Dictionary<EUiCameraAnimationTargetType, UiCameraTargetTypeBase> TargetTypeMap = new Dictionary<EUiCameraAnimationTargetType, UiCameraTargetTypeBase>();
}
