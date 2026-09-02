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
	// Token: 0x02006568 RID: 25960
	public class PrizeDrawingFinalRewardItem : UiPanelBase
	{
		// Token: 0x06040DC9 RID: 265673 RVA: 0x010A29C3 File Offset: 0x010A0BC3
		public PrizeDrawingFinalRewardItem(int itemId, int count)
		{
			this.ItemId = itemId;
			this.Count = count;
		}

		// Token: 0x06040DCA RID: 265674 RVA: 0x010A29DC File Offset: 0x010A0BDC
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040DCB RID: 265675 RVA: 0x010A2ACC File Offset: 0x010A0CCC
		protected override UniTask OnBeforeStartAsync()
		{
			PrizeDrawingFinalRewardItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PrizeDrawingFinalRewardItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040DCC RID: 265676 RVA: 0x010A2B10 File Offset: 0x010A0D10
		private UniTask Initialize(int itemId, int count)
		{
			PrizeDrawingFinalRewardItem.<Initialize>d__7 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.itemId = itemId;
			<Initialize>d__.count = count;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<PrizeDrawingFinalRewardItem.<Initialize>d__7>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x06040DCD RID: 265677 RVA: 0x010A2B63 File Offset: 0x010A0D63
		public void Refresh(bool isGot, bool animBanned = false)
		{
			GotItem gotItem = this.GotItem;
			if (gotItem == null)
			{
				return;
			}
			gotItem.RefreshGotState(isGot, animBanned);
		}

		// Token: 0x04024648 RID: 149064
		[Nullable(2)]
		private GotItem GotItem;

		// Token: 0x04024649 RID: 149065
		private readonly int ItemId;

		// Token: 0x0402464A RID: 149066
		private readonly int Count;

		// Token: 0x0200C551 RID: 50513
		private enum EComp
		{
			// Token: 0x0403CB91 RID: 248721
			TexIcon,
			// Token: 0x0403CB92 RID: 248722
			TxtName,
			// Token: 0x0403CB93 RID: 248723
			SprGot,
			// Token: 0x0403CB94 RID: 248724
			PnlTagCur,
			// Token: 0x0403CB95 RID: 248725
			TxtCount,
			// Token: 0x0403CB96 RID: 248726
			GotItem
		}
	}
}
