using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C0 RID: 18368
	public class ParabolaMoveConfig
	{
		// Token: 0x0602FAD0 RID: 195280 RVA: 0x00B66E66 File Offset: 0x00B65066
		public void UpdateFromUeData(SMotorRailMove_ParabolaMove data)
		{
			this.GravityAccelerationAbs = data.GravityAccelerationAbs;
			this.Duration = data.Duration;
			this.MinSpeedAlongRail = data.MinSpeedAlongRail;
			this.MaxSpeedAlongRail = data.MaxSpeedAlongRail;
		}

		// Token: 0x0602FAD1 RID: 195281 RVA: 0x00B66E98 File Offset: 0x00B65098
		[NullableContext(1)]
		public void DeepCopy(ParabolaMoveConfig other)
		{
			this.GravityAccelerationAbs = other.GravityAccelerationAbs;
			this.Duration = other.Duration;
			this.MinSpeedAlongRail = other.MinSpeedAlongRail;
			this.MaxSpeedAlongRail = other.MaxSpeedAlongRail;
		}

		// Token: 0x0401B4C1 RID: 111809
		public float GravityAccelerationAbs = 980f;

		// Token: 0x0401B4C2 RID: 111810
		public float Duration = 0.5f;

		// Token: 0x0401B4C3 RID: 111811
		public float MinSpeedAlongRail = 10f;

		// Token: 0x0401B4C4 RID: 111812
		public float MaxSpeedAlongRail = 3500f;
	}
}
