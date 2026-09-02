using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200207E RID: 8318
public class SpecialItemDefine : IStaticVariableResetter
{
	// Token: 0x0600FD78 RID: 64888 RVA: 0x004587FB File Offset: 0x004569FB
	static SpecialItemDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SpecialItemDefine.CreateStaticDefaultValue), new Action(SpecialItemDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600FD79 RID: 64889 RVA: 0x0045881A File Offset: 0x00456A1A
	public static void CreateStaticDefaultValue()
	{
		SpecialItemDefine.specialItemLogic = new Dictionary<SpecialItemDefine.ESpecialItemType, Type>
		{
			{
				SpecialItemDefine.ESpecialItemType.EntityCamera,
				typeof(SpecialItemLogicEntityCamera)
			}
		};
		SpecialItemDefine.SpecialItemIdSet = new HashSet<SpecialItemDefine.ESpecialItemType>
		{
			SpecialItemDefine.ESpecialItemType.EntityCamera
		};
	}

	// Token: 0x0600FD7A RID: 64890 RVA: 0x00458851 File Offset: 0x00456A51
	public static void ResetStaticDefaultValue()
	{
		SpecialItemDefine.specialItemLogic = null;
		SpecialItemDefine.SpecialItemIdSet = null;
	}

	// Token: 0x0400799F RID: 31135
	[Nullable(1)]
	public static Dictionary<SpecialItemDefine.ESpecialItemType, Type> specialItemLogic;

	// Token: 0x040079A0 RID: 31136
	[Nullable(1)]
	public static HashSet<SpecialItemDefine.ESpecialItemType> SpecialItemIdSet;

	// Token: 0x02008407 RID: 33799
	public enum ESpecialItemEquipType
	{
		// Token: 0x0402CBFA RID: 183290
		Equipped,
		// Token: 0x0402CBFB RID: 183291
		Portable,
		// Token: 0x0402CBFC RID: 183292
		FragmentMemory
	}

	// Token: 0x02008408 RID: 33800
	public enum ESpecialItemType
	{
		// Token: 0x0402CBFE RID: 183294
		EntityCamera = 70140001
	}
}
