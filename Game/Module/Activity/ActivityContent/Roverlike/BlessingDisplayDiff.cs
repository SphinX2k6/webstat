using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200640A RID: 25610
	[NullableContext(1)]
	[Nullable(0)]
	public class BlessingDisplayDiff : IBlessingDisplayDiff
	{
		// Token: 0x17009DD7 RID: 40407
		// (get) Token: 0x060404B8 RID: 263352 RVA: 0x0107A996 File Offset: 0x01078B96
		// (set) Token: 0x060404B9 RID: 263353 RVA: 0x0107A99E File Offset: 0x01078B9E
		public List<IRoverlikeBlessingSlotItemData> DataList { get; set; }

		// Token: 0x17009DD8 RID: 40408
		// (get) Token: 0x060404BA RID: 263354 RVA: 0x0107A9A7 File Offset: 0x01078BA7
		// (set) Token: 0x060404BB RID: 263355 RVA: 0x0107A9AF File Offset: 0x01078BAF
		public List<int> ChangedSlots { get; set; }

		// Token: 0x17009DD9 RID: 40409
		// (get) Token: 0x060404BC RID: 263356 RVA: 0x0107A9B8 File Offset: 0x01078BB8
		// (set) Token: 0x060404BD RID: 263357 RVA: 0x0107A9C0 File Offset: 0x01078BC0
		public int Count { get; set; }
	}
}
