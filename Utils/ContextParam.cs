using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x0200469A RID: 18074
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class ContextParam
	{
		// Token: 0x0602F0FC RID: 192764 RVA: 0x00B26F39 File Offset: 0x00B25139
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ContextParam()
		{
		}

		// Token: 0x0401ACF3 RID: 109811
		public long SkillId;

		// Token: 0x0401ACF4 RID: 109812
		[RequiredMember]
		public Entity Owner;

		// Token: 0x0401ACF5 RID: 109813
		[RequiredMember]
		public CharacterBuffComponent BuffComp;

		// Token: 0x0401ACF6 RID: 109814
		[RequiredMember]
		public CharacterPassiveSkillComponent PassiveSkillComp;
	}
}
