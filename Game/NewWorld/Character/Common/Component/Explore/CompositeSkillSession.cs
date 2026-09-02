using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x0200495A RID: 18778
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class CompositeSkillSession : ICompositeSkillSession
	{
		// Token: 0x170083C6 RID: 33734
		// (get) Token: 0x06031199 RID: 201113 RVA: 0x00C37525 File Offset: 0x00C35725
		// (set) Token: 0x0603119A RID: 201114 RVA: 0x00C3752D File Offset: 0x00C3572D
		[RequiredMember]
		public ICompositeExploreSkillConfig Config { get; set; }

		// Token: 0x170083C7 RID: 33735
		// (get) Token: 0x0603119B RID: 201115 RVA: 0x00C37536 File Offset: 0x00C35736
		// (set) Token: 0x0603119C RID: 201116 RVA: 0x00C3753E File Offset: 0x00C3573E
		[RequiredMember]
		public bool EnterSent { get; set; }

		// Token: 0x170083C8 RID: 33736
		// (get) Token: 0x0603119D RID: 201117 RVA: 0x00C37547 File Offset: 0x00C35747
		// (set) Token: 0x0603119E RID: 201118 RVA: 0x00C3754F File Offset: 0x00C3574F
		[RequiredMember]
		public double CreatedTime { get; set; }

		// Token: 0x0603119F RID: 201119 RVA: 0x00C37558 File Offset: 0x00C35758
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CompositeSkillSession()
		{
		}
	}
}
