using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EE7 RID: 20199
	[NullableContext(1)]
	[Nullable(0)]
	public class TeleportContextHolder
	{
		// Token: 0x060342B0 RID: 213680 RVA: 0x00D0B6C4 File Offset: 0x00D098C4
		public TeleportContextHolder(TeleportContext context)
		{
		}

		// Token: 0x0401E1D7 RID: 123351
		public readonly TeleportContext TeleportContext = context;
	}
}
