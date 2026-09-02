using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005179 RID: 20857
	public class RogueInfoViewTokenDetailGridBottom : MediumItemGridComponent
	{
		// Token: 0x06035AAE RID: 219822 RVA: 0x00D7B0AD File Offset: 0x00D792AD
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemRogue";
		}

		// Token: 0x06035AAF RID: 219823 RVA: 0x00D7B0B4 File Offset: 0x00D792B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035AB0 RID: 219824 RVA: 0x00D7B11D File Offset: 0x00D7931D
		protected override void OnActivate()
		{
			this.CommonElementItem = new CommonElementItem();
			this.CommonElementItem.CreateThenShowByActorAsync(base.GetItem(0).GetOwner());
		}

		// Token: 0x06035AB1 RID: 219825 RVA: 0x00D7B144 File Offset: 0x00D79344
		[NullableContext(2)]
		protected override void OnRefresh(object param = null)
		{
			RogueGainEntry rogueGainEntry = param as RogueGainEntry;
			if (rogueGainEntry == null)
			{
				return;
			}
			List<ElementInfo> sortElementInfoArrayByCount = rogueGainEntry.GetSortElementInfoArrayByCount(false);
			if (sortElementInfoArrayByCount.Count <= 0)
			{
				return;
			}
			this.CommonElementItem.Update(sortElementInfoArrayByCount[0].ElementId);
			this.CommonElementItem.RefreshPanel();
			base.GetText(1).SetText(sortElementInfoArrayByCount[0].Count.ToString(), true);
		}

		// Token: 0x0401ECF0 RID: 126192
		[Nullable(2)]
		private CommonElementItem CommonElementItem;

		// Token: 0x0200B12E RID: 45358
		private class ERogueInfoViewTokenDetailGridBottomDefine
		{
			// Token: 0x04036F40 RID: 225088
			public const int ElementItem = 0;

			// Token: 0x04036F41 RID: 225089
			public const int ElementNumText = 1;
		}
	}
}
