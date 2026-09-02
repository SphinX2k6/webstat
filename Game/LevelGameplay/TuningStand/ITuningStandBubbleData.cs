using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A75 RID: 27253
	[NullableContext(2)]
	public interface ITuningStandBubbleData
	{
		// Token: 0x1700A25E RID: 41566
		// (get) Token: 0x0604368A RID: 276106
		// (set) Token: 0x0604368B RID: 276107
		float WaitTime { get; set; }

		// Token: 0x1700A25F RID: 41567
		// (get) Token: 0x0604368C RID: 276108
		// (set) Token: 0x0604368D RID: 276109
		string MainRoleTex { get; set; }

		// Token: 0x1700A260 RID: 41568
		// (get) Token: 0x0604368E RID: 276110
		// (set) Token: 0x0604368F RID: 276111
		string MainRoleTalk { get; set; }

		// Token: 0x1700A261 RID: 41569
		// (get) Token: 0x06043690 RID: 276112
		// (set) Token: 0x06043691 RID: 276113
		string FloroTex { get; set; }

		// Token: 0x1700A262 RID: 41570
		// (get) Token: 0x06043692 RID: 276114
		// (set) Token: 0x06043693 RID: 276115
		string FloroTalk { get; set; }
	}
}
