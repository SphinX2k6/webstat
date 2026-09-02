using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005053 RID: 20563
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleDevDefine : IStaticVariableResetter
	{
		// Token: 0x06034F15 RID: 216853 RVA: 0x00D46BAB File Offset: 0x00D44DAB
		static RoleDevDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoleDevDefine.CreateStaticDefaultValue), new Action(RoleDevDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06034F16 RID: 216854 RVA: 0x00D46BCA File Offset: 0x00D44DCA
		public static void ResetStaticDefaultValue()
		{
			RoleDevDefine.tabTypeToMainPageMap = null;
			RoleDevDefine.roleTabMaterialTypeToSubPageButtonMap = null;
			RoleDevDefine.weaponTabMaterialTypeToSubPageButtonMap = null;
			RoleDevDefine.skillTabMaterialTypeToSubPageButtonMap = null;
		}

		// Token: 0x06034F17 RID: 216855 RVA: 0x00D46BE4 File Offset: 0x00D44DE4
		public static void CreateStaticDefaultValue()
		{
			RoleDevDefine.tabTypeToMainPageMap = new Dictionary<ERoleDevTabType, ERoleDevMainPage>
			{
				{
					ERoleDevTabType.Role,
					ERoleDevMainPage.Role
				},
				{
					ERoleDevTabType.Weapon,
					ERoleDevMainPage.Weapon
				},
				{
					ERoleDevTabType.Phantom,
					ERoleDevMainPage.Phantom
				},
				{
					ERoleDevTabType.Skill,
					ERoleDevMainPage.Skill
				}
			};
			RoleDevDefine.roleTabMaterialTypeToSubPageButtonMap = new Dictionary<EItemMaterialType, ERoleDevSubPageButton>
			{
				{
					EItemMaterialType.RoleExp,
					ERoleDevSubPageButton.RoleExpMaterialGo
				},
				{
					EItemMaterialType.RoleBreak,
					ERoleDevSubPageButton.RoleBreakthroughMaterialGo
				},
				{
					EItemMaterialType.Map,
					ERoleDevSubPageButton.RoleMapMaterialGo
				},
				{
					EItemMaterialType.Drop,
					ERoleDevSubPageButton.RoleDropMaterialGo
				}
			};
			RoleDevDefine.weaponTabMaterialTypeToSubPageButtonMap = new Dictionary<EItemMaterialType, ERoleDevSubPageButton>
			{
				{
					EItemMaterialType.WeaponExp,
					ERoleDevSubPageButton.WeaponExpMaterialGo
				},
				{
					EItemMaterialType.WeaponSkill,
					ERoleDevSubPageButton.WeaponSkillMaterialGo
				},
				{
					EItemMaterialType.Drop,
					ERoleDevSubPageButton.WeaponDropMaterialGo
				}
			};
			RoleDevDefine.skillTabMaterialTypeToSubPageButtonMap = new Dictionary<EItemMaterialType, ERoleDevSubPageButton>
			{
				{
					EItemMaterialType.WeaponSkill,
					ERoleDevSubPageButton.SkillWeaponMaterialGo
				},
				{
					EItemMaterialType.Weekly,
					ERoleDevSubPageButton.SkillWeeklyMaterialGo
				},
				{
					EItemMaterialType.Drop,
					ERoleDevSubPageButton.SkillDropMaterialGo
				}
			};
		}

		// Token: 0x0401E839 RID: 124985
		public static Dictionary<ERoleDevTabType, ERoleDevMainPage> tabTypeToMainPageMap;

		// Token: 0x0401E83A RID: 124986
		public static Dictionary<EItemMaterialType, ERoleDevSubPageButton> roleTabMaterialTypeToSubPageButtonMap;

		// Token: 0x0401E83B RID: 124987
		public static Dictionary<EItemMaterialType, ERoleDevSubPageButton> weaponTabMaterialTypeToSubPageButtonMap;

		// Token: 0x0401E83C RID: 124988
		public static Dictionary<EItemMaterialType, ERoleDevSubPageButton> skillTabMaterialTypeToSubPageButtonMap;
	}
}
