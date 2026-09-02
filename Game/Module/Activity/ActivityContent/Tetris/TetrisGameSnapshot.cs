using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B7 RID: 25271
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisGameSnapshot : ITetrisGameSnapshot
	{
		// Token: 0x17009CA6 RID: 40102
		// (get) Token: 0x0603F98E RID: 260494 RVA: 0x0104C579 File Offset: 0x0104A779
		// (set) Token: 0x0603F98F RID: 260495 RVA: 0x0104C581 File Offset: 0x0104A781
		public TetrisCellData[][] BoardCells { get; set; }

		// Token: 0x17009CA7 RID: 40103
		// (get) Token: 0x0603F990 RID: 260496 RVA: 0x0104C58A File Offset: 0x0104A78A
		// (set) Token: 0x0603F991 RID: 260497 RVA: 0x0104C592 File Offset: 0x0104A792
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public List<BlockInstance> HandShapes { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }

		// Token: 0x17009CA8 RID: 40104
		// (get) Token: 0x0603F992 RID: 260498 RVA: 0x0104C59B File Offset: 0x0104A79B
		// (set) Token: 0x0603F993 RID: 260499 RVA: 0x0104C5A3 File Offset: 0x0104A7A3
		public ITetrisScoreSnapshot ScoreSnapshot { get; set; }

		// Token: 0x17009CA9 RID: 40105
		// (get) Token: 0x0603F994 RID: 260500 RVA: 0x0104C5AC File Offset: 0x0104A7AC
		// (set) Token: 0x0603F995 RID: 260501 RVA: 0x0104C5B4 File Offset: 0x0104A7B4
		public ITetrisGemSnapshot GemSnapshot { get; set; }

		// Token: 0x17009CAA RID: 40106
		// (get) Token: 0x0603F996 RID: 260502 RVA: 0x0104C5BD File Offset: 0x0104A7BD
		// (set) Token: 0x0603F997 RID: 260503 RVA: 0x0104C5C5 File Offset: 0x0104A7C5
		public int CurrentRoundIndex { get; set; }

		// Token: 0x17009CAB RID: 40107
		// (get) Token: 0x0603F998 RID: 260504 RVA: 0x0104C5CE File Offset: 0x0104A7CE
		// (set) Token: 0x0603F999 RID: 260505 RVA: 0x0104C5D6 File Offset: 0x0104A7D6
		public int CurrentStageIndex { get; set; }

		// Token: 0x17009CAC RID: 40108
		// (get) Token: 0x0603F99A RID: 260506 RVA: 0x0104C5DF File Offset: 0x0104A7DF
		// (set) Token: 0x0603F99B RID: 260507 RVA: 0x0104C5E7 File Offset: 0x0104A7E7
		public int PlaceCount { get; set; }
	}
}
