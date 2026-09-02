using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x0200559D RID: 21917
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsTipsData : IPhantomArenaBattleDetailsTipsData
	{
		// Token: 0x17008FB5 RID: 36789
		// (get) Token: 0x06037C99 RID: 228505 RVA: 0x00E234C4 File Offset: 0x00E216C4
		// (set) Token: 0x06037C9A RID: 228506 RVA: 0x00E234CC File Offset: 0x00E216CC
		public UUIItem AttachItem { get; set; }

		// Token: 0x17008FB6 RID: 36790
		// (get) Token: 0x06037C9B RID: 228507 RVA: 0x00E234D5 File Offset: 0x00E216D5
		// (set) Token: 0x06037C9C RID: 228508 RVA: 0x00E234DD File Offset: 0x00E216DD
		public UUIItem TriggerItem { get; set; }

		// Token: 0x17008FB7 RID: 36791
		// (get) Token: 0x06037C9D RID: 228509 RVA: 0x00E234E6 File Offset: 0x00E216E6
		// (set) Token: 0x06037C9E RID: 228510 RVA: 0x00E234EE File Offset: 0x00E216EE
		public EPhantomArenaBattleDetailsPositionType PositionType { get; set; }

		// Token: 0x17008FB8 RID: 36792
		// (get) Token: 0x06037C9F RID: 228511 RVA: 0x00E234F7 File Offset: 0x00E216F7
		// (set) Token: 0x06037CA0 RID: 228512 RVA: 0x00E234FF File Offset: 0x00E216FF
		public EPhantomArenaBattleDetailsTipsShowType ShowType { get; set; }
	}
}
