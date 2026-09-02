using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200595B RID: 22875
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueGridEventView : UiViewBase
	{
		// Token: 0x06039FA8 RID: 237480 RVA: 0x00EAC072 File Offset: 0x00EAA272
		public MapRogueGridEventView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06039FA9 RID: 237481 RVA: 0x00EAC090 File Offset: 0x00EAA290
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.SetVisible)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnMaskBtnClick)),
				new ValueTuple<int, Delegate>(9, new Action(this.SetAuto))
			};
		}

		// Token: 0x06039FAA RID: 237482 RVA: 0x00EAC238 File Offset: 0x00EAA438
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueGridEventView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueGridEventView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039FAB RID: 237483 RVA: 0x00EAC27B File Offset: 0x00EAA47B
		protected override void OnBeforeShow()
		{
			this.RefreshLv(false);
			this.RefreshMood(false);
		}

		// Token: 0x06039FAC RID: 237484 RVA: 0x00EAC28C File Offset: 0x00EAA48C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RogueResTeamLvChange, new Action<int>(this.OnRogueResTeamLvChange));
			Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RogueResMoodChange, new Action<int, int, int>(this.OnRogueResMoodChange));
		}

		// Token: 0x06039FAD RID: 237485 RVA: 0x00EAC2F0 File Offset: 0x00EAA4F0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResTeamLvChange, new Action<int>(this.OnRogueResTeamLvChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMoodChange, new Action<int, int, int>(this.OnRogueResMoodChange));
		}

		// Token: 0x06039FAE RID: 237486 RVA: 0x00EAC351 File Offset: 0x00EAA551
		protected override void OnBeforeDestroy()
		{
			if (this.OpData != null)
			{
				this.OpData.EventStepUpdateFunc = null;
				this.OpData = null;
			}
			this.StepItemList.Clear();
		}

		// Token: 0x06039FAF RID: 237487 RVA: 0x00EAC37C File Offset: 0x00EAA57C
		private UniTask InitCaption()
		{
			MapRogueGridEventView.<InitCaption>d__20 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<MapRogueGridEventView.<InitCaption>d__20>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06039FB0 RID: 237488 RVA: 0x00EAC3BF File Offset: 0x00EAA5BF
		private void SetVisible()
		{
			this.VisibleState = !this.VisibleState;
			base.GetItem(7).SetUIActive(this.VisibleState);
			base.GetItem(1).SetUIActive(this.VisibleState);
		}

		// Token: 0x06039FB1 RID: 237489 RVA: 0x00EAC3F4 File Offset: 0x00EAA5F4
		private void SetAuto()
		{
			IEventStepItem currentStepItem = this.GetCurrentStepItem();
			if (currentStepItem == null || currentStepItem.StepType != EStepType.Desc)
			{
				return;
			}
			this.AutoState = true;
			if (this.ViewState == EViewState.Anim)
			{
				this.OnMaskBtnClick();
				this.OnMaskBtnClick();
				return;
			}
			if (this.ViewState == EViewState.CanInteract)
			{
				this.OnMaskBtnClick();
			}
		}

		// Token: 0x06039FB2 RID: 237490 RVA: 0x00EAC441 File Offset: 0x00EAA641
		private void OnBackBtnClick()
		{
			if (this.ViewState == EViewState.Forbidden)
			{
				return;
			}
			ControllerBase<MapRogueController>.Instance.OpenExploreEnd(false);
		}

		// Token: 0x06039FB3 RID: 237491 RVA: 0x00EAC458 File Offset: 0x00EAA658
		private void UpdateBg(int newBgId, bool needAnim)
		{
			if (newBgId == 0)
			{
				return;
			}
			if (this.CurrentBgId == newBgId)
			{
				return;
			}
			this.CurrentBgId = newBgId;
			if (!needAnim)
			{
				this.RefreshBg();
				return;
			}
			if (!this.UiViewSequence.HasSequenceNameInPlaying("Switch"))
			{
				this.UiViewSequence.PlaySequence("Switch", false, null);
				return;
			}
			this.RefreshBg();
		}

		// Token: 0x06039FB4 RID: 237492 RVA: 0x00EAC4B8 File Offset: 0x00EAA6B8
		private void RefreshLv(bool needAnim)
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo != null)
			{
				this.PanelLv.SetLv(gameInfo.TeamLv, needAnim);
			}
		}

		// Token: 0x06039FB5 RID: 237493 RVA: 0x00EAC4E8 File Offset: 0x00EAA6E8
		private void RefreshMood(bool needAnim)
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			this.MoodBar.SetLimit(gameInfo.MoodMin, gameInfo.MoodMax);
			if (!needAnim)
			{
				this.TempMood = gameInfo.Mood;
				this.MoodBar.SetCurrentValue(gameInfo.Mood);
				return;
			}
			int changeValue = gameInfo.Mood - this.TempMood;
			this.MoodBar.ShowPreviewValue(changeValue, gameInfo.Mood);
			this.TempMood = gameInfo.Mood;
		}

		// Token: 0x06039FB6 RID: 237494 RVA: 0x00EAC568 File Offset: 0x00EAA768
		private void OnActivitySequenceEmitEvent(string eventName)
		{
			if (eventName != "Change")
			{
				return;
			}
			this.RefreshBg();
		}

		// Token: 0x06039FB7 RID: 237495 RVA: 0x00EAC57E File Offset: 0x00EAA77E
		private void OnRogueResTeamLvChange(int lv)
		{
			this.RefreshLv(true);
		}

		// Token: 0x06039FB8 RID: 237496 RVA: 0x00EAC587 File Offset: 0x00EAA787
		private void OnRogueResMoodChange(int curMood, int minMood, int maxMood)
		{
			this.RefreshMood(true);
		}

		// Token: 0x06039FB9 RID: 237497 RVA: 0x00EAC590 File Offset: 0x00EAA790
		private void RefreshBg()
		{
			RogueResEventBg? eventBgById = ConfigBase<MapRogueConfig>.Instance.GetEventBgById(this.CurrentBgId);
			if (eventBgById == null)
			{
				return;
			}
			UUITexture texBg = base.GetTexture(0);
			UUIItem item = base.GetItem(11);
			USpineSkeletonAnimationComponent spine = base.GetSpine(10);
			bool flag = !StringUtils.IsEmpty(eventBgById.Value.BgPath) || !StringUtils.IsEmpty(eventBgById.Value.BgFemalePath);
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (flag)
			{
				string path = (playerGender == EPlayerGender.Female) ? eventBgById.Value.BgFemalePath : eventBgById.Value.BgPath;
				base.SetTextureByPath(path, texBg, null, delegate(bool _)
				{
					texBg.SetSizeFromTexture();
				});
			}
			else
			{
				string atlasPath = (playerGender == EPlayerGender.Female) ? eventBgById.Value.BgSpineAtlasFemalePath : eventBgById.Value.BgSpineAtlasPath;
				string skeletonPath = (playerGender == EPlayerGender.Female) ? eventBgById.Value.BgSpineSkeletonFemalePath : eventBgById.Value.BgSpineSkeletonPath;
				base.SetSpineAssetByPath(atlasPath, skeletonPath, spine);
				spine.SetAnimation(0, "idle", true);
			}
			texBg.SetUIActive(flag);
			item.SetUIActive(!flag);
		}

		// Token: 0x06039FBA RID: 237498 RVA: 0x00EAC6EC File Offset: 0x00EAA8EC
		private void UpdateBgm(int newBgmId)
		{
			if (newBgmId == 0)
			{
				return;
			}
			if (this.CurrentBgmId == newBgmId)
			{
				return;
			}
			this.CurrentBgmId = newBgmId;
			RogueResEventBgm? eventBgmById = ConfigBase<MapRogueConfig>.Instance.GetEventBgmById(newBgmId);
			if (eventBgmById == null)
			{
				return;
			}
			string bgmPath = eventBgmById.Value.BgmPath;
			Singleton<AudioSystem>.Instance.PostEvent(bgmPath);
		}

		// Token: 0x17009462 RID: 37986
		// (get) Token: 0x06039FBC RID: 237500 RVA: 0x00EAC753 File Offset: 0x00EAA953
		// (set) Token: 0x06039FBB RID: 237499 RVA: 0x00EAC740 File Offset: 0x00EAA940
		protected EViewState ViewState
		{
			get
			{
				return this.ViewStateInternal;
			}
			set
			{
				if (this.ViewStateInternal == value)
				{
					return;
				}
				this.ViewStateInternal = value;
			}
		}

		// Token: 0x06039FBD RID: 237501 RVA: 0x00EAC75B File Offset: 0x00EAA95B
		[NullableContext(2)]
		private bool OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			this.IsDragging = true;
			return true;
		}

		// Token: 0x06039FBE RID: 237502 RVA: 0x00EAC765 File Offset: 0x00EAA965
		[NullableContext(2)]
		private bool OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
		{
			this.IsDragging = false;
			return true;
		}

		// Token: 0x06039FBF RID: 237503 RVA: 0x00EAC770 File Offset: 0x00EAA970
		private void OnMaskBtnClick()
		{
			if (this.IsDragging)
			{
				return;
			}
			IEventStepItem currentStepItem = this.GetCurrentStepItem();
			if (currentStepItem == null)
			{
				return;
			}
			switch (currentStepItem.StepType)
			{
			case EStepType.Desc:
				if (this.ViewState == EViewState.Anim)
				{
					currentStepItem.MaskClick();
					return;
				}
				if (this.ViewState == EViewState.CanInteract)
				{
					base.GetItem(5).SetUIActive(false);
					base.GetItem(6).SetUIActive(false);
					base.GetButton(8).RootUIComp.Get().SetUIActive(false);
					this.ExecuteStep(currentStepItem.StepId, 0);
					return;
				}
				break;
			case EStepType.Choose:
			case EStepType.ChooseEffect:
				break;
			case EStepType.Ending:
				if (this.ViewState == EViewState.CanInteract)
				{
					base.GetButton(8).RootUIComp.Get().SetUIActive(false);
					this.ExecuteStep(currentStepItem.StepId, 0);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06039FC0 RID: 237504 RVA: 0x00EAC83C File Offset: 0x00EAAA3C
		private UUIItem GetParentItem()
		{
			return base.GetVerticalLayout(3).RootUIComp.Get();
		}

		// Token: 0x06039FC1 RID: 237505 RVA: 0x00EAC860 File Offset: 0x00EAAA60
		[NullableContext(2)]
		private IEventStepItem GetCurrentStepItem()
		{
			int count = this.StepItemList.Count;
			if (count > 0)
			{
				return this.StepItemList[count - 1];
			}
			return null;
		}

		// Token: 0x06039FC2 RID: 237506 RVA: 0x00EAC890 File Offset: 0x00EAAA90
		private void ScrollToBottom(UUIItem item)
		{
			MapRogueGridEventView.<>c__DisplayClass41_0 CS$<>8__locals1 = new MapRogueGridEventView.<>c__DisplayClass41_0();
			CS$<>8__locals1.item = item;
			CS$<>8__locals1.scrollView = base.GetScrollViewWithScrollbar(2);
			MapRogueGridEventView.<>c__DisplayClass41_0 CS$<>8__locals2 = CS$<>8__locals1;
			FVector relativeLocation = CS$<>8__locals1.scrollView.ContentUIItem.Get().RelativeLocation;
			CS$<>8__locals2.pos = new FVector2D(ref relativeLocation);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				CS$<>8__locals1.scrollView.ScrollToBottom(ref CS$<>8__locals1.pos, CS$<>8__locals1.item, false);
			}, 100f, null, null, true, 1f);
		}

		// Token: 0x06039FC3 RID: 237507 RVA: 0x00EAC904 File Offset: 0x00EAAB04
		protected UniTask CreateComponentChoice(int stepId, IList<EventOption> options)
		{
			MapRogueGridEventView.<CreateComponentChoice>d__42 <CreateComponentChoice>d__;
			<CreateComponentChoice>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateComponentChoice>d__.<>4__this = this;
			<CreateComponentChoice>d__.stepId = stepId;
			<CreateComponentChoice>d__.options = options;
			<CreateComponentChoice>d__.<>1__state = -1;
			<CreateComponentChoice>d__.<>t__builder.Start<MapRogueGridEventView.<CreateComponentChoice>d__42>(ref <CreateComponentChoice>d__);
			return <CreateComponentChoice>d__.<>t__builder.Task;
		}

		// Token: 0x06039FC4 RID: 237508 RVA: 0x00EAC958 File Offset: 0x00EAAB58
		protected UniTask CreateComponentDesc(int stepId)
		{
			MapRogueGridEventView.<CreateComponentDesc>d__43 <CreateComponentDesc>d__;
			<CreateComponentDesc>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateComponentDesc>d__.<>4__this = this;
			<CreateComponentDesc>d__.stepId = stepId;
			<CreateComponentDesc>d__.<>1__state = -1;
			<CreateComponentDesc>d__.<>t__builder.Start<MapRogueGridEventView.<CreateComponentDesc>d__43>(ref <CreateComponentDesc>d__);
			return <CreateComponentDesc>d__.<>t__builder.Task;
		}

		// Token: 0x06039FC5 RID: 237509 RVA: 0x00EAC9A4 File Offset: 0x00EAABA4
		protected UniTask CreateComponentEnding(int stepId)
		{
			MapRogueGridEventView.<CreateComponentEnding>d__44 <CreateComponentEnding>d__;
			<CreateComponentEnding>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateComponentEnding>d__.<>4__this = this;
			<CreateComponentEnding>d__.stepId = stepId;
			<CreateComponentEnding>d__.<>1__state = -1;
			<CreateComponentEnding>d__.<>t__builder.Start<MapRogueGridEventView.<CreateComponentEnding>d__44>(ref <CreateComponentEnding>d__);
			return <CreateComponentEnding>d__.<>t__builder.Task;
		}

		// Token: 0x06039FC6 RID: 237510 RVA: 0x00EAC9F0 File Offset: 0x00EAABF0
		private void CanInteractCallback(int stepId, EStepType type)
		{
			switch (type)
			{
			case EStepType.Desc:
				base.GetItem(5).SetUIActive(false);
				base.GetItem(6).SetUIActive(true);
				break;
			case EStepType.Choose:
				base.GetButton(8).RootUIComp.Get().SetUIActive(false);
				break;
			case EStepType.Ending:
				base.GetButton(8).RootUIComp.Get().SetUIActive(false);
				break;
			}
			this.ViewState = EViewState.CanInteract;
		}

		// Token: 0x06039FC7 RID: 237511 RVA: 0x00EACA70 File Offset: 0x00EAAC70
		private void ExecuteStep(int stepId, int optionId)
		{
			MapRogueOpGridEvent opData = this.OpData;
			if (opData == null)
			{
				return;
			}
			opData.ExecuteStep(stepId, optionId);
		}

		// Token: 0x06039FC8 RID: 237512 RVA: 0x00EACA84 File Offset: 0x00EAAC84
		private void OnGridEventStepUpdate(int stepId)
		{
			this.UpdateBg(this.OpData.CurrentPlotBgId, true);
			this.UpdateBgm(this.OpData.CurrentPlotBgmId);
			this.StepStart(stepId);
		}

		// Token: 0x06039FC9 RID: 237513 RVA: 0x00EACAB4 File Offset: 0x00EAACB4
		private UniTask StepStart(int stepId)
		{
			MapRogueGridEventView.<StepStart>d__48 <StepStart>d__;
			<StepStart>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StepStart>d__.<>4__this = this;
			<StepStart>d__.stepId = stepId;
			<StepStart>d__.<>1__state = -1;
			<StepStart>d__.<>t__builder.Start<MapRogueGridEventView.<StepStart>d__48>(ref <StepStart>d__);
			return <StepStart>d__.<>t__builder.Task;
		}

		// Token: 0x04020DC9 RID: 134601
		private const string SPINE_DEFAULT_ANIM_NAME = "idle";

		// Token: 0x04020DCA RID: 134602
		private int TempMood;

		// Token: 0x04020DCB RID: 134603
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04020DCC RID: 134604
		[Nullable(2)]
		private MapRoguePanelLv PanelLv;

		// Token: 0x04020DCD RID: 134605
		[Nullable(2)]
		private MapRogueMoodBar MoodBar;

		// Token: 0x04020DCE RID: 134606
		private readonly List<IEventStepItem> StepItemList = new List<IEventStepItem>();

		// Token: 0x04020DCF RID: 134607
		private EViewState ViewStateInternal;

		// Token: 0x04020DD0 RID: 134608
		private bool VisibleState = true;

		// Token: 0x04020DD1 RID: 134609
		protected bool AutoState;

		// Token: 0x04020DD2 RID: 134610
		private int OpIncId;

		// Token: 0x04020DD3 RID: 134611
		[Nullable(2)]
		protected MapRogueOpGridEvent OpData;

		// Token: 0x04020DD4 RID: 134612
		protected int CurrentBgId;

		// Token: 0x04020DD5 RID: 134613
		protected int CurrentBgmId;

		// Token: 0x04020DD6 RID: 134614
		private bool IsDragging;
	}
}
