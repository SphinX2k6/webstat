using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A8 RID: 25256
	[NullableContext(1)]
	[Nullable(0)]
	public class TerisDefine
	{
		// Token: 0x04023AB1 RID: 146097
		public const int BOARDROWS = 8;

		// Token: 0x04023AB2 RID: 146098
		public const int BOARDCOLS = 8;

		// Token: 0x04023AB3 RID: 146099
		public const int GRID_SIZE = 5;

		// Token: 0x04023AB4 RID: 146100
		public const int GRID_CENTER = 2;

		// Token: 0x04023AB5 RID: 146101
		public const string DONE_TEXT = "Tetristext_03";

		// Token: 0x04023AB6 RID: 146102
		public const string OPEN_TEXT = "Tetristext_04";

		// Token: 0x04023AB7 RID: 146103
		public const string LOCK_TEXT = "Tetristext_05";

		// Token: 0x04023AB8 RID: 146104
		public const string PREVLOCK_TEXT = "Tetristext_12";

		// Token: 0x04023AB9 RID: 146105
		public const int TETRIS_REDPOINT_KEY = 10001;

		// Token: 0x04023ABA RID: 146106
		public const int TETRIS_CELL_START_TIME = 50;

		// Token: 0x04023ABB RID: 146107
		public const int TETRIS_CELL_REMOVE_DELAY = 25;

		// Token: 0x04023ABC RID: 146108
		public const string COMPLETE_COLOR_0 = "5c89a0";

		// Token: 0x04023ABD RID: 146109
		public const string OPEN_COLOR_0 = "9277fc";

		// Token: 0x04023ABE RID: 146110
		public const string LOCK_COLOR_0 = "4c4c4c";

		// Token: 0x04023ABF RID: 146111
		public const string COMPLETE_COLOR_1 = "7bffad";

		// Token: 0x04023AC0 RID: 146112
		public const string OPEN_COLOR_1 = "ebd4ff";

		// Token: 0x04023AC1 RID: 146113
		public const string LOCK_COLOR_1 = "8f8f8e";

		// Token: 0x04023AC2 RID: 146114
		public const string LOSE_EFX = "play_ui_cube_efx_stone";

		// Token: 0x04023AC3 RID: 146115
		public const string GREAT_EFX = "play_ui_cube_efx_match_level2";

		// Token: 0x04023AC4 RID: 146116
		public const string NORMAL_EFX = "play_ui_cube_efx_match_level1";

		// Token: 0x04023AC5 RID: 146117
		public const string TETRIS_CELL_START_EFX = "play_ui_cube_efx_up";

		// Token: 0x04023AC6 RID: 146118
		[TupleElementNames(new string[]
		{
			"Gem",
			"Color"
		})]
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<string, ValueTuple<EGemType, int>> configMap = new Dictionary<string, ValueTuple<EGemType, int>>
		{
			{
				"O",
				new ValueTuple<EGemType, int>(EGemType.Orange, 1)
			},
			{
				"B",
				new ValueTuple<EGemType, int>(EGemType.Blue, 2)
			},
			{
				"G",
				new ValueTuple<EGemType, int>(EGemType.Green, 3)
			},
			{
				"P",
				new ValueTuple<EGemType, int>(EGemType.Purple, 4)
			},
			{
				"Y",
				new ValueTuple<EGemType, int>(EGemType.Yellow, 5)
			},
			{
				"R",
				new ValueTuple<EGemType, int>(EGemType.Red, 6)
			}
		};
	}
}
