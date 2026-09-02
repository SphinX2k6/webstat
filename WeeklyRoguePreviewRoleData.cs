using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002D61 RID: 11617
public class WeeklyRoguePreviewRoleData : RoleDataBase
{
	// Token: 0x0601774E RID: 96078 RVA: 0x00680A32 File Offset: 0x0067EC32
	public WeeklyRoguePreviewRoleData(int id) : base(id)
	{
	}

	// Token: 0x0601774F RID: 96079 RVA: 0x00680A3B File Offset: 0x0067EC3B
	public override bool IsTrialRole()
	{
		return true;
	}

	// Token: 0x06017750 RID: 96080 RVA: 0x00680A40 File Offset: 0x0067EC40
	[NullableContext(1)]
	public override string GetName(int? playerId = null)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleName(base.GetRoleConfig().Name);
	}

	// Token: 0x06017751 RID: 96081 RVA: 0x00680A65 File Offset: 0x0067EC65
	public override int GetRoleId()
	{
		return this.Id;
	}

	// Token: 0x06017752 RID: 96082 RVA: 0x00680A6D File Offset: 0x0067EC6D
	public override bool IsOnlineRole()
	{
		return false;
	}

	// Token: 0x06017753 RID: 96083 RVA: 0x00680A70 File Offset: 0x0067EC70
	public override bool CanChangeName()
	{
		return false;
	}

	// Token: 0x06017754 RID: 96084 RVA: 0x00680A73 File Offset: 0x0067EC73
	public override int GetRoleCreateTime()
	{
		return 0;
	}

	// Token: 0x06017755 RID: 96085 RVA: 0x00680A76 File Offset: 0x0067EC76
	public override bool GetIsNew()
	{
		return false;
	}
}
