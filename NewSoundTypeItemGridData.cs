using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200175E RID: 5982
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class NewSoundTypeItemGridData : MultiTemplateGridDataBase<INewSoundTypeItemData, NewSoundTypeItem>
{
	// Token: 0x0600A81A RID: 43034 RVA: 0x002CC3EB File Offset: 0x002CA5EB
	public NewSoundTypeItemGridData(INewSoundTypeItemData data, Action<int, UUIExtendToggle> toggleFunc, Func<int, bool> canToggleChange)
	{
		base.Data = data;
		this.ToggleFunc = toggleFunc;
		this.CanToggleChange = canToggleChange;
	}

	// Token: 0x0600A81B RID: 43035 RVA: 0x002CC408 File Offset: 0x002CA608
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x0600A81C RID: 43036 RVA: 0x002CC40B File Offset: 0x002CA60B
	public override NewSoundTypeItem CreateProxy()
	{
		NewSoundTypeItem newSoundTypeItem = new NewSoundTypeItem();
		newSoundTypeItem.BindOnToggleFunc(this.ToggleFunc);
		newSoundTypeItem.BindCanToggleExecuteChange(this.CanToggleChange);
		return newSoundTypeItem;
	}

	// Token: 0x04004F45 RID: 20293
	private Action<int, UUIExtendToggle> ToggleFunc;

	// Token: 0x04004F46 RID: 20294
	private Func<int, bool> CanToggleChange;
}
