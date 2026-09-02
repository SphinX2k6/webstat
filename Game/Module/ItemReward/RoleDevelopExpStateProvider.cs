using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B3D RID: 23357
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleDevelopExpStateProvider : IRoleDevelopExpStateProvider
	{
		// Token: 0x1700972D RID: 38701
		// (get) Token: 0x0603B143 RID: 241987 RVA: 0x00EF351A File Offset: 0x00EF171A
		// (set) Token: 0x0603B144 RID: 241988 RVA: 0x00EF3522 File Offset: 0x00EF1722
		public Func<int, EItemRequirementState?> GetExpItemRequirementState { get; set; }
	}
}
