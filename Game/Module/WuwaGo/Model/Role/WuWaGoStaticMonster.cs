using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.Role
{
	// Token: 0x02004ADF RID: 19167
	public class WuWaGoStaticMonster : WuWaGoRole
	{
		// Token: 0x06031F9E RID: 204702 RVA: 0x00C82CB4 File Offset: 0x00C80EB4
		[NullableContext(1)]
		public WuWaGoStaticMonster(Vector coordinate, Rotator rotator) : base(EWuWaGoRoleType.HeatFusionEnemy, coordinate, rotator)
		{
		}

		// Token: 0x17008548 RID: 34120
		// (get) Token: 0x06031F9F RID: 204703 RVA: 0x00C82CBF File Offset: 0x00C80EBF
		public override bool Actionable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17008549 RID: 34121
		// (get) Token: 0x06031FA0 RID: 204704 RVA: 0x00C82CC2 File Offset: 0x00C80EC2
		public override bool MoveAbility
		{
			get
			{
				return false;
			}
		}
	}
}
