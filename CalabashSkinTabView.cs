using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Skin.Skip;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A4A RID: 10826
[NullableContext(1)]
[Nullable(0)]
public class CalabashSkinTabView : UiTabViewBase
{
	// Token: 0x06015ADC RID: 88796 RVA: 0x00604BC4 File Offset: 0x00602DC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
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
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIDraggableComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnCalabashHideUiClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnCalabashConfirmBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06015ADD RID: 88797 RVA: 0x00604D98 File Offset: 0x00602F98
	protected override void OnStart()
	{
		this.RootViewModel = (this.ExtraParams as SkinRootViewModel);
		this.ViewModel = new CalabashSkinViewProxy();
		this.ViewModel.Init(this.RootViewModel.ViewData);
		this.ViewModel.SetGetDragItemFunc(new Func<UUIDraggableComponent>(this.GetDragItem));
		this.ViewModel.Bind(new Action<ECalabashSkinViewData>(this.OnViewModelUpdate));
		this.Draggable = base.GetDraggable(9);
		this.Draggable.RootUIComp.Get().SetUIActive(false);
		this.InitGrid();
		this.InitHuluObserver();
		this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		this.ObtainLayout = new GenericLayout<SkinObtainItem, ISkinSkipData>(base.GetLayoutBase(5), new Func<SkinObtainItem>(this.InitObtainItem), base.GetItem(6).GetOwner() as AUIBaseActor, false, true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06015ADE RID: 88798 RVA: 0x00604E8F File Offset: 0x0060308F
	protected override void OnBeforeShow()
	{
		this.RootViewModel.SetModelState(EModelStateInSkinView.ShowCalabash, false);
		this.UpdateSelectedGrid();
		this.TryPushCamera();
	}

	// Token: 0x06015ADF RID: 88799 RVA: 0x00604EAC File Offset: 0x006030AC
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		CalabashSkinTabView.<OnBeforeShowAsyncImplement>d__12 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<CalabashSkinTabView.<OnBeforeShowAsyncImplement>d__12>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06015AE0 RID: 88800 RVA: 0x00604EEF File Offset: 0x006030EF
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x06015AE1 RID: 88801 RVA: 0x00604F0D File Offset: 0x0060310D
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x06015AE2 RID: 88802 RVA: 0x00604F2B File Offset: 0x0060312B
	protected override void OnBeforeHide()
	{
		this.HideHuluObserver();
	}

	// Token: 0x06015AE3 RID: 88803 RVA: 0x00604F33 File Offset: 0x00603133
	protected override void OnBeforeDestroy()
	{
		this.ViewModel.UnBind(new Action<ECalabashSkinViewData>(this.OnViewModelUpdate));
		this.ReleaseHuluObserver();
		this.RemoveTimeHandler();
	}

	// Token: 0x06015AE4 RID: 88804 RVA: 0x00604F58 File Offset: 0x00603158
	private void InitGrid()
	{
		this.GridLayout = new GenericLayout<CalabashSkinGridItem, CalabashSkinData>(base.GetLayoutBase(1), new Func<CalabashSkinGridItem>(this.InitGridItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06015AE5 RID: 88805 RVA: 0x00604F8B File Offset: 0x0060318B
	private CalabashSkinGridItem InitGridItem()
	{
		CalabashSkinGridItem calabashSkinGridItem = new CalabashSkinGridItem();
		calabashSkinGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnCalabashGridItemClick));
		calabashSkinGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.ViewModel.CalabashGridItemCanExecuteChange));
		return calabashSkinGridItem;
	}

	// Token: 0x06015AE6 RID: 88806 RVA: 0x00604FBB File Offset: 0x006031BB
	private SkinObtainItem InitObtainItem()
	{
		return new SkinObtainItem();
	}

	// Token: 0x06015AE7 RID: 88807 RVA: 0x00604FC4 File Offset: 0x006031C4
	private void InitHuluObserver()
	{
		this.HuluObserver = Singleton<UiSceneManager>.Instance.InitHuluObserver();
		UiModelBase model = this.HuluObserver.Model;
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.SetTransformByTag("TerminalCase");
		}
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		if (uiModelDataComponent == null)
		{
			return;
		}
		uiModelDataComponent.SetLoadingIconFollowState(false);
	}

	// Token: 0x06015AE8 RID: 88808 RVA: 0x00605012 File Offset: 0x00603212
	private void HideHuluObserver()
	{
		if (this.HuluObserver != null)
		{
			Singleton<UiSceneManager>.Instance.HideObserver(this.HuluObserver, "ShowHideWeaponEffect");
		}
	}

