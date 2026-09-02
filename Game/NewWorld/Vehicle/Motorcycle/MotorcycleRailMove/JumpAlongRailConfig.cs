using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047BD RID: 18365
	[NullableContext(1)]
	[Nullable(0)]
	public class JumpAlongRailConfig
	{
		// Token: 0x0602FAC7 RID: 195271 RVA: 0x00B66CA8 File Offset: 0x00B64EA8
		public void UpdateFromUeData(SMotorRailMoveConfig_JumpAlongRail data)
		{
			this.CommonConfig.UpdateFromUeData(data.CommonConfig);
			this.SkillId = data.SkillId;
			this.ParabolaMoveConfig.UpdateFromUeData(data.ParabolaMove);
		}

		// Token: 0x0602FAC8 RID: 195272 RVA: 0x00B66CD8 File Offset: 0x00B64ED8
		public void DeepCopy(JumpAlongRailConfig other)
		{
			this.CommonConfig.DeepCopy(other.CommonConfig);
			this.SkillId = other.SkillId;
			this.ParabolaMoveConfig.DeepCopy(other.ParabolaMoveConfig);
		}

		// Token: 0x0401B4B8 RID: 111800
		public readonly CommonConfig CommonConfig = new CommonConfig();

		// Token: 0x0401B4B9 RID: 111801
		public int SkillId = 100010016;

		// Token: 0x0401B4BA RID: 111802
		public readonly ParabolaMoveConfig ParabolaMoveConfig = new ParabolaMoveConfig();
	}
}
