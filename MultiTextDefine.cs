using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000E61 RID: 3681
public class MultiTextDefine
{
	// Token: 0x0400292F RID: 10543
	[Nullable(1)]
	public const string MULTI_TEXT_LANG_PLOT_PATH = "../Config/Raw/Tables/w.文本库/剧情";

	// Token: 0x04002930 RID: 10544
	public const int CVS_START_INDEX = 8;

	// Token: 0x04002931 RID: 10545
	public const int CSV_LANG_INDEX = 1;

	// Token: 0x04002932 RID: 10546
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	[StaticVariableRuleIgnore]
	public static IReadOnlyDictionary<ETableText, ValueTuple<string, string>> tableTextMap = new Dictionary<ETableText, ValueTuple<string, string>>
	{
		{
			ETableText.SpeakerName,
			new ValueTuple<string, string>("Speaker_", "_Name")
		},
		{
			ETableText.SpeakerTitle,
			new ValueTuple<string, string>("Speaker_", "_Title")
		},
		{
			ETableText.MonsterDisplayName,
			new ValueTuple<string, string>("MonsterDisplay_", "_Name")
		},
		{
			ETableText.MonsterDisplayIntroduce,
			new ValueTuple<string, string>("MonsterDisplay_", "_Introduce")
		},
		{
			ETableText.OccupationConfigName,
			new ValueTuple<string, string>("OccupationConfig_", "_Name")
		},
		{
			ETableText.OriginSubtitle,
			new ValueTuple<string, string>("LyricsText_", "_Original")
		},
		{
			ETableText.TranslationSubtitle,
			new ValueTuple<string, string>("LyricsText_", "_Translation")
		}
	};
}
