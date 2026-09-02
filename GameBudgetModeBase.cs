using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BC4 RID: 3012
[NullableContext(1)]
[Nullable(0)]
public class GameBudgetModeBase
{
	// Token: 0x0600312E RID: 12590 RVA: 0x0001B800 File Offset: 0x00019A00
	public GameBudgetModeBase(string ModeName, EGameBudgetMode GameBudgetMode)
	{
	}

	// Token: 0x0600312F RID: 12591 RVA: 0x0001B816 File Offset: 0x00019A16
	public virtual void OnEnterMode()
	{
	}

	// Token: 0x06003130 RID: 12592 RVA: 0x0001B818 File Offset: 0x00019A18
	public virtual void OnExitMode()
	{
	}

	// Token: 0x0400044A RID: 1098
	public string GameBudgetModeName = ModeName;

	// Token: 0x0400044B RID: 1099
	public EGameBudgetMode Mode = GameBudgetMode;
}
