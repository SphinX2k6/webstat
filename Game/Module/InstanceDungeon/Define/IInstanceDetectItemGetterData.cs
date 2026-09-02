using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C0F RID: 23567
	[NullableContext(2)]
	public interface IInstanceDetectItemGetterData
	{
		// Token: 0x170097B5 RID: 38837
		// (get) Token: 0x0603B9A8 RID: 244136
		// (set) Token: 0x0603B9A9 RID: 244137
		TInstanceSubtitleTextIdGetter SubtitleTextIdGetter { get; set; }

		// Token: 0x170097B6 RID: 38838
		// (get) Token: 0x0603B9AA RID: 244138
		// (set) Token: 0x0603B9AB RID: 244139
		TInstanceSubtitleArgsGetter SubtitleArgsGetter { get; set; }

		// Token: 0x170097B7 RID: 38839
		// (get) Token: 0x0603B9AC RID: 244140
		// (set) Token: 0x0603B9AD RID: 244141
		TInstanceCheckFinishedGetter CheckFinishedGetter { get; set; }
	}
}
