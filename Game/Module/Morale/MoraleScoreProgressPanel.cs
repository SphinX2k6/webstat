using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200571B RID: 22299
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleScoreProgressPanel : UiPanelBase
	{
		// Token: 0x06038C0F RID: 232463 RVA: 0x00E5EE60 File Offset: 0x00E5D060
		public UniTask Init(UUIItem item)
		{
			MoraleScoreProgressPanel.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleScoreProgressPanel.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038C10 RID: 232464 RVA: 0x00E5EEAC File Offset: 0x00E5D0AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06038C11 RID: 232465 RVA: 0x00E5EF48 File Offset: 0x00E5D148
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleScoreProgressPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleScoreProgressPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038C12 RID: 232466 RVA: 0x00E5EF8B File Offset: 0x00E5D18B
		public void UpdateData()
		{
			this.UpdateDataExcludeReward();
			GenericLayout<MoraleScoreProgressRewardItem, MoraleProgressRewardData> rewardRewardLayout = this.RewardRewardLayout;
			if (rewardRewardLayout == null)
			{
				return;
			}
			rewardRewardLayout.RefreshByData(ModelBase<MoraleModel>.Instance.ProgressRewardList, null, false);
		}

		// Token: 0x06038C13 RID: 232467 RVA: 0x00E5EFB0 File Offset: 0x00E5D1B0
		public void UpdateDataExcludeReward()
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> rewardPercentLayout = this.RewardPercentLayout;
			if (rewardPercentLayout != null)
			{
				rewardPercentLayout.RefreshByData(instance.ProgressRewardList, new Action(this.UpdatePercentHandle), false);
			}
			GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> rewardPercentLayout2 = this.RewardPercentLayout;
			if (rewardPercentLayout2 != null)
			{
				rewardPercentLayout2.BindLateUpdate(delegate(float _)
				{
					TimerSystem.Instance.Next(new TTimerAction(this.TimerUpdatePercentHandle), null, null);
					GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> rewardPercentLayout3 = this.RewardPercentLayout;
					if (rewardPercentLayout3 == null)
					{
						return;
					}
					rewardPercentLayout3.UnBindLateUpdate();
				});
			}
			int currentProgressScore = instance.GetCurrentProgressScore();
			int progressTotalScore = instance.GetProgressTotalScore();
			UUIText text = base.GetText(0);
			string textStringId = "Morale_title_17";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				currentProgressScore,
				progressTotalScore
			}));
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("Morale_title_1");
		}

		// Token: 0x06038C14 RID: 232468 RVA: 0x00E5F061 File Offset: 0x00E5D261
		protected void TimerUpdatePercentHandle(float _)
		{
			this.UpdatePercentHandle();
		}

		// Token: 0x06038C15 RID: 232469 RVA: 0x00E5F06C File Offset: 0x00E5D26C
		protected void UpdatePercentHandle()
		{
			GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> rewardPercentLayout = this.RewardPercentLayout;
			List<MoraleScoreProgressPercentItem> list = (rewardPercentLayout != null) ? rewardPercentLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].UpdatePercentHandle();
			}
		}

		// Token: 0x06038C16 RID: 232470 RVA: 0x00E5F0AD File Offset: 0x00E5D2AD
		private MoraleScoreProgressPercentItem CreatePercentItem()
		{
			return new MoraleScoreProgressPercentItem();
		}

		// Token: 0x06038C17 RID: 232471 RVA: 0x00E5F0B4 File Offset: 0x00E5D2B4
		private MoraleScoreProgressRewardItem CreateRewardItem()
		{
			return new MoraleScoreProgressRewardItem
			{
				ClickCallBack = new Action<MoraleProgressRewardData>(this.OnClickRewardItem)
			};
		}

		// Token: 0x06038C18 RID: 232472 RVA: 0x00E5F0CD File Offset: 0x00E5D2CD
		private void OnClickRewardItem(MoraleProgressRewardData data)
		{
			if (data.IsCanReceived)
			{
				ModelBase<MoraleModel>.Instance.RequestProgressReward(data.Id, true);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(data.ItemId, true, null);
		}

		// Token: 0x04020555 RID: 132437
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<MoraleScoreProgressPercentItem, MoraleProgressRewardData> RewardPercentLayout;

		// Token: 0x04020556 RID: 132438
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<MoraleScoreProgressRewardItem, MoraleProgressRewardData> RewardRewardLayout;

		// Token: 0x0200B7C1 RID: 47041
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D71 RID: 232817
			public const int TxtSumScoreProgress = 0;

			// Token: 0x04038D72 RID: 232818
			public const int TxtSumProgressTitle = 1;

			// Token: 0x04038D73 RID: 232819
			public const int LayoutPercent = 2;

			// Token: 0x04038D74 RID: 232820
			public const int ItemPercent = 3;

			// Token: 0x04038D75 RID: 232821
			public const int LayoutReward = 4;

			// Token: 0x04038D76 RID: 232822
			public const int ItemReward = 5;
		}
	}
}
