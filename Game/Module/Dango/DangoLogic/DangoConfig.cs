using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Dango.DangoLogic
{
	// Token: 0x02005DE7 RID: 24039
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class DangoConfig : ConfigBase<DangoConfig>
	{
		// Token: 0x0603C7F8 RID: 247800 RVA: 0x00F5D598 File Offset: 0x00F5B798
		public Dango? GetDangoById(int id)
		{
			return ConfigDangoById.GetConfig(id, true);
		}

		// Token: 0x0603C7F9 RID: 247801 RVA: 0x00F5D5A1 File Offset: 0x00F5B7A1
		public Dice? GetDiceById(int id)
		{
			return ConfigDiceById.GetConfig(id, true);
		}

		// Token: 0x0603C7FA RID: 247802 RVA: 0x00F5D5AA File Offset: 0x00F5B7AA
		public DangoSkill? GetDangoSkillById(int id)
		{
			return ConfigDangoSkillById.GetConfig(id, true);
		}

		// Token: 0x0603C7FB RID: 247803 RVA: 0x00F5D5B3 File Offset: 0x00F5B7B3
		public DangoSkillEffect? GetDangoSkillEffectById(int id)
		{
			return ConfigDangoSkillEffectById.GetConfig(id, true);
		}
	}
}
