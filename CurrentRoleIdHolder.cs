using System;

// Token: 0x020031E7 RID: 12775
public class CurrentRoleIdHolder : IStaticVariableResetter
{
	// Token: 0x0601A7F5 RID: 108533 RVA: 0x007D4AE8 File Offset: 0x007D2CE8
	static CurrentRoleIdHolder()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CurrentRoleIdHolder.CreateStaticDefaultValue), new Action(CurrentRoleIdHolder.ResetStaticDefaultValue));
	}

	// Token: 0x0601A7F6 RID: 108534 RVA: 0x007D4B07 File Offset: 0x007D2D07
	public static void CreateStaticDefaultValue()
	{
		CurrentRoleIdHolder.currentRoleId = 0;
	}

	// Token: 0x0601A7F7 RID: 108535 RVA: 0x007D4B0F File Offset: 0x007D2D0F
	public static void ResetStaticDefaultValue()
	{
		CurrentRoleIdHolder.currentRoleId = 0;
	}

	// Token: 0x0400D63F RID: 54847
	public static int currentRoleId;
}
