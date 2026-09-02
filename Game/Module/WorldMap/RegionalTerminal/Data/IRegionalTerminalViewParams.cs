using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data
{
	// Token: 0x02004BF6 RID: 19446
	[NullableContext(2)]
	public interface IRegionalTerminalViewParams
	{
		// Token: 0x1700871E RID: 34590
		// (get) Token: 0x06032BEB RID: 207851
		// (set) Token: 0x06032BEC RID: 207852
		bool ShowLockPanel { get; set; }

		// Token: 0x1700871F RID: 34591
		// (get) Token: 0x06032BED RID: 207853
		// (set) Token: 0x06032BEE RID: 207854
		bool ShowButton { get; set; }

		// Token: 0x17008720 RID: 34592
		// (get) Token: 0x06032BEF RID: 207855
		// (set) Token: 0x06032BF0 RID: 207856
		Action LockClickFunc { get; set; }

		// Token: 0x17008721 RID: 34593
		// (get) Token: 0x06032BF1 RID: 207857
		// (set) Token: 0x06032BF2 RID: 207858
		string LockTxtId { get; set; }

		// Token: 0x17008722 RID: 34594
		// (get) Token: 0x06032BF3 RID: 207859
		// (set) Token: 0x06032BF4 RID: 207860
		string ButtonTxtId { get; set; }
	}
}
