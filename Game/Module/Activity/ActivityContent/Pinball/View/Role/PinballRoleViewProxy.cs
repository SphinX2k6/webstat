using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065DE RID: 26078
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleViewProxy : IPinballRoleAttributeTabViewProxy, IPinballRoleWeaponTabViewProxy
	{
		// Token: 0x06041267 RID: 266855 RVA: 0x010B6B10 File Offset: 0x010B4D10
		public void SetActivityData(PinballActivityData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x06041268 RID: 266856 RVA: 0x010B6B1C File Offset: 0x010B4D1C
		[NullableContext(2)]
		public void BuildRoleDataList(List<int> formationRoleIds)
		{
			this.RoleDataList = new List<PinballRoleDataBase>();
			if (this.ActivityData == null)
			{
				return;
			}
			int id = this.ActivityData.Id;
			foreach (PinballRoleConfig pinballRoleConfig in ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigListByActivityId(id))
			{
				if (!pinballRoleConfig.IsTrail)
				{
					PinballRoleData roleData = this.ActivityData.GetRoleData(pinballRoleConfig.Id);
					if (roleData != null)
					{
						this.RoleDataList.Add(roleData);
					}
					else
					{
						PinballLockedRoleData pinballLockedRoleData = new PinballLockedRoleData(pinballRoleConfig.Id);
						pinballLockedRoleData.SetLevel(1);
						this.RoleDataList.Add(pinballLockedRoleData);
					}
				}
			}
			this.RoleDataList.Sort(delegate(PinballRoleDataBase a, PinballRoleDataBase b)
			{
				if (formationRoleIds != null && formationRoleIds.Count > 0)
				{
					int num = formationRoleIds.IndexOf(a.GetId());
					int num2 = formationRoleIds.IndexOf(b.GetId());
					bool flag = num >= 0;
					bool flag2 = num2 >= 0;
					if (flag != flag2)
					{
						if (!flag)
						{
							return 1;
						}
						return -1;
					}
					else if (flag && flag2)
					{
						return num - num2;
					}
				}
				bool flag3 = a.IsLocked();
				bool flag4 = b.IsLocked();
				if (flag3 != flag4)
				{
					if (!flag3)
					{
						return -1;
					}
					return 1;
				}
				else
				{
					int level = a.GetLevel();
					int level2 = b.GetLevel();
					if (level != level2)
					{
						return level2 - level;
					}
					return a.GetId() - b.GetId();
				}
			});
		}

		// Token: 0x06041269 RID: 266857 RVA: 0x010B6C00 File Offset: 0x010B4E00
		public void SetRoleSelectedDataByIndex(int index)
		{
			if (this.SelectedRoleIndex == index || index < 0 || index >= this.RoleDataList.Count)
			{
				return;
			}
			this.SelectedRoleIndex = index;
			this.SelectedRoleId = this.RoleDataList[index].GetId();
		}

		// Token: 0x0604126A RID: 266858 RVA: 0x010B6C3C File Offset: 0x010B4E3C
		public void SetSelectedRoleDataById(int roleId)
		{
			if (this.SelectedRoleId == roleId)
			{
				return;
			}
			this.SelectedRoleId = roleId;
			this.SelectedRoleIndex = this.RoleDataList.FindIndex((PinballRoleDataBase data) => data.GetId() == roleId);
		}

		// Token: 0x0604126B RID: 266859 RVA: 0x010B6C8E File Offset: 0x010B4E8E
		public int GetSelectedRoleId()
		{
			return this.SelectedRoleId;
		}

		// Token: 0x0604126C RID: 266860 RVA: 0x010B6C96 File Offset: 0x010B4E96
		public int GetSelectedRoleIndex()
		{
			return this.SelectedRoleIndex;
		}

		// Token: 0x0604126D RID: 266861 RVA: 0x010B6C9E File Offset: 0x010B4E9E
		public List<PinballRoleDataBase> GetRoleDataList()
		{
			return this.RoleDataList;
		}

		// Token: 0x0604126E RID: 266862 RVA: 0x010B6CA6 File Offset: 0x010B4EA6
		public PinballActivityData GetActivityData()
		{
			return this.ActivityData;
		}

		// Token: 0x0604126F RID: 266863 RVA: 0x010B6CAE File Offset: 0x010B4EAE
		public PinballRoleDataBase GetRoleData()
		{
			return this.RoleDataList[this.SelectedRoleIndex];
		}

		// Token: 0x040247C5 RID: 149445
		[Nullable(2)]
		private PinballActivityData ActivityData;

		// Token: 0x040247C6 RID: 149446
		private int SelectedRoleId;

		// Token: 0x040247C7 RID: 149447
		private int SelectedRoleIndex;

		// Token: 0x040247C8 RID: 149448
		private List<PinballRoleDataBase> RoleDataList;
	}
}
