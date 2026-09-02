using System;
using CSharpScript.Game;

// Token: 0x02001D12 RID: 7442
public class GameBudgetNormalMode : GameBudgetMode
{
	// Token: 0x0600DA93 RID: 55955 RVA: 0x003ABBB8 File Offset: 0x003A9DB8
	public GameBudgetNormalMode() : base("EGameBudgetMode.Normal", EGameBudgetMode.Normal)
	{
	}

	// Token: 0x0600DA94 RID: 55956 RVA: 0x003ABBC6 File Offset: 0x003A9DC6
	public override void OnEnterMode()
	{
		Singleton<GameBudgetInterfaceController>.Instance.SetCenterRole(Global.BaseCharacter);
	}
}
