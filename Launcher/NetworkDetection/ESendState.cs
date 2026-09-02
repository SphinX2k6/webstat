using System;

namespace CSharpScript.Launcher.NetworkDetection
{
	// Token: 0x020045E2 RID: 17890
	public enum ESendState
	{
		// Token: 0x0401AA75 RID: 109173
		ESS_None,
		// Token: 0x0401AA76 RID: 109174
		ESS_Compressing,
		// Token: 0x0401AA77 RID: 109175
		ESS_Sending,
		// Token: 0x0401AA78 RID: 109176
		ESS_Interrupted,
		// Token: 0x0401AA79 RID: 109177
		ESS_Fail,
		// Token: 0x0401AA7A RID: 109178
		ESS_Done
	}
}
