using System;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C94 RID: 23700
	public interface IHonamiStoryTipsBuffInfo
	{
		// Token: 0x1700981C RID: 38940
		// (get) Token: 0x0603BD7D RID: 245117
		// (set) Token: 0x0603BD7E RID: 245118
		int BuffId { get; set; }

		// Token: 0x1700981D RID: 38941
		// (get) Token: 0x0603BD7F RID: 245119
		// (set) Token: 0x0603BD80 RID: 245120
		int? TagId { get; set; }

		// Token: 0x1700981E RID: 38942
		// (get) Token: 0x0603BD81 RID: 245121
		// (set) Token: 0x0603BD82 RID: 245122
		int? RoleId { get; set; }

		// Token: 0x1700981F RID: 38943
		// (get) Token: 0x0603BD83 RID: 245123
		// (set) Token: 0x0603BD84 RID: 245124
		bool FromTeamView { get; set; }
	}
}
