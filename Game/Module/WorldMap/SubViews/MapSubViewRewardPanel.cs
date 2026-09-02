using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B58 RID: 19288
	[NullableContext(1)]
	[Nullable(0)]
	public class MapSubViewRewardPanel : UiPanelBase
	{
		// Token: 0x06032628 RID: 206376 RVA: 0x00C9BD28 File Offset: 0x00C99F28
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

		// Token: 0x06032629 RID: 206377 RVA: 0x00C9BDB2 File Offset: 0x00C99FB2
		protected override void OnStart()
		{
			this.ConsumeList = new GenericLayoutNew<MapSubViewRewardItem>(base.GetGridLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MapSubViewRewardItem>(this.CreatePropItem), null);
		}

		// Token: 0x0603262A RID: 206378 RVA: 0x00C9BDD4 File Offset: 0x00C99FD4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private ILayoutItem<MapSubViewRewardItem> CreatePropItem(object data, UUIItem uiitem, int index)
		{
			MapSubViewRewardItem mapSubViewRewardItem = new MapSubViewRewardItem();
			mapSubViewRewardItem.Initialize(uiitem.GetOwner());
			mapSubViewRewardItem.Refresh((TItem)data, false, index);
			return new LayoutItem<MapSubViewRewardItem>
			{
				Key = index,
				Value = mapSubViewRewardItem
			};
		}

		// Token: 0x0603262B RID: 206379 RVA: 0x00C9BE1C File Offset: 0x00C9A01C
		public void RebuildRewardsByData(TItem[] data)
		{
			this.ConsumeList.RebuildLayoutByDataNew<TItem>(data, null);
		}

		// Token: 0x0603262C RID: 206380 RVA: 0x00C9BE3E File Offset: 0x00C9A03E
		public void SetTitleNewTxt(string newTxtId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), newTxtId, Array.Empty<object>());
		}

		// Token: 0x0401D6A8 RID: 120488
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<MapSubViewRewardItem> ConsumeList;

		// Token: 0x0200AC27 RID: 44071
		[NullableContext(0)]
		public static class ERewardItemBarChildCom
		{
			// Token: 0x040358A9 RID: 219305
			public const int UiTextInstanceTitle = 0;

			// Token: 0x040358AA RID: 219306
			public const int UiItemContainer = 1;

			// Token: 0x040358AB RID: 219307
			public const int UiItemItem = 2;
		}
	}
}
