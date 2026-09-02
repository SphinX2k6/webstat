using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal
{
	// Token: 0x02004BEC RID: 19436
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegionalTerminalConfig : ConfigBase<RegionalTerminalConfig>
	{
		// Token: 0x06032B5A RID: 207706 RVA: 0x00CB3BD4 File Offset: 0x00CB1DD4
		public AreaTerminal? GetAreaTerminalByGameplayId(int gameplayId)
		{
			return ConfigAreaTerminalById.GetConfig(gameplayId, true);
		}

		// Token: 0x06032B5B RID: 207707 RVA: 0x00CB3BDD File Offset: 0x00CB1DDD
		public IReadOnlyList<AreaTerminal> GetAreaTerminalByCountryId(int countryId)
		{
			return ConfigAreaTerminalByCountry.GetConfigList(countryId, true) ?? new List<AreaTerminal>();
		}

		// Token: 0x06032B5C RID: 207708 RVA: 0x00CB3BEF File Offset: 0x00CB1DEF
		public IReadOnlyList<AreaTerminal> GetAllAreaTerminal()
		{
			return ConfigAreaTerminalAll.GetConfigList(true) ?? new List<AreaTerminal>();
		}

		// Token: 0x06032B5D RID: 207709 RVA: 0x00CB3C00 File Offset: 0x00CB1E00
		public AreaTerminalGroup? GetAreaTerminalGroup(int groupId)
		{
			return ConfigAreaTerminalGroupById.GetConfig(groupId, true);
		}

		// Token: 0x06032B5E RID: 207710 RVA: 0x00CB3C09 File Offset: 0x00CB1E09
		public IReadOnlyList<AreaMapGroup> GetAllAreaMapGroup()
		{
			return ConfigAreaMapGroupAll.GetConfigList(true) ?? new List<AreaMapGroup>();
		}

		// Token: 0x06032B5F RID: 207711 RVA: 0x00CB3C1A File Offset: 0x00CB1E1A
		public AreaMapGroup? GetAreaMapGroup(int groupId)
		{
			return ConfigAreaMapGroupById.GetConfig(groupId, true);
		}
	}
}
