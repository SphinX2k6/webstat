using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200666B RID: 26219
	public class MowingRiskInBattleRecordData
	{
		// Token: 0x060417F7 RID: 268279 RVA: 0x010D027D File Offset: 0x010CE47D
		public void Clear()
		{
			this.BasicBuffRecord.Clear();
			this.ProgressPanelBasicBuffCountRecord = 0;
		}

		// Token: 0x040249A4 RID: 149924
		[Nullable(1)]
		public HashSet<int> BasicBuffRecord = new HashSet<int>();

		// Token: 0x040249A5 RID: 149925
		public int ProgressPanelBasicBuffCountRecord;
	}
}
