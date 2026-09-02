using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C58 RID: 23640
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfrLimitTaskItem : GridProxyAbstract<InfrastructureLimitTaskData>
	{
		// Token: 0x0603BB96 RID: 244630 RVA: 0x00F21290 File Offset: 0x00F1F490
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
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
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickGoto));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickRewardGetConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB97 RID: 244631 RVA: 0x00F21487 File Offset: 0x00F1F687
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(3), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		}

		// Token: 0x0603BB98 RID: 244632 RVA: 0x00F214AA File Offset: 0x00F1F6AA
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603BB99 RID: 244633 RVA: 0x00F214B4 File Offset: 0x00F1F6B4
		public override void Refresh(InfrastructureLimitTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			InfrActivityTask? infrActivityTaskConfig = ConfigBase<InfrastructureConfig>.Instance.GetInfrActivityTaskConfig(this.Data.ConfigId);
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.Data.TaskReward);
			this.RewardScroll.RefreshByData(dropPackagePreviewItemList, delegate
			{
				this.RewardScroll.ScrollToLeft(0);
			}, false);
			ActivityTaskState status = data.Status;
			base.GetArtText(0).SetText(data.Index.ToString());
			base.GetText(5).SetUIActive(status == ActivityTaskState.ActivityTaskRunning);
			base.GetSprite(6).SetUIActive(status == ActivityTaskState.ActivityTaskTaken);
			base.GetSprite(7).SetUIActive(status == ActivityTaskState.ActivityTaskTaken);
			base.GetItem(8).SetUIActive(status == ActivityTaskState.ActivityTaskFinish);
			base.GetButton(9).RootUIComp.Get().SetUIActive(this.Data.JumpId != 0 && status == ActivityTaskState.ActivityTaskRunning);
			base.GetButton(10).RootUIComp.Get().SetUIActive(status == ActivityTaskState.ActivityTaskFinish);
			base.GetText(1).ShowTextNew(infrActivityTaskConfig.Value.TaskDes);
			UUIText text = base.GetText(2);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603BB9A RID: 244634 RVA: 0x00F21620 File Offset: 0x00F1F820
		public void SetOnClickRewardCb(Action cb)
		{
			this.OnClickRewardCb = cb;
		}

		// Token: 0x0603BB9B RID: 244635 RVA: 0x00F21629 File Offset: 0x00F1F829
		private void OnClickGoto()
		{
			if (this.Data.JumpId != 0)
			{
				SkipTaskManager.RunByConfigId(this.Data.JumpId, null);
			}
		}

		// Token: 0x0603BB9C RID: 244636 RVA: 0x00F21649 File Offset: 0x00F1F849
		private void OnClickRewardGetConfirm()
		{
			Action onClickRewardCb = this.OnClickRewardCb;
			if (onClickRewardCb == null)
			{
				return;
			}
			onClickRewardCb();
		}

		// Token: 0x0402192D RID: 137517
		private InfrastructureLimitTaskData Data;

		// Token: 0x0402192E RID: 137518
		public Action<int> OnClickToGet = delegate(int taskId)
		{
		};

		// Token: 0x0402192F RID: 137519
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x04021930 RID: 137520
		private Action OnClickRewardCb;

		// Token: 0x0200BCD5 RID: 48341
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403A2D3 RID: 238291
			public const int ArtTextNum = 0;

			// Token: 0x0403A2D4 RID: 238292
			public const int TextName = 1;

			// Token: 0x0403A2D5 RID: 238293
			public const int TextProcessNum = 2;

			// Token: 0x0403A2D6 RID: 238294
			public const int HorizontalScrollReward = 3;

			// Token: 0x0403A2D7 RID: 238295
			public const int RewardItem = 4;

			// Token: 0x0403A2D8 RID: 238296
			public const int TextDoing = 5;

			// Token: 0x0403A2D9 RID: 238297
			public const int SpriteDone = 6;

			// Token: 0x0403A2DA RID: 238298
			public const int SpriteDoneBg = 7;

			// Token: 0x0403A2DB RID: 238299
			public const int PanelRedPoint = 8;

			// Token: 0x0403A2DC RID: 238300
			public const int BtnGoto = 9;

			// Token: 0x0403A2DD RID: 238301
			public const int BtnRewardGetConfirm = 10;
		}
	}
}
