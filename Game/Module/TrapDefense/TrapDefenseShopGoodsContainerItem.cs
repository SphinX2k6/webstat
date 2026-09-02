using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E4C RID: 20044
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseShopGoodsContainerItem : GridProxyAbstract<TrapDefenseShopGoodsListData>
	{
		// Token: 0x06033CD9 RID: 212185 RVA: 0x00CF3610 File Offset: 0x00CF1810
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033CDA RID: 212186 RVA: 0x00CF369A File Offset: 0x00CF189A
		protected override void OnStart()
		{
			this.GridLayout = new GenericLayout<TrapDefenseShopGoodsItem, ITrapDefenseShopGoods>(base.GetGridLayout(1), () => new TrapDefenseShopGoodsItem(), null, false, true);
		}

		// Token: 0x06033CDB RID: 212187 RVA: 0x00CF36D0 File Offset: 0x00CF18D0
		public override void Refresh(TrapDefenseShopGoodsListData data, bool isSelected, int gridIndex)
		{
			if (data.Type == ETrapDefenseShopGoodsType.Item)
			{
				int ownItemTypeCount = ModelBase<TrapDefenseModel>.Instance.BattleInventoryData.GetOwnItemTypeCount();
				int value = 8;
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText text = base.GetText(0);
				string textStringId = ETrapDefenseTextKey.ShopGoodsItem.ToString();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(ownItemTypeCount);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), ETrapDefenseTextKey.ShopGoodsBuff.ToString(), Array.Empty<object>());
			}
			this.GridLayout.RefreshByData(data.GoodsList, null, false);
		}

		// Token: 0x0401DF9D RID: 122781
		private GenericLayout<TrapDefenseShopGoodsItem, ITrapDefenseShopGoods> GridLayout;

		// Token: 0x0200ADE3 RID: 44515
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035FEB RID: 221163
			public const int TextTitle = 0;

			// Token: 0x04035FEC RID: 221164
			public const int LayoutItems = 1;

			// Token: 0x04035FED RID: 221165
			public const int ItemGrid = 2;
		}
	}
}
