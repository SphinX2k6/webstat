using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001209 RID: 4617
public class BabelTowerDefine : IStaticVariableResetter
{
	// Token: 0x06007A2A RID: 31274 RVA: 0x001FD1C4 File Offset: 0x001FB3C4
	static BabelTowerDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BabelTowerDefine.CreateStaticDefaultValue), new Action(BabelTowerDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06007A2B RID: 31275 RVA: 0x001FD224 File Offset: 0x001FB424
	public static void CreateStaticDefaultValue()
	{
		BabelTowerDefine.BABEL_TOWER_SETTLEMENT_DETERM_LINE_COUNT = new int?(4);
		BabelTowerDefine.BABEL_TOWER_TEAM_ROLE_SLOT_COUNT = new int?(3);
	}

	// Token: 0x06007A2C RID: 31276 RVA: 0x001FD23C File Offset: 0x001FB43C
	public static void ResetStaticDefaultValue()
	{
		BabelTowerDefine.BABEL_TOWER_SETTLEMENT_DETERM_LINE_COUNT = null;
		BabelTowerDefine.BABEL_TOWER_TEAM_ROLE_SLOT_COUNT = null;
	}

	// Token: 0x04003AB0 RID: 15024
	public static int? BABEL_TOWER_SETTLEMENT_DETERM_LINE_COUNT;

	// Token: 0x04003AB1 RID: 15025
	public static int? BABEL_TOWER_TEAM_ROLE_SLOT_COUNT;

	// Token: 0x04003AB2 RID: 15026
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly IReadOnlyList<string> babelTowerRankDecoPath = new List<string>
	{
		"",
		"T_RankDeco1",
		"T_RankDeco2",
		"T_RankDeco3"
	};
}
