using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001B38 RID: 6968
[Nullable(new byte[]
{
	0,
	1
})]
public class EditBattleTeamConfig : ConfigBase<EditBattleTeamConfig>
{
	// Token: 0x0600C8FE RID: 51454 RVA: 0x00353C3C File Offset: 0x00351E3C
	public InstanceDungeon GetDungeonConfig(int dungeonId)
	{
		return ConfigInstanceDungeonById.GetConfig(dungeonId, true).Value;
	}

	// Token: 0x0600C8FF RID: 51455 RVA: 0x00353C58 File Offset: 0x00351E58
	public FightFormation? GetFightFormationConfig(int fightFormationId)
	{
		if (fightFormationId == 0)
		{
			return null;
		}
		return ConfigFightFormationById.GetConfig(fightFormationId, true);
	}
}
