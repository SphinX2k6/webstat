using System;
using UnrealEngine;

namespace CSharpScript.Core.Define
{
	// Token: 0x0200712F RID: 28975
	public class CollisionProfile
	{
		// Token: 0x04027581 RID: 161153
		[StaticVariableRuleIgnore]
		public static readonly FName Custom = FNameUtil.GetDynamicFName("Custom").Value;

		// Token: 0x04027582 RID: 161154
		[StaticVariableRuleIgnore]
		public static readonly FName NoCollision = FNameUtil.GetDynamicFName("NoCollision").Value;
	}
}
