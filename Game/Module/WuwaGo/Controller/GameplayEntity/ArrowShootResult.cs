using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model.Role;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B05 RID: 19205
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class ArrowShootResult : IArrowShootResult
	{
		// Token: 0x1700857C RID: 34172
		// (get) Token: 0x0603214E RID: 205134 RVA: 0x00C88292 File Offset: 0x00C86492
		// (set) Token: 0x0603214F RID: 205135 RVA: 0x00C8829A File Offset: 0x00C8649A
		public WuWaGoRole HitRole { get; set; }

		// Token: 0x1700857D RID: 34173
		// (get) Token: 0x06032150 RID: 205136 RVA: 0x00C882A3 File Offset: 0x00C864A3
		// (set) Token: 0x06032151 RID: 205137 RVA: 0x00C882AB File Offset: 0x00C864AB
		[RequiredMember]
		public bool HitWall { get; set; }

		// Token: 0x1700857E RID: 34174
		// (get) Token: 0x06032152 RID: 205138 RVA: 0x00C882B4 File Offset: 0x00C864B4
		// (set) Token: 0x06032153 RID: 205139 RVA: 0x00C882BC File Offset: 0x00C864BC
		[RequiredMember]
		public float TargetDistanceMeter { get; set; }

		// Token: 0x06032154 RID: 205140 RVA: 0x00C882C5 File Offset: 0x00C864C5
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ArrowShootResult()
		{
		}
	}
}
