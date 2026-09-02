using System;
using System.Runtime.CompilerServices;

// Token: 0x020019AE RID: 6574
public class MediumItemGridBranchUpgradeComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BCEC RID: 48364 RVA: 0x00322E05 File Offset: 0x00321005
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_UpgradeTriangle";
	}

	// Token: 0x0600BCED RID: 48365 RVA: 0x00322E0C File Offset: 0x0032100C
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
