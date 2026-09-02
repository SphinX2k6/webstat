using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA6 RID: 19110
	[NullableContext(2)]
	[Nullable(0)]
	public class WuWaGoWorldMoveTarget : IWuWaGoWorldMoveTarget
	{
		// Token: 0x170084E2 RID: 34018
		// (get) Token: 0x06031D4A RID: 204106 RVA: 0x00C799DB File Offset: 0x00C77BDB
		// (set) Token: 0x06031D4B RID: 204107 RVA: 0x00C799E3 File Offset: 0x00C77BE3
		public WuWaGoBaseUnit Unit { get; set; }

		// Token: 0x170084E3 RID: 34019
		// (get) Token: 0x06031D4C RID: 204108 RVA: 0x00C799EC File Offset: 0x00C77BEC
		// (set) Token: 0x06031D4D RID: 204109 RVA: 0x00C799F4 File Offset: 0x00C77BF4
		public AActor Actor { get; set; }

		// Token: 0x170084E4 RID: 34020
		// (get) Token: 0x06031D4E RID: 204110 RVA: 0x00C799FD File Offset: 0x00C77BFD
		// (set) Token: 0x06031D4F RID: 204111 RVA: 0x00C79A05 File Offset: 0x00C77C05
		public Vector FromWorldPosition { get; set; }

		// Token: 0x170084E5 RID: 34021
		// (get) Token: 0x06031D50 RID: 204112 RVA: 0x00C79A0E File Offset: 0x00C77C0E
		// (set) Token: 0x06031D51 RID: 204113 RVA: 0x00C79A16 File Offset: 0x00C77C16
		public Vector ToWorldPosition { get; set; }
	}
}
