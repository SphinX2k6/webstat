using System;

// Token: 0x020028F6 RID: 10486
public class RolePreviewAgent : RoleViewAgent
{
	// Token: 0x06014D41 RID: 85313 RVA: 0x005C4E08 File Offset: 0x005C3008
	public override ERoleSystemMode GetRoleSystemMode()
	{
		return ERoleSystemMode.Preview;
	}
}
