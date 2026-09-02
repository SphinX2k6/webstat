using System;

namespace CSharpScript.Game.Module.InstanceDungeon.ExchangeReward
{
	// Token: 0x02005C00 RID: 23552
	public class ExchangeShareData
	{
		// Token: 0x0603B971 RID: 244081 RVA: 0x00F1B137 File Offset: 0x00F19337
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x0603B972 RID: 244082 RVA: 0x00F1B13F File Offset: 0x00F1933F
		public int GetCount()
		{
			return this.Count;
		}

		// Token: 0x0603B973 RID: 244083 RVA: 0x00F1B147 File Offset: 0x00F19347
		public void Phrase(int id, int count)
		{
			this.Id = id;
			this.Count = count;
		}

		// Token: 0x040218A2 RID: 137378
		private int Id;

		// Token: 0x040218A3 RID: 137379
		private int Count;
	}
}
