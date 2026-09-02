using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047BC RID: 18364
	[NullableContext(1)]
	[Nullable(0)]
	public class JumpOffRailConfig
	{
		// Token: 0x0602FAC4 RID: 195268 RVA: 0x00B66BFC File Offset: 0x00B64DFC
		public void UpdateFromUeData(SMotorRailMoveConfig_JumpOffRail data)
		{
			this.CommonConfig.UpdateFromUeData(data.CommonConfig);
			this.SkillId = data.SkillId;
			this.SideOffsetAbs = data.SideOffsetAbs;
			this.ParabolaMoveConfig.UpdateFromUeData(data.ParabolaMove);
		}

		// Token: 0x0602FAC5 RID: 195269 RVA: 0x00B66C38 File Offset: 0x00B64E38
		public void DeepCopy(JumpOffRailConfig other)
		{
			this.CommonConfig.DeepCopy(other.CommonConfig);
			this.SkillId = other.SkillId;
			this.SideOffsetAbs = other.SideOffsetAbs;
			this.ParabolaMoveConfig.DeepCopy(other.ParabolaMoveConfig);
		}

		// Token: 0x0401B4B4 RID: 111796
		public readonly CommonConfig CommonConfig = new CommonConfig();

		// Token: 0x0401B4B5 RID: 111797
		public int SkillId = 100010016;

		// Token: 0x0401B4B6 RID: 111798
		public float SideOffsetAbs = 300f;

		// Token: 0x0401B4B7 RID: 111799
		public readonly ParabolaMoveConfig ParabolaMoveConfig = new ParabolaMoveConfig();
	}
}
