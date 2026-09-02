using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047BB RID: 18363
	[NullableContext(1)]
	[Nullable(0)]
	public class SwitchRailConfig
	{
		// Token: 0x0602FAC1 RID: 195265 RVA: 0x00B66B30 File Offset: 0x00B64D30
		public void UpdateFromUeData(SMotorRailMoveConfig_SwitchRail data)
		{
			this.CommonConfig.UpdateFromUeData(data.CommonConfig);
			this.SkillId = data.SkillId;
			this.EnterRailCondition.UpdateFromUeData(data.EnterCondition);
			this.ParabolaMoveConfig.UpdateFromUeData(data.ParabolaMove);
		}

		// Token: 0x0602FAC2 RID: 195266 RVA: 0x00B66B7C File Offset: 0x00B64D7C
		public void DeepCopy(SwitchRailConfig other)
		{
			this.CommonConfig.DeepCopy(other.CommonConfig);
			this.SkillId = other.SkillId;
			this.EnterRailCondition.DeepCopy(other.EnterRailCondition);
			this.ParabolaMoveConfig.DeepCopy(other.ParabolaMoveConfig);
		}

		// Token: 0x0401B4B0 RID: 111792
		public readonly CommonConfig CommonConfig = new CommonConfig();

		// Token: 0x0401B4B1 RID: 111793
		public int SkillId = 100010015;

		// Token: 0x0401B4B2 RID: 111794
		public readonly EnterRailCondition EnterRailCondition = new EnterRailCondition();

		// Token: 0x0401B4B3 RID: 111795
		public readonly ParabolaMoveConfig ParabolaMoveConfig = new ParabolaMoveConfig();
	}
}
