using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005060 RID: 20576
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class TrialRoleConfig : ConfigBase<TrialRoleConfig>
	{
		// Token: 0x06034FE7 RID: 217063 RVA: 0x00D4A7FC File Offset: 0x00D489FC
		public TrialRoleInfo? GetTrialRoleConfig(int id)
		{
			TrialRoleInfo? config = ConfigTrialRoleInfoById.GetConfig(id, true);
			if (config != null)
			{
				return new TrialRoleInfo?(config.Value);
			}
			return null;
		}

		// Token: 0x06034FE8 RID: 217064 RVA: 0x00D4A830 File Offset: 0x00D48A30
		[NullableContext(2)]
		public IReadOnlyList<TrialRoleInfo> GetTrialRoleConfigsByGroupId(int id)
		{
			return ConfigTrialRoleInfoByGroupId.GetConfigList(id, true);
		}

		// Token: 0x06034FE9 RID: 217065 RVA: 0x00D4A839 File Offset: 0x00D48A39
		public IReadOnlyList<TrialRoleInfo> GetTrialRoleConfigListByType(ETrialRoleType trialRoleType)
		{
			return ConfigTrialRoleInfoByType.GetConfigList((int)trialRoleType, true) ?? new List<TrialRoleInfo>();
		}

		// Token: 0x06034FEA RID: 217066 RVA: 0x00D4A84C File Offset: 0x00D48A4C
		public Dictionary<int, List<TrialRoleInfo>> GetTrialRoleAllConfigByType(ETrialRoleType trialRoleType)
		{
			Dictionary<int, List<TrialRoleInfo>> dictionary = new Dictionary<int, List<TrialRoleInfo>>();
			foreach (TrialRoleInfo item in this.GetTrialRoleConfigListByType(trialRoleType))
			{
				int groupId = item.GroupId;
				if (!dictionary.ContainsKey(groupId))
				{
					dictionary[groupId] = new List<TrialRoleInfo>();
				}
				dictionary[groupId].Add(item);
			}
			foreach (KeyValuePair<int, List<TrialRoleInfo>> keyValuePair in dictionary)
			{
				keyValuePair.Value.Sort((TrialRoleInfo a, TrialRoleInfo b) => a.WorldLevel - b.WorldLevel);
			}
			return dictionary;
		}

		// Token: 0x06034FEB RID: 217067 RVA: 0x00D4A928 File Offset: 0x00D48B28
		public RoleInfo? GetRoleConfigByTrialRoleId(int id)
		{
			TrialRoleInfo? trialRoleConfig = this.GetTrialRoleConfig(id);
			if (trialRoleConfig == null)
			{
				return null;
			}
			RoleInfo? config = ConfigRoleInfoById.GetConfig(trialRoleConfig.Value.ParentId, true);
			if (config != null)
			{
				return new RoleInfo?(config.Value);
			}
			return null;
		}

		// Token: 0x06034FEC RID: 217068 RVA: 0x00D4A988 File Offset: 0x00D48B88
		public RoleInfo? GetRoleConfigByGroupId(int id)
		{
			IReadOnlyList<TrialRoleInfo> trialRoleConfigsByGroupId = this.GetTrialRoleConfigsByGroupId(id);
			if (trialRoleConfigsByGroupId == null || trialRoleConfigsByGroupId.Count == 0)
			{
				return null;
			}
			RoleConfig instance = ConfigBase<RoleConfig>.Instance;
			RoleInfo? roleInfo = (instance != null) ? instance.GetRoleConfig(trialRoleConfigsByGroupId[0].ParentId) : null;
			if (roleInfo != null)
			{
				return new RoleInfo?(roleInfo.Value);
			}
			return null;
		}

		// Token: 0x06034FED RID: 217069 RVA: 0x00D4A9FC File Offset: 0x00D48BFC
		public int? GetTrialRoleGroupId(int id)
		{
			TrialRoleInfo? trialRoleConfig = this.GetTrialRoleConfig(id);
			if (trialRoleConfig == null)
			{
				return null;
			}
			return new int?(trialRoleConfig.GetValueOrDefault().GroupId);
		}
	}
}
