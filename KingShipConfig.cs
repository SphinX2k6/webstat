using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002097 RID: 8343
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class KingShipConfig : ConfigBase<KingShipConfig>
{
	// Token: 0x0600FEA8 RID: 65192 RVA: 0x0045E578 File Offset: 0x0045C778
	public KingShipAttribute GetKingShipAttribute(int id)
	{
		return ConfigKingShipAttributeById.GetConfig(id, true).Value;
	}

	// Token: 0x0600FEA9 RID: 65193 RVA: 0x0045E594 File Offset: 0x0045C794
	public KingShipBuff GetKingShipBuff(int id)
	{
		return ConfigKingShipBuffById.GetConfig(id, true).Value;
	}

	// Token: 0x0600FEAA RID: 65194 RVA: 0x0045E5B0 File Offset: 0x0045C7B0
	public Reigns GetReigns(int id)
	{
		return ConfigReignsById.GetConfig(id, true).Value;
	}

	// Token: 0x0600FEAB RID: 65195 RVA: 0x0045E5CC File Offset: 0x0045C7CC
	public Reigns? TryGetReigns(int id)
	{
		return ConfigReignsById.GetConfig(id, true);
	}

	// Token: 0x0600FEAC RID: 65196 RVA: 0x0045E5D8 File Offset: 0x0045C7D8
	public ReignsCard GetReignsCallCard(int id)
	{
		return ConfigReignsCardById.GetConfig(id, true).Value;
	}
}
