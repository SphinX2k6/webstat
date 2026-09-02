using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064DC RID: 25820
	public class RhythmShipChoseLevelViewDefine : IStaticVariableResetter
	{
		// Token: 0x06040AD2 RID: 264914 RVA: 0x01094386 File Offset: 0x01092586
		static RhythmShipChoseLevelViewDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RhythmShipChoseLevelViewDefine.CreateStaticDefaultValue), new Action(RhythmShipChoseLevelViewDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06040AD3 RID: 264915 RVA: 0x010943A8 File Offset: 0x010925A8
		public static void CreateStaticDefaultValue()
		{
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			dictionary[1] = new List<int>
			{
				4
			};
			dictionary[3] = new List<int>
			{
				1,
				2,
				5
			};
			dictionary[4] = new List<int>
			{
				1,
				2,
				4,
				5
			};
			dictionary[5] = new List<int>
			{
				1,
				2,
				3,
				4,
				5
			};
			RhythmShipChoseLevelViewDefine.rhythmShipLevelItemShow = dictionary;
			Dictionary<int, List<string>> dictionary2 = new Dictionary<int, List<string>>();
			dictionary2[1] = new List<string>
			{
				"",
				"",
				"",
				"Big",
				""
			};
			dictionary2[3] = new List<string>
			{
				"Big",
				"Big",
				"",
				"",
				"Big"
			};
			dictionary2[4] = new List<string>
			{
				"Small",
				"Big",
				"",
				"Big",
				"Small"
			};
			dictionary2[5] = new List<string>
			{
				"Small",
				"Small",
				"Small",
				"Small",
				"Small"
			};
			RhythmShipChoseLevelViewDefine.rhythmShipLevelItemSequenceName = dictionary2;
		}

		// Token: 0x06040AD4 RID: 264916 RVA: 0x01094560 File Offset: 0x01092760
		public static void ResetStaticDefaultValue()
		{
			RhythmShipChoseLevelViewDefine.rhythmShipLevelItemShow = null;
			RhythmShipChoseLevelViewDefine.rhythmShipLevelItemSequenceName = null;
		}

		// Token: 0x040243CD RID: 148429
		public const int LINKAGE_PLANET_ID = 5;

		// Token: 0x040243CE RID: 148430
		public const int LINKAGE_BTN_CD = 1;

		// Token: 0x040243CF RID: 148431
		public const int REFRESH_TIME = 500;

		// Token: 0x040243D0 RID: 148432
		[Nullable(1)]
		public static Dictionary<int, List<int>> rhythmShipLevelItemShow;

		// Token: 0x040243D1 RID: 148433
		[Nullable(1)]
		public static Dictionary<int, List<string>> rhythmShipLevelItemSequenceName;
	}
}
