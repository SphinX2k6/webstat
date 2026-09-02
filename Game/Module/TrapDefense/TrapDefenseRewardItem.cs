using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E46 RID: 20038
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseRewardItem : GridProxyAbstract<TrapDefenseRewardItemData>
	{
		// Token: 0x06033CAD RID: 212141 RVA: 0x00CF25DC File Offset: 0x00CF07DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
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
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClaimClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033CAE RID: 212142 RVA: 0x00CF276A File Offset: 0x00CF096A
		protected override void OnStart()
		{
			this.ItemListScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(5), () => new CommonItemSmallItemGrid(), null, false, null);
		}

		// Token: 0x06033CAF RID: 212143 RVA: 0x00CF27A0 File Offset: 0x00CF09A0
		public override void Refresh(TrapDefenseRewardItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (this.Data == null)
			{
				return;
			}
			base.GetButton(0).GetRootComponent().SetUIActive(false);
			base.GetButton(7).GetRootComponent().SetUIActive(data.State == ETrapDefenseRewardState.CanClaim);
			base.GetText(1).SetUIActive(data.State != ETrapDefenseRewardState.CanClaim && data.State != ETrapDefenseRewardState.Claimed);
			if (data.State == ETrapDefenseRewardState.Lock)
			{
				base.GetText(1).SetText(data.GetUnlockRemainTimeStr(), true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.Desc, Array.Empty<object>());
			base.GetItem(6).SetUIActive(false);
			base.GetItem(3).SetUIActive(data.State == ETrapDefenseRewardState.Claimed);
			base.GetSprite(2).SetUIActive(data.State == ETrapDefenseRewardState.Claimed);
			UUIText text = base.GetText(8);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.CurProgress);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.ItemListScrollView.RefreshByData(data.ItemList, null, false);
		}

		// Token: 0x06033CB0 RID: 212144 RVA: 0x00CF28D1 File Offset: 0x00CF0AD1
		private void OnClaimClick()
		{
			Action<TrapDefenseRewardItemData> onClaimRewardCallback = this.OnClaimRewardCallback;
			if (onClaimRewardCallback == null)
			{
				return;
			}
			onClaimRewardCallback(this.Data);
		}

		// Token: 0x0401DF91 RID: 122769
		private TrapDefenseRewardItemData Data;

		// Token: 0x0401DF92 RID: 122770
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ItemListScrollView;

		// Token: 0x0401DF93 RID: 122771
		public Action<TrapDefenseRewardItemData> OnClaimRewardCallback;

		// Token: 0x0200ADD9 RID: 44505
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035FB2 RID: 221106
			public const int BtnWhite = 0;

			// Token: 0x04035FB3 RID: 221107
			public const int TextState = 1;

			// Token: 0x04035FB4 RID: 221108
			public const int SpriteFinished = 2;

			// Token: 0x04035FB5 RID: 221109
			public const int ItemFinished = 3;

			// Token: 0x04035FB6 RID: 221110
			public const int TextDesc = 4;

			// Token: 0x04035FB7 RID: 221111
			public const int ScrollView = 5;

			// Token: 0x04035FB8 RID: 221112
			public const int ItemRedDot = 6;

			// Token: 0x04035FB9 RID: 221113
			public const int BtnBlack = 7;

			// Token: 0x04035FBA RID: 221114
			public const int TextProgress = 8;
		}
	}
}
