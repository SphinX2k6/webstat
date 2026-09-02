using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006594 RID: 26004
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballLimitedRewardTaskItem : GridProxyAbstract<PinballTaskData>
	{
		// Token: 0x06040FA4 RID: 266148 RVA: 0x010ABDFC File Offset: 0x010A9FFC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnRewardBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040FA5 RID: 266149 RVA: 0x010ABF8A File Offset: 0x010AA18A
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(3), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		}

		// Token: 0x06040FA6 RID: 266150 RVA: 0x010ABFB0 File Offset: 0x010AA1B0
		public override void Refresh(PinballTaskData data, bool isSelected, int gridIndex)
		{
			this.TaskData = data;
			this.RewardScroll.RefreshByData(data.RewardList, null, false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(data.IsUnclaimed);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(data.IsFinished);
			base.GetText(5).SetUIActive(data.IsDoing);
			UUIText text = base.GetText(1);
			if (!string.IsNullOrEmpty(data.QuestNameTextKey))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.QuestNameTextKey, Array.Empty<object>());
			}
			else
			{
				text.SetText(data.QuestName, true);
			}
			base.GetText(2).SetUIActive(data.Target != 0);
			UUIText text2 = base.GetText(2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06040FA7 RID: 266151 RVA: 0x010AC0B9 File Offset: 0x010AA2B9
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06040FA8 RID: 266152 RVA: 0x010AC0C0 File Offset: 0x010AA2C0
		private void OnRewardBtnClick()
		{
			UiAsyncTask task = new UiAsyncTask("PinballTaskItem.RequestTaskReward", delegate()
			{
				PinballLimitedRewardTaskItem.<<OnRewardBtnClick>b__7_0>d <<OnRewardBtnClick>b__7_0>d;
				<<OnRewardBtnClick>b__7_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnRewardBtnClick>b__7_0>d.<>4__this = this;
				<<OnRewardBtnClick>b__7_0>d.<>1__state = -1;
				<<OnRewardBtnClick>b__7_0>d.<>t__builder.Start<PinballLimitedRewardTaskItem.<<OnRewardBtnClick>b__7_0>d>(ref <<OnRewardBtnClick>b__7_0>d);
				return <<OnRewardBtnClick>b__7_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06040FA9 RID: 266153 RVA: 0x010AC0F4 File Offset: 0x010AA2F4
		private UniTask OnRewardBtnClickAsync()
		{
			PinballLimitedRewardTaskItem.<OnRewardBtnClickAsync>d__8 <OnRewardBtnClickAsync>d__;
			<OnRewardBtnClickAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnRewardBtnClickAsync>d__.<>4__this = this;
			<OnRewardBtnClickAsync>d__.<>1__state = -1;
			<OnRewardBtnClickAsync>d__.<>t__builder.Start<PinballLimitedRewardTaskItem.<OnRewardBtnClickAsync>d__8>(ref <OnRewardBtnClickAsync>d__);
			return <OnRewardBtnClickAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04024712 RID: 149266
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x04024713 RID: 149267
		[Nullable(2)]
		private PinballTaskData TaskData;

		// Token: 0x04024714 RID: 149268
		[Nullable(2)]
		public Func<int, UniTask> OnTaskRewardClick;

		// Token: 0x0200C580 RID: 50560
		[NullableContext(0)]
		private enum ETaskComponents
		{
			// Token: 0x0403CC87 RID: 248967
			BtnStrip,
			// Token: 0x0403CC88 RID: 248968
			TxtName,
			// Token: 0x0403CC89 RID: 248969
			TxtNum,
			// Token: 0x0403CC8A RID: 248970
			ItemLayout,
			// Token: 0x0403CC8B RID: 248971
			ItemBaseB,
			// Token: 0x0403CC8C RID: 248972
			TxtDoing,
			// Token: 0x0403CC8D RID: 248973
			BtnConfirmBaseA,
			// Token: 0x0403CC8E RID: 248974
			RedPoint,
			// Token: 0x0403CC8F RID: 248975
			PanelDone
		}
	}
}
