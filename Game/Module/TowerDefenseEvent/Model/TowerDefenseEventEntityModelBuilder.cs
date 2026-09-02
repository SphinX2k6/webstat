using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E94 RID: 20116
	public class TowerDefenseEventEntityModelBuilder
	{
		// Token: 0x06033FBC RID: 212924 RVA: 0x00D00DD9 File Offset: 0x00CFEFD9
		[NullableContext(1)]
		[return: Nullable(2)]
		public static ITowerDefenseEventCombatInfo Get(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			ITowerDefenseEventCombatInfo result;
			if ((result = TowerDefenseEventSpecialCellModel.BuildModel(entityData, componentDataMap)) == null && (result = TowerDefenseEventTrapModel.BuildModel(entityData, componentDataMap)) == null)
			{
				result = (TowerDefenseEventMonsterModel.BuildModel(entityData, componentDataMap) ?? TowerDefenseEventEntityModel.BuildModel(entityData, componentDataMap));
			}
			return result;
		}

		// Token: 0x06033FBD RID: 212925 RVA: 0x00D00E03 File Offset: 0x00CFF003
		public static void Clear()
		{
			TowerDefenseEventSpecialCellModel.Clear();
			TowerDefenseEventTrapModel.Clear();
			TowerDefenseEventMonsterModel.Clear();
			TowerDefenseEventEntityModel.Clear();
		}
	}
}
