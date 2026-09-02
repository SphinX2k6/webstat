using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044EA RID: 17642
	[NullableContext(1)]
	[Nullable(0)]
	public class MapBlockInfoRow : TableBaseRow
	{
		// Token: 0x0602E84C RID: 190540 RVA: 0x00B06000 File Offset: 0x00B04200
		public override object GetId()
		{
			return this.BlockId;
		}

		// Token: 0x0401A6DA RID: 108250
		public int BlockId;

		// Token: 0x0401A6DB RID: 108251
		public int MapId;

		// Token: 0x0401A6DC RID: 108252
		public string PackName = "";

		// Token: 0x0401A6DD RID: 108253
		public string BlockDatalayer = "";

		// Token: 0x0401A6DE RID: 108254
		public string RegionName = "";

		// Token: 0x0401A6DF RID: 108255
		public List<global::Vector2D> RegionBoxes = new List<global::Vector2D>();
	}
}
