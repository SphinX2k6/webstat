using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001ABB RID: 6843
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengeResultRoleInfo
{
	// Token: 0x0600C48B RID: 50315 RVA: 0x0033DFB4 File Offset: 0x0033C1B4
	public int GetRoleSkinId()
	{
		return this.RoleSkinId;
	}

	// Token: 0x0600C48C RID: 50316 RVA: 0x0033DFBC File Offset: 0x0033C1BC
	public int GetRoleLevel()
	{
		return this.RoleLevel;
	}

	// Token: 0x0600C48D RID: 50317 RVA: 0x0033DFC4 File Offset: 0x0033C1C4
	public int GetDangoId()
	{
		return this.DangoId;
	}

	// Token: 0x0600C48E RID: 50318 RVA: 0x0033DFCC File Offset: 0x0033C1CC
	[NullableContext(2)]
	public global::AbyssChallengeRoleHonor GetMainHonor()
	{
		return this.MainHonor;
	}

	// Token: 0x0600C48F RID: 50319 RVA: 0x0033DFD4 File Offset: 0x0033C1D4
	public global::AbyssChallengeRoleHonor[] GetSubHonor()
	{
		return this.SubHonor;
	}

	// Token: 0x0600C490 RID: 50320 RVA: 0x0033DFDC File Offset: 0x0033C1DC
	public void Phrase(Aki.Protocol.AbyssChallengeResultRoleInfo data)
	{
		this.RoleSkinId = data.RoleSkinId;
		this.RoleLevel = data.RoleLevel;
		this.DangoId = data.LittleRoleId;
		this.MainHonor = new global::AbyssChallengeRoleHonor();
		this.MainHonor.Phrase(data.MainHonor);
		this.SubHonor = Array.Empty<global::AbyssChallengeRoleHonor>();
		List<global::AbyssChallengeRoleHonor> list = new List<global::AbyssChallengeRoleHonor>();
		int count = data.OtherHonor.Count;
		for (int i = 0; i < count; i++)
		{
			global::AbyssChallengeRoleHonor abyssChallengeRoleHonor = new global::AbyssChallengeRoleHonor();
			abyssChallengeRoleHonor.Phrase(data.OtherHonor[i]);
			list.Add(abyssChallengeRoleHonor);
		}
		this.SubHonor = list.ToArray();
	}

	// Token: 0x04005E42 RID: 24130
	private int RoleSkinId;

	// Token: 0x04005E43 RID: 24131
	private int RoleLevel;

	// Token: 0x04005E44 RID: 24132
	private int DangoId;

	// Token: 0x04005E45 RID: 24133
	[Nullable(2)]
	private global::AbyssChallengeRoleHonor MainHonor;

	// Token: 0x04005E46 RID: 24134
	private global::AbyssChallengeRoleHonor[] SubHonor = Array.Empty<global::AbyssChallengeRoleHonor>();
}
