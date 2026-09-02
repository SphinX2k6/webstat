using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C10 RID: 23568
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceDetectItemGetterData : IInstanceDetectItemGetterData
	{
		// Token: 0x170097B8 RID: 38840
		// (get) Token: 0x0603B9AE RID: 244142 RVA: 0x00F1B919 File Offset: 0x00F19B19
		// (set) Token: 0x0603B9AF RID: 244143 RVA: 0x00F1B921 File Offset: 0x00F19B21
		public TInstanceSubtitleTextIdGetter SubtitleTextIdGetter { get; set; }

		// Token: 0x170097B9 RID: 38841
		// (get) Token: 0x0603B9B0 RID: 244144 RVA: 0x00F1B92A File Offset: 0x00F19B2A
		// (set) Token: 0x0603B9B1 RID: 244145 RVA: 0x00F1B932 File Offset: 0x00F19B32
		public TInstanceSubtitleArgsGetter SubtitleArgsGetter { get; set; }

		// Token: 0x170097BA RID: 38842
		// (get) Token: 0x0603B9B2 RID: 244146 RVA: 0x00F1B93B File Offset: 0x00F19B3B
		// (set) Token: 0x0603B9B3 RID: 244147 RVA: 0x00F1B943 File Offset: 0x00F19B43
		public TInstanceCheckFinishedGetter CheckFinishedGetter { get; set; }
	}
}
