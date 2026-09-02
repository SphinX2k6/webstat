using System;

// Token: 0x02003187 RID: 12679
public class NpcMatHandleInfo : IStaticVariableResetter
{
	// Token: 0x0601A496 RID: 107670 RVA: 0x007BD23E File Offset: 0x007BB43E
	static NpcMatHandleInfo()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(NpcMatHandleInfo.CreateStaticDefaultValue), new Action(NpcMatHandleInfo.ResetStaticDefaultValue));
	}

	// Token: 0x0601A497 RID: 107671 RVA: 0x007BD25D File Offset: 0x007BB45D
	public static void CreateStaticDefaultValue()
	{
		NpcMatHandleInfo.IdGenerator = 0;
	}

	// Token: 0x0601A498 RID: 107672 RVA: 0x007BD265 File Offset: 0x007BB465
	public static void ResetStaticDefaultValue()
	{
		NpcMatHandleInfo.IdGenerator = 0;
	}

	// Token: 0x0400D3C8 RID: 54216
	private static int IdGenerator;

	// Token: 0x0400D3C9 RID: 54217
	public int Id = ++NpcMatHandleInfo.IdGenerator;

	// Token: 0x0400D3CA RID: 54218
	public EMatDataType Type;

	// Token: 0x0400D3CB RID: 54219
	public int Handle;
}
