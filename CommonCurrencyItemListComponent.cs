using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018A0 RID: 6304
[NullableContext(1)]
[Nullable(0)]
public class CommonCurrencyItemListComponent
{
	// Token: 0x0600B510 RID: 46352 RVA: 0x0030384E File Offset: 0x00301A4E
	public CommonCurrencyItemListComponent(UUIItem rootItem)
	{
		this.RootItem = rootItem;
	}

	// Token: 0x0600B511 RID: 46353 RVA: 0x00303868 File Offset: 0x00301A68
	public void SetResourceId(string resourceId)
	{
		this.ResourceId = resourceId;
	}

	// Token: 0x0600B512 RID: 46354 RVA: 0x00303871 File Offset: 0x00301A71
	private CommonCurrencyItem GetCurrentItemByItemId(int itemId)
	{
		if (ModelBase<PowerModel>.Instance.CheckItemIfPowerItem(itemId))
		{
			return new PowerCurrencyItem();
		}
		return new CommonCurrencyItem();
	}

	// Token: 0x0600B513 RID: 46355 RVA: 0x0030388C File Offset: 0x00301A8C
	private UniTask SetCurrencyItemListInternal(int[] itemIdList)
	{
		CommonCurrencyItemListComponent.<SetCurrencyItemListInternal>d__8 <SetCurrencyItemListInternal>d__;
		<SetCurrencyItemListInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetCurrencyItemListInternal>d__.<>4__this = this;
		<SetCurrencyItemListInternal>d__.itemIdList = itemIdList;
		<SetCurrencyItemListInternal>d__.<>1__state = -1;
		<SetCurrencyItemListInternal>d__.<>t__builder.Start<CommonCurrencyItemListComponent.<SetCurrencyItemListInternal>d__8>(ref <SetCurrencyItemListInternal>d__);
		return <SetCurrencyItemListInternal>d__.<>t__builder.Task;
	}

	// Token: 0x0600B514 RID: 46356 RVA: 0x003038D8 File Offset: 0x00301AD8
	public UniTask SetCurrencyItemList(int[] itemIdList)
	{
		CommonCurrencyItemListComponent.<SetCurrencyItemList>d__9 <SetCurrencyItemList>d__;
		<SetCurrencyItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetCurrencyItemList>d__.<>4__this = this;
		<SetCurrencyItemList>d__.itemIdList = itemIdList;
		<SetCurrencyItemList>d__.<>1__state = -1;
		<SetCurrencyItemList>d__.<>t__builder.Start<CommonCurrencyItemListComponent.<SetCurrencyItemList>d__9>(ref <SetCurrencyItemList>d__);
		return <SetCurrencyItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600B515 RID: 46357 RVA: 0x00303923 File Offset: 0x00301B23
	public List<CommonCurrencyItem> GetCurrencyItemList()
	{
		return this.CurrencyItemList;
	}

	// Token: 0x04005583 RID: 21891
	private List<CommonCurrencyItem> CurrencyItemList;

	// Token: 0x04005584 RID: 21892
	private readonly UUIItem RootItem;

	// Token: 0x04005585 RID: 21893
	private string ResourceId = "UIItem_CommonCurrencyItem";

	// Token: 0x04005586 RID: 21894
	private bool IsExecuting;

	// Token: 0x04005587 RID: 21895
	[Nullable(2)]
	private int[] PendingItemIdList;
}
