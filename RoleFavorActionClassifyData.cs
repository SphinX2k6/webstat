using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200284A RID: 10314
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorActionClassifyData : RoleFavorClassifyDataBase
{
	// Token: 0x0601475E RID: 83806 RVA: 0x005AE81C File Offset: 0x005ACA1C
	public RoleFavorActionClassifyData(string titleTableId, int roleId, EFavorActionType typeParam) : base(titleTableId, roleId)
	{
		this.TypeParam = typeParam;
	}

	// Token: 0x0601475F RID: 83807 RVA: 0x005AE834 File Offset: 0x005ACA34
	protected override EFavorTabType GetFavorTabType()
	{
		return EFavorTabType.Action;
	}

	// Token: 0x06014760 RID: 83808 RVA: 0x005AE838 File Offset: 0x005ACA38
	protected override void InitContentDataList()
	{
		this.ContentDataList.Clear();
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		if (roleInstanceById == null)
		{
			return;
		}
		int roleSkinId = roleInstanceById.GetRoleSkinId();
		IReadOnlyList<Motion> roleMotionByRoleSkinId = ConfigBase<MotionConfig>.Instance.GetRoleMotionByRoleSkinId(roleSkinId);
		if (roleMotionByRoleSkinId == null || roleMotionByRoleSkinId.Count == 0)
		{
			return;
		}
		List<Motion> list = new List<Motion>(roleMotionByRoleSkinId);
		list.Sort(delegate(Motion a, Motion b)
		{
			if (a.Sort != b.Sort)
			{
				return a.Sort.CompareTo(b.Sort);
			}
			return a.Id.CompareTo(b.Id);
		});
		foreach (Motion config in list)
		{
			this.ContentDataList.Add(this.CreateActionContentData(config));
		}
	}

	// Token: 0x06014761 RID: 83809 RVA: 0x005AE8FC File Offset: 0x005ACAFC
	private RoleFavorActionContentData CreateActionContentData(Motion config)
	{
		return new RoleFavorActionContentData(this.RoleId, this.TypeParam, config);
	}

	// Token: 0x04009E2B RID: 40491
	public EFavorActionType TypeParam = EFavorActionType.IdleAction;
}
