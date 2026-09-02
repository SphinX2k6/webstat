using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047BE RID: 18366
	[NullableContext(1)]
	[Nullable(0)]
	public class DirectlyEnterRailConfig
	{
		// Token: 0x0602FACA RID: 195274 RVA: 0x00B66D34 File Offset: 0x00B64F34
		public void UpdateFromUeData(SMotorRailMoveConfig_DirectlyEnterRail data)
		{
			this.CommonConfig.UpdateFromUeData(data.CommonConfig);
			this.MaxAbsorbDist = data.MaxAbsorbDist;
			this.EnterRailCondition.UpdateFromUeData(data.EnterCondition);
			this.LinearMoveConfig.UpdateFromUeData(data.LinearMove);
		}

		// Token: 0x0602FACB RID: 195275 RVA: 0x00B66D80 File Offset: 0x00B64F80
		public void DeepCopy(DirectlyEnterRailConfig other)
		{
			this.CommonConfig.DeepCopy(other.CommonConfig);
			this.MaxAbsorbDist = other.MaxAbsorbDist;
			this.EnterRailCondition.DeepCopy(other.EnterRailCondition);
			this.LinearMoveConfig.DeepCopy(other.LinearMoveConfig);
		}

		// Token: 0x0401B4BB RID: 111803
		public readonly CommonConfig CommonConfig = new CommonConfig();

		// Token: 0x0401B4BC RID: 111804
		public float MaxAbsorbDist = 100f;

		// Token: 0x0401B4BD RID: 111805
		public readonly EnterRailCondition EnterRailCondition = new EnterRailCondition();

		// Token: 0x0401B4BE RID: 111806
		public readonly LinearMoveConfig LinearMoveConfig = new LinearMoveConfig();
	}
}
