using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024CE RID: 9422
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractEditView : UiViewBase
{
	// Token: 0x060124A2 RID: 74914 RVA: 0x005072E0 File Offset: 0x005054E0
	public PhantomInteractEditView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060124A3 RID: 74915 RVA: 0x005073A7 File Offset: 0x005055A7
	private void LocalLog(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
	}

	// Token: 0x060124A4 RID: 74916 RVA: 0x005073AC File Offset: 0x005055AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		foreach (ICostToggleInfo costToggleInfo in this.allCostToggleInfo)
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(costToggleInfo.Component, typeof(UUIItem)));
		}
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnMoveNextSkinClick))
		};
	}

	// Token: 0x060124A5 RID: 74917 RVA: 0x00507544 File Offset: 0x00505744
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomInteractEditView.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomInteractEditView.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060124A6 RID: 74918 RVA: 0x00507587 File Offset: 0x00505787
	protected override void OnDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
	}

	// Token: 0x060124A7 RID: 74919 RVA: 0x005075A1 File Offset: 0x005057A1
	protected override void OnBeforeShow()
	{
		this.SetOtherTeamEntitiesEnable(false);
	}

	// Token: 0x060124A8 RID: 74920 RVA: 0x005075AA File Offset: 0x005057AA
	protected override void OnAfterHide()
	{
		PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
		if (detailPanelGroup != null)
		{
			detailPanelGroup.RefreshDetailPanel(false, null);
		}
		this.SetOtherTeamEntitiesEnable(true);
	}

	// Token: 0x060124A9 RID: 74921 RVA: 0x005075C8 File Offset: 0x005057C8
	private void InitDropDown()
	{
		this.FilterDropDown.SetOnSelectCall(new Action<int, EFilterIsSpecialOption>(this.OnDropDownSelectCall));
		this.FilterDropDown.SetShowType(ECommonDropDownShowType.Up);
		this.FilterDropDown.InitScroll(this.allFilterOption, new Func<EFilterIsSpecialOption, int>(this.GetDropDownTextId), 0, true);
	}

	// Token: 0x060124AA RID: 74922 RVA: 0x00507617 File Offset: 0x00505817
	private int GetDropDownTextId(EFilterIsSpecialOption data)
	{
		return (int)data;
	}

	// Token: 0x060124AB RID: 74923 RVA: 0x0050761C File Offset: 0x0050581C
	private void OnDropDownSelectCall(int index, EFilterIsSpecialOption data)
	{
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		this.RefreshRightScrollViewGrid(-1);
		editViewModel.SetFilterIsSpecial(data);
		if (this.ViewStarted)
		{
			editViewModel.RefreshFilterGridViewData();
		}
		this.Refresh();
		this.RefreshRightScrollData();
		this.RefreshRightScrollView(null, true);
	}

	// Token: 0x060124AC RID: 74924 RVA: 0x0050766C File Offset: 0x0050586C
	protected override void OnStart()
	{
		PhantomInteractEditViewParam phantomInteractEditViewParam = this.OpenParam as PhantomInteractEditViewParam;
		if (phantomInteractEditViewParam == null)
		{
			return;
		}
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		this.CaptionPanel = new PopupCaptionItem(base.GetItem(7));
		this.CaptionPanel.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
		this.CaptionPanel.SetTitleByTextIdAndArgNew("ExploreTools_1007_Name", Array.Empty<object>());
		this.CaptionPanel.SetTitleIcon("/Game/Aki/UI/UIResources/Common/Atlas/SkillIcon/SkillIconNor/SP_IconT29.SP_IconT29");
		this.CaptionPanel.SetHelpCallBack(delegate
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(473);
		});
		this.InitDropDown();
		PhantomInteractListPanel visionList = this.VisionList;
		if (visionList != null)
		{
			visionList.Refresh(phantomInteractEditViewParam.InfoData.EquippedVisionData.Cast<IPhantomInteractItemData>().ToList<IPhantomInteractItemData>(), true, true);
		}
		this.RefreshRightScrollData();
		IPhantomInteractItemData selectedItemData = editViewModel.SelectedItemData;
		int value = editViewModel.FindGridIndexInMultiTemplate((selectedItemData != null) ? selectedItemData.MonsterId : 0);
		this.RefreshRightScrollView(new int?(value), false);
		this.Refresh();
		if (phantomInteractEditViewParam.FromSummonView)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Start01", false, null, false);
			}
		}
		else
		{
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.PlayLevelSequenceByName("Start02", false, null, false);
			}
		}
		this.ViewStarted = true;
	}

	// Token: 0x060124AD RID: 74925 RVA: 0x005077BD File Offset: 0x005059BD
	protected override void OnAddEventListener()
	{
		if (Singleton<EventSystem>.Instance.HasWithTarget<HitInformation, HitContext>(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit)))
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit));
	}

	// Token: 0x060124AE RID: 74926 RVA: 0x005077FD File Offset: 0x005059FD
	protected override void OnRemoveEventListener()
	{
		this.RemoveCharBeHitListener();
	}

	// Token: 0x060124AF RID: 74927 RVA: 0x00507805 File Offset: 0x00505A05
	private CostTabItem TabItemProxyCreate(UUIItem uiItem, int index)
	{
		CostTabItem costTabItem = new CostTabItem(uiItem);
		costTabItem.Init();
		return costTabItem;
	}

	// Token: 0x060124B0 RID: 74928 RVA: 0x00507814 File Offset: 0x00505A14
	private void ToggleCallBack(int index)
	{
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		int costValue = this.allCostToggleInfo[index].CostValue;
		this.RefreshRightScrollViewGrid(-1);
		editViewModel.SetFilterCost(costValue);
		if (this.ViewStarted)
		{
			editViewModel.RefreshFilterGridViewData();
		}
		this.Refresh();
		this.RefreshRightScrollData();
		this.RefreshRightScrollView(null, true);
	}

	// Token: 0x060124B1 RID: 74929 RVA: 0x00507874 File Offset: 0x00505A74
	private void ConfirmEquipHandler(int _)
	{
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		IPhantomInteractItemData selectedItemData = editViewModel.SelectedItemData;
		int num = (selectedItemData != null) ? selectedItemData.MonsterId : 0;
		editViewModel.ConfirmEquipHandler();
		this.Refresh();
		PhantomInteractEditViewModel phantomInteractEditViewModel = editViewModel;
		PhantomInteractEditGridViewModel selectedGridData = editViewModel.SelectedGridData;
		int num2 = phantomInteractEditViewModel.FindGridIndexInMultiTemplate((selectedGridData != null) ? selectedGridData.MonsterId : 0);
		if (num2 >= 0)
		{
			this.RefreshRightScrollViewGrid(num2);
		}
		if (num <= 0)
		{
			return;
		}
		int num3 = editViewModel.FindGridIndexInMultiTemplate(num);
		if (num3 >= 0)
		{
			this.RefreshRightScrollViewGrid(num3);
		}
	}

	// Token: 0x060124B2 RID: 74930 RVA: 0x005078E8 File Offset: 0x00505AE8
	private void ReplaceRecommendHandler()
	{
		PhantomInteractEditViewModel viewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		viewModel.SetEquipRecommendCallback(delegate
		{
			this.Refresh();
			List<int> filteredRecommendedIdList = viewModel.GetFilteredRecommendedIdList();
			int num = (filteredRecommendedIdList != null) ? filteredRecommendedIdList.Count : 0;
			for (int i = 0; i < num; i++)
			{
				int gridIndex = i + 1;
				this.RefreshRightScrollViewGrid(gridIndex);
			}
			this.RefreshRightScrollView(new int?(-1), false);
		});
		viewModel.EquipRecommendHandler();
	}

	// Token: 0x060124B3 RID: 74931 RVA: 0x00507934 File Offset: 0x00505B34
	private void OnListItemClick(IPhantomInteractItemData itemData)
	{
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		int itemIndex = itemData.ItemIndex;
		IPhantomInteractItemData selectedItemData = editViewModel.SelectedItemData;
		bool flag = itemIndex != ((selectedItemData != null) ? selectedItemData.ItemIndex : -1);
		int monsterId = itemData.MonsterId;
		if (flag && monsterId > 0)
		{
			int num = editViewModel.FindGridIndexInMultiTemplate(itemData.MonsterId);
			if (num < 0)
			{
				StaticTabComponent<CostTabItem> costTabComponent = this.CostTabComponent;
				object obj = costTabComponent == null || costTabComponent.GetSelectedIndex() != 0;
				CommonDropDown<int, EFilterIsSpecialOption> filterDropDown = this.FilterDropDown;
				bool flag2 = filterDropDown == null || filterDropDown.GetSelectedIndex() != 0;
				object obj2 = obj;
				if (obj2 != null)
				{
					StaticTabComponent<CostTabItem> costTabComponent2 = this.CostTabComponent;
					if (costTabComponent2 != null)
					{
						costTabComponent2.SelectToggleByIndex(0, true);
					}
				}
				if (flag2)
				{
					CommonDropDown<int, EFilterIsSpecialOption> filterDropDown2 = this.FilterDropDown;
					if (filterDropDown2 != null)
					{
						filterDropDown2.SetSelectedIndex(0, true);
					}
				}
				if ((obj2 | flag2) != null)
				{
					num = editViewModel.FindGridIndexInMultiTemplate(itemData.MonsterId);
				}
			}
			this.RefreshRightScrollView(new int?((num < 0) ? 0 : num), true);
		}
		editViewModel.SelectItem(itemData.ItemIndex);
		this.Refresh();
	}

	// Token: 0x060124B4 RID: 74932 RVA: 0x00507A1C File Offset: 0x00505C1C
	private void OnMoveNextSkinClick()
	{
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		editViewModel.MoveNextSkinHandler();
		this.Refresh();
		PhantomInteractEditGridViewModel selectedGridData = editViewModel.SelectedGridData;
		int num = editViewModel.FindGridIndexInMultiTemplate((selectedGridData != null) ? selectedGridData.MonsterId : 0);
		if (num >= 0)
		{
			this.RefreshRightScrollViewGrid(num);
		}
	}

	// Token: 0x060124B5 RID: 74933 RVA: 0x00507A64 File Offset: 0x00505C64
	public void Refresh()
	{
		PhantomInteractInfoData interactInfoData = ModelBase<PhantomInteractModel>.Instance.InteractInfoData;
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		this.ApplyBtnState(editViewModel.BtnState, editViewModel.BtnAvailable);
		PhantomInteractListPanel visionList = this.VisionList;
		if (visionList != null)
		{
			visionList.Refresh(interactInfoData.EquippedVisionData.Cast<IPhantomInteractItemData>().ToList<IPhantomInteractItemData>(), true, true);
		}
		IPhantomInteractItemData selectedItemData = editViewModel.SelectedItemData;
		if (selectedItemData != null)
		{
			this.VisionList.SetSelectedItem(selectedItemData.ItemIndex);
		}
		PhantomInteractEditGridViewModel selectedGridData = editViewModel.SelectedGridData;
		bool flag = selectedGridData != null && selectedGridData.IsUnlocked;
		PhantomInteractEditGridViewModel selectedGridData2 = editViewModel.SelectedGridData;
		bool flag2 = selectedGridData2 != null && selectedGridData2.HasSkin;
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag2 && flag);
		}
		int num = (selectedGridData != null) ? selectedGridData.MonsterId : 0;
		if (this.CurrentDetailMonsterId != num)
		{
			this.CurrentDetailMonsterId = num;
		}
		PhantomInteractEditGridViewModel selectedGridData3 = editViewModel.SelectedGridData;
		int newId = (selectedGridData3 != null) ? selectedGridData3.MonsterId : 0;
		this.RefreshSelectGridId(newId);
		PhantomInteractDetailPanelGroup detailPanelGroup = this.DetailPanelGroup;
		if (detailPanelGroup == null)
		{
			return;
		}
		detailPanelGroup.RefreshDetailPanel(editViewModel.ShowDetail, editViewModel.DetailViewModel);
	}

	// Token: 0x060124B6 RID: 74934 RVA: 0x00507B7C File Offset: 0x00505D7C
	private void RefreshSelectGridId(int newId)
	{
		if (newId == this.CurrentSelectGridId)
		{
			return;
		}
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		int gridIndex = editViewModel.FindGridIndexInMultiTemplate(this.CurrentSelectGridId);
		this.RefreshRightScrollViewGrid(gridIndex);
		int gridIndex2 = editViewModel.FindGridIndexInMultiTemplate(newId);
		this.RefreshRightScrollViewGrid(gridIndex2);
		this.CurrentSelectGridId = newId;
	}

	// Token: 0x060124B7 RID: 74935 RVA: 0x00507BC8 File Offset: 0x00505DC8
	private void ApplyBtnState(EPhantomInteractEditBtnState state, bool enableClick)
	{
		bool flag = state == EPhantomInteractEditBtnState.Invisible;
		ButtonItem btnConfirm = this.BtnConfirm;
		if (btnConfirm != null)
		{
			btnConfirm.SetUiActive(!flag);
		}
		this.SetConfirmBtnText(state);
		ButtonItem btnConfirm2 = this.BtnConfirm;
		if (btnConfirm2 == null)
		{
			return;
		}
		btnConfirm2.SetEnableClick(enableClick);
	}

	// Token: 0x060124B8 RID: 74936 RVA: 0x00507C08 File Offset: 0x00505E08
	private void SetConfirmBtnText(EPhantomInteractEditBtnState state)
	{
		string text;
		switch (state)
		{
		case EPhantomInteractEditBtnState.UnEquip:
			text = "Text_PhantomTakeOff_Text";
			goto IL_34;
		case EPhantomInteractEditBtnState.Equip:
			text = "Text_PhantomPutOn_Text";
			goto IL_34;
		case EPhantomInteractEditBtnState.Swap:
			text = "Text_PhantomReplace_Text";
			goto IL_34;
		}
		text = null;
		IL_34:
		if (text != null)
		{
			ButtonItem btnConfirm = this.BtnConfirm;
			if (btnConfirm == null)
			{
				return;
			}
			btnConfirm.SetLocalTextNew(text, Array.Empty<object>());
		}
	}

	// Token: 0x060124B9 RID: 74937 RVA: 0x00507C62 File Offset: 0x00505E62
	private PhantomInteractDropDownItem CreateDropDownItem(UUIItem uiItem, EFilterIsSpecialOption data)
	{
		return new PhantomInteractDropDownItem(uiItem);
	}

	// Token: 0x060124BA RID: 74938 RVA: 0x00507C6A File Offset: 0x00505E6A
	private PhantomInteractDropDownTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new PhantomInteractDropDownTitleItem(uiItem);
	}

	// Token: 0x060124BB RID: 74939 RVA: 0x00507C74 File Offset: 0x00505E74
	private void RefreshRightScrollData()
	{
		this.RightScrollDataList = new List<IMultiTemplateGridData>();
		this.TitleTemplatePositionList.Clear();
		int num = 0;
		int num2 = 0;
		PhantomInteractEditViewModel editViewModel = ModelBase<PhantomInteractModel>.Instance.EditViewModel;
		foreach (IPhantomGridListData phantomGridListData in editViewModel.GridsDataList)
		{
			if (phantomGridListData.TitleType != EGridTitleType.Hide)
			{
				PhantomGridRowTitleTemplateData titleTemplateData = this.GetTitleTemplateData(num2++);
				titleTemplateData.Data = (int)phantomGridListData.TitleType;
				titleTemplateData.ClickRecommendBtnCb = new Action(this.ReplaceRecommendHandler);
				this.TitleTemplatePositionList.Add(this.RightScrollDataList.Count);
				this.RightScrollDataList.Add(titleTemplateData);
			}
			foreach (int key in phantomGridListData.MonsterIds)
			{
				PhantomInteractEditGridViewModel phantomInteractEditGridViewModel = null;
				PhantomInteractEditGridViewModel phantomInteractEditGridViewModel2;
				if (editViewModel.GridViewModelMap.TryGetValue(key, out phantomInteractEditGridViewModel2))
				{
					phantomInteractEditGridViewModel = phantomInteractEditGridViewModel2;
				}
				if (phantomInteractEditGridViewModel != null)
				{
					PhantomGridGridTemplateData gridTemplateData = this.GetGridTemplateData(num++);
					gridTemplateData.Data = phantomInteractEditGridViewModel;
					gridTemplateData.OnClickCb = new Action<IPhantomInteractGridViewModel, int>(this.OnClickGridItem);
					phantomInteractEditGridViewModel.GridIndex = this.RightScrollDataList.Count;
					this.RightScrollDataList.Add(gridTemplateData);
				}
			}
		}
	}

	// Token: 0x060124BC RID: 74940 RVA: 0x00507E00 File Offset: 0x00506000
	private PhantomGridGridTemplateData GetGridTemplateData(int index)
	{
		for (int i = index - this.GridTemplateDataList.Count; i >= 0; i--)
		{
			PhantomGridGridTemplateData item = new PhantomGridGridTemplateData();
			this.GridTemplateDataList.Add(item);
		}
		return this.GridTemplateDataList[index];
	}

	// Token: 0x060124BD RID: 74941 RVA: 0x00507E44 File Offset: 0x00506044
	private PhantomGridRowTitleTemplateData GetTitleTemplateData(int index)
	{
		for (int i = index - this.TitleTemplateDataList.Count; i >= 0; i--)
		{
			PhantomGridRowTitleTemplateData item = new PhantomGridRowTitleTemplateData();
			this.TitleTemplateDataList.Add(item);
		}
		return this.TitleTemplateDataList[index];
	}

	// Token: 0x060124BE RID: 74942 RVA: 0x00507E88 File Offset: 0x00506088
	private void RefreshRightScrollView(int? focusIndex = null, bool playAnim = false)
	{
		MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.RightScrollDataList);
		int num = focusIndex.GetValueOrDefault();
		foreach (int num2 in this.TitleTemplatePositionList)
		{
			if (num > num2 && num <= num2 + 3)
			{
				num = num2;
				break;
			}
		}
		multiTemplateScrollViewRefreshContext.ScrollToGridIndex = num;
		multiTemplateScrollViewRefreshContext.GridAnimName = "Start";
		multiTemplateScrollViewRefreshContext.PlayGridAnim = playAnim;
		MultiTemplateScrollView multiTemplateScrollView = this.MultiTemplateScrollView;
		if (multiTemplateScrollView != null)
		{
			multiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
		}
		bool uiactive = this.RightScrollDataList.Count <= 0;
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x060124BF RID: 74943 RVA: 0x00507F4C File Offset: 0x0050614C
	private void RefreshRightScrollViewGrid(int gridIndex)
	{
		if (gridIndex < 0 || gridIndex >= this.RightScrollDataList.Count)
		{
			return;
		}
		IMultiTemplateGridData multiTemplateGridData = this.RightScrollDataList[gridIndex];
		MultiTemplateScrollView multiTemplateScrollView = this.MultiTemplateScrollView;
		ISyncGridProxy syncGridProxy = (multiTemplateScrollView != null) ? multiTemplateScrollView.GetProxyByGridIndex(gridIndex) : null;
		PhantomGridGridTemplateData phantomGridGridTemplateData = multiTemplateGridData as PhantomGridGridTemplateData;
		if (phantomGridGridTemplateData != null && syncGridProxy != null)
		{
			syncGridProxy.Refresh(phantomGridGridTemplateData.Data);
		}
	}

	// Token: 0x060124C0 RID: 74944 RVA: 0x00507FA4 File Offset: 0x005061A4
	private void OnClickGridItem(IPhantomInteractGridViewModel data, int gridIndex)
	{
		ModelBase<PhantomInteractModel>.Instance.EditViewModel.SelectGrid(data.MonsterId);
		this.Refresh();
	}

	// Token: 0x060124C1 RID: 74945 RVA: 0x00507FC1 File Offset: 0x005061C1
	private void OnCharBeHit(HitInformation hitData, HitContext hitContext)
	{
		this.RemoveCharBeHitListener();
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x060124C2 RID: 74946 RVA: 0x00507FD4 File Offset: 0x005061D4
	private void RemoveCharBeHitListener()
	{
		if (!Singleton<EventSystem>.Instance.HasWithTarget<HitInformation, HitContext>(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit)))
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget(SceneTeam.Local, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnCharBeHit));
	}

	// Token: 0x060124C3 RID: 74947 RVA: 0x00508014 File Offset: 0x00506214
	private void SetOtherTeamEntitiesEnable(bool isEnable)
	{
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
		{
			Entity entity = entityHandle.Entity;
			if (!(!entity) && !entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy)
			{
				if (isEnable)
				{
					int handle;
					if (this.DisabledEntityHandles.TryGetValue(entity.Id, out handle))
					{
						entity.Enable(handle, "PhantomInteractEditView_Show");
						this.DisabledEntityHandles.Remove(entity.Id);
					}
				}
				else
				{
					int value = entity.Disable("PhantomInteractEditView_Show");
					this.DisabledEntityHandles[entity.Id] = value;
				}
			}
		}
		if (isEnable)
		{
			this.DisabledEntityHandles.Clear();
		}
	}

	// Token: 0x04008EA6 RID: 36518
	private ICostToggleInfo[] allCostToggleInfo = new ICostToggleInfo[]
	{
		new CostToggleInfo
		{
			Component = 9,
			CostValue = -1
		},
		new CostToggleInfo
		{
			Component = 10,
			CostValue = 1
		},
		new CostToggleInfo
		{
			Component = 11,
			CostValue = 3
		},
		new CostToggleInfo
		{
			Component = 12,
			CostValue = 4
		}
	};

	// Token: 0x04008EA7 RID: 36519
	private EFilterIsSpecialOption[] allFilterOption = new EFilterIsSpecialOption[]
	{
		EFilterIsSpecialOption.All,
		EFilterIsSpecialOption.Special,
		EFilterIsSpecialOption.NonSpecial
	};

	// Token: 0x04008EA8 RID: 36520
	private const string CAPTION_ICON_ID = "/Game/Aki/UI/UIResources/Common/Atlas/SkillIcon/SkillIconNor/SP_IconT29.SP_IconT29";

	// Token: 0x04008EA9 RID: 36521
	private const string CAPTION_TITLE_ID = "ExploreTools_1007_Name";

	// Token: 0x04008EAA RID: 36522
	private const int CAPTION_HELP_ID = 473;

	// Token: 0x04008EAB RID: 36523
	private const int GRID_FOCUS_CLAMP_TO_TITLE_RANGE = 3;

	// Token: 0x04008EAC RID: 36524
	[Nullable(2)]
	private PopupCaptionItem CaptionPanel;

	// Token: 0x04008EAD RID: 36525
	[Nullable(2)]
	private PhantomInteractListPanel VisionList;

	// Token: 0x04008EAE RID: 36526
	[Nullable(2)]
	private PhantomInteractDetailPanelGroup DetailPanelGroup;

	// Token: 0x04008EAF RID: 36527
	[Nullable(2)]
	private ButtonItem BtnConfirm;

	// Token: 0x04008EB0 RID: 36528
	[Nullable(2)]
	private MultiTemplateScrollView MultiTemplateScrollView;

	// Token: 0x04008EB1 RID: 36529
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private StaticTabComponent<CostTabItem> CostTabComponent;

	// Token: 0x04008EB2 RID: 36530
	private List<IMultiTemplateGridData> RightScrollDataList = new List<IMultiTemplateGridData>();

	// Token: 0x04008EB3 RID: 36531
	[Nullable(2)]
	private CommonDropDown<int, EFilterIsSpecialOption> FilterDropDown;

	// Token: 0x04008EB4 RID: 36532
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04008EB5 RID: 36533
	private int CurrentDetailMonsterId;

	// Token: 0x04008EB6 RID: 36534
	private readonly List<PhantomGridGridTemplateData> GridTemplateDataList = new List<PhantomGridGridTemplateData>();

	// Token: 0x04008EB7 RID: 36535
	private readonly List<PhantomGridRowTitleTemplateData> TitleTemplateDataList = new List<PhantomGridRowTitleTemplateData>();

	// Token: 0x04008EB8 RID: 36536
	private readonly List<int> TitleTemplatePositionList = new List<int>();

	// Token: 0x04008EB9 RID: 36537
	private int CurrentSelectGridId;

	// Token: 0x04008EBA RID: 36538
	private bool ViewStarted;

	// Token: 0x04008EBB RID: 36539
	private readonly Dictionary<int, int> DisabledEntityHandles = new Dictionary<int, int>();

	// Token: 0x020087DD RID: 34781
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DE6B RID: 188011
		ItemPanelVisionList,
		// Token: 0x0402DE6C RID: 188012
		ScrollView,
		// Token: 0x0402DE6D RID: 188013
		ItemPanelEmpty,
		// Token: 0x0402DE6E RID: 188014
		ToggleGroupTopTab,
		// Token: 0x0402DE6F RID: 188015
		ItemSort,
		// Token: 0x0402DE70 RID: 188016
		ItemBtnConfirm,
		// Token: 0x0402DE71 RID: 188017
		BtnSkin,
		// Token: 0x0402DE72 RID: 188018
		ItemCaption,
		// Token: 0x0402DE73 RID: 188019
		ItemVisionEditTip,
		// Token: 0x0402DE74 RID: 188020
		TogTabCostAll,
		// Token: 0x0402DE75 RID: 188021
		TogTabCost1,
		// Token: 0x0402DE76 RID: 188022
		TogTabCost3,
		// Token: 0x0402DE77 RID: 188023
		TogTabCost4,
		// Token: 0x0402DE78 RID: 188024
		ItemTemplateTitle,
		// Token: 0x0402DE79 RID: 188025
		ItemTemplateGrid,
		// Token: 0x0402DE7A RID: 188026
		ItemEquipBtnGroup,
		// Token: 0x0402DE7B RID: 188027
		ItemGridContent
	}
}
