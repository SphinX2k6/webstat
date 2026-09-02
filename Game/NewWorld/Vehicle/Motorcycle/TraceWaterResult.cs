using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047AD RID: 18349
	[NullableContext(1)]
	[Nullable(0)]
	public class TraceWaterResult : ITraceWaterResult
	{
		// Token: 0x170081BE RID: 33214
		// (get) Token: 0x0602F9FA RID: 195066 RVA: 0x00B5D9CA File Offset: 0x00B5BBCA
		// (set) Token: 0x0602F9FB RID: 195067 RVA: 0x00B5D9D2 File Offset: 0x00B5BBD2
		public bool FoundWater { get; set; }

		// Token: 0x170081BF RID: 33215
		// (get) Token: 0x0602F9FC RID: 195068 RVA: 0x00B5D9DB File Offset: 0x00B5BBDB
		// (set) Token: 0x0602F9FD RID: 195069 RVA: 0x00B5D9E3 File Offset: 0x00B5BBE3
		public float MinWaterHeight { get; set; }

		// Token: 0x170081C0 RID: 33216
		// (get) Token: 0x0602F9FE RID: 195070 RVA: 0x00B5D9EC File Offset: 0x00B5BBEC
		// (set) Token: 0x0602F9FF RID: 195071 RVA: 0x00B5D9F4 File Offset: 0x00B5BBF4
		public Vector ImpactPoint { get; set; }

		// Token: 0x170081C1 RID: 33217
		// (get) Token: 0x0602FA00 RID: 195072 RVA: 0x00B5D9FD File Offset: 0x00B5BBFD
		// (set) Token: 0x0602FA01 RID: 195073 RVA: 0x00B5DA05 File Offset: 0x00B5BC05
		public Vector ImpactNormal { get; set; }
	}
}
