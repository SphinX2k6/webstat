using System;

// Token: 0x0200344A RID: 13386
public class CombatScriptHelper : CombatScriptHelperBase
{
	// Token: 0x0601C14A RID: 115018 RVA: 0x00860B90 File Offset: 0x0085ED90
	public override void OnInit()
	{
		this.CombatScripts.Add(new AnimHelp());
	}
}
