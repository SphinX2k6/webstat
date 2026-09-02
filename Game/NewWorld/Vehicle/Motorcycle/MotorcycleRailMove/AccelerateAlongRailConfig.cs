using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047BF RID: 18367
	[NullableContext(1)]
	[Nullable(0)]
	public class AccelerateAlongRailConfig
	{
		// Token: 0x0602FACD RID: 195277 RVA: 0x00B66E00 File Offset: 0x00B65000
		public void UpdateFromUeData(SMotorRailMoveConfig_AccelerateAlongRail data)
		{
			this.CommonConfig.UpdateFromUeData(data.CommonConfig);
			this.LinearMoveConfig.UpdateFromUeData(data.LinearMove);
		}

		// Token: 0x0602FACE RID: 195278 RVA: 0x00B66E24 File Offset: 0x00B65024
		public void DeepCopy(AccelerateAlongRailConfig other)
		{
			this.CommonConfig.DeepCopy(other.CommonConfig);
			this.LinearMoveConfig.DeepCopy(other.LinearMoveConfig);
		}

		// Token: 0x0401B4BF RID: 111807
		public readonly CommonConfig CommonConfig = new CommonConfig();

		// Token: 0x0401B4C0 RID: 111808
		public readonly LinearMoveConfig LinearMoveConfig = new LinearMoveConfig();
	}
}
