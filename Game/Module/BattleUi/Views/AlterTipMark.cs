using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F97 RID: 24471
	[NullableContext(1)]
	[Nullable(0)]
	public class AlterTipMark : UiPanelBase
	{
		// Token: 0x0603D70A RID: 251658 RVA: 0x00FA25BC File Offset: 0x00FA07BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D70B RID: 251659 RVA: 0x00FA2625 File Offset: 0x00FA0825
		protected override void OnStart()
		{
			this.WarningItem = base.GetItem(0);
			this.ErrorItem = base.GetItem(1);
			base.GetItem(0).SetUIActive(false);
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x0603D70C RID: 251660 RVA: 0x00FA265C File Offset: 0x00FA085C
		public AlterTipMark(UUIItem parent, AActor trackActor, bool isBattle)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			base.CreateThenShowByResourceIdAsync("UiItem_SneakTip", parent, false).Forget();
			this.TrackingActor = trackActor;
			this.IsBattle = isBattle;
		}

		// Token: 0x0603D70D RID: 251661 RVA: 0x00FA26F6 File Offset: 0x00FA08F6
		public void Update()
		{
			if (GlobalData.World == null)
			{
				return;
			}
			if (this.RootItem == null)
			{
				return;
			}
			this.PositionUpdate();
			if (!this.IsBattle)
			{
				this.AlertValueUpdate();
			}
		}

		// Token: 0x0603D70E RID: 251662 RVA: 0x00FA2720 File Offset: 0x00FA0920
		private void PositionUpdate()
		{
			if (this.TrackingActor == null)
			{
				return;
			}
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			TsCharacterController characterController = Global.CharacterController;
			FVectorDouble fvectorDouble = this.TrackingActor.D_K2_GetActorLocation();
			this.TempTrackPosition.Set(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z);
			FVector2D fvector2D = new FVector2D();
			if (!UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref fvector2D, false))
			{
				this.TempTrackPosition.Subtraction(playerLocation, this.Offset);
				Rotator.Create(Global.CharacterCameraManager.GetCameraRotation()).Vector(this.CameraForward);
				FVectorDouble fvectorDouble2 = UKismetMathLibrary.D_ProjectVectorOnToVector(this.Offset.ToUeVector(false), this.CameraForward.ToUeVector(false));
				FVectorDouble fvectorDouble3 = fvectorDouble2 * 2.0;
				this.ProjectResult.Set(fvectorDouble3.X, fvectorDouble3.Y, fvectorDouble3.Z);
				this.Offset.SubtractionEqual(this.ProjectResult);
				playerLocation.Addition(this.Offset, this.TempTrackPosition);
				APlayerController player = characterController;
				fvectorDouble2 = this.TempTrackPosition.ToUeVector(false);
				UGameplayStatics.D_ProjectWorldToScreen(player, fvectorDouble2, ref fvector2D, false);
			}
			int num = 0;
			int num2 = 0;
			characterController.GetViewportSize(ref num, ref num2);
			this.ScreenPosition.Set((double)fvector2D.X, (double)fvector2D.Y);
			this.ViewportSize.Set((double)(uiRootItem.GetWidth() * 0.5f), (double)(uiRootItem.GetHeight() * 0.5f));
			this.ScreenPosition.MultiplyEqual((double)(uiRootItem.GetWidth() / (float)num)).SubtractionEqual(this.ViewportSize).MultiplyEqual(this.PointTransport);
			Vector2D vector2D = this.ScreenPosition.AdditionEqual(TrackDefine.center);
			float x = (float)Vector.Distance(playerLocation, this.TempTrackPosition);
			vector2D.AdditionEqual(Vector2D.Create(0.0, (double)this.GetOffsetY(x)));
			this.RootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
		}

		// Token: 0x0603D70F RID: 251663 RVA: 0x00FA2924 File Offset: 0x00FA0B24
		private void AlertValueUpdate()
		{
			float alertValue = ActorUtils.GetEntityByActor(this.TrackingActor, true).Entity.GetComponent<CharacterAiComponent>().AiController.AiAlert.AlertValue;
			if (alertValue > 0f)
			{
				if (this.AlterLevel > 0.0)
				{
					return;
				}
				this.WarningItem.SetUIActive(true);
				this.ErrorItem.SetUIActive(false);
			}
			else
			{
				this.WarningItem.SetUIActive(false);
				this.ErrorItem.SetUIActive(false);
			}
			this.AlterLevel = (double)alertValue;
		}

		// Token: 0x0603D710 RID: 251664 RVA: 0x00FA29AB File Offset: 0x00FA0BAB
		private float GetOffsetY(float x)
		{
			return 6E-05f * x * x - 0.2f * x + 275f;
		}

		// Token: 0x0603D711 RID: 251665 RVA: 0x00FA29C4 File Offset: 0x00FA0BC4
		public void ChangeToError()
		{
			UUIItem warningItem = this.WarningItem;
			if (warningItem != null)
			{
				warningItem.SetUIActive(false);
			}
			UUIItem errorItem = this.ErrorItem;
			if (errorItem == null)
			{
				return;
			}
			errorItem.SetUIActive(true);
		}

		// Token: 0x0402286D RID: 141421
		[Nullable(2)]
		private readonly AActor TrackingActor;

		// Token: 0x0402286E RID: 141422
		private readonly Vector TempTrackPosition = Vector.Create();

		// Token: 0x0402286F RID: 141423
		private readonly Vector Offset = Vector.Create();

		// Token: 0x04022870 RID: 141424
		private readonly Vector CameraForward = Vector.Create();

		// Token: 0x04022871 RID: 141425
		private readonly Vector ProjectResult = Vector.Create();

		// Token: 0x04022872 RID: 141426
		private readonly Vector2D ScreenPosition = Vector2D.Create();

		// Token: 0x04022873 RID: 141427
		private readonly Vector2D ViewportSize = Vector2D.Create();

		// Token: 0x04022874 RID: 141428
		private readonly Vector2D PointTransport = Vector2D.Create(1.0, -1.0);

		// Token: 0x04022875 RID: 141429
		private double AlterLevel;

		// Token: 0x04022876 RID: 141430
		[Nullable(2)]
		private UUIItem ErrorItem;

		// Token: 0x04022877 RID: 141431
		[Nullable(2)]
		private UUIItem WarningItem;

		// Token: 0x04022878 RID: 141432
		private readonly bool IsBattle;

		// Token: 0x0200BF85 RID: 49029
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403AF32 RID: 241458
			UITipsWarning,
			// Token: 0x0403AF33 RID: 241459
			UITipError
		}
	}
}
