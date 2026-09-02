using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020023D3 RID: 9171
public class CumulativePayShopContentPanel : UiPanelBase
{
	// Token: 0x06011BB4 RID: 72628 RVA: 0x004DED5C File Offset: 0x004DCF5C
	private void OnPreviewCheckClick()
	{
		PayShopUtil.OpenItemPreview(ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.PreviewItemConfigId)), this.PreviewItemConfigId);
	}

	// Token: 0x06011BB5 RID: 72629 RVA: 0x004DED80 File Offset: 0x004DCF80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011BB6 RID: 72630 RVA: 0x004DEDC8 File Offset: 0x004DCFC8
	protected override void OnStart()
	{
		this.ApplyCheckButtonState();
	}

	// Token: 0x06011BB7 RID: 72631 RVA: 0x004DEDD0 File Offset: 0x004DCFD0
	public void SetCheckButtonVisible(bool active)
	{
		this.CheckBtnVisible = active;
		this.ApplyCheckButtonState();
	}

	// Token: 0x06011BB8 RID: 72632 RVA: 0x004DEDE0 File Offset: 0x004DCFE0
	public void RefreshCheckButtonVisibility(int itemConfigId)
	{
		this.PreviewItemConfigId = itemConfigId;
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemConfigId));
		this.SetCheckButtonVisible(PayShopDefine.PayShopNeedCheckBtnItemTypeSet.Contains(itemDataTypeByConfigId));
	}

	// Token: 0x06011BB9 RID: 72633 RVA: 0x004DEE18 File Offset: 0x004DD018
	private void ApplyCheckButtonState()
	{
		if (!this.CheckBtnVisible)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(0);
			AActor aactor = (item2 != null) ? item2.GetOwner() : null;
			if (aactor == null || !aactor.IsValid())
			{
				return;
			}
			if (this.CheckBtnItem == null)
			{
				this.CheckBtnItem = new PayShopCheckBtnItem();
				this.CheckBtnItem.CreateByActorAsync(aactor, null, false).ContinueWith(delegate()
				{
					this.CheckBtnItem.SetCallback(new Action(this.OnPreviewCheckClick));
					UUIItem item4 = base.GetItem(0);
					if (item4 == null)
					{
						return;
					}
					item4.SetUIActive(this.CheckBtnVisible);
				});
				return;
			}
			UUIItem item3 = base.GetItem(0);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(true);
			return;
		}
	}

	// Token: 0x04008ACB RID: 35531
	[Nullable(2)]
	private PayShopCheckBtnItem CheckBtnItem;

	// Token: 0x04008ACC RID: 35532
	private bool CheckBtnVisible;

	// Token: 0x04008ACD RID: 35533
	private int PreviewItemConfigId;

	// Token: 0x02008706 RID: 34566
	private enum EComponents
	{
		// Token: 0x0402DAB9 RID: 187065
		BtnItem
	}
}
