using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E5D RID: 20061
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBdSumBdItem : GridProxyAbstract<TrapDefenseBdData>
	{
		// Token: 0x06033D7C RID: 212348 RVA: 0x00CF6D24 File Offset: 0x00CF4F24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleRoot));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D7D RID: 212349 RVA: 0x00CF6ED4 File Offset: 0x00CF50D4
		[Conditional("WITH_EDITOR")]
		private void EditorShowActorLabel()
		{
		}

		// Token: 0x06033D7E RID: 212350 RVA: 0x00CF6ED8 File Offset: 0x00CF50D8
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBdSumBdItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdSumBdItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D7F RID: 212351 RVA: 0x00CF6F1C File Offset: 0x00CF511C
		public override UniTask RefreshAsync(TrapDefenseBdData data, bool isSelected, int gridIndex)
		{
			TrapDefenseBdSumBdItem.<RefreshAsync>d__7 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<TrapDefenseBdSumBdItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D80 RID: 212352 RVA: 0x00CF6F68 File Offset: 0x00CF5168
		public UniTask UpdateProgress()
		{
			TrapDefenseBdSumBdItem.<UpdateProgress>d__8 <UpdateProgress>d__;
			<UpdateProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateProgress>d__.<>4__this = this;
			<UpdateProgress>d__.<>1__state = -1;
			<UpdateProgress>d__.<>t__builder.Start<TrapDefenseBdSumBdItem.<UpdateProgress>d__8>(ref <UpdateProgress>d__);
			return <UpdateProgress>d__.<>t__builder.Task;
		}

		// Token: 0x06033D81 RID: 212353 RVA: 0x00CF6FAB File Offset: 0x00CF51AB
		private TrapDefenseBdSumBdProgressItem CreateItemLayoutProgress()
		{
			return new TrapDefenseBdSumBdProgressItem();
		}

		// Token: 0x06033D82 RID: 212354 RVA: 0x00CF6FB2 File Offset: 0x00CF51B2
		private void OnClickToggleRoot(EToggleState check)
		{
			if (check == EToggleState.ETT_Checked)
			{
				IScrollViewDelegate<IGridProxy<TrapDefenseBdData>, TrapDefenseBdData> scrollViewDelegate = base.ScrollViewDelegate;
				if (scrollViewDelegate == null)
				{
					return;
				}
				scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
			}
		}

		// Token: 0x06033D83 RID: 212355 RVA: 0x00CF6FD8 File Offset: 0x00CF51D8
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			Action<TrapDefenseBdData> clickCallBack = this.ClickCallBack;
			if (clickCallBack != null)
			{
				clickCallBack(this.ItemData);
			}
			foreach (TrapDefenseBdSumBdProgressItem trapDefenseBdSumBdProgressItem in this.LayoutProgress.GetLayoutItemList())
			{
				trapDefenseBdSumBdProgressItem.SetQualityArrowShow(true);
			}
		}

		// Token: 0x06033D84 RID: 212356 RVA: 0x00CF705C File Offset: 0x00CF525C
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			foreach (TrapDefenseBdSumBdProgressItem trapDefenseBdSumBdProgressItem in this.LayoutProgress.GetLayoutItemList())
			{
				trapDefenseBdSumBdProgressItem.SetQualityArrowShow(false);
			}
		}

		// Token: 0x0401DFCD RID: 122829
		public TrapDefenseBdData ItemData;

		// Token: 0x0401DFCE RID: 122830
		public Action<TrapDefenseBdData> ClickCallBack;

		// Token: 0x0401DFCF RID: 122831
		public GenericLayout<TrapDefenseBdSumBdProgressItem, ITrapDefenseBdProgressInfo> LayoutProgress;

		// Token: 0x0200AE06 RID: 44550
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x040360BA RID: 221370
			public const int ToggleRoot = 0;

			// Token: 0x040360BB RID: 221371
			public const int TextureBgQuality = 1;

			// Token: 0x040360BC RID: 221372
			public const int TextureIcon = 2;

			// Token: 0x040360BD RID: 221373
			public const int TextTitle = 3;

			// Token: 0x040360BE RID: 221374
			public const int TextDesc = 4;

			// Token: 0x040360BF RID: 221375
			public const int TextProgress = 5;

			// Token: 0x040360C0 RID: 221376
			public const int LayoutProgress = 6;

			// Token: 0x040360C1 RID: 221377
			public const int ItemLayoutProgress = 7;

			// Token: 0x040360C2 RID: 221378
			public const int ItemNormalState = 8;

			// Token: 0x040360C3 RID: 221379
			public const int ItemLockState = 9;
		}
	}
}
