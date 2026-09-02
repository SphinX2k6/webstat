using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047BA RID: 18362
	[NullableContext(1)]
	[Nullable(0)]
	public class JumpToRailConfig
	{
		// Token: 0x0602FABE RID: 195262 RVA: 0x00B66A64 File Offset: 0x00B64C64
		public void UpdateFromUeData(SMotorRailMoveConfig_JumpToRail data)
		{
			this.CommonConfig.UpdateFromUeData(data.CommonConfig);
			this.SkillId = data.SkillId;
			this.EnterRailCondition.UpdateFromUeData(data.EnterCondition);
			this.ParabolaMoveConfig.UpdateFromUeData(data.ParabolaMove);
		}

		// Token: 0x0602FABF RID: 195263 RVA: 0x00B66AB0 File Offset: 0x00B64CB0
		public void DeepCopy(JumpToRailConfig other)
		{
			this.CommonConfig.DeepCopy(other.CommonConfig);
			this.SkillId = other.SkillId;
			this.EnterRailCondition.DeepCopy(other.EnterRailCondition);
			this.ParabolaMoveConfig.DeepCopy(other.ParabolaMoveConfig);
		}

		// Token: 0x0401B4AC RID: 111788
		public readonly CommonConfig CommonConfig = new CommonConfig();

		// Token: 0x0401B4AD RID: 111789
		public int SkillId = 100010012;

		// Token: 0x0401B4AE RID: 111790
		public readonly EnterRailCondition EnterRailCondition = new EnterRailCondition();

		// Token: 0x0401B4AF RID: 111791
		public readonly ParabolaMoveConfig ParabolaMoveConfig = new ParabolaMoveConfig();
	}
}
