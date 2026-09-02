using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A72 RID: 27250
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningStandDefine
	{
		// Token: 0x0604367D RID: 276093 RVA: 0x0115D190 File Offset: 0x0115B390
		// Note: this type is marked as 'beforefieldinit'.
		static TuningStandDefine()
		{
			Dictionary<ETuningStandGridType, int> dictionary = new Dictionary<ETuningStandGridType, int>();
			dictionary[ETuningStandGridType.Start1] = 0;
			dictionary[ETuningStandGridType.Start2] = 0;
			dictionary[ETuningStandGridType.Number1] = 1;
			dictionary[ETuningStandGridType.Number2] = 2;
			dictionary[ETuningStandGridType.Number3] = 3;
			dictionary[ETuningStandGridType.Number4] = 4;
			dictionary[ETuningStandGridType.End1] = 5;
			dictionary[ETuningStandGridType.End2] = 5;
			dictionary[ETuningStandGridType.Empty] = -1;
			TuningStandDefine.gridValueMap = dictionary;
			Dictionary<ETuningStandGridType, EGridMainType> dictionary2 = new Dictionary<ETuningStandGridType, EGridMainType>();
			dictionary2[ETuningStandGridType.Start1] = EGridMainType.Start;
			dictionary2[ETuningStandGridType.Start2] = EGridMainType.Start;
			dictionary2[ETuningStandGridType.Number1] = EGridMainType.Path;
			dictionary2[ETuningStandGridType.Number2] = EGridMainType.Path;
			dictionary2[ETuningStandGridType.Number3] = EGridMainType.Path;
			dictionary2[ETuningStandGridType.Number4] = EGridMainType.Path;
			dictionary2[ETuningStandGridType.End1] = EGridMainType.End;
			dictionary2[ETuningStandGridType.End2] = EGridMainType.End;
			dictionary2[ETuningStandGridType.Empty] = EGridMainType.Empty;
			TuningStandDefine.gridMainTypeMap = dictionary2;
			Dictionary<ETuningStandGridType, string[]> dictionary3 = new Dictionary<ETuningStandGridType, string[]>();
			dictionary3[ETuningStandGridType.Number1] = new string[]
			{
				"SP_DigitalMazeNum01Nml",
				"SP_DigitalMazeNum01Red",
				"SP_DigitalMazeNum01Blue"
			};
			dictionary3[ETuningStandGridType.Number2] = new string[]
			{
				"SP_DigitalMazeNum02Nml",
				"SP_DigitalMazeNum02Red",
				"SP_DigitalMazeNum02Blue"
			};
			dictionary3[ETuningStandGridType.Number3] = new string[]
			{
				"SP_DigitalMazeNum03Nml",
				"SP_DigitalMazeNum03Red",
				"SP_DigitalMazeNum03Blue"
			};
			dictionary3[ETuningStandGridType.Number4] = new string[]
			{
				"SP_DigitalMazeNum04Nml",
				"SP_DigitalMazeNum04Red",
				"SP_DigitalMazeNum04Blue"
			};
			dictionary3[ETuningStandGridType.End1] = new string[]
			{
				"SP_DigitalMazeNum05Nml",
				"SP_DigitalMazeNum05Red",
				"SP_DigitalMazeNum05Blue"
			};
			dictionary3[ETuningStandGridType.End2] = new string[]
			{
				"SP_DigitalMazeNum05Nml",
				"SP_DigitalMazeNum05Red",
				"SP_DigitalMazeNum05Blue"
			};
			TuningStandDefine.gridSpriteMap = dictionary3;
		}

		// Token: 0x04025A23 RID: 154147
		public const int MAX_ROW = 5;

		// Token: 0x04025A24 RID: 154148
		public const int MAX_LINE = 7;

		// Token: 0x04025A25 RID: 154149
		public const int ANIM_IN_TIME = 330;

		// Token: 0x04025A26 RID: 154150
		public const int RESET_TIMES_THREDHOLD = 3;

		// Token: 0x04025A27 RID: 154151
		public const int RESET_COOL_DOWN = 3;

		// Token: 0x04025A28 RID: 154152
		public const int TOOLONG_DELAY = 60000;

		// Token: 0x04025A29 RID: 154153
		public const int TOOLONG_DELAY_MIN = 3;

		// Token: 0x04025A2A RID: 154154
		public const int TUNINGSTAND_HELP_ID = 346;

		// Token: 0x04025A2B RID: 154155
		public const int FX_FLYING_TIME = 1;

		// Token: 0x04025A2C RID: 154156
		public const float AK_COOL_DOWN = 0.05f;

		// Token: 0x04025A2D RID: 154157
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ETuningStandGridType, int> gridValueMap;

		// Token: 0x04025A2E RID: 154158
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ETuningStandGridType, EGridMainType> gridMainTypeMap;

		// Token: 0x04025A2F RID: 154159
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ETuningStandGridType, string[]> gridSpriteMap;
	}
}
