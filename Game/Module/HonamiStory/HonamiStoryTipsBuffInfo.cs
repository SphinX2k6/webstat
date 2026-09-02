using System;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C95 RID: 23701
	public class HonamiStoryTipsBuffInfo : IHonamiStoryTipsBuffInfo
	{
		// Token: 0x17009820 RID: 38944
		// (get) Token: 0x0603BD85 RID: 245125 RVA: 0x00F2B478 File Offset: 0x00F29678
		// (set) Token: 0x0603BD86 RID: 245126 RVA: 0x00F2B480 File Offset: 0x00F29680
		public int BuffId { get; set; }

		// Token: 0x17009821 RID: 38945
		// (get) Token: 0x0603BD87 RID: 245127 RVA: 0x00F2B489 File Offset: 0x00F29689
		// (set) Token: 0x0603BD88 RID: 245128 RVA: 0x00F2B491 File Offset: 0x00F29691
		public int? TagId { get; set; }

		// Token: 0x17009822 RID: 38946
		// (get) Token: 0x0603BD89 RID: 245129 RVA: 0x00F2B49A File Offset: 0x00F2969A
		// (set) Token: 0x0603BD8A RID: 245130 RVA: 0x00F2B4A2 File Offset: 0x00F296A2
		public int? RoleId { get; set; }

		// Token: 0x17009823 RID: 38947
		// (get) Token: 0x0603BD8B RID: 245131 RVA: 0x00F2B4AB File Offset: 0x00F296AB
		// (set) Token: 0x0603BD8C RID: 245132 RVA: 0x00F2B4B3 File Offset: 0x00F296B3
		public bool FromTeamView { get; set; }
	}
}
