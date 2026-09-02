using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.RoleUi.TabView.VisionSubView;
using CSharpScript.Game.Module.UiComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x0200251C RID: 9500
[NullableContext(1)]
[Nullable(0)]
public class VisionEquipmentView : UiViewBase
{
	// Token: 0x060126D6 RID: 75478 RVA: 0x00511230 File Offset: 0x0050F430
	public VisionEquipmentView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060126D7 RID: 75479 RVA: 0x005112C4 File Offset: 0x0050F4C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUISprite)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(30, typeof(UUIText)),
			new ValueTuple<int, Type>(31, typeof(UUIItem)),
			new ValueTuple<int, Type>(32, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(33, typeof(UUIItem)),
			new ValueTuple<int, Type>(34, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(35, typeof(UUIItem)),
			new ValueTuple<int, Type>(37, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(21, new Action<EToggleState>(this.OnSimplyButtonClick)),
			new ValueTuple<int, Delegate>(27, new Action(this.OnMonsterSkinBtnClick)),
			new ValueTuple<int, Delegate>(29, new Action(this.OnClickCompareButton)),
			new ValueTuple<int, Delegate>(32, new Action(this.OnClickJumpVisionRecoveryButton)),
			new ValueTuple<int, Delegate>(34, new Action<EToggleState>(this.OnClickRecommendToggle))
		};
	}

	// Token: 0x060126D8 RID: 75480 RVA: 0x005116B0 File Offset: 0x0050F8B0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PhantomPersonalSkillActive, new Action<int>(this.RefreshPhantom));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomEquipError, new Action(this.OnEquipError));
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomEquip, new Action(this.OnPhantomEquip));
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.PhantomEquipWithSourceAndTargetPos, new Action<int, int, bool>(this.OnEquipEquipment));
		Singleton<EventSystem>.Instance.Add(EEventName.VisionFilterMonster, new Action(this.OnVisionFilterMonster));
		Singleton<EventSystem>.Instance.Add<UiCameraAnimationDefine.IFinishData>(EEventName.OnPlayCameraAnimationFinish, new Action<UiCameraAnimationDefine.IFinishData>(this.OnCameraFinish));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.VisionSkinViewClose, new Action<bool>(this.VisionSkinViewClose));
	}

	// Token: 0x060126D9 RID: 75481 RVA: 0x005117A0 File Offset: 0x0050F9A0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PhantomPersonalSkillActive, new Action<int>(this.RefreshPhantom));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhantomEquipError, new Action(this.OnEquipError));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhantomEquip, new Action(this.OnPhantomEquip));
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.PhantomEquipWithSourceAndTargetPos, new Action<int, int, bool>(this.OnEquipEquipment));
		Singleton<EventSystem>.Instance.Remove(EEventName.VisionFilterMonster, new Action(this.OnVisionFilterMonster));
		Singleton<EventSystem>.Instance.Remove<UiCameraAnimationDefine.IFinishData>(EEventName.OnPlayCameraAnimationFinish, new Action<UiCameraAnimationDefine.IFinishData>(this.OnCameraFinish));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.VisionSkinViewClose, new Action<bool>(this.VisionSkinViewClose));
	}

	// Token: 0x060126DA RID: 75482 RVA: 0x00511890 File Offset: 0x0050FA90
	protected override void OnStart()
	{
		this.InitUiBlur();
		this.CameraState = false;
		base.GetItem(15).SetUIActive(true);
		base.GetItem(15).SetRaycastTarget(false);
		base.GetItem(9).SetUIActive(true);
		this.FilterEntrance = new FilterEntrance<IPhantomItemData>(base.GetItem(12), new TUpdateDataListFunction<IPhantomItemData>(this.OnFilterRefresh));
		this.FilterEntrance.OnBtnClearClickCallback = delegate()
		{
			this.VisionEquipmentRecommendItem.ClearSelectMainPhantom(true);
		};
		this.SortEntrance = new SortEntrance<IPhantomItemData>(base.GetItem(13), new TUpdateDataListFunction<IPhantomItemData>(this.OnFilterRefresh));
		this.LoopScrollView = new LoopScrollView<VisionMediumItemGrid, PhantomBattleData>(base.GetLoopScrollViewComponent(6), base.GetItem(8).GetOwner() as AUIBaseActor, new Func<VisionMediumItemGrid>(this.InitItem), false);
		this.InitDetailItem();
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAlpha(1f);
		}
		this.RootLevelSequence = new LevelSequencePlayer(this.RootItem);
		this.RootLevelSequence.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinishEvent), false);
		base.GetItem(14).SetUIActive(false);
		this.RefreshUiBlur(false);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(7));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBackBtn));
		this.LongPressTime = (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerPressTime();
		this.ScrollerMoveDistance = (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerMoveDistance();
		this.BeforeLongPressTime = (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionBeforeScrollerLongPressTime();
		this.InitCurrentSelectVision();
		this.ShowDefaultElement();
		this.SetPressItemShowState(false);
		base.GetVerticalLayout(17).SetEnable(false);
		this.VisionDetailComponentCompare.RefreshViewByCompareState(true);
		this.InitCostTab();
		this.InitDropDown();
		this.InitState = true;
		EToggleState state = ModelBase<PhantomBattleModel>.Instance.GetIfSimpleState(1) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(21);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		this.RootLevelSequence.PlaySequencePurely("ContrastSwitch", false, true, null, null, false);
		this.CurrentAnimationState = false;
		base.GetButton(32).RootUIComp.Get().SetUIActive(ModelBase<FunctionModel>.Instance.IsOpen(10024001));
	}

	// Token: 0x060126DB RID: 75483 RVA: 0x00511AC6 File Offset: 0x0050FCC6
	private void InitUiBlur()
	{
		AUIBaseActor rootActor = this.RootActor;
		this.UiBlur = (((rootActor != null) ? rootActor.GetComponentByClass(TsUiBlur.StaticClass()) : null) as TsUiBlur);
		if (this.UiBlur != null)
		{
			this.UiBlur.SetEnableUiBlur(false);
		}
	}

	// Token: 0x060126DC RID: 75484 RVA: 0x00511B04 File Offset: 0x0050FD04
	protected override void OnHandlePostLoadScene(bool isSceneLoad)
	{
		if (this.PreSelectMeshId <= 0)
		{
			return;
		}
		if (ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.PreSelectMeshId) != null)
		{
			if (ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.PreSelectMeshId) != null)
			{
				this.RefreshMesh(this.PreSelectMeshId, false);
				SkeletalObserverHandle visionSkeletalHandle = this.VisionSkeletalHandle;
				if (((visionSkeletalHandle != null) ? visionSkeletalHandle.Model : null) != null)
				{
					ControllerBase<PhantomBattleController>.Instance.SetMeshTransform(this.VisionSkeletalHandle);
					return;
				}
			}
		}
		else
		{
			this.CurrentSelectPhantomData = null;
		}
	}

	// Token: 0x060126DD RID: 75485 RVA: 0x00511B78 File Offset: 0x0050FD78
	private void SequenceFinishEvent(string sequenceName)
	{
		if (sequenceName == "ContrastSwitch")
		{
			base.GetItem(11).SetUIActive(this.CurrentAnimationState);
		}
	}

	// Token: 0x060126DE RID: 75486 RVA: 0x00511B9A File Offset: 0x0050FD9A
	private void OnDeselectMainPhantomCallback()
	{
		FilterEntrance<IPhantomItemData> filterEntrance = this.FilterEntrance;
		if (filterEntrance != null)
		{
			filterEntrance.TryClearData();
		}
		this.MultiSelectDropDown.SetSelectedIndices(new List<int>
		{
			0
		});
		this.RefreshSelectAllToggleState();
	}

	// Token: 0x060126DF RID: 75487 RVA: 0x00511BCC File Offset: 0x0050FDCC
	private void OnMainPhantomFilterChanged(IMainPhantomFilterChangedInfo info)
	{
		if (info.IsDeselect)
		{
			return;
		}
		int num = this.CostArray.IndexOf(info.Cost);
		if (num >= 0)
		{
			StaticTabComponent<CostTabItem> staticTabComponent = this.StaticTabComponent;
			if (staticTabComponent == null)
			{
				return;
			}
			staticTabComponent.SelectToggleByIndex(num, false);
		}
	}

	// Token: 0x060126E0 RID: 75488 RVA: 0x00511C0C File Offset: 0x0050FE0C
	private void OnSelectAllCallback(List<int> fetterGroupIds, bool isSelectAll)
	{
		FilterEntrance<IPhantomItemData> filterEntrance = this.FilterEntrance;
		if (filterEntrance != null)
		{
			filterEntrance.TryClearData();
		}
		if (isSelectAll)
		{
			List<int> list = (from id in fetterGroupIds
			select this.FetterSuitFilterArray.IndexOf(id) into idx
			where idx > 0
			select idx).ToList<int>();
			MultiSelectDropDown<int, int> multiSelectDropDown = this.MultiSelectDropDown;
			List<int> selectedIndices;
			if (list.Count <= 0)
			{
				(selectedIndices = new List<int>()).Add(0);
			}
			else
			{
				selectedIndices = list;
			}
			multiSelectDropDown.SetSelectedIndices(selectedIndices);
		}
		else
		{
			this.MultiSelectDropDown.SetSelectedIndices(new List<int>
			{
				0
			});
		}
		this.UpdateFilterComponent();
		this.RefreshSelectAllToggleState();
	}

	// Token: 0x060126E1 RID: 75489 RVA: 0x00511CB4 File Offset: 0x0050FEB4
	private void RefreshSelectAllToggleState()
	{
		if (this.VisionEquipmentRecommendItem == null)
		{
			return;
		}
		List<int> selectedFetterGroupIds = this.GetSelectedFetterGroupIds();
		this.VisionEquipmentRecommendItem.RefreshSelectAllToggleState(selectedFetterGroupIds);
	}

	// Token: 0x060126E2 RID: 75490 RVA: 0x00511CE0 File Offset: 0x0050FEE0
	private void OnChangeSelectRecommendAttr()
	{
		if (this.InitState)
		{
			VisionMainSelectPhantomData currentMainPhantom = ModelBase<VisionRecommendModel>.Instance.CurrentMainPhantom;
			if (currentMainPhantom != null)
			{
				int num = this.FetterSuitFilterArray.IndexOf(currentMainPhantom.FetterGroupId);
				if (num > 0)
				{
					this.MultiSelectDropDown.SetSelectedIndices(new List<int>
					{
						num
					});
				}
				else
				{
					this.MultiSelectDropDown.SetSelectedIndices(new List<int>
					{
						0
					});
				}
				this.OnClickVisionAndRefreshVisionView(0);
				this.FilterEntrance.SelectSingleById(currentMainPhantom.MonsterId);
			}
			this.UpdateFilterComponent();
		}
		VisionEquipmentRecommendFetterGroupView visionEquipmentRecommendFetterGroupView = this.VisionEquipmentRecommendFetterGroupView;
		if (visionEquipmentRecommendFetterGroupView != null)
		{
			visionEquipmentRecommendFetterGroupView.Refresh(this.VisionEquipmentRecommendItem.CurrentPlanInfo.BuildFetterList());
		}
		this.RefreshSelectAllToggleState();
	}

	// Token: 0x060126E3 RID: 75491 RVA: 0x00511D90 File Offset: 0x0050FF90
	protected override UniTask OnBeforeStartAsync()
	{
		VisionEquipmentView.<OnBeforeStartAsync>d__73 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionEquipmentView.<OnBeforeStartAsync>d__73>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060126E4 RID: 75492 RVA: 0x00511DD4 File Offset: 0x0050FFD4
	private void InitDetailItem()
	{
		this.VisionDetailComponent.GetDetailUnderComponent().SetRightButtonClick(new Action(this.OnClickLevelUpButton));
		this.VisionDetailComponent.GetDetailUnderComponent().SetLeftButtonClick(new Action(this.OnClickEquipButton));
		this.VisionDetailComponent.SetActive(false);
		this.VisionDetailComponentCompare.SetButtonPanelShowState(true);
		this.VisionDetailComponentCompare.SetActive(true);
	}

	// Token: 0x060126E5 RID: 75493 RVA: 0x00511E40 File Offset: 0x00510040
	private UniTask InitVisionTabItem()
	{
		VisionEquipmentView.<InitVisionTabItem>d__75 <InitVisionTabItem>d__;
		<InitVisionTabItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitVisionTabItem>d__.<>4__this = this;
		<InitVisionTabItem>d__.<>1__state = -1;
		<InitVisionTabItem>d__.<>t__builder.Start<VisionEquipmentView.<InitVisionTabItem>d__75>(ref <InitVisionTabItem>d__);
		return <InitVisionTabItem>d__.<>t__builder.Task;
	}

	// Token: 0x060126E6 RID: 75494 RVA: 0x00511E84 File Offset: 0x00510084
	private void InitDropDown()
	{
		List<VisionFetterRecommendInfo> recommendInfoList = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.RoleId);
		IEnumerable<PhantomFetterGroup> fetterGroupArray = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupArray();
		this.FetterSortIdMap.Clear();
		foreach (PhantomFetterGroup phantomFetterGroup in fetterGroupArray)
		{
			this.FetterSuitFilterArray.Add(phantomFetterGroup.Id);
			this.FetterSortIdMap[phantomFetterGroup.Id] = phantomFetterGroup.SortId;
		}
		this.FetterSuitFilterArray.Sort(delegate(int a, int b)
		{
			VisionFetterRecommendInfo visionFetterRecommendInfo = (recommendInfoList != null) ? recommendInfoList.Find((VisionFetterRecommendInfo item) => item.GetRecommendFetterGroupId() == a) : null;
			VisionFetterRecommendInfo visionFetterRecommendInfo2 = (recommendInfoList != null) ? recommendInfoList.Find((VisionFetterRecommendInfo item) => item.GetRecommendFetterGroupId() == b) : null;
			if (visionFetterRecommendInfo != null && visionFetterRecommendInfo2 == null)
			{
				return -1;
			}
			if (visionFetterRecommendInfo == null && visionFetterRecommendInfo2 != null)
			{
				return 1;
			}
			if (visionFetterRecommendInfo != null && visionFetterRecommendInfo2 != null)
			{
				int usage = visionFetterRecommendInfo.GetUsage();
				return visionFetterRecommendInfo2.GetUsage() - usage;
			}
			int num = this.FetterSortIdMap.ContainsKey(a) ? this.FetterSortIdMap[a] : 0;
			return (this.FetterSortIdMap.ContainsKey(b) ? this.FetterSortIdMap[b] : 0) - num;
		});
		this.FetterSuitFilterArray.Insert(0, 0);
		this.MultiSelectDropDown.SetOnCloseCall(new Action<List<int>>(this.OnDropDownClose));
		this.MultiSelectDropDown.SetOnItemToggleCall(new Action<int, bool>(this.OnSuitToggled));
		this.MultiSelectDropDown.SetShowType(ECommonDropDownShowType.Down);
		this.MultiSelectDropDown.InitScroll(this.FetterSuitFilterArray, new Func<int, int>(this.GetDropDownTextId), new List<int>
		{
			0
		});
	}

	// Token: 0x060126E7 RID: 75495 RVA: 0x00511FB0 File Offset: 0x005101B0
	private void OnSuitToggled(int index, bool isSelected)
	{
		this.DropDownDirty = true;
		if (index == 0 && isSelected)
		{
			using (List<int>.Enumerator enumerator = this.MultiSelectDropDown.GetSelectedIndices().ToList<int>().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int num = enumerator.Current;
					if (num != 0)
					{
						this.MultiSelectDropDown.ToggleItem(num, false);
					}
				}
				goto IL_80;
			}
		}
		if (index != 0 && isSelected && this.MultiSelectDropDown.GetSelectedIndices().Contains(0))
		{
			this.MultiSelectDropDown.ToggleItem(0, false);
		}
		IL_80:
		if (this.MultiSelectDropDown.GetSelectedIndices().Count == 0)
		{
			this.MultiSelectDropDown.ToggleItem(0, true);
		}
	}

	// Token: 0x060126E8 RID: 75496 RVA: 0x0051206C File Offset: 0x0051026C
	private void OnDropDownClose(List<int> indices)
	{
		if (this.InitState && this.DropDownDirty)
		{
			this.DropDownDirty = false;
			this.UpdateFilterComponent();
			VisionMainSelectPhantomData currentMainPhantom = ModelBase<VisionRecommendModel>.Instance.CurrentMainPhantom;
			if (currentMainPhantom != null)
			{
				List<int> selectedFetterGroupIds = this.GetSelectedFetterGroupIds();
				if (selectedFetterGroupIds.Count > 0 && !selectedFetterGroupIds.Contains(currentMainPhantom.FetterGroupId))
				{
					this.VisionEquipmentRecommendItem.ClearSelectMainPhantom(false);
				}
			}
		}
		this.RefreshSelectAllToggleState();
	}

	// Token: 0x060126E9 RID: 75497 RVA: 0x005120D4 File Offset: 0x005102D4
	private int GetDropDownTextId(int data)
	{
		return data;
	}

	// Token: 0x060126EA RID: 75498 RVA: 0x005120D7 File Offset: 0x005102D7
	private VisionEquipmentDropDownItem CreateDropDownItem(UUIItem uiItem, int data)
	{
		VisionEquipmentDropDownItem visionEquipmentDropDownItem = new VisionEquipmentDropDownItem(uiItem);
		visionEquipmentDropDownItem.SetRoleId(this.RoleId);
		return visionEquipmentDropDownItem;
	}

	// Token: 0x060126EB RID: 75499 RVA: 0x005120EB File Offset: 0x005102EB
	private VisionEquipmentMultiSelectDropDownTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new VisionEquipmentMultiSelectDropDownTitleItem(uiItem);
	}

	// Token: 0x060126EC RID: 75500 RVA: 0x005120F4 File Offset: 0x005102F4
	private List<int> GetSelectedFetterGroupIds()
	{
		MultiSelectDropDown<int, int> multiSelectDropDown = this.MultiSelectDropDown;
		IReadOnlySet<int> readOnlySet = (multiSelectDropDown != null) ? multiSelectDropDown.GetSelectedIndices() : null;
		if (readOnlySet == null || readOnlySet.Contains(0) || readOnlySet.Count == 0)
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		foreach (int index in readOnlySet)
		{
			int num = this.FetterSuitFilterArray[index];
			if (num > 0)
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x060126ED RID: 75501 RVA: 0x00512184 File Offset: 0x00510384
	private void InitCostTab()
	{
		int num = 23;
		int num2 = 26;
		List<UUIItem> list = new List<UUIItem>();
		for (int i = num; i <= num2; i++)
		{
			UUIItem item = base.GetItem(i);
			if (item != null)
			{
				list.Add(item);
			}
		}
		UUIItem item2 = base.GetItem(20);
		this.StaticTabComponent = new StaticTabComponent<CostTabItem>(new Func<UUIItem, int, CostTabItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack));
		this.StaticTabComponent.Init(list);
		int num3 = item2.GetAttachUIChildren().Num();
		for (int j = 0; j < num3; j++)
		{
			int num4 = j;
			if (j > 1)
			{
				num4++;
			}
			this.CostArray.Add(num4);
		}
		this.StaticTabComponent.SelectToggleByIndex(0, true);
	}

	// Token: 0x060126EE RID: 75502 RVA: 0x00512237 File Offset: 0x00510437
	private CostTabItem TabItemProxyCreate(UUIItem uiItem, int index)
	{
		CostTabItem costTabItem = new CostTabItem(uiItem);
		costTabItem.Init();
		return costTabItem;
	}

	// Token: 0x060126EF RID: 75503 RVA: 0x00512245 File Offset: 0x00510445
	private void ToggleCallBack(int index)
	{
		this.CurrentCost = this.CostArray[index];
		this.VisionEquipmentRecommendItem.ChangeCost(this.CurrentCost, this.RoleId);
	}

	// Token: 0x060126F0 RID: 75504 RVA: 0x00512270 File Offset: 0x00510470
	private void OnSimplyButtonClick(EToggleState toggleState)
	{
		ModelBase<PhantomBattleModel>.Instance.SaveIfSimpleState(1, toggleState != EToggleState.ETT_Checked);
	}

	// Token: 0x060126F1 RID: 75505 RVA: 0x00512284 File Offset: 0x00510484
	private void OnMonsterSkinBtnClick()
	{
		VisionSkinViewOpenParam visionSkinViewOpenParam = new VisionSkinViewOpenParam();
		PhantomBattleData currentSelectPhantomData = this.CurrentSelectPhantomData;
		visionSkinViewOpenParam.UniqueId = ((currentSelectPhantomData != null) ? new int?(currentSelectPhantomData.GetUniqueId()) : null);
		visionSkinViewOpenParam.ShowItemIdList = null;
		IVisionSkinViewOpenParam param = visionSkinViewOpenParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionSkinView, param, null);
	}

	// Token: 0x060126F2 RID: 75506 RVA: 0x005122D4 File Offset: 0x005104D4
	private void OnCameraFinish(UiCameraAnimationDefine.IFinishData finishData)
	{
		if (finishData.ToHandleData.ViewName != EUiViewName.VisionEquipmentView)
		{
			return;
		}
		if (!base.IsShowOrShowing)
		{
			return;
		}
		if (!this.CameraState)
		{
			this.CameraState = true;
			this.RefreshMesh((this.CurrentSelectPhantomData != null) ? this.CurrentSelectPhantomData.GetUniqueId() : 0, false);
		}
	}

	// Token: 0x060126F3 RID: 75507 RVA: 0x00512334 File Offset: 0x00510534
	private void VisionSkinViewClose(bool skinChanged)
	{
		if (!skinChanged)
		{
			return;
		}
		int currentMeshId = this.CurrentMeshId;
		this.CurrentMeshId = 0;
		this.RefreshMesh(currentMeshId, false);
	}

	// Token: 0x060126F4 RID: 75508 RVA: 0x0051235C File Offset: 0x0051055C
	private void InitCurrentSelectVision()
	{
		if (this.PresetSelectIndexInternal >= 0)
		{
			this.CurrentSelectIndex = (EPhantomItemIndex)this.PresetSelectIndexInternal;
			ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = this.PresetSelectIndexInternal;
		}
		else
		{
			this.CurrentSelectIndex = (EPhantomItemIndex)ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex;
		}
		int currentSelectUniqueId = ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId;
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(currentSelectUniqueId);
		if (currentSelectUniqueId > 0 && phantomBattleData != null)
		{
			this.SetCurrentSelectPhantomData(phantomBattleData);
			return;
		}
		this.SetCurrentSelectPhantomData(this.GetCurrentSelectIndexPhantomData((int)this.CurrentSelectIndex));
	}

	// Token: 0x060126F5 RID: 75509 RVA: 0x005123D8 File Offset: 0x005105D8
	private void TryUnbindConfirmButtonRedDot()
	{
		if (this.CurrentConfirmButtonRedDotUniqueId > 0)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.VisionIdentifyTab, base.GetItem(28), this.CurrentConfirmButtonRedDotUniqueId);
			this.CurrentConfirmButtonRedDotUniqueId = 0;
		}
	}

	// Token: 0x060126F6 RID: 75510 RVA: 0x00512404 File Offset: 0x00510604
	private void RefreshConfirmButtonRedDot()
	{
		this.TryUnbindConfirmButtonRedDot();
		if (this.CurrentSelectPhantomData != null)
		{
			this.CurrentConfirmButtonRedDotUniqueId = this.CurrentSelectPhantomData.GetUniqueId();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.VisionIdentifyTab, base.GetItem(28), null, this.CurrentConfirmButtonRedDotUniqueId);
		}
	}

	// Token: 0x060126F7 RID: 75511 RVA: 0x00512440 File Offset: 0x00510640
	private void ShowDefaultElement()
	{
		this.RefreshView(this.CurrentSelectPhantomData);
		this.RefreshMesh((this.CurrentSelectPhantomData != null) ? this.CurrentSelectPhantomData.GetUniqueId() : 0, false);
		this.RefreshPhantomClickState();
	}

	// Token: 0x060126F8 RID: 75512 RVA: 0x00512474 File Offset: 0x00510674
	private void OnClickEquipButton()
	{
		RoleInstance roleInstance = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		Action doFunction = delegate()
		{
			ControllerBase<PhantomBattleController>.Instance.SendPhantomPutOnRequest(this.CurrentSelectPhantomData.GetUniqueId(), roleInstance.GetRoleId(), (int)this.CurrentSelectIndex, -1, false);
		};
		this.DoEquip(this.CurrentSelectPhantomData, (int)this.CurrentSelectIndex, doFunction);
	}

	// Token: 0x060126F9 RID: 75513 RVA: 0x005124C2 File Offset: 0x005106C2
	private void SetPressItemAlpha(float alpha)
	{
		base.GetItem(18).SetAlpha(alpha);
		this.LongPressItemAlpha = alpha;
	}

	// Token: 0x060126FA RID: 75514 RVA: 0x005124D9 File Offset: 0x005106D9
	private void SetPressItemShowState(bool state)
	{
		base.GetItem(18).SetUIActive(state);
	}

	// Token: 0x060126FB RID: 75515 RVA: 0x005124E9 File Offset: 0x005106E9
	private void DoEquip(PhantomBattleData phantomData, int targetIndex, Action doFunction)
	{
		if (!this.CheckCost(phantomData, targetIndex))
		{
			this.ResetVisionPosition(true);
			return;
		}
		this.TryEquip(phantomData, targetIndex, doFunction);
	}

	// Token: 0x060126FC RID: 75516 RVA: 0x00512508 File Offset: 0x00510708
	private bool CheckCost(PhantomBattleData phantomData, int targetIndex)
	{
		int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(phantomData.GetUniqueId());
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		int roleIndexPhantomId = instance.GetRoleIndexPhantomId(roleInstanceById.GetRoleId(), targetIndex);
		int num = (instance.GetPhantomBattleData(roleIndexPhantomId) != null) ? instance.GetPhantomBattleData(roleIndexPhantomId).GetCost() : 0;
		int roleCurrentPhantomCost = instance.GetRoleCurrentPhantomCost(roleInstanceById.GetRoleId());
		if (equipRole != null && equipRole.Value != roleInstanceById.GetRoleId())
		{
			int num2 = instance.GetRoleCurrentPhantomCost(equipRole.Value) - phantomData.GetCost() + num;
			int num3 = roleCurrentPhantomCost - num + phantomData.GetCost();
			if (num2 > this.GetCostMax() || num3 > this.GetCostMax())
			{
				this.TryShowMaxCost();
				return false;
			}
		}
		else
		{
			if (equipRole != null && equipRole.Value == roleInstanceById.GetRoleId())
			{
				return true;
			}
			if (roleCurrentPhantomCost - num + phantomData.GetCost() > this.GetCostMax())
			{
				this.TryShowMaxCost();
				return false;
			}
		}
		return true;
	}

	// Token: 0x060126FD RID: 75517 RVA: 0x00512604 File Offset: 0x00510804
	private void TryShowMaxCost()
	{
		if (this.GetCostMax() < ConfigBase<PhantomBattleConfig>.Instance.GetVisionReachableCostMax())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.JumpToCalabash);
			Action value = delegate()
			{
				this.DestroyVisionHandle();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, null, delegate(bool success, int _)
				{
					if (success)
					{
						Singleton<UiManager>.Instance.CloseView(EUiViewName.VisionEquipmentView, null);
						Singleton<EventSystem>.Instance.Emit(EEventName.PhantomCostInsufficient);
					}
				});
			};
			confirmBoxDataNew.FunctionMap.Add(1, value);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.CostMax);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
	}

	// Token: 0x060126FE RID: 75518 RVA: 0x00512674 File Offset: 0x00510874
	private void RefreshCostText()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		int num = ModelBase<PhantomBattleModel>.Instance.GetRoleCurrentPhantomCost(roleInstanceById.GetRoleId());
		int roleIndexPhantomId = ModelBase<PhantomBattleModel>.Instance.GetRoleIndexPhantomId(roleInstanceById.GetRoleId(), (int)this.CurrentSelectIndex);
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleInstanceById.GetRoleId()).GetIncrIdList();
		int num2 = (this.CurrentSelectPhantomData != null) ? this.CurrentSelectPhantomData.GetUniqueId() : 0;
		bool flag = false;
		if (incrIdList != null)
		{
			for (int i = 0; i < incrIdList.Count; i++)
			{
				if (incrIdList[i] == num2)
				{
					flag = true;
					break;
				}
			}
		}
		if (roleIndexPhantomId > 0 && !flag)
		{
			PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(roleIndexPhantomId);
			num -= phantomDataBase.GetCost();
		}
		if (!flag)
		{
			num += ((this.CurrentSelectPhantomData != null) ? this.CurrentSelectPhantomData.GetCost() : 0);
		}
		string hexStr;
		string hexStr2;
		if (num > this.GetCostMax())
		{
			hexStr = ConfigBase<PhantomBattleConfig>.Instance.GetVisionCostColorAlert();
			hexStr2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionCostColorFull();
			if (!this.IfPlayingCostBlinkAnimate)
			{
				this.RootLevelSequence.PlaySequencePurely("CostBlink", false, false, null, null, false);
				this.IfPlayingCostBlinkAnimate = true;
			}
		}
		else if (num == this.GetCostMax())
		{
			hexStr = ConfigBase<PhantomBattleConfig>.Instance.GetVisionCostColorFull();
			hexStr2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionCostColorFull();
			this.RootLevelSequence.StopSequenceByKey("CostBlink", false, true);
			this.IfPlayingCostBlinkAnimate = false;
		}
		else
		{
			hexStr = ConfigBase<PhantomBattleConfig>.Instance.GetVisionCostColorBase();
			hexStr2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionCostColorBase();
			this.RootLevelSequence.StopSequenceByKey("CostBlink", false, true);
			this.IfPlayingCostBlinkAnimate = false;
		}
		base.GetText(5).SetText(StringUtils.Format("/{0}", new string[]
		{
			this.GetCostMax().ToString()
		}), true);
		base.GetText(30).SetText(StringUtils.Format("{0}", new string[]
		{
			num.ToString()
		}), true);
		base.GetText(30).SetColor(FColor.FromHex(hexStr));
		base.GetText(5).SetColor(FColor.FromHex(hexStr2));
	}

	// Token: 0x060126FF RID: 75519 RVA: 0x00512890 File Offset: 0x00510A90
	private void OnClickLevelUpButton()
	{
		VisionIntensifyViewPassData param = new VisionIntensifyViewPassData
		{
			UniqueId = this.CurrentSelectPhantomData.GetUniqueId(),
			Cost = this.CurrentCost,
			RoleId = this.RoleId
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionIntensifyView, param, null);
	}

	// Token: 0x06012700 RID: 75520 RVA: 0x005128DD File Offset: 0x00510ADD
	private void OnClickJumpVisionRecoveryButton()
	{
		this.PreSelectMeshId = this.CurrentMeshId;
		this.DestroyVisionHandle();
		ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRecoveryTabView, null);
	}

	// Token: 0x06012701 RID: 75521 RVA: 0x00512901 File Offset: 0x00510B01
	private void OnClickRecommendToggle(EToggleState toggleState)
	{
		if (this.CurrentCompareState)
		{
			this.OnCompareButtonClicked();
		}
		if (base.GetExtendToggle(34).GetToggleState() == EToggleState.ETT_Checked)
		{
			this.VisionEquipmentRecommendItem.Show(null);
			return;
		}
		this.VisionEquipmentRecommendItem.Hide(null);
	}

	// Token: 0x06012702 RID: 75522 RVA: 0x0051293C File Offset: 0x00510B3C
	private void OnClickCompareButton()
	{
		if (base.GetExtendToggle(34).GetToggleState() == EToggleState.ETT_Checked)
		{
			base.GetExtendToggle(34).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.VisionEquipmentRecommendItem.Hide(null);
		}
		this.OnCompareButtonClicked();
	}

	// Token: 0x06012703 RID: 75523 RVA: 0x00512974 File Offset: 0x00510B74
	private void OnCompareButtonClicked()
	{
		this.CurrentCompareState = !this.CurrentCompareState;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		int roleIndexPhantomId = ModelBase<PhantomBattleModel>.Instance.GetRoleIndexPhantomId(roleInstanceById.GetRoleId(), (int)this.CurrentSelectIndex);
		if (roleIndexPhantomId > 0)
		{
			if (this.CurrentCompareState)
			{
				base.GetItem(11).SetUIActive(true);
				this.RootLevelSequence.StopSequenceByKey("ContrastSwitch", false, false);
				this.RootLevelSequence.PlaySequencePurely("ContrastSwitch", false, false, null, null, false);
				this.CurrentAnimationState = true;
			}
			else
			{
				if (this.CurrentAnimationState)
				{
					this.RootLevelSequence.StopSequenceByKey("ContrastSwitch", false, false);
					this.RootLevelSequence.PlaySequencePurely("ContrastSwitch", false, true, null, null, false);
				}
				this.CurrentAnimationState = false;
			}
		}
		else
		{
			this.CurrentCompareState = false;
		}
		bool flag = this.CurrentCompareState && roleIndexPhantomId > 0;
		base.GetItem(14).SetUIActive(flag);
		this.RefreshUiBlur(flag);
		this.RefreshVisionDetailCompare();
	}

	// Token: 0x06012704 RID: 75524 RVA: 0x00512A80 File Offset: 0x00510C80
	private void RefreshVisionDetailCompare()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(roleInstanceById.GetRoleId(), (int)this.CurrentSelectIndex);
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(equipByIndex);
		if (phantomBattleData != null)
		{
			this.VisionDetailComponentCompare.Update(phantomBattleData, this.RoleId, this.CurrentCost, true);
			return;
		}
		RoleInstance roleInstanceById2 = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		if (ModelBase<PhantomBattleModel>.Instance.GetRoleIndexPhantomId(roleInstanceById2.GetRoleId(), (int)this.CurrentSelectIndex) == 0 && this.CurrentAnimationState)
		{
			this.RootLevelSequence.PlaySequencePurely("ContrastSwitch", false, true, null, null, false);
			this.CurrentAnimationState = false;
			this.CurrentCompareState = false;
		}
	}

	// Token: 0x06012705 RID: 75525 RVA: 0x00512B3B File Offset: 0x00510D3B
	private void RefreshUiBlur(bool state)
	{
		if (this.UiBlur != null)
		{
			this.UiBlur.SetEnableUiBlur(state);
		}
	}

	// Token: 0x06012706 RID: 75526 RVA: 0x00512B54 File Offset: 0x00510D54
	private VisionMediumItemGrid InitItem()
	{
		VisionMediumItemGrid visionMediumItemGrid = new VisionMediumItemGrid();
		visionMediumItemGrid.Source = this.Source;
		visionMediumItemGrid.RoleId = this.RoleId;
		visionMediumItemGrid.SetUseFixedAsync(true);
		visionMediumItemGrid.SetClickToggleEvent(new Action<PhantomBattleData, int>(this.OnPhantomItemClick));
		visionMediumItemGrid.SetOnRefreshEvent(new Action<VisionMediumItemGrid>(this.OnItemRefresh));
		visionMediumItemGrid.SetOnPointDownCallBack(new Action<VisionMediumItemGrid, PhantomBattleData>(this.OnPhantomPointerDown));
		visionMediumItemGrid.SetOnPointUpCallBack(new Action<VisionMediumItemGrid, PhantomBattleData>(this.OnPhantomPointerUp));
		return visionMediumItemGrid;
	}

	// Token: 0x06012707 RID: 75527 RVA: 0x00512BCD File Offset: 0x00510DCD
	private void OnItemRefresh(VisionMediumItemGrid item)
	{
		if (item.CheckSelectedState(this.CurrentSelectPhantomData))
		{
			this.LoopScrollView.DeselectCurrentGridProxy(false);
			this.LoopScrollView.SelectGridProxy(item.GridIndex, false);
		}
	}

	// Token: 0x06012708 RID: 75528 RVA: 0x00512BFB File Offset: 0x00510DFB
	private void SetCurrentSelectPhantomData(PhantomBattleData data)
	{
		this.CurrentSelectPhantomData = data;
		this.RefreshSwitchButtonText();
		this.RefreshCostText();
		this.RefreshConfirmButtonRedDot();
	}

	// Token: 0x06012709 RID: 75529 RVA: 0x00512C16 File Offset: 0x00510E16
	private void ClearPhantomClickTick()
	{
		if (this.PhantomClickTick != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.PhantomClickTick);
			this.PhantomClickTick = -1;
		}
	}

	// Token: 0x0601270A RID: 75530 RVA: 0x00512C3C File Offset: 0x00510E3C
	private void OnPhantomPointerDown(VisionMediumItemGrid item, PhantomBattleData data)
	{
		this.ClearPhantomClickTick();
		this.PressTime = 0f;
		this.FillPressTime = 0f;
		this.CheckState = true;
		this.CurrentPressItem = item;
		FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
		this.OnPressPositionX = worldPointInPlane.X;
		this.OnPressPositionY = worldPointInPlane.Z;
		this.AfterLongPressState = false;
		this.VisionEquipmentDragItem.UpdateItem(data);
		this.ScrollVisionDragItem.Refresh(data, false);
		this.SetPressItemShowState(true);
		this.SetPressItemAlpha(0f);
		this.CurrentDragIndex = -1;
		base.GetSprite(19).SetFillAmount(0f);
		this.PhantomClickTick = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnPhantomPointerTick), "RoleVisionAnimation", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
	}

	// Token: 0x0601270B RID: 75531 RVA: 0x00512D14 File Offset: 0x00510F14
	private void RefreshLongPressItemPosition()
	{
		FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
		Vector2D vector2D = Vector2D.Create((double)pointerEventDataPosition.Value.X, (double)pointerEventDataPosition.Value.Y);
		Vector2D vector2D2 = vector2D;
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		FVector2D fvector2D = vector2D.ToUeVector2D(false);
		vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
		float num = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetX() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetXDir();
		float num2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetY() * (float)ConfigBase<PhantomBattleConfig>.Instance.GetVisionScrollerOffsetYDir();
		double num3 = vector2D.X + (double)num;
		double num4 = vector2D.Y + (double)num2;
		UUIItem item = base.GetItem(18);
		FVector fvector = new FVector((float)num3, (float)num4, 0f);
		item.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x0601270C RID: 75532 RVA: 0x00512DDC File Offset: 0x00510FDC
	[NullableContext(2)]
	private void OnPhantomPointerUp(VisionMediumItemGrid item, PhantomBattleData data)
	{
		this.ClearPhantomClickTick();
		base.GetLoopScrollViewComponent(6).SetEnable(true);
		VisionCommonDragItem scrollVisionDragItem = this.ScrollVisionDragItem;
		if (scrollVisionDragItem != null)
		{
			scrollVisionDragItem.ClearStayingItem();
		}
		this.VisionEquipmentDragItem.SetActive(false);
		this.SetPressItemShowState(false);
		this.CurrentDragIndex = 999;
		if (item == null && data == null)
		{
			this.ResetVisionPosition(true);
		}
	}

	// Token: 0x0601270D RID: 75533 RVA: 0x00512E39 File Offset: 0x00511039
	private void ClearScrollerMoveTick()
	{
		if (this.ScrollerTickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.ScrollerTickId);
			this.ScrollerTickId = -1;
		}
	}

	// Token: 0x0601270E RID: 75534 RVA: 0x00512E5C File Offset: 0x0051105C
	private void OnPhantomPointerTick(float _)
	{
		this.PressTime += Singleton<Time>.Instance.DeltaTime;
		if (this.AfterLongPressState)
		{
			this.ScrollVisionDragItem.TickCheckDrag();
		}
		if (!this.CheckState)
		{
			return;
		}
		if (this.PressTime > this.BeforeLongPressTime && this.LongPressItemAlpha == 0f)
		{
			this.RefreshLongPressItemPosition();
			this.SetPressItemAlpha(1f);
			this.FillPressTime = 0f;
		}
		if (this.LongPressItemAlpha > 0f)
		{
			this.FillPressTime += Singleton<Time>.Instance.DeltaTime;
		}
		if (this.CurrentPressItem != null)
		{
			FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
			float value = this.OnPressPositionX - worldPointInPlane.X;
			float value2 = this.OnPressPositionY - worldPointInPlane.Z;
			if (Math.Abs(value) + Math.Abs(value2) > this.ScrollerMoveDistance)
			{
				this.SetPressItemShowState(false);
				this.CheckState = false;
			}
		}
		if (this.FillPressTime > this.LongPressTime)
		{
			base.GetLoopScrollViewComponent(6).SetEnable(false);
			this.SetPressItemShowState(false);
			this.CheckState = false;
			this.AfterLongPressState = true;
			this.VisionEquipmentDragItem.SetActive(true);
			this.ScrollVisionDragItem.StartDragState();
			this.ScrollVisionDragItem.SetItemToPointerPosition();
			this.OnPointerDownCallBack(this.ScrollVisionDragItem.GetCurrentIndex());
			this.ScrollVisionDragItem.SetDragItemHierarchyMax();
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_drag");
			this.PhantomScrollerItemPositionTick = Singleton<TickSystem>.Instance.Add(new Action<float>(this.CheckPhantomsScrollerItemMove), "RoleVisionAnimation", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			return;
		}
		base.GetSprite(19).SetFillAmount(this.FillPressTime / this.LongPressTime);
	}

	// Token: 0x0601270F RID: 75535 RVA: 0x00513018 File Offset: 0x00511218
	private void CheckPhantomsScrollerItemMove(float _)
	{
		bool flag = Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(0);
		bool flag2 = Singleton<LguiEventSystemManager>.Instance.IsNowTriggerPressed(0);
		List<VisionCommonDragItem> stayingItem = this.ScrollVisionDragItem.GetStayingItem();
		if (!flag && !flag2)
		{
			if (stayingItem != null && stayingItem.Count == 0)
			{
				this.OnPhantomPointerUp(null, null);
				Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_drop");
			}
			else
			{
				this.OnDragEndCallBack(this.ScrollVisionDragItem, this.ScrollVisionDragItem.GetStayingItem(), false);
				this.OnPhantomPointerUp(null, null);
			}
			this.ClearScrollerItemMoveTick();
		}
	}

	// Token: 0x06012710 RID: 75536 RVA: 0x00513098 File Offset: 0x00511298
	private void ClearScrollerItemMoveTick()
	{
		if (this.PhantomScrollerItemPositionTick != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.PhantomScrollerItemPositionTick);
			this.PhantomScrollerItemPositionTick = -1;
		}
	}

	// Token: 0x06012711 RID: 75537 RVA: 0x005130BC File Offset: 0x005112BC
	private void OnPhantomItemClick(PhantomBattleData data, int index)
	{
		this.SetCurrentSelectPhantomData(data);
		this.LoopScrollView.DeselectCurrentGridProxy(false);
		this.LoopScrollView.SelectGridProxy(index, false);
		this.RefreshCurrentDetailComponent(data, false);
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectData = this.GetCurrentSelectIndexPhantomData(index);
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId = data.GetUniqueId();
		this.RefreshMesh(this.CurrentSelectPhantomData.GetUniqueId(), false);
		this.RefreshSkinButton();
	}

	// Token: 0x06012712 RID: 75538 RVA: 0x0051312C File Offset: 0x0051132C
	protected void TryEquip(PhantomBattleData phantomData, int targetIndex, Action doFunction)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		switch ((phantomData != null) ? ControllerBase<PhantomBattleController>.Instance.GetEquipState(roleInstanceById.GetRoleId(), targetIndex, phantomData.GetUniqueId()) : EEquipType.Equip)
		{
		case EEquipType.UnEquip:
			if (targetIndex == -1)
			{
				return;
			}
			this.UnEquip(targetIndex);
			return;
		case EEquipType.Equip:
			this.CheckIfCanEquip(phantomData, targetIndex, doFunction);
			return;
		case EEquipType.Replace:
			this.CheckIfCanEquip(phantomData, targetIndex, doFunction);
			return;
		default:
			return;
		}
	}

	// Token: 0x06012713 RID: 75539 RVA: 0x0051319C File Offset: 0x0051139C
	private void UnEquip(int index)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		ControllerBase<PhantomBattleController>.Instance.SendPhantomPutOnRequest(0, roleInstanceById.GetRoleId(), index, index, false);
	}

	// Token: 0x06012714 RID: 75540 RVA: 0x005131D0 File Offset: 0x005113D0
	private void CheckIfCanEquip(PhantomBattleData phantomData, int index, Action call)
	{
		int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(phantomData.GetUniqueId());
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		if (equipRole != null && equipRole.Value != roleInstanceById.GetRoleId())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomEquipRoleTip);
			RoleInstance roleInstanceById2 = ModelBase<RoleModel>.Instance.GetRoleInstanceById(equipRole.Value);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				roleInstanceById2.GetName(null)
			});
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
			});
			confirmBoxDataNew.FunctionMap.Add(2, call);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		call();
	}

	// Token: 0x06012715 RID: 75541 RVA: 0x0051329E File Offset: 0x0051149E
	protected void OnClickFailVision(int index)
	{
		this.ResetVisionPosition(true);
	}

	// Token: 0x06012716 RID: 75542 RVA: 0x005132A8 File Offset: 0x005114A8
	protected void OnClickVisionAndRefreshVisionView(int index)
	{
		base.GetItem(15).SetRaycastTarget(false);
		this.SetCurrentSelectIndex(index);
		this.RefreshVisionBySelectIndex(false, false, true);
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		if (ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(roleInstanceById.GetRoleId(), index) == 0)
		{
			this.LoopScrollView.ResetGridController();
		}
		this.RefreshCostText();
		if (this.CurrentSelectPhantomData != null)
		{
			this.SetCurrentSelectPhantomData(this.CurrentSelectPhantomData);
		}
		Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_click");
	}

	// Token: 0x06012717 RID: 75543 RVA: 0x0051332C File Offset: 0x0051152C
	private void SetCurrentSelectIndex(int index)
	{
		if (this.CurrentSelectIndex == (EPhantomItemIndex)index)
		{
			return;
		}
		this.CurrentSelectIndex = (EPhantomItemIndex)index;
		ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = index;
	}

	// Token: 0x06012718 RID: 75544 RVA: 0x0051334A File Offset: 0x0051154A
	private void RefreshVisionBySelectIndex(bool meshChangeGoldEffect = false, bool needResetScrollerWhenUniqueIdZero = true, bool needScrollToItem = true)
	{
		this.RefreshScrollByCurrentUniqueId(needResetScrollerWhenUniqueIdZero, needScrollToItem);
		this.RefreshVisionBySelectPhantomData(meshChangeGoldEffect);
	}

	// Token: 0x06012719 RID: 75545 RVA: 0x0051335C File Offset: 0x0051155C
	private void RefreshScrollByCurrentUniqueId(bool needResetScrollerWhenUniqueIdZero = true, bool needScrollToItem = true)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(roleInstanceById.GetRoleId(), (int)this.CurrentSelectIndex);
		if (equipByIndex != 0)
		{
			this.ScrollToUniqueItem(equipByIndex, needScrollToItem);
			PhantomBattleData currentSelectIndexPhantomData = this.GetCurrentSelectIndexPhantomData((int)this.CurrentSelectIndex);
			this.SetCurrentSelectPhantomData(currentSelectIndexPhantomData);
			return;
		}
		if (needResetScrollerWhenUniqueIdZero)
		{
			this.SetCurrentSelectPhantomData(this.GetCurrentSelectIndexPhantomData((int)this.CurrentSelectIndex));
			this.LoopScrollView.ResetGridController();
			PhantomBattleData currentSelectPhantomData = this.CurrentSelectPhantomData;
			this.ScrollToUniqueItem((currentSelectPhantomData != null) ? currentSelectPhantomData.GetUniqueId() : 0, needScrollToItem);
		}
	}

	// Token: 0x0601271A RID: 75546 RVA: 0x005133EC File Offset: 0x005115EC
	private void RefreshVisionBySelectPhantomData(bool meshChangeGoldEffect = false)
	{
		this.RefreshCurrentDetailComponent(this.CurrentSelectPhantomData, false);
		this.RefreshPhantomHeadSelectState();
		this.RefreshVisionDetailCompare();
		PhantomBattleData currentSelectPhantomData = this.CurrentSelectPhantomData;
		this.RefreshMesh((currentSelectPhantomData != null) ? currentSelectPhantomData.GetUniqueId() : 0, meshChangeGoldEffect);
		this.RefreshSkinButton();
		this.RefreshPhantomClickState();
		this.ResetVisionPosition(true);
	}

	// Token: 0x0601271B RID: 75547 RVA: 0x00513440 File Offset: 0x00511640
	private void SetClickStateUnCheck()
	{
		int count = this.RoleVisionItem.Count;
		for (int i = 0; i < count; i++)
		{
			this.RoleVisionItem[i].SetToggleState(EToggleState.ETT_UnChecked, false, true);
		}
	}

	// Token: 0x0601271C RID: 75548 RVA: 0x0051347C File Offset: 0x0051167C
	private void RefreshPhantomClickState()
	{
		int count = this.RoleVisionItem.Count;
		for (int i = 0; i < count; i++)
		{
			this.RoleVisionItem[i].SetToggleState((this.CurrentSelectIndex == (EPhantomItemIndex)i) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false);
		}
	}

	// Token: 0x0601271D RID: 75549 RVA: 0x005134C4 File Offset: 0x005116C4
	[NullableContext(2)]
	private PhantomBattleData GetCurrentSelectIndexPhantomData(int index)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		int equipByIndex = ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(roleInstanceById.GetRoleId(), index);
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(equipByIndex);
		if (phantomBattleData == null)
		{
			phantomBattleData = ((this.CurrentShowingDataList.Count > 0) ? this.CurrentShowingDataList[0] : null);
		}
		return phantomBattleData;
	}

	// Token: 0x0601271E RID: 75550 RVA: 0x00513522 File Offset: 0x00511722
	private void RefreshCurrentDetailComponent(PhantomBattleData data, bool ifOnEquip = false)
	{
		if (data == null)
		{
			this.VisionDetailComponent.SetActive(false);
			return;
		}
		this.VisionDetailComponent.SetActive(true);
		this.VisionDetailComponent.Update(data, this.RoleId, this.CurrentCost, false);
	}

	// Token: 0x0601271F RID: 75551 RVA: 0x0051355C File Offset: 0x0051175C
	private void ScrollToUniqueItem(int uniqueId, bool needScrollToItem = true)
	{
		this.LoopScrollView.DeselectCurrentGridProxy(false);
		bool flag = false;
		int num = 0;
		using (List<PhantomBattleData>.Enumerator enumerator = this.CurrentShowingDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetUniqueId() == uniqueId)
				{
					flag = true;
					break;
				}
				num++;
			}
		}
		if (!flag)
		{
			num = 0;
		}
		if (this.CurrentShowingDataList.Count > 0 && flag)
		{
			if (needScrollToItem)
			{
				this.LoopScrollView.ScrollToGridIndex(num, false);
			}
			this.LoopScrollView.SelectGridProxy(num, false);
		}
	}

	// Token: 0x06012720 RID: 75552 RVA: 0x005135FC File Offset: 0x005117FC
	protected override void OnBeforeShow()
	{
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		if (instance != null)
		{
			instance.AddNeedCameraFocusMethodDisableViewCount();
		}
		UiSceneUtils.SetSceneFloorReflection(true, true);
		if (this.CurrentMeshId > 0 && !Singleton<UiSceneManager>.Instance.HasVisionSkeletalHandle())
		{
			int currentMeshId = this.CurrentMeshId;
			this.CurrentMeshId = 0;
			this.RefreshMesh(currentMeshId, false);
		}
		ModelBase<PhantomBattleModel>.Instance.ClearCurrentDragIndex();
		this.RefreshCurrentDetailComponent(this.CurrentSelectPhantomData, false);
		this.RefreshVisionDetailCompare();
		if (ModelBase<PhantomBattleModel>.Instance.GetVisionLevelUpTag())
		{
			this.UpdateFilterComponent();
			ModelBase<PhantomBattleModel>.Instance.ClearVisionLevelUp();
		}
		else if (ModelBase<PhantomBattleModel>.Instance.CurrentSelectFetterGroupId > 0)
		{
			int num = this.FetterSuitFilterArray.IndexOf(ModelBase<PhantomBattleModel>.Instance.CurrentSelectFetterGroupId);
			ModelBase<PhantomBattleModel>.Instance.CurrentSelectFetterGroupId = 0;
			if (num > 0)
			{
				this.MultiSelectDropDown.SetSelectedIndices(new List<int>
				{
					num
				});
			}
			else
			{
				this.MultiSelectDropDown.SetSelectedIndices(new List<int>
				{
					0
				});
			}
			this.UpdateFilterComponent();
		}
		else
		{
			this.UpdateFilterComponent();
		}
		this.RefreshFilterList();
		this.SetClickStateUnCheck();
		this.RefreshPhantomClickState();
		this.RefreshSkinButton();
		this.RefreshPhantomHead();
	}

	// Token: 0x06012721 RID: 75553 RVA: 0x00513714 File Offset: 0x00511914
	private void RefreshFilterList()
	{
		if (ModelBase<PhantomBattleModel>.Instance.CurrentSelectedFetter != null)
		{
			ModelBase<PhantomBattleModel>.Instance.CurrentSelectedFetter = null;
		}
	}

	// Token: 0x06012722 RID: 75554 RVA: 0x00513748 File Offset: 0x00511948
	private void UpdateFilterComponent()
	{
		MultiSelectDropDown<int, int> multiSelectDropDown = this.MultiSelectDropDown;
		IReadOnlySet<int> readOnlySet = (multiSelectDropDown != null) ? multiSelectDropDown.GetSelectedIndices() : null;
		IPhantomItemData[] source;
		if (readOnlySet == null || readOnlySet.Contains(0) || readOnlySet.Count == 0)
		{
			source = ModelBase<PhantomBattleModel>.Instance.GetVisionSortUseDataList(0, this.CurrentCost);
		}
		else
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int index in readOnlySet)
			{
				hashSet.Add(this.FetterSuitFilterArray[index]);
			}
			source = ModelBase<PhantomBattleModel>.Instance.GetVisionSortUseDataListByMultiGroup(hashSet, this.CurrentCost);
		}
		this.FilterEntrance.UpdateDataWithConfig(this.UseWayId, EFilterSortConfigId.VisionEquipment, source.ToList<IPhantomItemData>(), this.RoleId.ToString(), new object[]
		{
			this.RoleId
		});
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(this.UseWayId);
		this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
		this.SortEntrance.UpdateDataWithConfig(this.UseWayId, EFilterSortConfigId.VisionEquipment, source.ToList<IPhantomItemData>(), this.RoleId.ToString(), new object[]
		{
			this.RoleId
		});
		int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(this.UseWayId);
		this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
	}

	// Token: 0x06012723 RID: 75555 RVA: 0x005138A4 File Offset: 0x00511AA4
	protected override void OnAfterShow()
	{
		foreach (VisionCommonDragItem visionCommonDragItem in this.VisionDragItem)
		{
			visionCommonDragItem.SetScrollViewItem(base.GetLoopScrollViewComponent(6).RootUIComp.Get());
		}
		if (!this.CameraState)
		{
			this.CameraState = true;
			PhantomBattleData currentSelectPhantomData = this.CurrentSelectPhantomData;
			this.RefreshMesh((currentSelectPhantomData != null) ? currentSelectPhantomData.GetUniqueId() : 0, false);
		}
	}

	// Token: 0x06012724 RID: 75556 RVA: 0x00513930 File Offset: 0x00511B30
	protected override void OnAfterHide()
	{
		this.ResetVisionPosition(true);
		Singleton<UiLayer>.Instance.SetShowMaskLayer("playBackToStartPositionAnimation", false);
		Singleton<UiLayer>.Instance.SetShowMaskLayer("OnEquipVision", false);
	}

	// Token: 0x06012725 RID: 75557 RVA: 0x0051395C File Offset: 0x00511B5C
	private void RefreshMesh(int uniqueId, bool needGoldEffect = false)
	{
		if (!this.CameraState)
		{
			return;
		}
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(uniqueId);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		if (this.CurrentMeshId == phantomItemDataByUniqueId.GetUniqueId())
		{
			return;
		}
		this.CheckAndCreateVisionHandle();
		ControllerBase<PhantomBattleController>.Instance.SetMeshShow(phantomItemDataByUniqueId.GetConfigId(true), delegate
		{
			this.PlayMeshEffect(needGoldEffect);
		}, this.VisionSkeletalHandle, true);
		this.CurrentMeshId = uniqueId;
	}

	// Token: 0x06012726 RID: 75558 RVA: 0x005139D8 File Offset: 0x00511BD8
	private void PlayMeshEffect(bool needGoldEffect = false)
	{
		if (this.VisionSkeletalHandle == null)
		{
			return;
		}
		UiModelBase model = this.VisionSkeletalHandle.Model;
		string effectId;
		string materialId;
		if (needGoldEffect)
		{
			effectId = "VisionChangeEffect";
			materialId = "VisionChangeController";
		}
		else
		{
			effectId = "VisionLevelUpEffect";
			materialId = "VisionStepupController";
		}
		Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(model, effectId);
		Singleton<UiModelUtil>.Instance.SetRenderingMaterial(model, materialId);
	}

	// Token: 0x06012727 RID: 75559 RVA: 0x00513A34 File Offset: 0x00511C34
	[NullableContext(2)]
	private void RefreshView(PhantomBattleData data)
	{
		this.RefreshPhantomHead();
		this.RefreshCostText();
		this.RefreshSkinButton();
		this.ScrollToUniqueItem((data != null) ? data.GetUniqueId() : 0, true);
	}

	// Token: 0x06012728 RID: 75560 RVA: 0x00513A5C File Offset: 0x00511C5C
	private void RefreshSwitchButtonText()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		EEquipType eequipType = (this.CurrentSelectPhantomData != null) ? ControllerBase<PhantomBattleController>.Instance.GetEquipState(roleInstanceById.GetRoleId(), (int)this.CurrentSelectIndex, this.CurrentSelectPhantomData.GetUniqueId()) : EEquipType.Equip;
		string underLeftButtonText = "";
		switch (eequipType)
		{
		case EEquipType.UnEquip:
			underLeftButtonText = "PhantomTakeOff";
			break;
		case EEquipType.Equip:
			underLeftButtonText = "PhantomPutOn";
			break;
		case EEquipType.Replace:
			underLeftButtonText = "PhantomReplace";
			break;
		}
		this.VisionDetailComponent.SetUnderLeftButtonText(underLeftButtonText);
	}

	// Token: 0x06012729 RID: 75561 RVA: 0x00513AE4 File Offset: 0x00511CE4
	private void RefreshPhantomNotReload()
	{
		this.LoopScrollView.DeselectCurrentGridProxy(false);
		if (this.CurrentShowingDataList.Count > 0)
		{
			base.GetLoopScrollViewComponent(6).RootUIComp.Get().SetUIActive(true);
			this.LoopScrollView.RefreshAllGridProxies();
			return;
		}
		base.GetLoopScrollViewComponent(6).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0601272A RID: 75562 RVA: 0x00513B4B File Offset: 0x00511D4B
	private void OnItemFuncValueChange(int _)
	{
		this.LoopScrollView.RefreshAllGridProxies();
	}

	// Token: 0x0601272B RID: 75563 RVA: 0x00513B58 File Offset: 0x00511D58
	private void RefreshPhantom(int uniqueId = 0)
	{
		this.LoopScrollView.DeselectCurrentGridProxy(false);
		if (this.CurrentShowingDataList.Count > 0)
		{
			base.GetLoopScrollViewComponent(6).RootUIComp.Get().SetUIActive(true);
			this.LoopScrollView.ReloadData(this.CurrentShowingDataList, false);
		}
		else
		{
			base.GetLoopScrollViewComponent(6).RootUIComp.Get().SetUIActive(false);
		}
		this.RefreshEmptyItem();
	}

	// Token: 0x0601272C RID: 75564 RVA: 0x00513BD0 File Offset: 0x00511DD0
	private void RefreshPhantomHead()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		List<PhantomDataBase> currentViewShowPhantomList = ModelBase<PhantomBattleModel>.Instance.GetCurrentViewShowPhantomList(roleInstanceById);
		int count = this.RoleVisionItem.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomDataBase data = (currentViewShowPhantomList.Count > i) ? currentViewShowPhantomList[i] : null;
			this.RoleVisionItem[i].UpdateItem(data, null);
			this.VisionDragItem[i].Refresh(data, false);
		}
		this.RefreshPhantomHeadSelectState();
	}

	// Token: 0x0601272D RID: 75565 RVA: 0x00513C58 File Offset: 0x00511E58
	private void RefreshPhantomHeadSelectState()
	{
		int count = this.RoleVisionItem.Count;
		for (int i = 0; i < count; i++)
		{
			if (i == (int)this.CurrentSelectIndex)
			{
				this.RoleVisionItem[i].SetSelected();
			}
			else
			{
				this.RoleVisionItem[i].SetUnSelected();
			}
		}
	}

	// Token: 0x0601272E RID: 75566 RVA: 0x00513CAC File Offset: 0x00511EAC
	protected void OnBeginDrag(int index)
	{
		int count = this.VisionDragItem.Count;
		for (int i = 0; i < count; i++)
		{
			this.VisionDragItem[i].StartDragState();
		}
		for (int j = 0; j < count; j++)
		{
			if (ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.VisionDragItem[j].GetCurrentIndex()))
			{
				this.VisionDragItem[j].SetDragItemHierarchyMax();
			}
		}
		this.VisionDragItem[index].SetItemToPointerPosition();
		this.CurrentDragIndex = index;
		Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_drag");
	}

	// Token: 0x0601272F RID: 75567 RVA: 0x00513D44 File Offset: 0x00511F44
	protected void OnPointerDownCallBack(int index)
	{
		base.GetItem(15).SetRaycastTarget(true);
		int count = this.VisionDragItem.Count;
		for (int i = 0; i < count; i++)
		{
			this.VisionDragItem[i].StartClickCheckTimer();
		}
	}

	// Token: 0x06012730 RID: 75568 RVA: 0x00513D88 File Offset: 0x00511F88
	private void OnFailAnimationTick(float _)
	{
		this.CurrentRunningTime += Singleton<Time>.Instance.DeltaTime;
		float num = this.CurrentRunningTime / 300f;
		if (num >= 1f)
		{
			num = 1f;
		}
		this.VisionDragItem[this.CurrentDragIndex].TickDoCeaseAnimation(num);
		if (num >= 1f)
		{
			this.DoFailCeaseAnimation(this.CurrentDragIndex);
			this.ClearFailAnimationTick();
		}
	}

	// Token: 0x06012731 RID: 75569 RVA: 0x00513DFC File Offset: 0x00511FFC
	private UniTask DoFailCeaseAnimation(int index)
	{
		VisionEquipmentView.<DoFailCeaseAnimation>d__151 <DoFailCeaseAnimation>d__;
		<DoFailCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DoFailCeaseAnimation>d__.<>4__this = this;
		<DoFailCeaseAnimation>d__.index = index;
		<DoFailCeaseAnimation>d__.<>1__state = -1;
		<DoFailCeaseAnimation>d__.<>t__builder.Start<VisionEquipmentView.<DoFailCeaseAnimation>d__151>(ref <DoFailCeaseAnimation>d__);
		return <DoFailCeaseAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06012732 RID: 75570 RVA: 0x00513E48 File Offset: 0x00512048
	private UniTask PlayCeaseAnimation(int index)
	{
		VisionEquipmentView.<PlayCeaseAnimation>d__152 <PlayCeaseAnimation>d__;
		<PlayCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCeaseAnimation>d__.<>4__this = this;
		<PlayCeaseAnimation>d__.index = index;
		<PlayCeaseAnimation>d__.<>1__state = -1;
		<PlayCeaseAnimation>d__.<>t__builder.Start<VisionEquipmentView.<PlayCeaseAnimation>d__152>(ref <PlayCeaseAnimation>d__);
		return <PlayCeaseAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06012733 RID: 75571 RVA: 0x00513E93 File Offset: 0x00512093
	private void ClearFailAnimationTick()
	{
		if (this.FailAnimationTick != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.FailAnimationTick);
			this.FailAnimationTick = -1;
		}
	}

	// Token: 0x06012734 RID: 75572 RVA: 0x00513EB8 File Offset: 0x005120B8
	private UniTask ResetVisionPosition(bool playBackToStartPositionAnimation = true)
	{
		VisionEquipmentView.<ResetVisionPosition>d__154 <ResetVisionPosition>d__;
		<ResetVisionPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ResetVisionPosition>d__.<>4__this = this;
		<ResetVisionPosition>d__.playBackToStartPositionAnimation = playBackToStartPositionAnimation;
		<ResetVisionPosition>d__.<>1__state = -1;
		<ResetVisionPosition>d__.<>t__builder.Start<VisionEquipmentView.<ResetVisionPosition>d__154>(ref <ResetVisionPosition>d__);
		return <ResetVisionPosition>d__.<>t__builder.Task;
	}

	// Token: 0x06012735 RID: 75573 RVA: 0x00513F03 File Offset: 0x00512103
	private void SetIndexVisionMoveState(int index, bool state)
	{
		if (index >= 0)
		{
			this.VisionDragItem[index].SetMovingState(state);
		}
	}

	// Token: 0x06012736 RID: 75574 RVA: 0x00513F1B File Offset: 0x0051211B
	private void SetIndexVisionAnimateState(int index, bool state)
	{
		if (index >= 0)
		{
			this.RoleVisionItem[index].SetAnimationState(state);
		}
	}

	// Token: 0x06012737 RID: 75575 RVA: 0x00513F33 File Offset: 0x00512133
	protected void OnEquipError()
	{
		this.ResetVisionPosition(true);
	}

	// Token: 0x06012738 RID: 75576 RVA: 0x00513F40 File Offset: 0x00512140
	private void RefreshEmptyItem()
	{
		int count = this.CurrentShowingDataList.Count;
		base.GetItem(35).SetUIActive(count == 0);
	}

	// Token: 0x06012739 RID: 75577 RVA: 0x00513F6A File Offset: 0x0051216A
	protected void OnPhantomEquip()
	{
		this.RefreshVisionDetailCompare();
	}

	// Token: 0x0601273A RID: 75578 RVA: 0x00513F72 File Offset: 0x00512172
	protected void OnVisionFilterMonster()
	{
		this.RefreshFilterList();
	}

	// Token: 0x0601273B RID: 75579 RVA: 0x00513F7C File Offset: 0x0051217C
	private void OnMoveToScrollViewDragEndCallBack(int index, PhantomBattleData data)
	{
		this.ClearFailAnimationTick();
		this.CurrentRunningTime = 0f;
		this.CurrentDragIndex = 999;
		this.VisionDragItem[index].SetActive(false);
		this.VisionDragItem[index].ResetPosition();
		this.RoleVisionItem[index].ResetPosition();
		base.GetItem(15).SetRaycastTarget(false);
		RoleInstance roleInstance = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		Action doFunction = delegate()
		{
			ControllerBase<PhantomBattleController>.Instance.SendPhantomPutOnRequest(data.GetUniqueId(), roleInstance.GetRoleId(), index, -1, false);
		};
		this.DoEquip(data, index, doFunction);
	}

	// Token: 0x0601273C RID: 75580 RVA: 0x00514040 File Offset: 0x00512240
	protected void OnDragEndCallBack(VisionCommonDragItem self, List<VisionCommonDragItem> targets, bool _)
	{
		if (targets.Count < 1)
		{
			this.ResetVisionPosition(true);
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_drop");
			return;
		}
		int targetIndex = VisionCommonDragItem.GetOverlapIndex(self, targets);
		if (targetIndex == -1)
		{
			this.ResetVisionPosition(true);
			return;
		}
		if (self.GetCurrentIndex() == -1)
		{
			this.ResetVisionPosition(true);
		}
		int selfIndex = self.GetCurrentIndex();
		RoleInstance currentRoleInstance = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		bool fromDrag = selfIndex != -1;
		Action doFunction = delegate()
		{
			this.SetIndexVisionMoveState(selfIndex, true);
			this.SetIndexVisionMoveState(targetIndex, true);
			this.SetIndexVisionAnimateState(selfIndex, true);
			this.SetIndexVisionAnimateState(targetIndex, true);
			ControllerBase<PhantomBattleController>.Instance.SendPhantomPutOnRequest((self.GetCurrentData() as PhantomBattleData).GetUniqueId(), currentRoleInstance.GetRoleId(), targetIndex, selfIndex, fromDrag);
		};
		this.DoEquip(self.GetCurrentData() as PhantomBattleData, targetIndex, doFunction);
	}

	// Token: 0x0601273D RID: 75581 RVA: 0x00514120 File Offset: 0x00512320
	private void OnEquipEquipment(int selfIndex, int targetIndex, bool fromDrag)
	{
		this.CurrentDragIndex = 999;
		if (selfIndex >= 0)
		{
			this.VisionDragItem[selfIndex].SetActive(true);
			this.RoleVisionItem[selfIndex].SetAniLightState(false);
		}
		if (fromDrag && selfIndex != -1)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("OnEquipVision", true);
			this.ClearAnimationTick();
			this.CurrentRunningTime = 0f;
			Vector2D animationTargetPos = this.VisionDragItem[targetIndex].GetAnimationTargetPos();
			this.VisionDragItem[selfIndex].SetDragComponentToTargetPositionParam(animationTargetPos);
			Vector2D animationTargetPos2 = this.VisionDragItem[selfIndex].GetAnimationTargetPos();
			this.VisionDragItem[targetIndex].SetDragComponentToTargetPositionParam(animationTargetPos2);
			this.CurrentAnimationSourceIndex = selfIndex;
			this.CurrentAnimationTargetIndex = targetIndex;
			this.SetIndexVisionMoveState(this.CurrentAnimationSourceIndex, true);
			this.SetIndexVisionMoveState(this.CurrentAnimationTargetIndex, true);
			this.SetIndexVisionAnimateState(this.CurrentAnimationSourceIndex, true);
			this.SetIndexVisionAnimateState(this.CurrentAnimationTargetIndex, true);
			this.MoveAnimationTick = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "RoleVisionAnimation", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			return;
		}
		this.SetIndexVisionMoveState(selfIndex, false);
		this.SetIndexVisionMoveState(targetIndex, false);
		this.SetIndexVisionAnimateState(selfIndex, false);
		this.SetIndexVisionAnimateState(targetIndex, false);
		this.RefreshOnEquip();
		this.SetCurrentSelectIndex(targetIndex);
		this.RefreshVisionBySelectIndex(true, false, false);
		if (this.RoleVisionItem[targetIndex].GetCurrentData() != null)
		{
			this.PlayTargetIndexEquipmentCeaseAnimation(targetIndex);
		}
		if (selfIndex >= 0)
		{
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_equip_off");
			return;
		}
		Singleton<AudioSystem>.Instance.PostEvent("ui_vision_equip_on");
	}

	// Token: 0x0601273E RID: 75582 RVA: 0x005142B4 File Offset: 0x005124B4
	private UniTask PlayTargetIndexEquipmentCeaseAnimation(int targetIndex)
	{
		VisionEquipmentView.<PlayTargetIndexEquipmentCeaseAnimation>d__164 <PlayTargetIndexEquipmentCeaseAnimation>d__;
		<PlayTargetIndexEquipmentCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayTargetIndexEquipmentCeaseAnimation>d__.<>4__this = this;
		<PlayTargetIndexEquipmentCeaseAnimation>d__.targetIndex = targetIndex;
		<PlayTargetIndexEquipmentCeaseAnimation>d__.<>1__state = -1;
		<PlayTargetIndexEquipmentCeaseAnimation>d__.<>t__builder.Start<VisionEquipmentView.<PlayTargetIndexEquipmentCeaseAnimation>d__164>(ref <PlayTargetIndexEquipmentCeaseAnimation>d__);
		return <PlayTargetIndexEquipmentCeaseAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x0601273F RID: 75583 RVA: 0x00514300 File Offset: 0x00512500
	private void OnTick(float _)
	{
		this.CurrentRunningTime += Singleton<Time>.Instance.DeltaTime;
		float num = this.CurrentRunningTime / 300f;
		if (num >= 1f)
		{
			num = 1f;
		}
		this.VisionDragItem[this.CurrentAnimationSourceIndex].TickDoCeaseAnimation(num);
		this.VisionDragItem[this.CurrentAnimationTargetIndex].TickDoCeaseAnimation(num);
		if (num >= 1f)
		{
			this.DoCeaseAnimationAndResetView();
			this.ClearAnimationTick();
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_equip_on");
		}
	}

	// Token: 0x06012740 RID: 75584 RVA: 0x00514398 File Offset: 0x00512598
	private UniTask DoCeaseAnimationAndResetView()
	{
		VisionEquipmentView.<DoCeaseAnimationAndResetView>d__166 <DoCeaseAnimationAndResetView>d__;
		<DoCeaseAnimationAndResetView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DoCeaseAnimationAndResetView>d__.<>4__this = this;
		<DoCeaseAnimationAndResetView>d__.<>1__state = -1;
		<DoCeaseAnimationAndResetView>d__.<>t__builder.Start<VisionEquipmentView.<DoCeaseAnimationAndResetView>d__166>(ref <DoCeaseAnimationAndResetView>d__);
		return <DoCeaseAnimationAndResetView>d__.<>t__builder.Task;
	}

	// Token: 0x06012741 RID: 75585 RVA: 0x005143DB File Offset: 0x005125DB
	private void RefreshOnEquip()
	{
		this.RefreshPhantomNotReload();
		this.RefreshPhantomHead();
		this.RefreshVisionDetailCompare();
		this.RefreshCostText();
		this.RefreshSwitchButtonText();
		this.ResetVisionPosition(true);
		this.RefreshSelectAllToggleState();
	}

	// Token: 0x06012742 RID: 75586 RVA: 0x00514409 File Offset: 0x00512609
	private void ClearAnimationTick()
	{
		if (this.MoveAnimationTick != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.MoveAnimationTick);
			this.MoveAnimationTick = -1;
		}
	}

	// Token: 0x06012743 RID: 75587 RVA: 0x0051442C File Offset: 0x0051262C
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012744 RID: 75588 RVA: 0x00514435 File Offset: 0x00512635
	private int GetCostMax()
	{
		return ModelBase<PhantomBattleModel>.Instance.GetMaxCost();
	}

	// Token: 0x06012745 RID: 75589 RVA: 0x00514441 File Offset: 0x00512641
	private void CheckAndCreateVisionHandle()
	{
		if (!Singleton<UiSceneManager>.Instance.HasVisionSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitVisionSkeletalHandle();
		}
		this.VisionSkeletalHandle = Singleton<UiSceneManager>.Instance.GetVisionSkeletalHandle();
	}

	// Token: 0x06012746 RID: 75590 RVA: 0x00514469 File Offset: 0x00512669
	private void DestroyVisionHandle()
	{
		Singleton<UiSceneManager>.Instance.DestroyVisionSkeletalHandle();
		this.VisionSkeletalHandle = null;
		this.CurrentMeshId = 0;
	}

	// Token: 0x06012747 RID: 75591 RVA: 0x00514483 File Offset: 0x00512683
	protected override void OnBeforeHide()
	{
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		if (instance != null)
		{
			instance.ReduceNeedCameraFocusMethodDisableViewCount();
		}
		this.VisionEquipmentRecommendItem.Hide(null);
		UUIExtendToggle extendToggle = base.GetExtendToggle(34);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.RefreshUiBlur(false);
	}

	// Token: 0x06012748 RID: 75592 RVA: 0x005144C0 File Offset: 0x005126C0
	protected override void OnBeforePlayCloseSequence()
	{
		this.DestroyVisionHandle();
		UUIExtendToggle extendToggle = base.GetExtendToggle(34);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012749 RID: 75593 RVA: 0x005144E0 File Offset: 0x005126E0
	protected override void OnBeforeDestroy()
	{
		this.DestroyVisionHandle();
		this.VisionSkeletalHandle = null;
		this.ClearScrollerMoveTick();
		this.TryUnbindConfirmButtonRedDot();
		this.LoopScrollView.ClearGridProxies();
		this.ClearPhantomClickTick();
		this.ClearAnimationTick();
		this.ClearFailAnimationTick();
		this.StaticTabComponent.Destroy(null);
		MultiSelectDropDown<int, int> multiSelectDropDown = this.MultiSelectDropDown;
		if (multiSelectDropDown != null)
		{
			multiSelectDropDown.Destroy(null);
		}
		this.RefreshUiBlur(false);
	}

	// Token: 0x0601274A RID: 75594 RVA: 0x00514548 File Offset: 0x00512748
	private bool NeedClearSelectMainPhantom()
	{
		Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> selectRuleDataMap = this.FilterEntrance.GetSelectRuleDataMap();
		VisionRecommendModel instance = ModelBase<VisionRecommendModel>.Instance;
		int? num;
		if (instance == null)
		{
			num = null;
		}
		else
		{
			VisionMainSelectPhantomData currentMainPhantom = instance.CurrentMainPhantom;
			num = ((currentMainPhantom != null) ? new int?(currentMainPhantom.MonsterId) : null);
		}
		int? num2 = num;
		bool result = false;
		if (num2 != null)
		{
			if (selectRuleDataMap == null || selectRuleDataMap.Count != 1)
			{
				result = true;
			}
			else
			{
				Dictionary<int, string> dictionary = selectRuleDataMap.Values.ToArray<Dictionary<int, string>>()[0];
				if (dictionary == null || dictionary.Count > 1 || !dictionary.ContainsKey(num2.Value))
				{
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x0601274B RID: 75595 RVA: 0x005145E0 File Offset: 0x005127E0
	private void OnFilterRefresh(List<IPhantomItemData> list, bool ifOutSideChange, EFilterSortType type)
	{
		if (type == EFilterSortType.Filter && !ifOutSideChange && this.NeedClearSelectMainPhantom())
		{
			this.VisionEquipmentRecommendItem.ClearSelectMainPhantom(false);
			return;
		}
		List<PhantomBattleData> list2 = new List<PhantomBattleData>();
		foreach (IPhantomItemData phantomItemData in list)
		{
			list2.Add(ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(phantomItemData.Id));
		}
		this.CurrentShowingDataList = list2;
		this.RefreshPhantom(0);
		bool uiactive = list != null && list.Count > 0;
		base.GetLoopScrollViewComponent(6).RootUIComp.Get().SetUIActive(uiactive);
		this.RefreshDefaultVisionOnFilter(list.ToArray(), ifOutSideChange, type);
	}

	// Token: 0x0601274C RID: 75596 RVA: 0x005146AC File Offset: 0x005128AC
	private void RefreshDefaultVisionOnFilter(IPhantomItemData[] dataList, bool ifOutSideChange, EFilterSortType type)
	{
		if (dataList == null || dataList.Length == 0)
		{
			return;
		}
		int num = 0;
		if (type == EFilterSortType.Sort && !ifOutSideChange)
		{
			num = dataList[0].Id;
		}
		else
		{
			int num2 = dataList.Length;
			for (int i = 0; i < num2; i++)
			{
				int id = dataList[i].Id;
				PhantomBattleData currentSelectPhantomData = this.CurrentSelectPhantomData;
				int? num3 = (currentSelectPhantomData != null) ? new int?(currentSelectPhantomData.GetUniqueId()) : null;
				if (id == num3.GetValueOrDefault() & num3 != null)
				{
					PhantomBattleData currentSelectPhantomData2 = this.CurrentSelectPhantomData;
					num = ((currentSelectPhantomData2 != null) ? currentSelectPhantomData2.GetUniqueId() : 0);
					break;
				}
			}
			if (num == 0)
			{
				num = dataList[0].Id;
			}
		}
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(num);
		this.SetCurrentSelectPhantomData(phantomBattleData);
		this.ScrollToUniqueItem(num, true);
		this.RefreshCurrentDetailComponent(this.CurrentSelectPhantomData, false);
		this.RefreshVisionDetailCompare();
		this.RefreshMesh(num, false);
		this.RefreshSkinButton();
		this.RefreshPhantomClickState();
	}

	// Token: 0x0601274D RID: 75597 RVA: 0x0051478C File Offset: 0x0051298C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		List<PhantomBattleData> currentShowingDataList = this.CurrentShowingDataList;
		if (currentShowingDataList.Count == 0)
		{
			return null;
		}
		if (configParams.Length != 2)
		{
			Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TL, "声骸聚焦引导extraParam配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (configParams[0] == "txt")
		{
			VisionDetailComponent visionDetailComponent = this.VisionDetailComponent;
			UUIItem uuiitem = (visionDetailComponent != null) ? visionDetailComponent.GetTxtItemByIndex(int.Parse(configParams[1])) : null;
			if (uuiitem != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
		}
		if (!(configParams[0] == "item"))
		{
			return null;
		}
		int num = int.Parse(configParams[1]);
		if (num == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "声骸聚焦引导extraParam字段配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		int gridIndex = -1;
		for (int i = 0; i < currentShowingDataList.Count; i++)
		{
			if (currentShowingDataList[i].GetMonsterId(true) == num)
			{
				gridIndex = i;
				break;
			}
		}
		this.LoopScrollView.ScrollToGridIndex(gridIndex, true);
		UUIItem grid = this.LoopScrollView.GetGrid(gridIndex);
		return new UUIItem[]
		{
			grid,
			grid
		};
	}

	// Token: 0x0601274E RID: 75598 RVA: 0x005148B4 File Offset: 0x00512AB4
	private void RefreshSkinButton()
	{
		PhantomBattleData currentSelectPhantomData = this.CurrentSelectPhantomData;
		int? num = (currentSelectPhantomData != null) ? new int?(currentSelectPhantomData.GetMonsterId(false)) : null;
		if (num == null)
		{
			base.GetButton(27).RootUIComp.Get().SetUIActive(false);
			return;
		}
		int[] monsterSkinListByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(num.Value);
		if (monsterSkinListByMonsterId == null)
		{
			base.GetButton(27).RootUIComp.Get().SetUIActive(false);
			return;
		}
		bool uiactive = monsterSkinListByMonsterId.Length > 1;
		base.GetButton(27).RootUIComp.Get().SetUIActive(uiactive);
		bool monsterSkinListHasNew = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListHasNew(this.CurrentSelectPhantomData.GetConfigId(false));
		base.GetItem(31).SetUIActive(monsterSkinListHasNew);
	}

	// Token: 0x04008FCE RID: 36814
	private const int ANIMATIONTIME = 300;

	// Token: 0x04008FCF RID: 36815
	private const int INVALIDINDEX = 999;

	// Token: 0x04008FD0 RID: 36816
	private readonly EFilterSortGroupId UseWayId = EFilterSortGroupId.PhantomEquip;

	// Token: 0x04008FD1 RID: 36817
	[Nullable(2)]
	private CustomPromise<bool> FailAnimationPromise;

	// Token: 0x04008FD2 RID: 36818
	private int MoveAnimationTick = -1;

	// Token: 0x04008FD3 RID: 36819
	private int PhantomClickTick = -1;

	// Token: 0x04008FD4 RID: 36820
	private int FailAnimationTick = -1;

	// Token: 0x04008FD5 RID: 36821
	private int PhantomScrollerItemPositionTick = -1;

	// Token: 0x04008FD6 RID: 36822
	private int RoleId;

	// Token: 0x04008FD7 RID: 36823
	private int CurrentAnimationSourceIndex;

	// Token: 0x04008FD8 RID: 36824
	private int CurrentAnimationTargetIndex;

	// Token: 0x04008FD9 RID: 36825
	private float CurrentRunningTime;

	// Token: 0x04008FDA RID: 36826
	private ERoleViewSource Source;

	// Token: 0x04008FDB RID: 36827
	private readonly List<RoleVisionCommonItem> RoleVisionItem = new List<RoleVisionCommonItem>();

	// Token: 0x04008FDC RID: 36828
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04008FDD RID: 36829
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<VisionMediumItemGrid, PhantomBattleData> LoopScrollView;

	// Token: 0x04008FDE RID: 36830
	private List<PhantomBattleData> CurrentShowingDataList = new List<PhantomBattleData>();

	// Token: 0x04008FDF RID: 36831
	[Nullable(2)]
	private PhantomBattleData CurrentSelectPhantomData;

	// Token: 0x04008FE0 RID: 36832
	private EPhantomItemIndex CurrentSelectIndex;

	// Token: 0x04008FE1 RID: 36833
	[Nullable(2)]
	private VisionDetailComponent VisionDetailComponent;

	// Token: 0x04008FE2 RID: 36834
	[Nullable(2)]
	private VisionDetailComponent VisionDetailComponentCompare;

	// Token: 0x04008FE3 RID: 36835
	private int CurrentMeshId;

	// Token: 0x04008FE4 RID: 36836
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterEntrance<IPhantomItemData> FilterEntrance;

	// Token: 0x04008FE5 RID: 36837
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SortEntrance<IPhantomItemData> SortEntrance;

	// Token: 0x04008FE6 RID: 36838
	[Nullable(2)]
	private LevelSequencePlayer RootLevelSequence;

	// Token: 0x04008FE7 RID: 36839
	private int CurrentDragIndex = 999;

	// Token: 0x04008FE8 RID: 36840
	private float PressTime;

	// Token: 0x04008FE9 RID: 36841
	private float FillPressTime;

	// Token: 0x04008FEA RID: 36842
	private bool CheckState;

	// Token: 0x04008FEB RID: 36843
	private bool AfterLongPressState;

	// Token: 0x04008FEC RID: 36844
	private float OnPressPositionX;

	// Token: 0x04008FED RID: 36845
	private float OnPressPositionY;

	// Token: 0x04008FEE RID: 36846
	private int ScrollerTickId = -1;

	// Token: 0x04008FEF RID: 36847
	[Nullable(2)]
	private VisionMediumItemGrid CurrentPressItem;

	// Token: 0x04008FF0 RID: 36848
	[Nullable(2)]
	protected VisionEquipmentDragItem VisionEquipmentDragItem;

	// Token: 0x04008FF1 RID: 36849
	private readonly List<VisionCommonDragItem> VisionDragItem = new List<VisionCommonDragItem>();

	// Token: 0x04008FF2 RID: 36850
	[Nullable(2)]
	private VisionCommonDragItem ScrollVisionDragItem;

	// Token: 0x04008FF3 RID: 36851
	private float LongPressTime;

	// Token: 0x04008FF4 RID: 36852
	private float BeforeLongPressTime;

	// Token: 0x04008FF5 RID: 36853
	private float LongPressItemAlpha;

	// Token: 0x04008FF6 RID: 36854
	private float ScrollerMoveDistance;

	// Token: 0x04008FF7 RID: 36855
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private StaticTabComponent<CostTabItem> StaticTabComponent;

	// Token: 0x04008FF8 RID: 36856
	private int CurrentCost;

	// Token: 0x04008FF9 RID: 36857
	private readonly List<int> CostArray = new List<int>();

	// Token: 0x04008FFA RID: 36858
	[Nullable(2)]
	private MultiSelectDropDown<int, int> MultiSelectDropDown;

	// Token: 0x04008FFB RID: 36859
	private readonly List<int> FetterSuitFilterArray = new List<int>();

	// Token: 0x04008FFC RID: 36860
	private readonly Dictionary<int, int> FetterSortIdMap = new Dictionary<int, int>();

	// Token: 0x04008FFD RID: 36861
	private bool DropDownDirty;

	// Token: 0x04008FFE RID: 36862
	private bool InitState;

	// Token: 0x04008FFF RID: 36863
	private bool CurrentCompareState;

	// Token: 0x04009000 RID: 36864
	private bool CurrentAnimationState;

	// Token: 0x04009001 RID: 36865
	private int CurrentConfirmButtonRedDotUniqueId;

	// Token: 0x04009002 RID: 36866
	private bool CameraState = true;

	// Token: 0x04009003 RID: 36867
	private bool IfPlayingCostBlinkAnimate;

	// Token: 0x04009004 RID: 36868
	private int PreSelectMeshId;

	// Token: 0x04009005 RID: 36869
	[Nullable(2)]
	private VisionEquipmentRecommendItem VisionEquipmentRecommendItem;

	// Token: 0x04009006 RID: 36870
	private int PresetSelectIndexInternal;

	// Token: 0x04009007 RID: 36871
	[Nullable(2)]
	private TsUiBlur UiBlur;

	// Token: 0x04009008 RID: 36872
	[Nullable(2)]
	private VisionEquipmentRecommendFetterGroupView VisionEquipmentRecommendFetterGroupView;

	// Token: 0x04009009 RID: 36873
	[Nullable(2)]
	private SkeletalObserverHandle VisionSkeletalHandle;

	// Token: 0x02008825 RID: 34853
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DFBA RID: 188346
		MainVisionItem,
		// Token: 0x0402DFBB RID: 188347
		SubVisionItem1,
		// Token: 0x0402DFBC RID: 188348
		SubVisionItem2,
		// Token: 0x0402DFBD RID: 188349
		SubVisionItem3,
		// Token: 0x0402DFBE RID: 188350
		SubVisionItem4,
		// Token: 0x0402DFBF RID: 188351
		CostTextBack,
		// Token: 0x0402DFC0 RID: 188352
		Scroller,
		// Token: 0x0402DFC1 RID: 188353
		CaptionItem,
		// Token: 0x0402DFC2 RID: 188354
		LoopItem,
		// Token: 0x0402DFC3 RID: 188355
		FilterItem,
		// Token: 0x0402DFC4 RID: 188356
		AttributePanelOne,
		// Token: 0x0402DFC5 RID: 188357
		AttributePanelTwo,
		// Token: 0x0402DFC6 RID: 188358
		Filter,
		// Token: 0x0402DFC7 RID: 188359
		Sort,
		// Token: 0x0402DFC8 RID: 188360
		BgBlack,
		// Token: 0x0402DFC9 RID: 188361
		DragPanel,
		// Token: 0x0402DFCA RID: 188362
		DragItem,
		// Token: 0x0402DFCB RID: 188363
		HeadListLayout,
		// Token: 0x0402DFCC RID: 188364
		LongPressItem,
		// Token: 0x0402DFCD RID: 188365
		LongPressBar,
		// Token: 0x0402DFCE RID: 188366
		SwitchCostTab,
		// Token: 0x0402DFCF RID: 188367
		SimplyToggle,
		// Token: 0x0402DFD0 RID: 188368
		SuitFilter,
		// Token: 0x0402DFD1 RID: 188369
		TabItem1,
		// Token: 0x0402DFD2 RID: 188370
		TabItem2,
		// Token: 0x0402DFD3 RID: 188371
		TabItem3,
		// Token: 0x0402DFD4 RID: 188372
		TabItem4,
		// Token: 0x0402DFD5 RID: 188373
		MonsterSkinBtn,
		// Token: 0x0402DFD6 RID: 188374
		ButtonRedDot,
		// Token: 0x0402DFD7 RID: 188375
		CompareButton,
		// Token: 0x0402DFD8 RID: 188376
		CostTextFront,
		// Token: 0x0402DFD9 RID: 188377
		MonsterSkinBtnRedDot,
		// Token: 0x0402DFDA RID: 188378
		JumpVisionRecoveryButton,
		// Token: 0x0402DFDB RID: 188379
		RecommendPanel,
		// Token: 0x0402DFDC RID: 188380
		RecommendToggle,
		// Token: 0x0402DFDD RID: 188381
		EmptyItem,
		// Token: 0x0402DFDE RID: 188382
		PnlRoleVisionPrefabInfo,
		// Token: 0x0402DFDF RID: 188383
		PnlCurrentElement
	}
}
