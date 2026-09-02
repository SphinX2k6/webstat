using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Container
{
	// Token: 0x020058F2 RID: 22770
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkSpritePoolObj : IMarkSpritePoolObj
	{
		// Token: 0x170093BD RID: 37821
		// (get) Token: 0x06039CA2 RID: 236706 RVA: 0x00EA3462 File Offset: 0x00EA1662
		// (set) Token: 0x06039CA3 RID: 236707 RVA: 0x00EA346A File Offset: 0x00EA166A
		public string SpritePath { get; set; }

		// Token: 0x170093BE RID: 37822
		// (get) Token: 0x06039CA4 RID: 236708 RVA: 0x00EA3473 File Offset: 0x00EA1673
		// (set) Token: 0x06039CA5 RID: 236709 RVA: 0x00EA347B File Offset: 0x00EA167B
		public double RecycleTimeStamp { get; set; }

		// Token: 0x170093BF RID: 37823
		// (get) Token: 0x06039CA6 RID: 236710 RVA: 0x00EA3484 File Offset: 0x00EA1684
		// (set) Token: 0x06039CA7 RID: 236711 RVA: 0x00EA348C File Offset: 0x00EA168C
		public ULGUISpriteData_BaseObject Obj { get; set; }

		// Token: 0x170093C0 RID: 37824
		// (get) Token: 0x06039CA8 RID: 236712 RVA: 0x00EA3495 File Offset: 0x00EA1695
		// (set) Token: 0x06039CA9 RID: 236713 RVA: 0x00EA349D File Offset: 0x00EA169D
		public int Ref { get; set; }
	}
}
