using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA3 RID: 23971
	[NullableContext(2)]
	[Nullable(0)]
	public class DreamLinkWeaponModelHandle
	{
		// Token: 0x0603C5A6 RID: 247206 RVA: 0x00F50897 File Offset: 0x00F4EA97
		[NullableContext(1)]
		public DreamLinkWeaponModelHandle(AActor Actor)
		{
			this.Actor = Actor;
			this.Rotator = Rotator.Create();
		}

		// Token: 0x0603C5A7 RID: 247207 RVA: 0x00F508B1 File Offset: 0x00F4EAB1
		public void SetRotateParam(float aroundTime, ERotateAxis axis = ERotateAxis.Yaw, bool isPlus = true)
		{
			this.DeltaSecondRotate = ((aroundTime != 0f) ? (360f / aroundTime) : 0f);
			this.RotateAxis = new ERotateAxis?(axis);
			this.IsRotatePlus = isPlus;
		}

		// Token: 0x0603C5A8 RID: 247208 RVA: 0x00F508E2 File Offset: 0x00F4EAE2
		public void StartRotate()
		{
			this.IsRotating = true;
		}

		// Token: 0x0603C5A9 RID: 247209 RVA: 0x00F508EB File Offset: 0x00F4EAEB
		public void StopRotate()
		{
			this.IsRotating = false;
		}

		// Token: 0x0603C5AA RID: 247210 RVA: 0x00F508F4 File Offset: 0x00F4EAF4
		public void Tick(float deltaTime)
		{
			this.OnRotate(deltaTime);
		}

		// Token: 0x0603C5AB RID: 247211 RVA: 0x00F50900 File Offset: 0x00F4EB00
		protected void OnRotate(float deltaTime)
		{
			if (!this.IsRotating || this.DeltaSecondRotate <= 0f)
			{
				return;
			}
			if (this.Actor == null)
			{
				return;
			}
			int num = this.IsRotatePlus ? 1 : -1;
			float num2 = this.DeltaSecondRotate * deltaTime * (float)num;
			ERotateAxis? rotateAxis = this.RotateAxis;
			ERotateAxis erotateAxis = ERotateAxis.Pitch;
			if (rotateAxis.GetValueOrDefault() == erotateAxis & rotateAxis != null)
			{
				this.Rotator.Pitch = num2;
			}
			else if (this.RotateAxis.GetValueOrDefault() == ERotateAxis.Yaw)
			{
				this.Rotator.Yaw = num2;
			}
			else if (this.RotateAxis.GetValueOrDefault() == ERotateAxis.Roll)
			{
				this.Rotator.Roll = num2;
			}
			FHitResult fhitResult = new FHitResult();
			this.Actor.K2_AddActorLocalRotation(this.Rotator.ToUeRotator(), false, ref fhitResult, false);
		}

		// Token: 0x0603C5AC RID: 247212 RVA: 0x00F509C8 File Offset: 0x00F4EBC8
		public void Destroy()
		{
			this.Actor = null;
		}

		// Token: 0x04021EF6 RID: 138998
		private AActor Actor;

		// Token: 0x04021EF7 RID: 138999
		private float DeltaSecondRotate;

		// Token: 0x04021EF8 RID: 139000
		private bool IsRotating;

		// Token: 0x04021EF9 RID: 139001
		private Rotator Rotator;

		// Token: 0x04021EFA RID: 139002
		private ERotateAxis? RotateAxis;

		// Token: 0x04021EFB RID: 139003
		private bool IsRotatePlus;
	}
}
