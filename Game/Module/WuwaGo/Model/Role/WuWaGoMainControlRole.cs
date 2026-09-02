using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.Role
{
	// Token: 0x02004AD9 RID: 19161
	public class WuWaGoMainControlRole : WuWaGoRole
	{
		// Token: 0x06031F60 RID: 204640 RVA: 0x00C823C0 File Offset: 0x00C805C0
		[NullableContext(1)]
		public WuWaGoMainControlRole(Vector coordinate, Rotator rotator) : base(EWuWaGoRoleType.AircraftSoldiers, coordinate, rotator)
		{
		}

		// Token: 0x17008538 RID: 34104
		// (get) Token: 0x06031F61 RID: 204641 RVA: 0x00C823CB File Offset: 0x00C805CB
		public override bool Actionable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17008539 RID: 34105
		// (get) Token: 0x06031F62 RID: 204642 RVA: 0x00C823CE File Offset: 0x00C805CE
		public override bool MoveAbility
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0401D3C2 RID: 119746
		public bool IsAcceptingInput;

		// Token: 0x0401D3C3 RID: 119747
		public int DeathCount;
	}
}
