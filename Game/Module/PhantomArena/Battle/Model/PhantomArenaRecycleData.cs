using System;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005603 RID: 22019
	public class PhantomArenaRecycleData
	{
		// Token: 0x1700904D RID: 36941
		// (get) Token: 0x0603824E RID: 229966 RVA: 0x00E38269 File Offset: 0x00E36469
		public bool IsSeal
		{
			get
			{
				return this.SealRemainRound > 0;
			}
		}

		// Token: 0x0402013D RID: 131389
		public int SealRemainRound;
	}
}
