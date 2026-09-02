using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044E6 RID: 17638
	[NullableContext(1)]
	[Nullable(0)]
	public class DownLoadSubPackageRow : TableBaseRow
	{
		// Token: 0x0602E83E RID: 190526 RVA: 0x00B05D0C File Offset: 0x00B03F0C
		public override object GetId()
		{
			return this.Id;
		}

		// Token: 0x0401A6CE RID: 108238
		public int Id;

		// Token: 0x0401A6CF RID: 108239
		public int Version;

		// Token: 0x0401A6D0 RID: 108240
		public int Type;

		// Token: 0x0401A6D1 RID: 108241
		public int BelongBranch = 1;

		// Token: 0x0401A6D2 RID: 108242
		public List<int> Area = new List<int>();

		// Token: 0x0401A6D3 RID: 108243
		public bool BelongKey;

		// Token: 0x0401A6D4 RID: 108244
		public string Title = "";
	}
}
