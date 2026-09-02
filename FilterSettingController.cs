using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200225D RID: 8797
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FilterSettingController : UiControllerBase<FilterSettingController>
{
	// Token: 0x17001480 RID: 5248
	// (get) Token: 0x06010978 RID: 67960 RVA: 0x00489594 File Offset: 0x00487794
	private float DeadZone
	{
		get
		{
			return ConfigCommonParamById.GetFloatConfig("FilterSettingLeftStickDeadZone").GetValueOrDefault();
		}
	}

	// Token: 0x17001481 RID: 5249
	// (get) Token: 0x06010979 RID: 67961 RVA: 0x004895B4 File Offset: 0x004877B4
	private float MoveFactor
	{
		get
		{
			return ConfigCommonParamById.GetFloatConfig("FilterSettingLeftStickMoveFactor").GetValueOrDefault(1f);
		}
	}

	// Token: 0x0601097A RID: 67962 RVA: 0x004895D8 File Offset: 0x004877D8
	public override bool Clear()
	{
		FilterCameraComponent cameraComponent = this.CameraComponent;
		if (cameraComponent != null)
		{
			cameraComponent.ClosePhotograph();
		}
		return base.Clear();
	}

	// Token: 0x0601097B RID: 67963 RVA: 0x004895F1 File Offset: 0x004877F1
	protected override bool OnLeaveLevel()
	{
		FilterCameraComponent cameraComponent = this.CameraComponent;
		if (cameraComponent != null)
		{
			cameraComponent.ClosePhotograph();
		}
		this.SwitchFilter(true);
		return true;
	}

	// Token: 0x0601097C RID: 67964 RVA: 0x0048960C File Offset: 0x0048780C
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
		Singleton<EventSystem>.Instance.Add(EEventName.UiSceneLastStepInLoadScene, new Action(this.HandleUiSceneLastStepInLoadScene));
		Singleton<EventSystem>.Instance.Add(EEventName.UiSceneLastStepInExitScene, new Action(this.HandleUiSceneLastStepInExitScene));
		Singleton<EventSystem>.Instance.Add(EEventName.LogOut, new Action(this.HandleBackLoginView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnExecuteAfterSetPlotMode, new Action(this.HandlePlotNetworkStart));
		Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.HandlePlotNetworkEnd));
	}

	// Token: 0x0601097D RID: 67965 RVA: 0x004896BC File Offset: 0x004878BC
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
		Singleton<EventSystem>.Instance.Remove(EEventName.UiSceneLastStepInLoadScene, new Action(this.HandleUiSceneLastStepInLoadScene));
		Singleton<EventSystem>.Instance.Remove(EEventName.UiSceneLastStepInExitScene, new Action(this.HandleUiSceneLastStepInExitScene));
		Singleton<EventSystem>.Instance.Remove(EEventName.LogOut, new Action(this.HandleBackLoginView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteAfterSetPlotMode, new Action(this.HandlePlotNetworkStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.HandlePlotNetworkEnd));
		if (this.CameraComponent != null)
		{
			this.CameraComponent.RemoveEntityEvents();
		}
	}

	// Token: 0x0601097E RID: 67966 RVA: 0x0048977C File Offset: 0x0048797C
	private void OnRoleDead(int charId)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FilterSettingView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FilterSettingView, null);
		}
	}

	// Token: 0x0601097F RID: 67967 RVA: 0x0048979F File Offset: 0x0048799F
	private void HandlePlotNetworkStart()
	{
		if (ModelBase<PlotModel>.Instance.IsInOverLevel(EPlotLevel.LevelC))
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 0", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Tonemapper.BrightnessAndTextureDisable 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.BlueLightFilter.Disable 1", null);
		}
	}

	// Token: 0x06010980 RID: 67968 RVA: 0x004897DE File Offset: 0x004879DE
	private void HandlePlotNetworkEnd(PlotResultInfo plotResultInfo)
	{
		if (ModelBase<PlotModel>.Instance.IsInOverLevel(EPlotLevel.LevelC))
		{
			this.SwitchFilter(true);
		}
	}

	// Token: 0x06010981 RID: 67969 RVA: 0x004897F4 File Offset: 0x004879F4
	private void HandleUiSceneLastStepInLoadScene()
	{
		this.DisableFilterTemporarily(true);
	}

	// Token: 0x06010982 RID: 67970 RVA: 0x004897FD File Offset: 0x004879FD
	private void HandleUiSceneLastStepInExitScene()
	{
		this.DisableFilterTemporarily(false);
	}

	// Token: 0x06010983 RID: 67971 RVA: 0x00489806 File Offset: 0x00487A06
	private void HandleBackLoginView()
	{
		this.SwitchFilter(false);
	}

	// Token: 0x06010984 RID: 67972 RVA: 0x00489810 File Offset: 0x00487A10
	[NullableContext(0)]
	public UniTask<bool> TryOpenExternalPreparedAsync()
	{
		FilterSettingController.<TryOpenExternalPreparedAsync>d__16 <TryOpenExternalPreparedAsync>d__;
		<TryOpenExternalPreparedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<TryOpenExternalPreparedAsync>d__.<>4__this = this;
		<TryOpenExternalPreparedAsync>d__.<>1__state = -1;
		<TryOpenExternalPreparedAsync>d__.<>t__builder.Start<FilterSettingController.<TryOpenExternalPreparedAsync>d__16>(ref <TryOpenExternalPreparedAsync>d__);
		return <TryOpenExternalPreparedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010985 RID: 67973 RVA: 0x00489854 File Offset: 0x00487A54
	[NullableContext(0)]
	private UniTask<bool> OpenFilterSettingView()
	{
		FilterSettingController.<OpenFilterSettingView>d__17 <OpenFilterSettingView>d__;
		<OpenFilterSettingView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenFilterSettingView>d__.<>4__this = this;
		<OpenFilterSettingView>d__.<>1__state = -1;
		<OpenFilterSettingView>d__.<>t__builder.Start<FilterSettingController.<OpenFilterSettingView>d__17>(ref <OpenFilterSettingView>d__);
		return <OpenFilterSettingView>d__.<>t__builder.Task;
	}

	// Token: 0x06010986 RID: 67974 RVA: 0x00489898 File Offset: 0x00487A98
	private FilterSettingViewModel BuildFilterSettingViewModel()
	{
		int filterSettingIdCache = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
		FilterSettingViewModel viewModel = new FilterSettingViewModel();
		viewModel.InitFilterIndex = ModelBase<MenuModel>.Instance.GetFilterIndexByConfigId(filterSettingIdCache);
		this.RefreshFilterSettingViewModel(filterSettingIdCache, viewModel);
		viewModel.OnHideClick = delegate()
		{
			viewModel.IsHideByClick = !viewModel.IsHideByClick;
		};
		viewModel.OnResetClick = delegate()
		{
			int filterSettingIdCache2 = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
			float[] array;
			if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterSettingIdCache2, out array) && array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.GetFilterDefaultValue(filterSettingIdCache2, (EFilterSettingValueIndex)i);
				}
				viewModel.IntensityNormalized = this.GetFilterDefaultValue(filterSettingIdCache2, EFilterSettingValueIndex.Intensity);
				viewModel.HorizontalNormalized = this.GetFilterDefaultValue(filterSettingIdCache2, EFilterSettingValueIndex.Horizontal);
				viewModel.VerticalNormalized = this.GetFilterDefaultValue(filterSettingIdCache2, EFilterSettingValueIndex.Vertical);
				viewModel.IsSeniorParamRefresh = true;
				this.SetFilterAllValueImp(viewModel, filterSettingIdCache2, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12]);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GlobalFilterFeatureResetTips", Array.Empty<object>());
				viewModel.IsFilterChanged = true;
			}
		};
		viewModel.OnConfirmClick = delegate()
		{
			LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.FilterSettingId, ModelBase<MenuModel>.Instance.FilterSettingIdCache);
			LocalStorage.SetGlobal<Dictionary<int, float[]>>(ELocalStorageGlobalKey.FilterSettingValues, ModelBase<MenuModel>.Instance.FilterSettingValuesCache);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GlobalFilterFeatureUseTips", Array.Empty<object>());
			viewModel.IsApplyClicked = true;
			ModelBase<MenuModel>.Instance.IsEdited = true;
		};
		Action <>9__23;
		viewModel.OnCloseClick = delegate()
		{
			if (viewModel.IsFilterChanged && !viewModel.IsApplyClicked)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FilterSettingChangingConfirm);
				Dictionary<int, Action> functionMap = confirmBoxDataNew.FunctionMap;
				int key = 2;
				Action value;
				if ((value = <>9__23) == null)
				{
					value = (<>9__23 = delegate()
					{
						this.CloseViewAndReturnWorld().Forget();
					});
				}
				functionMap.Add(key, value);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.CloseViewAndReturnWorld().Forget();
		};
		viewModel.OnPadChanged = delegate()
		{
			if (viewModel.PadLock)
			{
				return;
			}
			int filterSettingIdCache2 = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
			float[] array;
			if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterSettingIdCache2, out array) && array != null)
			{
				array[0] = viewModel.HorizontalNormalized;
				array[1] = viewModel.VerticalNormalized;
				this.SetFilterValueImp(viewModel, filterSettingIdCache2, array[0], array[1], array[2]);
				viewModel.IsHideByPad = true;
				viewModel.IsFilterChanged = true;
			}
		};
		viewModel.OnPadChangeStop = delegate()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			viewModel.IsHideByPad = false;
		};
		viewModel.OnSliderChanged = delegate()
		{
			int filterSettingIdCache2 = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
			float[] array;
			if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterSettingIdCache2, out array) && array != null)
			{
				array[2] = viewModel.IntensityNormalized;
				this.SetFilterValueImp(viewModel, filterSettingIdCache2, array[0], array[1], array[2]);
				viewModel.IsFilterChanged = true;
			}
		};
		viewModel.OnSeniorSliderChanged = delegate(EFilterSettingValueIndex param, float value)
		{
			int filterSettingIdCache2 = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
			float[] array;
			if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterSettingIdCache2, out array) && array != null)
			{
				array[(int)param] = value;
				this.SetFilterAllValueImp(viewModel, filterSettingIdCache2, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12]);
				viewModel.IsFilterChanged = true;
			}
		};
		viewModel.OnViewBeforeCreate = delegate()
		{
		};
		viewModel.OnViewBeforeStart = delegate()
		{
		};
		viewModel.OnViewBeforeShow = delegate(string tag)
		{
		};
		viewModel.OnViewAfterHide = delegate(string tag)
		{
		};
		viewModel.OnViewDestroy = delegate()
		{
			ModelBase<MenuModel>.Instance.CleanFilterCache();
		};
		viewModel.OnDragBegin = delegate()
		{
			FilterCameraComponent cameraComponent = this.CameraComponent;
			if (cameraComponent == null)
			{
				return;
			}
			cameraComponent.OnDragBegin();
		};
		viewModel.OnDragEnded = delegate()
		{
			FilterCameraComponent cameraComponent = this.CameraComponent;
			if (cameraComponent == null)
			{
				return;
			}
			cameraComponent.OnDragEnded();
		};
		viewModel.OnDragMoved = delegate(ULGUIPointerEventData eventData)
		{
			FilterCameraComponent cameraComponent = this.CameraComponent;
			if (cameraComponent == null)
			{
				return;
			}
			cameraComponent.OnDragMoved(eventData);
		};
		viewModel.OnInputUiMoveForward = delegate(string axisName, float value)
		{
			if (!Singleton<Info>.Instance.IsInGamepad() || Singleton<MathUtils>.Instance.InRangeArray((double)value, new double[]
			{
				(double)(-(double)this.DeadZone),
				(double)this.DeadZone
			}) || viewModel.VerticalReal == null || viewModel.IsHideByClick || viewModel.IsOtherViewOpen)
			{
				viewModel.IsLeftStickVerticalMoved = false;
				viewModel.IsHideByPad = viewModel.IsLeftStickHorizontalMoved;
				return;
			}
			viewModel.VerticalReal += value * this.MoveFactor;
			int filterSettingIdCache2 = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
			float[] array;
			if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterSettingIdCache2, out array) && array != null)
			{
				array[1] = viewModel.VerticalNormalized;
				this.SetFilterValueImp(viewModel, filterSettingIdCache2, array[0], array[1], array[2]);
				viewModel.IsFilterChanged = true;
			}
			viewModel.IsHideByPad = true;
			viewModel.IsLeftStickVerticalMoved = true;
		};
		viewModel.OnInputUiMoveRight = delegate(string axisName, float value)
		{
			if (!Singleton<Info>.Instance.IsInGamepad() || Singleton<MathUtils>.Instance.InRangeArray((double)value, new double[]
			{
				(double)(-(double)this.DeadZone),
				(double)this.DeadZone
			}) || viewModel.HorizontalReal == null || viewModel.IsHideByClick || viewModel.IsOtherViewOpen)
			{
				viewModel.IsLeftStickHorizontalMoved = false;
				viewModel.IsHideByPad = viewModel.IsLeftStickVerticalMoved;
				return;
			}
			viewModel.HorizontalReal += value * this.MoveFactor;
			int filterSettingIdCache2 = ModelBase<MenuModel>.Instance.FilterSettingIdCache;
			Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
			float[] array;
			if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterSettingIdCache2, out array) && array != null)
			{
				array[0] = viewModel.HorizontalNormalized;
				this.SetFilterValueImp(viewModel, filterSettingIdCache2, array[0], array[1], array[2]);
				viewModel.IsFilterChanged = true;
			}
			viewModel.IsHideByPad = true;
			viewModel.IsLeftStickHorizontalMoved = true;
		};
		viewModel.OnInputUiLookUp = delegate(string axisName, float value)
		{
			FilterCameraComponent cameraComponent = this.CameraComponent;
			if (cameraComponent == null)
			{
				return;
			}
			cameraComponent.OnInputUiLookUp(axisName, value);
		};
		viewModel.OnInputUiTurn = delegate(string axisName, float value)
		{
			FilterCameraComponent cameraComponent = this.CameraComponent;
			if (cameraComponent == null)
			{
				return;
			}
			cameraComponent.OnInputUiTurn(axisName, value);
		};
		viewModel.OnIndexChanged = delegate(int index)
		{
			int filterConfigIdByIndex = ModelBase<MenuModel>.Instance.GetFilterConfigIdByIndex(index);
			this.RefreshFilterSettingViewModel(filterConfigIdByIndex, viewModel);
		};
		viewModel.OnLeftArrowClick = delegate()
		{
			viewModel.IsFilterChanged = true;
		};
		viewModel.OnRightArrowClick = delegate()
		{
			viewModel.IsFilterChanged = true;
		};
		return viewModel;
	}

	// Token: 0x06010987 RID: 67975 RVA: 0x00489B64 File Offset: 0x00487D64
	private void RefreshFilterSettingViewModel(int filterId, FilterSettingViewModel viewModel)
	{
		ModelBase<MenuModel>.Instance.FilterSettingIdCache = filterId;
		Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
		if (ConfigFilterSettingAll.GetConfigList(true) == null)
		{
			return;
		}
		float[] array;
		if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterId, out array) && array != null)
		{
			viewModel.IntensityNormalized = array[2];
			viewModel.HorizontalNormalized = array[0];
			viewModel.VerticalNormalized = array[1];
			this.SetFilterValueImp(viewModel, filterId, array[0], array[1], array[2]);
		}
		FilterSetting? config = ConfigFilterSettingById.GetConfig(filterId, true);
		viewModel.FilterPadTexturePath = ((config != null) ? config.GetValueOrDefault().PadTexturePath : null);
		viewModel.FilterNameTextId = ((config != null) ? config.GetValueOrDefault().NameTextId : null);
		viewModel.IsSliderActive = (filterId != 1);
		viewModel.IsSeniorParamRefresh = true;
	}

	// Token: 0x06010988 RID: 67976 RVA: 0x00489C2C File Offset: 0x00487E2C
	public void ApplyFilterSetting()
	{
		int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.FilterSettingId, 1);
		Dictionary<int, float[]> global2 = LocalStorage.GetGlobal<Dictionary<int, float[]>>(ELocalStorageGlobalKey.FilterSettingValues, null);
		float[] array;
		if (global2 != null && global2.TryGetValue(global, out array) && array != null)
		{
			UKuroGISystem.SetKuroAdvancedModeScreenFilter(GlobalData.World, ConfigFilterSettingById.GetConfig(global, true).Value.LogicIndex, array[0], array[1], array[2], (array.Length > 3) ? array[3] : 0f, (array.Length > 3) ? array[4] : 0f, (array.Length > 3) ? array[5] : 0f, (array.Length > 3) ? array[6] : 0f, (array.Length > 3) ? array[7] : 0f, (array.Length > 3) ? array[8] : 0f, (array.Length > 3) ? array[9] : 0f, (array.Length > 3) ? array[10] : 0f, (array.Length > 3) ? array[11] : 0f, (array.Length > 3) ? array[12] : 0f);
			return;
		}
		this.SetDefaultFilterSetting();
	}

	// Token: 0x06010989 RID: 67977 RVA: 0x00489D44 File Offset: 0x00487F44
	public void SetDefaultFilterSetting()
	{
		UKuroGISystem.SetKuroAdvancedModeScreenFilter(GlobalData.World, ConfigFilterSettingById.GetConfig(1, true).Value.LogicIndex, 0.5f, 0.5f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
	}

	// Token: 0x0601098A RID: 67978 RVA: 0x00489DB4 File Offset: 0x00487FB4
	private void SetFilterValueImp(FilterSettingViewModel viewModel, int filterId, float horizontalNormalized, float verticalNormalized, float intensityNormalized)
	{
		Dictionary<int, float[]> filterSettingValuesCache = ModelBase<MenuModel>.Instance.FilterSettingValuesCache;
		float[] array;
		if (filterSettingValuesCache != null && filterSettingValuesCache.TryGetValue(filterId, out array) && array != null)
		{
			this.SetFilterAllValueImp(viewModel, filterId, horizontalNormalized, verticalNormalized, intensityNormalized, array[3], array[4], array[5], array[6], array[7], array[8], array[9], array[10], array[11], array[12]);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameSettings;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "未找到当前滤镜id相关的参数值";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("filterId", filterId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601098B RID: 67979 RVA: 0x00489E3C File Offset: 0x0048803C
	private unsafe void SetFilterAllValueImp(FilterSettingViewModel viewModel, int filterId, float horizontalNormalized, float verticalNormalized, float intensityNormalized, float sharpenIntensity, float brightness, float contrast, float colorTemperature, float saturation, float bloom, float gamma, float shadowIntensity, float noiseIntensity, float halation)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameSettings;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "设置全局滤镜值";
		<>y__InlineArray14<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray14<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("filterId", filterId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("horizontalNormalized", horizontalNormalized);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("verticalNormalized", verticalNormalized);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("intensityNormalized", intensityNormalized);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("sharpenIntensity", sharpenIntensity);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("brightness", brightness);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("contrast", contrast);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("colorTemperature", colorTemperature);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("saturation", saturation);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 9) = new ValueTuple<string, object>("bloom", bloom);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 10) = new ValueTuple<string, object>("gamma", gamma);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 11) = new ValueTuple<string, object>("shadowIntensity", shadowIntensity);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 12) = new ValueTuple<string, object>("noiseIntensity", noiseIntensity);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 13) = new ValueTuple<string, object>("halation", halation);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray14<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 14));
		UKuroGISystem.SetKuroAdvancedModeScreenFilter(GlobalData.World, ConfigFilterSettingById.GetConfig(filterId, true).Value.LogicIndex, horizontalNormalized, verticalNormalized, intensityNormalized, sharpenIntensity, brightness, contrast, colorTemperature, saturation, bloom, gamma, shadowIntensity, noiseIntensity, halation);
	}

	// Token: 0x0601098C RID: 67980 RVA: 0x0048A054 File Offset: 0x00488254
	public UniTask CloseViewAndReturnWorld()
	{
		FilterSettingController.<CloseViewAndReturnWorld>d__24 <CloseViewAndReturnWorld>d__;
		<CloseViewAndReturnWorld>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseViewAndReturnWorld>d__.<>4__this = this;
		<CloseViewAndReturnWorld>d__.<>1__state = -1;
		<CloseViewAndReturnWorld>d__.<>t__builder.Start<FilterSettingController.<CloseViewAndReturnWorld>d__24>(ref <CloseViewAndReturnWorld>d__);
		return <CloseViewAndReturnWorld>d__.<>t__builder.Task;
	}

	// Token: 0x0601098D RID: 67981 RVA: 0x0048A098 File Offset: 0x00488298
	public UniTask OpenBlackScreen()
	{
		FilterSettingController.<OpenBlackScreen>d__25 <OpenBlackScreen>d__;
		<OpenBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenBlackScreen>d__.<>1__state = -1;
		<OpenBlackScreen>d__.<>t__builder.Start<FilterSettingController.<OpenBlackScreen>d__25>(ref <OpenBlackScreen>d__);
		return <OpenBlackScreen>d__.<>t__builder.Task;
	}

	// Token: 0x0601098E RID: 67982 RVA: 0x0048A0D4 File Offset: 0x004882D4
	public UniTask CloseBlackScreen()
	{
		FilterSettingController.<CloseBlackScreen>d__26 <CloseBlackScreen>d__;
		<CloseBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseBlackScreen>d__.<>1__state = -1;
		<CloseBlackScreen>d__.<>t__builder.Start<FilterSettingController.<CloseBlackScreen>d__26>(ref <CloseBlackScreen>d__);
		return <CloseBlackScreen>d__.<>t__builder.Task;
	}

	// Token: 0x0601098F RID: 67983 RVA: 0x0048A10F File Offset: 0x0048830F
	public float GetFilterDefaultValue(int filterId, EFilterSettingValueIndex typeIndex)
	{
		if (filterId == 1 && typeIndex == EFilterSettingValueIndex.Intensity)
		{
			return 1f;
		}
		if (typeIndex <= EFilterSettingValueIndex.Intensity)
		{
			return 0.5f;
		}
		return 0f;
	}

	// Token: 0x06010990 RID: 67984 RVA: 0x0048A12E File Offset: 0x0048832E
	private void DisableFilterTemporarily(bool isEnter)
	{
		if (isEnter)
		{
			UKuroSequencePerformanceManager.ExecuteCommandInPerformance("r.Kuro.KuroEnableScreenFilter 0");
			UKuroSequencePerformanceManager.ExecuteCommandInPerformance("r.BlueLightFilter.Disable 1");
			UKuroSequencePerformanceManager.ExecuteCommandInPerformance("r.Tonemapper.BrightnessAndTextureDisable 1");
			return;
		}
		UKuroSequencePerformanceManager.CloseKuroPerformanceMode();
	}

	// Token: 0x06010991 RID: 67985 RVA: 0x0048A158 File Offset: 0x00488358
	public bool IsFilterSettingChange()
	{
		int global = LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.FilterSettingId, 0);
		if (global != 1)
		{
			return true;
		}
		Dictionary<int, float[]> global2 = LocalStorage.GetGlobal<Dictionary<int, float[]>>(ELocalStorageGlobalKey.FilterSettingValues, null);
		if (global2 == null)
		{
			return false;
		}
		float[] array;
		if (!global2.TryGetValue(global, out array) || array == null)
		{
			return false;
		}
		foreach (EFilterSettingValueIndex efilterSettingValueIndex in MenuDefine.filterSettingParams)
		{
			int num = (int)efilterSettingValueIndex;
			if (num < array.Length && array[num] != 0f && array[num] != this.GetFilterDefaultValue(global, efilterSettingValueIndex))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010992 RID: 67986 RVA: 0x0048A1DE File Offset: 0x004883DE
	public void SwitchFilter(bool isOn)
	{
		if (isOn)
		{
			GameSettingsUtils.ApplyImageDisplayMode(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.ImageDisplayMode, 0, true));
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroEnableScreenFilter 0", null);
	}

	// Token: 0x040082AA RID: 33450
	[Nullable(2)]
	public FilterCameraComponent CameraComponent;

	// Token: 0x040082AB RID: 33451
	[Nullable(2)]
	private FilterSettingViewModel ViewModel;
}
