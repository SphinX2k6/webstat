using System;
using System.Runtime.CompilerServices;

// Token: 0x020019E7 RID: 6631
public class MediumItemGridTemplateIconComponent : MediumItemGridComponent
{
	// Token: 0x0600BE10 RID: 48656 RVA: 0x0032578E File Offset: 0x0032398E
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_TemplateIcon";
	}

	// Token: 0x0600BE11 RID: 48657 RVA: 0x00325798 File Offset: 0x00323998
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
