using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002847 RID: 10311
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleFavorClassifyDataBase
{
	// Token: 0x0601474B RID: 83787 RVA: 0x005AE56A File Offset: 0x005AC76A
	public RoleFavorClassifyDataBase(string titleTableId, int roleId)
	{
		this.TitleTableId = titleTableId;
		this.RoleId = roleId;
	}

	// Token: 0x0601474C RID: 83788
	protected abstract void InitContentDataList();

	// Token: 0x0601474D RID: 83789 RVA: 0x005AE596 File Offset: 0x005AC796
	public List<RoleFavorContentDataBase> GetContentDataList()
	{
		if (this.ContentDataList.Count == 0)
		{
			this.InitContentDataList();
		}
		return this.ContentDataList;
	}

	// Token: 0x0601474E RID: 83790 RVA: 0x005AE5B1 File Offset: 0x005AC7B1
	[NullableContext(2)]
	public RoleFavorContentDataBase GetContentDataByIndex(int index)
	{
		if (index < 0 || index >= this.ContentDataList.Count)
		{
			return null;
		}
		return this.ContentDataList[index];
	}

	// Token: 0x0601474F RID: 83791 RVA: 0x005AE5D3 File Offset: 0x005AC7D3
	protected void SortContentDataList()
	{
		this.ContentDataList.Sort(delegate(RoleFavorContentDataBase a, RoleFavorContentDataBase b)
		{
			EFavorItemStatus itemStatus = this.GetItemStatus(a);
			EFavorItemStatus itemStatus2 = this.GetItemStatus(b);
			if (itemStatus != itemStatus2)
			{
				return itemStatus2 - itemStatus;
			}
			return a.ConfigId - b.ConfigId;
		});
	}

	// Token: 0x06014750 RID: 83792 RVA: 0x005AE5EC File Offset: 0x005AC7EC
	protected EFavorItemStatus GetItemStatus(RoleFavorContentDataBase contentData)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		if (roleInstanceById == null)
		{
			return EFavorItemStatus.ItemLocked;
		}
		RoleFavorData favorData = roleInstanceById.GetFavorData();
		if (contentData.FavorContentType == EFavorContentType.Action)
		{
			return (EFavorItemStatus)ModelBase<MotionModel>.Instance.GetRoleMotionState(roleInstanceById.GetRoleId(), contentData.ConfigId);
		}
		return favorData.GetFavorItemState(contentData.ConfigId, contentData.FavorContentType);
	}

	// Token: 0x06014751 RID: 83793
	protected abstract EFavorTabType GetFavorTabType();

	// Token: 0x04009E26 RID: 40486
	protected int RoleId;

	// Token: 0x04009E27 RID: 40487
	public string TitleTableId = "";

	// Token: 0x04009E28 RID: 40488
	protected List<RoleFavorContentDataBase> ContentDataList = new List<RoleFavorContentDataBase>();
}
