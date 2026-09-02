using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002423 RID: 9251
public class PersonalCardItem : PersonalCardBaseItem
{
	// Token: 0x06011E52 RID: 73298 RVA: 0x004EC02C File Offset: 0x004EA22C
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIItem)));
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
	}

	// Token: 0x06011E53 RID: 73299 RVA: 0x004EC06C File Offset: 0x004EA26C
	[NullableContext(1)]
	public override void Refresh(PersonalCardData data, bool isSelected, int gridIndex)
	{
		base.Refresh(data, isSelected, gridIndex);
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		bool flag = ControllerBase<PersonalController>.Instance.CheckCardIsUsing(this.CardConfig.Value.Id);
		item.SetUIActive(flag && !this.IsOtherCardItem);
		item2.SetUIActive(!data.IsUnLock);
	}

	// Token: 0x06011E54 RID: 73300 RVA: 0x004EC0D2 File Offset: 0x004EA2D2
	public void SetIsOtherCardItem(bool isOther)
	{
		this.IsOtherCardItem = isOther;
	}

	// Token: 0x04008C17 RID: 35863
	private bool IsOtherCardItem;
}
