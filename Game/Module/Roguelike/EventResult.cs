using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005103 RID: 20739
	[NullableContext(2)]
	[Nullable(0)]
	public class EventResult
	{
		// Token: 0x06035747 RID: 218951 RVA: 0x00D6ADAD File Offset: 0x00D68FAD
		public EventResult([Nullable(new byte[]
		{
			2,
			1
		})] List<RogueGainEntry> rogueGainEntryArray, Action<bool?> callback = null)
		{
			this.RogueGainEntryArray = rogueGainEntryArray;
			this.Callback = callback;
		}

		// Token: 0x0401EB48 RID: 125768
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RogueGainEntry> RogueGainEntryArray;

		// Token: 0x0401EB49 RID: 125769
		public Action<bool?> Callback;
	}
}
