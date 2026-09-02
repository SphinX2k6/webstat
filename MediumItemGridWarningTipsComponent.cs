using System;
using System.Runtime.CompilerServices;

// Token: 0x020019F4 RID: 6644
public class MediumItemGridWarningTipsComponent : MediumItemGridComponent
{
	// Token: 0x0600BE3F RID: 48703 RVA: 0x00326258 File Offset: 0x00324458
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_WarningIcon";
	}

	// Token: 0x0600BE40 RID: 48704 RVA: 0x00326260 File Offset: 0x00324460
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
