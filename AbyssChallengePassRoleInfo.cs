using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001AC3 RID: 6851
[NullableContext(1)]
[Nullable(0)]
public class AbyssChallengePassRoleInfo
{
	// Token: 0x0600C4CC RID: 50380 RVA: 0x0033EEC3 File Offset: 0x0033D0C3
	public int GetRoleSkinId()
	{
		return this.RoleSkinId;
	}

	// Token: 0x0600C4CD RID: 50381 RVA: 0x0033EECB File Offset: 0x0033D0CB
	public int GetRoleLevel()
	{
		return this.RoleLevel;
	}

	// Token: 0x0600C4CE RID: 50382 RVA: 0x0033EED3 File Offset: 0x0033D0D3
	public int GetDangoId()
	{
		return this.DangoId;
	}

	// Token: 0x0600C4CF RID: 50383 RVA: 0x0033EEDB File Offset: 0x0033D0DB
	public int[] GetEquipmentList()
	{
		return this.EquipmentList;
	}

	// Token: 0x0600C4D0 RID: 50384 RVA: 0x0033EEE3 File Offset: 0x0033D0E3
	public void Phrase(AbyssPassRoleInfo data)
	{
		this.RoleSkinId = data.RoleSkinId;
		this.RoleLevel = data.RoleLevel;
		this.DangoId = data.LittleRoleId;
		this.EquipmentList = data.PluginItemIds.ToArray<int>();
	}

	// Token: 0x04005E6A RID: 24170
	private int RoleSkinId;

	// Token: 0x04005E6B RID: 24171
	private int RoleLevel;

	// Token: 0x04005E6C RID: 24172
	private int DangoId;

	// Token: 0x04005E6D RID: 24173
	private int[] EquipmentList = Array.Empty<int>();
}
