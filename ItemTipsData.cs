using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;

// Token: 0x02001985 RID: 6533
[NullableContext(1)]
[Nullable(0)]
public class ItemTipsData
{
	// Token: 0x0600BBDB RID: 48091 RVA: 0x0031DAE4 File Offset: 0x0031BCE4
	public ItemTipsData(ItemTipsParam data)
	{
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.ItemId);
		this.ConfigId = data.ItemId;
		this.IncId = data.ItemUid;
		this.CanSkip = data.CanSkip;
		this.PreviewType = itemConfigData.PreviewType;
		this.ShowPreview = itemConfigData.ShowPreview;
		this.Title = itemConfigData.Name;
		this.QualityId = itemConfigData.QualityId;
		List<IGetWayItemData> list = new List<IGetWayItemData>();
		if (itemConfigData.ItemAccess != null && itemConfigData.ItemAccess.Length != 0)
		{
			int[] itemAccess = itemConfigData.ItemAccess;
			for (int i = 0; i < itemAccess.Length; i++)
			{
				int num = itemAccess[i];
				AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(num);
				if (configById != null && ModelBase<SkipInterfaceModel>.Instance.CheckAccessPathCondition(num))
				{
					int getWayIdLocal = num;
					GetWayItemData item = new GetWayItemData(num, (EGetWayItemType)configById.Value.Type, configById.Value.Description, configById.Value.SortIndex, delegate()
					{
						if (this.CanSkip)
						{
							SkipTaskManager.RunByConfigId(getWayIdLocal, this.ConfigId);
							return;
						}
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SkipTask_Prevent", Array.Empty<object>());
					});
					list.Add(item);
				}
			}
		}
		this.GetWayData = list.ToArray();
	}

	// Token: 0x0600BBDC RID: 48092 RVA: 0x0031DC5C File Offset: 0x0031BE5C
	public bool CanDeprecate()
	{
		if (this.IncId <= 0)
		{
			return false;
		}
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.IncId);
		return attributeItemData != null && attributeItemData.CanDeprecate();
	}

	// Token: 0x0600BBDD RID: 48093 RVA: 0x0031DC90 File Offset: 0x0031BE90
	public bool IsShowIconBig()
	{
		return this.OnIsShowIconBig();
	}

	// Token: 0x0600BBDE RID: 48094 RVA: 0x0031DC98 File Offset: 0x0031BE98
	protected virtual bool OnIsShowIconBig()
	{
		return false;
	}

	// Token: 0x040058C1 RID: 22721
	public int IncId;

	// Token: 0x040058C2 RID: 22722
	public int ConfigId;

	// Token: 0x040058C3 RID: 22723
	public string Title;

	// Token: 0x040058C4 RID: 22724
	public int QualityId;

	// Token: 0x040058C5 RID: 22725
	public bool CanSkip;

	// Token: 0x040058C6 RID: 22726
	public bool IsIconByType;

	// Token: 0x040058C7 RID: 22727
	public bool IsQualityByType;

	// Token: 0x040058C8 RID: 22728
	public EItemTipsType ItemType;

	// Token: 0x040058C9 RID: 22729
	public ESkipName PreviewType = ESkipName.NoSkip;

	// Token: 0x040058CA RID: 22730
	public bool ShowPreview;

	// Token: 0x040058CB RID: 22731
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IGetWayItemData[] GetWayData;

	// Token: 0x040058CC RID: 22732
	[Nullable(2)]
	public string LimitTimeTxt;

	// Token: 0x040058CD RID: 22733
	public Func<int, bool> CanClickLockButton = (int uniqueId) => true;

	// Token: 0x040058CE RID: 22734
	[Nullable(2)]
	public Func<int> UpdateShowNumCallback;

	// Token: 0x040058CF RID: 22735
	[Nullable(2)]
	public Func<bool> IsShowNumTextCallback;
}
