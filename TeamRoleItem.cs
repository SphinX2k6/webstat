using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200143A RID: 5178
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class TeamRoleItem : GridProxyAbstract<TeamData>
{
	// Token: 0x06009022 RID: 36898 RVA: 0x0025E0B0 File Offset: 0x0025C2B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06009023 RID: 36899 RVA: 0x0025E10A File Offset: 0x0025C30A
	public override void Refresh(TeamData data, bool isSelected, int gridIndex)
	{
		this.CurrentTeamData = data;
		this.RefreshRoleTexture();
	}

	// Token: 0x06009024 RID: 36900 RVA: 0x0025E11C File Offset: 0x0025C31C
	private void RefreshRoleTexture()
	{
		if (this.CurrentTeamData.RoleId == 0)
		{
			base.GetTexture(2).SetUIActive(false);
			return;
		}
		base.GetTexture(2).SetUIActive(true);
		base.SetRoleIcon(ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.CurrentTeamData.RoleId).Value.RoleHeadIconCircle, base.GetTexture(2), this.CurrentTeamData.RoleId, null, null);
	}

	// Token: 0x040042D6 RID: 17110
	private TeamData CurrentTeamData = new TeamData();

	// Token: 0x02007839 RID: 30777
	[NullableContext(0)]
	private class ETeamRoleComponent
	{
		// Token: 0x04029594 RID: 169364
		public const int Button = 0;

		// Token: 0x04029595 RID: 169365
		public const int BgSprite = 1;

		// Token: 0x04029596 RID: 169366
		public const int RoleTexture = 2;
	}
}
