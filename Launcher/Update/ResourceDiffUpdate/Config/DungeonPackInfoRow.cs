using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044E8 RID: 17640
	[NullableContext(1)]
	[Nullable(0)]
	public class DungeonPackInfoRow : TableBaseRow
	{
		// Token: 0x0602E845 RID: 190533 RVA: 0x00B05E69 File Offset: 0x00B04069
		public override object GetId()
		{
			return this.DungeonId;
		}

		// Token: 0x0401A6D5 RID: 108245
		public int DungeonId;

		// Token: 0x0401A6D6 RID: 108246
		public string Umap = "";

		// Token: 0x0401A6D7 RID: 108247
		public List<int> OwnerBlockIds = new List<int>();

		// Token: 0x0401A6D8 RID: 108248
		public string BlockPakName = "";

		// Token: 0x0401A6D9 RID: 108249
		public List<int> ReachableBlockIds = new List<int>();
	}
}
