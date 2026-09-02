using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044EF RID: 17647
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestRefVideoConfigRow : TableBaseRow
	{
		// Token: 0x0602E85E RID: 190558 RVA: 0x00B06290 File Offset: 0x00B04490
		public override object GetId()
		{
			return this.Id;
		}

		// Token: 0x0401A6EA RID: 108266
		public int Id;

		// Token: 0x0401A6EB RID: 108267
		public int QuestId;

		// Token: 0x0401A6EC RID: 108268
		public int GirlOrBoy;

		// Token: 0x0401A6ED RID: 108269
		public string PakName = "";
	}
}
