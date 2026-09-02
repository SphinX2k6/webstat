using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005490 RID: 21648
	[RequiredMember]
	public class BadgeGroupSkillData
	{
		// Token: 0x060371AC RID: 225708 RVA: 0x00DFD922 File Offset: 0x00DFBB22
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public BadgeGroupSkillData()
		{
		}

		// Token: 0x0401FB8F RID: 129935
		[RequiredMember]
		public int GroupId;

		// Token: 0x0401FB90 RID: 129936
		[RequiredMember]
		public int SkillId;
	}
}
