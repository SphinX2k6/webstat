using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007049 RID: 28745
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecData
	{
		// Token: 0x1700A525 RID: 42277
		// (get) Token: 0x06045937 RID: 284983 RVA: 0x0122E0E2 File Offset: 0x0122C2E2
		// (set) Token: 0x06045938 RID: 284984 RVA: 0x0122E0EA File Offset: 0x0122C2EA
		public int Id { get; set; }

		// Token: 0x1700A526 RID: 42278
		// (get) Token: 0x06045939 RID: 284985 RVA: 0x0122E0F3 File Offset: 0x0122C2F3
		// (set) Token: 0x0604593A RID: 284986 RVA: 0x0122E0FB File Offset: 0x0122C2FB
		public string Path { get; set; }

		// Token: 0x1700A527 RID: 42279
		// (get) Token: 0x0604593B RID: 284987 RVA: 0x0122E104 File Offset: 0x0122C304
		// (set) Token: 0x0604593C RID: 284988 RVA: 0x0122E10C File Offset: 0x0122C30C
		public byte SpecType { get; set; }

		// Token: 0x1700A528 RID: 42280
		// (get) Token: 0x0604593D RID: 284989 RVA: 0x0122E115 File Offset: 0x0122C315
		// (set) Token: 0x0604593E RID: 284990 RVA: 0x0122E11D File Offset: 0x0122C31D
		public sbyte EffectRegularType { get; set; }

		// Token: 0x1700A529 RID: 42281
		// (get) Token: 0x0604593F RID: 284991 RVA: 0x0122E126 File Offset: 0x0122C326
		// (set) Token: 0x06045940 RID: 284992 RVA: 0x0122E12E File Offset: 0x0122C32E
		public float LifeTime { get; set; }

		// Token: 0x1700A52A RID: 42282
		// (get) Token: 0x06045941 RID: 284993 RVA: 0x0122E137 File Offset: 0x0122C337
		// (set) Token: 0x06045942 RID: 284994 RVA: 0x0122E13F File Offset: 0x0122C33F
		public List<int> Children { get; set; }
	}
}
