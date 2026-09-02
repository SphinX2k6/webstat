using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x02005400 RID: 21504
	[NullableContext(1)]
	[Nullable(0)]
	public class TalkRecord
	{
		// Token: 0x17008E0B RID: 36363
		// (get) Token: 0x06036E80 RID: 224896 RVA: 0x00DEC8D5 File Offset: 0x00DEAAD5
		// (set) Token: 0x06036E81 RID: 224897 RVA: 0x00DEC8DD File Offset: 0x00DEAADD
		public ITalkItem TalkItem { get; set; }

		// Token: 0x17008E0C RID: 36364
		// (get) Token: 0x06036E82 RID: 224898 RVA: 0x00DEC8E6 File Offset: 0x00DEAAE6
		// (set) Token: 0x06036E83 RID: 224899 RVA: 0x00DEC8EE File Offset: 0x00DEAAEE
		public bool IsOption { get; set; }

		// Token: 0x17008E0D RID: 36365
		// (get) Token: 0x06036E84 RID: 224900 RVA: 0x00DEC8F7 File Offset: 0x00DEAAF7
		// (set) Token: 0x06036E85 RID: 224901 RVA: 0x00DEC8FF File Offset: 0x00DEAAFF
		public int? OptionIndex { get; set; }
	}
}
