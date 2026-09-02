using System;
using System.Runtime.CompilerServices;

// Token: 0x020019BA RID: 6586
public class MediumItemGridCurTagComponent : MediumItemGridComponent
{
	// Token: 0x0600BD26 RID: 48422 RVA: 0x003235D3 File Offset: 0x003217D3
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTagCur";
	}

	// Token: 0x0600BD27 RID: 48423 RVA: 0x003235DC File Offset: 0x003217DC
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
