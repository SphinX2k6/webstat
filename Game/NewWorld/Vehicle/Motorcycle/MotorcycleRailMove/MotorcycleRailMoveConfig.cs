using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C4 RID: 18372
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleRailMoveConfig : IClear
	{
		// Token: 0x0602FADC RID: 195292 RVA: 0x00B67108 File Offset: 0x00B65308
		public void UpdateFromUeData(SMotorRailMoveConfig data)
		{
			if (data.EnableBasicConfig)
			{
				this.BasicRailMoveConfig.UpdateFromUeData(data.BasicConfig);
			}
			if (data.EnableDirectlyEnterRailConfig)
			{
				this.DirectlyEnterRailConfig.UpdateFromUeData(data.DirectlyEnterRailConfig);
			}
			if (data.EnableAccelerateAlongRailConfig)
			{
				this.AccelerateAlongRailConfig.UpdateFromUeData(data.AccelerateAlongRailConfig);
			}
			if (data.EnableJumpToRailConfig)
			{
				this.JumpToRailConfig.UpdateFromUeData(data.JumpToRailConfig);
			}
			if (data.EnableSwitchRailConfig)
			{
				this.SwitchRailConfig.UpdateFromUeData(data.SwitchRailConfig);
			}
			if (data.EnableJumpOffRailConfig)
			{
				this.JumpOffRailConfig.UpdateFromUeData(data.JumpOffRailConfig);
			}
			if (data.EnableJumpAlongRailConfig)
			{
				this.JumpAlongRailConfig.UpdateFromUeData(data.JumpAlongRailConfig);
			}
		}

		// Token: 0x0602FADD RID: 195293 RVA: 0x00B671C4 File Offset: 0x00B653C4
		public void DeepCopy(MotorcycleRailMoveConfig other)
		{
			this.BasicRailMoveConfig.DeepCopy(other.BasicRailMoveConfig);
			this.DirectlyEnterRailConfig.DeepCopy(other.DirectlyEnterRailConfig);
			this.AccelerateAlongRailConfig.DeepCopy(other.AccelerateAlongRailConfig);
			this.JumpToRailConfig.DeepCopy(other.JumpToRailConfig);
			this.SwitchRailConfig.DeepCopy(other.SwitchRailConfig);
			this.JumpOffRailConfig.DeepCopy(other.JumpOffRailConfig);
			this.JumpAlongRailConfig.DeepCopy(other.JumpAlongRailConfig);
		}

		// Token: 0x0602FADE RID: 195294 RVA: 0x00B67248 File Offset: 0x00B65448
		public bool ClearObject()
		{
			return true;
		}

		// Token: 0x0401B4CD RID: 111821
		public readonly BasicRailMoveConfig BasicRailMoveConfig = new BasicRailMoveConfig();

		// Token: 0x0401B4CE RID: 111822
		public readonly DirectlyEnterRailConfig DirectlyEnterRailConfig = new DirectlyEnterRailConfig();

		// Token: 0x0401B4CF RID: 111823
		public readonly AccelerateAlongRailConfig AccelerateAlongRailConfig = new AccelerateAlongRailConfig();

		// Token: 0x0401B4D0 RID: 111824
		public readonly JumpToRailConfig JumpToRailConfig = new JumpToRailConfig();

		// Token: 0x0401B4D1 RID: 111825
		public readonly SwitchRailConfig SwitchRailConfig = new SwitchRailConfig();

		// Token: 0x0401B4D2 RID: 111826
		public readonly JumpOffRailConfig JumpOffRailConfig = new JumpOffRailConfig();

		// Token: 0x0401B4D3 RID: 111827
		public readonly JumpAlongRailConfig JumpAlongRailConfig = new JumpAlongRailConfig();
	}
}
