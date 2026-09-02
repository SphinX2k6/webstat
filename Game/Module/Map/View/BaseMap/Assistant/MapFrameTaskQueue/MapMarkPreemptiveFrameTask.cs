using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x02005808 RID: 22536
	[NullableContext(2)]
	[Nullable(0)]
	public class MapMarkPreemptiveFrameTask : IMapMarkPreemptiveFrameTask, IPreemptiveFrameTask
	{
		// Token: 0x17009207 RID: 37383
		// (get) Token: 0x0603953E RID: 234814 RVA: 0x00E8DD92 File Offset: 0x00E8BF92
		// (set) Token: 0x0603953F RID: 234815 RVA: 0x00E8DD9A File Offset: 0x00E8BF9A
		public int Priority { get; set; }

		// Token: 0x17009208 RID: 37384
		// (get) Token: 0x06039540 RID: 234816 RVA: 0x00E8DDA3 File Offset: 0x00E8BFA3
		// (set) Token: 0x06039541 RID: 234817 RVA: 0x00E8DDAB File Offset: 0x00E8BFAB
		[Nullable(1)]
		public TPreemptiveExecuteMethod Execute { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009209 RID: 37385
		// (get) Token: 0x06039542 RID: 234818 RVA: 0x00E8DDB4 File Offset: 0x00E8BFB4
		// (set) Token: 0x06039543 RID: 234819 RVA: 0x00E8DDBC File Offset: 0x00E8BFBC
		public TPreemptiveExecuteMethod FrameExecute { get; set; }

		// Token: 0x1700920A RID: 37386
		// (get) Token: 0x06039544 RID: 234820 RVA: 0x00E8DDC5 File Offset: 0x00E8BFC5
		// (set) Token: 0x06039545 RID: 234821 RVA: 0x00E8DDCD File Offset: 0x00E8BFCD
		public TPreemptiveIsCompleteMethod IsComplete { get; set; }

		// Token: 0x1700920B RID: 37387
		// (get) Token: 0x06039546 RID: 234822 RVA: 0x00E8DDD6 File Offset: 0x00E8BFD6
		// (set) Token: 0x06039547 RID: 234823 RVA: 0x00E8DDDE File Offset: 0x00E8BFDE
		public TPreemptiveCancelMethod Cancel { get; set; }

		// Token: 0x1700920C RID: 37388
		// (get) Token: 0x06039548 RID: 234824 RVA: 0x00E8DDE7 File Offset: 0x00E8BFE7
		// (set) Token: 0x06039549 RID: 234825 RVA: 0x00E8DDEF File Offset: 0x00E8BFEF
		public TGetPreemptiveResultMethod GetResult { get; set; }

		// Token: 0x1700920D RID: 37389
		// (get) Token: 0x0603954A RID: 234826 RVA: 0x00E8DDF8 File Offset: 0x00E8BFF8
		// (set) Token: 0x0603954B RID: 234827 RVA: 0x00E8DE00 File Offset: 0x00E8C000
		public EMarkType MarkType { get; set; }

		// Token: 0x1700920E RID: 37390
		// (get) Token: 0x0603954C RID: 234828 RVA: 0x00E8DE09 File Offset: 0x00E8C009
		// (set) Token: 0x0603954D RID: 234829 RVA: 0x00E8DE11 File Offset: 0x00E8C011
		public int MarkId { get; set; }
	}
}
