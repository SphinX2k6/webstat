using System;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x0200618D RID: 24973
	public class AdventureTaskRecord
	{
		// Token: 0x0603F191 RID: 258449 RVA: 0x0102EA44 File Offset: 0x0102CC44
		public AdventureTaskRecord(AdventureTask adventureBase, AdventreTaskSate status)
		{
			this.AdventureTaskBase = adventureBase;
			this.Status = status;
		}

		// Token: 0x0603F192 RID: 258450 RVA: 0x0102EA5A File Offset: 0x0102CC5A
		public int GetTotalNum()
		{
			return this.AdventureTaskBase.NeedProgress;
		}

		// Token: 0x04023670 RID: 145008
		public AdventureTask AdventureTaskBase;

		// Token: 0x04023671 RID: 145009
		public AdventreTaskSate Status;

		// Token: 0x04023672 RID: 145010
		public int Progress;
	}
}
