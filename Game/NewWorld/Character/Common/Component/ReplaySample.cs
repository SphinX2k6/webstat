using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x020048F8 RID: 18680
	[NullableContext(1)]
	[Nullable(0)]
	public class ReplaySample
	{
		// Token: 0x06030C61 RID: 199777 RVA: 0x00C0CA60 File Offset: 0x00C0AC60
		public ReplaySample(MoveReplaySample moveInfo, int controllerPlayerId, double time)
		{
			Aki.Protocol.Vector location = moveInfo.Location;
			Aki.Protocol.Rotator rotation = moveInfo.Rotation;
			Aki.Protocol.Vector linearVelocity = moveInfo.LinearVelocity;
			Aki.Protocol.Vector slideForward = moveInfo.SlideForward;
			this.Location.Set((double)location.X, (double)location.Y, (double)location.Z);
			this.Rotation.Set(rotation.Pitch, rotation.Yaw, rotation.Roll);
			if (linearVelocity != null)
			{
				this.LinearVelocity.Set((double)linearVelocity.X, (double)linearVelocity.Y, (double)linearVelocity.Z);
			}
			if (slideForward != null)
			{
				this.SlideForward.Set((double)slideForward.X, (double)slideForward.Y, (double)slideForward.Z);
			}
			this.ControllerPitch = moveInfo.ControllerPitch;
			this.MovementMode = moveInfo.MovementMode;
			this.Input = moveInfo.InputDirection;
			this.TimeScale = moveInfo.TimeScale;
			this.TimeStamp = time;
			this.ControllerPlayerId = controllerPlayerId;
			this.ServerTimeStamp = moveInfo.ServerTimeStamp;
			this.Rtt = moveInfo.RTT;
			RelativeMoveReplaySample relativeMoveReplaySample = moveInfo.RelativeMoveReplaySample;
			if (relativeMoveReplaySample != null)
			{
				this.RelativeMove = new RelativeMove
				{
					BaseMovementEntityId = relativeMoveReplaySample.BaseMovementEntityId
				};
				Aki.Protocol.Rotator relativeRotation = relativeMoveReplaySample.RelativeRotation;
				Aki.Protocol.Vector relativeLocation = relativeMoveReplaySample.RelativeLocation;
				this.RelativeMove.RelativeRotation = global::Rotator.Create(relativeRotation.Pitch, relativeRotation.Yaw, relativeRotation.Roll);
				this.RelativeMove.RelativeLocation = global::Vector.Create((double)relativeLocation.X, (double)relativeLocation.Y, (double)relativeLocation.Z);
			}
		}

		// Token: 0x0401C066 RID: 114790
		public global::Vector Location = global::Vector.Create();

		// Token: 0x0401C067 RID: 114791
		public global::Rotator Rotation = global::Rotator.Create();

		// Token: 0x0401C068 RID: 114792
		public global::Vector LinearVelocity = global::Vector.Create();

		// Token: 0x0401C069 RID: 114793
		public global::Vector SlideForward = global::Vector.Create();

		// Token: 0x0401C06A RID: 114794
		public float ControllerPitch;

		// Token: 0x0401C06B RID: 114795
		public int MovementMode;

		// Token: 0x0401C06C RID: 114796
		public int Input;

		// Token: 0x0401C06D RID: 114797
		public double TimeStamp;

		// Token: 0x0401C06E RID: 114798
		[Nullable(2)]
		public RelativeMove RelativeMove;

		// Token: 0x0401C06F RID: 114799
		public int ControllerPlayerId;

		// Token: 0x0401C070 RID: 114800
		public float TimeScale;

		// Token: 0x0401C071 RID: 114801
		public long ServerTimeStamp;

		// Token: 0x0401C072 RID: 114802
		public int Rtt;
	}
}
