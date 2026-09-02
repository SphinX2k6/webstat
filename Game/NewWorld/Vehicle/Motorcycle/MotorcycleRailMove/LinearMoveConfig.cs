using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C1 RID: 18369
	public class LinearMoveConfig
	{
		// Token: 0x0602FAD3 RID: 195283 RVA: 0x00B66EFE File Offset: 0x00B650FE
		public void UpdateFromUeData(SMotorRailMove_LinearMove data)
		{
			this.MinSpeed = data.MinSpeed;
			this.MaxSpeed = data.MaxSpeed;
		}

		// Token: 0x0602FAD4 RID: 195284 RVA: 0x00B66F18 File Offset: 0x00B65118
		[NullableContext(1)]
		public void DeepCopy(LinearMoveConfig other)
		{
			this.MinSpeed = other.MinSpeed;
			this.MaxSpeed = other.MaxSpeed;
		}

		// Token: 0x0401B4C5 RID: 111813
		public float MinSpeed = 10f;

		// Token: 0x0401B4C6 RID: 111814
		public float MaxSpeed = 3500f;
	}
}
