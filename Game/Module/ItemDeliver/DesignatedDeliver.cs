using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B6C RID: 23404
	public class DesignatedDeliver : Deliver
	{
		// Token: 0x0603B2F5 RID: 242421 RVA: 0x00EF9D5A File Offset: 0x00EF7F5A
		public DesignatedDeliver()
		{
			this.Type = EDeliverType.DesignatedDeliver;
			this.ItemSlotInfo = new List<DesignatedDeliverSlot>();
		}

		// Token: 0x040215C6 RID: 136646
		[Nullable(1)]
		public List<DesignatedDeliverSlot> ItemSlotInfo;
	}
}
