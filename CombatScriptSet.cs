using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200344C RID: 13388
[NullableContext(1)]
[Nullable(0)]
public class CombatScriptSet
{
	// Token: 0x0601C14E RID: 115022 RVA: 0x00860C35 File Offset: 0x0085EE35
	public virtual string OnFilterCmd()
	{
		return "CombatScriptHelper.GetCombatScriptBaseByName('" + base.GetType().Name + "').Introduction;";
	}

	// Token: 0x0400E2D4 RID: 58068
	public string Introduction = "";

	// Token: 0x0400E2D5 RID: 58069
	public List<CombatScriptUnit> CombatScriptUnits = new List<CombatScriptUnit>();
}
