using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006872 RID: 26738
	[NullableContext(1)]
	[Nullable(0)]
	public class EncircleLevelDetailView : UiViewBase
	{
		// Token: 0x06042A25 RID: 272933 RVA: 0x01119EF1 File Offset: 0x011180F1
		public EncircleLevelDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042A26 RID: 272934 RVA: 0x01119F08 File Offset: 0x01118108
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickedEnterButton))
			};
		}

		// Token: 0x06042A27 RID: 272935 RVA: 0x0111A065 File Offset: 0x01118265
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042A28 RID: 272936 RVA: 0x0111A083 File Offset: 0x01118283
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042A29 RID: 272937 RVA: 0x0111A0A4 File Offset: 0x011182A4
		protected override UniTask OnBeforeStartAsync()
		{
			EncircleLevelDetailView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EncircleLevelDetailView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042A2A RID: 272938 RVA: 0x0111A0E8 File Offset: 0x011182E8
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelpBtn));
			this.Param = (this.OpenParam as IDetailArgs);
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			this.GroupId = this.Param.GroupId;
			this.Levels = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallenges(activityId, this.Param.GroupId);
			this.DifficultyScroll = new GenericLayout<EncircleLevelDetailGridView, int>(base.GetVerticalLayout(2), new Func<EncircleLevelDetailGridView>(this.UpdateItem), null, false, true);
			this.RefreshScroller();
		}

		// Token: 0x06042A2B RID: 272939 RVA: 0x0111A1A8 File Offset: 0x011183A8
		private void GetCurrentDifficulty()
		{
			if (this.Levels == null)
			{
				return;
			}
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			for (int i = 0; i < this.Levels.Length; i++)
			{
				EncircleChallenge? encircleChallengeConfig = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(this.Levels[i]);
				if (encircleChallengeConfig.Value.PreId == 0 || encircleData.CheckChallengeComplete(encircleChallengeConfig.Value.PreId))
				{
					this.DifficultyIndex = i;
				}
			}
		}

		// Token: 0x06042A2C RID: 272940 RVA: 0x0111A225 File Offset: 0x01118425
		protected override void OnBeforeShow()
		{
			this.GetCurrentDifficulty();
			this.Refresh(false);
		}

		// Token: 0x06042A2D RID: 272941 RVA: 0x0111A234 File Offset: 0x01118434
		public void Refresh(bool isSwitch = false)
		{
			this.RefreshDesc(isSwitch);
			this.RefreshReward();
			this.RefreshNewUnlock();
			this.RefreshGridHighLight();
		}

		// Token: 0x06042A2E RID: 272942 RVA: 0x0111A24F File Offset: 0x0111844F
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
		}

		// Token: 0x06042A2F RID: 272943 RVA: 0x0111A26C File Offset: 0x0111846C
		private void RefreshGridHighLight()
		{
			foreach (EncircleLevelDetailGridView encircleLevelDetailGridView in this.GridViews)
			{
				int? challengeDifficulty = encircleLevelDetailGridView.GetChallengeDifficulty();
				if (challengeDifficulty != null)
				{
					int? num = challengeDifficulty;
					int difficultyIndex = this.DifficultyIndex;
					if (num.GetValueOrDefault() == difficultyIndex & num != null)
					{
						encircleLevelDetailGridView.SetToggleActive();
					}
				}
			}
		}

		// Token: 0x06042A30 RID: 272944 RVA: 0x0111A2F0 File Offset: 0x011184F0
		private void RefreshNewUnlock()
		{
			ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
			if (encircleData == null)
			{
				return;
			}
			foreach (int challengeId in this.Levels)
			{
				if (encircleData != null && encircleData.CheckChallengeNewUnlock(challengeId))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_LevelUnlockTips_Text", Array.Empty<object>());
					encircleData.MarkChallengeNewUnlock(challengeId, false);
				}
			}
		}

		// Token: 0x06042A31 RID: 272945 RVA: 0x0111A350 File Offset: 0x01118550
		private void RefreshDesc(bool isSwitch = false)
		{
			int challengeId = this.Levels[this.DifficultyIndex];
			EncircleChallenge? encircleChallengeConfig = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(challengeId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), encircleChallengeConfig.Value.LevelTitle, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), encircleChallengeConfig.Value.LevelDesc, Array.Empty<object>());
			this.SetSpriteByPath(encircleChallengeConfig.Value.LevelIcon, base.GetSprite(12), false, null, null);
			UUIArtText artText = base.GetArtText(1);
			if (artText != null)
			{
				artText.SetText((this.GroupId >= 10) ? this.GroupId.ToString() : ("0" + this.GroupId.ToString()));
			}
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(this.DifficultyIndex == 0);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(this.DifficultyIndex == 1);
			}
			UUIItem item3 = base.GetItem(11);
			if (item3 != null)
			{
				item3.SetUIActive(this.DifficultyIndex == 1);
			}
			UUIItem item4 = base.GetItem(12);
			if (item4 != null)
			{
				item4.SetUIActive(this.DifficultyIndex == 0);
			}
			if (isSwitch)
			{
				LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
				if (viewSequencePlayer != null)
				{
					viewSequencePlayer.StopCurrentSequence(false, true);
				}
				this.ViewSequencePlayer.PlayLevelSequenceByName((this.DifficultyIndex == 1) ? "Switch" : "Switch02", false, null, false);
			}
		}

		// Token: 0x06042A32 RID: 272946 RVA: 0x0111A4DC File Offset: 0x011186DC
		private void RefreshReward()
		{
			int challengeId = this.Levels[this.DifficultyIndex];
			int rewardId = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(challengeId).Value.RewardId;
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardId);
			this.RewardListComponent.RefreshItemLayout(dropPackagePreviewItemList.ToArray(), null);
		}

		// Token: 0x06042A33 RID: 272947 RVA: 0x0111A532 File Offset: 0x01118732
		private void RefreshScroller()
		{
			this.DifficultyScroll.RefreshByData(this.Levels.ToList<int>(), null, false);
		}

		// Token: 0x06042A34 RID: 272948 RVA: 0x0111A54C File Offset: 0x0111874C
		public CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = delegate(TItem _)
				{
					ActivityEncircleData encircleData = ControllerBase<ActivityEncircleController>.Instance.GetEncircleData();
					int challengeId = this.Levels[this.DifficultyIndex];
					return encircleData.CheckChallengeComplete(challengeId);
				}
			};
		}

		// Token: 0x06042A35 RID: 272949 RVA: 0x0111A568 File Offset: 0x01118768
		private EncircleLevelDetailGridView UpdateItem()
		{
			EncircleLevelDetailGridView encircleLevelDetailGridView = new EncircleLevelDetailGridView();
			this.GridViews.Add(encircleLevelDetailGridView);
			return encircleLevelDetailGridView;
		}

		// Token: 0x06042A36 RID: 272950 RVA: 0x0111A588 File Offset: 0x01118788
		private void OnClickedEnterButton()
		{
			if (!ControllerBase<ActivityEncircleController>.Instance.GetEncircleData().CheckPreChallengeComplete(this.Levels[this.DifficultyIndex]))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Encirle_DifficultyLockTips_Text", Array.Empty<object>());
				return;
			}
			Singleton<EncirclePlayLevelController>.Instance.EnterPlay(this.Param.GroupId, this.Levels[this.DifficultyIndex]);
		}

		// Token: 0x06042A37 RID: 272951 RVA: 0x0111A5EA File Offset: 0x011187EA
		private void OnClickedCloseButton()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.EncircleLevelDetailView, null);
		}

		// Token: 0x06042A38 RID: 272952 RVA: 0x0111A5FC File Offset: 0x011187FC
		public void ChangeDifficultyIndex(int value)
		{
			this.DifficultyIndex = value;
			this.Refresh(true);
		}

		// Token: 0x06042A39 RID: 272953 RVA: 0x0111A60C File Offset: 0x0111880C
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(507);
		}

		// Token: 0x06042A3A RID: 272954 RVA: 0x0111A61D File Offset: 0x0111881D
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<ActivityEncircleController>.Instance.ActivityId))
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x0402515E RID: 151902
		private const int HELP_ID = 507;

		// Token: 0x0402515F RID: 151903
		[Nullable(2)]
		private IDetailArgs Param;

		// Token: 0x04025160 RID: 151904
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025161 RID: 151905
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x04025162 RID: 151906
		private GenericLayout<EncircleLevelDetailGridView, int> DifficultyScroll;

		// Token: 0x04025163 RID: 151907
		private int DifficultyIndex;

		// Token: 0x04025164 RID: 151908
		private int GroupId;

		// Token: 0x04025165 RID: 151909
		[Nullable(2)]
		private int[] Levels;

		// Token: 0x04025166 RID: 151910
		[Nullable(2)]
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04025167 RID: 151911
		private readonly List<EncircleLevelDetailGridView> GridViews = new List<EncircleLevelDetailGridView>();
	}
}
