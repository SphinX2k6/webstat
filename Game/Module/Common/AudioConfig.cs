using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E45 RID: 24133
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class AudioConfig : ConfigBase<AudioConfig>
	{
		// Token: 0x0603CBAB RID: 248747 RVA: 0x00F6C2CB File Offset: 0x00F6A4CB
		public Audio? GetAudioPath(string name)
		{
			return ConfigAudioById.GetConfig(name, true);
		}

		// Token: 0x0603CBAC RID: 248748 RVA: 0x00F6C2D4 File Offset: 0x00F6A4D4
		public MapAudio? GetMapConfig(int mapId)
		{
			return ConfigMapAudioById.GetConfig(mapId, true);
		}

		// Token: 0x0603CBAD RID: 248749 RVA: 0x00F6C2DD File Offset: 0x00F6A4DD
		public RoleSkinAudio? GetRoleConfig(int roleId)
		{
			return ConfigRoleSkinAudioById.GetConfig(roleId, true);
		}

		// Token: 0x0603CBAE RID: 248750 RVA: 0x00F6C2E8 File Offset: 0x00F6A4E8
		public RoleInfoAudio? GetRoleInfoConfig(int roleId)
		{
			if (this.RoleInfoAudioList == null)
			{
				this.RoleInfoAudioList = new List<int>();
				IReadOnlyList<RoleInfoAudio> configList = ConfigRoleInfoAudioAll.GetConfigList(true);
				if (configList != null)
				{
					foreach (RoleInfoAudio roleInfoAudio in configList)
					{
						this.RoleInfoAudioList.Add(roleInfoAudio.RoleId);
					}
				}
			}
			if (this.RoleInfoAudioList.Contains(roleId))
			{
				return ConfigRoleInfoAudioByRoleId.GetConfig(roleId, true);
			}
			return null;
		}

		// Token: 0x0402218E RID: 139662
		[Nullable(2)]
		private List<int> RoleInfoAudioList;
	}
}
