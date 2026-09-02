using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DCE RID: 19918
	public interface ITrapDefenseDevelopPreviewLevelInfo
	{
		// Token: 0x17008844 RID: 34884
		// (get) Token: 0x060338E9 RID: 211177
		// (set) Token: 0x060338EA RID: 211178
		int Id { get; set; }

		// Token: 0x17008845 RID: 34885
		// (get) Token: 0x060338EB RID: 211179
		// (set) Token: 0x060338EC RID: 211180
		bool IsCurLevel { get; set; }

		// Token: 0x17008846 RID: 34886
		// (get) Token: 0x060338ED RID: 211181
		// (set) Token: 0x060338EE RID: 211182
		bool? NeedAlpha { get; set; }
	}
}
