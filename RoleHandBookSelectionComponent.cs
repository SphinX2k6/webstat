using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;

// Token: 0x0200278B RID: 10123
[NullableContext(1)]
[Nullable(0)]
public class RoleHandBookSelectionComponent
{
	// Token: 0x06013FB4 RID: 81844 RVA: 0x00591A92 File Offset: 0x0058FC92
	public void UpdateRoleHandBookItem(int id)
	{
	}

	// Token: 0x06013FB5 RID: 81845 RVA: 0x00591A94 File Offset: 0x0058FC94
	public int GetCurSelectRoleId()
	{
		return 0;
	}

	// Token: 0x06013FB6 RID: 81846 RVA: 0x00591A97 File Offset: 0x0058FC97
	public IReadOnlyDictionary<object, RoleHandBookSelectionItem> GetAllRoleItemMap()
	{
		return this.RoleScroll.GetScrollItemMap();
	}

	// Token: 0x06013FB7 RID: 81847 RVA: 0x00591AA4 File Offset: 0x0058FCA4
	public void UpdateComponent(RoleDataBase[] roleList)
	{
	}

	// Token: 0x06013FB8 RID: 81848 RVA: 0x00591AA6 File Offset: 0x0058FCA6
	protected void RefreshRoleItem(RoleDataBase[] roleList)
	{
	}

	// Token: 0x06013FB9 RID: 81849 RVA: 0x00591AA8 File Offset: 0x0058FCA8
	public void UpdateItemByRoleId(int roleId)
	{
		RoleHandBookSelectionItem roleHandBookSelectionItem;
		if (this.GetAllRoleItemMap().TryGetValue(roleId, out roleHandBookSelectionItem))
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			roleHandBookSelectionItem.UpdateItem(roleDataById);
		}
	}

	// Token: 0x06013FBA RID: 81850 RVA: 0x00591ADE File Offset: 0x0058FCDE
	public void PlaySequence()
	{
		if (this.RoleHandBookItem == null)
		{
			return;
		}
		this.RoleHandBookItem.PlaySequence();
	}

	// Token: 0x06013FBB RID: 81851 RVA: 0x00591AF4 File Offset: 0x0058FCF4
	protected void OnBeforeDestroy()
	{
	}

	// Token: 0x04009B91 RID: 39825
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<RoleHandBookSelectionItem> RoleScroll;

	// Token: 0x04009B92 RID: 39826
	[Nullable(2)]
	protected RoleHandBookItem RoleHandBookItem;
}
