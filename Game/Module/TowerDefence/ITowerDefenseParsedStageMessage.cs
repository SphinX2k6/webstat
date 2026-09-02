using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB8 RID: 20152
	[NullableContext(1)]
	public interface ITowerDefenseParsedStageMessage
	{
		// Token: 0x1700897C RID: 35196
		// (get) Token: 0x06034105 RID: 213253
		// (set) Token: 0x06034106 RID: 213254
		TowerDefenceInstanceInfo Meta { get; set; }

		// Token: 0x1700897D RID: 35197
		// (get) Token: 0x06034107 RID: 213255
		// (set) Token: 0x06034108 RID: 213256
		int Id { get; set; }

		// Token: 0x1700897E RID: 35198
		// (get) Token: 0x06034109 RID: 213257
		// (set) Token: 0x0603410A RID: 213258
		long UnlockTime { get; set; }

		// Token: 0x1700897F RID: 35199
		// (get) Token: 0x0603410B RID: 213259
		// (set) Token: 0x0603410C RID: 213260
		bool Passed { get; set; }

		// Token: 0x17008980 RID: 35200
		// (get) Token: 0x0603410D RID: 213261
		// (set) Token: 0x0603410E RID: 213262
		double PassTime { get; set; }

		// Token: 0x17008981 RID: 35201
		// (get) Token: 0x0603410F RID: 213263
		// (set) Token: 0x06034110 RID: 213264
		bool Rewarded { get; set; }

		// Token: 0x17008982 RID: 35202
		// (get) Token: 0x06034111 RID: 213265
		// (set) Token: 0x06034112 RID: 213266
		int Record { get; set; }

		// Token: 0x17008983 RID: 35203
		// (get) Token: 0x06034113 RID: 213267
		// (set) Token: 0x06034114 RID: 213268
		bool RecordOverThreshold { get; set; }
	}
}
