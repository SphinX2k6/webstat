using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C62 RID: 23650
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfrMaterialsDeliveryEffectItem : GridProxyAbstract<string>
	{
		// Token: 0x0603BBFD RID: 244733 RVA: 0x00F23A9C File Offset: 0x00F21C9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BBFE RID: 244734 RVA: 0x00F23AE4 File Offset: 0x00F21CE4
		[NullableContext(1)]
		public override void Refresh(string data, bool isSelected, int gridIndex)
		{
			base.GetText(0).SetText(data, true);
		}

		// Token: 0x0200BCED RID: 48365
		private class EChildType
		{
			// Token: 0x0403A35F RID: 238431
			public const int TextEffect = 0;
		}
	}
}
