using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200549B RID: 21659
	public class PhantomArenaReportCardInfo
	{
		// Token: 0x060371B7 RID: 225719 RVA: 0x00DFD97A File Offset: 0x00DFBB7A
		public PhantomArenaReportCardInfo(int cost)
		{
		}

		// Token: 0x0401FBB2 RID: 129970
		[Nullable(1)]
		public List<int> CardIdList = new List<int>();

		// Token: 0x0401FBB3 RID: 129971
		public int Cost = cost;
	}
}
