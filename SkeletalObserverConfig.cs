using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;

// Token: 0x02002A21 RID: 10785
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class SkeletalObserverConfig : ConfigBase<SkeletalObserverConfig>
{
	// Token: 0x0601587C RID: 88188 RVA: 0x005F89B4 File Offset: 0x005F6BB4
	public SModelConfig GetMeshConfig(int meshId)
	{
		return DataTableUtil.GetDataTableRowFromName<SModelConfig>(EDataTable.ModelConfig, meshId.ToString());
	}
}