	// Token: 0x06015AE9 RID: 88809 RVA: 0x00605031 File Offset: 0x00603231
	private void ShowHuluObserver(int skinId)
	{
		CalabashSkinController instance = ControllerBase<CalabashSkinController>.Instance;
		int roleId = this.RootViewModel.RoleId;
		SkeletalObserverHandle huluObserver = this.HuluObserver;
		instance.SelectedCalabashSkinChange(skinId, roleId, (huluObserver != null) ? huluObserver.Model : null, "TerminalCase");
	}

	// Token: 0x06015AEA RID: 88810 RVA: 0x00605060 File Offset: 0x00603260
	public void SwitchHuluRotate(bool needStop)
	{
		SkeletalObserverHandle huluObserver = this.HuluObserver;
		UiModelRotateComponent uiModelRotateComponent;
		if (huluObserver == null)
		{
			uiModelRotateComponent = null;
		}
		else
		{
			UiModelBase model = huluObserver.Model;
			uiModelRotateComponent = ((model != null) ? model.CheckGetComponent<UiModelRotateComponent>() : null);
		}
		UiModelRotateComponent uiModelRotateComponent2 = uiModelRotateComponent;
		if (needStop)
		{
			if (uiModelRotateComponent2 != null)
			{
				uiModelRotateComponent2.StopRotate();
				return;
			}
		}
		else if (uiModelRotateComponent2 != null)
		{
			uiModelRotateComponent2.StartRotate();
		}
	}

	// Token: 0x06015AEB RID: 88811 RVA: 0x006050A2 File Offset: 0x006032A2
	public void ReleaseHuluObserver()
	{
		if (this.HuluObserver != null)
		{
			Singleton<UiSceneManager>.Instance.HideObserverWithCallback(this.HuluObserver, "ShowHideWeaponEffect", delegate(SkeletalObserverHandle observer)
			{
				Singleton<UiSceneManager>.Instance.DestroyHuluObserver();
			});
		}
	}

	// Token: 0x06015AEC RID: 88812 RVA: 0x006050E0 File Offset: 0x006032E0
	public void HideView()
	{
		this.Draggable.RootUIComp.Get().SetUIActive(true);
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.RootViewModel.SetRootUiVisible(false, false);
		this.RootViewModel.SetMoveGamepadKeyTipActive(true, false);
	}

