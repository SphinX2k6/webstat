using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x02005014 RID: 20500
	[NullableContext(1)]
	[Nullable(0)]
	public class RouletteTipsItemPanel : UiPanelBase
	{
		// Token: 0x06034D5D RID: 216413 RVA: 0x00D43D7C File Offset: 0x00D41F7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034D5E RID: 216414 RVA: 0x00D43E06 File Offset: 0x00D42006
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<CommonItemSmallItemGridWrap, ItemRefreshData>(base.GetGridLayout(0), new Func<CommonItemSmallItemGridWrap>(this.InitGridItem), null, false, true);
		}

		// Token: 0x06034D5F RID: 216415 RVA: 0x00D43E29 File Offset: 0x00D42029
		private CommonItemSmallItemGridWrap InitGridItem()
		{
			return new CommonItemSmallItemGridWrap();
		}

		// Token: 0x06034D60 RID: 216416 RVA: 0x00D43E30 File Offset: 0x00D42030
		public void RefreshTitle(string textId)
		{
			base.GetText(2).ShowTextNew(textId);
		}

		// Token: 0x06034D61 RID: 216417 RVA: 0x00D43E3F File Offset: 0x00D4203F
		public void RefreshItemPanel(List<ItemRefreshData> dataList)
		{
			this.ItemLayout.RefreshByData(dataList, null, false);
		}

		// Token: 0x0401E74B RID: 124747
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CommonItemSmallItemGridWrap, ItemRefreshData> ItemLayout;
	}
}
