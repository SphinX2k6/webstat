using System;

namespace CSharpScript.Game.Module.InstanceDungeon.ExchangeReward
{
	// Token: 0x02005BFF RID: 23551
	public class ExchangeRewardData
	{
		// Token: 0x0603B96D RID: 244077 RVA: 0x00F1B10F File Offset: 0x00F1930F
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x0603B96E RID: 244078 RVA: 0x00F1B117 File Offset: 0x00F19317
		public int GetCount()
		{
			return this.Count;
		}

		// Token: 0x0603B96F RID: 244079 RVA: 0x00F1B11F File Offset: 0x00F1931F
		public void Phrase(int id, int count)
		{
			this.Id = id;
			this.Count = count;
		}

		// Token: 0x040218A0 RID: 137376
		private int Id;

		// Token: 0x040218A1 RID: 137377
		private int Count;
	}
}
