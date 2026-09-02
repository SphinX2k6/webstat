using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F94 RID: 24468
	[NullableContext(1)]
	[Nullable(0)]
	public class AlterMark : UiPanelBase
	{
		// Token: 0x0603D6D1 RID: 251601 RVA: 0x00FA0C40 File Offset: 0x00F9EE40
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D6D2 RID: 251602 RVA: 0x00FA0CCC File Offset: 0x00F9EECC
		protected override void OnStart()
		{
			this.Mark = base.GetItem(0);
			this.RightSprite = base.GetSprite(1);
			this.LeftSprite = base.GetSprite(2);
			this.LeftSprite.SetFillAmount(0f);
			this.RightSprite.SetFillAmount(0f);
			this.LeftSprite.SetColor(FColor.FromHex("B7E6E7FF"));
			this.RightSprite.SetColor(FColor.FromHex("B7E6E7FF"));
			base.GetItem(0).SetUIActive(false);
			base.GetSprite(1).SetUIActive(false);
			base.GetSprite(2).SetUIActive(false);
		}

		// Token: 0x0603D6D3 RID: 251603 RVA: 0x00FA0D74 File Offset: 0x00F9EF74
		[NullableContext(2)]
		public AlterMark([Nullable(1)] UUIItem parent, Vector originPosition = null, AActor trackActor = null)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			base.CreateThenShowByResourceIdAsync("UiItem_SneakItem_Prefab", parent, false).Forget();
			this.OriginalPosition = new FVectorDouble?((originPosition != null) ? originPosition.ToUeVector(false) : new FVectorDouble());
			this.TrackingActor = trackActor;
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
			this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
			this.PlayerController = Global.CharacterController;
			this.PlayerCameraManager = Global.CharacterCameraManager;
		}

		// Token: 0x0603D6D4 RID: 251604 RVA: 0x00FA0E74 File Offset: 0x00F9F074
		protected override void OnBeforeDestroy()
		{
			this.OriginalPosition = null;
			this.TrackingActor = null;
			this.RightSprite = null;
			this.LeftSprite = null;
			this.Mark = null;
			this.PlayerController = null;
			this.PlayerCameraManager = null;
			this.ProjectScreenLocation = null;
		}

		// Token: 0x0603D6D5 RID: 251605 RVA: 0x00FA0EB4 File Offset: 0x00F9F0B4
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
			if (Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation() == null)
			{
				this.RootItem.SetUIActive(false);
			}
			FVectorDouble value = this.GetCurTrackPosition().Value;
			this.TempTrackPosition.Set(value.X, value.Y, value.Z);
			this.RootItem.SetUIActive(true);
			this.Mark.SetUIActive(true);
			this.RightSprite.SetUIActive(true);
			this.LeftSprite.SetUIActive(true);
			FVectorDouble monsterLocation = this.GetMonsterLocation(this.TrackingActor);
			FVector2D inEllipsePosition = this.GetInEllipsePosition(monsterLocation);
			UUIItem rootItem = this.RootItem;
			FRotator frotator = new FRotator(0f, (float)(Math.Atan2((double)inEllipsePosition.Y, (double)inEllipsePosition.X) * 57.2957763671875 - 90.0), 0f);
			rootItem.SetUIRelativeRotation(frotator);
			this.AlertValueUpdate();
		}

		// Token: 0x0603D6D6 RID: 251606 RVA: 0x00FA0FA8 File Offset: 0x00F9F1A8
		private FVectorDouble? GetCurTrackPosition()
		{
			if (!ObjectUtils.IsValid(this.TrackingActor))
			{
				return this.OriginalPosition;
			}
			return new FVectorDouble?(this.TrackingActor.D_K2_GetActorLocation());
		}

		// Token: 0x0603D6D7 RID: 251607 RVA: 0x00FA0FCE File Offset: 0x00F9F1CE
		private FVectorDouble GetMonsterLocation(AActor monsterActor)
		{
			return monsterActor.D_K2_GetActorLocation();
		}

		// Token: 0x0603D6D8 RID: 251608 RVA: 0x00FA0FD8 File Offset: 0x00F9F1D8
		private FVector2D GetInEllipsePosition(in FVectorDouble monsterLocation)
		{
			FVector2D screenPosition = new FVector2D();
			if (UGameplayStatics.D_ProjectWorldToScreen(this.PlayerController, monsterLocation, ref screenPosition, false))
			{
				return this.ScreenPositionToEllipsePosition(screenPosition, true);
			}
			Vector projectionToFrontPosition = this.GetProjectionToFrontPosition(monsterLocation);
			APlayerController playerController = this.PlayerController;
			FVectorDouble fvectorDouble = projectionToFrontPosition.ToUeVector(false);
			UGameplayStatics.D_ProjectWorldToScreen(playerController, fvectorDouble, ref screenPosition, false);
			return this.ScreenPositionToEllipsePosition(screenPosition, false);
		}

		// Token: 0x0603D6D9 RID: 251609 RVA: 0x00FA1030 File Offset: 0x00F9F230
		private FVector2D ScreenPositionToEllipsePosition(FVector2D screenPosition, bool isInScreen)
		{
			float viewportSizeX = this.GetViewportSizeX();
			FVector2D uiRootItemSize = this.GetUiRootItemSize();
			FVector2D fvector2D = screenPosition * (uiRootItemSize.X / viewportSizeX);
			FVector2D fvector2D2 = uiRootItemSize * 0.5f;
			FVector2D fvector2D3 = fvector2D - fvector2D2;
			FVector2D fvector2D4 = new FVector2D(1f, -1f);
			FVector2D vector = fvector2D3 * fvector2D4;
			FVector2D fvector2D5 = this.ClampToEllipse(vector, this.LimitA, this.LimitB, isInScreen);
			fvector2D = TrackDefine.center.ToUeVector2D(false);
			return fvector2D5 + fvector2D;
		}

		// Token: 0x0603D6DA RID: 251610 RVA: 0x00FA10BC File Offset: 0x00F9F2BC
		private float GetViewportSizeX()
		{
			int num = 0;
			int num2 = 0;
			this.PlayerController.GetViewportSize(ref num, ref num2);
			return (float)num;
		}

		// Token: 0x0603D6DB RID: 251611 RVA: 0x00FA10E0 File Offset: 0x00F9F2E0
		private FVector2D GetUiRootItemSize()
		{
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			return new FVector2D(uiRootItem.GetWidth(), uiRootItem.GetHeight());
		}

		// Token: 0x0603D6DC RID: 251612 RVA: 0x00FA110C File Offset: 0x00F9F30C
		private FVector2D ClampToEllipse(FVector2D vector, float majorAxis, float minorAxis, bool isInScreen)
		{
			float x = vector.X;
			float y = vector.Y;
			if (isInScreen && x * x / (majorAxis * majorAxis) + y * y / (minorAxis * minorAxis) <= 1f)
			{
				return vector;
			}
			double num = (double)(majorAxis * minorAxis) / Math.Sqrt((double)(minorAxis * minorAxis * x * x + majorAxis * majorAxis * y * y));
			return vector * (float)num;
		}

		// Token: 0x0603D6DD RID: 251613 RVA: 0x00FA1168 File Offset: 0x00F9F368
		private Vector GetProjectionToFrontPosition(in FVectorDouble targetLocation)
		{
			this.TargetLocation.Set(targetLocation.X, targetLocation.Y, targetLocation.Z);
			Vector playerLocation = this.GetPlayerLocation();
			Vector monsterToPlayerVector = this.GetMonsterToPlayerVector(this.TargetLocation);
			FVectorDouble cameraForwardVector = this.GetCameraForwardVector();
			FVectorDouble fvectorDouble = UKismetMathLibrary.D_ProjectVectorOnToVector(monsterToPlayerVector.ToUeVector(false), cameraForwardVector);
			FVectorDouble fvectorDouble2 = fvectorDouble * 2.0;
			this.ProjectScreenLocation.Set(fvectorDouble2.X, fvectorDouble2.Y, fvectorDouble2.Z);
			monsterToPlayerVector.SubtractionEqual(this.ProjectScreenLocation);
			playerLocation.Addition(monsterToPlayerVector, this.TargetLocation);
			return this.TargetLocation;
		}

		// Token: 0x0603D6DE RID: 251614 RVA: 0x00FA1208 File Offset: 0x00F9F408
		private Vector GetPlayerLocation()
		{
			FVectorDouble actorLocation = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseActorComponent>().ActorLocation;
			this.PlayerLocation.Set(actorLocation.X, actorLocation.Y, actorLocation.Z);
			return this.PlayerLocation;
		}

		// Token: 0x0603D6DF RID: 251615 RVA: 0x00FA1254 File Offset: 0x00F9F454
		private Vector GetMonsterToPlayerVector(Vector monsterLocation)
		{
			Vector playerLocation = this.GetPlayerLocation();
			monsterLocation.Subtraction(playerLocation, this.MonsterToPlayerVector);
			return this.MonsterToPlayerVector;
		}

		// Token: 0x0603D6E0 RID: 251616 RVA: 0x00FA127C File Offset: 0x00F9F47C
		private FVectorDouble GetCameraForwardVector()
		{
			return this.PlayerCameraManager.GetCameraRotation().VectorDouble();
		}

		// Token: 0x0603D6E1 RID: 251617 RVA: 0x00FA129C File Offset: 0x00F9F49C
		private void AlertValueUpdate()
		{
			float alertValue = ActorUtils.GetEntityByActor(this.TrackingActor, true).Entity.GetComponent<CharacterAiComponent>().AiController.AiAlert.AlertValue;
			this.LeftSprite.SetFillAmount(0.5f + alertValue / 100f / 2f);
			this.RightSprite.SetFillAmount(0.5f + alertValue / 100f / 2f);
			if (alertValue < 50f)
			{
				if (this.AlterLevel == AlterMark.EAlterLevel.Normal)
				{
					return;
				}
				this.AlterLevel = AlterMark.EAlterLevel.Normal;
				this.LeftSprite.SetColor(FColor.FromHex("B7E6E7FF"));
				this.RightSprite.SetColor(FColor.FromHex("B7E6E7FF"));
				return;
			}
			else if (alertValue < 80f)
			{
				if (this.AlterLevel == AlterMark.EAlterLevel.Warning)
				{
					return;
				}
				this.AlterLevel = AlterMark.EAlterLevel.Warning;
				this.LeftSprite.SetColor(FColor.FromHex("EDDC4DFF"));
				this.RightSprite.SetColor(FColor.FromHex("EDDC4DFF"));
				return;
			}
			else
			{
				if (this.AlterLevel == AlterMark.EAlterLevel.Error)
				{
					return;
				}
				this.AlterLevel = AlterMark.EAlterLevel.Error;
				this.LeftSprite.SetColor(FColor.FromHex("F01D1BFF"));
				this.RightSprite.SetColor(FColor.FromHex("F01D1BFF"));
				return;
			}
		}

		// Token: 0x04022849 RID: 141385
		private const int MAX_ALERT = 100;

		// Token: 0x0402284A RID: 141386
		private const float START_FILL_AMOUNT = 0.5f;

		// Token: 0x0402284B RID: 141387
		private const string NORMAL_COLOR = "B7E6E7FF";

		// Token: 0x0402284C RID: 141388
		private const string WARNING_COLOR = "EDDC4DFF";

		// Token: 0x0402284D RID: 141389
		private const string ERROR_COLOR = "F01D1BFF";

		// Token: 0x0402284E RID: 141390
		private FVectorDouble? OriginalPosition;

		// Token: 0x0402284F RID: 141391
		[Nullable(2)]
		private AActor TrackingActor;

		// Token: 0x04022850 RID: 141392
		private readonly float LimitA;

		// Token: 0x04022851 RID: 141393
		private readonly float LimitB;

		// Token: 0x04022852 RID: 141394
		private readonly Vector TempTrackPosition = Vector.Create();

		// Token: 0x04022853 RID: 141395
		[Nullable(2)]
		private UUISprite RightSprite;

		// Token: 0x04022854 RID: 141396
		[Nullable(2)]
		private UUISprite LeftSprite;

		// Token: 0x04022855 RID: 141397
		[Nullable(2)]
		private UUIItem Mark;

		// Token: 0x04022856 RID: 141398
		[Nullable(2)]
		private APlayerController PlayerController;

		// Token: 0x04022857 RID: 141399
		private readonly Vector TargetLocation = Vector.Create();

		// Token: 0x04022858 RID: 141400
		private readonly Vector PlayerLocation = Vector.Create();

		// Token: 0x04022859 RID: 141401
		private readonly Vector MonsterToPlayerVector = Vector.Create();

		// Token: 0x0402285A RID: 141402
		[Nullable(2)]
		private APlayerCameraManager PlayerCameraManager;

		// Token: 0x0402285B RID: 141403
		[Nullable(2)]
		private Vector ProjectScreenLocation = Vector.Create();

		// Token: 0x0402285C RID: 141404
		private AlterMark.EAlterLevel AlterLevel;

		// Token: 0x0200BF80 RID: 49024
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403AF22 RID: 241442
			UIContainerRoot,
			// Token: 0x0403AF23 RID: 241443
			UIContainerRight,
			// Token: 0x0403AF24 RID: 241444
			UIContainerLeft
		}

		// Token: 0x0200BF81 RID: 49025
		[NullableContext(0)]
		private enum EAlterLevel
		{
			// Token: 0x0403AF26 RID: 241446
			Normal,
			// Token: 0x0403AF27 RID: 241447
			Warning = 50,
			// Token: 0x0403AF28 RID: 241448
			Error = 80
		}
	}
}
