using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047A4 RID: 18340
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMotorMoveAudioEvent : IEquatable<EMotorMoveAudioEvent>
	{
		// Token: 0x0602F950 RID: 194896 RVA: 0x00B57897 File Offset: 0x00B55A97
		private EMotorMoveAudioEvent(string value)
		{
			this.Value = value;
		}

		// Token: 0x0602F952 RID: 194898 RVA: 0x00B578F8 File Offset: 0x00B55AF8
		public override string ToString()
		{
			return this.Value;
		}

		// Token: 0x0602F953 RID: 194899 RVA: 0x00B57900 File Offset: 0x00B55B00
		public bool Equals(EMotorMoveAudioEvent other)
		{
			return this.Value == other.Value;
		}

		// Token: 0x0602F954 RID: 194900 RVA: 0x00B57914 File Offset: 0x00B55B14
		public override bool Equals(object obj)
		{
			if (obj is EMotorMoveAudioEvent)
			{
				EMotorMoveAudioEvent other = (EMotorMoveAudioEvent)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602F955 RID: 194901 RVA: 0x00B57939 File Offset: 0x00B55B39
		public override int GetHashCode()
		{
			string value = this.Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0602F956 RID: 194902 RVA: 0x00B5794C File Offset: 0x00B55B4C
		public static bool operator ==(EMotorMoveAudioEvent left, EMotorMoveAudioEvent right)
		{
			return left.Equals(right);
		}

		// Token: 0x0602F957 RID: 194903 RVA: 0x00B57956 File Offset: 0x00B55B56
		public static bool operator !=(EMotorMoveAudioEvent left, EMotorMoveAudioEvent right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401B369 RID: 111465
		public readonly string Value;

		// Token: 0x0401B36A RID: 111466
		public static readonly EMotorMoveAudioEvent WheelRoll = new EMotorMoveAudioEvent("play_sfx_motor_wheel");

		// Token: 0x0401B36B RID: 111467
		public static readonly EMotorMoveAudioEvent NitroAcceleration = new EMotorMoveAudioEvent("play_sfx_motor_nos");

		// Token: 0x0401B36C RID: 111468
		public static readonly EMotorMoveAudioEvent MotorEngine = new EMotorMoveAudioEvent("play_sfx_motor_engine");

		// Token: 0x0401B36D RID: 111469
		public static readonly EMotorMoveAudioEvent DriftingState = new EMotorMoveAudioEvent("play_sfx_motor_drift");

		// Token: 0x0401B36E RID: 111470
		public static readonly EMotorMoveAudioEvent BrakingTurn = new EMotorMoveAudioEvent("play_sfx_motor_burnout");

		// Token: 0x0401B36F RID: 111471
		public const string WheelRoll_Value = "play_sfx_motor_wheel";

		// Token: 0x0401B370 RID: 111472
		public const string NitroAcceleration_Value = "play_sfx_motor_nos";

		// Token: 0x0401B371 RID: 111473
		public const string MotorEngine_Value = "play_sfx_motor_engine";

		// Token: 0x0401B372 RID: 111474
		public const string DriftingState_Value = "play_sfx_motor_drift";

		// Token: 0x0401B373 RID: 111475
		public const string BrakingTurn_Value = "play_sfx_motor_burnout";
	}
}
