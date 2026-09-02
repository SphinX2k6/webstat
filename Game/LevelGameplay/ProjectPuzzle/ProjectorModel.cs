using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ProjectPuzzle
{
	// Token: 0x02006B2E RID: 27438
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ProjectorModel : ModelBase<ProjectorModel>
	{
		// Token: 0x06043CBA RID: 277690 RVA: 0x01184068 File Offset: 0x01182268
		public void InitFromComponent(int entityId, float rotationSpeed, float dragRotationCoefficient, float matchTolerance, Rotator[] targetRotators, Action<bool> finishCallback)
		{
			this.IsActive = true;
			this.EntityId = entityId;
			this.RotationSpeed = rotationSpeed;
			this.DragRotationCoefficient = dragRotationCoefficient;
			this.MatchTolerance = matchTolerance;
			this.IsCompleted = false;
			this.FinishCallback = finishCallback;
			if (targetRotators.Length == 0)
			{
				this.TargetRotators = Array.Empty<Rotator>();
			}
			else
			{
				Rotator[] array = new Rotator[targetRotators.Length];
				Array.Copy(targetRotators, array, targetRotators.Length);
				this.TargetRotators = array;
			}
			this.ResetInputState();
		}

		// Token: 0x06043CBB RID: 277691 RVA: 0x011840DD File Offset: 0x011822DD
		protected override bool OnClear()
		{
			this.Reset();
			return true;
		}

		// Token: 0x06043CBC RID: 277692 RVA: 0x011840E8 File Offset: 0x011822E8
		public void ResetInputState()
		{
			this.HasLastArcballVector = false;
			this.DragCenterX = 0f;
			this.DragCenterY = 0f;
			this.FrameDragAngle = 0f;
			this.FrameStickAngle = 0f;
			this.LastArcballVector.Reset();
			this.TempArcballVector.Reset();
			this.TempAxis.Reset();
			this.TempWorldAxis.Reset();
		}

		// Token: 0x06043CBD RID: 277693 RVA: 0x01184154 File Offset: 0x01182354
		public void Reset()
		{
			this.EntityId = 0;
			this.IsActive = false;
			this.IsCompleted = false;
			this.RotationSpeed = 0f;
			this.DragRotationCoefficient = 0f;
			this.MatchTolerance = 0f;
			this.TargetRotators = Array.Empty<Rotator>();
			this.FinishCallback = null;
			this.AttachActor = null;
			this.InitialAttachRelativeRotator.Set(0f, 0f, 0f);
			this.BackgroundActor = null;
			this.BackgroundDecalEffectId = 0;
			this.ShadowCompensationActor = null;
			this.RotationAudioHandle = 0;
			this.ResetInputState();
		}

		// Token: 0x04025EA7 RID: 155303
		public int EntityId;

		// Token: 0x04025EA8 RID: 155304
		public bool IsActive;

		// Token: 0x04025EA9 RID: 155305
		public bool IsCompleted;

		// Token: 0x04025EAA RID: 155306
		public float RotationSpeed;

		// Token: 0x04025EAB RID: 155307
		public float DragRotationCoefficient;

		// Token: 0x04025EAC RID: 155308
		public float MatchTolerance;

		// Token: 0x04025EAD RID: 155309
		public Rotator[] TargetRotators = Array.Empty<Rotator>();

		// Token: 0x04025EAE RID: 155310
		[Nullable(2)]
		public Action<bool> FinishCallback;

		// Token: 0x04025EAF RID: 155311
		[Nullable(2)]
		public AActor AttachActor;

		// Token: 0x04025EB0 RID: 155312
		public readonly Rotator InitialAttachRelativeRotator = Rotator.Create();

		// Token: 0x04025EB1 RID: 155313
		[Nullable(2)]
		public AActor BackgroundActor;

		// Token: 0x04025EB2 RID: 155314
		public int BackgroundDecalEffectId;

		// Token: 0x04025EB3 RID: 155315
		[Nullable(2)]
		public AStaticMeshActor ShadowCompensationActor;

		// Token: 0x04025EB4 RID: 155316
		public int RotationAudioHandle;

		// Token: 0x04025EB5 RID: 155317
		public float FrameDragAngle;

		// Token: 0x04025EB6 RID: 155318
		public float FrameStickAngle;

		// Token: 0x04025EB7 RID: 155319
		public bool HasLastArcballVector;

		// Token: 0x04025EB8 RID: 155320
		public float DragCenterX;

		// Token: 0x04025EB9 RID: 155321
		public float DragCenterY;

		// Token: 0x04025EBA RID: 155322
		public readonly Vector LastArcballVector = Vector.Create();

		// Token: 0x04025EBB RID: 155323
		public readonly Vector TempArcballVector = Vector.Create();

		// Token: 0x04025EBC RID: 155324
		public readonly Vector TempAxis = Vector.Create();

		// Token: 0x04025EBD RID: 155325
		public readonly Vector TempWorldAxis = Vector.Create();

		// Token: 0x04025EBE RID: 155326
		public readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04025EBF RID: 155327
		public readonly Quat TempQuat2 = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04025EC0 RID: 155328
		public readonly Rotator TempRotator = Rotator.Create();
	}
}
