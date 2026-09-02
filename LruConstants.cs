using System;

// Token: 0x02000068 RID: 104
public class LruConstants : IStaticVariableResetter
{
	// Token: 0x06000250 RID: 592 RVA: 0x0000CD0C File Offset: 0x0000AF0C
	static LruConstants()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LruConstants.CreateStaticDefaultValue), new Action(LruConstants.ResetStaticDefaultValue));
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0000CD2B File Offset: 0x0000AF2B
	public static void CreateStaticDefaultValue()
	{
		LruConstants.IsLruEnabledGlobal = true;
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0000CD33 File Offset: 0x0000AF33
	public static void ResetStaticDefaultValue()
	{
		LruConstants.IsLruEnabledGlobal = true;
	}

	// Token: 0x040001D0 RID: 464
	public static bool IsLruEnabledGlobal;
}
