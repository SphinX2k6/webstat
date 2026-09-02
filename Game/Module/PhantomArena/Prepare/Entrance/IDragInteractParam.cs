using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054BA RID: 21690
	[NullableContext(1)]
	public interface IDragInteractParam
	{
		// Token: 0x17008E86 RID: 36486
		// (get) Token: 0x060373ED RID: 226285
		// (set) Token: 0x060373EC RID: 226284
		UUIDraggableComponent Draggable { get; set; }

		// Token: 0x17008E87 RID: 36487
		// (get) Token: 0x060373EF RID: 226287
		// (set) Token: 0x060373EE RID: 226286
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<Vector2D> CallbackOnDrag { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008E88 RID: 36488
		// (get) Token: 0x060373F1 RID: 226289
		// (set) Token: 0x060373F0 RID: 226288
		[Nullable(2)]
		Action CallbackOnDown { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008E89 RID: 36489
		// (get) Token: 0x060373F3 RID: 226291
		// (set) Token: 0x060373F2 RID: 226290
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<Vector2D> CallbackOnInertia { [return: Nullable(new byte[]
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
