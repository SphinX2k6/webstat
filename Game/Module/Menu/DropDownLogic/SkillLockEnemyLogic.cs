using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Menu.DropDownLogic
{
	// Token: 0x020057D4 RID: 22484
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillLockEnemyLogic : DropDownLogicBase
	{
		// Token: 0x06039253 RID: 234067 RVA: 0x00E7D4F4 File Offset: 0x00E7B6F4
		public override IReadOnlyList<object> GetDropDownDataList()
		{
			List<SkillLockEnemyDropDownData> list = new List<SkillLockEnemyDropDownData>();
			MenuConfig? menuConfigByFunctionId = ConfigBase<MenuBaseConfig>.Instance.GetMenuConfigByFunctionId(133);
			if (menuConfigByFunctionId == null)
			{
				return list;
			}
			string[] array = menuConfigByFunctionId.Value.OptionsName();
			for (int i = 0; i < array.Length; i++)
			{
				string textId = array[i];
				SkillLockEnemyDropDownData item = new SkillLockEnemyDropDownData(i, textId);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06039254 RID: 234068 RVA: 0x00E7D55E File Offset: 0x00E7B75E
		public override TableTextArgNew GetDataTextId(object data, MenuData menuData)
		{
			return new TableTextArgNew(((SkillLockEnemyDropDownData)data).TextId, Array.Empty<object>());
		}

		// Token: 0x06039255 RID: 234069 RVA: 0x00E7D578 File Offset: 0x00E7B778
		public override void TriggerSelectChange(object data, MenuData menuData)
		{
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(menuData.FunctionId);
			int index = ((SkillLockEnemyDropDownData)data).Index;
			if (targetConfig == index)
			{
				return;
			}
			Singleton<GameSettingsManager>.Instance.HandleValueChange(menuData.FunctionId, index, EGameSettingsApplyReason.WhenUi);
			ModelBase<MenuModel>.Instance.IsEdited = true;
		}

		// Token: 0x06039256 RID: 234070 RVA: 0x00E7D5C2 File Offset: 0x00E7B7C2
		public override int GetDefaultIndex(MenuData menuData)
		{
			return ControllerBase<MenuController>.Instance.GetTargetConfig(menuData.FunctionId);
		}
	}
}
