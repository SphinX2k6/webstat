using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x0200657D RID: 25981
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityPreWarmDefine
	{
		// Token: 0x040246B6 RID: 149174
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<int, string> titleNumIcons = new Dictionary<int, string>
		{
			{
				1,
				"SP_TitleNum01"
			},
			{
				2,
				"SP_TitleNum02"
			},
			{
				3,
				"SP_TitleNum03"
			},
			{
				4,
				"SP_TitleNum04"
			},
			{
				5,
				"SP_TitleNum05"
			},
			{
				6,
				"SP_TitleNum06"
			},
			{
				7,
				"SP_TitleNum07"
			}
		};

		// Token: 0x040246B7 RID: 149175
		public const int PREWARMTASKNUM = 7;

		// Token: 0x040246B8 RID: 149176
		[StaticVariableRuleIgnore]
		public static readonly List<int> leftCollectItems = new List<int>
		{
			1,
			2,
			3
		};

		// Token: 0x040246B9 RID: 149177
		[StaticVariableRuleIgnore]
		public static readonly List<int> rightCollectItems = new List<int>
		{
			4,
			5,
			6,
			7
		};

		// Token: 0x040246BA RID: 149178
		public const int SKIPTIMESPEED = 5;
	}
}
