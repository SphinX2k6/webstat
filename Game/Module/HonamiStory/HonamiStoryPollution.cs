using System;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C8C RID: 23692
	public class HonamiStoryPollution : IHonamiStoryPollution
	{
		// Token: 0x1700980B RID: 38923
		// (get) Token: 0x0603BD58 RID: 245080 RVA: 0x00F2B3A0 File Offset: 0x00F295A0
		// (set) Token: 0x0603BD59 RID: 245081 RVA: 0x00F2B3A8 File Offset: 0x00F295A8
		public int PollutionLevel { get; set; }

		// Token: 0x1700980C RID: 38924
		// (get) Token: 0x0603BD5A RID: 245082 RVA: 0x00F2B3B1 File Offset: 0x00F295B1
		// (set) Token: 0x0603BD5B RID: 245083 RVA: 0x00F2B3B9 File Offset: 0x00F295B9
		public int PersistMilliseconds { get; set; }

		// Token: 0x1700980D RID: 38925
		// (get) Token: 0x0603BD5C RID: 245084 RVA: 0x00F2B3C2 File Offset: 0x00F295C2
		// (set) Token: 0x0603BD5D RID: 245085 RVA: 0x00F2B3CA File Offset: 0x00F295CA
		public int MonsterEnhanceLevel { get; set; }
	}
}
