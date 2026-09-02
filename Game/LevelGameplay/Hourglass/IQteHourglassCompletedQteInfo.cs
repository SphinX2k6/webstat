using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Hourglass
{
	// Token: 0x02006E5B RID: 28251
	[NullableContext(2)]
	public interface IQteHourglassCompletedQteInfo
	{
		// Token: 0x1700A383 RID: 41859
		// (get) Token: 0x06044904 RID: 280836
		// (set) Token: 0x06044905 RID: 280837
		int HandleId { get; set; }

		// Token: 0x1700A384 RID: 41860
		// (get) Token: 0x06044906 RID: 280838
		// (set) Token: 0x06044907 RID: 280839
		int QteId { get; set; }

		// Token: 0x1700A385 RID: 41861
		// (get) Token: 0x06044908 RID: 280840
		// (set) Token: 0x06044909 RID: 280841
		bool IsSuccess { get; set; }

		// Token: 0x1700A386 RID: 41862
		// (get) Token: 0x0604490A RID: 280842
		// (set) Token: 0x0604490B RID: 280843
		bool IsFail { get; set; }

		// Token: 0x1700A387 RID: 41863
		// (get) Token: 0x0604490C RID: 280844
		// (set) Token: 0x0604490D RID: 280845
		Vector StartPos { get; set; }
	}
}
