using System;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006148 RID: 24904
	public class EnableAutoPilot : AutoPilotDefine.IEnableAutoPilot
	{
		// Token: 0x17009ADE RID: 39646
		// (get) Token: 0x0603EEB9 RID: 257721 RVA: 0x010210D3 File Offset: 0x0101F2D3
		// (set) Token: 0x0603EEBA RID: 257722 RVA: 0x010210DB File Offset: 0x0101F2DB
		public AutoPilotDefine.EEnableAutoPilot Value { get; set; }

		// Token: 0x17009ADF RID: 39647
		// (get) Token: 0x0603EEBB RID: 257723 RVA: 0x010210E4 File Offset: 0x0101F2E4
		// (set) Token: 0x0603EEBC RID: 257724 RVA: 0x010210EC File Offset: 0x0101F2EC
		public AutoPilotDefine.EDisableAutoPilotReason? DisableReason { get; set; }
	}
}
