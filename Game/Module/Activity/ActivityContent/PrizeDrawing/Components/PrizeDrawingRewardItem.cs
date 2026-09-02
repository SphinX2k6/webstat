using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components
{
	// Token: 0x0200656A RID: 25962
	public class PrizeDrawingRewardItem : UiPanelBase
	{
		// Token: 0x06040DDA RID: 265690 RVA: 0x010A2FA9 File Offset: 0x010A11A9
		public PrizeDrawingRewardItem(int itemId, int count, int maxAmount)
		{
			this.ItemId = itemId;
			this.Count = count;
			this.MaxAmount = maxAmount;
		}

		// Token: 0x06040DDB RID: 265691 RVA: 0x010A2FD4 File Offset: 0x010A11D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040DDC RID: 265692 RVA: 0x010A30C4 File Offset: 0x010A12C4
		protected override UniTask OnBeforeStartAsync()
		{
			PrizeDrawingRewardItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PrizeDrawingRewardItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040DDD RID: 265693 RVA: 0x010A3108 File Offset: 0x010A1308
		private UniTask Initialize(int itemId, int count, int rewardMaxAmount)
		{
			PrizeDrawingRewardItem.<Initialize>d__8 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.itemId = itemId;
			<Initialize>d__.count = count;
			<Initialize>d__.rewardMaxAmount = rewardMaxAmount;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<PrizeDrawingRewardItem.<Initialize>d__8>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x06040DDE RID: 265694 RVA: 0x010A3164 File Offset: 0x010A1364
		public void Refresh(int acquiredCount, bool animBanned = false)
		{
			for (int i = 0; i < this.GotItemList.Count; i++)
			{
				this.GotItemList[i].RefreshGotState(i + 1 <= acquiredCount, animBanned);
			}
		}

		// Token: 0x0402464E RID: 149070
		[Nullable(1)]
		private readonly List<GotItem> GotItemList = new List<GotItem>();

		// Token: 0x0402464F RID: 149071
		private readonly int ItemId;

		// Token: 0x04024650 RID: 149072
		private readonly int Count;

		// Token: 0x04024651 RID: 149073
		private readonly int MaxAmount;

		// Token: 0x0200C557 RID: 50519
		private enum EPrizeItemType
		{
			// Token: 0x0403CBB1 RID: 248753
			TexIcon,
			// Token: 0x0403CBB2 RID: 248754
			TxtName,
			// Token: 0x0403CBB3 RID: 248755
			TxtTotal,
			// Token: 0x0403CBB4 RID: 248756
			PnlGrid,
			// Token: 0x0403CBB5 RID: 248757
			PrizeItem,
			// Token: 0x0403CBB6 RID: 248758
			TxtCount
		}
	}
}
