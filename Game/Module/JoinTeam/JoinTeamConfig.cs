using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.JoinTeam
{
	// Token: 0x02005AFD RID: 23293
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class JoinTeamConfig : ConfigBase<JoinTeamConfig>
	{
		// Token: 0x0603AE6B RID: 241259 RVA: 0x00EEFED9 File Offset: 0x00EEE0D9
		public RoleDescription? GetRoleDescriptionConfig(int roleDescriptionId)
		{
			return ConfigRoleDescriptionById.GetConfig(roleDescriptionId, true);
		}

		// Token: 0x0603AE6C RID: 241260 RVA: 0x00EEFEE2 File Offset: 0x00EEE0E2
		public RoleInfo? GetRoleConfig(int roleConfigId)
		{
			return ConfigRoleInfoById.GetConfig(roleConfigId, true);
		}

		// Token: 0x0603AE6D RID: 241261 RVA: 0x00EEFEEC File Offset: 0x00EEE0EC
		public string GetRoleNameId(int roleDescriptionId)
		{
			RoleDescription? roleDescriptionConfig = this.GetRoleDescriptionConfig(roleDescriptionId);
			if (roleDescriptionConfig == null)
			{
				return null;
			}
			int roleId = roleDescriptionConfig.Value.RoleId;
			RoleInfo? roleConfig = this.GetRoleConfig(roleId);
			if (roleConfig == null)
			{
				return null;
			}
			return roleConfig.GetValueOrDefault().Name;
		}

		// Token: 0x0603AE6E RID: 241262 RVA: 0x00EEFF40 File Offset: 0x00EEE140
		public string GetRoleTexturePath(int roleDescriptionId)
		{
			RoleDescription? roleDescriptionConfig = this.GetRoleDescriptionConfig(roleDescriptionId);
			if (roleDescriptionConfig == null)
			{
				return null;
			}
			return roleDescriptionConfig.Value.Texture;
		}

		// Token: 0x0603AE6F RID: 241263 RVA: 0x00EEFF70 File Offset: 0x00EEE170
		public string GetRoleDescriptionId(int roleDescriptionId)
		{
			RoleDescription? roleDescriptionConfig = this.GetRoleDescriptionConfig(roleDescriptionId);
			if (roleDescriptionConfig == null)
			{
				return null;
			}
			return roleDescriptionConfig.Value.Description;
		}

		// Token: 0x0603AE70 RID: 241264 RVA: 0x00EEFFA0 File Offset: 0x00EEE1A0
		public int? GetRoleElementId(int roleDescriptionId)
		{
			RoleDescription? roleDescriptionConfig = this.GetRoleDescriptionConfig(roleDescriptionId);
			if (roleDescriptionConfig == null)
			{
				return null;
			}
			int roleId = roleDescriptionConfig.Value.RoleId;
			RoleInfo? roleConfig = this.GetRoleConfig(roleId);
			if (roleConfig == null)
			{
				return null;
			}
			return new int?(roleConfig.GetValueOrDefault().ElementId);
		}

		// Token: 0x0603AE71 RID: 241265 RVA: 0x00EF000C File Offset: 0x00EEE20C
		public int? GetRoleConfigId(int roleDescriptionId)
		{
			RoleDescription? roleDescriptionConfig = this.GetRoleDescriptionConfig(roleDescriptionId);
			if (roleDescriptionConfig == null)
			{
				return null;
			}
			return new int?(roleDescriptionConfig.Value.RoleId);
		}
	}
}
