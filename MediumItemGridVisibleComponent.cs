using System;
using System.Runtime.CompilerServices;

// Token: 0x020019ED RID: 6637
public class MediumItemGridVisibleComponent : MediumItemGridComponent
{
	// Token: 0x0600BE21 RID: 48673 RVA: 0x00325938 File Offset: 0x00323B38
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
