using System;
using System.Runtime.CompilerServices;

// Token: 0x020028B8 RID: 10424
public class RoleSkillDefine : IStaticVariableResetter
{
	// Token: 0x06014AE7 RID: 84711 RVA: 0x005BA25C File Offset: 0x005B845C
	static RoleSkillDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleSkillDefine.CreateStaticDefaultValue), new Action(RoleSkillDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06014AE8 RID: 84712 RVA: 0x005BA27B File Offset: 0x005B847B
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06014AE9 RID: 84713 RVA: 0x005BA27D File Offset: 0x005B847D
	public static void ResetStaticDefaultValue()
	{
	}

	// Token: 0x04009F8F RID: 40847
	[Nullable(1)]
	public const string RECOMMEND_SKILL_SHOW_TAG_RESOURCE_ID = "T_RoleDevelopRecommendA";

	// Token: 0x04009F90 RID: 40848
	[Nullable(1)]
	public const string CORE_SKILL_SHOW_TAG_RESOURCE_ID = "T_RoleDevelopRecommend";
}
