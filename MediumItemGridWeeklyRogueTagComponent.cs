using System;
using System.Runtime.CompilerServices;

// Token: 0x020019F5 RID: 6645
public class MediumItemGridWeeklyRogueTagComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BE42 RID: 48706 RVA: 0x0032628B File Offset: 0x0032448B
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTagDescript";
	}

	// Token: 0x0600BE43 RID: 48707 RVA: 0x00326292 File Offset: 0x00324492
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
