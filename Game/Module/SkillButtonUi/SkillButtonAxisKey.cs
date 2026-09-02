using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F92 RID: 20370
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class SkillButtonAxisKey
	{
		// Token: 0x060348FC RID: 215292 RVA: 0x00D2CE7A File Offset: 0x00D2B07A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SkillButtonAxisKey()
		{
		}

		// Token: 0x0401E4C1 RID: 124097
		[RequiredMember]
		public string AxisName;

		// Token: 0x0401E4C2 RID: 124098
		[RequiredMember]
		public string KeyName;

		// Token: 0x0401E4C3 RID: 124099
		[RequiredMember]
		public float Scale;
	}
}
