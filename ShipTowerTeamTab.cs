using System;
using System.Runtime.CompilerServices;

// Token: 0x0200298B RID: 10635
[RequiredMember]
public class ShipTowerTeamTab
{
	// Token: 0x060152FE RID: 86782 RVA: 0x005DDC03 File Offset: 0x005DBE03
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerTeamTab()
	{
	}

	// Token: 0x0400A30E RID: 41742
	[RequiredMember]
	public EShipTowerTeamTabType TabType;

	// Token: 0x0400A30F RID: 41743
	[Nullable(1)]
	[RequiredMember]
	public string Title;
}
