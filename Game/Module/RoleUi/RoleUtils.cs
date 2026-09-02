using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Skin;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x0200505F RID: 20575
	[NullableContext(1)]
	[Nullable(0)]
	public static class RoleUtils
	{
		// Token: 0x06034FDA RID: 217050 RVA: 0x00D4A522 File Offset: 0x00D48722
		public static bool IsTrialRole(int id)
		{
			return id > 100000;
		}

		// Token: 0x06034FDB RID: 217051 RVA: 0x00D4A52C File Offset: 0x00D4872C
		public static ETrialRoleType GetTrialRoleType(int id)
		{
			TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(id);
			if (trialRoleConfig == null)
			{
				return ETrialRoleType.None;
			}
			return (ETrialRoleType)trialRoleConfig.Value.Type;
		}

		// Token: 0x06034FDC RID: 217052 RVA: 0x00D4A560 File Offset: 0x00D48760
		public static bool IsSpecialTrialRole(int id)
		{
			if (!RoleUtils.IsTrialRole(id))
			{
				return false;
			}
			ETrialRoleType trialRoleType = RoleUtils.GetTrialRoleType(id);
			return trialRoleType != ETrialRoleType.None && trialRoleType != ETrialRoleType.NormalTrial;
		}

		// Token: 0x06034FDD RID: 217053 RVA: 0x00D4A58C File Offset: 0x00D4878C
		public static int GetTrailRoleRealRoleId(int id)
		{
			return ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(id).Value.ParentId;
		}

		// Token: 0x06034FDE RID: 217054 RVA: 0x00D4A5B4 File Offset: 0x00D487B4
		public static string GetTrailRoleLabelIconById(int trialRoleId)
		{
			TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(trialRoleId);
			if (trialRoleConfig == null)
			{
				return string.Empty;
			}
			return RoleUtils.GetTrialRoleLabelIconByType((ETrialRoleType)trialRoleConfig.Value.Type);
		}

		// Token: 0x06034FDF RID: 217055 RVA: 0x00D4A5F0 File Offset: 0x00D487F0
		public static string GetTrialRoleLabelIconByType(ETrialRoleType trialRoleType)
		{
			switch (trialRoleType)
			{
			case ETrialRoleType.NormalTrial:
				return "SP_TagRoleTrial00";
			case ETrialRoleType.NewbieSupportTrial:
				return "SP_TagRoleTrial02";
			case ETrialRoleType.ReturnSupportTrial:
				return "SP_TagRoleTrial01";
			case ETrialRoleType.NewbieSupportTrialV2:
				return "SP_TagRoleTrial02";
			default:
				return "SP_TagRoleTrial00";
			}
		}

		// Token: 0x06034FE0 RID: 217056 RVA: 0x00D4A629 File Offset: 0x00D48829
		public static int GetRoleRealId(int roleId)
		{
			if (!RoleUtils.IsTrialRole(roleId))
			{
				return roleId;
			}
			return RoleUtils.GetTrailRoleRealRoleId(roleId);
		}

		// Token: 0x06034FE1 RID: 217057 RVA: 0x00D4A63C File Offset: 0x00D4883C
		public static bool HasMultiTrialRole(int roleId, int[] roleIdList, int? replaceIndex = null)
		{
			if (RoleUtils.FindRoleIdIndex(roleId, roleIdList) != -1)
			{
				return false;
			}
			int[] array = RoleUtils.BuildSimulatedList(roleId, roleIdList, replaceIndex);
			if (RoleUtils.IsSpecialTrialRole(roleId))
			{
				foreach (int num in array)
				{
					if (num != roleId && RoleUtils.IsSpecialTrialRole(num))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06034FE2 RID: 217058 RVA: 0x00D4A68C File Offset: 0x00D4888C
		public static bool HasSameRole(int roleId, int[] roleIdList, int? replaceIndex = null)
		{
			if (RoleUtils.FindRoleIdIndex(roleId, roleIdList) != -1)
			{
				return false;
			}
			foreach (int num in RoleUtils.BuildSimulatedList(roleId, roleIdList, replaceIndex))
			{
				if (roleId != num && RoleUtils.GetRoleRealId(roleId) == RoleUtils.GetRoleRealId(num))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06034FE3 RID: 217059 RVA: 0x00D4A6D5 File Offset: 0x00D488D5
		public static List<int> MergeDefaultOrnaments(List<int> serverWearList, int skinId)
		{
			return ModelBase<RoleOrnamentModel>.Instance.MergeDefaultOrnaments(serverWearList, skinId);
		}

		// Token: 0x06034FE4 RID: 217060 RVA: 0x00D4A6E4 File Offset: 0x00D488E4
		public static int GetSkinOrnamentModelId(int skinId, int ornamentId)
		{
			Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(ornamentId).Value;
			RoleSkin value2 = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(skinId).Value;
			if (!ModelBase<RoleModel>.Instance.IsMainRole(value2.RoleId))
			{
				return value.ModelId(0);
			}
			if (ConfigBase<RoleConfig>.Instance.GetMainRoleById(value2.RoleId).Value.Gender != 1)
			{
				return value.ModelId(1);
			}
			return value.ModelId(0);
		}

		// Token: 0x06034FE5 RID: 217061 RVA: 0x00D4A76C File Offset: 0x00D4896C
		private static int FindRoleIdIndex(int roleId, int[] roleIdList)
		{
			for (int i = 0; i < roleIdList.Length; i++)
			{
				if (roleIdList[i] == roleId)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06034FE6 RID: 217062 RVA: 0x00D4A790 File Offset: 0x00D48990
		private static int[] BuildSimulatedList(int roleId, int[] roleIdList, int? replaceIndex)
		{
			if (replaceIndex != null)
			{
				int? num = replaceIndex;
				int num2 = 0;
				if (!(num.GetValueOrDefault() < num2 & num != null))
				{
					num = replaceIndex;
					num2 = roleIdList.Length;
					if (!(num.GetValueOrDefault() >= num2 & num != null))
					{
						int[] array = new int[roleIdList.Length];
						roleIdList.CopyTo(array, 0);
						array[replaceIndex.Value] = roleId;
						return array;
					}
				}
			}
			return roleIdList;
		}
	}
}
