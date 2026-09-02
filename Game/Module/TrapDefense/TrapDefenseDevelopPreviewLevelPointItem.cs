using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E1C RID: 19996
	public class TrapDefenseDevelopPreviewLevelPointItem : GridProxyAbstract<bool>
	{
		// Token: 0x06033B53 RID: 211795 RVA: 0x00CEC580 File Offset: 0x00CEA780
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

		// Token: 0x06033B54 RID: 211796 RVA: 0x00CEC5C8 File Offset: 0x00CEA7C8
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data);
		}

		// Token: 0x0200AD97 RID: 44439
		private class ELevelPoint
		{
			// Token: 0x04035E86 RID: 220806
			public const int Point = 0;
		}
	}
}
