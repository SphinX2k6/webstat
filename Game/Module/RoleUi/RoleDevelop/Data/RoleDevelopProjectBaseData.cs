using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.View;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050D6 RID: 20694
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoleDevelopProjectBaseData
	{
		// Token: 0x0603552A RID: 218410 RVA: 0x00D60CE4 File Offset: 0x00D5EEE4
		public RoleDevelopProjectBaseData(int id, RoleDevelopRoleBaseData developRoleData)
		{
			this.Id = id;
			this.DevelopRoleData = developRoleData;
		}

		// Token: 0x0603552B RID: 218411 RVA: 0x00D60CFA File Offset: 0x00D5EEFA
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x0603552C RID: 218412 RVA: 0x00D60D02 File Offset: 0x00D5EF02
		protected List<ISelectedData> GetSortedRoleExpItemList()
		{
			List<ISelectedData> list = new List<ISelectedData>(ModelBase<RoleModel>.Instance.GetExpItemInInventory());
			list.Sort(delegate(ISelectedData a, ISelectedData b)
			{
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemId);
				ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemId);
				return ((itemConfigData != null) ? itemConfigData.QualityId : 0) - ((itemConfigData2 != null) ? itemConfigData2.QualityId : 0);
			});
			return list;
		}

		// Token: 0x0603552D RID: 218413 RVA: 0x00D60D38 File Offset: 0x00D5EF38
		protected List<ISelectedData> GetSortedWeaponExpItemList()
		{
			List<ISelectedData> expItemInInventory = ModelBase<WeaponModel>.Instance.GetExpItemInInventory();
			expItemInInventory.Sort(delegate(ISelectedData a, ISelectedData b)
			{
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemId);
				ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemId);
				return ((itemConfigData != null) ? itemConfigData.QualityId : 0) - ((itemConfigData2 != null) ? itemConfigData2.QualityId : 0);
			});
			return expItemInInventory;
		}

		// Token: 0x0603552E RID: 218414 RVA: 0x00D60D69 File Offset: 0x00D5EF69
		protected bool IsShouldSkipItem(int itemId)
		{
			return itemId == 2;
		}

		// Token: 0x0603552F RID: 218415 RVA: 0x00D60D6F File Offset: 0x00D5EF6F
		protected void HandleItemJumpCallback(RoleDevelopItemGroup groupItem)
		{
			RoleDevelopUtil.HandleItemJump(this.Id, groupItem);
		}

		// Token: 0x06035530 RID: 218416
		public abstract ERoleDevelopRoleType GetRoleType();

		// Token: 0x06035531 RID: 218417
		public abstract int GetRoleTargetLevel();

		// Token: 0x06035532 RID: 218418
		public abstract int GetRoleUpgradeExp();

		// Token: 0x06035533 RID: 218419
		public abstract List<RoleDevelopNeedItem> GetRoleUpgradeNeedItems();

		// Token: 0x06035534 RID: 218420
		public abstract List<RoleDevelopNeedItem> GetRoleBreachNeedItems();

		// Token: 0x06035535 RID: 218421
		public abstract List<RoleDevelopNeedItem> GetRoleDevelopNeedItems();

		// Token: 0x06035536 RID: 218422
		public abstract List<RoleDevelopProjectMaterialItemData> GetRoleDevelopProjectViewItems();

		// Token: 0x06035537 RID: 218423
		public abstract int GetWeaponType();

		// Token: 0x06035538 RID: 218424
		public abstract int GetWeaponTargetLevel();

		// Token: 0x06035539 RID: 218425
		public abstract int GetWeaponUpgradeExp();

		// Token: 0x0603553A RID: 218426
		public abstract List<RoleDevelopNeedItem> GetWeaponUpgradeNeedItems();

		// Token: 0x0603553B RID: 218427
		public abstract List<RoleDevelopNeedItem> GetWeaponBreachNeedItems();

		// Token: 0x0603553C RID: 218428
		public abstract List<RoleDevelopProjectMaterialItemData> GetWeaponDevelopProjectViewItems();

		// Token: 0x0603553D RID: 218429
		public abstract List<RoleDevelopSkillData> GetSkillDevelopData();

		// Token: 0x0603553E RID: 218430
		public abstract bool IsSkillPlanFinished();

		// Token: 0x0603553F RID: 218431
		public abstract List<RoleDevelopNeedItem> GetSkillPlanNeedItems();

		// Token: 0x06035540 RID: 218432
		public abstract List<RoleDevelopProjectMaterialItemData> GetSkillDevelopProjectViewItems();

		// Token: 0x06035541 RID: 218433
		public abstract bool IsShowUpgradeHint(ERoleDevelopCategoryType categoryType);

		// Token: 0x06035542 RID: 218434
		public abstract bool IsShowFinishHint(ERoleDevelopCategoryType categoryType);

		// Token: 0x06035543 RID: 218435
		public abstract bool IsRoleDevelopFinished();

		// Token: 0x06035544 RID: 218436
		public abstract bool IsWeaponDevelopFinished();

		// Token: 0x06035545 RID: 218437
		public abstract bool IsRoleReachTargetLevel();

		// Token: 0x06035546 RID: 218438
		public abstract bool IsRoleReachBreachLevel();

		// Token: 0x06035547 RID: 218439
		public abstract bool IsWeaponReachTargetLevel();

		// Token: 0x06035548 RID: 218440
		public abstract bool IsWeaponReachBreachLevel();

		// Token: 0x0401EAA2 RID: 125602
		protected int Id;

		// Token: 0x0401EAA3 RID: 125603
		protected RoleDevelopRoleBaseData DevelopRoleData;
	}
}
