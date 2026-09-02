using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B0D RID: 19213
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class GearTrapMoveStep : IGearTrapMoveStep
	{
		// Token: 0x1700858C RID: 34188
		// (get) Token: 0x060321A5 RID: 205221 RVA: 0x00C8971C File Offset: 0x00C8791C
		// (set) Token: 0x060321A6 RID: 205222 RVA: 0x00C89724 File Offset: 0x00C87924
		[RequiredMember]
		public Vector Direction { get; set; }

		// Token: 0x1700858D RID: 34189
		// (get) Token: 0x060321A7 RID: 205223 RVA: 0x00C8972D File Offset: 0x00C8792D
		// (set) Token: 0x060321A8 RID: 205224 RVA: 0x00C89735 File Offset: 0x00C87935
		[RequiredMember]
		public Vector TargetCoordinate { get; set; }

		// Token: 0x060321A9 RID: 205225 RVA: 0x00C8973E File Offset: 0x00C8793E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public GearTrapMoveStep()
		{
		}
	}
}
