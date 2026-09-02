using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004912 RID: 18706
	[NullableContext(1)]
	[Nullable(0)]
	public static class ManipulateSkillConfig
	{
		// Token: 0x06030E2C RID: 200236 RVA: 0x00C1D0AC File Offset: 0x00C1B2AC
		public static bool IsMechascoutRole(int roleId)
		{
			return ConfigBase<RoleConfig>.Instance.GetBaseRoleId(roleId) == 5045;
		}

		// Token: 0x06030E2D RID: 200237 RVA: 0x00C1D0C0 File Offset: 0x00C1B2C0
		public static ManipulateSkillConfigData GetSkillConfig(int roleId)
		{
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(roleId);
			return ManipulateSkillConfig.RoleSkillConfigMap.GetValueOrDefault(baseRoleId, ManipulateSkillConfig.DefaultConfig);
		}

		// Token: 0x06030E2E RID: 200238 RVA: 0x00C1D0E9 File Offset: 0x00C1B2E9
		public static ManipulateSkillConfigData GetDefaultConfig()
		{
			return ManipulateSkillConfig.DefaultConfig;
		}

		// Token: 0x0401C1A2 RID: 115106
		public const int MechascoutBaseRoleId = 5045;

		// Token: 0x0401C1A3 RID: 115107
		[StaticVariableRuleIgnore]
		private static readonly ManipulateSkillConfigData DefaultConfig = new ManipulateSkillConfigData
		{
			SkillId = 210003,
			CastSkillId = 210005,
			CancelSkillId = 210006,
			HoldingSkillId = 210007
		};

		// Token: 0x0401C1A4 RID: 115108
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, ManipulateSkillConfigData> RoleSkillConfigMap = new Dictionary<int, ManipulateSkillConfigData>
		{
			{
				5045,
				new ManipulateSkillConfigData
				{
					SkillId = 5045006,
					CastSkillId = 5045007,
					CancelSkillId = 5045016,
					HoldingSkillId = 5045017
				}
			}
		};
	}
}
