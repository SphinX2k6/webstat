using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE2 RID: 24290
	public class BossPilingTaskInfo : IBossPilingTaskInfo
	{
		// Token: 0x170099F6 RID: 39414
		// (get) Token: 0x0603D094 RID: 250004 RVA: 0x00F8108A File Offset: 0x00F7F28A
		// (set) Token: 0x0603D095 RID: 250005 RVA: 0x00F81092 File Offset: 0x00F7F292
		public int Id { get; set; }

		// Token: 0x170099F7 RID: 39415
		// (get) Token: 0x0603D096 RID: 250006 RVA: 0x00F8109B File Offset: 0x00F7F29B
		// (set) Token: 0x0603D097 RID: 250007 RVA: 0x00F810A3 File Offset: 0x00F7F2A3
		public int Current { get; set; }

		// Token: 0x170099F8 RID: 39416
		// (get) Token: 0x0603D098 RID: 250008 RVA: 0x00F810AC File Offset: 0x00F7F2AC
		// (set) Token: 0x0603D099 RID: 250009 RVA: 0x00F810B4 File Offset: 0x00F7F2B4
		public int Target { get; set; }

		// Token: 0x170099F9 RID: 39417
		// (get) Token: 0x0603D09A RID: 250010 RVA: 0x00F810BD File Offset: 0x00F7F2BD
		// (set) Token: 0x0603D09B RID: 250011 RVA: 0x00F810C5 File Offset: 0x00F7F2C5
		public ConditionTaskState Status { get; set; }
	}
}
