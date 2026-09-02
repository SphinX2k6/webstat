using System;
using System.Runtime.CompilerServices;

// Token: 0x02002EF9 RID: 12025
[RequiredMember]
public class RequirementSkillGenre : IRequirement
{
	// Token: 0x1700216E RID: 8558
	// (get) Token: 0x06018AE6 RID: 101094 RVA: 0x006F838A File Offset: 0x006F658A
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.SpecifiedSkillGenre;
		}
	}

	// Token: 0x06018AE7 RID: 101095 RVA: 0x006F838D File Offset: 0x006F658D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementSkillGenre()
	{
	}

	// Token: 0x0400BFE7 RID: 49127
	[Nullable(1)]
	[RequiredMember]
	public int[] SkillGenres;
}
