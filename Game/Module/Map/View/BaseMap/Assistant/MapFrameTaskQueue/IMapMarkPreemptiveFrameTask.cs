using System;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x02005807 RID: 22535
	public interface IMapMarkPreemptiveFrameTask : IPreemptiveFrameTask
	{
		// Token: 0x17009205 RID: 37381
		// (get) Token: 0x0603953A RID: 234810
		// (set) Token: 0x0603953B RID: 234811
		EMarkType MarkType { get; set; }

		// Token: 0x17009206 RID: 37382
		// (get) Token: 0x0603953C RID: 234812
		// (set) Token: 0x0603953D RID: 234813
		int MarkId { get; set; }
	}
}
