using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C5D RID: 23645
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrastructureMissionItemData
	{
		// Token: 0x170097E7 RID: 38887
		// (get) Token: 0x0603BBE2 RID: 244706 RVA: 0x00F22FC6 File Offset: 0x00F211C6
		// (set) Token: 0x0603BBE3 RID: 244707 RVA: 0x00F22FCE File Offset: 0x00F211CE
		public string DesText { get; set; }

		// Token: 0x170097E8 RID: 38888
		// (get) Token: 0x0603BBE4 RID: 244708 RVA: 0x00F22FD7 File Offset: 0x00F211D7
		// (set) Token: 0x0603BBE5 RID: 244709 RVA: 0x00F22FDF File Offset: 0x00F211DF
		public int MaxCount { get; set; }

		// Token: 0x170097E9 RID: 38889
		// (get) Token: 0x0603BBE6 RID: 244710 RVA: 0x00F22FE8 File Offset: 0x00F211E8
		// (set) Token: 0x0603BBE7 RID: 244711 RVA: 0x00F22FF0 File Offset: 0x00F211F0
		public int CurrentCount { get; set; }
	}
}
