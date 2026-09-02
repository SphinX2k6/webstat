using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common
{
	// Token: 0x02006F26 RID: 28454
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonMarkItem : UiPanelBase
	{
		// Token: 0x06044E7A RID: 282234 RVA: 0x011EF794 File Offset: 0x011ED994
		[NullableContext(2)]
		public CommonMarkItem(in FVectorDouble targetPosition, Vector2D center = null)
		{
			this.TargetPosition = targetPosition;
			this.Center = (center ?? Vector2D.Create(0.0, 0.0));
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
			this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
		}

		// Token: 0x06044E7B RID: 282235 RVA: 0x011EF88B File Offset: 0x011EDA8B
		public Vector2D GetScreenPositionWithoutClamp([Nullable(2)] Vector2D inVector = null)
		{
			if (inVector != null)
			{
				inVector.DeepCopy(this.ScreenPositionWithoutClamp);
				return inVector;
			}
			return this.ScreenPositionWithoutClamp;
		}

		// Token: 0x06044E7C RID: 282236 RVA: 0x011EF8A4 File Offset: 0x011EDAA4
		protected bool IsInRange()
		{
			return this.InRange;
		}

		// Token: 0x06044E7D RID: 282237 RVA: 0x011EF8AC File Offset: 0x011EDAAC
		protected virtual void InRangeStateChanged(bool bInRange, bool bFirst = false)
		{
		}

		// Token: 0x06044E7E RID: 282238 RVA: 0x011EF8AE File Offset: 0x011EDAAE
		protected virtual void OnScreenPositionChanged(bool bInRange)
		{
		}

		// Token: 0x06044E7F RID: 282239 RVA: 0x011EF8B0 File Offset: 0x011EDAB0
		public virtual void OnTick(float delta)
		{
			this.UpdatePositionAndRotation();
		}

		// Token: 0x06044E80 RID: 282240 RVA: 0x011EF8B8 File Offset: 0x011EDAB8
		protected void UpdatePositionAndRotation()
		{
			FVectorDouble targetPosition = this.TargetPosition;
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, this.TargetPosition, ref this.ScreenPositionRef, false);
			if (!flag)
			{
				FTransformDouble value = ModelBase<CameraModel>.Instance.MainModel.CameraTransform.Value;
				FVectorDouble fvectorDouble = value.InverseTransformPositionNoScale(this.TargetPosition);
				fvectorDouble.X = -fvectorDouble.X;
				FVectorDouble fvectorDouble2 = value.TransformPositionNoScale(fvectorDouble);
				UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble2, ref this.ScreenPositionRef, false);
			}
			this.ScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
			if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
			{
				this.LastScreenPosition.DeepCopy(this.ScreenPosition);
				BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
				this.ScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset).MultiplyEqual(this.PointTransport);
				this.ScreenPositionWithoutClamp.DeepCopy(this.ScreenPosition);
				this.InRange = this.ClampToEllipse(this.ScreenPosition, flag);
				if (this.InRange != this.LastInRange)
				{
					this.InRangeStateChanged(this.InRange, false);
				}
				this.LastInRange = this.InRange;
				Vector2D vector2D = this.ScreenPosition.AdditionEqual(this.Center);
				this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
				this.OnScreenPositionChanged(this.InRange);
			}
		}

		// Token: 0x06044E81 RID: 282241 RVA: 0x011EFA3C File Offset: 0x011EDC3C
		protected virtual bool ClampToEllipse(Vector2D vector, bool inFront)
		{
			double x = vector.X;
			double y = vector.Y;
			float limitA = this.LimitA;
			float limitB = this.LimitB;
			if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
			{
				return true;
			}
			double inB = (double)(limitA * limitB) / Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
			vector.MultiplyEqual(inB);
			return false;
		}

		// Token: 0x0402669B RID: 157339
		protected FVector2D ScreenPositionRef = new FVector2D(0f, 0f);

		// Token: 0x0402669C RID: 157340
		protected readonly Vector2D ScreenPosition = Vector2D.Create();

		// Token: 0x0402669D RID: 157341
		protected readonly Vector2D LastScreenPosition = Vector2D.Create();

		// Token: 0x0402669E RID: 157342
		private readonly Vector2D ScreenPositionWithoutClamp = Vector2D.Create();

		// Token: 0x0402669F RID: 157343
		protected readonly Vector2D PointTransport = Vector2D.Create(1.0, -1.0);

		// Token: 0x040266A0 RID: 157344
		private bool LastInRange;

		// Token: 0x040266A1 RID: 157345
		protected bool InRange;

		// Token: 0x040266A2 RID: 157346
		private readonly float LimitA;

		// Token: 0x040266A3 RID: 157347
		private readonly float LimitB;

		// Token: 0x040266A4 RID: 157348
		protected FVectorDouble TargetPosition;

		// Token: 0x040266A5 RID: 157349
		protected readonly Vector2D Center;
	}
}
