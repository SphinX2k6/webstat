using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B3C RID: 23356
	[NullableContext(2)]
	public interface IRoleDevelopExpStateProvider
	{
		// Token: 0x1700972C RID: 38700
		// (get) Token: 0x0603B141 RID: 241985
		// (set) Token: 0x0603B142 RID: 241986
		Func<int, EItemRequirementState?> GetExpItemRequirementState { get; set; }
	}
}
