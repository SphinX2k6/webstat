using System;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E92 RID: 28306
	public class RingArea
	{
		// Token: 0x1700A3C5 RID: 41925
		// (get) Token: 0x06044A3A RID: 281146 RVA: 0x011D721C File Offset: 0x011D541C
		// (set) Token: 0x06044A3B RID: 281147 RVA: 0x011D7224 File Offset: 0x011D5424
		public int StartCellIndex { get; set; }

		// Token: 0x1700A3C6 RID: 41926
		// (get) Token: 0x06044A3C RID: 281148 RVA: 0x011D722D File Offset: 0x011D542D
		// (set) Token: 0x06044A3D RID: 281149 RVA: 0x011D7235 File Offset: 0x011D5435
		public int EndCellIndex { get; set; }

		// Token: 0x1700A3C7 RID: 41927
		// (get) Token: 0x06044A3E RID: 281150 RVA: 0x011D723E File Offset: 0x011D543E
		// (set) Token: 0x06044A3F RID: 281151 RVA: 0x011D7246 File Offset: 0x011D5446
		public EArrowDirection ArrowDirection { get; set; }

		// Token: 0x06044A40 RID: 281152 RVA: 0x011D724F File Offset: 0x011D544F
		public RingArea(int startCellIndex, int endCellIndex, EArrowDirection arrowDirection)
		{
			this.StartCellIndex = startCellIndex;
			this.EndCellIndex = endCellIndex;
			this.ArrowDirection = arrowDirection;
		}

		// Token: 0x06044A41 RID: 281153 RVA: 0x011D726C File Offset: 0x011D546C
		public void OnArrowDirectionReverse()
		{
			EArrowDirection arrowDirection = this.ArrowDirection;
			if (arrowDirection == EArrowDirection.Clockwise)
			{
				this.ArrowDirection = EArrowDirection.Anticlockwise;
				return;
			}
			if (arrowDirection != EArrowDirection.Anticlockwise)
			{
				return;
			}
			this.ArrowDirection = EArrowDirection.Clockwise;
		}
	}
}