	// Token: 0x06015AED RID: 88813 RVA: 0x00605134 File Offset: 0x00603334
	public void ShowView()
	{
		this.RootViewModel.SetMoveGamepadKeyTipActive(false, false);
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.RootViewModel.SetRootUiVisible(true, false);
		this.Draggable.RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06015AEE RID: 88814 RVA: 0x00605187 File Offset: 0x00603387
	public void SelectedGrid(int index)
	{
		this.GridLayout.DeselectCurrentGridProxy();
		this.GridLayout.SelectGridProxy(index, true);
	}

	// Token: 0x06015AEF RID: 88815 RVA: 0x006051A1 File Offset: 0x006033A1
	public void RefreshText(string name, string bgDescription)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), bgDescription, Array.Empty<object>());
	}

	// Token: 0x06015AF0 RID: 88816 RVA: 0x006051D1 File Offset: 0x006033D1
	public void RefreshConfirmBox(bool isSame)
	{
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(!isSame);
	}

	// Token: 0x06015AF1 RID: 88817 RVA: 0x006051E8 File Offset: 0x006033E8
	public void RefreshGridSelect(int lastIndex, int nowIndex)
	{
		CalabashSkinGridItem layoutItemByIndex = this.GridLayout.GetLayoutItemByIndex(lastIndex);
		if (layoutItemByIndex != null)
		{
			layoutItemByIndex.RefreshVisible();
		}
		CalabashSkinGridItem layoutItemByIndex2 = this.GridLayout.GetLayoutItemByIndex(nowIndex);
		if (layoutItemByIndex2 == null)
		{
			return;
		}
		layoutItemByIndex2.RefreshVisible();
	}

	// Token: 0x06015AF2 RID: 88818 RVA: 0x00605218 File Offset: 0x00603418
	public void RefreshBottom(CalabashSkinData data, bool isSame)
	{
		bool isLock = data.GetIsLock();
		UUIButtonComponent button = base.GetButton(4);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(!isLock);
		}
		this.ObtainLayout.SetActive(isLock);
		if (isLock)
		{
			CalabashSkin calabashSkinConfig = ConfigBase<SkinConfig>.Instance.GetCalabashSkinConfig(data.SkinId);
			List<ISkinSkipData> skinSkipDataList = this.RootViewModel.GetSkinSkipDataList(data.SkinId, calabashSkinConfig.ItemAccess());
			this.ObtainLayout.SetActive(skinSkipDataList.Count != 0);
			if (skinSkipDataList.Count > 0)
			{
				this.ObtainLayout.RefreshByData(skinSkipDataList, null, false);
				return;
			}
		}
		else
		{
			UUIButtonComponent button2 = base.GetButton(4);
			if (button2 == null)
			{
				return;
			}
			button2.SetSelfInteractive(!isSame);
		}
	}

	// Token: 0x06015AF3 RID: 88819 RVA: 0x006052C9 File Offset: 0x006034C9
	public void ShowEquipTips()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TerminalSkin_Change_Success", Array.Empty<object>());
	}

	// Token: 0x06015AF4 RID: 88820 RVA: 0x006052DF File Offset: 0x006034DF
	public void SwitchHuluObserver(int skinId)
	{
		CalabashSkinController instance = ControllerBase<CalabashSkinController>.Instance;
		int roleId = this.RootViewModel.RoleId;
		SkeletalObserverHandle huluObserver = this.HuluObserver;
		instance.SelectedCalabashSkinChange(skinId, roleId, (huluObserver != null) ? huluObserver.Model : null, "TerminalCase");
	}

	// Token: 0x06015AF5 RID: 88821 RVA: 0x00605310 File Offset: 0x00603510
	public void RefreshMainRoleHulu()
	{
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		UiRoleHuluComponent uiRoleHuluComponent = (model != null) ? model.GetComponent<UiRoleHuluComponent>() : null;
		if (uiRoleHuluComponent != null)
		{
			uiRoleHuluComponent.Refresh();
		}
	}

	// Token: 0x06015AF6 RID: 88822 RVA: 0x00605340 File Offset: 0x00603540
	private void OnViewModelUpdate(ECalabashSkinViewData data)
	{
		if (data == ECalabashSkinViewData.EquipSkinId)
		{
			int dataIndexBySkinId = this.ViewModel.GetDataIndexBySkinId(this.ViewModel.PrevEquipSkinId);
			int dataIndexBySkinId2 = this.ViewModel.GetDataIndexBySkinId(this.ViewModel.GetSelectedSkinId());
			this.RefreshGridSelect(dataIndexBySkinId, dataIndexBySkinId2);
			this.RefreshConfirmBox(true);
			this.ShowEquipTips();
			this.RefreshMainRoleHulu();
			return;
		}
		if (data == ECalabashSkinViewData.SelectedSkinId)
		{
			int selectedSkinId = this.ViewModel.GetSelectedSkinId();
			this.UpdateSelectedGrid();
			this.SwitchHuluObserver(selectedSkinId);
		}
	}

	// Token: 0x06015AF7 RID: 88823 RVA: 0x006053B8 File Offset: 0x006035B8
	private UUIDraggableComponent GetDragItem()
	{
		return base.GetDraggable(9);
	}

	// Token: 0x06015AF8 RID: 88824 RVA: 0x006053C4 File Offset: 0x006035C4
	private void UpdateSelectedGrid()
	{
		int selectedSkinId = this.ViewModel.GetSelectedSkinId();
		int dataIndexBySkinId = this.ViewModel.GetDataIndexBySkinId(selectedSkinId);
		CalabashSkinData skinDataByIndex = this.ViewModel.GetSkinDataByIndex(dataIndexBySkinId);
		this.RefreshBottom(skinDataByIndex, this.ViewModel.GetEquipSkinId() == selectedSkinId);
		this.RefreshText(skinDataByIndex.Name, skinDataByIndex.Description);
		this.SelectedGrid(dataIndexBySkinId);
	}

	// Token: 0x06015AF9 RID: 88825 RVA: 0x00605428 File Offset: 0x00603628
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.ViewName == EUiTabViewName.CalabashSkinTabView && this.ViewModel.NeedLoadModel)
		{
			this.ViewModel.NeedLoadModel = false;
			this.ShowHuluObserver(this.ViewModel.GetSelectedSkinId());
		}
	}

	// Token: 0x06015AFA RID: 88826 RVA: 0x00605478 File Offset: 0x00603678
	private void OnCalabashHideUiClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ShowView();
			this.RootViewModel.SetRootUiVisible(true, false);
			this.SwitchHuluRotate(false);
			this.EndCameraInput();
			this.ResetCamera();
			return;
		}
		this.HideView();
		this.RootViewModel.SetRootUiVisible(false, false);
		this.SwitchHuluRotate(this.ViewModel.NeedStopRotate);
		this.StartCameraInput();
	}

	// Token: 0x06015AFB RID: 88827 RVA: 0x006054DA File Offset: 0x006036DA
	private void OnCalabashConfirmBtnClick()
	{
		this.OnCalabashConfirmClick().Forget();
	}

	// Token: 0x06015AFC RID: 88828 RVA: 0x006054E8 File Offset: 0x006036E8
	private UniTask OnCalabashConfirmClick()
	{
		CalabashSkinTabView.<OnCalabashConfirmClick>d__41 <OnCalabashConfirmClick>d__;
		<OnCalabashConfirmClick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCalabashConfirmClick>d__.<>4__this = this;
		<OnCalabashConfirmClick>d__.<>1__state = -1;
		<OnCalabashConfirmClick>d__.<>t__builder.Start<CalabashSkinTabView.<OnCalabashConfirmClick>d__41>(ref <OnCalabashConfirmClick>d__);
		return <OnCalabashConfirmClick>d__.<>t__builder.Task;
	}

	// Token: 0x06015AFD RID: 88829 RVA: 0x0060552C File Offset: 0x0060372C
	private void OnCalabashGridItemClick(MediumItemGridExtendCallback parameters)
	{
		int skinId = (parameters.Data as CalabashSkinData).SkinId;
		this.ViewModel.SetSelectedSkinId(skinId, false);
	}

	// Token: 0x06015AFE RID: 88830 RVA: 0x00605557 File Offset: 0x00603757
	private void CreateTimeHandler()
	{
		if (this.TimeHandler != null)
		{
			return;
		}
		this.TimeHandler = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.TimeHandler = null;
		}, (float)this.ViewModel.FailRequestCd, null, null, true, 1f);
	}

	// Token: 0x06015AFF RID: 88831 RVA: 0x00605592 File Offset: 0x00603792
	private void RemoveTimeHandler()
	{
		if (this.TimeHandler != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimeHandler);
			this.TimeHandler = null;
		}
	}

	// Token: 0x06015B00 RID: 88832 RVA: 0x006055B4 File Offset: 0x006037B4
	private void StartCameraInput()
	{
		IUiCameraInputComponentData calabashSkinTabCameraInputData = this.ViewModel.GetCalabashSkinTabCameraInputData();
		this.RootViewModel.StartCameraInput(calabashSkinTabCameraInputData, new bool?(true), true);
	}

	// Token: 0x06015B01 RID: 88833 RVA: 0x006055E0 File Offset: 0x006037E0
	private void EndCameraInput()
	{
		this.RootViewModel.EndCameraInput();
	}

	// Token: 0x06015B02 RID: 88834 RVA: 0x006055F0 File Offset: 0x006037F0
	public void ResetCamera()
	{
		UiCameraHandleData newHandleData = UiCameraHandleData.NewByView(EUiTabViewName.CalabashSkinTabView, null, null);
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandle(newHandleData, true, true, "1001", false, null);
	}

	// Token: 0x06015B03 RID: 88835 RVA: 0x00605634 File Offset: 0x00603834
	public void TryPushCamera()
	{
		this.ViewModel.NeedLoadModel = true;
		UiCameraHandleData newHandleData = UiCameraHandleData.NewByView(EUiTabViewName.CalabashSkinTabView, null, null);
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandle(newHandleData, true, true, "10010", false, null);
	}

	// Token: 0x0400A676 RID: 42614
	private SkinRootViewModel RootViewModel;

	// Token: 0x0400A677 RID: 42615
	private CalabashSkinViewProxy ViewModel;

	// Token: 0x0400A678 RID: 42616
	protected GenericLayout<CalabashSkinGridItem, CalabashSkinData> GridLayout;

	// Token: 0x0400A679 RID: 42617
	protected GenericLayout<SkinObtainItem, ISkinSkipData> ObtainLayout;

	// Token: 0x0400A67A RID: 42618
	[Nullable(2)]
	protected SkeletalObserverHandle HuluObserver;

	// Token: 0x0400A67B RID: 42619
	[Nullable(2)]
	protected TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400A67C RID: 42620
	protected UUIDraggableComponent Draggable;

	// Token: 0x0400A67D RID: 42621
	[Nullable(2)]
	protected TimerHandle TimeHandler;

	// Token: 0x02008DD3 RID: 36307
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x0402FBAA RID: 195498
		TopAndRightItem,
		// Token: 0x0402FBAB RID: 195499
		GridLayout,
		// Token: 0x0402FBAC RID: 195500
		GridItem,
		// Token: 0x0402FBAD RID: 195501
		HideUiToggle,
		// Token: 0x0402FBAE RID: 195502
		ConfirmBtn,
		// Token: 0x0402FBAF RID: 195503
		ObtainLayout,
		// Token: 0x0402FBB0 RID: 195504
		ObtainItem,
		// Token: 0x0402FBB1 RID: 195505
		CalabashName,
		// Token: 0x0402FBB2 RID: 195506
		CalabashDesc,
		// Token: 0x0402FBB3 RID: 195507
		Draggable
	}
}
