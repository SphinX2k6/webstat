using System;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x02005809 RID: 22537
	public interface IMapGamePlayRequestPreemptiveFrameTask : IPreemptiveFrameTask
	{
		// Token: 0x1700920F RID: 37391
		// (get) Token: 0x0603954F RID: 234831
		// (set) Token: 0x06039550 RID: 234832
		int MarkId { get; set; }

		// Token: 0x17009210 RID: 37392
		// (get) Token: 0x06039551 RID: 234833
		// (set) Token: 0x06039552 RID: 234834
		int GamePlayId { get; set; }

		// Token: 0x17009211 RID: 37393
		// (get) Token: 0x06039553 RID: 234835
		// (set) Token: 0x06039554 RID: 234836
		int InstId { get; set; }
	}
}
