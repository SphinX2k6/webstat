using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E31 RID: 20017
	public class TrapDefenseLevelStarItem : GridProxyAbstract<bool>
	{
		// Token: 0x06033BEF RID: 211951 RVA: 0x00CEF780 File Offset: 0x00CED980
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033BF0 RID: 211952 RVA: 0x00CEF7C8 File Offset: 0x00CED9C8
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data);
		}

		// Token: 0x0401DF3B RID: 122683
		public bool ItemData;

		// Token: 0x0200ADB4 RID: 44468
		private class EChildType
		{
			// Token: 0x04035F13 RID: 220947
			public const int ItemActive = 0;
		}
	}
}
