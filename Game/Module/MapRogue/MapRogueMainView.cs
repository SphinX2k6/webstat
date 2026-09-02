using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200597C RID: 22908
	[NullableContext(2)]
	[Nullable(0)]
	public class MapRogueMainView : UiTickViewBase
	{
		// Token: 0x0603A062 RID: 237666 RVA: 0x00EAF654 File Offset: 0x00EAD854
		[NullableContext(1)]
		public MapRogueMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A063 RID: 237667 RVA: 0x00EAF688 File Offset: 0x00EAD888
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnProgressBtnClick))
			};
		}

		// Token: 0x0603A064 RID: 237668 RVA: 0x00EAF7A4 File Offset: 0x00EAD9A4
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueMainView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueMainView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A065 RID: 237669 RVA: 0x00EAF7E8 File Offset: 0x00EAD9E8
		protected override void OnStart()
		{
			RogueResInstGrid? insGridConfigByInstId = ConfigBase<MapRogueConfig>.Instance.GetInsGridConfigByInstId(this.GameInfo.InstanceId);
			if (insGridConfigByInstId == null)
			{
				return;
			}
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, insGridConfigByInstId.Value.Title, Array.Empty<object>());
			this.MoodBar.SetLimit(this.GameInfo.MoodMin, this.GameInfo.MoodMax);
			this.MoodBar.SetCurrentValue(this.GameInfo.Mood);
			this.MapModule.SetRolePos(this.GameInfo.PlayerGridIndex);
			this.MapModule.SetInteractState(false, false, null);
			this.RefreshProgress();
			this.MapMusicState.State = insGridConfigByInstId.Value.MapMusicState;
			this.RefreshTeamLv();
			this.RefreshMoodMusicState();
			this.GameInfo.BindView(this);
			this.GameInfo.SetInteractAvailable(EMapForbiddenTag.AsyncUi, false);
			if (ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.OpenMapViewBlackScreen && !ModelBase<LoadingModel>.Instance.IsLoading)
			{
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "MapRogueMainView.Create");
			}
			CustomPromise viewOpenPromise = this.GameInfo.ViewOpenPromise;
			if (viewOpenPromise == null)
			{
				return;
			}
			viewOpenPromise.SetResult();
		}

		// Token: 0x0603A066 RID: 237670 RVA: 0x00EAF937 File Offset: 0x00EADB37
		protected override void OnAfterShow()
		{
			this.MapModule.MapShow();
			CustomPromise viewShowPromise = this.GameInfo.ViewShowPromise;
			if (viewShowPromise != null)
			{
				viewShowPromise.SetResult();
			}
			this.GameInfo.SetInteractAvailable(EMapForbiddenTag.AsyncUi, true);
		}

		// Token: 0x0603A067 RID: 237671 RVA: 0x00EAF968 File Offset: 0x00EADB68
		protected override UniTask OnBeforeHideAsync()
		{
			MapRogueMainView.<OnBeforeHideAsync>d__14 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<MapRogueMainView.<OnBeforeHideAsync>d__14>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A068 RID: 237672 RVA: 0x00EAF9AB File Offset: 0x00EADBAB
		protected override void OnBeforeHide()
		{
			this.GameInfo.ViewShowPromise = new CustomPromise();
			this.MapModule.MapHide();
		}

		// Token: 0x0603A069 RID: 237673 RVA: 0x00EAF9C8 File Offset: 0x00EADBC8
		protected override void OnBeforeDestroy()
		{
			MapRogueActorPool actorPool = this.GameInfo.ActorPool;
			if (actorPool != null)
			{
				actorPool.CancelLoad();
			}
			MapRogueGameInfo gameInfo = this.GameInfo;
			if (gameInfo != null)
			{
				gameInfo.BindView(null);
			}
			this.MapMusicState.State = "none";
			this.MapMoodMusicState.State = "none";
			this.PopViewCacheForGuide = null;
		}

		// Token: 0x0603A06A RID: 237674 RVA: 0x00EAFA24 File Offset: 0x00EADC24
		protected override void OnAfterDestroy()
		{
			MapRogueGameInfo gameInfo = this.GameInfo;
			if (gameInfo != null && gameInfo.EnterBattleFlag)
			{
				this.GameInfo.EnterBattleFlag = false;
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "MapRogueMainView.BattleClose");
			}
		}

		// Token: 0x0603A06B RID: 237675 RVA: 0x00EAFA5A File Offset: 0x00EADC5A
		protected override void OnTick(float delta)
		{
			this.GameInfo.OnTick(delta);
			MapRogueMapModule mapModule = this.MapModule;
			if (mapModule == null)
			{
				return;
			}
			mapModule.OnTick(delta);
		}

		// Token: 0x0603A06C RID: 237676 RVA: 0x00EAFA79 File Offset: 0x00EADC79
		public void ChangeGameStagePerformance(EMapRogueGameStage lastStage, EMapRogueGameStage curStage)
		{
		}

		// Token: 0x0603A06D RID: 237677 RVA: 0x00EAFA7C File Offset: 0x00EADC7C
		private UniTask InitMapModule()
		{
			MapRogueMainView.<InitMapModule>d__20 <InitMapModule>d__;
			<InitMapModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMapModule>d__.<>4__this = this;
			<InitMapModule>d__.<>1__state = -1;
			<InitMapModule>d__.<>t__builder.Start<MapRogueMainView.<InitMapModule>d__20>(ref <InitMapModule>d__);
			return <InitMapModule>d__.<>t__builder.Task;
		}

		// Token: 0x0603A06E RID: 237678 RVA: 0x00EAFAC0 File Offset: 0x00EADCC0
		private UniTask InitCaption()
		{
			MapRogueMainView.<InitCaption>d__21 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<MapRogueMainView.<InitCaption>d__21>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x0603A06F RID: 237679 RVA: 0x00EAFB04 File Offset: 0x00EADD04
		private UniTask InitPanelLv()
		{
			MapRogueMainView.<InitPanelLv>d__22 <InitPanelLv>d__;
			<InitPanelLv>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPanelLv>d__.<>4__this = this;
			<InitPanelLv>d__.<>1__state = -1;
			<InitPanelLv>d__.<>t__builder.Start<MapRogueMainView.<InitPanelLv>d__22>(ref <InitPanelLv>d__);
			return <InitPanelLv>d__.<>t__builder.Task;
		}

		// Token: 0x0603A070 RID: 237680 RVA: 0x00EAFB48 File Offset: 0x00EADD48
		private UniTask InitPanelFetter()
		{
			MapRogueMainView.<InitPanelFetter>d__23 <InitPanelFetter>d__;
			<InitPanelFetter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPanelFetter>d__.<>4__this = this;
			<InitPanelFetter>d__.<>1__state = -1;
			<InitPanelFetter>d__.<>t__builder.Start<MapRogueMainView.<InitPanelFetter>d__23>(ref <InitPanelFetter>d__);
			return <InitPanelFetter>d__.<>t__builder.Task;
		}

		// Token: 0x0603A071 RID: 237681 RVA: 0x00EAFB8C File Offset: 0x00EADD8C
		private UniTask InitMoodBar()
		{
			MapRogueMainView.<InitMoodBar>d__24 <InitMoodBar>d__;
			<InitMoodBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMoodBar>d__.<>4__this = this;
			<InitMoodBar>d__.<>1__state = -1;
			<InitMoodBar>d__.<>t__builder.Start<MapRogueMainView.<InitMoodBar>d__24>(ref <InitMoodBar>d__);
			return <InitMoodBar>d__.<>t__builder.Task;
		}

		// Token: 0x0603A072 RID: 237682 RVA: 0x00EAFBD0 File Offset: 0x00EADDD0
		private UniTask InitTipsItem()
		{
			MapRogueMainView.<InitTipsItem>d__25 <InitTipsItem>d__;
			<InitTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTipsItem>d__.<>4__this = this;
			<InitTipsItem>d__.<>1__state = -1;
			<InitTipsItem>d__.<>t__builder.Start<MapRogueMainView.<InitTipsItem>d__25>(ref <InitTipsItem>d__);
			return <InitTipsItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603A073 RID: 237683 RVA: 0x00EAFC13 File Offset: 0x00EADE13
		private bool CheckCanOpenMenu()
		{
			return this.GameInfo.CanInteract;
		}

		// Token: 0x0603A074 RID: 237684 RVA: 0x00EAFC20 File Offset: 0x00EADE20
		private void OnBackBtnClick()
		{
			ControllerBase<MapRogueController>.Instance.OpenExploreEnd(false);
		}

		// Token: 0x0603A075 RID: 237685 RVA: 0x00EAFC2D File Offset: 0x00EADE2D
		private void OnHelpBtnClick()
		{
			ControllerBase<MapRogueController>.Instance.OpenMapHelpView();
		}

		// Token: 0x0603A076 RID: 237686 RVA: 0x00EAFC39 File Offset: 0x00EADE39
		private void OnProgressBtnClick()
		{
			ControllerBase<MapRogueController>.Instance.OpenExplore();
		}

		// Token: 0x0603A077 RID: 237687 RVA: 0x00EAFC48 File Offset: 0x00EADE48
		public void RefreshProgress()
		{
			int num = this.GameInfo.ExplorationCurrentProgress();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RogueResExplore_3", new <>z__ReadOnlySingleElementList<object>(num));
		}

		// Token: 0x0603A078 RID: 237688 RVA: 0x00EAFC84 File Offset: 0x00EADE84
		public void SetInteractAvailable(bool bAvailable)
		{
			MapRogueMapModule mapModule = this.MapModule;
			if (mapModule != null)
			{
				mapModule.SetInteractAvailable(bAvailable);
			}
			MapRogueMapModule mapModule2 = this.MapModule;
			if (mapModule2 == null)
			{
				return;
			}
			mapModule2.SetInteractState(false, false, null);
		}

		// Token: 0x0603A079 RID: 237689 RVA: 0x00EAFCBE File Offset: 0x00EADEBE
		public void RefreshTeamLv()
		{
			MapRoguePanelLv panelLv = this.PanelLv;
			if (panelLv == null)
			{
				return;
			}
			panelLv.SetLv(this.GameInfo.TeamLv, false);
		}

		// Token: 0x0603A07A RID: 237690 RVA: 0x00EAFCDC File Offset: 0x00EADEDC
		public void SetTipsItem(bool bVisible, string textId = null)
		{
			if (textId != null)
			{
				MapRogueFloatTipsItem tipsItem = this.TipsItem;
				if (tipsItem != null)
				{
					tipsItem.SetText(textId);
				}
			}
			MapRogueFloatTipsItem tipsItem2 = this.TipsItem;
			if (tipsItem2 == null)
			{
				return;
			}
			tipsItem2.SetActive(bVisible);
		}

		// Token: 0x0603A07B RID: 237691 RVA: 0x00EAFD04 File Offset: 0x00EADF04
		[NullableContext(1)]
		public UniTask OpenPopupView(MapGridData gridData)
		{
			MapRogueMainView.<OpenPopupView>d__34 <OpenPopupView>d__;
			<OpenPopupView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenPopupView>d__.<>4__this = this;
			<OpenPopupView>d__.gridData = gridData;
			<OpenPopupView>d__.<>1__state = -1;
			<OpenPopupView>d__.<>t__builder.Start<MapRogueMainView.<OpenPopupView>d__34>(ref <OpenPopupView>d__);
			return <OpenPopupView>d__.<>t__builder.Task;
		}

		// Token: 0x0603A07C RID: 237692 RVA: 0x00EAFD50 File Offset: 0x00EADF50
		public void RefreshMoodMusicState()
		{
			RogueResMoodRule? moodRuleById = ConfigBase<MapRogueConfig>.Instance.GetMoodRuleById(this.GameInfo.MoodRuleId);
			if (moodRuleById != null && !StringUtils.IsEmpty(moodRuleById.Value.MapMusicStateSwitch))
			{
				this.MapMoodMusicState.State = moodRuleById.Value.MapMusicStateSwitch;
			}
		}

		// Token: 0x0603A07D RID: 237693 RVA: 0x00EAFDAC File Offset: 0x00EADFAC
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "Mood")
			{
				MapRogueMoodBar moodBar = this.MoodBar;
				if (moodBar == null)
				{
					return null;
				}
				return moodBar.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else if (a == "MapRougeGrid")
			{
				MapRogueMapModule mapModule = this.MapModule;
				if (mapModule == null)
				{
					return null;
				}
				return mapModule.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				GridPopupView popViewCacheForGuide = this.PopViewCacheForGuide;
				if (popViewCacheForGuide == null)
				{
					return null;
				}
				return popViewCacheForGuide.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x04020E7E RID: 134782
		public MapRogueMapModule MapModule;

		// Token: 0x04020E7F RID: 134783
		public MapRogueMoodBar MoodBar;

		// Token: 0x04020E80 RID: 134784
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04020E81 RID: 134785
		protected MapRoguePanelLv PanelLv;

		// Token: 0x04020E82 RID: 134786
		protected MapRoguePanelFetter PanelFetter;

		// Token: 0x04020E83 RID: 134787
		protected MapRogueFloatTipsItem TipsItem;

		// Token: 0x04020E84 RID: 134788
		[Nullable(1)]
		protected MapRogueGameInfo GameInfo;

		// Token: 0x04020E85 RID: 134789
		private GridPopupView PopViewCacheForGuide;

		// Token: 0x04020E86 RID: 134790
		[Nullable(1)]
		private const string STATE_NONE = "none";

		// Token: 0x04020E87 RID: 134791
		[Nullable(1)]
		private readonly StateRef MapMusicState = new StateRef("game_maprogue_map_type", "none");

		// Token: 0x04020E88 RID: 134792
		[Nullable(1)]
		private readonly StateRef MapMoodMusicState = new StateRef("game_maprogue_map_vibe", "none");
	}
}
