using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D11 RID: 7441
public class GameBudgetMode : GameBudgetModeBase
{
	// Token: 0x0600DA8E RID: 55950 RVA: 0x003ABBA2 File Offset: 0x003A9DA2
	[NullableContext(1)]
	public GameBudgetMode(string modeName, EGameBudgetMode gameBudgetMode) : base(modeName, gameBudgetMode)
	{
	}

	// Token: 0x0600DA8F RID: 55951 RVA: 0x003ABBAC File Offset: 0x003A9DAC
	public virtual bool AllowSwitchMode()
	{
		return true;
	}

	// Token: 0x0600DA90 RID: 55952 RVA: 0x003ABBAF File Offset: 0x003A9DAF
	public virtual bool AllowSetCenterActor()
	{
		return true;
	}

	// Token: 0x0600DA91 RID: 55953 RVA: 0x003ABBB2 File Offset: 0x003A9DB2
	public virtual bool AllowSetCenterOffset()
	{
		return true;
	}

	// Token: 0x0600DA92 RID: 55954 RVA: 0x003ABBB5 File Offset: 0x003A9DB5
	public virtual bool AllowAddAssistantActor()
	{
		return true;
	}
}
