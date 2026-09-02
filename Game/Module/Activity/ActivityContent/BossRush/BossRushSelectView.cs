using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069CC RID: 27084
	[NullableContext(1)]
	[Nullable(0)]
	public class BossRushSelectView : UiTabViewBase
	{
		// Token: 0x06043242 RID: 275010 RVA: 0x0113FAEC File Offset: 0x0113DCEC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043243 RID: 275011 RVA: 0x0113FBF8 File Offset: 0x0113DDF8
		protected override void OnStart()
		{
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(ModelBase<BossRushModel>.Instance.CurrentSelectActivityId) as BossRushData;
			this.BossRushData = bossRushData;
			this.LoopScrollView = new LoopScrollView<BossRushMainViewScrollItem, BossRushLevelDetailInfo>(base.GetLoopScrollViewComponent(2), base.GetItem(3).GetOwner() as AUIBaseActor, new Func<BossRushMainViewScrollItem>(this.CreateLoopItem), false);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TryShowNewUnlockTips();
		}

		// Token: 0x06043244 RID: 275012 RVA: 0x0113FC70 File Offset: 0x0113DE70
		private void BindRedDot()
		{
			UUIItem item = base.GetItem(4);
			RedDotController instance = ControllerBase<RedDotController>.Instance;
			ERedDotName name = ERedDotName.BossRushReward;
			UUIItem uiItem = item;
			Action<bool, int> stateChangeCallback = null;
			BossRushData bossRushData = this.BossRushData;
			instance.BindRedDot(name, uiItem, stateChangeCallback, (bossRushData != null) ? bossRushData.Id : 0);
		}

		// Token: 0x06043245 RID: 275013 RVA: 0x0113FCA8 File Offset: 0x0113DEA8
		private void UnBindRedDot()
		{
			UUIItem item = base.GetItem(4);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.BossRushReward, item, 0);
		}

		// Token: 0x06043246 RID: 275014 RVA: 0x0113FCCE File Offset: 0x0113DECE
		private BossRushMainViewScrollItem CreateLoopItem()
		{
			return new BossRushMainViewScrollItem();
		}

		// Token: 0x06043247 RID: 275015 RVA: 0x0113FCD5 File Offset: 0x0113DED5
		private void OnClickRewardButton()
		{
			Singleton<EventSystem>.Instance.Emit<EUiTabViewName>(EEventName.RequestChangeBossRushView, EUiTabViewName.BossRushRewardView);
		}

		// Token: 0x06043248 RID: 275016 RVA: 0x0113FCEC File Offset: 0x0113DEEC
		private void RefreshScrollView()
		{
			if (this.LoopScrollView != null)
			{
				this.LoopScrollView.RefreshByData(this.BossRushData.GetBossRushLevelDetailInfo(), false, null, false);
			}
		}

		// Token: 0x06043249 RID: 275017 RVA: 0x0113FD0F File Offset: 0x0113DF0F
		protected override void OnBeforeShow()
		{
			this.TryShowAnimation();
			this.RefreshScrollView();
			this.RefreshPoint();
			this.BindRedDot();
		}

		// Token: 0x0604324A RID: 275018 RVA: 0x0113FD2C File Offset: 0x0113DF2C
		private void TryShowAnimation()
		{
			string sequenceName = "Start";
			if (ModelBase<BossRushModel>.Instance.PlayBackAnimation)
			{
				sequenceName = "ShowView";
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
			}
			ModelBase<BossRushModel>.Instance.PlayBackAnimation = false;
		}

		// Token: 0x0604324B RID: 275019 RVA: 0x0113FD7B File Offset: 0x0113DF7B
		protected override void OnBeforeHide()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0604324C RID: 275020 RVA: 0x0113FD84 File Offset: 0x0113DF84
		private void RefreshPoint()
		{
			base.GetText(1).SetText(this.BossRushData.GetFullScore().ToString(), true);
		}

		// Token: 0x0604324D RID: 275021 RVA: 0x0113FDB4 File Offset: 0x0113DFB4
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			int gridIndex;
			if (configParams.Length != 1 || !int.TryParse(configParams[0], out gridIndex))
			{
				return null;
			}
			UUIItem buttonItem = this.LoopScrollView.UnsafeGetGridProxy(gridIndex, false).GetButtonItem();
			if (buttonItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				buttonItem,
				buttonItem
			};
		}

		// Token: 0x0604324E RID: 275022 RVA: 0x0113FDFC File Offset: 0x0113DFFC
		private void TryShowNewUnlockTips()
		{
			if (this.BossRushData.GetNewUnlockState())
			{
				this.BossRushData.CacheNewUnlock();
				DifficultUnlockTipsData difficultUnlockTipsData = new DifficultUnlockTipsData();
				difficultUnlockTipsData.Text = "BossRushUnlockTips";
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DifficultUnlockTipView, difficultUnlockTipsData, null);
			}
		}

		// Token: 0x040256A0 RID: 153248
		private BossRushData BossRushData;

		// Token: 0x040256A1 RID: 153249
		private LoopScrollView<BossRushMainViewScrollItem, BossRushLevelDetailInfo> LoopScrollView;

		// Token: 0x040256A2 RID: 153250
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C950 RID: 51536
		[NullableContext(0)]
		public class EComponent
		{
			// Token: 0x0403DEA2 RID: 253602
			public const int RewardButton = 0;

			// Token: 0x0403DEA3 RID: 253603
			public const int RewardText = 1;

			// Token: 0x0403DEA4 RID: 253604
			public const int LoopScrollView = 2;

			// Token: 0x0403DEA5 RID: 253605
			public const int LoopItem = 3;

			// Token: 0x0403DEA6 RID: 253606
			public const int RedDot = 4;
		}
	}
}
