using System;
using System.Runtime.CompilerServices;

// Token: 0x02001FD0 RID: 8144
public class HudUnitUtils : IStaticVariableResetter
{
	// Token: 0x0600F5DB RID: 62939 RVA: 0x00435425 File Offset: 0x00433625
	static HudUnitUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(HudUnitUtils.CreateStaticDefaultValue), new Action(HudUnitUtils.ResetStaticDefaultValue));
	}

	// Token: 0x0600F5DC RID: 62940 RVA: 0x00435444 File Offset: 0x00433644
	public static void CreateStaticDefaultValue()
	{
		HudUnitUtils.PositionUtil = new HudUnitPositionUtil();
	}

	// Token: 0x0600F5DD RID: 62941 RVA: 0x00435450 File Offset: 0x00433650
	public static void ResetStaticDefaultValue()
	{
		HudUnitUtils.PositionUtil = null;
	}

	// Token: 0x040076E2 RID: 30434
	[Nullable(1)]
	public static HudUnitPositionUtil PositionUtil;
}
