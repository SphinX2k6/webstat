using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004958 RID: 18776
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class CompositeExploreSkillConfig : ICompositeExploreSkillConfig
	{
		// Token: 0x170083C0 RID: 33728
		// (get) Token: 0x0603118C RID: 201100 RVA: 0x00C374EA File Offset: 0x00C356EA
		// (set) Token: 0x0603118D RID: 201101 RVA: 0x00C374F2 File Offset: 0x00C356F2
		[RequiredMember]
		public string Name { get; set; }

		// Token: 0x170083C1 RID: 33729
		// (get) Token: 0x0603118E RID: 201102 RVA: 0x00C374FB File Offset: 0x00C356FB
		// (set) Token: 0x0603118F RID: 201103 RVA: 0x00C37503 File Offset: 0x00C35703
		[RequiredMember]
		public int EntrySkillId { get; set; }

		// Token: 0x170083C2 RID: 33730
		// (get) Token: 0x06031190 RID: 201104 RVA: 0x00C3750C File Offset: 0x00C3570C
		// (set) Token: 0x06031191 RID: 201105 RVA: 0x00C37514 File Offset: 0x00C35714
		[RequiredMember]
		public int ExitSkillId { get; set; }

		// Token: 0x06031192 RID: 201106 RVA: 0x00C3751D File Offset: 0x00C3571D
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CompositeExploreSkillConfig()
		{
		}
	}
}
