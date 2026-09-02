using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x02004823 RID: 18467
	[RequiredMember]
	public class StepSpringResult : IStepSpringResult
	{
		// Token: 0x17008234 RID: 33332
		// (get) Token: 0x060300E8 RID: 196840 RVA: 0x00BA5B6E File Offset: 0x00BA3D6E
		// (set) Token: 0x060300E9 RID: 196841 RVA: 0x00BA5B76 File Offset: 0x00BA3D76
		[RequiredMember]
		public float NewPosition { get; set; }

		// Token: 0x17008235 RID: 33333
		// (get) Token: 0x060300EA RID: 196842 RVA: 0x00BA5B7F File Offset: 0x00BA3D7F
		// (set) Token: 0x060300EB RID: 196843 RVA: 0x00BA5B87 File Offset: 0x00BA3D87
		[RequiredMember]
		public float NewVelocity { get; set; }

		// Token: 0x17008236 RID: 33334
		// (get) Token: 0x060300EC RID: 196844 RVA: 0x00BA5B90 File Offset: 0x00BA3D90
		// (set) Token: 0x060300ED RID: 196845 RVA: 0x00BA5B98 File Offset: 0x00BA3D98
		[RequiredMember]
		public bool Converged { get; set; }

		// Token: 0x060300EE RID: 196846 RVA: 0x00BA5BA1 File Offset: 0x00BA3DA1
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public StepSpringResult()
		{
		}
	}
}
