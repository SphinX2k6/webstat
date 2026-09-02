using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B6B RID: 23403
	public class ArbitraryDeliver : Deliver
	{
		// Token: 0x0603B2F4 RID: 242420 RVA: 0x00EF9D40 File Offset: 0x00EF7F40
		public ArbitraryDeliver()
		{
			this.Type = EDeliverType.ArbitraryDeliver;
			this.ItemSlotInfo = new List<ArbitraryDiliverSlot>();
		}

		// Token: 0x040215C5 RID: 136645
		[Nullable(1)]
		public List<ArbitraryDiliverSlot> ItemSlotInfo;
	}
}
