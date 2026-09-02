using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x020050AB RID: 20651
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopDefine : IStaticVariableResetter
	{
		// Token: 0x06035306 RID: 217862 RVA: 0x00D531C1 File Offset: 0x00D513C1
		static RoleDevelopDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoleDevelopDefine.CreateStaticDefaultValue), new Action(RoleDevelopDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06035307 RID: 217863 RVA: 0x00D531E0 File Offset: 0x00D513E0
		public static void CreateStaticDefaultValue()
		{
			RoleDevelopDefine.roleDevelopCategoryConfig = new List<RoleDevelopCategoryData>
			{
				new RoleDevelopCategoryData
				{
					CategoryType = ERoleDevelopCategoryType.Role,
					CategoryName = "RoleProject_Role"
				},
				new RoleDevelopCategoryData
				{
					CategoryType = ERoleDevelopCategoryType.Weapon,
					CategoryName = "RoleProject_Weapon"
				},
				new RoleDevelopCategoryData
				{
					CategoryType = ERoleDevelopCategoryType.Phantom,
					CategoryName = "RoleProject_Phantom"
				},
				new RoleDevelopCategoryData
				{
					CategoryType = ERoleDevelopCategoryType.Skill,
					CategoryName = "RoleProject_Skill"
				}
			};
			RoleDevelopDefine.roleDevelopHotRoleTagColor = new Dictionary<ERoleDevelopHotRoleTag, string>
			{
				{
					ERoleDevelopHotRoleTag.Forecast,
					"#65d5af"
				},
				{
					ERoleDevelopHotRoleTag.Rerun,
					"#87c6f1"
				},
				{
					ERoleDevelopHotRoleTag.Summon,
					"#d7ba6c"
				},
				{
					ERoleDevelopHotRoleTag.None,
					"#d7ba6c"
				}
			};
		}

		// Token: 0x06035308 RID: 217864 RVA: 0x00D532A5 File Offset: 0x00D514A5
		public static void ResetStaticDefaultValue()
		{
			RoleDevelopDefine.roleDevelopCategoryConfig = null;
			RoleDevelopDefine.roleDevelopHotRoleTagColor = null;
		}

		// Token: 0x0401E9FF RID: 125439
		public const int ROLE_DEVELOP_WORLD_DROP_PROMPT_PURPLE_QUALITY = 4;

		// Token: 0x0401EA00 RID: 125440
		public const int ROLE_DEVELOP_WORLD_DROP_PROMPT_GOLD_QUALITY = 5;

		// Token: 0x0401EA01 RID: 125441
		public const int ROLE_DEVELOP_WORLD_DROP_PROMPT_PURPLE_SOAR_LEVEL_THRESHOLD = 4;

		// Token: 0x0401EA02 RID: 125442
		public const int ROLE_DEVELOP_WORLD_DROP_PROMPT_GOLD_SOAR_LEVEL_THRESHOLD = 5;

		// Token: 0x0401EA03 RID: 125443
		public const int PROSPECT_ROLE_SKILL_TARGET_LEVEL = 10;

		// Token: 0x0401EA04 RID: 125444
		public const int PROSPECT_ROLE_SKILL_DEFAULT_LEVEL = 1;

		// Token: 0x0401EA05 RID: 125445
		public const int SKILL_PLAN_BREAKTHROUGH_LEVEL_LIMIT = 6;

		// Token: 0x0401EA06 RID: 125446
		public const string ROLE_DEVELOP_ITEM_STATE_TAG_PREFAB = "UiItem_ItemBRoleDevelopTag";

		// Token: 0x0401EA07 RID: 125447
		public const string ROLE_DEVELOP_RESULT_LINK_PREFAB = "UiItem_RoleDevelopResultLink";

		// Token: 0x0401EA08 RID: 125448
		public static List<RoleDevelopCategoryData> roleDevelopCategoryConfig;

		// Token: 0x0401EA09 RID: 125449
		public static Dictionary<ERoleDevelopHotRoleTag, string> roleDevelopHotRoleTagColor;
	}
}
