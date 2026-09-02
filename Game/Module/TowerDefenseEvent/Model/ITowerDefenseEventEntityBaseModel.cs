using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E83 RID: 20099
	[NullableContext(1)]
	public interface ITowerDefenseEventEntityBaseModel
	{
		// Token: 0x06033EF9 RID: 212729
		[return: Nullable(2)]
		public abstract static ITowerDefenseEventCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap);

		// Token: 0x06033EFA RID: 212730
		public abstract static void Clear();
	}
}
