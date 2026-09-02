using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.SubViews;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D9 RID: 21721
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaMapEntrancePanel : WorldMapExtraUiPanel
	{
		// Token: 0x17008E9C RID: 36508
		// (get) Token: 0x06037540 RID: 226624 RVA: 0x00E09A7B File Offset: 0x00E07C7B
		public new PhantomArenaMapEntrancePanelParam OpenParam
		{
			get
			{
				return this.OpenParam as PhantomArenaMapEntrancePanelParam;
			}
		}

		// Token: 0x06037541 RID: 226625 RVA: 0x00E09A88 File Offset: 0x00E07C88
		[NullableContext(1)]
		public PhantomArenaMapEntrancePanel(EWorldMapExtraUiPanelName panelName, WorldMapExtraUiPanelComponent extraUiPanelComponent) : base(panelName, extraUiPanelComponent)
		{
		}

		// Token: 0x06037542 RID: 226626 RVA: 0x00E09AA4 File Offset: 0x00E07CA4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUISprite)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUIItem)),
				new ValueTuple<int, Type>(25, typeof(UUIItem)),
				new ValueTuple<int, Type>(26, typeof(UUIText)),
				new ValueTuple<int, Type>(27, typeof(UUIItem)),
				new ValueTuple<int, Type>(28, typeof(UUIItem)),
				new ValueTuple<int, Type>(29, typeof(UUIItem)),
				new ValueTuple<int, Type>(30, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnReward)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickCard)),
				new ValueTuple<int, Delegate>(12, new Action(this.OnClickRole)),
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickCollect)),
				new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickToggleNpcList))
			};
		}

		// Token: 0x06037543 RID: 226627 RVA: 0x00E09DEC File Offset: 0x00E07FEC
		private int GetMapIdByChallengeId(int challengeId)
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).MapId;
		}

		// Token: 0x06037544 RID: 226628 RVA: 0x00E09E0C File Offset: 0x00E0800C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaMapEntrancePanel.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaMapEntrancePanel.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037545 RID: 226629 RVA: 0x00E09E4F File Offset: 0x00E0804F
		protected override void OnStart()
		{
			this.InitCaptionItem();
			this.InitZoomButton();
			this.InitSequencePlayer();
			this.BindRedDot();
		}

		// Token: 0x06037546 RID: 226630 RVA: 0x00E09E6C File Offset: 0x00E0806C
		private void InitZoomButton()
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				this.ZoomInButton = new LongPressButton(button, delegate(float delta)
				{
					this.OnZoomIn();
				}, 100);
			}
			UUIButtonComponent button2 = base.GetButton(3);
			if (button2 != null)
			{
				this.ZoomOutButton = new LongPressButton(button2, delegate(float delta)
				{
					this.OnZoomOut();
				}, 100);
			}
		}

		// Token: 0x06037547 RID: 226631 RVA: 0x00E09EC4 File Offset: 0x00E080C4
		private void InitNpcListView()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(5);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIItem item = base.GetItem(17);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.NpcListSequencePlayer = new UiSequencePlayer(base.GetItem(17));
			this.NpcListSequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnNpcListSequenceEnd));
			UUIItem item2 = base.GetItem(20);
			AUIBaseActor auibaseActor = ((item2 != null) ? item2.GetOwner() : null) as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
			}
			UUILoopScrollViewComponent uuiloopScrollViewComponent = ((auibaseActor != null) ? auibaseActor.GetComponentByClass(UUILoopScrollViewComponent.StaticClass()) : null) as UUILoopScrollViewComponent;
			UUILoopScrollViewComponent scrollView = uuiloopScrollViewComponent;
			UUIItem item3 = base.GetItem(21);
			this.NpcListView = new LoopScrollView<PhantomArenaMapEntranceNpcListItem, int>(scrollView, ((item3 != null) ? item3.GetOwner() : null) as AUIBaseActor, () => new PhantomArenaMapEntranceNpcListItem
			{
				SelectCallBack = new Action<int>(this.OnSelectNpcListItem)
			}, false);
			UUIItem item4 = base.GetItem(21);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
		}

		// Token: 0x06037548 RID: 226632 RVA: 0x00E09FC0 File Offset: 0x00E081C0
		private void InitSequencePlayer()
		{
			this.RewardBtnSequencePlayer = new UiSequencePlayer(base.GetItem(16));
			this.RewardBtnSequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnRewardBtnSequenceEnd));
			this.RightBtnRootSequencePlayer = new UiSequencePlayer(base.GetItem(25));
			this.RightBtnRootSequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnRightBtnRootSequenceEnd));
		}

		// Token: 0x06037549 RID: 226633 RVA: 0x00E0A024 File Offset: 0x00E08224
		private void OnSelectNpcListItem(int challengeId)
		{
			if (this.CurrentSelectedChallengeId == challengeId)
			{
				return;
			}
			this.CurrentSelectedChallengeId = challengeId;
			UiSequencePlayer rightBtnRootSequencePlayer = this.RightBtnRootSequencePlayer;
			if (rightBtnRootSequencePlayer != null)
			{
				rightBtnRootSequencePlayer.PlaySequence("Hide", false, null);
			}
			PhantomArenaMapEntranceDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel != null)
			{
				detailPanel.ShowPanel(challengeId);
			}
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetUiActive(false);
			}
			CommonDropDown<int, int> dropDown = this.DropDown;
			if (dropDown != null)
			{
				dropDown.SetActive(false);
			}
			int markId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId).MarkId;
			if (ModelBase<WorldMapModel>.Instance.GetIsMarkFocal(markId, EMarkType.PhantomArenaNpc))
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
			{
				MarkId = markId,
				MarkType = EMarkType.PhantomArenaNpc,
				Focal = new bool?(true)
			});
		}

		// Token: 0x0603754A RID: 226634 RVA: 0x00E0A0EC File Offset: 0x00E082EC
		private UniTask InitDifficultTabLayout()
		{
			PhantomArenaMapEntrancePanel.<InitDifficultTabLayout>d__28 <InitDifficultTabLayout>d__;
			<InitDifficultTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDifficultTabLayout>d__.<>4__this = this;
			<InitDifficultTabLayout>d__.<>1__state = -1;
			<InitDifficultTabLayout>d__.<>t__builder.Start<PhantomArenaMapEntrancePanel.<InitDifficultTabLayout>d__28>(ref <InitDifficultTabLayout>d__);
			return <InitDifficultTabLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603754B RID: 226635 RVA: 0x00E0A130 File Offset: 0x00E08330
		private UniTask RefreshDifficultTabLayout()
		{
			PhantomArenaMapEntrancePanel.<RefreshDifficultTabLayout>d__29 <RefreshDifficultTabLayout>d__;
			<RefreshDifficultTabLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDifficultTabLayout>d__.<>4__this = this;
			<RefreshDifficultTabLayout>d__.<>1__state = -1;
			<RefreshDifficultTabLayout>d__.<>t__builder.Start<PhantomArenaMapEntrancePanel.<RefreshDifficultTabLayout>d__29>(ref <RefreshDifficultTabLayout>d__);
			return <RefreshDifficultTabLayout>d__.<>t__builder.Task;
		}

		// Token: 0x0603754C RID: 226636 RVA: 0x00E0A173 File Offset: 0x00E08373
		private int GetCurrentMapId()
		{
			return this.CurrentMapId;
		}

		// Token: 0x0603754D RID: 226637 RVA: 0x00E0A17C File Offset: 0x00E0837C
		private void OnSelectDifficultItem(int difficult)
		{
			this.CurrentSelectedDifficult = difficult;
			UiSequencePlayer npcListSequencePlayer = this.NpcListSequencePlayer;
			if (npcListSequencePlayer == null)
			{
				return;
			}
			npcListSequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x0603754E RID: 226638 RVA: 0x00E0A1B0 File Offset: 0x00E083B0
		private UniTask CreateDetailPanel()
		{
			PhantomArenaMapEntrancePanel.<CreateDetailPanel>d__32 <CreateDetailPanel>d__;
			<CreateDetailPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDetailPanel>d__.<>4__this = this;
			<CreateDetailPanel>d__.<>1__state = -1;
			<CreateDetailPanel>d__.<>t__builder.Start<PhantomArenaMapEntrancePanel.<CreateDetailPanel>d__32>(ref <CreateDetailPanel>d__);
			return <CreateDetailPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603754F RID: 226639 RVA: 0x00E0A1F3 File Offset: 0x00E083F3
		private void OnCloseDetailPanel()
		{
			this.CancelSelectNpc();
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetUiActive(true);
		}

		// Token: 0x06037550 RID: 226640 RVA: 0x00E0A20C File Offset: 0x00E0840C
		private void CancelSelectNpc()
		{
			this.CurrentSelectedChallengeId = 0;
			UUIItem item = base.GetItem(25);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UiSequencePlayer rightBtnRootSequencePlayer = this.RightBtnRootSequencePlayer;
			if (rightBtnRootSequencePlayer != null)
			{
				rightBtnRootSequencePlayer.PlaySequence("Show", false, null);
			}
			LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> npcListView = this.NpcListView;
			if (npcListView != null)
			{
				npcListView.DeselectCurrentGridProxy(true);
			}
			this.ExtraUiPanelComponent.ClearClickItem();
			CommonDropDown<int, int> dropDown = this.DropDown;
			if (dropDown == null)
			{
				return;
			}
			dropDown.SetActive(true);
		}

		// Token: 0x06037551 RID: 226641 RVA: 0x00E0A284 File Offset: 0x00E08484
		private UniTask InitDropDownList()
		{
			PhantomArenaMapEntrancePanel.<InitDropDownList>d__35 <InitDropDownList>d__;
			<InitDropDownList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDropDownList>d__.<>4__this = this;
			<InitDropDownList>d__.<>1__state = -1;
			<InitDropDownList>d__.<>t__builder.Start<PhantomArenaMapEntrancePanel.<InitDropDownList>d__35>(ref <InitDropDownList>d__);
			return <InitDropDownList>d__.<>t__builder.Task;
		}

		// Token: 0x06037552 RID: 226642 RVA: 0x00E0A2C7 File Offset: 0x00E084C7
		[NullableContext(1)]
		private PhantomArenaMapDropDownTitleItem CreateTitleItem(UUIItem uiItem)
		{
			return new PhantomArenaMapDropDownTitleItem(uiItem);
		}

		// Token: 0x06037553 RID: 226643 RVA: 0x00E0A2CF File Offset: 0x00E084CF
		[NullableContext(1)]
		private PhantomArenaMapDropDownItem CreateDropDownItem(UUIItem uiItem, int data)
		{
			return new PhantomArenaMapDropDownItem(uiItem);
		}

		// Token: 0x06037554 RID: 226644 RVA: 0x00E0A2D8 File Offset: 0x00E084D8
		private void OnDropDownSelectCall(int index, int data)
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			if (instance != null)
			{
				instance.SaveMapUnlockRedDotById(data, false);
			}
			ValueTuple<int, int>? permanentDefaultChallengeIdAndMarkId = ModelBase<PhantomArenaModel>.Instance.GetPermanentDefaultChallengeIdAndMarkId(new int?(data));
			if (permanentDefaultChallengeIdAndMarkId == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应地图的默认挑战数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mapId", data);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			PhantomArenaBattleController.OpenPhantomArenaMapEntrance(new int?(permanentDefaultChallengeIdAndMarkId.Value.Item1), null);
		}

		// Token: 0x06037555 RID: 226645 RVA: 0x00E0A362 File Offset: 0x00E08562
		private bool OnCheckCanChange(int oldIndex, int newIndex)
		{
			return oldIndex != newIndex;
		}

		// Token: 0x06037556 RID: 226646 RVA: 0x00E0A36B File Offset: 0x00E0856B
		private int GetLevelDropDownTextId(int data)
		{
			return data;
		}

		// Token: 0x06037557 RID: 226647 RVA: 0x00E0A370 File Offset: 0x00E08570
		private void InitCaptionItem()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.CloseCallBack));
			this.CaptionItem.SetTitleLocalText(EPhantomArenaTextId.TextEntranceTitle.ToString());
			ControllerBase<HomeBtnController>.Instance.CreateHomeBtnFromUiItem(base.GetItem(28), EUiViewName.WorldMapView, null, false);
		}

		// Token: 0x06037558 RID: 226648 RVA: 0x00E0A3DA File Offset: 0x00E085DA
		private void CloseCallBack()
		{
			base.CloseMe();
		}

		// Token: 0x06037559 RID: 226649 RVA: 0x00E0A3E4 File Offset: 0x00E085E4
		private void OnClickCard()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			PhantomArenaMainViewOpenParam param = new PhantomArenaMainViewOpenParam
			{
				ChallengeId = 0,
				OpenView = EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView,
				ActivityId = permanentPhantomArenaActivityData.Id
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMainView, param, null);
		}

		// Token: 0x0603755A RID: 226650 RVA: 0x00E0A434 File Offset: 0x00E08634
		private void OnClickRole()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			PhantomArenaMainViewOpenParam param = new PhantomArenaMainViewOpenParam
			{
				ChallengeId = 0,
				OpenView = EPhantomArenaChildViewName.PhantomArenaRoleSelectTabView,
				ActivityId = permanentPhantomArenaActivityData.Id
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMainView, param, null);
		}

		// Token: 0x0603755B RID: 226651 RVA: 0x00E0A484 File Offset: 0x00E08684
		private void OnClickCollect()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaCollectViewNew, permanentPhantomArenaActivityData.Id, null);
		}

		// Token: 0x0603755C RID: 226652 RVA: 0x00E0A4BC File Offset: 0x00E086BC
		private void OnClickBtnReward()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaRewardView, permanentPhantomArenaActivityData.Id, null);
		}

		// Token: 0x0603755D RID: 226653 RVA: 0x00E0A4F4 File Offset: 0x00E086F4
		protected override void OnBeforeShow()
		{
			this.RefreshInfo();
			this.RefreshBtnReward();
			this.RefreshRightDownBtns();
			WorldMapUiEntity worldMapUiComponent = this.ExtraUiPanelComponent.WorldMapUiComponent;
			if (worldMapUiComponent != null)
			{
				worldMapUiComponent.MultiFloorComponent.DeSelectMultiMapFloor(true);
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "BvbMapPanelShow");
		}

		// Token: 0x0603755E RID: 226654 RVA: 0x00E0A544 File Offset: 0x00E08744
		private void RefreshInfo()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetMasterLevel(permanentPhantomArenaActivityData.Id)) : null;
			UUIText text = base.GetText(6);
			if (text != null)
			{
				text.SetText(num.ToString(), true);
			}
			PhantomArenaModel instance2 = ModelBase<PhantomArenaModel>.Instance;
			int? num2 = (instance2 != null) ? new int?(instance2.GetMasterExpNow(permanentPhantomArenaActivityData.Id, null)) : null;
			PhantomArenaModel instance3 = ModelBase<PhantomArenaModel>.Instance;
			PhantomBattleMasterLevel? phantomBattleMasterLevel = (instance3 != null) ? instance3.GetMasterLevelConfig(num.Value, permanentPhantomArenaActivityData.Id) : null;
			if (phantomBattleMasterLevel == null)
			{
				return;
			}
			int? num3 = num2 - phantomBattleMasterLevel.Value.ExpNeed;
			int expNext = phantomBattleMasterLevel.Value.ExpNext;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(7), EPhantomArenaTextId.TextExp.ToString(), new <>z__ReadOnlyArray<object>(new object[]
			{
				num3,
				expNext
			}));
			int titleId = phantomBattleMasterLevel.Value.TitleId;
			PhantomArenaConfig instance4 = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleMasterTitle? phantomBattleMasterTitle = (instance4 != null) ? new PhantomBattleMasterTitle?(instance4.GetPhantomBattleMasterTitleById(titleId)) : null;
			int? num4 = num3;
			float? num5 = ((num4 != null) ? new float?((float)num4.GetValueOrDefault()) : null) / (float)expNext;
			base.GetSprite(15).SetFillAmount(num5.Value);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(8), (phantomBattleMasterTitle != null) ? phantomBattleMasterTitle.GetValueOrDefault().Name : null, Array.Empty<object>());
		}

		// Token: 0x0603755F RID: 226655 RVA: 0x00E0A764 File Offset: 0x00E08964
		private void RefreshChallengeProgress()
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetPermanentFinishedChallengeCount(this.CurrentMapId)) : null;
			PhantomArenaModel instance2 = ModelBase<PhantomArenaModel>.Instance;
			int? num2 = (instance2 != null) ? new int?(instance2.GetPermanentAllChallengeCount(this.CurrentMapId)) : null;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(26), this.IsShowNpcList ? EPhantomArenaTextId.TextChallengeProgressSelect.ToString() : EPhantomArenaTextId.TextChallengeProgressNormal.ToString(), new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				num2
			}));
		}

		// Token: 0x06037560 RID: 226656 RVA: 0x00E0A814 File Offset: 0x00E08A14
		private void RefreshBtnReward()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			ValueTuple<int, int>? valueTuple = (instance != null) ? new ValueTuple<int, int>?(instance.GetAllTaskProgress(permanentPhantomArenaActivityData.Id)) : null;
			PhantomArenaModel instance2 = ModelBase<PhantomArenaModel>.Instance;
			int? num = (instance2 != null) ? new int?(instance2.GetAllTaskSecondCurrencyNum(permanentPhantomArenaActivityData.Id)) : null;
			UUIText text = base.GetText(14);
			if (text != null)
			{
				text.SetText(num.ToString(), true);
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(10), EPhantomArenaTextId.TextRewardProgress.ToString(), new <>z__ReadOnlyArray<object>(new object[]
			{
				valueTuple.Value.Item1,
				valueTuple.Value.Item2
			}));
			UiSequencePlayer rewardBtnSequencePlayer = this.RewardBtnSequencePlayer;
			if (rewardBtnSequencePlayer != null)
			{
				rewardBtnSequencePlayer.StopPrevSequence(false, true);
			}
			if (this.IsShowNpcList)
			{
				UiSequencePlayer rewardBtnSequencePlayer2 = this.RewardBtnSequencePlayer;
				if (rewardBtnSequencePlayer2 == null)
				{
					return;
				}
				rewardBtnSequencePlayer2.PlaySequence("Hide", false, null);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(16);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				UiSequencePlayer rewardBtnSequencePlayer3 = this.RewardBtnSequencePlayer;
				if (rewardBtnSequencePlayer3 == null)
				{
					return;
				}
				rewardBtnSequencePlayer3.PlaySequence("Show", false, null);
				return;
			}
		}

		// Token: 0x06037561 RID: 226657 RVA: 0x00E0A978 File Offset: 0x00E08B78
		private void RefreshRightDownBtns()
		{
			UUIButtonComponent button = base.GetButton(11);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PermanentPhantomArenaCard));
			}
			UUIButtonComponent button2 = base.GetButton(12);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PermanentPhantomArenaRole));
			}
			UUIButtonComponent button3 = base.GetButton(13);
			if (button3 == null)
			{
				return;
			}
			button3.RootUIComp.Get().SetUIActive(ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PermanentPhantomAreaCollect));
		}

		// Token: 0x06037562 RID: 226658 RVA: 0x00E0AA14 File Offset: 0x00E08C14
		private void OnClickToggleNpcList(EToggleState toggleState)
		{
			EToggleState toggleState2 = base.GetExtendToggle(5).GetToggleState();
			this.IsShowNpcList = (toggleState2 == EToggleState.ETT_Checked);
			this.RefreshBtnReward();
			if (this.IsShowNpcList)
			{
				UUIItem item = base.GetItem(17);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UiSequencePlayer npcListSequencePlayer = this.NpcListSequencePlayer;
				if (npcListSequencePlayer != null)
				{
					npcListSequencePlayer.StopPrevSequence(false, true);
				}
				UiSequencePlayer npcListSequencePlayer2 = this.NpcListSequencePlayer;
				if (npcListSequencePlayer2 != null)
				{
					npcListSequencePlayer2.PlaySequence("Show", false, null);
				}
			}
			else
			{
				UiSequencePlayer npcListSequencePlayer3 = this.NpcListSequencePlayer;
				if (npcListSequencePlayer3 != null)
				{
					npcListSequencePlayer3.StopPrevSequence(false, true);
				}
				UiSequencePlayer npcListSequencePlayer4 = this.NpcListSequencePlayer;
				if (npcListSequencePlayer4 != null)
				{
					npcListSequencePlayer4.PlaySequence("Hide", false, null);
				}
			}
			if (this.CurrentSelectedChallengeId == 0)
			{
				List<int> permanentSortedDifficultList = ModelBase<PhantomArenaModel>.Instance.GetPermanentSortedDifficultList(this.CurrentMapId);
				if (permanentSortedDifficultList == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.CB, "difficultList为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				int num = -1;
				foreach (int num2 in permanentSortedDifficultList)
				{
					num = num2;
					if (!ModelBase<PhantomArenaModel>.Instance.GetPermanentIsDifficultCompleted(this.CurrentMapId, num2))
					{
						break;
					}
				}
				if (num != -1)
				{
					GenericLayout<PhantomArenaMapEntranceDifficultItem, int> difficultTabLayout = this.DifficultTabLayout;
					if (difficultTabLayout != null)
					{
						difficultTabLayout.SelectGridProxyByKey(num, true);
					}
				}
			}
			this.RefreshChallengeProgress();
		}

		// Token: 0x06037563 RID: 226659 RVA: 0x00E0AB7C File Offset: 0x00E08D7C
		[NullableContext(1)]
		private void OnNpcListSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Hide")
			{
				UUIItem item = base.GetItem(17);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}
		}

		// Token: 0x06037564 RID: 226660 RVA: 0x00E0AB9E File Offset: 0x00E08D9E
		[NullableContext(1)]
		private void OnRewardBtnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Hide")
			{
				UUIItem item = base.GetItem(16);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}
		}

		// Token: 0x06037565 RID: 226661 RVA: 0x00E0ABC0 File Offset: 0x00E08DC0
		[NullableContext(1)]
		private void OnRightBtnRootSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Hide")
			{
				UUIItem item = base.GetItem(25);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}
		}

		// Token: 0x06037566 RID: 226662 RVA: 0x00E0ABE2 File Offset: 0x00E08DE2
		[NullableContext(1)]
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (sequenceName == "Switch" && eventName == "Switch")
			{
				this.RefreshNpcList();
			}
		}

		// Token: 0x06037567 RID: 226663 RVA: 0x00E0AC04 File Offset: 0x00E08E04
		private void RefreshNpcList()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			Dictionary<int, List<int>> dictionary = (permanentPhantomArenaActivityData != null) ? permanentPhantomArenaActivityData.GetDifficultChallengeIdsMap(this.CurrentMapId) : null;
			List<int> list;
			if (dictionary == null || !dictionary.TryGetValue(this.CurrentSelectedDifficult, out list))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "RefreshNpcList:当前难度对应的ChallengeIdList为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("difficult", this.CurrentSelectedDifficult);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int index = -1;
			bool isSelectFireEvent = false;
			if (this.TargetChallengeId == 0)
			{
				index = list.IndexOf(this.CurrentSelectedChallengeId);
			}
			else
			{
				index = list.IndexOf(this.TargetChallengeId);
				this.TargetChallengeId = 0;
				isSelectFireEvent = true;
			}
			LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> npcListView = this.NpcListView;
			if (npcListView != null)
			{
				npcListView.DeselectCurrentGridProxy(false);
			}
			LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> npcListView2 = this.NpcListView;
			if (npcListView2 == null)
			{
				return;
			}
			npcListView2.RefreshByData(list, false, delegate
			{
				if (index != -1)
				{
					LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> npcListView3 = this.NpcListView;
					if (npcListView3 != null)
					{
						npcListView3.SelectGridProxy(index, isSelectFireEvent);
					}
					LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> npcListView4 = this.NpcListView;
					if (npcListView4 == null || !npcListView4.IsGridDisplaying(index))
					{
						LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> npcListView5 = this.NpcListView;
						if (npcListView5 == null)
						{
							return;
						}
						npcListView5.ScrollToGridIndex(index, true);
					}
				}
			}, false);
		}

		// Token: 0x06037568 RID: 226664 RVA: 0x00E0AD00 File Offset: 0x00E08F00
		private void BindRedDot()
		{
			PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
			if (permanentPhantomArenaActivityData == null)
			{
				return;
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhantomArenaCollect, base.GetItem(24), null, permanentPhantomArenaActivityData.Id);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhantomArenaRole, base.GetItem(23), null, permanentPhantomArenaActivityData.Id);
			base.GetItem(22).SetUIActive(false);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotPhantomArenaTaskReward, base.GetItem(27), null, permanentPhantomArenaActivityData.Id);
			UUIItem item = base.GetItem(30);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06037569 RID: 226665 RVA: 0x00E0AD98 File Offset: 0x00E08F98
		private void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhantomArenaCollect, base.GetItem(24), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhantomArenaRole, base.GetItem(23), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotPhantomArenaTaskReward, base.GetItem(27), 0);
		}

		// Token: 0x0603756A RID: 226666 RVA: 0x00E0ADED File Offset: 0x00E08FED
		protected override void OnBeforeDestroy()
		{
			LongPressButton zoomInButton = this.ZoomInButton;
			if (zoomInButton != null)
			{
				zoomInButton.OnDestroy();
			}
			LongPressButton zoomOutButton = this.ZoomOutButton;
			if (zoomOutButton != null)
			{
				zoomOutButton.OnDestroy();
			}
			this.UnBindRedDot();
		}

		// Token: 0x0603756B RID: 226667 RVA: 0x00E0AE17 File Offset: 0x00E09017
		public override UUISliderComponent GetScaleSlider()
		{
			return base.GetSlider(1);
		}

		// Token: 0x0603756C RID: 226668 RVA: 0x00E0AE20 File Offset: 0x00E09020
		public override void OnHandleShowParam(object param = null)
		{
			this.OpenParam = (param as PhantomArenaMapEntrancePanelParam);
			if (this.OpenParam == null || this.OpenParam.ChallengeId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.CB, "PhantomArenaMapEntrancePanel:OnHandleShowParam challengeId undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.CB;
			string message = "PhantomArenaMapEntrancePanel:OnHandleShowParam";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", this.OpenParam.ChallengeId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SelectChallenge(this.OpenParam.ChallengeId, this.OpenParam.IsNeedSelect.GetValueOrDefault());
		}

		// Token: 0x0603756D RID: 226669 RVA: 0x00E0AECC File Offset: 0x00E090CC
		private UniTask SelectChallenge(int challengeId, bool isNeedSelect)
		{
			PhantomArenaMapEntrancePanel.<SelectChallenge>d__63 <SelectChallenge>d__;
			<SelectChallenge>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelectChallenge>d__.<>4__this = this;
			<SelectChallenge>d__.challengeId = challengeId;
			<SelectChallenge>d__.isNeedSelect = isNeedSelect;
			<SelectChallenge>d__.<>1__state = -1;
			<SelectChallenge>d__.<>t__builder.Start<PhantomArenaMapEntrancePanel.<SelectChallenge>d__63>(ref <SelectChallenge>d__);
			return <SelectChallenge>d__.<>t__builder.Task;
		}

		// Token: 0x0603756E RID: 226670 RVA: 0x00E0AF1F File Offset: 0x00E0911F
		private void OnZoomOut()
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapZoomBtnInput, -0.1f, EMapScaleSetType.ZoomButton);
		}

		// Token: 0x0603756F RID: 226671 RVA: 0x00E0AF47 File Offset: 0x00E09147
		private void OnZoomIn()
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_slider_tick");
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapZoomBtnInput, 0.1f, EMapScaleSetType.ZoomButton);
		}

		// Token: 0x06037570 RID: 226672 RVA: 0x00E0AF6F File Offset: 0x00E0916F
		[NullableContext(1)]
		public override bool OnClickEmpty(Vector2D clickedPosition)
		{
			if (this.IsSecondaryUiOpening)
			{
				this.CloseSecondaryUi(null, true);
			}
			return true;
		}

		// Token: 0x06037571 RID: 226673 RVA: 0x00E0AF84 File Offset: 0x00E09184
		[NullableContext(1)]
		public override ClickMarkItemRet OnClickMarkItem(MarkItem markItem)
		{
			this.ClickMarkItemRetData.IsExtraUiLogic = true;
			int markId = markItem.MarkId;
			if (markId == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.CB, "markItem.MarkId为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return this.ClickMarkItemRetData;
			}
			PhantomBattleChallenge? phantomBattleChallengeByMarkId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeByMarkId(markId);
			if (phantomBattleChallengeByMarkId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.CB;
				string message = "对应markId的Challenge为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return this.ClickMarkItemRetData;
			}
			this.SelectChallenge(phantomBattleChallengeByMarkId.Value.Id, true);
			return this.ClickMarkItemRetData;
		}

		// Token: 0x06037572 RID: 226674 RVA: 0x00E0B036 File Offset: 0x00E09236
		[NullableContext(1)]
		public override bool OnClickMarks(List<MarkItem> clickedItems, Vector2D clickedPosition)
		{
			this.CloseSecondaryUi(delegate
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_spl_map_click_com");
			}, true);
			return true;
		}

		// Token: 0x06037573 RID: 226675 RVA: 0x00E0B05F File Offset: 0x00E0925F
		private void CloseSecondaryUi(Action onClosed = null, bool playSequence = true)
		{
			if (!this.IsSecondaryUiOpening)
			{
				if (onClosed != null)
				{
					onClosed();
				}
				return;
			}
			PhantomArenaMapEntranceDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel == null)
			{
				return;
			}
			detailPanel.Close(onClosed, playSequence);
		}

		// Token: 0x17008E9D RID: 36509
		// (get) Token: 0x06037574 RID: 226676 RVA: 0x00E0B085 File Offset: 0x00E09285
		private bool IsSecondaryUiOpening
		{
			get
			{
				PhantomArenaMapEntranceDetailPanel detailPanel = this.DetailPanel;
				return detailPanel == null || !detailPanel.IsUiCloseComplete;
			}
		}

		// Token: 0x06037575 RID: 226677 RVA: 0x00E0B09E File Offset: 0x00E0929E
		public override bool GetIsEnableMapScale()
		{
			return !this.IsSecondaryUiOpening;
		}

		// Token: 0x06037576 RID: 226678 RVA: 0x00E0B0A9 File Offset: 0x00E092A9
		public override bool GetIsEnableMapCursorButton()
		{
			return !this.IsSecondaryUiOpening;
		}

		// Token: 0x06037577 RID: 226679 RVA: 0x00E0B0B4 File Offset: 0x00E092B4
		[NullableContext(1)]
		public override bool OnPointerDrag(Vector2D delta)
		{
			if (this.IsSecondaryUiOpening)
			{
				this.CloseSecondaryUi(null, true);
			}
			return true;
		}

		// Token: 0x06037578 RID: 226680 RVA: 0x00E0B0C8 File Offset: 0x00E092C8
		public override float GetDefaultMapScale()
		{
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleMapParam? phantomBattleMapParam = (instance != null) ? instance.GetPhantomBattleMapParamById(this.CurrentMapId) : null;
			return (float)((phantomBattleMapParam != null) ? phantomBattleMapParam.GetValueOrDefault().BigMapDefaultScale : 0);
		}

		// Token: 0x06037579 RID: 226681 RVA: 0x00E0B114 File Offset: 0x00E09314
		public override float GetMaxMapScale()
		{
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleMapParam? phantomBattleMapParam = (instance != null) ? instance.GetPhantomBattleMapParamById(this.CurrentMapId) : null;
			return (float)((phantomBattleMapParam != null) ? phantomBattleMapParam.GetValueOrDefault().BigMapMaxScale : 0);
		}

		// Token: 0x0603757A RID: 226682 RVA: 0x00E0B160 File Offset: 0x00E09360
		public override float GetMinMapScale()
		{
			PhantomArenaConfig instance = ConfigBase<PhantomArenaConfig>.Instance;
			PhantomBattleMapParam? phantomBattleMapParam = (instance != null) ? instance.GetPhantomBattleMapParamById(this.CurrentMapId) : null;
			return (float)((phantomBattleMapParam != null) ? phantomBattleMapParam.GetValueOrDefault().BigMapMinScale : 0);
		}

		// Token: 0x0603757B RID: 226683 RVA: 0x00E0B1A9 File Offset: 0x00E093A9
		[NullableContext(1)]
		public override EMarkType[] GetExtraMarkTypes()
		{
			return new EMarkType[]
			{
				EMarkType.PhantomArenaNpc,
				EMarkType.AreaMark
			};
		}

		// Token: 0x0603757C RID: 226684 RVA: 0x00E0B1BC File Offset: 0x00E093BC
		public override void SetOpenParam(object openParam)
		{
			this.OpenParam = openParam;
			int challengeId = ((PhantomArenaMapEntrancePanelParam)openParam).ChallengeId;
			this.CurrentMapId = this.GetMapIdByChallengeId(challengeId);
		}

		// Token: 0x0401FC8C RID: 130188
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401FC8D RID: 130189
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<PhantomArenaMapEntranceNpcListItem, int> NpcListView;

		// Token: 0x0401FC8E RID: 130190
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<PhantomArenaMapEntranceDifficultItem, int> DifficultTabLayout;

		// Token: 0x0401FC8F RID: 130191
		private PhantomArenaMapEntranceDetailPanel DetailPanel;

		// Token: 0x0401FC90 RID: 130192
		private UiSequencePlayer NpcListSequencePlayer;

		// Token: 0x0401FC91 RID: 130193
		private LongPressButton ZoomInButton;

		// Token: 0x0401FC92 RID: 130194
		private LongPressButton ZoomOutButton;

		// Token: 0x0401FC93 RID: 130195
		private int CurrentSelectedDifficult = -1;

		// Token: 0x0401FC94 RID: 130196
		private int TargetChallengeId;

		// Token: 0x0401FC95 RID: 130197
		private int CurrentSelectedChallengeId;

		// Token: 0x0401FC96 RID: 130198
		private bool IsShowNpcList;

		// Token: 0x0401FC97 RID: 130199
		private UiSequencePlayer RewardBtnSequencePlayer;

		// Token: 0x0401FC98 RID: 130200
		private UiSequencePlayer RightBtnRootSequencePlayer;

		// Token: 0x0401FC99 RID: 130201
		private CommonDropDown<int, int> DropDown;

		// Token: 0x0401FC9A RID: 130202
		[Nullable(1)]
		private readonly List<int> MapIdList = new List<int>();

		// Token: 0x0401FC9B RID: 130203
		private int CurrentMapId;

		// Token: 0x0200B449 RID: 46153
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04037CBB RID: 228539
			public const int CaptionItem = 0;

			// Token: 0x04037CBC RID: 228540
			public const int ScaleSlider = 1;

			// Token: 0x04037CBD RID: 228541
			public const int ZoomIn = 2;

			// Token: 0x04037CBE RID: 228542
			public const int ZoomOut = 3;

			// Token: 0x04037CBF RID: 228543
			public const int PnlInfo = 4;

			// Token: 0x04037CC0 RID: 228544
			public const int ToggleNpcList = 5;

			// Token: 0x04037CC1 RID: 228545
			public const int TextLv = 6;

			// Token: 0x04037CC2 RID: 228546
			public const int TextExp = 7;

			// Token: 0x04037CC3 RID: 228547
			public const int TextTitle = 8;

			// Token: 0x04037CC4 RID: 228548
			public const int BtnReward = 9;

			// Token: 0x04037CC5 RID: 228549
			public const int TextRewardProgress = 10;

			// Token: 0x04037CC6 RID: 228550
			public const int BtnMenuCard = 11;

			// Token: 0x04037CC7 RID: 228551
			public const int BtnMenuRole = 12;

			// Token: 0x04037CC8 RID: 228552
			public const int BtnMenuCollect = 13;

			// Token: 0x04037CC9 RID: 228553
			public const int TextRewardNum = 14;

			// Token: 0x04037CCA RID: 228554
			public const int SpriteExp = 15;

			// Token: 0x04037CCB RID: 228555
			public const int RewardBtnRoot = 16;

			// Token: 0x04037CCC RID: 228556
			public const int PnlNpcList = 17;

			// Token: 0x04037CCD RID: 228557
			public const int DifficultTabList = 18;

			// Token: 0x04037CCE RID: 228558
			public const int DifficultTabItem = 19;

			// Token: 0x04037CCF RID: 228559
			public const int NpcList = 20;

			// Token: 0x04037CD0 RID: 228560
			public const int NpcListItem = 21;

			// Token: 0x04037CD1 RID: 228561
			public const int ItemRedDotCard = 22;

			// Token: 0x04037CD2 RID: 228562
			public const int ItemRedDotRole = 23;

			// Token: 0x04037CD3 RID: 228563
			public const int ItemRedDotCollect = 24;

			// Token: 0x04037CD4 RID: 228564
			public const int RightButtonsRoot = 25;

			// Token: 0x04037CD5 RID: 228565
			public const int ChallengeProgress = 26;

			// Token: 0x04037CD6 RID: 228566
			public const int ItemRedDotTask = 27;

			// Token: 0x04037CD7 RID: 228567
			public const int HomeBtnRoot = 28;

			// Token: 0x04037CD8 RID: 228568
			public const int DropDownItem = 29;

			// Token: 0x04037CD9 RID: 228569
			public const int DropDownRedDot = 30;
		}
	}
}
