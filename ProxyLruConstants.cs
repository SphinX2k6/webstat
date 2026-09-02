using System;

// Token: 0x0200006E RID: 110
public class ProxyLruConstants : IStaticVariableResetter
{
	// Token: 0x06000281 RID: 641 RVA: 0x0000DC27 File Offset: 0x0000BE27
	static ProxyLruConstants()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ProxyLruConstants.CreateStaticDefaultValue), new Action(ProxyLruConstants.ResetStaticDefaultValue));
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0000DC46 File Offset: 0x0000BE46
	public static void CreateStaticDefaultValue()
	{
		ProxyLruConstants.ProxyLruEnable = true;
	}

	// Token: 0x06000283 RID: 643 RVA: 0x0000DC4E File Offset: 0x0000BE4E
	public static void ResetStaticDefaultValue()
	{
		ProxyLruConstants.ProxyLruEnable = true;
	}

	// Token: 0x040001E9 RID: 489
	public static bool ProxyLruEnable;
}
