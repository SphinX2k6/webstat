using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002E2B RID: 11819
public class CampUtils : IStaticVariableResetter
{
	// Token: 0x06017EFA RID: 98042 RVA: 0x006B4C53 File Offset: 0x006B2E53
	static CampUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CampUtils.CreateStaticDefaultValue), new Action(CampUtils.ResetStaticDefaultValue));
	}

	// Token: 0x06017EFB RID: 98043 RVA: 0x006B4C72 File Offset: 0x006B2E72
	public static ERelation GetCampRelationship(ECamp selfCamp, ECamp targetCamp)
	{
		return CampUtils.Camp[(int)selfCamp][(int)targetCamp];
	}

	// Token: 0x06017EFC RID: 98044 RVA: 0x006B4C85 File Offset: 0x006B2E85
	public static void CreateStaticDefaultValue()
	{
		CampUtils.Camp = new List<List<ERelation>>();
	}

	// Token: 0x06017EFD RID: 98045 RVA: 0x006B4C91 File Offset: 0x006B2E91
	public static void ResetStaticDefaultValue()
	{
		CampUtils.Camp = null;
	}

	// Token: 0x0400B9F8 RID: 47608
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static List<List<ERelation>> Camp;
}
