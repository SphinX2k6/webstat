using System;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200615A RID: 24922
	public interface IAudioCoolDownInfo
	{
		// Token: 0x17009AE6 RID: 39654
		// (get) Token: 0x0603EFBA RID: 257978
		// (set) Token: 0x0603EFBB RID: 257979
		int DefaultCooldownTime { get; set; }

		// Token: 0x17009AE7 RID: 39655
		// (get) Token: 0x0603EFBC RID: 257980
		// (set) Token: 0x0603EFBD RID: 257981
		double DefaultProbability { get; set; }
	}
}
