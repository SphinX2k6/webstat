using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005764 RID: 22372
	[NullableContext(1)]
	public interface IGameQualityLoadInfo
	{
		// Token: 0x1700918B RID: 37259
		// (get) Token: 0x06038EEE RID: 233198
		// (set) Token: 0x06038EEF RID: 233199
		string Desc { get; set; }

		// Token: 0x1700918C RID: 37260
		// (get) Token: 0x06038EF0 RID: 233200
		// (set) Token: 0x06038EF1 RID: 233201
		int Percentage { get; set; }

		// Token: 0x1700918D RID: 37261
		// (get) Token: 0x06038EF2 RID: 233202
		// (set) Token: 0x06038EF3 RID: 233203
		string BarColor { get; set; }
	}
}
