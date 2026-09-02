using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SundialControl
{
	// Token: 0x02006AB5 RID: 27317
	[NullableContext(1)]
	[Nullable(0)]
	public class RotatingRing
	{
		// Token: 0x060438B1 RID: 276657 RVA: 0x0116A0A4 File Offset: 0x011682A4
		public RotatingRing(AActor ringActor, float simpleRotateAngle, float rotateSpeed)
		{
			this.RingActor = ringActor;
			this.SimpleRotateAngle = (double)simpleRotateAngle;
			this.TotalSocket = (int)(360f / simpleRotateAngle);
			this.CurSocket = 0;
			this.IsShine = false;
			this.RotateSpeed = rotateSpeed;
			FRotator relativeRotation = this.RingActor.RootComponent.RelativeRotation;
			this.InitYaw = relativeRotation.Yaw;
		}

		// Token: 0x04025BBD RID: 154557
		public AActor RingActor;

		// Token: 0x04025BBE RID: 154558
		public double SimpleRotateAngle;

		// Token: 0x04025BBF RID: 154559
		public int TotalSocket;

		// Token: 0x04025BC0 RID: 154560
		public int CurSocket;

		// Token: 0x04025BC1 RID: 154561
		public bool IsShine;

		// Token: 0x04025BC2 RID: 154562
		public float InitYaw;

		// Token: 0x04025BC3 RID: 154563
		public float RotateSpeed;
	}
}
