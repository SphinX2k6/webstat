using System;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F5B RID: 28507
	public class ContinuousArea : Area
	{
		// Token: 0x06044FF8 RID: 282616 RVA: 0x011F553B File Offset: 0x011F373B
		public ContinuousArea(int ContinuousIndex, int StartCellIndex, int EndCellIndex, EArrowDirection ArrowDirection) : base(StartCellIndex, EndCellIndex, ArrowDirection)
		{
			this.ContinuousIndex = ContinuousIndex;
		}

		// Token: 0x040267B2 RID: 157618
		public int ContinuousIndex;
	}
}
