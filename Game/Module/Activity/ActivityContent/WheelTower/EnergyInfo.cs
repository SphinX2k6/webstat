using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F2 RID: 25074
	[NullableContext(1)]
	[Nullable(0)]
	public class EnergyInfo
	{
		// Token: 0x17009B48 RID: 39752
		// (get) Token: 0x0603F437 RID: 259127 RVA: 0x0103CA49 File Offset: 0x0103AC49
		public Dictionary<int, int> RoleEnergyMap { get; } = new Dictionary<int, int>();

		// Token: 0x17009B49 RID: 39753
		// (get) Token: 0x0603F438 RID: 259128 RVA: 0x0103CA51 File Offset: 0x0103AC51
		public Dictionary<int, int> WeaponEnergyMap { get; } = new Dictionary<int, int>();

		// Token: 0x17009B4A RID: 39754
		// (get) Token: 0x0603F439 RID: 259129 RVA: 0x0103CA59 File Offset: 0x0103AC59
		public Dictionary<int, int> PhantomEnergyMap { get; } = new Dictionary<int, int>();

		// Token: 0x17009B4B RID: 39755
		// (get) Token: 0x0603F43A RID: 259130 RVA: 0x0103CA61 File Offset: 0x0103AC61
		public Dictionary<int, int> SkillBranchMap { get; } = new Dictionary<int, int>();

		// Token: 0x0603F43B RID: 259131 RVA: 0x0103CA6C File Offset: 0x0103AC6C
		public int GetRoleEnergy(int roleId)
		{
			int key = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
			int result;
			if (!this.RoleEnergyMap.TryGetValue(key, out result))
			{
				return -1;
			}
			return result;
		}

		// Token: 0x0603F43C RID: 259132 RVA: 0x0103CA98 File Offset: 0x0103AC98
		public bool IsRoleEnergyEnough(int roleId)
		{
			return this.GetRoleEnergy(roleId) > 0;
		}

		// Token: 0x0603F43D RID: 259133 RVA: 0x0103CAA4 File Offset: 0x0103ACA4
		public bool GetWeaponCanUse(int weaponIncId, int roleId)
		{
			int num;
			return !this.WeaponEnergyMap.TryGetValue(weaponIncId, out num) || roleId == num;
		}

		// Token: 0x0603F43E RID: 259134 RVA: 0x0103CAC8 File Offset: 0x0103ACC8
		public int GetWeaponOccupyRoleId(int weaponIncId, int roleId)
		{
			int num;
			if (!this.WeaponEnergyMap.TryGetValue(weaponIncId, out num) || roleId == num)
			{
				return -1;
			}
			return num;
		}

		// Token: 0x0603F43F RID: 259135 RVA: 0x0103CAEC File Offset: 0x0103ACEC
		public bool GetPhantomCanUse(int phantomIncId, int roleId)
		{
			int num;
			return !this.PhantomEnergyMap.TryGetValue(phantomIncId, out num) || roleId == num;
		}

		// Token: 0x0603F440 RID: 259136 RVA: 0x0103CB10 File Offset: 0x0103AD10
		public int GetPhantomOccupyRoleId(int phantomIncId, int roleId)
		{
			int num;
			if (!this.PhantomEnergyMap.TryGetValue(phantomIncId, out num) || roleId == num)
			{
				return -1;
			}
			return num;
		}
	}
}
