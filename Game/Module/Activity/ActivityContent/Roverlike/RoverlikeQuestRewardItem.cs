using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006437 RID: 25655
	public class RoverlikeQuestRewardItem : GridProxyAbstract<int>
	{
		// Token: 0x06040689 RID: 263817 RVA: 0x01083074 File Offset: 0x01081274
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickJumpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604068A RID: 263818 RVA: 0x010831E0 File Offset: 0x010813E0
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(5), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
			this.GetBtnItem = new ButtonItem(base.GetItem(7));
			this.GetBtnItem.SetFunction(delegate(int _)
			{
				this.OnClickGetBtn();
			});
		}

		// Token: 0x0604068B RID: 263819 RVA: 0x01083237 File Offset: 0x01081437
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => this.IsTaken)
			};
		}

		// Token: 0x0604068C RID: 263820 RVA: 0x01083250 File Offset: 0x01081450
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.TaskId = data;
			RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			ConditionTask conditionTask = (currentActivityData != null) ? currentActivityData.QuestData.GetTask(this.TaskId) : null;
			RoverRogueReward? rewardConfig = ConfigBase<RoverlikeConfig>.Instance.GetRewardConfig(this.TaskId);
			if (conditionTask == null || rewardConfig == null)
			{
				return;
			}
			RoverRogueReward value = rewardConfig.Value;
			bool flag = conditionTask.Status == ConditionTaskState.ConditionTaskTaken;
			bool flag2 = conditionTask.Status == ConditionTaskState.ConditionTaskFinish;
			bool uiactive = conditionTask.Status == ConditionTaskState.ConditionTaskRunning;
			this.IsTaken = flag;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), value.Name, Array.Empty<object>());
			UUIText text = base.GetText(8);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(conditionTask.Current);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(conditionTask.Target);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.DropId);
			this.RewardScroll.RefreshByData(dropPackagePreviewItemList, null, false);
			UUIText text2 = base.GetText(4);
			if (text2 != null)
			{
				text2.useChangeColor = flag;
				text2.outlineSize = (flag ? 0 : 3);
			}
			UUIText text3 = base.GetText(8);
			if (text3 != null)
			{
				text3.useChangeColor = flag;
			}
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(flag);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			ButtonItem getBtnItem = this.GetBtnItem;
			if (getBtnItem != null)
			{
				getBtnItem.SetUiActive(flag2);
			}
			ButtonItem getBtnItem2 = this.GetBtnItem;
			if (getBtnItem2 != null)
			{
				getBtnItem2.SetRedDotVisible(flag2);
			}
			UUIText text4 = base.GetText(1);
			if (text4 != null)
			{
				text4.SetUIActive(uiactive);
			}
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(false);
		}

		// Token: 0x0604068D RID: 263821 RVA: 0x01083418 File Offset: 0x01081618
		public override void Clear()
		{
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScroll = this.RewardScroll;
			if (rewardScroll == null)
			{
				return;
			}
			rewardScroll.RefreshByData(new List<TItem>(), null, false);
		}

		// Token: 0x0604068E RID: 263822 RVA: 0x01083431 File Offset: 0x01081631
		[NullableContext(1)]
		public override object GetKey(int data, int displayIndex)
		{
			return data;
		}

		// Token: 0x0604068F RID: 263823 RVA: 0x0108343C File Offset: 0x0108163C
		private void OnClickGetBtn()
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			List<int> list = ((roverlikeActivityData != null) ? roverlikeActivityData.QuestData.GetAllTakeableTaskIds() : null) ?? new List<int>();
			if (list.Count == 0)
			{
				return;
			}
			ControllerBase<RoverlikeController>.Instance.RequestTaskRewardTake(list, null);
		}

		// Token: 0x06040690 RID: 263824 RVA: 0x0108348A File Offset: 0x0108168A
		private void OnClickJumpBtn()
		{
		}

		// Token: 0x04024126 RID: 147750
		private int TaskId;

		// Token: 0x04024127 RID: 147751
		private bool IsTaken;

		// Token: 0x04024128 RID: 147752
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x04024129 RID: 147753
		[Nullable(2)]
		private ButtonItem GetBtnItem;

		// Token: 0x0200C4AB RID: 50347
		private class EComponent
		{
			// Token: 0x0403C889 RID: 247945
			public const int JumpBtn = 0;

			// Token: 0x0403C88A RID: 247946
			public const int DoingText = 1;

			// Token: 0x0403C88B RID: 247947
			public const int SpriteDone = 2;

			// Token: 0x0403C88C RID: 247948
			public const int ItemDone = 3;

			// Token: 0x0403C88D RID: 247949
			public const int NameText = 4;

			// Token: 0x0403C88E RID: 247950
			public const int RewardScroll = 5;

			// Token: 0x0403C88F RID: 247951
			public const int GetBtn = 7;

			// Token: 0x0403C890 RID: 247952
			public const int ProgressText = 8;
		}
	}
}
