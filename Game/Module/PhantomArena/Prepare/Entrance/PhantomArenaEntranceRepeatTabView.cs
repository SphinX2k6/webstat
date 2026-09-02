using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C4 RID: 21700
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaEntranceRepeatTabView : PhantomArenaChildViewBase
	{
		// Token: 0x17008E96 RID: 36502
		// (get) Token: 0x0603746E RID: 226414 RVA: 0x00E0655D File Offset: 0x00E0475D
		// (set) Token: 0x0603746F RID: 226415 RVA: 0x00E0656A File Offset: 0x00E0476A
		public new PhantomArenaEntranceViewModel ViewModel
		{
			get
			{
				return this.ViewModel as PhantomArenaEntranceViewModel;
			}
			set
			{
				this.ViewModel = value;
			}
		}

		// Token: 0x06037470 RID: 226416 RVA: 0x00E06574 File Offset: 0x00E04774
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
		}

		// Token: 0x06037471 RID: 226417 RVA: 0x00E0666C File Offset: 0x00E0486C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaEntranceRepeatTabView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaEntranceRepeatTabView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037472 RID: 226418 RVA: 0x00E066B0 File Offset: 0x00E048B0
		protected override void OnStart()
		{
			this.LayoutReward = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(4), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, null);
			ModelBase<PhantomArenaModel>.Instance.SetGymRedDotChecked(7, base.ActivityId);
			int player = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.PhantomArenaRepeatLastIndex, 0);
			List<GymChallengeData> challengeStateListByGymLevel = ModelBase<PhantomArenaModel>.Instance.GetChallengeStateListByGymLevel(7, base.ActivityId);
			this.ChallengeData = challengeStateListByGymLevel[player];
			this.DropDownDifficulty.InitScroll(challengeStateListByGymLevel, new Func<GymChallengeData, GymChallengeData>(this.GetDropDownItemData), player, true);
			this.DropDownDifficulty.SetShowType(ECommonDropDownShowType.Up);
			this.DropDownDifficulty.SetOnSelectCall(new Action<int, GymChallengeData>(this.OnSelectDifficulty));
		}

		// Token: 0x06037473 RID: 226419 RVA: 0x00E06767 File Offset: 0x00E04967
		protected override void OnBeforeShow()
		{
			this.RefreshInfo();
			this.RefreshPoints();
			this.RefreshBtns();
		}

		// Token: 0x06037474 RID: 226420 RVA: 0x00E0677C File Offset: 0x00E0497C
		private void RefreshInfo()
		{
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(this.ChallengeId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomBattleChallenge.ChallengeName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), phantomBattleChallenge.NpcDesc, Array.Empty<object>());
			List<TItem> rewardListByChallengeId = ModelBase<PhantomArenaModel>.Instance.GetRewardListByChallengeId(this.ChallengeId);
			this.LayoutReward.RefreshByData(rewardListByChallengeId, null, false);
			int masterLevel = ModelBase<PhantomArenaModel>.Instance.GetMasterLevel(base.ActivityId);
			int repeatGymExpWeekLimitByLevel = ConfigBase<PhantomArenaConfig>.Instance.GetRepeatGymExpWeekLimitByLevel(masterLevel);
			int masterExpWeek = ModelBase<PhantomArenaModel>.Instance.GetMasterExpWeek(base.ActivityId);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), "PhantomBattle_1117", new <>z__ReadOnlyArray<object>(new object[]
			{
				masterExpWeek,
				repeatGymExpWeekLimitByLevel
			}));
		}

		// Token: 0x06037475 RID: 226421 RVA: 0x00E06858 File Offset: 0x00E04A58
		private void RefreshPoints()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "PhantomBattle_1106", Array.Empty<object>());
			int pointsItemId = ModelBase<PhantomArenaModel>.Instance.GetPointsItemId(base.ActivityId);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(pointsItemId, 0);
			base.GetText(1).SetText(commonItemCount.ToString(), true);
		}

		// Token: 0x06037476 RID: 226422 RVA: 0x00E068B4 File Offset: 0x00E04AB4
		private void RefreshBtns()
		{
			bool uiActive = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PhantomArenaCard);
			this.BtnCard.SetUiActive(uiActive);
		}

		// Token: 0x06037477 RID: 226423 RVA: 0x00E068E0 File Offset: 0x00E04AE0
		private void OnClickCard(int _)
		{
			PhantomArenaMainViewOpenParam param = new PhantomArenaMainViewOpenParam
			{
				ChallengeId = 0,
				OpenView = EPhantomArenaChildViewName.PhantomArenaDeckOverviewTabView,
				ActivityId = base.ActivityId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaMainView, param, null);
		}

		// Token: 0x06037478 RID: 226424 RVA: 0x00E0691E File Offset: 0x00E04B1E
		private void OnClickConfirm(int _)
		{
			if (!ModelBase<PhantomArenaModel>.Instance.GetRepeatChallengeOpen(this.ChallengeId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1112", Array.Empty<object>());
				return;
			}
			this.ViewModel.SetRepeatChallenge(this.ChallengeId, false);
		}

		// Token: 0x06037479 RID: 226425 RVA: 0x00E06959 File Offset: 0x00E04B59
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603747A RID: 226426 RVA: 0x00E06960 File Offset: 0x00E04B60
		private bool OnCheckCanChange(int oldIndex, int newIndex)
		{
			return oldIndex != newIndex && ModelBase<PhantomArenaModel>.Instance.GetChallengeStateListByGymLevel(7, base.ActivityId)[newIndex].State > EChallengeState.Lock;
		}

		// Token: 0x0603747B RID: 226427 RVA: 0x00E06988 File Offset: 0x00E04B88
		private void OnSelectDifficulty(int index, object data)
		{
			GymChallengeData challengeData = data as GymChallengeData;
			this.ChallengeData = challengeData;
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.PhantomArenaRepeatLastIndex, index);
			this.RefreshInfo();
		}

		// Token: 0x0603747C RID: 226428 RVA: 0x00E069B5 File Offset: 0x00E04BB5
		private GymChallengeData GetDropDownItemData(object data)
		{
			return data as GymChallengeData;
		}

		// Token: 0x17008E97 RID: 36503
		// (get) Token: 0x0603747D RID: 226429 RVA: 0x00E069BD File Offset: 0x00E04BBD
		private int ChallengeId
		{
			get
			{
				GymChallengeData challengeData = this.ChallengeData;
				if (challengeData == null)
				{
					return -1;
				}
				return challengeData.Id;
			}
		}

		// Token: 0x0401FC52 RID: 130130
		[Nullable(2)]
		private GymChallengeData ChallengeData;

		// Token: 0x0401FC53 RID: 130131
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> LayoutReward;

		// Token: 0x0401FC54 RID: 130132
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private CommonDropDown<GymChallengeData, GymChallengeData> DropDownDifficulty;

		// Token: 0x0401FC55 RID: 130133
		[Nullable(2)]
		private ButtonItem BtnCard;

		// Token: 0x0401FC56 RID: 130134
		[Nullable(2)]
		private ButtonItem BtnConfirm;

		// Token: 0x0200B42D RID: 46125
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037C36 RID: 228406
			public const int TextPointsAllTitle = 0;

			// Token: 0x04037C37 RID: 228407
			public const int TextPointsAll = 1;

			// Token: 0x04037C38 RID: 228408
			public const int TextChallenge = 2;

			// Token: 0x04037C39 RID: 228409
			public const int TextDesc = 3;

			// Token: 0x04037C3A RID: 228410
			public const int ScrollReward = 4;

			// Token: 0x04037C3B RID: 228411
			public const int ItemReward = 5;

			// Token: 0x04037C3C RID: 228412
			public const int TextPointsNow = 6;

			// Token: 0x04037C3D RID: 228413
			public const int ItemDropDown = 7;

			// Token: 0x04037C3E RID: 228414
			public const int BtnConfirmLeft = 8;

			// Token: 0x04037C3F RID: 228415
			public const int BtnConfirmRight = 9;
		}
	}
}
