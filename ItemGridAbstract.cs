using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200196A RID: 6506
[NullableContext(2)]
[Nullable(0)]
public abstract class ItemGridAbstract : GridProxyAbstract<TItem>
{
	// Token: 0x0600BAE8 RID: 47848 RVA: 0x0031BAE4 File Offset: 0x00319CE4
	public ItemGridAbstract(AActor commonItemActor = null, ItemGridAbstract source = null, EUiViewName? belongView = null)
	{
		this.SourceItem = source;
		this.SetBelongViewName(belongView);
		if (commonItemActor != null)
		{
			this.CreateThenShowByActor(commonItemActor);
		}
	}

	// Token: 0x0600BAE9 RID: 47849 RVA: 0x0031BB04 File Offset: 0x00319D04
	protected ItemConfig GetItemConfig()
	{
		if (this.SourceItem != null)
		{
			return this.SourceItem.GetItemConfig();
		}
		return this.ItemConfig;
	}

	// Token: 0x0600BAEA RID: 47850 RVA: 0x0031BB20 File Offset: 0x00319D20
	public int GetItemId()
	{
		if (this.SourceItem != null)
		{
			return this.SourceItem.GetItemId();
		}
		return this.ItemId;
	}

	// Token: 0x0600BAEB RID: 47851 RVA: 0x0031BB3C File Offset: 0x00319D3C
	protected EUiViewName GetBelongView()
	{
		if (this.SourceItem != null)
		{
			return this.SourceItem.GetBelongView();
		}
		return this.BelongViewName.Value;
	}

	// Token: 0x0600BAEC RID: 47852 RVA: 0x0031BB60 File Offset: 0x00319D60
	public override void Refresh(TItem data, bool isSelected, int gridIndex)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData;
		this.RefreshByItemId(itemData.ItemId);
		this.ItemCount = data.Count;
		this.UniqueId = itemData.IncId;
	}

	// Token: 0x0600BAED RID: 47853 RVA: 0x0031BB98 File Offset: 0x00319D98
	public void RefreshByItemId(int itemId)
	{
		this.ItemId = itemId;
		this.ItemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (this.InstanceOfBehaviourPop(this))
		{
			((IItemGrid)this).RefreshQualitySprite();
			((IItemGrid)this).RefreshTextureIcon();
		}
	}

	// Token: 0x0600BAEE RID: 47854 RVA: 0x0031BBD1 File Offset: 0x00319DD1
	public void ShowDefaultDownText()
	{
		if (this.InstanceOfBehaviourPop(this))
		{
			((IItemGrid)this).RefreshTextDown(true, this.GetDefaultDownText());
		}
	}

	// Token: 0x0600BAEF RID: 47855 RVA: 0x0031BBF0 File Offset: 0x00319DF0
	[NullableContext(1)]
	public string GetDefaultDownText()
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.UniqueId);
		if (this.ItemCount > 1)
		{
			return this.ItemCount.ToString();
		}
		if (!StringUtils.IsEmpty((attributeItemData != null) ? attributeItemData.GetDefaultDownText() : null))
		{
			if (attributeItemData is PhantomItemData)
			{
				int phantomLevel = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(this.UniqueId).GetPhantomLevel();
				return StringUtils.Format(attributeItemData.GetDefaultDownText(), new string[]
				{
					phantomLevel.ToString()
				});
			}
			if (attributeItemData is WeaponItemData)
			{
				int level = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.UniqueId).GetLevel();
				return StringUtils.Format(attributeItemData.GetDefaultDownText(), new string[]
				{
					level.ToString()
				});
			}
		}
		return this.ItemCount.ToString();
	}

	// Token: 0x0600BAF0 RID: 47856 RVA: 0x0031BCB8 File Offset: 0x00319EB8
	[NullableContext(1)]
	private bool InstanceOfBehaviourPop(object obj)
	{
		IItemGrid itemGrid = obj as IItemGrid;
		return itemGrid != null && itemGrid.IsItemGrid;
	}

	// Token: 0x0600BAF1 RID: 47857 RVA: 0x0031BCD7 File Offset: 0x00319ED7
	public void SetBelongViewName(EUiViewName? viewName)
	{
		this.BelongViewName = viewName;
	}

	// Token: 0x04005860 RID: 22624
	private ItemConfig ItemConfig;

	// Token: 0x04005861 RID: 22625
	private int ItemId;

	// Token: 0x04005862 RID: 22626
	private int ItemCount;

	// Token: 0x04005863 RID: 22627
	private int UniqueId;

	// Token: 0x04005864 RID: 22628
	private EUiViewName? BelongViewName;

	// Token: 0x04005865 RID: 22629
	private readonly ItemGridAbstract SourceItem;
}
