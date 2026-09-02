using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044F3 RID: 17651
	[NullableContext(1)]
	[Nullable(0)]
	public class RecommendPackRow : TableBaseRow
	{
		// Token: 0x0602E86C RID: 190572 RVA: 0x00B064A9 File Offset: 0x00B046A9
		public override object GetId()
		{
			return this.Id;
		}

		// Token: 0x0401A6F1 RID: 108273
		public int Id;

		// Token: 0x0401A6F2 RID: 108274
		public List<int> FinishQuest = new List<int>();

		// Token: 0x0401A6F3 RID: 108275
		public List<int> UnfinishQuest = new List<int>();

		// Token: 0x0401A6F4 RID: 108276
		public List<int> Source = new List<int>();

		// Token: 0x0401A6F5 RID: 108277
		public List<int> VideoQuestId = new List<int>();
	}
}
