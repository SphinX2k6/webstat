using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003424 RID: 13348
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RenderModuleConfig : ConfigBase<RenderModuleConfig>
{
	// Token: 0x0601BDBD RID: 114109 RVA: 0x0084E854 File Offset: 0x0084CA54
	protected override bool OnInit()
	{
		this.InitLevelCustomPrimitiveData();
		return true;
	}

	// Token: 0x0601BDBE RID: 114110 RVA: 0x0084E85D File Offset: 0x0084CA5D
	protected override bool OnClear()
	{
		Dictionary<int, LevelCustomPrimitiveData> levelCustomPrimitiveData = this.LevelCustomPrimitiveData;
		if (levelCustomPrimitiveData != null)
		{
			levelCustomPrimitiveData.Clear();
		}
		this.LevelCustomPrimitiveData = null;
		return true;
	}

	// Token: 0x0601BDBF RID: 114111 RVA: 0x0084E878 File Offset: 0x0084CA78
	private void InitLevelCustomPrimitiveData()
	{
		this.LevelCustomPrimitiveData = new Dictionary<int, LevelCustomPrimitiveData>();
		IReadOnlyList<LevelCustomPrimitiveData> configList = ConfigLevelCustomPrimitiveDataAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (LevelCustomPrimitiveData value in configList)
			{
				this.LevelCustomPrimitiveData[value.PbDataId] = value;
			}
		}
	}

	// Token: 0x0400E123 RID: 57635
	public Dictionary<int, LevelCustomPrimitiveData> LevelCustomPrimitiveData;
}
