using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C66 RID: 23654
	public class InfrMaterialsDeliveryDoneItem : InfrMaterialsDeliveryLockItemBase
	{
		// Token: 0x0603BC3A RID: 244794 RVA: 0x00F257A8 File Offset: 0x00F239A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0200BCFD RID: 48381
		private class EChildType
		{
			// Token: 0x0403A3C4 RID: 238532
			public const int LockSprite = 0;

			// Token: 0x0403A3C5 RID: 238533
			public const int LockDescriptionText = 1;

			// Token: 0x0403A3C6 RID: 238534
			public const int FunctionButton = 2;
		}
	}
}
