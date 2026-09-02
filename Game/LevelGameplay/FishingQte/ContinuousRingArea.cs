using System;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E93 RID: 28307
	public class ContinuousRingArea : RingArea
	{
		// Token: 0x1700A3C8 RID: 41928
		// (get) Token: 0x06044A42 RID: 281154 RVA: 0x011D7297 File Offset: 0x011D5497
		// (set) Token: 0x06044A43 RID: 281155 RVA: 0x011D729F File Offset: 0x011D549F
		public int ContinuousIndex { get; set; }

		// Token: 0x06044A44 RID: 281156 RVA: 0x011D72A8 File Offset: 0x011D54A8
		public ContinuousRingArea(int continuousIndex, int startCellIndex, int endCellIndex, EArrowDirection arrowDirection) : base(startCellIndex, endCellIndex, arrowDirection)
		{
			this.ContinuousIndex = continuousIndex;
		}
	}
}
