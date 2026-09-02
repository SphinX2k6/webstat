using System;
using System.Runtime.CompilerServices;

// Token: 0x020019EC RID: 6636
public class MediumItemGridUpgradeComponent : MediumItemGridComponent
{
	// Token: 0x0600BE1E RID: 48670 RVA: 0x00325903 File Offset: 0x00323B03
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_Upgrade";
	}

	// Token: 0x0600BE1F RID: 48671 RVA: 0x0032590C File Offset: 0x00323B0C
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is bool)
		{
			bool active = (bool)data;
			this.SetActive(active);
		}
	}
}
