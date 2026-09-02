using System;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D9F RID: 23967
	public class DreamLinkRewardData
	{
		// Token: 0x0603C58E RID: 247182 RVA: 0x00F50749 File Offset: 0x00F4E949
		public DreamLinkRewardData(int id)
		{
			this.Id = id;
		}

		// Token: 0x04021EE6 RID: 138982
		public int Id;

		// Token: 0x04021EE7 RID: 138983
		public EActivityTaskState Status = EActivityTaskState.Active;

		// Token: 0x04021EE8 RID: 138984
		public int Current;

		// Token: 0x04021EE9 RID: 138985
		public int Target = 1;
	}
}
