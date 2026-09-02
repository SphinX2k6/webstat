using System;
using System.Runtime.CompilerServices;

// Token: 0x020019E6 RID: 6630
public class MediumItemGridTeamIconComponent : MediumItemGridComponent
{
	// Token: 0x0600BE0D RID: 48653 RVA: 0x00325750 File Offset: 0x00323950
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTeam";
	}

	// Token: 0x0600BE0E RID: 48654 RVA: 0x00325758 File Offset: 0x00323958
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (!(data is bool) || !(bool)data)
		{
			this.SetActive(false);
			return;
		}
		this.SetActive(true);
	}
}
