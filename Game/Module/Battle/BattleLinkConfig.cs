using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F2B RID: 24363
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BattleLinkConfig : ConfigBase<BattleLinkConfig>
	{
		// Token: 0x0603D301 RID: 250625 RVA: 0x00F8D224 File Offset: 0x00F8B424
		public LinkData? GetLinkDataConfig(int id)
		{
			if (id == 0)
			{
				return null;
			}
			return ConfigLinkDataById.GetConfig(id, true);
		}

		// Token: 0x0603D302 RID: 250626 RVA: 0x00F8D248 File Offset: 0x00F8B448
		public LinkCharacter? GetRoleConfig(int id)
		{
			if (id == 0)
			{
				return null;
			}
			return ConfigLinkCharacterById.GetConfig(id, true);
		}

		// Token: 0x0603D303 RID: 250627 RVA: 0x00F8D26C File Offset: 0x00F8B46C
		public LinkParam? GetLinkParam(int id)
		{
			if (id == 0)
			{
				return null;
			}
			return ConfigLinkParamById.GetConfig(id, true);
		}

		// Token: 0x0603D304 RID: 250628 RVA: 0x00F8D290 File Offset: 0x00F8B490
		public LinkPreload? GetLinkPreloadConfig(int id)
		{
			if (id == 0)
			{
				return null;
			}
			return ConfigLinkPreloadById.GetConfig(id, true);
		}
	}
}
