using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058B0 RID: 22704
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonLevelPlayPanelRewardData
	{
		// Token: 0x17009321 RID: 37665
		// (get) Token: 0x06039ADA RID: 236250 RVA: 0x00E9FBF7 File Offset: 0x00E9DDF7
		// (set) Token: 0x06039ADB RID: 236251 RVA: 0x00E9FBFF File Offset: 0x00E9DDFF
		public bool FinishRecord { get; set; }

		// Token: 0x17009322 RID: 37666
		// (get) Token: 0x06039ADC RID: 236252 RVA: 0x00E9FC08 File Offset: 0x00E9DE08
		// (set) Token: 0x06039ADD RID: 236253 RVA: 0x00E9FC10 File Offset: 0x00E9DE10
		public List<TItem> ItemList { get; set; }
	}
}
