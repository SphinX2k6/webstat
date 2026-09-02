using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F07 RID: 12039
[RequiredMember]
public class RequirementMonsterGenre : IRequirement
{
	// Token: 0x1700217C RID: 8572
	// (get) Token: 0x06018B01 RID: 101121 RVA: 0x006F841F File Offset: 0x006F661F
	public EExtraEffectRequire Type
	{
		get
		{
			return EExtraEffectRequire.MonsterGenre;
		}
	}

	// Token: 0x06018B02 RID: 101122 RVA: 0x006F8423 File Offset: 0x006F6623
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public RequirementMonsterGenre()
	{
	}

	// Token: 0x0400BFF8 RID: 49144
	[RequiredMember]
	public ERequirementTargetType RequireTargetType;

	// Token: 0x0400BFF9 RID: 49145
	[Nullable(1)]
	[RequiredMember]
	public int[] MonsterGenres;
}
