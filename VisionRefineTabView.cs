using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Calabash.New.VisionRefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001828 RID: 6184
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineTabView : UiTabViewBase
{
	// Token: 0x17000E5B RID: 3675
	// (get) Token: 0x0600B021 RID: 45089 RVA: 0x002EEF78 File Offset: 0x002ED178
	// (set) Token: 0x0600B022 RID: 45090 RVA: 0x002EEFE8 File Offset: 0x002ED1E8
	[Nullable(2)]
	private IRefineAttrItemData SelectMainAttribute
	{
		[NullableContext(2)]
		get
		{
			if (this.ExtraParamsExactly != null && this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
			{
				return this.SelectMainAttributeInternalSingle;
			}
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			EVisionRefineCostType? evisionRefineCostType = (choosePanel != null) ? choosePanel.CurrentCostType : null;
			if (evisionRefineCostType == null)
			{
				return null;
			}
			IRefineAttrItemData result;
			if (this.SelectMainAttributeInternalMulti.TryGetValue(evisionRefineCostType.Value, out result))
			{
				return result;
			}
			return null;
		}
		[NullableContext(2)]
		set
		{
			if (this.ExtraParamsExactly != null && this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
			{
				this.SelectMainAttributeInternalSingle = value;
				return;
			}
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			EVisionRefineCostType? evisionRefineCostType = (choosePanel != null) ? choosePanel.CurrentCostType : null;
			if (evisionRefineCostType == null)
			{
				return;
			}
			if (value == null)
			{
				this.SelectMainAttributeInternalMulti.Remove(evisionRefineCostType.Value);
				return;
			}
			this.SelectMainAttributeInternalMulti[evisionRefineCostType.Value] = value;
		}
	}

	// Token: 0x17000E5C RID: 3676
	// (get) Token: 0x0600B023 RID: 45091 RVA: 0x002EF069 File Offset: 0x002ED269
	[Nullable(2)]
	private PhantomItemData SelectedVision
	{
		[NullableContext(2)]
		get
		{
			if (this.CurrentRefineType == EVisionRefineRefineType.Main)
			{
				return null;
			}
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			if (choosePanel == null)
			{
				return null;
			}
			return choosePanel.GetSelection();
		}
	}

	// Token: 0x17000E5D RID: 3677
	// (get) Token: 0x0600B024 RID: 45092 RVA: 0x002EF088 File Offset: 0x002ED288
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<PhantomItemData> SelectedVisionValidList
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			List<PhantomItemData> list = (choosePanel != null) ? choosePanel.CurrentSelectedList : null;
			if (list == null)
			{
				return null;
			}
			return list.FindAll(delegate(PhantomItemData target)
			{
				if (this.SelectMainAttribute == null)
				{
					return true;
				}
				PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(target.GetUniqueId());
				return phantomDataBase != null && this.SelectMainAttribute.PropItemId != phantomDataBase.GetPhantomFirstMainProp().PhantomPropId;
			});
		}
	}

	// Token: 0x17000E5E RID: 3678
	// (get) Token: 0x0600B025 RID: 45093 RVA: 0x002EF0BF File Offset: 0x002ED2BF
	[Nullable(2)]
	private IVisionRefineTabViewParam ExtraParamsExactly
	{
		[NullableContext(2)]
		get
		{
			if (this.ExtraParams == null)
			{
				return null;
			}
			return this.ExtraParams as IVisionRefineTabViewParam;
		}
	}

	// Token: 0x0600B026 RID: 45094 RVA: 0x002EF0D8 File Offset: 0x002ED2D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUILayoutBase))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickTip)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickRefine)),
			new ValueTuple<int, Delegate>(19, new Action(this.OnClickRefineMainDelete))
		};
	}

	// Token: 0x0600B027 RID: 45095 RVA: 0x002EF37C File Offset: 0x002ED57C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineTabView.<OnBeforeStartAsync>d__30 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineTabView.<OnBeforeStartAsync>d__30>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B028 RID: 45096 RVA: 0x002EF3C0 File Offset: 0x002ED5C0
	private UniTask InitMainSlotItemAsync()
	{
		VisionRefineTabView.<InitMainSlotItemAsync>d__31 <InitMainSlotItemAsync>d__;
		<InitMainSlotItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMainSlotItemAsync>d__.<>4__this = this;
		<InitMainSlotItemAsync>d__.<>1__state = -1;
		<InitMainSlotItemAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitMainSlotItemAsync>d__31>(ref <InitMainSlotItemAsync>d__);
		return <InitMainSlotItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B029 RID: 45097 RVA: 0x002EF404 File Offset: 0x002ED604
	private UniTask InitSubSlotItemAsync()
	{
		VisionRefineTabView.<InitSubSlotItemAsync>d__32 <InitSubSlotItemAsync>d__;
		<InitSubSlotItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSubSlotItemAsync>d__.<>4__this = this;
		<InitSubSlotItemAsync>d__.<>1__state = -1;
		<InitSubSlotItemAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitSubSlotItemAsync>d__32>(ref <InitSubSlotItemAsync>d__);
		return <InitSubSlotItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B02A RID: 45098 RVA: 0x002EF448 File Offset: 0x002ED648
	private UniTask InitChoosePanelAsync()
	{
		VisionRefineTabView.<InitChoosePanelAsync>d__33 <InitChoosePanelAsync>d__;
		<InitChoosePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChoosePanelAsync>d__.<>4__this = this;
		<InitChoosePanelAsync>d__.<>1__state = -1;
		<InitChoosePanelAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitChoosePanelAsync>d__33>(ref <InitChoosePanelAsync>d__);
		return <InitChoosePanelAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B02B RID: 45099 RVA: 0x002EF48C File Offset: 0x002ED68C
	private UniTask InitSingleAttributePanelAsync()
	{
		VisionRefineTabView.<InitSingleAttributePanelAsync>d__34 <InitSingleAttributePanelAsync>d__;
		<InitSingleAttributePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSingleAttributePanelAsync>d__.<>4__this = this;
		<InitSingleAttributePanelAsync>d__.<>1__state = -1;
		<InitSingleAttributePanelAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitSingleAttributePanelAsync>d__34>(ref <InitSingleAttributePanelAsync>d__);
		return <InitSingleAttributePanelAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B02C RID: 45100 RVA: 0x002EF4D0 File Offset: 0x002ED6D0
	private UniTask InitMultiAttributePanelAsync()
	{
		VisionRefineTabView.<InitMultiAttributePanelAsync>d__35 <InitMultiAttributePanelAsync>d__;
		<InitMultiAttributePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMultiAttributePanelAsync>d__.<>4__this = this;
		<InitMultiAttributePanelAsync>d__.<>1__state = -1;
		<InitMultiAttributePanelAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitMultiAttributePanelAsync>d__35>(ref <InitMultiAttributePanelAsync>d__);
		return <InitMultiAttributePanelAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B02D RID: 45101 RVA: 0x002EF514 File Offset: 0x002ED714
	private UniTask InitCostItemAsync()
	{
		VisionRefineTabView.<InitCostItemAsync>d__36 <InitCostItemAsync>d__;
		<InitCostItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCostItemAsync>d__.<>4__this = this;
		<InitCostItemAsync>d__.<>1__state = -1;
		<InitCostItemAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitCostItemAsync>d__36>(ref <InitCostItemAsync>d__);
		return <InitCostItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B02E RID: 45102 RVA: 0x002EF558 File Offset: 0x002ED758
	private UniTask InitUpLeftTabAsync()
	{
		VisionRefineTabView.<InitUpLeftTabAsync>d__37 <InitUpLeftTabAsync>d__;
		<InitUpLeftTabAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitUpLeftTabAsync>d__.<>4__this = this;
		<InitUpLeftTabAsync>d__.<>1__state = -1;
		<InitUpLeftTabAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitUpLeftTabAsync>d__37>(ref <InitUpLeftTabAsync>d__);
		return <InitUpLeftTabAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B02F RID: 45103 RVA: 0x002EF59C File Offset: 0x002ED79C
	private UniTask InitSubVerticalAsync()
	{
		VisionRefineTabView.<InitSubVerticalAsync>d__38 <InitSubVerticalAsync>d__;
		<InitSubVerticalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSubVerticalAsync>d__.<>4__this = this;
		<InitSubVerticalAsync>d__.<>1__state = -1;
		<InitSubVerticalAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitSubVerticalAsync>d__38>(ref <InitSubVerticalAsync>d__);
		return <InitSubVerticalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B030 RID: 45104 RVA: 0x002EF5E0 File Offset: 0x002ED7E0
	private UniTask LoadRefineSubUpperVertAsync()
	{
		VisionRefineTabView.<LoadRefineSubUpperVertAsync>d__39 <LoadRefineSubUpperVertAsync>d__;
		<LoadRefineSubUpperVertAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadRefineSubUpperVertAsync>d__.<>4__this = this;
		<LoadRefineSubUpperVertAsync>d__.<>1__state = -1;
		<LoadRefineSubUpperVertAsync>d__.<>t__builder.Start<VisionRefineTabView.<LoadRefineSubUpperVertAsync>d__39>(ref <LoadRefineSubUpperVertAsync>d__);
		return <LoadRefineSubUpperVertAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B031 RID: 45105 RVA: 0x002EF624 File Offset: 0x002ED824
	private UniTask InitRefineMainGridAsync()
	{
		VisionRefineTabView.<InitRefineMainGridAsync>d__40 <InitRefineMainGridAsync>d__;
		<InitRefineMainGridAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRefineMainGridAsync>d__.<>4__this = this;
		<InitRefineMainGridAsync>d__.<>1__state = -1;
		<InitRefineMainGridAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitRefineMainGridAsync>d__40>(ref <InitRefineMainGridAsync>d__);
		return <InitRefineMainGridAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B032 RID: 45106 RVA: 0x002EF668 File Offset: 0x002ED868
	private UniTask InitInvalidTipsAsync()
	{
		VisionRefineTabView.<InitInvalidTipsAsync>d__41 <InitInvalidTipsAsync>d__;
		<InitInvalidTipsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitInvalidTipsAsync>d__.<>4__this = this;
		<InitInvalidTipsAsync>d__.<>1__state = -1;
		<InitInvalidTipsAsync>d__.<>t__builder.Start<VisionRefineTabView.<InitInvalidTipsAsync>d__41>(ref <InitInvalidTipsAsync>d__);
		return <InitInvalidTipsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B033 RID: 45107 RVA: 0x002EF6AB File Offset: 0x002ED8AB
	private VisionRefineMaterialItem InitMaterialItem()
	{
		return new VisionRefineMaterialItem();
	}

	// Token: 0x0600B034 RID: 45108 RVA: 0x002EF6B2 File Offset: 0x002ED8B2
	private VisionRefineRefineTab InitUpLeftTabItem()
	{
		return new VisionRefineRefineTab();
	}

	// Token: 0x0600B035 RID: 45109 RVA: 0x002EF6B9 File Offset: 0x002ED8B9
	private VisionRefineAttributeItem InitSingleVerticalItem()
	{
		return new VisionRefineAttributeItem
		{
			OnSelectedCallback = new Func<int, bool>(this.OnClickSubAttributeSelected),
			OnDeselectedCallback = new Func<int, bool>(this.OnClickSubAttributeDeselected)
		};
	}

	// Token: 0x0600B036 RID: 45110 RVA: 0x002EF6E4 File Offset: 0x002ED8E4
	private VisionRefineSlotItem InitRefineMainGridItem()
	{
		return new VisionRefineSlotItem(new Action<bool, int>(this.OnClickRefineMainGrid))
		{
			OnGetMainPropItemIdCallback = new Func<int?>(this.OnGetMainPropItemIdCallback),
			OnIsShouldElementItemDownCallback = new Func<bool>(this.OnIsShouldElementItemDownCallback)
		};
	}

	// Token: 0x0600B037 RID: 45111 RVA: 0x002EF71C File Offset: 0x002ED91C
	protected override void OnStart()
	{
		this.SetCaptionItem(false, null);
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnSequenceTabStart));
			levelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceTabFinish), false);
		}
		this.SetViewState(ERefineViewState.Root, false);
		this.ClearSelectMainAttribute();
	}

	// Token: 0x0600B038 RID: 45112 RVA: 0x002EF784 File Offset: 0x002ED984
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<PhantomPolishResponse>(EEventName.OnVisionRefineResult, new Action<PhantomPolishResponse>(this.OnResponseVisionRefine));
		Singleton<EventSystem>.Instance.Add<PhantomBatchPolishResponse>(EEventName.OnVisionRefineBatchMainResult, new Action<PhantomBatchPolishResponse>(this.OnVisionRefineBatchMainResult));
		Singleton<EventSystem>.Instance.Add<PhantomVicePolishResponse>(EEventName.OnVisionRefineSubPreviewResult, new Action<PhantomVicePolishResponse>(this.OnVisionRefineSubPreviewResult));
		Singleton<EventSystem>.Instance.Add<PhantomVicePolishAckResponse, bool>(EEventName.OnVisionRefineSubResult, new Action<PhantomVicePolishAckResponse, bool>(this.OnVisionRefineSubResult));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
	}

	// Token: 0x0600B039 RID: 45113 RVA: 0x002EF820 File Offset: 0x002EDA20
	protected override void OnShowUiTabViewFromToggle()
	{
		if (this.ExtraParamsExactly == null)
		{
			return;
		}
		IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
		if (extraParamsExactly.UniqueId != null)
		{
			PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(extraParamsExactly.UniqueId.Value);
			if (phantomItemData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Calabash;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "当前声骸没有对应背包数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uid", extraParamsExactly.UniqueId.Value);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			if (choosePanel != null)
			{
				choosePanel.SetSelectionDummy(phantomItemData);
			}
			VisionRefineChoosePanel choosePanel2 = this.ChoosePanel;
			if (choosePanel2 != null)
			{
				choosePanel2.SetSelection(phantomItemData);
			}
		}
		if (this.ExtraParamsExactly.RefineType != null)
		{
			this.CurrentRefineType = this.ExtraParamsExactly.RefineType.Value;
			this.ChoosePanel.CurrentRefineType = this.ExtraParamsExactly.RefineType.Value;
		}
		this.SetViewState(extraParamsExactly.ViewState, true);
	}

	// Token: 0x0600B03A RID: 45114 RVA: 0x002EF926 File Offset: 0x002EDB26
	protected override void OnBeforeShow()
	{
		this.HasInitChoosePanel = false;
		if (this.CurrentRefineType != EVisionRefineRefineType.Sub)
		{
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			if (choosePanel != null)
			{
				choosePanel.RemoveInvalidSelections();
			}
		}
		this.RefreshSlotPanel();
		this.RefreshChoosePanel();
		this.RefreshCostItemList();
	}

	// Token: 0x0600B03B RID: 45115 RVA: 0x002EF95B File Offset: 0x002EDB5B
	protected override void OnAfterShow()
	{
		ModelBase<PhantomBattleModel>.Instance.RecordVisionRefineRedDot(false);
	}

	// Token: 0x0600B03C RID: 45116 RVA: 0x002EF968 File Offset: 0x002EDB68
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<PhantomPolishResponse>(EEventName.OnVisionRefineResult, new Action<PhantomPolishResponse>(this.OnResponseVisionRefine));
		Singleton<EventSystem>.Instance.Remove<PhantomBatchPolishResponse>(EEventName.OnVisionRefineBatchMainResult, new Action<PhantomBatchPolishResponse>(this.OnVisionRefineBatchMainResult));
		Singleton<EventSystem>.Instance.Remove<PhantomVicePolishResponse>(EEventName.OnVisionRefineSubPreviewResult, new Action<PhantomVicePolishResponse>(this.OnVisionRefineSubPreviewResult));
		Singleton<EventSystem>.Instance.Remove<PhantomVicePolishAckResponse, bool>(EEventName.OnVisionRefineSubResult, new Action<PhantomVicePolishAckResponse, bool>(this.OnVisionRefineSubResult));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
	}

	// Token: 0x0600B03D RID: 45117 RVA: 0x002EFA04 File Offset: 0x002EDC04
	private void RefreshChoosePanel()
	{
		if (this.ExtraParamsExactly != null && this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
		{
			return;
		}
		this.HasInitChoosePanel = true;
		List<PhantomItemData> phantomItemDataList = ModelBase<InventoryModel>.Instance.GetPhantomItemDataList();
		this.ChoosePanel.RefreshList(phantomItemDataList);
	}

	// Token: 0x0600B03E RID: 45118 RVA: 0x002EFA50 File Offset: 0x002EDC50
	private void SetViewState(ERefineViewState newState, bool force = false)
	{
		ERefineViewState? stateView = this.StateView;
		if ((stateView.GetValueOrDefault() == newState & stateView != null) && !force)
		{
			return;
		}
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.SetActive(newState == ERefineViewState.Choose);
		}
		GenericLayout<VisionRefineMaterialItem, ISelectedData> materialLayout = this.MaterialLayout;
		if (materialLayout != null)
		{
			materialLayout.SetActive(newState != ERefineViewState.Attribute);
		}
		VisionRefineCostItem costItem = this.CostItem;
		if (costItem != null)
		{
			costItem.SetActive(newState == ERefineViewState.Attribute);
		}
		GenericLayout<VisionRefineRefineTab, VisionRefineRefineTabData> upLeftTab = this.UpLeftTab;
		if (upLeftTab != null)
		{
			upLeftTab.SetActive(newState != ERefineViewState.Choose);
		}
		if (newState != ERefineViewState.Choose)
		{
			GenericLayout<VisionRefineRefineTab, VisionRefineRefineTabData> upLeftTab2 = this.UpLeftTab;
			if (upLeftTab2 != null)
			{
				upLeftTab2.RefreshByDataAsync(this.BuildUpLeftTabData(), false, null).Forget();
			}
		}
		if (this.StateView != null)
		{
			switch (newState)
			{
			case ERefineViewState.Root:
				this.ShowRootState(this.StateView.Value);
				break;
			case ERefineViewState.Choose:
				this.ShowChooseState(this.StateView.Value);
				break;
			case ERefineViewState.Attribute:
				this.ShowAttributeState(this.StateView.Value);
				break;
			}
		}
		this.StateView = new ERefineViewState?(newState);
		this.RefreshSlotPanel();
		VisionRefineChoosePanel choosePanel2 = this.ChoosePanel;
		if (choosePanel2 != null)
		{
			choosePanel2.ShowTipsComponent(null);
		}
		if (newState == ERefineViewState.Choose)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "VisionRefineChooseStart");
		}
	}

	// Token: 0x0600B03F RID: 45119 RVA: 0x002EFB98 File Offset: 0x002EDD98
	private void ShowChooseState(ERefineViewState oldState)
	{
		if (!this.HasInitChoosePanel)
		{
			this.RefreshChoosePanel();
		}
		if (oldState == ERefineViewState.Root)
		{
			this.UiViewSequence.PlaySequence("SwitchA_1", false, null);
			this.ChoosePanel.UiViewSequence.PlaySequence("SwitchA", false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.CalabashEnterInternalView);
			return;
		}
		if (oldState == ERefineViewState.Attribute)
		{
			this.UiViewSequence.PlaySequence("SwitchB_2", false, null);
			this.ChoosePanel.UiViewSequence.PlaySequence("SwitchA", false, null);
			this.SetCaptionItem(false, null);
		}
	}

	// Token: 0x0600B040 RID: 45120 RVA: 0x002EFC50 File Offset: 0x002EDE50
	private void ShowRootState(ERefineViewState oldState)
	{
		if (oldState == ERefineViewState.Choose)
		{
			this.UiViewSequence.PlaySequence("SwitchA_2", false, null);
			this.ChoosePanel.UiViewSequence.PlaySequence("SwitchB", false, null);
			this.ChoosePanel.UiViewSequence.AddSequenceFinishEvent("SwitchB", new Action<string>(this.OnSequenceHideFinish), false);
			Singleton<EventSystem>.Instance.Emit(EEventName.CalabashQuitInternalView);
			return;
		}
		if (oldState == ERefineViewState.Attribute)
		{
			this.UiViewSequence.PlaySequence("SwitchC_1", false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.CalabashQuitInternalView);
			this.SetCaptionItem(false, null);
		}
	}

	// Token: 0x0600B041 RID: 45121 RVA: 0x002EFD0C File Offset: 0x002EDF0C
	private void ShowAttributeState(ERefineViewState oldState)
	{
		this.SetCaptionItem(true, new bool?(oldState == ERefineViewState.Root));
		if (oldState == ERefineViewState.Root)
		{
			this.UiViewSequence.PlaySequence("SwitchC_2", false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.CalabashEnterInternalView);
			return;
		}
		if (oldState == ERefineViewState.Choose)
		{
			this.UiViewSequence.AddSequenceFinishEvent("SwitchB_1", new Action<string>(this.OnSequenceConfirmFinish), false);
			this.UiViewSequence.PlaySequence("SwitchB_1", false, null);
			this.ChoosePanel.UiViewSequence.PlaySequence("SwitchB", false, null);
		}
	}

	// Token: 0x0600B042 RID: 45122 RVA: 0x002EFDB4 File Offset: 0x002EDFB4
	private void RefreshSlotInteractive()
	{
		bool btnInteractive = true;
		if (this.ExtraParamsExactly != null)
		{
			IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
			if (extraParamsExactly.SlotInteractive != null)
			{
				btnInteractive = extraParamsExactly.SlotInteractive.Value;
			}
		}
		((this.CurrentRefineType == EVisionRefineRefineType.Main) ? this.RefineMainSlotItem : this.RefineSubSlotItem).SetBtnInteractive(btnInteractive);
	}

	// Token: 0x0600B043 RID: 45123 RVA: 0x002EFE0D File Offset: 0x002EE00D
	private void RefreshSlotPanel()
	{
		this.RefreshSlotPanelMain();
		this.RefreshSlotPanelSub();
		this.RefreshInvalidTip();
		this.RefreshCurrency();
	}

	// Token: 0x0600B044 RID: 45124 RVA: 0x002EFE28 File Offset: 0x002EE028
	private void RefreshCurrency()
	{
		if (this.ExtraParamsExactly != null && this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
		{
			List<int> list = this.BuildItemListForCurrency();
			Action<int[]> currencyChangeCallback = this.ExtraParamsExactly.CurrencyChangeCallback;
			if (currencyChangeCallback != null)
			{
				currencyChangeCallback(list.ToArray());
			}
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			if (choosePanel == null)
			{
				return;
			}
			choosePanel.RefreshCurrency(null);
			return;
		}
		else
		{
			List<int> list2 = this.BuildItemListForCurrency();
			VisionRefineChoosePanel choosePanel2 = this.ChoosePanel;
			if (choosePanel2 == null)
			{
				return;
			}
			choosePanel2.RefreshCurrency(list2.ToArray());
			return;
		}
	}

	// Token: 0x0600B045 RID: 45125 RVA: 0x002EFEA4 File Offset: 0x002EE0A4
	private List<int> BuildItemListForCurrency()
	{
		List<int> list = new List<int>();
		EVisionRefineRefineType currentRefineType = this.CurrentRefineType;
		if (currentRefineType != EVisionRefineRefineType.Main)
		{
			if (currentRefineType != EVisionRefineRefineType.Sub)
			{
				return list;
			}
		}
		else
		{
			Dictionary<int, int> visionRefineMaterialDefaultCost = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineMaterialDefaultCost();
			if (visionRefineMaterialDefaultCost == null)
			{
				return list;
			}
			using (Dictionary<int, int>.Enumerator enumerator = visionRefineMaterialDefaultCost.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					list.Add(keyValuePair.Key);
				}
				return list;
			}
		}
		Dictionary<int, int> visionRefineSubMaterialDefaultCost = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineSubMaterialDefaultCost();
		if (visionRefineSubMaterialDefaultCost != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair2 in visionRefineSubMaterialDefaultCost)
			{
				list.Add(keyValuePair2.Key);
			}
		}
		return list;
	}

	// Token: 0x0600B046 RID: 45126 RVA: 0x002EFF7C File Offset: 0x002EE17C
	private void RefreshInvalidTip()
	{
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			this.RefreshInvalidTipMain();
			return;
		}
		if (this.CurrentRefineType == EVisionRefineRefineType.Sub)
		{
			this.RefreshInvalidTipSub();
		}
	}

	// Token: 0x0600B047 RID: 45127 RVA: 0x002EFF9C File Offset: 0x002EE19C
	private void RefreshInvalidTipMain()
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		List<PhantomItemData> list = (choosePanel != null) ? choosePanel.CurrentSelectedList : null;
		if (list == null || list.Count == 0)
		{
			VisionRefineInvalidTips invalidTips = this.InvalidTips;
			if (invalidTips != null)
			{
				invalidTips.SetUiActive(false);
			}
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(true);
			return;
		}
		else
		{
			int num = 0;
			foreach (PhantomItemData phantomItemData in list)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(phantomItemData.GetUniqueId());
				if (phantomBattleData != null && phantomBattleData.GetVisionIfCanRefine(this.CurrentRefineType))
				{
					num++;
				}
			}
			if (num == 0)
			{
				VisionRefineInvalidTips invalidTips2 = this.InvalidTips;
				if (invalidTips2 != null)
				{
					invalidTips2.SetUiActive(true);
				}
				VisionRefineInvalidTips invalidTips3 = this.InvalidTips;
				if (invalidTips3 != null)
				{
					invalidTips3.RefreshExternalByData(new VisionRefineInvalidTipsData
					{
						LockDescriptionTextId = "Text_VisionRefineMain_InvalidReason_Text"
					});
				}
				UUIButtonComponent button2 = base.GetButton(2);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				VisionRefineInvalidTips invalidTips4 = this.InvalidTips;
				if (invalidTips4 != null)
				{
					invalidTips4.SetUiActive(false);
				}
				UUIButtonComponent button3 = base.GetButton(2);
				if (button3 == null)
				{
					return;
				}
				button3.RootUIComp.Get().SetUIActive(true);
				return;
			}
		}
	}

	// Token: 0x0600B048 RID: 45128 RVA: 0x002F00E8 File Offset: 0x002EE2E8
	private void RefreshInvalidTipSub()
	{
		if (this.SelectedVision != null)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.SelectedVision.GetUniqueId());
			bool flag = phantomBattleData == null || !phantomBattleData.GetVisionIfCanRefine(this.CurrentRefineType);
			VisionRefineInvalidTips invalidTips = this.InvalidTips;
			if (invalidTips != null)
			{
				invalidTips.SetUiActive(flag);
			}
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!flag);
			}
			if (flag)
			{
				VisionRefineInvalidTips invalidTips2 = this.InvalidTips;
				if (invalidTips2 == null)
				{
					return;
				}
				invalidTips2.RefreshExternalByData(new VisionRefineInvalidTipsData
				{
					LockDescriptionTextId = "Text_VisionRefineSub_InvalidReason_Text"
				});
			}
			return;
		}
		VisionRefineInvalidTips invalidTips3 = this.InvalidTips;
		if (invalidTips3 != null)
		{
			invalidTips3.SetUiActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(2);
		if (button2 == null)
		{
			return;
		}
		button2.RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600B049 RID: 45129 RVA: 0x002F01B4 File Offset: 0x002EE3B4
	private void RefreshSlotPanelMain()
	{
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			this.RefreshMainViewStates();
			this.RefreshMainSingleAttributePanel();
			this.RefreshMainGrid();
			this.RefreshMainSlotItem();
			this.RefreshMainMaterial();
			return;
		}
		UUIItem item = base.GetItem(21);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(15);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		VisionRefineAttributePanelLite refineMainSingleAttributePanel = this.RefineMainSingleAttributePanel;
		if (refineMainSingleAttributePanel == null)
		{
			return;
		}
		refineMainSingleAttributePanel.SetActive(false);
	}

	// Token: 0x0600B04A RID: 45130 RVA: 0x002F0224 File Offset: 0x002EE424
	private void RefreshMainViewStates()
	{
		UUIItem item = base.GetItem(21);
		if (item != null)
		{
			item.SetUIActive(this.StateView.GetValueOrDefault() != ERefineViewState.Choose);
		}
		UUIItem item2 = base.GetItem(15);
		if (item2 != null)
		{
			item2.SetUIActive(this.StateView.GetValueOrDefault() == ERefineViewState.Choose);
		}
		VisionRefineAttributePanelLite refineMainMultiAttributePanel = this.RefineMainMultiAttributePanel;
		if (refineMainMultiAttributePanel != null)
		{
			refineMainMultiAttributePanel.SetActive(this.StateView.GetValueOrDefault() == ERefineViewState.Choose);
		}
		if (this.StateView.GetValueOrDefault() == ERefineViewState.Choose)
		{
			VisionRefineAttributePanelLite refineMainMultiAttributePanel2 = this.RefineMainMultiAttributePanel;
			if (refineMainMultiAttributePanel2 == null)
			{
				return;
			}
			refineMainMultiAttributePanel2.RefreshItemSwitch(this.SelectMainAttribute);
		}
	}

	// Token: 0x0600B04B RID: 45131 RVA: 0x002F02BC File Offset: 0x002EE4BC
	private void RefreshMainSingleAttributePanel()
	{
		bool flag = this.StateView.GetValueOrDefault() == ERefineViewState.Attribute && this.ExtraParamsExactly != null;
		VisionRefineAttributePanelLite refineMainSingleAttributePanel = this.RefineMainSingleAttributePanel;
		if (refineMainSingleAttributePanel != null)
		{
			refineMainSingleAttributePanel.SetActive(flag);
		}
		VisionRefineAttributePanelLite refineMainSingleAttributePanel2 = this.RefineMainSingleAttributePanel;
		if (refineMainSingleAttributePanel2 != null)
		{
			refineMainSingleAttributePanel2.RefreshInteractive(true);
		}
		if (flag)
		{
			VisionRefineAttributePanelLite refineMainSingleAttributePanel3 = this.RefineMainSingleAttributePanel;
			if (refineMainSingleAttributePanel3 != null)
			{
				refineMainSingleAttributePanel3.RefreshItemSwitch(this.SelectMainAttribute);
			}
			IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
			int? num = (extraParamsExactly != null) ? extraParamsExactly.UniqueId : null;
			if (num != null)
			{
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(num.Value);
				if (phantomBattleData == null || !phantomBattleData.GetVisionIfCanRefine(this.CurrentRefineType))
				{
					VisionRefineAttributePanelLite refineMainSingleAttributePanel4 = this.RefineMainSingleAttributePanel;
					if (refineMainSingleAttributePanel4 == null)
					{
						return;
					}
					refineMainSingleAttributePanel4.RefreshInteractive(false);
				}
			}
		}
	}

	// Token: 0x0600B04C RID: 45132 RVA: 0x002F037C File Offset: 0x002EE57C
	private void RefreshMainGrid()
	{
		GenericLayout<VisionRefineSlotItem, VisionRefineSlotItemData> refineMainGrid = this.RefineMainGrid;
		if (refineMainGrid != null)
		{
			refineMainGrid.SetActive(this.StateView.GetValueOrDefault() == ERefineViewState.Choose);
		}
		if (this.StateView.GetValueOrDefault() == ERefineViewState.Choose)
		{
			GenericLayout<VisionRefineSlotItem, VisionRefineSlotItemData> refineMainGrid2 = this.RefineMainGrid;
			List<VisionRefineSlotItem> list = (refineMainGrid2 != null) ? refineMainGrid2.GetLayoutItemList() : null;
			if (list != null)
			{
				int num = 0;
				foreach (VisionRefineSlotItem visionRefineSlotItem in list)
				{
					List<PhantomItemData> currentSelectedList = this.ChoosePanel.CurrentSelectedList;
					if (currentSelectedList != null && num < currentSelectedList.Count)
					{
						int uniqueId = currentSelectedList[num].GetUniqueId();
						PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
						PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(uniqueId);
						visionRefineSlotItem.RefreshByData(phantomItemData, false, phantomDataBase.GetCost());
						visionRefineSlotItem.SetBtnInteractive(true);
					}
					else
					{
						visionRefineSlotItem.SetBtnInteractive(false);
						visionRefineSlotItem.RefreshEmpty();
					}
					num++;
				}
			}
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(18);
			string textStringId = "Text_ItemRecycleChosenTotal_text";
			object[] array = new object[2];
			int num2 = 0;
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			int? num3;
			if (choosePanel == null)
			{
				num3 = null;
			}
			else
			{
				List<PhantomItemData> currentSelectedList2 = choosePanel.CurrentSelectedList;
				num3 = ((currentSelectedList2 != null) ? new int?(currentSelectedList2.Count) : null);
			}
			int? num4 = num3;
			array[num2] = num4.GetValueOrDefault();
			array[1] = 10;
			instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlyArray<object>(array));
		}
	}

	// Token: 0x0600B04D RID: 45133 RVA: 0x002F04F4 File Offset: 0x002EE6F4
	private void RefreshMainSlotItem()
	{
		this.RefreshSlotInteractive();
		if (this.StateView.GetValueOrDefault() == ERefineViewState.Attribute && this.ExtraParamsExactly != null)
		{
			int? uniqueId = this.ExtraParamsExactly.UniqueId;
			this.RefreshSlotItem(uniqueId, true);
			return;
		}
		this.RefreshSlotItem(null, true);
	}

	// Token: 0x0600B04E RID: 45134 RVA: 0x002F0544 File Offset: 0x002EE744
	private void RefreshMainMaterial()
	{
		UUIItem item = base.GetItem(3);
		ERefineViewState? stateView;
		ERefineViewState erefineViewState;
		if (item != null)
		{
			stateView = this.StateView;
			erefineViewState = ERefineViewState.Root;
			item.SetUIActive(stateView.GetValueOrDefault() == erefineViewState & stateView != null);
		}
		UUIItem item2 = base.GetItem(8);
		if (item2 != null)
		{
			stateView = this.StateView;
			erefineViewState = ERefineViewState.Root;
			item2.SetUIActive(!(stateView.GetValueOrDefault() == erefineViewState & stateView != null));
		}
		Dictionary<int, int> visionRefineMaterialDefaultCost = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineMaterialDefaultCost();
		stateView = this.StateView;
		erefineViewState = ERefineViewState.Root;
		if (stateView.GetValueOrDefault() == erefineViewState & stateView != null)
		{
			List<ISelectedData> list = new List<ISelectedData>();
			if (visionRefineMaterialDefaultCost != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in visionRefineMaterialDefaultCost)
				{
					SelectedData item3 = new SelectedData
					{
						ItemId = keyValuePair.Key,
						IncId = 0,
						Count = 0,
						SelectedCount = 0
					};
					list.Add(item3);
				}
			}
			this.MaterialLayout.RefreshByData(list, null, false);
			return;
		}
		List<PhantomItemData> selectedVisionValidList = this.SelectedVisionValidList;
		if (selectedVisionValidList != null)
		{
			List<int> list2 = new List<int>();
			foreach (PhantomItemData phantomItemData in selectedVisionValidList)
			{
				list2.Add(phantomItemData.GetUniqueId());
			}
			Dictionary<int, int> visionListRefineMainMaterialCost = ModelBase<PhantomBattleModel>.Instance.GetVisionListRefineMainMaterialCost(list2);
			if (visionListRefineMainMaterialCost == null)
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				if (visionRefineMaterialDefaultCost != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair2 in visionRefineMaterialDefaultCost)
					{
						dictionary[keyValuePair2.Key] = 0;
					}
				}
				this.RefreshCost(dictionary);
				return;
			}
			this.RefreshCost(visionListRefineMainMaterialCost);
		}
	}

	// Token: 0x0600B04F RID: 45135 RVA: 0x002F072C File Offset: 0x002EE92C
	private void RefreshSlotPanelSub()
	{
		if (this.CurrentRefineType == EVisionRefineRefineType.Sub)
		{
			UUIItem item = base.GetItem(11);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.RefreshSlotInteractive();
			this.RefreshMaterialPanel();
			this.RefreshSubAttributePanel();
			this.RefreshSubSlot();
			return;
		}
		UUIItem item2 = base.GetItem(11);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600B050 RID: 45136 RVA: 0x002F0784 File Offset: 0x002EE984
	private void RefreshMaterialPanel()
	{
		ERefineViewState? stateView = this.StateView;
		ERefineViewState erefineViewState = ERefineViewState.Root;
		bool flag = (stateView.GetValueOrDefault() == erefineViewState & stateView != null) && this.SelectedVision == null;
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(8);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		Dictionary<int, int> dictionary = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineSubMaterialDefaultCost();
		if (this.SelectedVision != null)
		{
			dictionary = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineSubMaterialCost(this.SelectLockedSubProp.Count);
		}
		if (flag)
		{
			List<ISelectedData> list = new List<ISelectedData>();
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in dictionary)
				{
					SelectedData item3 = new SelectedData
					{
						ItemId = keyValuePair.Key,
						IncId = 0,
						Count = ((this.SelectedVision == null) ? 0 : keyValuePair.Value),
						SelectedCount = 0
					};
					list.Add(item3);
				}
			}
			this.MaterialLayout.RefreshByData(list, null, false);
			return;
		}
		if (dictionary != null)
		{
			this.RefreshCost(dictionary);
			return;
		}
		UUIItem item4 = base.GetItem(8);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(false);
	}

	// Token: 0x0600B051 RID: 45137 RVA: 0x002F08CC File Offset: 0x002EEACC
	private void RefreshSubAttributePanel()
	{
		bool flag = this.StateView.GetValueOrDefault() == ERefineViewState.Choose || this.SelectedVision != null;
		UUIItem item = base.GetItem(12);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (this.SelectedVision == null)
		{
			this.SelectLockedSubProp.Clear();
		}
		if (flag)
		{
			GenericLayout<VisionRefineAttributeItem, VisionRefineAttributeItemData> refineSubVertical = this.RefineSubVertical;
			if (refineSubVertical != null)
			{
				refineSubVertical.RefreshByData(this.BuildRefineSubVerticalData(), null, false);
			}
			GenericLayout<VisionRefineMainAttributeItem, VisionRefineAttributeItemData> refineSubUpperVert = this.RefineSubUpperVert;
			if (refineSubUpperVert != null)
			{
				refineSubUpperVert.RefreshByData(this.BuildRefineMainVerticalData(), null, false);
			}
		}
		UUIItem item2 = base.GetItem(24);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(flag && this.StateView.GetValueOrDefault() != ERefineViewState.Attribute);
	}

	// Token: 0x0600B052 RID: 45138 RVA: 0x002F097C File Offset: 0x002EEB7C
	private void RefreshSubSlot()
	{
		if (this.SelectedVision != null)
		{
			int uniqueId = this.SelectedVision.GetUniqueId();
			this.RefreshSlotItem(new int?(uniqueId), this.StateView.GetValueOrDefault() == ERefineViewState.Attribute);
		}
		else
		{
			this.RefineSubSlotItem.RefreshEmpty();
		}
		this.RefreshCostItemList();
	}

	// Token: 0x0600B053 RID: 45139 RVA: 0x002F09CC File Offset: 0x002EEBCC
	private void RefreshSlotItem(int? uid, bool isConfirm)
	{
		VisionRefineSlotItem visionRefineSlotItem = (this.CurrentRefineType == EVisionRefineRefineType.Main) ? this.RefineMainSlotItem : this.RefineSubSlotItem;
		if (uid == null)
		{
			visionRefineSlotItem.RefreshEmpty();
			return;
		}
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uid.Value);
		PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(uid.Value);
		visionRefineSlotItem.RefreshByData(phantomItemData, isConfirm, phantomDataBase.GetCost());
	}

	// Token: 0x0600B054 RID: 45140 RVA: 0x002F0A34 File Offset: 0x002EEC34
	private void RefreshCost(Dictionary<int, int> materialCost)
	{
		if (materialCost.Count == 1)
		{
			using (Dictionary<int, int>.Enumerator enumerator = materialCost.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					VisionRefineCostItem costItem = this.CostItem;
					if (costItem != null)
					{
						costItem.SetCost(keyValuePair.Key, keyValuePair.Value);
					}
				}
				return;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.CB, "检查数据重构的材料消耗配置，目前只展示一个材料消耗", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600B055 RID: 45141 RVA: 0x002F0AC4 File Offset: 0x002EECC4
	private void OnSequenceTabStart(string sequenceName)
	{
		if (sequenceName == "Start".ToString() || sequenceName == "ShowView".ToString() || sequenceName == "Sle".ToString())
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiTabViewName.VisionRefineTabView, true);
		}
	}

	// Token: 0x0600B056 RID: 45142 RVA: 0x002F0B1C File Offset: 0x002EED1C
	private void OnSequenceTabFinish(string sequenceName)
	{
		if (sequenceName == "Start".ToString() || sequenceName == "ShowView".ToString() || sequenceName == "Sle".ToString())
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiTabViewName.VisionRefineTabView, false);
		}
	}

	// Token: 0x0600B057 RID: 45143 RVA: 0x002F0B74 File Offset: 0x002EED74
	private void OnSequenceHideFinish(string _)
	{
		this.ChoosePanel.SetActive(false);
		this.ChoosePanel.UiViewSequence.RemoveSequenceFinishEvent("SwitchB", new Action<string>(this.OnSequenceHideFinish));
	}

	// Token: 0x0600B058 RID: 45144 RVA: 0x002F0BA3 File Offset: 0x002EEDA3
	private void OnSequenceConfirmFinish(string _)
	{
		this.ChoosePanel.SetActive(false);
		this.UiViewSequence.RemoveSequenceFinishEvent("SwitchB_1", new Action<string>(this.OnSequenceConfirmFinish));
	}

	// Token: 0x0600B059 RID: 45145 RVA: 0x002F0BCD File Offset: 0x002EEDCD
	[NullableContext(2)]
	private void OnChangeSelection(PhantomItemData selectedData)
	{
		this.SelectLockedSubProp.Clear();
		this.RefreshSlotPanel();
	}

	// Token: 0x0600B05A RID: 45146 RVA: 0x002F0BE0 File Offset: 0x002EEDE0
	private void OnChangeMultiSelection([Nullable(new byte[]
	{
		2,
		1
	})] List<PhantomItemData> selectedDataList)
	{
		this.RefreshSlotPanel();
	}

	// Token: 0x0600B05B RID: 45147 RVA: 0x002F0BE8 File Offset: 0x002EEDE8
	public bool OnClickCloseRoot()
	{
		if (this.StateView.GetValueOrDefault() == ERefineViewState.Attribute)
		{
			this.SetViewState(ERefineViewState.Choose, false);
			return true;
		}
		return false;
	}

	// Token: 0x0600B05C RID: 45148 RVA: 0x002F0C03 File Offset: 0x002EEE03
	[NullableContext(2)]
	private void OnClickConfirm(IRefineAttrItemData data)
	{
		this.SelectMainAttribute = data;
		this.RefreshSlotPanel();
		this.RefreshChoosePanel();
	}

	// Token: 0x0600B05D RID: 45149 RVA: 0x002F0C18 File Offset: 0x002EEE18
	private int[] GetSelectedPropItemIdList()
	{
		List<int> list = new List<int>();
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		List<PhantomItemData> list2 = (choosePanel != null) ? choosePanel.CurrentSelectedList : null;
		if (list2 != null)
		{
			foreach (PhantomItemData phantomItemData in list2)
			{
				int uniqueId = phantomItemData.GetUniqueId();
				PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
				if (phantomDataBase != null)
				{
					int phantomPropId = phantomDataBase.GetPhantomFirstMainProp().PhantomPropId;
					list.Add(phantomPropId);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600B05E RID: 45150 RVA: 0x002F0CB0 File Offset: 0x002EEEB0
	private void OnCostTabChangeCallback()
	{
		this.RefineMainMultiAttributePanel.RefreshItemSwitch(null);
		this.RefreshSlotPanel();
	}

	// Token: 0x0600B05F RID: 45151 RVA: 0x002F0CC4 File Offset: 0x002EEEC4
	private int? OnGetMainPropItemIdCallback()
	{
		IRefineAttrItemData selectMainAttribute = this.SelectMainAttribute;
		if (selectMainAttribute == null)
		{
			return null;
		}
		return new int?(selectMainAttribute.PropItemId);
	}

	// Token: 0x0600B060 RID: 45152 RVA: 0x002F0CEF File Offset: 0x002EEEEF
	private bool OnIsShouldElementItemDownCallback()
	{
		return true;
	}

	// Token: 0x0600B061 RID: 45153 RVA: 0x002F0CF4 File Offset: 0x002EEEF4
	private void OnClickTip()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionRefineMaterialHint);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600B062 RID: 45154 RVA: 0x002F0D18 File Offset: 0x002EEF18
	private void OnClickRefine()
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.ShowTipsComponent(null);
		}
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			this.HandleMainRefine();
			return;
		}
		if (this.CurrentRefineType == EVisionRefineRefineType.Sub)
		{
			this.HandleSubRefine();
		}
	}

	// Token: 0x0600B063 RID: 45155 RVA: 0x002F0D4C File Offset: 0x002EEF4C
	private void HandleMainRefine()
	{
		if (this.ExtraParamsExactly != null && this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
		{
			if (this.StateView.GetValueOrDefault() != ERefineViewState.Attribute)
			{
				return;
			}
		}
		else if (this.StateView.GetValueOrDefault() != ERefineViewState.Choose)
		{
			this.SetViewState(ERefineViewState.Choose, false);
			return;
		}
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (((choosePanel != null) ? choosePanel.CurrentSelectedList : null) == null || this.ChoosePanel.CurrentSelectedList.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_PhantomRefineLackTip_Text", Array.Empty<object>());
			return;
		}
		List<PhantomItemData> selectedVisionValidList = this.SelectedVisionValidList;
		if (selectedVisionValidList == null || selectedVisionValidList.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_VisionRefineMain_BlockedTips_Text", Array.Empty<object>());
			return;
		}
		if (!this.CheckMaterial())
		{
			return;
		}
		if (!this.CheckAttribute())
		{
			return;
		}
		if (this.ExtraParamsExactly != null && this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
		{
			int? num = null;
			foreach (PhantomItemData phantomItemData in selectedVisionValidList)
			{
				num = new int?(phantomItemData.GetUniqueId());
			}
			if (num != null)
			{
				ControllerBase<CalabashController>.Instance.RequestPhantomPolishRequest(num.Value, this.SelectMainAttribute.PropItemId);
				this.SelectMainAttribute = null;
				return;
			}
		}
		else
		{
			List<int> list = new List<int>();
			foreach (PhantomItemData phantomItemData2 in selectedVisionValidList)
			{
				list.Add(phantomItemData2.GetUniqueId());
			}
			ControllerBase<CalabashController>.Instance.RequestPhantomBatchPolishRequest(list.ToArray(), this.SelectMainAttribute.PropItemId).Forget();
		}
	}

	// Token: 0x0600B064 RID: 45156 RVA: 0x002F0F20 File Offset: 0x002EF120
	private void HandleSubRefine()
	{
		if (this.SelectedVision == null)
		{
			ERefineViewState? stateView = this.StateView;
			ERefineViewState erefineViewState = ERefineViewState.Root;
			if (stateView.GetValueOrDefault() == erefineViewState & stateView != null)
			{
				this.SetViewState(ERefineViewState.Choose, false);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_PhantomRefineLackTip_Text", Array.Empty<object>());
			return;
		}
		else
		{
			if (!this.CheckMaterial())
			{
				return;
			}
			int? num = null;
			List<string> list = new List<string>();
			int count = this.SelectLockedSubProp.Count;
			Dictionary<int, int> visionRefineSubMaterialCost = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineSubMaterialCost(count);
			int num2 = 0;
			if (visionRefineSubMaterialCost != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in visionRefineSubMaterialCost)
				{
					num2 = keyValuePair.Value;
				}
			}
			if (this.SelectLockedSubProp.Count <= 0)
			{
				num = new int?(447);
				list.Add(num2.ToString());
			}
			else
			{
				num = new int?(450);
				list.Add(count.ToString());
				list.Add(num2.ToString());
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((EConfirmBoxConfigId)num.Value);
			confirmBoxDataNew.TextArgs = list.ToArray();
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				List<int> list2 = new List<int>();
				foreach (int item in this.SelectLockedSubProp)
				{
					list2.Add(item);
				}
				ControllerBase<CalabashController>.Instance.RequestPhantomVicePolishRequest(this.SelectedVision.GetUniqueId(), list2.ToArray()).Forget();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
	}

	// Token: 0x0600B065 RID: 45157 RVA: 0x002F1080 File Offset: 0x002EF280
	private void OnClickRefineMainDelete()
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.ShowTipsComponent(null);
		}
		VisionRefineChoosePanel choosePanel2 = this.ChoosePanel;
		if (choosePanel2 != null)
		{
			choosePanel2.ClearCurrentCostMultiChoose();
		}
		this.SelectMainAttribute = null;
		this.RefreshSlotPanel();
		this.RefreshChoosePanel();
	}

	// Token: 0x0600B066 RID: 45158 RVA: 0x002F10B8 File Offset: 0x002EF2B8
	private void OnClickRefineSubSlot(bool isAddVision, int _1)
	{
		if (isAddVision && this.StateView.GetValueOrDefault() == ERefineViewState.Choose)
		{
			return;
		}
		if (!isAddVision)
		{
			this.ChoosePanel.ClearSelection();
		}
		if (this.StateView.GetValueOrDefault() != ERefineViewState.Choose)
		{
			this.SetViewState(ERefineViewState.Choose, false);
		}
	}

	// Token: 0x0600B067 RID: 45159 RVA: 0x002F10F0 File Offset: 0x002EF2F0
	private void OnClickRefineMainSlot(bool _0, int _1)
	{
		if (this.StateView.GetValueOrDefault() != ERefineViewState.Choose)
		{
			this.SetViewState(ERefineViewState.Choose, false);
		}
	}

	// Token: 0x0600B068 RID: 45160 RVA: 0x002F1108 File Offset: 0x002EF308
	private void OnClickRefineMainGrid(bool isAddVision, int gridIndex)
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		PhantomItemData phantomItemData;
		if (choosePanel == null)
		{
			phantomItemData = null;
		}
		else
		{
			List<PhantomItemData> currentSelectedList = choosePanel.CurrentSelectedList;
			phantomItemData = ((currentSelectedList != null) ? currentSelectedList[gridIndex] : null);
		}
		PhantomItemData phantomItemData2 = phantomItemData;
		if (isAddVision)
		{
			this.ChoosePanel.ShowTipsComponent(phantomItemData2);
			return;
		}
		if (!isAddVision && phantomItemData2 != null)
		{
			VisionRefineChoosePanel choosePanel2 = this.ChoosePanel;
			if (choosePanel2 != null)
			{
				choosePanel2.RefreshSelectionByItemData(phantomItemData2);
			}
			VisionRefineChoosePanel choosePanel3 = this.ChoosePanel;
			if (choosePanel3 == null)
			{
				return;
			}
			choosePanel3.ShowTipsComponent(null);
		}
	}

	// Token: 0x0600B069 RID: 45161 RVA: 0x002F116E File Offset: 0x002EF36E
	private void OnClickCloseChoosePanel()
	{
		this.SetViewState(ERefineViewState.Root, false);
	}

	// Token: 0x0600B06A RID: 45162 RVA: 0x002F1178 File Offset: 0x002EF378
	private void OnClickAttributeSelect()
	{
		if (this.ChoosePanel == null)
		{
			return;
		}
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.ShowTipsComponent(null);
		}
		EVisionRefineCostType? currentCostType = this.ChoosePanel.CurrentCostType;
		if (currentCostType == null)
		{
			return;
		}
		int num = 0;
		switch (currentCostType.Value)
		{
		case EVisionRefineCostType.Cost4:
			num = 4;
			break;
		case EVisionRefineCostType.Cost3:
			num = 3;
			break;
		case EVisionRefineCostType.Cost1:
			num = 1;
			break;
		}
		int? num2 = null;
		bool dataConfirmed = false;
		if (this.ExtraParamsExactly == null || !this.ExtraParamsExactly.IsSingleMode.GetValueOrDefault())
		{
			PhantomItemData phantomItemData = null;
			foreach (PhantomItemData phantomItemData2 in ModelBase<InventoryModel>.Instance.GetPhantomItemDataList())
			{
				if (phantomItemData2.GetConfig().As<Aki.Config.PhantomItem>().Value.QualityId >= 5)
				{
					int rarity = phantomItemData2.GetConfig().As<Aki.Config.PhantomItem>().Value.Rarity;
					if (ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost == num)
					{
						phantomItemData = phantomItemData2;
						break;
					}
				}
			}
			if (phantomItemData != null)
			{
				num2 = new int?(phantomItemData.GetUniqueId());
			}
		}
		else
		{
			num2 = this.ExtraParamsExactly.UniqueId;
			dataConfirmed = true;
		}
		if (num2 == null)
		{
			return;
		}
		Action<IRefineAttrItemData> callback = new Action<IRefineAttrItemData>(this.OnClickConfirm);
		Func<int[]> getSelectedPropItemIdList = new Func<int[]>(this.GetSelectedPropItemIdList);
		IRefineAttrItemData selectMainAttribute = this.SelectMainAttribute;
		RefineAttrSelectViewOpenParam param = new RefineAttrSelectViewOpenParam
		{
			GetSelectedPropItemIdList = getSelectedPropItemIdList,
			Callback = callback,
			DataConfirmed = dataConfirmed,
			IncId = num2.Value,
			SelectAttribute = selectMainAttribute
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRefineAttributeSelectView, param, null);
	}

	// Token: 0x0600B06B RID: 45163 RVA: 0x002F1350 File Offset: 0x002EF550
	private bool OnClickSubAttributeSelected(int index)
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.ShowTipsComponent(null);
		}
		if (this.SelectLockedSubProp.Count == 4)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_VisionRefineSubLockAll_Text", Array.Empty<object>());
			return false;
		}
		this.SelectLockedSubProp.Add(index);
		Dictionary<int, int> visionRefineSubMaterialCost = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineSubMaterialCost(this.SelectLockedSubProp.Count);
		if (visionRefineSubMaterialCost != null)
		{
			this.RefreshCost(visionRefineSubMaterialCost);
		}
		return true;
	}

	// Token: 0x0600B06C RID: 45164 RVA: 0x002F13C4 File Offset: 0x002EF5C4
	private bool OnClickSubAttributeDeselected(int index)
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.ShowTipsComponent(null);
		}
		if (this.SelectLockedSubProp.Count == 0)
		{
			return false;
		}
		this.SelectLockedSubProp.Remove(index);
		Dictionary<int, int> visionRefineSubMaterialCost = ModelBase<PhantomBattleModel>.Instance.GetVisionRefineSubMaterialCost(this.SelectLockedSubProp.Count);
		if (visionRefineSubMaterialCost != null)
		{
			this.RefreshCost(visionRefineSubMaterialCost);
		}
		return true;
	}

	// Token: 0x0600B06D RID: 45165 RVA: 0x002F1420 File Offset: 0x002EF620
	private void OnClickCancel()
	{
		if (this.StateView.GetValueOrDefault() != ERefineViewState.Choose)
		{
			this.SetViewState(ERefineViewState.Choose, false);
		}
	}

	// Token: 0x0600B06E RID: 45166 RVA: 0x002F1438 File Offset: 0x002EF638
	private void OnItemFuncValueChange(int uniqueId)
	{
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		if (choosePanel != null)
		{
			choosePanel.OnItemFuncValueChange(uniqueId);
		}
		this.RefreshSlotPanel();
	}

	// Token: 0x0600B06F RID: 45167 RVA: 0x002F1454 File Offset: 0x002EF654
	private void OnResponseVisionRefine(PhantomPolishResponse response)
	{
		VisionRefineResultViewParam visionRefineResultViewParam = new VisionRefineResultViewParam();
		visionRefineResultViewParam.Response = response;
		visionRefineResultViewParam.ResponseBatch = null;
		visionRefineResultViewParam.ShowTips = true;
		IRefineAttrItemData selectMainAttribute = this.SelectMainAttribute;
		visionRefineResultViewParam.PropIndexId = ((selectMainAttribute != null) ? new int?(selectMainAttribute.PropIndexId) : null);
		VisionRefineResultViewParam visionRefineResultViewParam2 = visionRefineResultViewParam;
		if (this.ExtraParamsExactly != null)
		{
			IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
			if (extraParamsExactly.ResultShowTips != null)
			{
				visionRefineResultViewParam2.ShowTips = extraParamsExactly.ResultShowTips.Value;
			}
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRefineResultView, visionRefineResultViewParam2, delegate(bool result, int id)
		{
			if (!result)
			{
				return;
			}
			(Singleton<UiManager>.Instance.GetView(id) as VisionRefineResultView).OnCloseCallback = new Action<bool>(this.OnCloseResultView);
			if (!((this.ExtraParamsExactly != null) ? this.ExtraParamsExactly.IsSingleMode : new bool?(false)).GetValueOrDefault())
			{
				VisionRefineChoosePanel choosePanel = this.ChoosePanel;
				if (choosePanel != null)
				{
					choosePanel.ClearSelection();
				}
				this.SetViewState(ERefineViewState.Root, false);
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetAlpha(1f);
				}
			}
			this.SelectMainAttribute = null;
		});
	}

	// Token: 0x0600B070 RID: 45168 RVA: 0x002F14F0 File Offset: 0x002EF6F0
	private void OnCloseResultView(bool result)
	{
		if (!result)
		{
			return;
		}
		if (!((this.ExtraParamsExactly != null) ? this.ExtraParamsExactly.IsSingleMode : new bool?(false)).GetValueOrDefault())
		{
			this.SetViewState(ERefineViewState.Choose, false);
		}
	}

	// Token: 0x0600B071 RID: 45169 RVA: 0x002F1530 File Offset: 0x002EF730
	private void OnVisionRefineBatchMainResult(PhantomBatchPolishResponse response)
	{
		VisionRefineResultViewParam visionRefineResultViewParam = new VisionRefineResultViewParam();
		visionRefineResultViewParam.Response = null;
		visionRefineResultViewParam.ResponseBatch = response;
		visionRefineResultViewParam.ShowTips = false;
		IRefineAttrItemData selectMainAttribute = this.SelectMainAttribute;
		visionRefineResultViewParam.PropIndexId = ((selectMainAttribute != null) ? new int?(selectMainAttribute.PropIndexId) : null);
		VisionRefineResultViewParam param = visionRefineResultViewParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRefineResultView, param, delegate(bool result, int id)
		{
			if (!result)
			{
				return;
			}
			this.SelectMainAttribute = null;
			VisionRefineChoosePanel choosePanel = this.ChoosePanel;
			if (choosePanel == null)
			{
				return;
			}
			choosePanel.ClearCurrentCostMultiChoose();
		});
	}

	// Token: 0x0600B072 RID: 45170 RVA: 0x002F159C File Offset: 0x002EF79C
	private void OnVisionRefineSubPreviewResult(PhantomVicePolishResponse response)
	{
		VisionRefineTabView.<>c__DisplayClass105_0 CS$<>8__locals1 = new VisionRefineTabView.<>c__DisplayClass105_0();
		CS$<>8__locals1.selectedUid = this.SelectedVision.GetUniqueId();
		VisionRefineBatchResultViewData visionRefineBatchResultViewData = new VisionRefineBatchResultViewData();
		visionRefineBatchResultViewData.LeftAttrList = this.BuildRefineSubVerticalLeftData();
		visionRefineBatchResultViewData.RightAttrList = this.BuildRefineSubVerticalRightData(response);
		visionRefineBatchResultViewData.OnClickCancel = delegate()
		{
			VisionRefineTabView.<>c__DisplayClass105_0.<<OnVisionRefineSubPreviewResult>b__0>d <<OnVisionRefineSubPreviewResult>b__0>d;
			<<OnVisionRefineSubPreviewResult>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnVisionRefineSubPreviewResult>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnVisionRefineSubPreviewResult>b__0>d.<>1__state = -1;
			<<OnVisionRefineSubPreviewResult>b__0>d.<>t__builder.Start<VisionRefineTabView.<>c__DisplayClass105_0.<<OnVisionRefineSubPreviewResult>b__0>d>(ref <<OnVisionRefineSubPreviewResult>b__0>d);
			return <<OnVisionRefineSubPreviewResult>b__0>d.<>t__builder.Task;
		};
		visionRefineBatchResultViewData.OnClickConfirm = delegate()
		{
			VisionRefineTabView.<>c__DisplayClass105_0.<<OnVisionRefineSubPreviewResult>b__1>d <<OnVisionRefineSubPreviewResult>b__1>d;
			<<OnVisionRefineSubPreviewResult>b__1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnVisionRefineSubPreviewResult>b__1>d.<>4__this = CS$<>8__locals1;
			<<OnVisionRefineSubPreviewResult>b__1>d.<>1__state = -1;
			<<OnVisionRefineSubPreviewResult>b__1>d.<>t__builder.Start<VisionRefineTabView.<>c__DisplayClass105_0.<<OnVisionRefineSubPreviewResult>b__1>d>(ref <<OnVisionRefineSubPreviewResult>b__1>d);
			return <<OnVisionRefineSubPreviewResult>b__1>d.<>t__builder.Task;
		};
		visionRefineBatchResultViewData.UniqueId = new int?(CS$<>8__locals1.selectedUid);
		VisionRefineBatchResultViewData visionRefineBatchResultViewData2 = visionRefineBatchResultViewData;
		IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
		int? num;
		if (extraParamsExactly == null)
		{
			num = null;
		}
		else
		{
			List<AttrRecommendInfo> recommendRefineSubList = extraParamsExactly.RecommendRefineSubList;
			num = ((recommendRefineSubList != null) ? new int?(recommendRefineSubList.Count) : null);
		}
		int? num2 = num;
		visionRefineBatchResultViewData2.HasRecommendData = (num2.GetValueOrDefault() > 0);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRefineSubResultView, visionRefineBatchResultViewData, null);
	}

	// Token: 0x0600B073 RID: 45171 RVA: 0x002F1669 File Offset: 0x002EF869
	private void OnVisionRefineSubResult(PhantomVicePolishAckResponse response, bool ack)
	{
		if (ack)
		{
			this.SelectLockedSubProp.Clear();
		}
	}

	// Token: 0x0600B074 RID: 45172 RVA: 0x002F167C File Offset: 0x002EF87C
	private bool CheckMaterial()
	{
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			List<PhantomItemData> selectedVisionValidList = this.SelectedVisionValidList;
			if (selectedVisionValidList == null)
			{
				return false;
			}
			List<int> list = new List<int>();
			foreach (PhantomItemData phantomItemData in selectedVisionValidList)
			{
				list.Add(phantomItemData.GetUniqueId());
			}
			if (!ModelBase<PhantomBattleModel>.Instance.IsVisionListRefineMainMaterialEnough(list))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_PhantomRefineMaterialLackTip_Text", Array.Empty<object>());
				return false;
			}
			return true;
		}
		else
		{
			if (this.CurrentRefineType != EVisionRefineRefineType.Sub)
			{
				return false;
			}
			int count = this.SelectLockedSubProp.Count;
			if (count >= 5)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_VisionRefineSubLockAll_Text", Array.Empty<object>());
				return false;
			}
			if (!ModelBase<PhantomBattleModel>.Instance.IsVisionRefineSubMaterialEnough(count))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_PhantomRefineMaterialLackTip_Text", Array.Empty<object>());
				return false;
			}
			return true;
		}
	}

	// Token: 0x0600B075 RID: 45173 RVA: 0x002F1768 File Offset: 0x002EF968
	private bool CheckAttribute()
	{
		if (this.SelectMainAttribute == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PrefabTextItem_PhantomRefineAttributeLackTip_Text", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0600B076 RID: 45174 RVA: 0x002F178C File Offset: 0x002EF98C
	private void SetCaptionItem(bool active, bool? activeSequence = null)
	{
		if (base.GetItem(7).bIsUIActive == active)
		{
			return;
		}
		if (this.ExtraParamsExactly != null)
		{
			IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
			if (extraParamsExactly.ActiveCaptionItem != null)
			{
				base.GetItem(7).SetUIActive(extraParamsExactly.ActiveCaptionItem.Value);
				return;
			}
		}
		if (this.CaptionItem == null)
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(7));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCancel));
		}
		this.CaptionItem.SetUiActive(active);
		if (active && activeSequence.GetValueOrDefault())
		{
			this.UiViewSequence.PlaySequence("CaptionIn", false, null);
		}
	}

	// Token: 0x0600B077 RID: 45175 RVA: 0x002F1848 File Offset: 0x002EFA48
	private List<VisionRefineRefineTabData> BuildUpLeftTabData()
	{
		List<VisionRefineRefineTabData> list = new List<VisionRefineRefineTabData>();
		if (CalabashDefine.visionRefineRefineMap != null)
		{
			using (Dictionary<EVisionRefineRefineType, string>.Enumerator enumerator = CalabashDefine.visionRefineRefineMap.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<EVisionRefineRefineType, string> kvp = enumerator.Current;
					list.Add(new VisionRefineRefineTabData
					{
						IsChosen = (kvp.Key == this.CurrentRefineType),
						RefineType = kvp.Key,
						TabTextId = kvp.Value,
						CanChangeExecute = ((EVisionRefineRefineType type) => type != this.CurrentRefineType),
						OnClick = delegate()
						{
							this.OnClickRefreshRefineTab(kvp.Key);
							this.CurrentRefineType = kvp.Key;
							this.ChoosePanel.CurrentRefineType = kvp.Key;
							this.RefreshSlotPanel();
							this.RefreshChoosePanel();
						}
					});
				}
			}
		}
		return list;
	}

	// Token: 0x0600B078 RID: 45176 RVA: 0x002F1928 File Offset: 0x002EFB28
	private void RefreshCostItemList()
	{
		CalabashRootView calabashRootView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CalabashRootView) as CalabashRootView;
		if (calabashRootView != null)
		{
			bool flag = this.CurrentRefineType == EVisionRefineRefineType.Sub && this.SelectedVision != null;
			calabashRootView.ShowCostItemCaption(flag ? this.BuildItemListForCurrency().ToArray() : Array.Empty<int>());
		}
	}

	// Token: 0x0600B079 RID: 45177 RVA: 0x002F1980 File Offset: 0x002EFB80
	private void OnClickRefreshRefineTab(EVisionRefineRefineType current)
	{
		if (this.UpLeftTab == null)
		{
			return;
		}
		foreach (VisionRefineRefineTab visionRefineRefineTab in this.UpLeftTab.GetLayoutItemList())
		{
			if (visionRefineRefineTab.CheckChosen(current))
			{
				visionRefineRefineTab.OnSelected(false);
			}
			else
			{
				visionRefineRefineTab.OnDeselected(false);
			}
		}
	}

	// Token: 0x0600B07A RID: 45178 RVA: 0x002F19F4 File Offset: 0x002EFBF4
	private List<VisionRefineAttributeItemData> BuildRefineSubVerticalData()
	{
		List<VisionRefineAttributeItemData> list = new List<VisionRefineAttributeItemData>();
		if (this.SelectedVision == null)
		{
			VisionRefineAttributeItemData visionRefineAttributeItemData = new VisionRefineAttributeItemData();
			for (int i = 0; i < 5; i++)
			{
				visionRefineAttributeItemData.NameTextId = "ErrorCode_200347_Text";
				visionRefineAttributeItemData.CanInteractive = false;
				visionRefineAttributeItemData.ForceCheckboxActive = new bool?(false);
				list.Add(visionRefineAttributeItemData);
			}
			return list;
		}
		int uniqueId = this.SelectedVision.GetUniqueId();
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
		List<VisionSubPropData> list2 = (phantomDataBase != null) ? phantomDataBase.GetEquipmentViewPreviewData() : null;
		for (int j = 0; j < 5; j++)
		{
			VisionRefineAttributeItemData visionRefineAttributeItemData2 = new VisionRefineAttributeItemData();
			if (list2 != null && j < list2.Count && list2[j] != null && list2[j].PhantomSubProp != null)
			{
				visionRefineAttributeItemData2.NameTextId = list2[j].GetSubPropName();
				visionRefineAttributeItemData2.NumberText = list2[j].GetAttributeValueString();
				visionRefineAttributeItemData2.IsChosen = this.SelectLockedSubProp.Contains(j);
				int phantomPropId = list2[j].PhantomSubProp.PhantomPropId;
				PhantomSubProperty subConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropId);
				VisionRefineAttributeItemData visionRefineAttributeItemData3 = visionRefineAttributeItemData2;
				IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
				visionRefineAttributeItemData3.IsRecommend = (((extraParamsExactly != null) ? extraParamsExactly.RecommendRefineSubList : null) != null && this.ExtraParamsExactly.RecommendRefineSubList.Find((AttrRecommendInfo value) => value.GetAttrId() == subConfig.PropId && value.GetAddType() == subConfig.AddType) != null);
				visionRefineAttributeItemData2.CanInteractive = (list2.Count == 5);
				visionRefineAttributeItemData2.ForceCheckboxActive = new bool?(true);
			}
			else
			{
				visionRefineAttributeItemData2.NameTextId = "Text_VisionRefineSubAttriLocked_Text";
				visionRefineAttributeItemData2.CanInteractive = false;
				visionRefineAttributeItemData2.ForceCheckboxActive = new bool?(false);
			}
			list.Add(visionRefineAttributeItemData2);
		}
		return list;
	}

	// Token: 0x0600B07B RID: 45179 RVA: 0x002F1BB0 File Offset: 0x002EFDB0
	private VisionRefineAttributeItemData[] BuildRefineSubVerticalLeftData()
	{
		CalabashController instance = ControllerBase<CalabashController>.Instance;
		PhantomItemData selectedVision = this.SelectedVision;
		int? uid = (selectedVision != null) ? new int?(selectedVision.GetUniqueId()) : null;
		HashSet<int> selectLockedSubProp = this.SelectLockedSubProp;
		IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
		return instance.BuildRefineSubVerticalLeftDataByUid(uid, selectLockedSubProp, (extraParamsExactly != null) ? extraParamsExactly.RecommendRefineSubList : null);
	}

	// Token: 0x0600B07C RID: 45180 RVA: 0x002F1C00 File Offset: 0x002EFE00
	private VisionRefineAttributeItemData[] BuildRefineSubVerticalRightData(PhantomVicePolishResponse response)
	{
		List<Aki.Protocol.PhantomPropInfo> list = new List<Aki.Protocol.PhantomPropInfo>(response.PhantomSubProp);
		CalabashController instance = ControllerBase<CalabashController>.Instance;
		PhantomItemData selectedVision = this.SelectedVision;
		int? uid = (selectedVision != null) ? new int?(selectedVision.GetUniqueId()) : null;
		List<Aki.Protocol.PhantomPropInfo> unAckInfo = list;
		HashSet<int> selectLockedSubProp = this.SelectLockedSubProp;
		IVisionRefineTabViewParam extraParamsExactly = this.ExtraParamsExactly;
		return instance.BuildRefineSubVerticalRightDataByUid(uid, unAckInfo, selectLockedSubProp, (extraParamsExactly != null) ? extraParamsExactly.RecommendRefineSubList : null);
	}

	// Token: 0x0600B07D RID: 45181 RVA: 0x002F1C5C File Offset: 0x002EFE5C
	private List<VisionRefineSlotItemData> BuildRefineMainGridData()
	{
		List<VisionRefineSlotItemData> list = new List<VisionRefineSlotItemData>();
		for (int i = 0; i < 10; i++)
		{
			list.Add(new VisionRefineSlotItemData());
		}
		return list;
	}

	// Token: 0x0600B07E RID: 45182 RVA: 0x002F1C88 File Offset: 0x002EFE88
	private List<VisionRefineAttributeItemData> BuildRefineMainVerticalData()
	{
		List<VisionRefineAttributeItemData> list = new List<VisionRefineAttributeItemData>();
		if (this.SelectedVision == null)
		{
			return list;
		}
		int uniqueId = this.SelectedVision.GetUniqueId();
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
		List<AttrListScrollData> list2 = (phantomDataBase != null) ? phantomDataBase.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false) : null;
		if (list2 == null || list2.Count <= 0)
		{
			return list;
		}
		foreach (AttrListScrollData attrListScrollData in list2)
		{
			VisionRefineAttributeItemData visionRefineAttributeItemData = new VisionRefineAttributeItemData();
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrListScrollData.Id);
			if (propertyIndexInfo != null)
			{
				visionRefineAttributeItemData.NameTextId = propertyIndexInfo.Value.Name;
				visionRefineAttributeItemData.IconPath = propertyIndexInfo.Value.Icon;
				visionRefineAttributeItemData.NumberText = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attrListScrollData.Id, attrListScrollData.BaseValue, attrListScrollData.IsRatio);
				list.Add(visionRefineAttributeItemData);
			}
		}
		return list;
	}

	// Token: 0x0600B07F RID: 45183 RVA: 0x002F1D9C File Offset: 0x002EFF9C
	private void ClearSelectMainAttribute()
	{
		this.SelectMainAttributeInternalSingle = null;
		this.SelectMainAttributeInternalMulti.Clear();
	}

	// Token: 0x0600B080 RID: 45184 RVA: 0x002F1DB0 File Offset: 0x002EFFB0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Filter"))
		{
			return null;
		}
		VisionRefineChoosePanel choosePanel = this.ChoosePanel;
		UUIItem uuiitem = (choosePanel != null) ? choosePanel.GetFilterToggleItem() : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x04005383 RID: 21379
	[Nullable(2)]
	private VisionRefineSlotItem RefineMainSlotItem;

	// Token: 0x04005384 RID: 21380
	[Nullable(2)]
	private VisionRefineSlotItem RefineSubSlotItem;

	// Token: 0x04005385 RID: 21381
	[Nullable(2)]
	private VisionRefineChoosePanel ChoosePanel;

	// Token: 0x04005386 RID: 21382
	[Nullable(2)]
	private VisionRefineAttributePanelLite RefineMainSingleAttributePanel;

	// Token: 0x04005387 RID: 21383
	[Nullable(2)]
	private VisionRefineAttributePanelLite RefineMainMultiAttributePanel;

	// Token: 0x04005388 RID: 21384
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04005389 RID: 21385
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineMaterialItem, ISelectedData> MaterialLayout;

	// Token: 0x0400538A RID: 21386
	private ERefineViewState? StateView;

	// Token: 0x0400538B RID: 21387
	[Nullable(2)]
	private IRefineAttrItemData SelectMainAttributeInternalSingle;

	// Token: 0x0400538C RID: 21388
	private readonly Dictionary<EVisionRefineCostType, IRefineAttrItemData> SelectMainAttributeInternalMulti = new Dictionary<EVisionRefineCostType, IRefineAttrItemData>();

	// Token: 0x0400538D RID: 21389
	private readonly HashSet<int> SelectLockedSubProp = new HashSet<int>();

	// Token: 0x0400538E RID: 21390
	private bool HasInitChoosePanel;

	// Token: 0x0400538F RID: 21391
	[Nullable(2)]
	private VisionRefineCostItem CostItem;

	// Token: 0x04005390 RID: 21392
	private EVisionRefineRefineType CurrentRefineType;

	// Token: 0x04005391 RID: 21393
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineRefineTab, VisionRefineRefineTabData> UpLeftTab;

	// Token: 0x04005392 RID: 21394
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineAttributeItem, VisionRefineAttributeItemData> RefineSubVertical;

	// Token: 0x04005393 RID: 21395
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineSlotItem, VisionRefineSlotItemData> RefineMainGrid;

	// Token: 0x04005394 RID: 21396
	[Nullable(2)]
	private VisionRefineInvalidTips InvalidTips;

	// Token: 0x04005395 RID: 21397
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineMainAttributeItem, VisionRefineAttributeItemData> RefineSubUpperVert;

	// Token: 0x02007BAD RID: 31661
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A462 RID: 173154
		RootChoosePanel,
		// Token: 0x0402A463 RID: 173155
		ItemRefineSlot,
		// Token: 0x0402A464 RID: 173156
		BtnRefine,
		// Token: 0x0402A465 RID: 173157
		PanelMaterial,
		// Token: 0x0402A466 RID: 173158
		PanelRefineMainMultiAttribute,
		// Token: 0x0402A467 RID: 173159
		BtnTip,
		// Token: 0x0402A468 RID: 173160
		LayoutMaterial,
		// Token: 0x0402A469 RID: 173161
		ItemCaption,
		// Token: 0x0402A46A RID: 173162
		CostItem,
		// Token: 0x0402A46B RID: 173163
		UpLeftTabRoot,
		// Token: 0x0402A46C RID: 173164
		UpLeftTabItem,
		// Token: 0x0402A46D RID: 173165
		RefineSubRoot,
		// Token: 0x0402A46E RID: 173166
		RefineSubInfo,
		// Token: 0x0402A46F RID: 173167
		RefineSubVertical,
		// Token: 0x0402A470 RID: 173168
		RefineSubVerticalToggle,
		// Token: 0x0402A471 RID: 173169
		RefineMainRoot2,
		// Token: 0x0402A472 RID: 173170
		RefineMainGrid,
		// Token: 0x0402A473 RID: 173171
		RefineMainGridItem,
		// Token: 0x0402A474 RID: 173172
		RefineMainInfo,
		// Token: 0x0402A475 RID: 173173
		RefineMainDeleteButton,
		// Token: 0x0402A476 RID: 173174
		RefineInvalidTipsItem,
		// Token: 0x0402A477 RID: 173175
		RefineMainRoot1,
		// Token: 0x0402A478 RID: 173176
		RefineMainSlot,
		// Token: 0x0402A479 RID: 173177
		PanelRefineMainSingleAttribute,
		// Token: 0x0402A47A RID: 173178
		RefineSubUpperVert
	}
}
