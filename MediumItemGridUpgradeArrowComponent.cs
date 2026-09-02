using System;
using System.Runtime.CompilerServices;

// Token: 0x020019EB RID: 6635
public class MediumItemGridUpgradeArrowComponent : MediumItemGridComponent
{
	// Token: 0x0600BE1B RID: 48667 RVA: 0x003258CE File Offset: 0x00323ACE
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_UpgradeArrow";
	}

	// Token: 0x0600BE1C RID: 48668 RVA: 0x003258D8 File Offset: 0x00323AD8
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
