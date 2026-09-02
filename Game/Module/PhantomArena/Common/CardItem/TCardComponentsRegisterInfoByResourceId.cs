using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x0200552F RID: 21807
	[NullableContext(1)]
	[Nullable(0)]
	public class TCardComponentsRegisterInfoByResourceId
	{
		// Token: 0x17008F30 RID: 36656
		// (get) Token: 0x060379EB RID: 227819 RVA: 0x00E1C9F4 File Offset: 0x00E1ABF4
		// (set) Token: 0x060379EC RID: 227820 RVA: 0x00E1C9FC File Offset: 0x00E1ABFC
		public ECardItemComponent ComponentType { get; set; }

		// Token: 0x17008F31 RID: 36657
		// (get) Token: 0x060379ED RID: 227821 RVA: 0x00E1CA05 File Offset: 0x00E1AC05
		// (set) Token: 0x060379EE RID: 227822 RVA: 0x00E1CA0D File Offset: 0x00E1AC0D
		public string ResourceId { get; set; }

		// Token: 0x17008F32 RID: 36658
		// (get) Token: 0x060379EF RID: 227823 RVA: 0x00E1CA16 File Offset: 0x00E1AC16
		// (set) Token: 0x060379F0 RID: 227824 RVA: 0x00E1CA1E File Offset: 0x00E1AC1E
		public UUIItem ParentItem { get; set; }

		// Token: 0x060379F1 RID: 227825 RVA: 0x00E1CA27 File Offset: 0x00E1AC27
		public TCardComponentsRegisterInfoByResourceId(ECardItemComponent componentType, string resourceId, UUIItem parentItem)
		{
			this.ComponentType = componentType;
			this.ResourceId = resourceId;
			this.ParentItem = parentItem;
		}

		// Token: 0x060379F2 RID: 227826 RVA: 0x00E1CA44 File Offset: 0x00E1AC44
		public void Deconstruct(out ECardItemComponent componentType, out string resourceId, out UUIItem parentItem)
		{
			componentType = this.ComponentType;
			resourceId = this.ResourceId;
			parentItem = this.ParentItem;
		}
	}
}
