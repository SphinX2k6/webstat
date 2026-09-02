using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C55 RID: 23637
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfrActivityProgressItem : GridProxyAbstract<List<bool>>
	{
		// Token: 0x0603BB80 RID: 244608 RVA: 0x00F20BD8 File Offset: 0x00F1EDD8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BB81 RID: 244609 RVA: 0x00F20C41 File Offset: 0x00F1EE41
		[NullableContext(1)]
		public override void Refresh(List<bool> pointState, bool isSelected, int gridIndex)
		{
			base.GetItem(0).SetUIActive(pointState[0]);
			base.GetItem(1).SetUIActive(pointState[1]);
		}

		// Token: 0x0200BCCF RID: 48335
		private class EComponent
		{
			// Token: 0x0403A2B8 RID: 238264
			public const int PanelLeft = 0;

			// Token: 0x0403A2B9 RID: 238265
			public const int PanelRight = 1;
		}
	}
}
