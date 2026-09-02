using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C2 RID: 18370
	public class EnterRailCondition
	{
		// Token: 0x0602FAD6 RID: 195286 RVA: 0x00B66F50 File Offset: 0x00B65150
		public void UpdateFromUeData(SMotorRailMove_EnterRailCondition data)
		{
			this.MaxAngleBetweenForwardAndRailTangent = data.MaxAngleBetweenForwardAndRailTangent;
			this.MaxAngleBetweenUpAndRailUp = data.MaxAngleBetweenUpAndRailUp;
			this.MaxAngleBetweenVelocityAndRailTangent = data.MaxAngleBetweenVelocityAndRailTangent;
			this.MinRailLenLeftAfterEnterRail = data.MinRailLenLeftAfterEnterRail;
			this.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent = data.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent;
		}

		// Token: 0x0602FAD7 RID: 195287 RVA: 0x00B66F8E File Offset: 0x00B6518E
		[NullableContext(1)]
		public void DeepCopy(EnterRailCondition other)
		{
			this.MaxAngleBetweenForwardAndRailTangent = other.MaxAngleBetweenForwardAndRailTangent;
			this.MaxAngleBetweenUpAndRailUp = other.MaxAngleBetweenUpAndRailUp;
			this.MaxAngleBetweenVelocityAndRailTangent = other.MaxAngleBetweenVelocityAndRailTangent;
			this.MinRailLenLeftAfterEnterRail = other.MinRailLenLeftAfterEnterRail;
			this.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent = other.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent;
		}

		// Token: 0x0401B4C7 RID: 111815
		public float MaxAngleBetweenForwardAndRailTangent = 90f;

		// Token: 0x0401B4C8 RID: 111816
		public float MaxAngleBetweenUpAndRailUp = 90f;

		// Token: 0x0401B4C9 RID: 111817
		public float MaxAngleBetweenVelocityAndRailTangent = 90f;

		// Token: 0x0401B4CA RID: 111818
		public float MinRailLenLeftAfterEnterRail = 100f;

		// Token: 0x0401B4CB RID: 111819
		public float MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent = 90f;
	}
}
