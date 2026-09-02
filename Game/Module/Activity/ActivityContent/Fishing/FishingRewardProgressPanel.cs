using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200678B RID: 26507
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingRewardProgressPanel : UiPanelBase
	{
		// Token: 0x06042133 RID: 270643 RVA: 0x010F3CDC File Offset: 0x010F1EDC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042134 RID: 270644 RVA: 0x010F3DA8 File Offset: 0x010F1FA8
		protected override void OnStart()
		{
			this.ProgressLayout = new GenericLayout<FishingRewardProgressItem, FishingRewardProgressData>(base.GetHorizontalLayout(1), new Func<FishingRewardProgressItem>(this.ProgressItemProxyCreate), null, false, true);
			this.ProgressBarWidth = base.GetSprite(4).GetWidth();
		}

		// Token: 0x06042135 RID: 270645 RVA: 0x010F3DDD File Offset: 0x010F1FDD
		private FishingRewardProgressItem ProgressItemProxyCreate()
		{
			return new FishingRewardProgressItem
			{
				OnClickToGet = this.OnClickToGet
			};
		}

		// Token: 0x06042136 RID: 270646 RVA: 0x010F3DF0 File Offset: 0x010F1FF0
		public UniTask RefreshProgressItem(int currentProgress, int maxProgress, FishingRewardProgressData[] dataList)
		{
			FishingRewardProgressPanel.<RefreshProgressItem>d__8 <RefreshProgressItem>d__;
			<RefreshProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshProgressItem>d__.<>4__this = this;
			<RefreshProgressItem>d__.currentProgress = currentProgress;
			<RefreshProgressItem>d__.dataList = dataList;
			<RefreshProgressItem>d__.<>1__state = -1;
			<RefreshProgressItem>d__.<>t__builder.Start<FishingRewardProgressPanel.<RefreshProgressItem>d__8>(ref <RefreshProgressItem>d__);
			return <RefreshProgressItem>d__.<>t__builder.Task;
		}

		// Token: 0x04024D59 RID: 150873
		private const int REWARD_ITEM_WIDTH = 108;

		// Token: 0x04024D5A RID: 150874
		protected GenericLayout<FishingRewardProgressItem, FishingRewardProgressData> ProgressLayout;

		// Token: 0x04024D5B RID: 150875
		protected float ProgressBarWidth;

		// Token: 0x04024D5C RID: 150876
		[Nullable(2)]
		public Action OnClickToGet;

		// Token: 0x0200C7A7 RID: 51111
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D776 RID: 251766
			public const int TxtProgress = 0;

			// Token: 0x0403D777 RID: 251767
			public const int ProgressLayout = 1;

			// Token: 0x0403D778 RID: 251768
			public const int ProgressItem = 2;

			// Token: 0x0403D779 RID: 251769
			public const int DotStart = 3;

			// Token: 0x0403D77A RID: 251770
			public const int BarProgress = 4;
		}
	}
}
