using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A5B RID: 10843
[NullableContext(1)]
[Nullable(0)]
public class FlySkinTabView : UiTabViewBase
{
	// Token: 0x06015B72 RID: 88946 RVA: 0x00606A38 File Offset: 0x00604C38
	protected unsafe override void OnRegisterComponent()
	{
		this.RootViewModel = (this.ExtraParams as SkinRootViewModel);
		this.FlySkinTabViewModel = new FlySkinTabViewModel();
		this.FlySkinTabViewModel.Init(this.RootViewModel.ViewData);
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnApplyToAllHelpBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06015B73 RID: 88947 RVA: 0x00606CC8 File Offset: 0x00604EC8
	protected override UniTask OnBeforeStartAsync()
	{
		FlySkinTabView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FlySkinTabView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015B74 RID: 88948 RVA: 0x00606D0C File Offset: 0x00604F0C
	protected override void OnStart()
	{
		this.ParaglidingTabItem.SetItemToggleState(EToggleState.ETT_UnChecked, new bool?(false));
		this.SoarWingTabItem.SetItemToggleState(EToggleState.ETT_UnChecked, new bool?(false));
		this.SelectedTabItem = null;
		this.FlySkinTabViewModel.ResetSelectedTab();
		this.ParaglidingTabItem.AddItemToggleStateChange(new Action<EToggleState>(this.OnParaglidingTabToggleStateChange));
		this.SoarWingTabItem.AddItemToggleStateChange(new Action<EToggleState>(this.OnSoarWingTabToggleStateChange));
		this.ParaglidingTabItem.SetCanItemToggleStateChange(new Func<bool>(this.CanTabToggleChange));
		this.SoarWingTabItem.SetCanItemToggleStateChange(new Func<bool>(this.CanTabToggleChange));
		base.GetExtendToggle(3).OnStateChange.Add(new Action<EToggleState>(this.OnSwitchShowToggleStateChange));
		base.GetExtendToggle(10).OnStateChange.Add(new Action<EToggleState>(this.OnApplyToAllToggleStateChange));
		this.GridLayout = new GenericLayout<FlySkinGridItem, FlySkinGridData>(base.GetLayoutBase(1), new Func<FlySkinGridItem>(this.InitGridItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		this.ObtainLayout = new GenericLayout<FlySkinObtainItem, IFlySkinGetWayData>(base.GetLayoutBase(5), new Func<FlySkinObtainItem>(this.InitObtainItem), base.GetItem(6).GetOwner() as AUIBaseActor, false, true);
		this.FlySkinTabViewModel.Bind(new Action<EFlySkinViewData>(this.OnViewModelUpdate));
	}

	// Token: 0x06015B75 RID: 88949 RVA: 0x00606E5F File Offset: 0x0060505F
	protected override void OnBeforeDestroy()
	{
		this.FlySkinTabViewModel.UnBind(new Action<EFlySkinViewData>(this.OnViewModelUpdate));
		this.DestroyGliderObserver();
	}

	// Token: 0x06015B76 RID: 88950 RVA: 0x00606E80 File Offset: 0x00605080
	protected override void OnBeforeShow()
	{
		this.InitGliderObserver();
		this.LastClickTimeStamp = 0.0;
		this.CanLoadModel = false;
		this.RootViewModel.SetModelState(EModelStateInSkinView.ShowGlider, false);
		int selectedFlySkinId = this.FlySkinTabViewModel.SelectedFlySkinId;
		int selectedSkinId = (selectedFlySkinId == -1) ? ModelBase<FlySkinModel>.Instance.GetRoleEquipParaglidingSkinId(this.FlySkinTabViewModel.RoleDataId) : selectedFlySkinId;
		EFlySkinTab valueOrDefault = this.FlySkinTabViewModel.GetSelectedTab().GetValueOrDefault();
		UpdateViewContext context = new UpdateViewContext
		{
			Tab = valueOrDefault,
			SelectedSkinId = selectedSkinId,
			UiShowState = true,
			IsApplyToAll = false
		};
		this.UpdateView(context);
	}

	// Token: 0x06015B77 RID: 88951 RVA: 0x00606F1D File Offset: 0x0060511D
	protected override void OnAfterShow()
	{
		this.CanPushCamera = true;
		this.TryPushCamera();
		this.TryStartCameraInputComponent();
	}

	// Token: 0x06015B78 RID: 88952 RVA: 0x00606F34 File Offset: 0x00605134
	private void HideModelWithEffect()
	{
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		UiModelBase uiModelBase = (gliderObserver != null) ? gliderObserver.Model : null;
		if (uiModelBase == null)
		{
			return;
		}
		Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
		UiModelDataComponent uiModelDataComponent = (uiModelBase != null) ? uiModelBase.CheckGetComponent<UiModelDataComponent>() : null;
		if (uiModelDataComponent != null && uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete)
		{
			EFlySkinType selectedFlySkinType = this.FlySkinTabViewModel.SelectedFlySkinType;
			string flySkinSpawnEffectId = ConfigBase<SkinConfig>.Instance.GetFlySkinSpawnEffectId(selectedFlySkinType);
			Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(uiModelBase, flySkinSpawnEffectId);
		}
	}

	// Token: 0x06015B79 RID: 88953 RVA: 0x00606FA6 File Offset: 0x006051A6
	protected override void OnBeforeHide()
	{
		this.ResetAll();
	}

	// Token: 0x06015B7A RID: 88954 RVA: 0x00606FAE File Offset: 0x006051AE
	private void OnSkinRootViewDestroy()
	{
		this.ResetAll();
	}

	// Token: 0x06015B7B RID: 88955 RVA: 0x00606FB6 File Offset: 0x006051B6
	private void ResetAll()
	{
		this.WaitCameraId = null;
		this.CanLoadModel = false;
		this.CanPushCamera = false;
		this.HideModelWithEffect();
		this.RootViewModel.EndCameraInput();
	}

	// Token: 0x06015B7C RID: 88956 RVA: 0x00606FE0 File Offset: 0x006051E0
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleFlySkinChange, new Action<int, EFlySkinType, int, int>(this.OnRoleFlySkinChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFlySkinEquipResponse, new Action<int, int>(this.OnFlySkinEquipResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFlySkinUnLoadResponse, new Action<int, int>(this.OnFlySkinUnLoadResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFlySkinEquipToAllRoleResponse, new Action<IReadOnlyList<RoleFlySkinChange>>(this.OnFlySkinEquipToAllRoleResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFlySkinAllUnLoadResponse, new Action<EFlySkinType>(this.OnFlySkinAllUnLoadResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSkinRootViewDestroy, new Action(this.OnSkinRootViewDestroy));
	}

	// Token: 0x06015B7D RID: 88957 RVA: 0x006070B4 File Offset: 0x006052B4
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleFlySkinChange, new Action<int, EFlySkinType, int, int>(this.OnRoleFlySkinChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFlySkinEquipResponse, new Action<int, int>(this.OnFlySkinEquipResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFlySkinUnLoadResponse, new Action<int, int>(this.OnFlySkinUnLoadResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFlySkinEquipToAllRoleResponse, new Action<IReadOnlyList<RoleFlySkinChange>>(this.OnFlySkinEquipToAllRoleResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFlySkinAllUnLoadResponse, new Action<EFlySkinType>(this.OnFlySkinAllUnLoadResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkinRootViewDestroy, new Action(this.OnSkinRootViewDestroy));
	}

	// Token: 0x06015B7E RID: 88958 RVA: 0x00607188 File Offset: 0x00605388
	private void InitGliderObserver()
	{
		Singleton<UiSceneManager>.Instance.InitGliderSkeletalHandle();
		SkeletalObserverHandle gliderSkeletalHandle = Singleton<UiSceneManager>.Instance.GetGliderSkeletalHandle();
		gliderSkeletalHandle.Model.CheckGetComponent<UiModelActorComponent>().SetTransformByTag(FlySkinDefine.DEFAULT_FLY_SKIN_CASE);
		this.GliderObserver = gliderSkeletalHandle;
	}

	// Token: 0x06015B7F RID: 88959 RVA: 0x006071C6 File Offset: 0x006053C6
	private void DestroyGliderObserver()
	{
		Singleton<UiSceneManager>.Instance.DestroyGliderSkeletalHandle();
		this.GliderObserver = null;
	}

	// Token: 0x06015B80 RID: 88960 RVA: 0x006071D9 File Offset: 0x006053D9
	public void UpdateView(UpdateViewContext context)
	{
		this.UpdateIsApplyToAll(context.IsApplyToAll);
		this.UpdateUiShowState(context.UiShowState, false);
		this.SelectTab(context.Tab, context.SelectedSkinId);
	}

	// Token: 0x06015B81 RID: 88961 RVA: 0x00607208 File Offset: 0x00605408
	public void SelectTab(EFlySkinTab tab, int skinId)
	{
		FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
		flySkinTabViewModel.SelectTab(tab);
		flySkinTabViewModel.SelectGridByIndex(this.FlySkinTabViewModel.GetGridIndexBySkinId(skinId).GetValueOrDefault());
	}

	// Token: 0x06015B82 RID: 88962 RVA: 0x0060723B File Offset: 0x0060543B
	public void SelectGridByIndex(int gridIndex)
	{
		this.FlySkinTabViewModel.SelectGridByIndex(gridIndex);
		this.GridLayout.SelectGridProxy(gridIndex, false);
		this.OnGridSelected();
	}

	// Token: 0x06015B83 RID: 88963 RVA: 0x0060725C File Offset: 0x0060545C
	public void OnGridSelected()
	{
		FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
		FlySkinGridData selectedGridData = flySkinTabViewModel.SelectedGridData;
		bool flag = selectedGridData == null || selectedGridData.GetIsLock();
		this.ObtainLayout.SetActive(flag);
		if (flag)
		{
			this.ObtainLayout.RefreshByData(flySkinTabViewModel.GetWayDataList, null, false);
		}
		this.RefreshConfirmBtnState();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), selectedGridData.GetName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), selectedGridData.GetTypeDescription(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), selectedGridData.GetDescription(), Array.Empty<object>());
		this.TryLoadModel();
	}

	// Token: 0x06015B84 RID: 88964 RVA: 0x00607308 File Offset: 0x00605508
	public void TryLoadModel()
	{
		FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		UiModelBase uiModelBase = (gliderObserver != null) ? gliderObserver.Model : null;
		if (uiModelBase == null)
		{
			return;
		}
		if (!this.CanLoadModel)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
			uiModelBase.CheckGetComponent<UiModelActorComponent>().SetTransformByTag(flySkinTabViewModel.ModelCase);
			return;
		}
		SkinConfig instance = ConfigBase<SkinConfig>.Instance;
		EFlySkinType selectedFlySkinType = flySkinTabViewModel.SelectedFlySkinType;
		FlySkinGridData selectedGridData = flySkinTabViewModel.SelectedGridData;
		string standAnimPath = selectedGridData.GetStandAnimPath();
		string flySkinSpawnEffectId = instance.GetFlySkinSpawnEffectId(selectedFlySkinType);
		string flySkinSpawnMaterialController = instance.GetFlySkinSpawnMaterialController(selectedFlySkinType);
		string effectPath = EffectUtil.GetEffectPath(flySkinSpawnEffectId);
		string changeMaterialControllerPath = EffectUtil.GetEffectPath(flySkinSpawnMaterialController);
		List<string> extraResourceList = new List<string>
		{
			standAnimPath,
			effectPath,
			changeMaterialControllerPath
		};
		UiModelLoadComponent loadComponent = uiModelBase.CheckGetComponent<UiModelLoadComponent>();
		uiModelBase.CheckGetComponent<UiModelActorComponent>().SetTransformByTag(flySkinTabViewModel.ModelCase);
		Action loadFinishCallBack = delegate()
		{
			SkeletalObserverHandle gliderObserver2 = this.GliderObserver;
			UiModelBase uiModelBase2 = (gliderObserver2 != null) ? gliderObserver2.Model : null;
			if (uiModelBase2 == null)
			{
				return;
			}
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase2, true);
			UiModelLoadComponent loadComponent = loadComponent;
			UAnimationAsset uanimationAsset = ((loadComponent != null) ? loadComponent.GetLoadedResource(standAnimPath) : null) as UAnimationAsset;
			if (uanimationAsset == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.LZK, "[FlySkin] 飞行皮肤待机动画预加载失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			uiModelBase2.CheckGetComponent<UiModelAnimationComponent>().PlayAnimation(uanimationAsset, true);
			UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = uiModelBase2.CheckGetComponent<UiModelRenderingMaterialComponent>();
			PD_CharacterControllerData_C pd_CharacterControllerData_C = loadComponent.GetLoadedResource(changeMaterialControllerPath) as PD_CharacterControllerData_C;
			if (pd_CharacterControllerData_C != null && uiModelRenderingMaterialComponent != null)
			{
				uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C);
			}
			Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(uiModelBase2, "GliderEffect");
		};
		loadComponent.LoadModelByModelId(selectedGridData.GetModelId(), true, loadFinishCallBack, extraResourceList);
	}

	// Token: 0x06015B85 RID: 88965 RVA: 0x00607418 File Offset: 0x00605618
	public void UpdateUiShowState(bool state, bool resetCamera)
	{
		this.FlySkinTabViewModel.SetUiShowState(state);
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(3).SetToggleState(state2, false, false, false);
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(state);
		}
		this.RootViewModel.SetCaptionItemActive(state);
		this.RootViewModel.NotifyGamePadKeyTipRefresh();
		this.RootViewModel.SetCameraInputCanInput(!state);
		if (state && resetCamera)
		{
			this.TryPushCamera();
		}
	}

	// Token: 0x06015B86 RID: 88966 RVA: 0x00607490 File Offset: 0x00605690
	public void UpdateIsApplyToAll(bool isApplyToAll)
	{
		this.FlySkinTabViewModel.SetIsApplyToAll(isApplyToAll);
		EToggleState state = isApplyToAll ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(10);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x06015B87 RID: 88967 RVA: 0x006074C8 File Offset: 0x006056C8
	public void RefreshConfirmBtnState()
	{
		FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
		FlySkinGridData selectedGridData = flySkinTabViewModel.SelectedGridData;
		bool flag = selectedGridData == null || selectedGridData.GetIsLock();
		UUIItem item = base.GetItem(14);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		if (flag)
		{
			return;
		}
		int selectedFlySkinId = flySkinTabViewModel.SelectedFlySkinId;
		EFlySkinType selectedFlySkinType = flySkinTabViewModel.SelectedFlySkinType;
		int roleDataId = flySkinTabViewModel.RoleDataId;
		bool flag2 = flySkinTabViewModel.IsApplyToAll || !ModelBase<FlySkinModel>.Instance.CheckRoleEquipFlySkin(roleDataId, selectedFlySkinId, selectedFlySkinType);
		this.ConfirmBtnItem.SetEnableClick(flag2);
		string flySkinEquipBtnTextId = ConfigBase<SkinConfig>.Instance.GetFlySkinEquipBtnTextId(selectedFlySkinType, flag2);
		this.ConfirmBtnItem.SetLocalTextNew(flySkinEquipBtnTextId, Array.Empty<object>());
	}

	// Token: 0x06015B88 RID: 88968 RVA: 0x0060756C File Offset: 0x0060576C
	private void TryPushCamera()
	{
		if (!this.CanPushCamera)
		{
			return;
		}
		string flySkinModelCameraId = ConfigBase<SkinConfig>.Instance.GetFlySkinModelCameraId(this.FlySkinTabViewModel.SelectedFlySkinType);
		this.WaitCameraId = flySkinModelCameraId;
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(flySkinModelCameraId, true, true, "10010", false, null, null);
	}

	// Token: 0x06015B89 RID: 88969 RVA: 0x006075C0 File Offset: 0x006057C0
	private void TryStartCameraInputComponent()
	{
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		if (((gliderObserver != null) ? gliderObserver.Model : null) == null)
		{
			return;
		}
		IUiCameraInputComponentData flySkinTabCameraInputData = this.FlySkinTabViewModel.GetFlySkinTabCameraInputData(this.RootViewModel.GetDragItem());
		this.RootViewModel.StartCameraInput(flySkinTabCameraInputData, null, false);
	}

	// Token: 0x06015B8A RID: 88970 RVA: 0x00607610 File Offset: 0x00605810
	public void ChangeSelectedTab(EFlySkinTab tab)
	{
		int roleEquipFlySkinId = ModelBase<FlySkinModel>.Instance.GetRoleEquipFlySkinId(this.FlySkinTabViewModel.RoleDataId, FlySkinDefine.flySkinTabToType[tab]);
		this.SelectTab(tab, roleEquipFlySkinId);
	}

	// Token: 0x06015B8B RID: 88971 RVA: 0x00607648 File Offset: 0x00605848
	protected bool CanTabToggleChange()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
		if (this.LastClickTimeStamp != 0.0)
		{
			double num = Singleton<Time>.Instance.Now - this.LastClickTimeStamp;
			int? num2 = intConfig;
			double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
			if (!(num >= num3.GetValueOrDefault() & num3 != null))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06015B8C RID: 88972 RVA: 0x006076CD File Offset: 0x006058CD
	private void OnParaglidingTabToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ChangeSelectedTab(EFlySkinTab.ParaglidingTab);
			this.LastClickTimeStamp = Singleton<Time>.Instance.Now;
		}
	}

	// Token: 0x06015B8D RID: 88973 RVA: 0x006076EA File Offset: 0x006058EA
	private void OnSoarWingTabToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ChangeSelectedTab(EFlySkinTab.SoarWingTab);
			this.LastClickTimeStamp = Singleton<Time>.Instance.Now;
		}
	}

	// Token: 0x06015B8E RID: 88974 RVA: 0x00607707 File Offset: 0x00605907
	public FlySkinChildTabItem GetTabItem(EFlySkinTab type)
	{
		if (type == EFlySkinTab.ParaglidingTab)
		{
			return this.ParaglidingTabItem;
		}
		if (type != EFlySkinTab.SoarWingTab)
		{
			return null;
		}
		return this.SoarWingTabItem;
	}

	// Token: 0x06015B8F RID: 88975 RVA: 0x00607721 File Offset: 0x00605921
	private void OnSwitchShowToggleStateChange(EToggleState state)
	{
		this.UpdateUiShowState(state == EToggleState.ETT_Checked, true);
	}

	// Token: 0x06015B90 RID: 88976 RVA: 0x0060772E File Offset: 0x0060592E
	private void OnApplyToAllToggleStateChange(EToggleState state)
	{
		this.UpdateIsApplyToAll(state == EToggleState.ETT_Checked);
		this.RefreshConfirmBtnState();
	}

	// Token: 0x06015B91 RID: 88977 RVA: 0x00607740 File Offset: 0x00605940
	private FlySkinGridItem InitGridItem()
	{
		FlySkinGridItem flySkinGridItem = new FlySkinGridItem();
		flySkinGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.GridItemClick));
		flySkinGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.GridItemCanExecuteChange));
		return flySkinGridItem;
	}

	// Token: 0x06015B92 RID: 88978 RVA: 0x0060776C File Offset: 0x0060596C
	private void GridItemClick(MediumItemGridExtendCallback parameters)
	{
		int skinId = (parameters.Data as FlySkinGridData).SkinId;
		int? gridIndexBySkinId = this.FlySkinTabViewModel.GetGridIndexBySkinId(skinId);
		if (gridIndexBySkinId != null)
		{
			this.SelectGridByIndex(gridIndexBySkinId.Value);
		}
	}

	// Token: 0x06015B93 RID: 88979 RVA: 0x006077B0 File Offset: 0x006059B0
	private bool GridItemCanExecuteChange(object parameters, bool result, EToggleState state)
	{
		int skinId = (parameters as FlySkinGridData).SkinId;
		return this.FlySkinTabViewModel.SelectedFlySkinId != skinId;
	}

	// Token: 0x06015B94 RID: 88980 RVA: 0x006077DA File Offset: 0x006059DA
	private FlySkinObtainItem InitObtainItem()
	{
		return new FlySkinObtainItem();
	}

	// Token: 0x06015B95 RID: 88981 RVA: 0x006077E4 File Offset: 0x006059E4
	private void OnApplyToAllHelpBtnClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FlySkinApplyHelp);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06015B96 RID: 88982 RVA: 0x00607808 File Offset: 0x00605A08
	private void OnConfirmBtnClick(int state)
	{
		FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
		int skinId = flySkinTabViewModel.SelectedFlySkinId;
		EFlySkinType skinType = flySkinTabViewModel.SelectedFlySkinType;
		int roleDataId = flySkinTabViewModel.RoleDataId;
		if (flySkinTabViewModel.IsApplyToAll)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FlySkinApplyToAll);
			Action value = delegate()
			{
				if (skinId == 0)
				{
					ControllerBase<FlySkinController>.Instance.FlySkinAllUnLoadRequest(skinType);
				}
				else
				{
					ControllerBase<FlySkinController>.Instance.FlySkinWearAllRoleRequest(skinId);
				}
				this.UpdateIsApplyToAll(false);
				this.RefreshConfirmBtnState();
			};
			confirmBoxDataNew.FunctionMap.Add(2, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (skinId == 0)
		{
			int roleEquipFlySkinId = ModelBase<FlySkinModel>.Instance.GetRoleEquipFlySkinId(roleDataId, skinType);
			ControllerBase<FlySkinController>.Instance.FlySkinUnLoadRequest(roleDataId, roleEquipFlySkinId);
			return;
		}
		ControllerBase<FlySkinController>.Instance.FlySkinWearRequest(roleDataId, skinId);
	}

	// Token: 0x06015B97 RID: 88983 RVA: 0x006078C0 File Offset: 0x00605AC0
	private void OnRoleFlySkinChange(int roleDataId, EFlySkinType skinType, int oldSkinId, int newSkinId)
	{
		FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
		if (skinType != flySkinTabViewModel.SelectedFlySkinType || roleDataId != flySkinTabViewModel.RoleDataId)
		{
			return;
		}
		int? gridIndexBySkinId = flySkinTabViewModel.GetGridIndexBySkinId(oldSkinId);
		if (gridIndexBySkinId != null)
		{
			FlySkinGridItem layoutItemByIndex = this.GridLayout.GetLayoutItemByIndex(gridIndexBySkinId.Value);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.RefreshEquipState();
			}
		}
		int? gridIndexBySkinId2 = flySkinTabViewModel.GetGridIndexBySkinId(newSkinId);
		if (gridIndexBySkinId2 != null)
		{
			FlySkinGridItem layoutItemByIndex2 = this.GridLayout.GetLayoutItemByIndex(gridIndexBySkinId2.Value);
			if (layoutItemByIndex2 == null)
			{
				return;
			}
			layoutItemByIndex2.RefreshEquipState();
		}
	}

	// Token: 0x06015B98 RID: 88984 RVA: 0x00607943 File Offset: 0x00605B43
	private void OnEquipSuccess()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FlySkinReplaceTip", Array.Empty<object>());
		this.UpdateIsApplyToAll(false);
		this.RefreshConfirmBtnState();
	}

	// Token: 0x06015B99 RID: 88985 RVA: 0x00607966 File Offset: 0x00605B66
	private void OnFlySkinEquipResponse(int roleDataId, int skinId)
	{
		this.OnEquipSuccess();
	}

	// Token: 0x06015B9A RID: 88986 RVA: 0x0060796E File Offset: 0x00605B6E
	private void OnFlySkinUnLoadResponse(int roleDataId, int skinId)
	{
		this.OnEquipSuccess();
	}

	// Token: 0x06015B9B RID: 88987 RVA: 0x00607976 File Offset: 0x00605B76
	private void OnFlySkinEquipToAllRoleResponse(IReadOnlyList<RoleFlySkinChange> skinChanges)
	{
		this.OnEquipSuccess();
	}

	// Token: 0x06015B9C RID: 88988 RVA: 0x0060797E File Offset: 0x00605B7E
	private void OnFlySkinAllUnLoadResponse(EFlySkinType skinType)
	{
		this.OnEquipSuccess();
	}

	// Token: 0x06015B9D RID: 88989 RVA: 0x00607986 File Offset: 0x00605B86
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.HandleName == this.WaitCameraId)
		{
			this.WaitCameraId = null;
			if (!this.CanLoadModel)
			{
				this.CanLoadModel = true;
				this.TryLoadModel();
			}
		}
	}

	// Token: 0x06015B9E RID: 88990 RVA: 0x006079B8 File Offset: 0x00605BB8
	private void OnViewModelUpdate(EFlySkinViewData data)
	{
		if (data == EFlySkinViewData.SelectedGridIndex)
		{
			FlySkinTabViewModel flySkinTabViewModel = this.FlySkinTabViewModel;
			this.TryPushCamera();
			this.GridLayout.RefreshByData(flySkinTabViewModel.GetGridDataList(), delegate
			{
				this.GridLayout.SelectGridProxy(flySkinTabViewModel.GetSelectedGridIndex(), false);
			}, false);
			this.OnGridSelected();
			return;
		}
		if (data == EFlySkinViewData.SelectedTab)
		{
			FlySkinChildTabItem tabItem = this.GetTabItem(this.FlySkinTabViewModel.GetSelectedTab().Value);
			FlySkinChildTabItem selectedTabItem = this.SelectedTabItem;
			if (selectedTabItem != null)
			{
				selectedTabItem.SetItemToggleState(EToggleState.ETT_UnChecked, new bool?(false));
			}
			this.SelectedTabItem = tabItem;
			tabItem.SetItemToggleState(EToggleState.ETT_Checked, new bool?(false));
		}
	}

	// Token: 0x0400A6AA RID: 42666
	private SkinRootViewModel RootViewModel;

	// Token: 0x0400A6AB RID: 42667
	private FlySkinTabViewModel FlySkinTabViewModel;

	// Token: 0x0400A6AC RID: 42668
	protected GenericLayout<FlySkinGridItem, FlySkinGridData> GridLayout;

	// Token: 0x0400A6AD RID: 42669
	protected GenericLayout<FlySkinObtainItem, IFlySkinGetWayData> ObtainLayout;

	// Token: 0x0400A6AE RID: 42670
	private ButtonItem ConfirmBtnItem;

	// Token: 0x0400A6AF RID: 42671
	private FlySkinChildTabItem ParaglidingTabItem;

	// Token: 0x0400A6B0 RID: 42672
	private FlySkinChildTabItem SoarWingTabItem;

	// Token: 0x0400A6B1 RID: 42673
	private FlySkinChildTabItem SelectedTabItem;

	// Token: 0x0400A6B2 RID: 42674
	private double LastClickTimeStamp;

	// Token: 0x0400A6B3 RID: 42675
	private bool CanPushCamera;

	// Token: 0x0400A6B4 RID: 42676
	private string WaitCameraId;

	// Token: 0x0400A6B5 RID: 42677
	private bool CanLoadModel;

	// Token: 0x0400A6B6 RID: 42678
	public SkeletalObserverHandle GliderObserver;

	// Token: 0x02008DE0 RID: 36320
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FBD4 RID: 195540
		TopAndRightItem,
		// Token: 0x0402FBD5 RID: 195541
		GridLayout,
		// Token: 0x0402FBD6 RID: 195542
		GridItem,
		// Token: 0x0402FBD7 RID: 195543
		SwitchShowToggle,
		// Token: 0x0402FBD8 RID: 195544
		ConfirmBtnItem,
		// Token: 0x0402FBD9 RID: 195545
		ObtainLayout,
		// Token: 0x0402FBDA RID: 195546
		ObtainItem,
		// Token: 0x0402FBDB RID: 195547
		TitleText,
		// Token: 0x0402FBDC RID: 195548
		SubTitleText,
		// Token: 0x0402FBDD RID: 195549
		DescText,
		// Token: 0x0402FBDE RID: 195550
		ApplyToAllToggle,
		// Token: 0x0402FBDF RID: 195551
		ApplyToAllHelpBtn,
		// Token: 0x0402FBE0 RID: 195552
		ParaglidingTabItem,
		// Token: 0x0402FBE1 RID: 195553
		SoarWingTabItem,
		// Token: 0x0402FBE2 RID: 195554
		ConfirmBtnAndApplyItem
	}
}
