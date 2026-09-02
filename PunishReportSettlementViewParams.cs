using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark;

// Token: 0x02001DF2 RID: 7666
[NullableContext(1)]
[Nullable(0)]
public class PunishReportSettlementViewParams
{
	// Token: 0x0600E233 RID: 57907 RVA: 0x003CE8C2 File Offset: 0x003CCAC2
	public PunishReportSettlementViewParams(int treeConfigId, List<EPunishReportTargetState> states)
	{
	}

	// Token: 0x04006CD1 RID: 27857
	public int TreeConfigId = treeConfigId;

	// Token: 0x04006CD2 RID: 27858
	public List<EPunishReportTargetState> States = states;
}
