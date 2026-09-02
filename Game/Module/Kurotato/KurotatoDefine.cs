using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A6B RID: 23147
	[NullableContext(1)]
	[Nullable(0)]
	public static class KurotatoDefine
	{
		// Token: 0x0402123E RID: 135742
		public const int KUTOTATO_COMBO_LEVEL_CONFIG_LENGTH = 4;

		// Token: 0x0402123F RID: 135743
		public const float NOT_FINISH_ALPHA = 1f;

		// Token: 0x04021240 RID: 135744
		public const float FINISH_ALPHA = 0.5f;

		// Token: 0x04021241 RID: 135745
		public const int KUROTATO_LEVEL_SELECT_HELPID = 573;

		// Token: 0x04021242 RID: 135746
		public const int KUROTATO_ROLE_SELECT_HELPID = 574;

		// Token: 0x04021243 RID: 135747
		public const int KUROTATO_HAND_BOOK_HELPID = 575;

		// Token: 0x04021244 RID: 135748
		public const int KUROTATO_ENDLESS_LEVEL_SELECT_HELPID = 614;

		// Token: 0x04021245 RID: 135749
		public const int KUROTATO_ARCHIVE_HELPID = 630;

		// Token: 0x04021246 RID: 135750
		public const string KUROTATO_COLOR_UP = "#31dea7";

		// Token: 0x04021247 RID: 135751
		public const string KUROTATO_COLOR_DOWN = "#f53864";

		// Token: 0x04021248 RID: 135752
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<EKurotatoCardType, string> KurotatoHandBookTabName = new Dictionary<EKurotatoCardType, string>
		{
			{
				EKurotatoCardType.None,
				""
			},
			{
				EKurotatoCardType.Weapon,
				"Kurotato_HandBook_Weapon_Tab"
			},
			{
				EKurotatoCardType.Item,
				"Kurotato_HandBook_Item_Tab"
			}
		};

		// Token: 0x04021249 RID: 135753
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<EKurotatoLevelDifficulty, string> KurotatoLevelDifficultyToText = new Dictionary<EKurotatoLevelDifficulty, string>
		{
			{
				EKurotatoLevelDifficulty.TeachEasy,
				"Kurotato_LevelTab_TeachEasy"
			},
			{
				EKurotatoLevelDifficulty.TeachDifficulty,
				"Kurotato_LevelTab_TeachDifficulty"
			},
			{
				EKurotatoLevelDifficulty.Interest,
				"Kurotato_LevelTab_Interest"
			},
			{
				EKurotatoLevelDifficulty.Endless,
				"Kurotato_LevelTab_Endless"
			}
		};
	}
}
