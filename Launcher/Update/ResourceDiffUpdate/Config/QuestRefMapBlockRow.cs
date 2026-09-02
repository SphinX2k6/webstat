using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044ED RID: 17645
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestRefMapBlockRow : TableBaseRow
	{
		// Token: 0x0602E857 RID: 190551 RVA: 0x00B06199 File Offset: 0x00B04399
		public override object GetId()
		{
			return this.QuestId;
		}

		// Token: 0x0401A6E8 RID: 108264
		public int QuestId;

		// Token: 0x0401A6E9 RID: 108265
		public List<int> MapBlockId = new List<int>();
	}
}
