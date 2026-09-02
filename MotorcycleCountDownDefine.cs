using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x0200228A RID: 8842
internal class MotorcycleCountDownDefine : IStaticVariableResetter
{
	// Token: 0x06010B7E RID: 68478 RVA: 0x004941AC File Offset: 0x004923AC
	static MotorcycleCountDownDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleCountDownDefine.CreateStaticDefaultValue), new Action(MotorcycleCountDownDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06010B7F RID: 68479 RVA: 0x004941CB File Offset: 0x004923CB
	public static void CreateStaticDefaultValue()
	{
		MotorcycleCountDownDefine.hideBattleUiChildren = new EBattleUiChild[]
		{
			EBattleUiChild.HomeButton,
			EBattleUiChild.TopButton,
			EBattleUiChild.MiniMap,
			EBattleUiChild.MotorcycleControlTop
		};
	}

	// Token: 0x06010B80 RID: 68480 RVA: 0x004941E3 File Offset: 0x004923E3
	public static void ResetStaticDefaultValue()
	{
		MotorcycleCountDownDefine.hideBattleUiChildren = null;
	}

	// Token: 0x040083EF RID: 33775
	[Nullable(1)]
	public static EBattleUiChild[] hideBattleUiChildren;
}
