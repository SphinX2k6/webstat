using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EF8 RID: 20216
	public class SlidingBlocksDefine
	{
		// Token: 0x0401E25E RID: 123486
		[Nullable(1)]
		public const string BoxMeshPath = "/Engine/BasicShapes/Cube.Cube";

		// Token: 0x0401E25F RID: 123487
		public const int TetrominoFallingSpeed = 1;

		// Token: 0x0200AF15 RID: 44821
		public enum EGameStage
		{
			// Token: 0x04036556 RID: 222550
			None,
			// Token: 0x04036557 RID: 222551
			Init,
			// Token: 0x04036558 RID: 222552
			GameRunning,
			// Token: 0x04036559 RID: 222553
			WaitSettlement,
			// Token: 0x0403655A RID: 222554
			Settlement,
			// Token: 0x0403655B RID: 222555
			WaitDestroy,
			// Token: 0x0403655C RID: 222556
			GameEnd
		}

		// Token: 0x0200AF16 RID: 44822
		public enum EGameEndReason
		{
			// Token: 0x0403655E RID: 222558
			None,
			// Token: 0x0403655F RID: 222559
			InitFail,
			// Token: 0x04036560 RID: 222560
			NormalModeEnd,
			// Token: 0x04036561 RID: 222561
			MainLineModeEnd,
			// Token: 0x04036562 RID: 222562
			SqueezePlayer,
			// Token: 0x04036563 RID: 222563
			MinoOverHeight,
			// Token: 0x04036564 RID: 222564
			ClickClose
		}

		// Token: 0x0200AF17 RID: 44823
		[EnumExtensions]
		public enum EAddMinoReason
		{
			// Token: 0x04036566 RID: 222566
			[EnumStringMember("LineClearFall")]
			LineClearFall,
			// Token: 0x04036567 RID: 222567
			[EnumStringMember("CreatePresetMino")]
			CreatePresetMino,
			// Token: 0x04036568 RID: 222568
			[EnumStringMember("TetrominoLock")]
			TetrominoLock
		}

		// Token: 0x0200AF18 RID: 44824
		[EnumExtensions]
		public enum ERemoveMinoReason
		{
			// Token: 0x0403656A RID: 222570
			[EnumStringMember("LineClearFall")]
			LineClearFall,
			// Token: 0x0403656B RID: 222571
			[EnumStringMember("LineClear")]
			LineClear
		}

		// Token: 0x0200AF19 RID: 44825
		public enum ECheckCanMoveResult
		{
			// Token: 0x0403656D RID: 222573
			None,
			// Token: 0x0403656E RID: 222574
			BeyondGrid,
			// Token: 0x0403656F RID: 222575
			Occupation
		}

		// Token: 0x0200AF1A RID: 44826
		[EnumExtensions]
		public enum ETetrominoType
		{
			// Token: 0x04036571 RID: 222577
			[EnumStringMember("I块")]
			I块,
			// Token: 0x04036572 RID: 222578
			[EnumStringMember("J块")]
			J块,
			// Token: 0x04036573 RID: 222579
			[EnumStringMember("L块")]
			L块,
			// Token: 0x04036574 RID: 222580
			[EnumStringMember("O块")]
			O块,
			// Token: 0x04036575 RID: 222581
			[EnumStringMember("S块")]
			S块,
			// Token: 0x04036576 RID: 222582
			[EnumStringMember("T块")]
			T块,
			// Token: 0x04036577 RID: 222583
			[EnumStringMember("Z块")]
			Z块,
			// Token: 0x04036578 RID: 222584
			[EnumStringMember("五连I块")]
			五连I块,
			// Token: 0x04036579 RID: 222585
			[EnumStringMember("五连T块")]
			五连T块,
			// Token: 0x0403657A RID: 222586
			[EnumStringMember("五连U块")]
			五连U块,
			// Token: 0x0403657B RID: 222587
			[EnumStringMember("五连V块")]
			五连V块,
			// Token: 0x0403657C RID: 222588
			[EnumStringMember("五连W块")]
			五连W块,
			// Token: 0x0403657D RID: 222589
			[EnumStringMember("五连X块")]
			五连X块,
			// Token: 0x0403657E RID: 222590
			[EnumStringMember("五连F块")]
			五连F块,
			// Token: 0x0403657F RID: 222591
			[EnumStringMember("五连F1块")]
			五连F1块,
			// Token: 0x04036580 RID: 222592
			[EnumStringMember("五连S块")]
			五连S块,
			// Token: 0x04036581 RID: 222593
			[EnumStringMember("五连Z块")]
			五连Z块,
			// Token: 0x04036582 RID: 222594
			[EnumStringMember("五连J块")]
			五连J块,
			// Token: 0x04036583 RID: 222595
			[EnumStringMember("五连L块")]
			五连L块,
			// Token: 0x04036584 RID: 222596
			[EnumStringMember("五连Y块")]
			五连Y块,
			// Token: 0x04036585 RID: 222597
			[EnumStringMember("五连Y1块")]
			五连Y1块,
			// Token: 0x04036586 RID: 222598
			[EnumStringMember("五连N块")]
			五连N块,
			// Token: 0x04036587 RID: 222599
			[EnumStringMember("五连N1块")]
			五连N1块,
			// Token: 0x04036588 RID: 222600
			[EnumStringMember("五连P块")]
			五连P块,
			// Token: 0x04036589 RID: 222601
			[EnumStringMember("五连Q块")]
			五连Q块,
			// Token: 0x0403658A RID: 222602
			[EnumStringMember("三连I块")]
			三连I块,
			// Token: 0x0403658B RID: 222603
			[EnumStringMember("三连V块")]
			三连V块,
			// Token: 0x0403658C RID: 222604
			[EnumStringMember("二连方块")]
			二连方块
		}

		// Token: 0x0200AF1B RID: 44827
		public enum ETetrominoBorad
		{
			// Token: 0x0403658E RID: 222606
			二乘二 = 2,
			// Token: 0x0403658F RID: 222607
			三乘三,
			// Token: 0x04036590 RID: 222608
			四乘四,
			// Token: 0x04036591 RID: 222609
			五乘五
		}

		// Token: 0x0200AF1C RID: 44828
		public enum EMinoParent
		{
			// Token: 0x04036593 RID: 222611
			Board,
			// Token: 0x04036594 RID: 222612
			Tetromino
		}

		// Token: 0x0200AF1D RID: 44829
		public enum ETetrominoRotateState
		{
			// Token: 0x04036596 RID: 222614
			角度0,
			// Token: 0x04036597 RID: 222615
			角度90,
			// Token: 0x04036598 RID: 222616
			角度180,
			// Token: 0x04036599 RID: 222617
			角度270
		}
	}
}
