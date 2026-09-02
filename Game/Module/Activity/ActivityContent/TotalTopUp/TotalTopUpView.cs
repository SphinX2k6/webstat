using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200628A RID: 25226
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpView : ActivitySubViewBase
	{
		// Token: 0x0603F813 RID: 260115 RVA: 0x01048280 File Offset: 0x01046480
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
		}

		// Token: 0x0603F814 RID: 260116 RVA: 0x0104838C File Offset: 0x0104658C
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F815 RID: 260117 RVA: 0x010483D0 File Offset: 0x010465D0
		protected override void OnStart()
		{
			TotalTopUpData totalTopUpData = this.ActivityBaseData as TotalTopUpData;
			if (totalTopUpData != null)
			{
				this.Refresh(totalTopUpData);
			}
		}

		// Token: 0x0603F816 RID: 260118 RVA: 0x010483F4 File Offset: 0x010465F4
		private void Refresh(TotalTopUpData data)
		{
			TotalTopUpPageViewModel pageViewModel = data.PageViewModel;
			for (int i = 0; i < this.RewardPanels.Count; i++)
			{
				TotalTopUpPageRewardItem totalTopUpPageRewardItem = this.RewardPanels[i];
				if (i < pageViewModel.RewardViewModels.Count)
				{
					TotalTopUpPageRewardViewModel totalTopUpPageRewardViewModel = pageViewModel.RewardViewModels[i];
					if (totalTopUpPageRewardViewModel != null)
					{
						totalTopUpPageRewardItem.Refresh(totalTopUpPageRewardViewModel);
					}
				}
			}
			TotalTopUpPageProgressPanel progressPanel = this.ProgressPanel;
			if (progressPanel == null)
			{
				return;
			}
			progressPanel.Refresh(pageViewModel);
		}

		// Token: 0x0603F817 RID: 260119 RVA: 0x01048464 File Offset: 0x01046664
		protected override void OnRefreshView()
		{
			TotalTopUpUtil.Debug("TotalTopUpView刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
			TotalTopUpData totalTopUpData = this.ActivityBaseData as TotalTopUpData;
			if (totalTopUpData != null)
			{
				this.Refresh(totalTopUpData);
			}
		}

		// Token: 0x0603F818 RID: 260120 RVA: 0x0104849C File Offset: 0x0104669C
		protected override void OnTimer(float deltaTime)
		{
			TotalTopUpData totalTopUpData = this.ActivityBaseData as TotalTopUpData;
			if (totalTopUpData == null)
			{
				return;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num = (double)totalTopUpData.EndOpenTime - serverTime;
			TotalTopUpPageTitlePanel titlePanel = this.TitlePanel;
			if (titlePanel == null)
			{
				return;
			}
			titlePanel.RefreshTime((long)num);
		}

		// Token: 0x04023A63 RID: 146019
		private readonly List<TotalTopUpPageRewardItem> RewardPanels = new List<TotalTopUpPageRewardItem>();

		// Token: 0x04023A64 RID: 146020
		[Nullable(2)]
		private TotalTopUpPageProgressPanel ProgressPanel;

		// Token: 0x04023A65 RID: 146021
		[Nullable(2)]
		private TotalTopUpPageTitlePanel TitlePanel;

		// Token: 0x04023A66 RID: 146022
		[StaticVariableRuleIgnore]
		private static readonly int[] RewardNodes = new int[]
		{
			8,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7
		};

		// Token: 0x0200C36D RID: 50029
		[NullableContext(0)]
		private class ENode
		{
			// Token: 0x0403C38E RID: 246670
			public const int ItemReward0 = 0;

			// Token: 0x0403C38F RID: 246671
			public const int ItemReward1 = 1;

			// Token: 0x0403C390 RID: 246672
			public const int ItemReward2 = 2;

			// Token: 0x0403C391 RID: 246673
			public const int ItemReward3 = 3;

			// Token: 0x0403C392 RID: 246674
			public const int ItemReward4 = 4;

			// Token: 0x0403C393 RID: 246675
			public const int ItemReward5 = 5;

			// Token: 0x0403C394 RID: 246676
			public const int ItemReward6 = 6;

			// Token: 0x0403C395 RID: 246677
			public const int ItemReward7 = 7;

			// Token: 0x0403C396 RID: 246678
			public const int ItemRewardIsolate = 8;

			// Token: 0x0403C397 RID: 246679
			public const int ItemTitlePanel = 9;

			// Token: 0x0403C398 RID: 246680
			public const int ItemProgressPanel = 10;
		}
	}
}
