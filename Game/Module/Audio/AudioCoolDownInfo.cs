using System;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200615C RID: 24924
	public class AudioCoolDownInfo : IAudioCoolDownInfo
	{
		// Token: 0x17009AE9 RID: 39657
		// (get) Token: 0x0603EFC0 RID: 257984 RVA: 0x01024E26 File Offset: 0x01023026
		// (set) Token: 0x0603EFC1 RID: 257985 RVA: 0x01024E2E File Offset: 0x0102302E
		public int DefaultCooldownTime { get; set; }

		// Token: 0x17009AEA RID: 39658
		// (get) Token: 0x0603EFC2 RID: 257986 RVA: 0x01024E37 File Offset: 0x01023037
		// (set) Token: 0x0603EFC3 RID: 257987 RVA: 0x01024E3F File Offset: 0x0102303F
		public double DefaultProbability { get; set; }
	}
}
