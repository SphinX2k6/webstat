using System;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F5A RID: 28506
	public class Area
	{
		// Token: 0x06044FF6 RID: 282614 RVA: 0x011F54F0 File Offset: 0x011F36F0
		public Area(int StartCellIndex, int EndCellIndex, EArrowDirection ArrowDirection)
		{
			this.StartCellIndex = StartCellIndex;
			this.EndCellIndex = EndCellIndex;
			this.ArrowDirection = ArrowDirection;
		}

		// Token: 0x06044FF7 RID: 282615 RVA: 0x011F5510 File Offset: 0x011F3710
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

		// Token: 0x040267AF RID: 157615
		public int StartCellIndex;

		// Token: 0x040267B0 RID: 157616
		public int EndCellIndex;

		// Token: 0x040267B1 RID: 157617
		public EArrowDirection ArrowDirection;
	}
}
