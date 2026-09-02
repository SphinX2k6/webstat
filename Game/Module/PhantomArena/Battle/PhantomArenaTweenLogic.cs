using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x020055A0 RID: 21920
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class PhantomArenaTweenLogic
	{
		// Token: 0x06037CC3 RID: 228547 RVA: 0x00E235A0 File Offset: 0x00E217A0
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PhantomArenaTweenLogic()
		{
		}

		// Token: 0x0401FF1D RID: 130845
		[Nullable(2)]
		public Action StartCallback;

		// Token: 0x0401FF1E RID: 130846
		[RequiredMember]
		public Action CompleteCallback;

		// Token: 0x0401FF1F RID: 130847
		[RequiredMember]
		public UCurveFloat LocationCurveX;

		// Token: 0x0401FF20 RID: 130848
		[RequiredMember]
		public UCurveFloat LocationCurveY;

		// Token: 0x0401FF21 RID: 130849
		public float? DurationTime;
	}
}
