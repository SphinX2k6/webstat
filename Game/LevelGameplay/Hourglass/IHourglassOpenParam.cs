using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Hourglass
{
	// Token: 0x02006E5E RID: 28254
	[NullableContext(1)]
	public interface IHourglassOpenParam
	{
		// Token: 0x1700A38D RID: 41869
		// (get) Token: 0x06044928 RID: 280872
		// (set) Token: 0x06044929 RID: 280873
		IQteHourglass Config { get; set; }

		// Token: 0x1700A38E RID: 41870
		// (get) Token: 0x0604492A RID: 280874
		// (set) Token: 0x0604492B RID: 280875
		bool? AutoStartQte { get; set; }
	}
}
