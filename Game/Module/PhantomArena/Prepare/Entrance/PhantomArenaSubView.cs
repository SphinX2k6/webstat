using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054E2 RID: 21730
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaSubView : ActivitySubViewBase
	{
		// Token: 0x060375DC RID: 226780 RVA: 0x00E0D1F8 File Offset: 0x00E0B3F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(USpineSkeletonAnimationComponent))
			};
		}

		// Token: 0x060375DD RID: 226781 RVA: 0x00E0D2AC File Offset: 0x00E0B4AC
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060375DE RID: 226782 RVA: 0x00E0D2F0 File Offset: 0x00E0B4F0
		protected override void OnBeforeShow()
		{
			string animationName = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "IdleF" : "IdleM";
			base.GetSpine(6).SetAnimation(0, animationName, true);
			this.RefreshInfo();
			this.BindRedDot();
		}

		// Token: 0x060375DF RID: 226783 RVA: 0x00E0D338 File Offset: 0x00E0B538
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnEventRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.ActivityCrossDayRefresh, new Action(this.CrossDayRefresh));
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnEventQuestChange));
		}

		// Token: 0x060375E0 RID: 226784 RVA: 0x00E0D39C File Offset: 0x00E0B59C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnEventRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityCrossDayRefresh, new Action(this.CrossDayRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnEventQuestChange));
		}

		// Token: 0x060375E1 RID: 226785 RVA: 0x00E0D3FD File Offset: 0x00E0B5FD
		protected override void OnRefreshView()
		{
			this.RefreshInfo();
			this.BindRedDot();
		}

		// Token: 0x060375E2 RID: 226786 RVA: 0x00E0D40C File Offset: 0x00E0B60C
		private void RefreshInfo()
		{
			this.InfoComponent.SetBtnText("PhantomBattle_1103", Array.Empty<object>());
			ActivitySubViewGeneralInfo infoComponent = this.InfoComponent;
			if (infoComponent != null)
			{
				infoComponent.RefreshFunction();
			}
			ValueTuple<bool, string> valueTuple = ModelBase<PhantomArenaModel>.Instance.IsInLimitTime(this.ActivityBaseData.Id, null);
			bool item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			ButtonItem btnLimit = this.BtnLimit;
			if (btnLimit != null)
			{
				btnLimit.SetUiActive(item);
			}
			if (item)
			{
				ButtonItem btnLimit2 = this.BtnLimit;
				if (btnLimit2 != null)
				{
					btnLimit2.SetText(item2);
				}
			}
			this.RefreshRecommend();
			this.RefreshLevel();
		}

		// Token: 0x060375E3 RID: 226787 RVA: 0x00E0D498 File Offset: 0x00E0B698
		private void RefreshRecommend()
		{
			PhantomArenaActivityData phantomArenaActivityData = this.ActivityBaseData as PhantomArenaActivityData;
			this.RecommendQuestTips.SetContentByTextId(phantomArenaActivityData.RecommendQuestTips, Array.Empty<string>());
			this.RecommendQuestTips.SetUiActive(phantomArenaActivityData.RecommendQuestId > 0 && !ModelBase<QuestNewModel>.Instance.CheckQuestFinished(phantomArenaActivityData.RecommendQuestId));
		}

		// Token: 0x060375E4 RID: 226788 RVA: 0x00E0D4F4 File Offset: 0x00E0B6F4
		private void RefreshLevel()
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			int masterLevel = instance.GetMasterLevel(this.ActivityBaseData.Id);
			int masterLevelMax = instance.GetMasterLevelMax(this.ActivityBaseData.Id);
			ButtonItem btnLevel = this.BtnLevel;
			if (btnLevel == null)
			{
				return;
			}
			btnLevel.SetLocalTextNew("PhantomBattle_1025", new object[]
			{
				masterLevel,
				masterLevelMax
			});
		}

		// Token: 0x060375E5 RID: 226789 RVA: 0x00E0D556 File Offset: 0x00E0B756
		private void OnClickConfirm(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaEntranceView, this.ActivityBaseData.Id, null);
		}

		// Token: 0x060375E6 RID: 226790 RVA: 0x00E0D578 File Offset: 0x00E0B778
		private void OnClickTask(int _)
		{
			BattleShopViewOpenParam param = new BattleShopViewOpenParam
			{
				TabViewName = EUiTabViewName.PhantomArenaEntranceTaskTabView,
				ActivityId = this.ActivityBaseData.Id
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaEntranceShopMainView, param, null);
		}

		// Token: 0x060375E7 RID: 226791 RVA: 0x00E0D5B8 File Offset: 0x00E0B7B8
		private void OnClickLevel(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMasterInfoView, this.ActivityBaseData.Id, null);
		}

		// Token: 0x060375E8 RID: 226792 RVA: 0x00E0D5DC File Offset: 0x00E0B7DC
		private void OnClickRecommend()
		{
			PhantomArenaActivityData phantomArenaActivityData = this.ActivityBaseData as PhantomArenaActivityData;
			if (phantomArenaActivityData.RecommendQuestId > 0 && !ModelBase<QuestNewModel>.Instance.CheckQuestFinished(phantomArenaActivityData.RecommendQuestId))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, phantomArenaActivityData.RecommendQuestId, null);
			}
		}

		// Token: 0x060375E9 RID: 226793 RVA: 0x00E0D62B File Offset: 0x00E0B82B
		protected override void OnBeforeHide()
		{
			this.UnBindRedDot();
		}

		// Token: 0x060375EA RID: 226794 RVA: 0x00E0D633 File Offset: 0x00E0B833
		private void CrossDayRefresh()
		{
			this.RefreshInfo();
		}

		// Token: 0x060375EB RID: 226795 RVA: 0x00E0D63B File Offset: 0x00E0B83B
		private void OnEventRefresh(int activityId)
		{
			this.RefreshInfo();
		}

		// Token: 0x060375EC RID: 226796 RVA: 0x00E0D643 File Offset: 0x00E0B843
		private void OnEventQuestChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
		{
			if (state >= QuestState.Finish)
			{
				this.RefreshInfo();
			}
		}

		// Token: 0x060375ED RID: 226797 RVA: 0x00E0D650 File Offset: 0x00E0B850
		private void BindRedDot()
		{
			this.UnBindRedDot();
			this.BtnLimit.BindRedDot(ERedDotName.RedDotPhantomArenaLimitReward, this.ActivityBaseData.Id);
			this.BtnLevel.BindRedDot(ERedDotName.RedDotPhantomArenaLevelReward, this.ActivityBaseData.Id);
			ActivitySubViewGeneralInfo infoComponent = this.InfoComponent;
			if (infoComponent != null)
			{
				ActivityFunctionalTypeA functional = infoComponent.GetFunctional();
				if (functional != null)
				{
					ActivityButtonItem functionButton = functional.FunctionButton;
					if (functionButton != null)
					{
						functionButton.BindRedDot(ERedDotName.RedDotPhantomArenaActivity, this.ActivityBaseData.Id);
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
		}

		// Token: 0x060375EE RID: 226798 RVA: 0x00E0D6EB File Offset: 0x00E0B8EB
		private void UnBindRedDot()
		{
			this.BtnLimit.UnBindRedDot();
			this.BtnLevel.UnBindRedDot();
			ActivitySubViewGeneralInfo infoComponent = this.InfoComponent;
			if (infoComponent == null)
			{
				return;
			}
			ActivityFunctionalTypeA functional = infoComponent.GetFunctional();
			if (functional == null)
			{
				return;
			}
			ActivityButtonItem functionButton = functional.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.UnBindRedDot();
		}

		// Token: 0x060375EF RID: 226799 RVA: 0x00E0D728 File Offset: 0x00E0B928
		protected override void OnTimer(float gap)
		{
			ValueTuple<bool, string> valueTuple = ModelBase<PhantomArenaModel>.Instance.IsInLimitTime(this.ActivityBaseData.Id, null);
			bool item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			ButtonItem btnLimit = this.BtnLimit;
			if (btnLimit != null)
			{
				btnLimit.SetUiActive(item);
			}
			if (item)
			{
				ButtonItem btnLimit2 = this.BtnLimit;
				if (btnLimit2 == null)
				{
					return;
				}
				btnLimit2.SetText(item2);
			}
		}

		// Token: 0x0401FCBE RID: 130238
		private ActivitySubViewGeneralInfo InfoComponent;

		// Token: 0x0401FCBF RID: 130239
		private ActivityQuestTipsItem RecommendQuestTips;

		// Token: 0x0401FCC0 RID: 130240
		private ButtonItem BtnLimit;

		// Token: 0x0401FCC1 RID: 130241
		private ButtonItem BtnLevel;

		// Token: 0x0200B45E RID: 46174
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037D53 RID: 228691
			public const int InfoItem = 0;

			// Token: 0x04037D54 RID: 228692
			public const int BtnLeft = 1;

			// Token: 0x04037D55 RID: 228693
			public const int RewardRedDot = 2;

			// Token: 0x04037D56 RID: 228694
			public const int BtnLimit = 3;

			// Token: 0x04037D57 RID: 228695
			public const int BtnLevel = 4;

			// Token: 0x04037D58 RID: 228696
			public const int PanelTips = 5;

			// Token: 0x04037D59 RID: 228697
			public const int ItemSpine = 6;
		}
	}
}
