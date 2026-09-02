using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054BB RID: 21691
	[NullableContext(1)]
	[Nullable(0)]
	public class DragInteractParam : IDragInteractParam
	{
		// Token: 0x17008E8A RID: 36490
		// (get) Token: 0x060373F5 RID: 226293 RVA: 0x00E03CDA File Offset: 0x00E01EDA
		// (set) Token: 0x060373F4 RID: 226292 RVA: 0x00E03CD1 File Offset: 0x00E01ED1
		public UUIDraggableComponent Draggable { get; set; }

		// Token: 0x17008E8B RID: 36491
		// (get) Token: 0x060373F7 RID: 226295 RVA: 0x00E03CEB File Offset: 0x00E01EEB
		// (set) Token: 0x060373F6 RID: 226294 RVA: 0x00E03CE2 File Offset: 0x00E01EE2
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<Vector2D> CallbackOnDrag { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008E8C RID: 36492
		// (get) Token: 0x060373F9 RID: 226297 RVA: 0x00E03CFC File Offset: 0x00E01EFC
		// (set) Token: 0x060373F8 RID: 226296 RVA: 0x00E03CF3 File Offset: 0x00E01EF3
		[Nullable(2)]
		public Action CallbackOnDown { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008E8D RID: 36493
		// (get) Token: 0x060373FB RID: 226299 RVA: 0x00E03D0D File Offset: 0x00E01F0D
		// (set) Token: 0x060373FA RID: 226298 RVA: 0x00E03D04 File Offset: 0x00E01F04
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<Vector2D> CallbackOnInertia { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
