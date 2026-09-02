using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x0200481D RID: 18461
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class EffectVisibilityRecord : IEffectVisibilityRecord
	{
		// Token: 0x1700822B RID: 33323
		// (get) Token: 0x060300A8 RID: 196776 RVA: 0x00BA430F File Offset: 0x00BA250F
		// (set) Token: 0x060300A9 RID: 196777 RVA: 0x00BA4317 File Offset: 0x00BA2517
		[Nullable(1)]
		[RequiredMember]
		public DragPlayEffectVisibilityProvider Provider { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700822C RID: 33324
		// (get) Token: 0x060300AA RID: 196778 RVA: 0x00BA4320 File Offset: 0x00BA2520
		// (set) Token: 0x060300AB RID: 196779 RVA: 0x00BA4328 File Offset: 0x00BA2528
		public IGuidePathVisibilityHost Attached { get; set; }

		// Token: 0x1700822D RID: 33325
		// (get) Token: 0x060300AC RID: 196780 RVA: 0x00BA4331 File Offset: 0x00BA2531
		// (set) Token: 0x060300AD RID: 196781 RVA: 0x00BA4339 File Offset: 0x00BA2539
		public Action CancelPending { get; set; }

		// Token: 0x060300AE RID: 196782 RVA: 0x00BA4342 File Offset: 0x00BA2542
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public EffectVisibilityRecord()
		{
		}
	}
}
