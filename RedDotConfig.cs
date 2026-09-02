using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020032CC RID: 13004
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RedDotConfig : ConfigBase<RedDotConfig>
{
	// Token: 0x0601B48D RID: 111757 RVA: 0x0083184A File Offset: 0x0082FA4A
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601B48E RID: 111758 RVA: 0x00831850 File Offset: 0x0082FA50
	public static Dictionary<ERedDotName, ERedDotName?> GetRelativeNameMap()
	{
		Dictionary<ERedDotName, ERedDotName?> dictionary = new Dictionary<ERedDotName, ERedDotName?>();
		foreach (RedDot redDot in ConfigRedDotByRelativeName.GetConfigList(true))
		{
			ERedDotName key;
			ERedDotName value;
			if (Enum.TryParse<ERedDotName>(redDot.Name, out key) && Enum.TryParse<ERedDotName>(redDot.RelativeName, out value))
			{
				dictionary.Add(key, new ERedDotName?(value));
			}
		}
		return dictionary;
	}
}
