using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200616F RID: 24943
	[NullableContext(2)]
	[Nullable(0)]
	internal class GondolaPlotAudioHandle : IGondolaPlotAudioHandle
	{
		// Token: 0x17009AFB RID: 39675
		// (get) Token: 0x0603F06C RID: 258156 RVA: 0x01028D2A File Offset: 0x01026F2A
		// (set) Token: 0x0603F06D RID: 258157 RVA: 0x01028D32 File Offset: 0x01026F32
		public int RoleId { get; set; }

		// Token: 0x17009AFC RID: 39676
		// (get) Token: 0x0603F06E RID: 258158 RVA: 0x01028D3B File Offset: 0x01026F3B
		// (set) Token: 0x0603F06F RID: 258159 RVA: 0x01028D43 File Offset: 0x01026F43
		public int PassengerId { get; set; }

		// Token: 0x17009AFD RID: 39677
		// (get) Token: 0x0603F070 RID: 258160 RVA: 0x01028D4C File Offset: 0x01026F4C
		// (set) Token: 0x0603F071 RID: 258161 RVA: 0x01028D54 File Offset: 0x01026F54
		public BaseActorComponent PassengerActor { get; set; }

		// Token: 0x17009AFE RID: 39678
		// (get) Token: 0x0603F072 RID: 258162 RVA: 0x01028D5D File Offset: 0x01026F5D
		// (set) Token: 0x0603F073 RID: 258163 RVA: 0x01028D65 File Offset: 0x01026F65
		public AudioHandleInfo AudioHandle { get; set; }

		// Token: 0x17009AFF RID: 39679
		// (get) Token: 0x0603F074 RID: 258164 RVA: 0x01028D6E File Offset: 0x01026F6E
		// (set) Token: 0x0603F075 RID: 258165 RVA: 0x01028D76 File Offset: 0x01026F76
		public PlotHandleInfo PlotHandle { get; set; }
	}
}
