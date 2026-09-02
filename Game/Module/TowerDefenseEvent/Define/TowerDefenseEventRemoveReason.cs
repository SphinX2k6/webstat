using System;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Define
{
	// Token: 0x02004E96 RID: 20118
	public class TowerDefenseEventRemoveReason
	{
		// Token: 0x0401E0C4 RID: 123076
		public static readonly FName Preview = FNameUtil.GetCheckDynamicFName("Preview");

		// Token: 0x0401E0C5 RID: 123077
		public static readonly FName CombatDirty = FNameUtil.GetCheckDynamicFName("CombatDirty");

		// Token: 0x0401E0C6 RID: 123078
		public static readonly FName Destroy = FNameUtil.GetCheckDynamicFName("Destroy");
	}
}
