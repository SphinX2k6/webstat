using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B6 RID: 25270
	[NullableContext(1)]
	public interface ITetrisGameSnapshot
	{
		// Token: 0x17009C9F RID: 40095
		// (get) Token: 0x0603F980 RID: 260480
		// (set) Token: 0x0603F981 RID: 260481
		TetrisCellData[][] BoardCells { get; set; }

		// Token: 0x17009CA0 RID: 40096
		// (get) Token: 0x0603F982 RID: 260482
		// (set) Token: 0x0603F983 RID: 260483
		[Nullable(new byte[]
		{
			1,
			2
		})]
		List<BlockInstance> HandShapes { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }

		// Token: 0x17009CA1 RID: 40097
		// (get) Token: 0x0603F984 RID: 260484
		// (set) Token: 0x0603F985 RID: 260485
		ITetrisScoreSnapshot ScoreSnapshot { get; set; }

		// Token: 0x17009CA2 RID: 40098
		// (get) Token: 0x0603F986 RID: 260486
		// (set) Token: 0x0603F987 RID: 260487
		ITetrisGemSnapshot GemSnapshot { get; set; }

		// Token: 0x17009CA3 RID: 40099
		// (get) Token: 0x0603F988 RID: 260488
		// (set) Token: 0x0603F989 RID: 260489
		int CurrentRoundIndex { get; set; }

		// Token: 0x17009CA4 RID: 40100
		// (get) Token: 0x0603F98A RID: 260490
		// (set) Token: 0x0603F98B RID: 260491
		int CurrentStageIndex { get; set; }

		// Token: 0x17009CA5 RID: 40101
		// (get) Token: 0x0603F98C RID: 260492
		// (set) Token: 0x0603F98D RID: 260493
		int PlaceCount { get; set; }
	}
}
