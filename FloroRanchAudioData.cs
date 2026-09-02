using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BBB RID: 7099
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchAudioData
{
	// Token: 0x0600CE8B RID: 52875 RVA: 0x00370AE1 File Offset: 0x0036ECE1
	public FloroRanchAudioData(FloroRanchAudio config)
	{
		this.Config = config;
	}

	// Token: 0x0600CE8C RID: 52876 RVA: 0x00370AF0 File Offset: 0x0036ECF0
	public string GetAudioText()
	{
		return this.Config.Text;
	}

	// Token: 0x0600CE8D RID: 52877 RVA: 0x00370B0C File Offset: 0x0036ED0C
	public string GetAudioEvent()
	{
		return this.Config.AudioEvent;
	}

	// Token: 0x0400627E RID: 25214
	private readonly FloroRanchAudio Config;
}
