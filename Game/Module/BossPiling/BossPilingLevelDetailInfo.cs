using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EEE RID: 24302
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingLevelDetailInfo : IBossPilingLevelDetailInfo
	{
		// Token: 0x17009A20 RID: 39456
		// (get) Token: 0x0603D0EE RID: 250094 RVA: 0x00F81230 File Offset: 0x00F7F430
		// (set) Token: 0x0603D0EF RID: 250095 RVA: 0x00F81238 File Offset: 0x00F7F438
		public bool IsFirst { get; set; }

		// Token: 0x17009A21 RID: 39457
		// (get) Token: 0x0603D0F0 RID: 250096 RVA: 0x00F81241 File Offset: 0x00F7F441
		// (set) Token: 0x0603D0F1 RID: 250097 RVA: 0x00F81249 File Offset: 0x00F7F449
		public List<BossPilingLevelDescInfo> LevelList { get; set; }
	}
}
