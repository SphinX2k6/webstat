using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056D6 RID: 22230
	public class MusicalInstrumentEnterParam
	{
		// Token: 0x170090C7 RID: 37063
		// (get) Token: 0x06038956 RID: 231766 RVA: 0x00E55DBF File Offset: 0x00E53FBF
		// (set) Token: 0x06038957 RID: 231767 RVA: 0x00E55DC7 File Offset: 0x00E53FC7
		public EInstrumentType Type { get; set; }

		// Token: 0x170090C8 RID: 37064
		// (get) Token: 0x06038958 RID: 231768 RVA: 0x00E55DD0 File Offset: 0x00E53FD0
		// (set) Token: 0x06038959 RID: 231769 RVA: 0x00E55DD8 File Offset: 0x00E53FD8
		public int? QteId { get; set; }
	}
}
