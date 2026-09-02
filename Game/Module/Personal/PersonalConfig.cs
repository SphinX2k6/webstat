using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Personal
{
	// Token: 0x0200564E RID: 22094
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class PersonalConfig : ConfigBase<PersonalConfig>
	{
		// Token: 0x060384E5 RID: 230629 RVA: 0x00E4107B File Offset: 0x00E3F27B
		public PlayerHeadRe? GetPlayerHeadConfig(int id)
		{
			return ConfigPlayerHeadReById.GetConfig(id, true);
		}

		// Token: 0x060384E6 RID: 230630 RVA: 0x00E41084 File Offset: 0x00E3F284
		[NullableContext(2)]
		public IReadOnlyList<PlayerHeadRe> GetAllPlayerHeadConfig()
		{
			return ConfigPlayerHeadReAll.GetConfigList(true);
		}

		// Token: 0x060384E7 RID: 230631 RVA: 0x00E4108C File Offset: 0x00E3F28C
		public string GetBirthLocalText(int date, EBirthDateType dateType)
		{
			BirthDayText? config = ConfigBirthDayTextByDateAndType.GetConfig(date, (int)dateType, true);
			string text = "";
			if (config != null)
			{
				text = (ConfigMultiTextLang.GetLocalTextNew(config.Value.TextId, null) ?? "");
			}
			if (text == "")
			{
				text = date.ToString();
			}
			return text;
		}
	}
}
