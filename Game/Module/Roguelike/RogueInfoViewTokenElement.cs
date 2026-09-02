using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005176 RID: 20854
	public class RogueInfoViewTokenElement : MediumItemGridComponent
	{
		// Token: 0x06035AA0 RID: 219808 RVA: 0x00D7ADD1 File Offset: 0x00D78FD1
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemRogueElement";
		}

		// Token: 0x06035AA1 RID: 219809 RVA: 0x00D7ADD8 File Offset: 0x00D78FD8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035AA2 RID: 219810 RVA: 0x00D7AE20 File Offset: 0x00D79020
		protected override void OnActivate()
		{
			this.GenericLayout = new GenericLayout<CommonElementItem, int>(base.GetVerticalLayout(0), new Func<CommonElementItem>(this.CreateElement), null, false, true);
		}

		// Token: 0x06035AA3 RID: 219811 RVA: 0x00D7AE43 File Offset: 0x00D79043
		[NullableContext(1)]
		private CommonElementItem CreateElement()
		{
			return new CommonElementItem();
		}

		// Token: 0x06035AA4 RID: 219812 RVA: 0x00D7AE4C File Offset: 0x00D7904C
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
			ElementInfo elementInfo = sortElementInfoArrayByCount[0];
			List<int> list = new List<int>();
			for (int i = 0; i < elementInfo.Count; i++)
			{
				list.Add(elementInfo.ElementId);
			}
			GenericLayout<CommonElementItem, int> genericLayout = this.GenericLayout;
			if (genericLayout == null)
			{
				return;
			}
			genericLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0401ECEF RID: 126191
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonElementItem, int> GenericLayout;

		// Token: 0x0200B12B RID: 45355
		private class ERogueInfoViewTokenElement
		{
			// Token: 0x04036F3C RID: 225084
			public const int Layout = 0;
		}
	}
}
