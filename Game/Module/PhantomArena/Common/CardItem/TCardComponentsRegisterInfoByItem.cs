using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x0200552E RID: 21806
	[NullableContext(1)]
	[Nullable(0)]
	public class TCardComponentsRegisterInfoByItem
	{
		// Token: 0x17008F2E RID: 36654
		// (get) Token: 0x060379E5 RID: 227813 RVA: 0x00E1C9AA File Offset: 0x00E1ABAA
		// (set) Token: 0x060379E6 RID: 227814 RVA: 0x00E1C9B2 File Offset: 0x00E1ABB2
		public ECardItemComponent ComponentType { get; set; }

		// Token: 0x17008F2F RID: 36655
		// (get) Token: 0x060379E7 RID: 227815 RVA: 0x00E1C9BB File Offset: 0x00E1ABBB
		// (set) Token: 0x060379E8 RID: 227816 RVA: 0x00E1C9C3 File Offset: 0x00E1ABC3
		public UUIItem Item { get; set; }

		// Token: 0x060379E9 RID: 227817 RVA: 0x00E1C9CC File Offset: 0x00E1ABCC
		public TCardComponentsRegisterInfoByItem(ECardItemComponent componentType, UUIItem item)
		{
			this.ComponentType = componentType;
			this.Item = item;
		}

		// Token: 0x060379EA RID: 227818 RVA: 0x00E1C9E2 File Offset: 0x00E1ABE2
		public void Deconstruct(out ECardItemComponent componentType, out UUIItem item)
		{
			componentType = this.ComponentType;
			item = this.Item;
		}
	}
}
