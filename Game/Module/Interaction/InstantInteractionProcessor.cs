using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B99 RID: 23449
	public class InstantInteractionProcessor : InteractionProcessor
	{
		// Token: 0x0603B4D8 RID: 242904 RVA: 0x00F03DC7 File Offset: 0x00F01FC7
		[NullableContext(2)]
		public InstantInteractionProcessor(Entity entity, int index) : base(entity, index, EInteractionType.Instant)
		{
		}

		// Token: 0x0603B4D9 RID: 242905 RVA: 0x00F03DD2 File Offset: 0x00F01FD2
		public override void OnPress()
		{
		}

		// Token: 0x0603B4DA RID: 242906 RVA: 0x00F03DD4 File Offset: 0x00F01FD4
		public override void OnRelease()
		{
			base.TriggerComplete();
		}

		// Token: 0x0603B4DB RID: 242907 RVA: 0x00F03DDC File Offset: 0x00F01FDC
		public override void OnReset()
		{
		}
	}
}
