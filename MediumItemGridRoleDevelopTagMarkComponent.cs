using System;
using System.Runtime.CompilerServices;

// Token: 0x020019DA RID: 6618
public class MediumItemGridRoleDevelopTagMarkComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BDD4 RID: 48596 RVA: 0x00324AB1 File Offset: 0x00322CB1
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_RoleDevelopTagMark";
	}

	// Token: 0x0600BDD5 RID: 48597 RVA: 0x00324AB8 File Offset: 0x00322CB8
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
