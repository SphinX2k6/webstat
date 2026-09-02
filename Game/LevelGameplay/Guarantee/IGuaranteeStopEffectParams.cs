using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E67 RID: 28263
	[NullableContext(2)]
	public interface IGuaranteeStopEffectParams
	{
		// Token: 0x1700A391 RID: 41873
		// (get) Token: 0x0604495E RID: 280926
		// (set) Token: 0x0604495F RID: 280927
		int? EffectId { get; set; }

		// Token: 0x1700A392 RID: 41874
		// (get) Token: 0x06044960 RID: 280928
		// (set) Token: 0x06044961 RID: 280929
		int? ScreenEffectHandle { get; set; }

		// Token: 0x1700A393 RID: 41875
		// (get) Token: 0x06044962 RID: 280930
		// (set) Token: 0x06044963 RID: 280931
		string Mp4Name { get; set; }
	}
}
