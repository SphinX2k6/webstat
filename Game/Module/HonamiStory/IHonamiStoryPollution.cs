using System;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C8B RID: 23691
	public interface IHonamiStoryPollution
	{
		// Token: 0x17009808 RID: 38920
		// (get) Token: 0x0603BD52 RID: 245074
		// (set) Token: 0x0603BD53 RID: 245075
		int PollutionLevel { get; set; }

		// Token: 0x17009809 RID: 38921
		// (get) Token: 0x0603BD54 RID: 245076
		// (set) Token: 0x0603BD55 RID: 245077
		int PersistMilliseconds { get; set; }

		// Token: 0x1700980A RID: 38922
		// (get) Token: 0x0603BD56 RID: 245078
		// (set) Token: 0x0603BD57 RID: 245079
		int MonsterEnhanceLevel { get; set; }
	}
}
