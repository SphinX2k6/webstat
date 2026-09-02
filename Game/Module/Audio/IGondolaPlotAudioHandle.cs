using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200616E RID: 24942
	[NullableContext(2)]
	internal interface IGondolaPlotAudioHandle
	{
		// Token: 0x17009AF6 RID: 39670
		// (get) Token: 0x0603F062 RID: 258146
		// (set) Token: 0x0603F063 RID: 258147
		int RoleId { get; set; }

		// Token: 0x17009AF7 RID: 39671
		// (get) Token: 0x0603F064 RID: 258148
		// (set) Token: 0x0603F065 RID: 258149
		int PassengerId { get; set; }

		// Token: 0x17009AF8 RID: 39672
		// (get) Token: 0x0603F066 RID: 258150
		// (set) Token: 0x0603F067 RID: 258151
		BaseActorComponent PassengerActor { get; set; }

		// Token: 0x17009AF9 RID: 39673
		// (get) Token: 0x0603F068 RID: 258152
		// (set) Token: 0x0603F069 RID: 258153
		AudioHandleInfo AudioHandle { get; set; }

		// Token: 0x17009AFA RID: 39674
		// (get) Token: 0x0603F06A RID: 258154
		// (set) Token: 0x0603F06B RID: 258155
		PlotHandleInfo PlotHandle { get; set; }
	}
}
