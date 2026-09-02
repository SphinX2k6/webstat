using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Core.Utils.LockingHandler;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007084 RID: 28804
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraCollision
	{
		// Token: 0x06045CB4 RID: 285876 RVA: 0x01243BDB File Offset: 0x01241DDB
		public void Init(FightCameraLogicComponent camera)
		{
			this.Camera = camera;
		}

		// Token: 0x06045CB5 RID: 285877 RVA: 0x01243BE4 File Offset: 0x01241DE4
		public void InitTraceElements()
		{
			this.CameraSphereTrace = new UTraceSphereElement();
			this.CameraSphereTrace.bIsSingle = false;
			this.CameraSphereTrace.bTraceComplex = false;
			this.CameraSphereTrace.bIgnoreSelf = true;
			this.CameraSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
			this.CameraRightSphereTrace = new UTraceSphereElement();
			this.CameraRightSphereTrace.bIsSingle = true;
			this.CameraRightSphereTrace.bTraceComplex = false;
			this.CameraRightSphereTrace.bIgnoreSelf = true;
			this.CameraRightSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
			this.CameraLeftSphereTrace = new UTraceSphereElement();
			this.CameraLeftSphereTrace.bIsSingle = true;
			this.CameraLeftSphereTrace.bTraceComplex = false;
			this.CameraLeftSphereTrace.bIgnoreSelf = true;
			this.CameraLeftSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
			this.CameraNpcSphereTrace = new UTraceSphereElement();
			this.CameraNpcSphereTrace.bIsSingle = false;
			this.CameraNpcSphereTrace.bTraceComplex = false;
			this.CameraNpcSphereTrace.bIgnoreSelf = true;
			this.CameraNpcSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
			this.CameraNpcSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
			this.CameraNpcSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
			this.CameraPlayerSphereTrace = new UTraceSphereElement();
			this.CameraPlayerSphereTrace.bIsSingle = false;
			this.CameraPlayerSphereTrace.bTraceComplex = false;
			this.CameraPlayerSphereTrace.bIgnoreSelf = true;
			this.CameraPlayerSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
			this.CameraPlayerSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
			this.CameraPlayerSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
			this.CameraInPlaceSphereTrace = new UTraceSphereElement();
			this.CameraInPlaceSphereTrace.bIsSingle = true;
			this.CameraInPlaceSphereTrace.bTraceComplex = false;
			this.CameraInPlaceSphereTrace.bIgnoreSelf = true;
			this.CameraInPlaceSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
		}

		// Token: 0x06045CB6 RID: 285878 RVA: 0x01243DAC File Offset: 0x01241FAC
		public void SetDrawDebugEnable(bool isEnable)
		{
			if (isEnable)
			{
				this.CameraSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				this.CameraSphereTrace.DrawTime = 5f;
				this.CameraRightSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				this.CameraRightSphereTrace.DrawTime = 5f;
				this.CameraLeftSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				this.CameraLeftSphereTrace.DrawTime = 5f;
				this.CameraNpcSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				this.CameraNpcSphereTrace.DrawTime = 5f;
				this.CameraPlayerSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
				this.CameraPlayerSphereTrace.DrawTime = 5f;
				this.CameraInPlaceSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				this.CameraInPlaceSphereTrace.DrawTime = 5f;
				return;
			}
			this.CameraSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			this.CameraSphereTrace.DrawTime = 0f;
			this.CameraRightSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			this.CameraRightSphereTrace.DrawTime = 0f;
			this.CameraLeftSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			this.CameraLeftSphereTrace.DrawTime = 0f;
			this.CameraNpcSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			this.CameraNpcSphereTrace.DrawTime = 0f;
			this.CameraPlayerSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			this.CameraPlayerSphereTrace.DrawTime = 0f;
			this.CameraInPlaceSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
			this.CameraInPlaceSphereTrace.DrawTime = 0f;
		}

		// Token: 0x06045CB7 RID: 285879 RVA: 0x01243F10 File Offset: 0x01242110
		public void SetCharacter(TsBaseCharacter character)
		{
			this.Character = character;
			this.CameraSphereTrace.ActorsToIgnore.Add(character);
			this.CameraRightSphereTrace.ActorsToIgnore.Add(character);
			this.CameraLeftSphereTrace.ActorsToIgnore.Add(character);
			this.CameraNpcSphereTrace.ActorsToIgnore.Add(character);
			this.CameraPlayerSphereTrace.ActorsToIgnore.Add(character);
			this.CameraInPlaceSphereTrace.ActorsToIgnore.Add(character);
			CharacterSwimComponent charSwimComp;
			if (character == null)
			{
				charSwimComp = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = character.CharacterActorComponent;
				charSwimComp = ((characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterSwimComponent>() : null);
			}
			this.CharSwimComp = charSwimComp;
		}

		// Token: 0x06045CB8 RID: 285880 RVA: 0x01243FAD File Offset: 0x012421AD
		public void SetCameraConfig(float collisionProbeSize, float minFloorZnOffset)
		{
			this.CameraCollisionProbeSizeSquared = collisionProbeSize * collisionProbeSize * 4f;
			this.CameraMinFloorZnOffset = minFloorZnOffset;
		}

		// Token: 0x06045CB9 RID: 285881 RVA: 0x01243FC8 File Offset: 0x012421C8
		public void Clear()
		{
			if (this.CameraSphereTrace != null)
			{
				this.CameraSphereTrace.Dispose();
				this.CameraSphereTrace = null;
			}
			if (this.CameraLeftSphereTrace != null)
			{
				this.CameraLeftSphereTrace.Dispose();
				this.CameraLeftSphereTrace = null;
			}
			if (this.CameraRightSphereTrace != null)
			{
				this.CameraRightSphereTrace.Dispose();
				this.CameraRightSphereTrace = null;
			}
			if (this.CameraNpcSphereTrace != null)
			{
				this.CameraNpcSphereTrace.Dispose();
				this.CameraNpcSphereTrace = null;
			}
			if (this.CameraPlayerSphereTrace != null)
			{
				this.CameraPlayerSphereTrace.Dispose();
				this.CameraPlayerSphereTrace = null;
			}
			if (this.CameraInPlaceSphereTrace != null)
			{
				this.CameraInPlaceSphereTrace.Dispose();
				this.CameraInPlaceSphereTrace = null;
			}
			this.IsMiddleCollision = false;
			this.IsInPlaceCollision = false;
			this.IsCameraFloatOnWater = false;
			this.IsLeftCollision = false;
			this.IsRightCollision = false;
			this.DitheredNpcSet.Clear();
			this.OcclusionDitherDataMap.Clear();
			this.LastFrameActiveDitherActors.Clear();
			this.WaitRemoveActorList.Clear();
		}

		// Token: 0x06045CBA RID: 285882 RVA: 0x012440C0 File Offset: 0x012422C0
		public void ResetBlendData()
		{
			this.CurrentBlendState = ECollisionBlendState.None;
		}

		// Token: 0x06045CBB RID: 285883 RVA: 0x012440C9 File Offset: 0x012422C9
		public Vector CheckCollision(Vector armLocation, Vector cameraLocation, float deltaTime)
		{
			this.CameraTargetLocation.DeepCopy(cameraLocation);
			if (this.CollisionMode == ECameraCollisionMode.Default)
			{
				this.DefaultCheckWorkFlow(armLocation, cameraLocation, deltaTime);
			}
			else if (this.CollisionMode == ECameraCollisionMode.InPlaceProbe)
			{
				this.InPlaceProbeCheckWorkFlow(armLocation, cameraLocation, deltaTime);
			}
			return this.CameraTargetLocation;
		}

		// Token: 0x06045CBC RID: 285884 RVA: 0x01244104 File Offset: 0x01242304
		private void DefaultCheckWorkFlow(Vector armLocation, Vector cameraLocation, float deltaTime)
		{
			if (this.IsCameraCollisionEnable() && this.GmCameraCollisionEnable)
			{
				this.SetCollisionSize();
				this.CheckMiddleCollision(armLocation, cameraLocation);
				this.CheckTwoSideCollision(armLocation, cameraLocation);
				this.CheckFloatOnWater();
				this.UpdateBlendState(armLocation, cameraLocation);
				this.UpdateBlendLocation(armLocation, cameraLocation, deltaTime);
			}
			this.ResetAllOcclusionDither();
			this.UpdateNpcDither();
			this.TraceElementBetweenCameraAndPlayer(armLocation);
			bool needXRay = this.IsHitSomethingBetweenCameraAndPlayer && this.IsPlayerBlueStateEnable(this.CameraPlayerSphereTrace.HitResult);
			this.UpdatePlayerXRayState(needXRay);
			this.UpdateOcclusionDither();
			this.CalculateAllOcclusionDitherValue(deltaTime);
			this.SetAllDitherValue();
		}

		// Token: 0x06045CBD RID: 285885 RVA: 0x01244198 File Offset: 0x01242398
		private void InPlaceProbeCheckWorkFlow(Vector armLocation, Vector cameraLocation, float deltaTime)
		{
			if (this.IsCameraCollisionEnable() && this.GmCameraCollisionEnable)
			{
				this.SetCollisionSize();
				this.CheckInPlaceCollision(cameraLocation);
				this.IsCameraFloatOnWater = false;
				if (this.IsInPlaceCollision)
				{
					this.CheckMiddleCollision(armLocation, cameraLocation);
				}
				this.UpdateInPlaceBlendState(armLocation, cameraLocation);
				this.UpdateBlendLocation(armLocation, cameraLocation, deltaTime);
			}
			this.ResetAllOcclusionDither();
			this.UpdateNpcDither();
			this.UpdatePlayerXRayState(true);
			this.CalculateAllOcclusionDitherValue(deltaTime);
			this.SetAllDitherValue();
		}

		// Token: 0x06045CBE RID: 285886 RVA: 0x0124420C File Offset: 0x0124240C
		private void CheckMiddleCollision(Vector armLocation, Vector cameraLocation)
		{
			this.GravityDirect.DeepCopy(this.Camera.GravityDirect);
			this.StartLocation.DeepCopy(armLocation);
			this.EndLocation.DeepCopy(cameraLocation);
			this.CameraSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraSphereTrace.Radius = this.Camera.CurrentCollisionSize;
			if (this.CharSwimComp != null)
			{
				double znInGravityForDirect = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, this.StartLocation);
				Vector tmpVector = this.TmpVector;
				Vector vector = tmpVector;
				FVectorDouble waterLocation = this.CharSwimComp.GetWaterLocation();
				vector.DeepCopy(waterLocation);
				Singleton<GravityUtils>.Instance.AddZnInGravityForDirect(this.GravityDirect, tmpVector, this.Camera.CollisionAdditionalHeightInWater);
				double znInGravityForDirect2 = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, tmpVector);
				this.StartLocation.Z = ((znInGravityForDirect > znInGravityForDirect2) ? this.StartLocation.Z : tmpVector.Z);
			}
			double znInGravityForDirect3 = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, this.StartLocation);
			Vector tmpVector2 = this.TmpVector;
			tmpVector2.DeepCopy(this.Camera.Character.CharacterActorComponent.FloorLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForDirect(this.GravityDirect, tmpVector2, this.CameraMinFloorZnOffset);
			double znInGravityForDirect4 = Singleton<GravityUtils>.Instance.GetZnInGravityForDirect(this.GravityDirect, tmpVector2);
			this.StartLocation.Z = ((znInGravityForDirect3 > znInGravityForDirect4) ? this.StartLocation.Z : tmpVector2.Z);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraSphereTrace, this.StartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraSphereTrace, this.EndLocation);
			this.IsMiddleCollision = false;
			if (Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera"))
			{
				this.MiddleCollisionHitIndex = this.GetValidHitIndex(this.StartLocation, this.EndLocation, this.CameraSphereTrace.HitResult);
				if (this.MiddleCollisionHitIndex >= 0)
				{
					Singleton<TraceElementCommon>.Instance.GetHitLocation(this.CameraSphereTrace.HitResult, this.MiddleCollisionHitIndex, this.CameraTargetLocation);
					this.IsMiddleCollision = true;
				}
			}
		}

		// Token: 0x06045CBF RID: 285887 RVA: 0x01244424 File Offset: 0x01242624
		private void CheckFloatOnWater()
		{
			this.IsCameraFloatOnWater = false;
			if (!this.IsMiddleCollision)
			{
				return;
			}
			UKuroHitResult hitResult = this.CameraSphereTrace.HitResult;
			TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr = (hitResult != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(hitResult.Components.Get(this.MiddleCollisionHitIndex)) : null;
			UKuroHitResult hitResult2 = this.CameraSphereTrace.HitResult;
			TArray<int> tarray = (hitResult2 != null) ? hitResult2.ItemArray : null;
			int instanceIndex = (tarray != null && this.MiddleCollisionHitIndex < tarray.Num()) ? tarray.Get(this.MiddleCollisionHitIndex) : 0;
			if (tweakObjectPtr != null && tweakObjectPtr.GetValueOrDefault().IsValid(false, false))
			{
				TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr2 = tweakObjectPtr;
				if (!(UKuroCollisionLibrary.GetCollisionResponseToChannel((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null, KuroCollisionChannel.Water, instanceIndex) != ECollisionResponse.ECR_Block))
				{
					this.IsCameraFloatOnWater = true;
					return;
				}
			}
		}

		// Token: 0x06045CC0 RID: 285888 RVA: 0x01244508 File Offset: 0x01242708
		private void CheckTwoSideCollision(Vector armLocation, Vector cameraLocation)
		{
			if (!this.IsMiddleCollision)
			{
				return;
			}
			armLocation.Subtraction(cameraLocation, this.ArmDirection);
			this.ArmDirection.Normalize(9.99999993922529E-09);
			double num = (double)(this.Camera.CheckWidth + this.CurrentCollisionDifferenceSize) / Vector.Dist(cameraLocation, this.CameraTargetLocation);
			double inB = Vector.Dist(cameraLocation, armLocation) * num;
			this.ArmDirection.CrossProduct(this.GravityDirect, this.OffsetVector);
			this.OffsetVector.MultiplyEqual(inB);
			armLocation.Addition(this.OffsetVector, this.StartLocation);
			UKuroHitResult hitResult = this.CameraRightSphereTrace.HitResult;
			if (hitResult != null)
			{
				hitResult.Clear();
			}
			this.CameraRightSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraRightSphereTrace.Radius = this.Camera.CheckCollisionProbeSize;
			this.StartLocation.DeepCopy(this.ModifyLocation(this.StartLocation, this.ArmDirection, -this.CameraRightSphereTrace.Radius));
			this.EndLocation.DeepCopy(cameraLocation);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraRightSphereTrace, this.StartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraRightSphereTrace, this.EndLocation);
			this.IsRightCollision = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraRightSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera");
			if (!this.IsRightCollision)
			{
				Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraRightSphereTrace, this.EndLocation);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraRightSphereTrace, this.StartLocation);
				this.IsRightCollision = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraRightSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera");
			}
			this.OffsetVector.UnaryNegation(this.OffsetVector);
			armLocation.Addition(this.OffsetVector, this.StartLocation);
			UKuroHitResult hitResult2 = this.CameraLeftSphereTrace.HitResult;
			if (hitResult2 != null)
			{
				hitResult2.Clear();
			}
			this.CameraLeftSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraLeftSphereTrace.Radius = this.Camera.CheckCollisionProbeSize;
			this.StartLocation.DeepCopy(this.ModifyLocation(this.StartLocation, this.ArmDirection, -this.CameraLeftSphereTrace.Radius));
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraLeftSphereTrace, this.StartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraLeftSphereTrace, this.EndLocation);
			this.IsLeftCollision = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraLeftSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera");
			if (!this.IsLeftCollision)
			{
				Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraLeftSphereTrace, this.EndLocation);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraLeftSphereTrace, this.StartLocation);
				this.IsLeftCollision = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraLeftSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera");
			}
		}

		// Token: 0x06045CC1 RID: 285889 RVA: 0x012447CC File Offset: 0x012429CC
		private void UpdateBlendState(Vector armLocation, Vector cameraLocation)
		{
			if (!this.IsOpenBlend)
			{
				this.CurrentBlendState = (this.IsMiddleCollision ? ECollisionBlendState.Loop : ECollisionBlendState.None);
				return;
			}
			if (this.SpecialUpdateBlend())
			{
				return;
			}
			switch (this.CurrentBlendState)
			{
			case ECollisionBlendState.None:
				if (this.IsMiddleCollision && (this.IsLeftCollision || this.IsRightCollision))
				{
					armLocation.Subtraction(this.Camera.CameraLocation, this.CurrentArmVector);
					armLocation.Subtraction(this.CameraTargetLocation, this.TargetArmVector);
					this.CurrentArmLength = (float)this.CurrentArmVector.Size();
					this.TargetArmLength = (float)this.TargetArmVector.Size();
					this.CurrentBlendState = ECollisionBlendState.BlendIn;
					return;
				}
				break;
			case ECollisionBlendState.BlendIn:
				if (this.IsMiddleCollision && this.IsLeftCollision && this.IsRightCollision)
				{
					this.CurrentBlendState = ECollisionBlendState.Loop;
					return;
				}
				if (this.IsMiddleCollision && (this.IsLeftCollision || this.IsRightCollision))
				{
					armLocation.Subtraction(this.Camera.CameraLocation, this.CurrentArmVector);
					armLocation.Subtraction(this.CameraTargetLocation, this.TargetArmVector);
					this.CurrentArmLength = (float)this.CurrentArmVector.Size();
					this.TargetArmLength = (float)this.TargetArmVector.Size();
					if (this.IsResetCamera(armLocation, cameraLocation, this.CurrentArmLength))
					{
						this.ResetBlendData();
						return;
					}
					if (this.CurrentArmLength <= this.TargetArmLength)
					{
						this.CurrentBlendState = ECollisionBlendState.Loop;
						return;
					}
				}
				else
				{
					if (this.IsMiddleCollision)
					{
						this.CurrentBlendState = ECollisionBlendState.BlendIn;
						return;
					}
					this.CurrentBlendState = ECollisionBlendState.BlendOut;
					return;
				}
				break;
			case ECollisionBlendState.Loop:
				if (!this.IsMiddleCollision && !this.IsLeftCollision && !this.IsRightCollision)
				{
					armLocation.Subtraction(this.Camera.CameraLocation, this.CurrentArmVector);
					armLocation.Subtraction(cameraLocation, this.TargetArmVector);
					this.CurrentArmLength = (float)this.CurrentArmVector.Size();
					this.TargetArmLength = (float)this.TargetArmVector.Size();
					this.CurrentBlendState = ECollisionBlendState.BlendOut;
				}
				break;
			case ECollisionBlendState.BlendOut:
				if (this.IsMiddleCollision && (this.IsLeftCollision || this.IsRightCollision))
				{
					this.CurrentBlendState = ECollisionBlendState.BlendIn;
					return;
				}
				armLocation.Subtraction(this.Camera.CameraLocation, this.CurrentArmVector);
				armLocation.Subtraction(cameraLocation, this.TargetArmVector);
				this.CurrentArmLength = (float)this.CurrentArmVector.Size();
				this.TargetArmLength = (float)this.TargetArmVector.Size();
				if (this.IsResetCamera(armLocation, cameraLocation, this.CurrentArmLength))
				{
					this.ResetBlendData();
					return;
				}
				if (this.CurrentArmLength >= this.TargetArmLength || this.CurrentArmLength >= this.Camera.MaxArmLength)
				{
					this.CurrentBlendState = ECollisionBlendState.None;
					return;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06045CC2 RID: 285890 RVA: 0x01244A78 File Offset: 0x01242C78
		private void UpdateBlendLocation(Vector armLocation, Vector cameraLocation, float deltaTime)
		{
			if (this.IsCameraFloatOnWater)
			{
				return;
			}
			switch (this.CurrentBlendState)
			{
			case ECollisionBlendState.None:
				this.CameraTargetLocation.DeepCopy(cameraLocation);
				break;
			case ECollisionBlendState.BlendIn:
			{
				float num = this.CurrentArmLength - this.Camera.InSpeed * deltaTime;
				num = Math.Max(this.TargetArmLength, num);
				cameraLocation.Subtraction(armLocation, this.ArmDirection);
				this.ArmDirection.Normalize(9.99999993922529E-09);
				this.ArmDirection.Multiply((double)num, this.NewArmVector);
				armLocation.Addition(this.NewArmVector, this.CameraTargetLocation);
				return;
			}
			case ECollisionBlendState.Loop:
				break;
			case ECollisionBlendState.BlendOut:
			{
				float num2 = this.CurrentArmLength + this.Camera.OutSpeed * deltaTime;
				num2 = Math.Min(this.TargetArmLength, num2);
				num2 = Math.Min(this.Camera.MaxArmLength, num2);
				cameraLocation.Subtraction(armLocation, this.ArmDirection);
				this.ArmDirection.Normalize(9.99999993922529E-09);
				this.ArmDirection.Multiply((double)num2, this.NewArmVector);
				armLocation.Addition(this.NewArmVector, this.CameraTargetLocation);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06045CC3 RID: 285891 RVA: 0x01244BA4 File Offset: 0x01242DA4
		private void CheckInPlaceCollision(Vector cameraLocation)
		{
			this.IsInPlaceCollision = false;
			UKuroHitResult hitResult = this.CameraInPlaceSphereTrace.HitResult;
			if (hitResult != null)
			{
				hitResult.Clear();
			}
			this.CameraInPlaceSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraInPlaceSphereTrace.Radius = this.Camera.CurrentCollisionSize;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraInPlaceSphereTrace, cameraLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraInPlaceSphereTrace, cameraLocation);
			this.IsInPlaceCollision = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraInPlaceSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera_InPlace");
		}

		// Token: 0x06045CC4 RID: 285892 RVA: 0x01244C34 File Offset: 0x01242E34
		private void UpdateInPlaceBlendState(Vector armLocation, Vector cameraLocation)
		{
			if (this.IsInPlaceCollision && this.IsMiddleCollision)
			{
				this.CurrentBlendState = ECollisionBlendState.Loop;
				return;
			}
			ECollisionBlendState currentBlendState = this.CurrentBlendState;
			if (currentBlendState != ECollisionBlendState.None && currentBlendState - ECollisionBlendState.BlendIn <= 2)
			{
				armLocation.Subtraction(this.Camera.CameraLocation, this.CurrentArmVector);
				armLocation.Subtraction(cameraLocation, this.TargetArmVector);
				this.CurrentArmLength = (float)this.CurrentArmVector.Size();
				this.TargetArmLength = (float)this.TargetArmVector.Size();
				if (this.CurrentBlendState == ECollisionBlendState.BlendOut && (this.CurrentArmLength >= this.TargetArmLength || this.CurrentArmLength >= this.Camera.MaxArmLength))
				{
					this.CurrentBlendState = ECollisionBlendState.None;
					return;
				}
				this.CurrentBlendState = ECollisionBlendState.BlendOut;
			}
		}

		// Token: 0x06045CC5 RID: 285893 RVA: 0x01244CF4 File Offset: 0x01242EF4
		private void SetDitherGroupEffect(ABaseCharacter actor, float ditherValue)
		{
			Entity entityNoBlueprint = actor.GetEntityNoBlueprint();
			long? num;
			if (entityNoBlueprint == null)
			{
				num = null;
			}
			else
			{
				CreatureDataComponent creatureDataComponent = entityNoBlueprint.CheckGetComponent<CreatureDataComponent>();
				num = ((creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
			}
			long? num2 = num;
			if (num2 != null)
			{
				long valueOrDefault = num2.GetValueOrDefault();
				if (valueOrDefault != 0L)
				{
					IReadOnlyList<long> set = this.Camera.CameraModel.DitherEntityGroups.GetSet(valueOrDefault);
					if (set == null || set.Count == 0)
					{
						return;
					}
					foreach (long creatureDataId in set)
					{
						EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
						if (entity != null && entity.Valid)
						{
							WorldEntity entity2 = entity.Entity;
							if (entity2 != null && entity2.Valid)
							{
								BaseActorComponent baseActorComponent = entity.Entity.CheckGetComponent<BaseActorComponent>();
								ABaseCharacter abaseCharacter = ((baseActorComponent != null) ? baseActorComponent.Owner : null) as ABaseCharacter;
								if (abaseCharacter != null && CameraCollision.IsCharacterRenderingType(abaseCharacter))
								{
									abaseCharacter.SetDitherEffect(ditherValue, ECharacterDitherType.Fight);
								}
							}
						}
					}
					return;
				}
			}
		}

		// Token: 0x06045CC6 RID: 285894 RVA: 0x01244E18 File Offset: 0x01243018
		private void UpdateNpcDither()
		{
			if (!this.IsCameraNpcDitherEnable() || !this.GmNpcDitherEnable)
			{
				if (this.DitheredNpcSet.Count > 0)
				{
					foreach (ABaseCharacter abaseCharacter in this.DitheredNpcSet)
					{
						if (abaseCharacter.IsValid())
						{
							this.SetDitherEffect(abaseCharacter, 1f, ECameraDitherType.CameraDither);
						}
					}
					this.DitheredNpcSet.Clear();
				}
				return;
			}
			this.UpdateCameraCollisionRadius();
			this.UpdateCameraCollisionLocation();
			UKuroHitResult hitResult = this.CameraNpcSphereTrace.HitResult;
			if (hitResult != null)
			{
				hitResult.Clear();
			}
			this.CameraNpcSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraNpcSphereTrace.Radius = this.CameraCollisionRadius;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraNpcSphereTrace, this.CameraTargetLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraNpcSphereTrace, this.CameraCollisionLocation);
			bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraNpcSphereTrace, "FightCameraLogicComponent_CheckCollision_Npc");
			int hitCount = this.CameraNpcSphereTrace.HitResult.GetHitCount();
			if (flag)
			{
				this.UpdateDitheredNpcDistance(this.CameraNpcSphereTrace.HitResult);
				foreach (KeyValuePair<ABaseCharacter, float> keyValuePair in this.DitheredNpcDistanceMap)
				{
					ABaseCharacter key = keyValuePair.Key;
					float value = keyValuePair.Value;
					if (this.IsCharacterIgnoreNpcDither(key))
					{
						this.SetDitherEffect(key, 1f, ECameraDitherType.CameraDither);
					}
					else
					{
						float npcDitherValue = this.GetNpcDitherValue(key, value);
						this.SetDitherEffect(key, npcDitherValue, ECameraDitherType.CameraDither);
						int num = this.DitheredNpcSet.IndexOf(key);
						if (num != -1)
						{
							this.DitheredNpcSet.RemoveAt(num);
						}
						this.DitheredNpcSet.Add(key);
					}
				}
			}
			for (int i = 0; i < this.DitheredNpcSet.Count - hitCount; i++)
			{
				ABaseCharacter actor = this.DitheredNpcSet[0];
				if (CameraCollision.IsCharacterRenderingType(actor))
				{
					this.SetDitherEffect(actor, 1f, ECameraDitherType.CameraDither);
				}
				this.DitheredNpcSet.RemoveAt(0);
			}
		}

		// Token: 0x06045CC7 RID: 285895 RVA: 0x01245050 File Offset: 0x01243250
		private void UpdatePlayerXRayState(bool needXRay)
		{
			if (!this.IsPlayerXRayEnable)
			{
				TsBaseCharacter character = this.Character;
				if (character == null)
				{
					return;
				}
				CharacterActorComponent characterActorComponent = character.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					return;
				}
				characterActorComponent.SetActorXRayState(false);
				return;
			}
			else
			{
				TsBaseCharacter character2 = this.Character;
				if (character2 == null)
				{
					return;
				}
				CharacterActorComponent characterActorComponent2 = character2.CharacterActorComponent;
				if (characterActorComponent2 == null)
				{
					return;
				}
				characterActorComponent2.SetActorXRayState(needXRay);
				return;
			}
		}

		// Token: 0x06045CC8 RID: 285896 RVA: 0x0124509C File Offset: 0x0124329C
		public void ResetAllNpcDither()
		{
			foreach (ABaseCharacter abaseCharacter in this.DitheredNpcSet)
			{
				if (abaseCharacter.IsValid())
				{
					this.SetDitherEffect(abaseCharacter, 1f, ECameraDitherType.CameraDither);
				}
			}
			this.DitheredNpcSet.Clear();
		}

		// Token: 0x06045CC9 RID: 285897 RVA: 0x01245108 File Offset: 0x01243308
		private unsafe void SetCollisionSize()
		{
			if (this.Camera.NearCollisionProbeSize <= this.Camera.CollisionProbeSize)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "CollisionSize数据错误:NearCollisionProbeSize <= this.CollisionProbeSize";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CollisionProbeSize", this.Camera.CollisionProbeSize);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NearCollisionProbeSize", this.Camera.NearCollisionProbeSize);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.CurrentCollisionDifferenceSize = this.Camera.NearCollisionProbeSize - this.Camera.CollisionProbeSize;
			float num = Singleton<MathUtils>.Instance.Clamp(this.Camera.CameraInputController.InputSpeedPercentage / this.Camera.CollisionSizePercentage, 0f, 1f);
			this.Camera.CurrentCollisionSize = this.CurrentCollisionDifferenceSize * num + this.Camera.CollisionProbeSize;
			this.Camera.CurrentCollisionSize = Singleton<MathUtils>.Instance.Clamp(this.Camera.CurrentCollisionSize, this.Camera.CurrentCollisionSize, this.Camera.NearCollisionProbeSize);
			if (this.CurrentBlendState != ECollisionBlendState.None)
			{
				this.Camera.CurrentCollisionSize = this.Camera.NearCollisionProbeSize;
			}
		}

		// Token: 0x06045CCA RID: 285898 RVA: 0x01245260 File Offset: 0x01243460
		private Vector ModifyLocation(Vector inLocation, Vector direction, float length)
		{
			direction.Multiply((double)length, this.TmpVector);
			inLocation.Addition(this.TmpVector, this.TmpVector);
			return this.TmpVector;
		}

		// Token: 0x06045CCB RID: 285899 RVA: 0x0124528C File Offset: 0x0124348C
		private bool SpecialUpdateBlend()
		{
			if (this.Camera.CameraDialogueController.State != EBlendState.None)
			{
				this.CurrentBlendState = (this.IsMiddleCollision ? ECollisionBlendState.Loop : ECollisionBlendState.None);
				return true;
			}
			if (ModelBase<GameModeModel>.Instance.IsSilentLogin)
			{
				this.CurrentBlendState = ECollisionBlendState.None;
				return true;
			}
			if (this.BlendPauseType == ECameraBlendPauseType.Forever)
			{
				this.CurrentBlendState = (this.IsMiddleCollision ? ECollisionBlendState.Loop : ECollisionBlendState.None);
				return true;
			}
			if (this.BlendPauseType == ECameraBlendPauseType.ForOneFrame)
			{
				this.BlendPauseType = ECameraBlendPauseType.None;
				this.CurrentBlendState = (this.IsMiddleCollision ? ECollisionBlendState.Loop : ECollisionBlendState.None);
				return true;
			}
			return false;
		}

		// Token: 0x06045CCC RID: 285900 RVA: 0x01245318 File Offset: 0x01243518
		private bool IsResetCamera(Vector armLocation, Vector cameraLocation, float currentDistance)
		{
			double num = armLocation.Subtraction(cameraLocation, this.TmpVector).SizeSquared();
			return (double)(currentDistance * currentDistance) > num;
		}

		// Token: 0x06045CCD RID: 285901 RVA: 0x01245340 File Offset: 0x01243540
		private bool IsCharacterIgnoreNpcDither(ABaseCharacter character)
		{
			Entity entityNoBlueprint = character.GetEntityNoBlueprint();
			if (entityNoBlueprint == null || !entityNoBlueprint.Valid)
			{
				return false;
			}
			BaseTagComponent component = entityNoBlueprint.GetComponent<BaseTagComponent>();
			if (component != null && component.HasAnyTag(CameraCollision.IgnoreNpcDitherTagList))
			{
				return true;
			}
			NpcPerformComponent component2 = entityNoBlueprint.GetComponent<NpcPerformComponent>();
			return component2 != null && component2.IsNpcIgnoreCameraHide;
		}

		// Token: 0x06045CCE RID: 285902 RVA: 0x01245394 File Offset: 0x01243594
		private void UpdateCameraCollisionRadius()
		{
			if (Singleton<MathUtils>.Instance.IsNearlyZero((double)this.Camera.CameraModel.CameraDitherStartHideDistance, new double?(0.0001)))
			{
				return;
			}
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CurrentCameraDitherStartHideDistance, (double)this.Camera.CameraModel.CameraDitherStartHideDistance, null) && Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CurrentCameraDitherFov, (double)this.Camera.Fov, null))
			{
				return;
			}
			this.CurrentCameraDitherStartHideDistance = this.Camera.CameraModel.CameraDitherStartHideDistance;
			this.CurrentCameraDitherFov = this.Camera.Fov;
			float currentCameraDitherStartHideDistance = this.CurrentCameraDitherStartHideDistance;
			float aspectRatio = this.Camera.CameraActor.CameraComponent.AspectRatio;
			double c = Math.Sin(Singleton<MathUtils>.Instance.VerticalFovToHorizontally((double)this.Camera.Fov, (double)aspectRatio) / 2.0 * 0.01745329238474369) * (double)currentCameraDitherStartHideDistance * 2.0;
			this.CameraCollisionRadius = (float)Singleton<MathUtils>.Instance.GetTriangleCircumradius((double)currentCameraDitherStartHideDistance, (double)currentCameraDitherStartHideDistance, c);
		}

		// Token: 0x06045CCF RID: 285903 RVA: 0x012454BC File Offset: 0x012436BC
		private void UpdateCameraCollisionLocation()
		{
			this.Camera.CameraForward.Normalize(9.99999993922529E-09);
			this.Camera.CameraForward.Multiply((double)this.CameraCollisionRadius, this.TmpVector);
			this.CameraTargetLocation.Addition(this.TmpVector, this.CameraCollisionLocation);
		}

		// Token: 0x06045CD0 RID: 285904 RVA: 0x0124551C File Offset: 0x0124371C
		private void UpdateDitheredNpcDistance(UKuroHitResult hitResult)
		{
			int hitCount = hitResult.GetHitCount();
			this.DitheredNpcDistanceMap.Clear();
			for (int i = 0; i < hitCount; i++)
			{
				ABaseCharacter abaseCharacter = hitResult.Actors.Get(i).Get() as ABaseCharacter;
				if (CameraCollision.IsCharacterRenderingType(abaseCharacter))
				{
					Entity entityNoBlueprint = abaseCharacter.GetEntityNoBlueprint();
					CreatureDataComponent creatureDataComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CreatureDataComponent>() : null;
					SModelConfig smodelConfig = (creatureDataComponent != null) ? creatureDataComponent.GetModelConfig() : null;
					if (smodelConfig == null || !smodelConfig.主角蓝透)
					{
						if (abaseCharacter.CapsuleComponent != null && abaseCharacter.CapsuleComponent.GetCollisionObjectType() == KuroCollisionChannel.Vehicle)
						{
							Entity entityNoBlueprint2 = abaseCharacter.GetEntityNoBlueprint();
							if (entityNoBlueprint2 == null || entityNoBlueprint2.GetComponent<MotorcycleActorComponent>() == null || ModelBase<VehicleModel>.Instance.MaterialControllerHandles.Count > 0)
							{
								this.DitheredNpcSet.Remove(abaseCharacter);
								goto IL_114;
							}
						}
						Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.TmpVector);
						float valueOrDefault = this.DitheredNpcDistanceMap.GetValueOrDefault(abaseCharacter, 9999999f);
						double num = Vector.Dist(this.TmpVector, this.CameraTargetLocation);
						if (num < (double)valueOrDefault)
						{
							this.DitheredNpcDistanceMap[abaseCharacter] = (float)num;
						}
					}
				}
				IL_114:;
			}
		}

		// Token: 0x06045CD1 RID: 285905 RVA: 0x01245648 File Offset: 0x01243848
		private float GetNpcDitherValue(ABaseCharacter actor, float distance)
		{
			if (!actor.IsValid() || actor.CapsuleComponent == null)
			{
				return 1f;
			}
			float completeHideDistance = this.Camera.CompleteHideDistance;
			float startHideDistance = this.Camera.StartHideDistance;
			float startDitherValue = this.Camera.StartDitherValue;
			if ((ECollisionChannel)actor.CapsuleComponent.GetCollisionObjectType() == KuroCollisionChannel.PawnMonster)
			{
				Entity entityNoBlueprint = (actor as TsBaseCharacter).GetEntityNoBlueprint();
				CharacterActorComponent characterActorComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterActorComponent>() : null;
				if (characterActorComponent != null)
				{
					completeHideDistance = characterActorComponent.CompleteHideDistance;
					startHideDistance = characterActorComponent.StartHideDistance;
					startDitherValue = characterActorComponent.StartDitherValue;
				}
			}
			else if ((ECollisionChannel)actor.CapsuleComponent.GetCollisionObjectType() == KuroCollisionChannel.Vehicle)
			{
				Entity entityNoBlueprint2 = (actor as TsBaseVehicle).GetEntityNoBlueprint();
				VehicleActorComponent vehicleActorComponent = (entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<VehicleActorComponent>() : null;
				if (vehicleActorComponent != null && vehicleActorComponent.StartHideDistance > 0f)
				{
					completeHideDistance = vehicleActorComponent.CompleteHideDistance;
					startHideDistance = vehicleActorComponent.StartHideDistance;
					startDitherValue = vehicleActorComponent.StartDitherValue;
				}
			}
			return Singleton<MathUtils>.Instance.RangeClamp(distance, completeHideDistance, startHideDistance, 0.01f, startDitherValue);
		}

		// Token: 0x06045CD2 RID: 285906 RVA: 0x01245748 File Offset: 0x01243948
		private int GetValidHitIndex(Vector startLocation, Vector endLocation, UKuroHitResult hitResult)
		{
			if (startLocation.Z > endLocation.Z)
			{
				return 0;
			}
			int result = -1;
			float num = 9999999f;
			int hitCount = hitResult.GetHitCount();
			for (int i = 0; i < hitCount; i++)
			{
				UKuroHitResult hitResult2 = this.CameraSphereTrace.HitResult;
				TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr;
				if (hitResult2 == null)
				{
					tweakObjectPtr = null;
				}
				else
				{
					TArray<TWeakObjectPtr<UPrimitiveComponent>> components = hitResult2.Components;
					tweakObjectPtr = ((components != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components.Get(i)) : null);
				}
				TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr2 = tweakObjectPtr;
				if (tweakObjectPtr2 == null || tweakObjectPtr2.Value.Get().IsValid())
				{
					UKuroHitResult hitResult3 = this.CameraSphereTrace.HitResult;
					TArray<int> tarray = (hitResult3 != null) ? hitResult3.ItemArray : null;
					int instanceIndex = (tarray != null && i < tarray.Num()) ? tarray.Get(i) : 0;
					Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.TmpVector);
					float num2 = (float)Vector.DistSquared(this.TmpVector, startLocation);
					TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr3 = tweakObjectPtr2;
					if ((!(UKuroCollisionLibrary.GetCollisionResponseToChannel((tweakObjectPtr3 != null) ? tweakObjectPtr3.GetValueOrDefault() : null, KuroCollisionChannel.Water, instanceIndex) == ECollisionResponse.ECR_Block) || num2 > this.CameraCollisionProbeSizeSquared) && num2 < num)
					{
						num = num2;
						result = i;
					}
				}
			}
			return result;
		}

		// Token: 0x06045CD3 RID: 285907 RVA: 0x01245888 File Offset: 0x01243A88
		private bool IsPlayerBlueStateEnable(UKuroHitResult hitResult)
		{
			int hitCount = hitResult.GetHitCount();
			for (int i = 0; i < hitCount; i++)
			{
				ABaseCharacter abaseCharacter = hitResult.Actors.Get(i).Get() as ABaseCharacter;
				if (CameraCollision.IsCharacterRenderingType(abaseCharacter))
				{
					Entity entityNoBlueprint = abaseCharacter.GetEntityNoBlueprint();
					CreatureDataComponent creatureDataComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CreatureDataComponent>() : null;
					SModelConfig smodelConfig = (creatureDataComponent != null) ? creatureDataComponent.GetModelConfig() : null;
					if (smodelConfig != null && smodelConfig.主角蓝透)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06045CD4 RID: 285908 RVA: 0x012458FC File Offset: 0x01243AFC
		public bool TraceCheckPlayerLocation(Vector beginLocation, Vector endLocation, Vector outLocation)
		{
			this.CameraSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraSphereTrace.Radius = this.Camera.CurrentCollisionSize;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraSphereTrace, beginLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraSphereTrace, endLocation);
			if (Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraSphereTrace, "FightCameraLogicComponent_CheckCollision_Camera_Caught_PlayerLocation"))
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(this.CameraSphereTrace.HitResult, 0, outLocation);
				return true;
			}
			return false;
		}

		// Token: 0x06045CD5 RID: 285909 RVA: 0x01245982 File Offset: 0x01243B82
		public void SetCameraBlendPauseType(ECameraBlendPauseType pauseType)
		{
			this.BlendPauseType = pauseType;
		}

		// Token: 0x06045CD6 RID: 285910 RVA: 0x0124598C File Offset: 0x01243B8C
		[NullableContext(2)]
		public static bool IsCharacterRenderingType(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				return false;
			}
			TsBaseCharacter tsBaseCharacter = actor as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(tsBaseCharacter.GetEntityIdNoBlueprint());
				return handle != null && handle.Valid;
			}
			TsBaseVehicle tsBaseVehicle = actor as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle(tsBaseVehicle.GetEntityIdNoBlueprint());
				return handle2 != null && handle2.Valid;
			}
			return false;
		}

		// Token: 0x06045CD7 RID: 285911 RVA: 0x012459F9 File Offset: 0x01243BF9
		public void LockCameraCollision(ECameraCollisionLockType lockType)
		{
			this.CameraCollisionLockingHandler.Lock(lockType);
		}

		// Token: 0x06045CD8 RID: 285912 RVA: 0x01245A07 File Offset: 0x01243C07
		public void UnlockCameraCollision(ECameraCollisionLockType lockType)
		{
			this.CameraCollisionLockingHandler.Unlock(lockType);
		}

		// Token: 0x06045CD9 RID: 285913 RVA: 0x01245A15 File Offset: 0x01243C15
		public bool IsCameraCollisionEnable()
		{
			return this.CameraCollisionLockingHandler.IsUnlocked();
		}

		// Token: 0x06045CDA RID: 285914 RVA: 0x01245A22 File Offset: 0x01243C22
		public void LockCameraNpcDither(ENpcDitherLockType lockType)
		{
			this.NpcDitherLockingHandler.Lock(lockType);
		}

		// Token: 0x06045CDB RID: 285915 RVA: 0x01245A30 File Offset: 0x01243C30
		public void UnlockCameraNpcDither(ENpcDitherLockType lockType)
		{
			this.NpcDitherLockingHandler.Unlock(lockType);
		}

		// Token: 0x06045CDC RID: 285916 RVA: 0x01245A3E File Offset: 0x01243C3E
		public bool IsCameraNpcDitherEnable()
		{
			return this.NpcDitherLockingHandler.IsUnlocked();
		}

		// Token: 0x06045CDD RID: 285917 RVA: 0x01245A4B File Offset: 0x01243C4B
		public bool GetIsMiddleCollision()
		{
			return this.IsMiddleCollision;
		}

		// Token: 0x06045CDE RID: 285918 RVA: 0x01245A53 File Offset: 0x01243C53
		public bool CheckIsOcclusionDitherActiveActor(ABaseCharacter actor)
		{
			Entity entityNoBlueprint = actor.GetEntityNoBlueprint();
			object obj;
			if (entityNoBlueprint == null)
			{
				obj = null;
			}
			else
			{
				CharacterActorComponent component = entityNoBlueprint.GetComponent<CharacterActorComponent>();
				obj = ((component != null) ? component.OcclusionDitherConfig : null);
			}
			object obj2 = obj;
			return obj2 != null && obj2.IsEnableOcclusionDither;
		}

		// Token: 0x06045CDF RID: 285919 RVA: 0x01245A80 File Offset: 0x01243C80
		public bool CheckOcclusionDitherActive(ABaseCharacter actor)
		{
			if (!this.IsActiveOcclusionDither)
			{
				return false;
			}
			Entity entityNoBlueprint = actor.GetEntityNoBlueprint();
			if (entityNoBlueprint == null || !entityNoBlueprint.Valid)
			{
				return false;
			}
			CharacterActorComponent component = entityNoBlueprint.GetComponent<CharacterActorComponent>();
			OcclusionDitherConfig occlusionDitherConfig = (component != null) ? component.OcclusionDitherConfig : null;
			FGameplayTag? fgameplayTag = (occlusionDitherConfig != null) ? occlusionDitherConfig.IgnoreOcclusionDitherTag : null;
			if (fgameplayTag != null)
			{
				FGameplayTag valueOrDefault = fgameplayTag.GetValueOrDefault();
				BaseTagComponent component2 = entityNoBlueprint.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.HasTag(valueOrDefault.TagId()))
				{
					return false;
				}
			}
			return occlusionDitherConfig != null && occlusionDitherConfig.IsEnableOcclusionDither;
		}

		// Token: 0x06045CE0 RID: 285920 RVA: 0x01245B0C File Offset: 0x01243D0C
		public void CalculateAllOcclusionDitherValue(float deltaTime)
		{
			foreach (KeyValuePair<ABaseCharacter, OcclusionDitherData> keyValuePair in this.OcclusionDitherDataMap)
			{
				OcclusionDitherData value = keyValuePair.Value;
				if (value != null)
				{
					float currentValue = value.CurrentValue;
					float targetOcclusionDitherValue = value.TargetOcclusionDitherValue;
					float targetCameraDitherValue = value.TargetCameraDitherValue;
					float interpSpeed = value.InterpSpeed;
					value.CurrentValue = Singleton<MathUtils>.Instance.Lerp(currentValue, Math.Min(targetOcclusionDitherValue, targetCameraDitherValue), interpSpeed * deltaTime);
				}
			}
		}

		// Token: 0x06045CE1 RID: 285921 RVA: 0x01245BA0 File Offset: 0x01243DA0
		public float GetActorInterpSpeed(ABaseCharacter actor)
		{
			Entity entityNoBlueprint = actor.GetEntityNoBlueprint();
			float? num;
			if (entityNoBlueprint == null)
			{
				num = null;
			}
			else
			{
				CharacterActorComponent component = entityNoBlueprint.GetComponent<CharacterActorComponent>();
				if (component == null)
				{
					num = null;
				}
				else
				{
					OcclusionDitherConfig occlusionDitherConfig = component.OcclusionDitherConfig;
					num = ((occlusionDitherConfig != null) ? new float?(occlusionDitherConfig.OcclusionDitherInterpSpeed) : null);
				}
			}
			float? num2 = num;
			return num2.GetValueOrDefault(1f);
		}

		// Token: 0x06045CE2 RID: 285922 RVA: 0x01245C04 File Offset: 0x01243E04
		public void ResetAllOcclusionDither()
		{
			foreach (ABaseCharacter key in this.LastFrameActiveDitherActors)
			{
				OcclusionDitherData occlusionDitherData;
				if (this.OcclusionDitherDataMap.TryGetValue(key, out occlusionDitherData))
				{
					occlusionDitherData.TargetCameraDitherValue = 1f;
					occlusionDitherData.TargetOcclusionDitherValue = 1f;
				}
			}
			this.LastFrameActiveDitherActors.Clear();
			this.WaitRemoveActorList.Clear();
		}

		// Token: 0x06045CE3 RID: 285923 RVA: 0x01245C8C File Offset: 0x01243E8C
		public void SetOcclusionDitherTargetValue(ABaseCharacter actor, float targetOcclusionDitherValue)
		{
			OcclusionDitherData occlusionDitherData;
			if (!this.OcclusionDitherDataMap.TryGetValue(actor, out occlusionDitherData))
			{
				occlusionDitherData = new OcclusionDitherData
				{
					CurrentValue = 1f,
					TargetCameraDitherValue = 1f,
					TargetOcclusionDitherValue = 1f,
					InterpSpeed = this.GetActorInterpSpeed(actor)
				};
				this.OcclusionDitherDataMap[actor] = occlusionDitherData;
			}
			occlusionDitherData.TargetOcclusionDitherValue = targetOcclusionDitherValue;
			this.LastFrameActiveDitherActors.Add(actor);
		}

		// Token: 0x06045CE4 RID: 285924 RVA: 0x01245D00 File Offset: 0x01243F00
		public void SetCameraDitherTargetValue(ABaseCharacter actor, float targetCameraDitherValue)
		{
			OcclusionDitherData occlusionDitherData;
			if (!this.OcclusionDitherDataMap.TryGetValue(actor, out occlusionDitherData))
			{
				occlusionDitherData = new OcclusionDitherData
				{
					CurrentValue = 1f,
					TargetCameraDitherValue = 1f,
					TargetOcclusionDitherValue = 1f,
					InterpSpeed = this.GetActorInterpSpeed(actor)
				};
				this.OcclusionDitherDataMap[actor] = occlusionDitherData;
			}
			occlusionDitherData.TargetCameraDitherValue = targetCameraDitherValue;
			this.LastFrameActiveDitherActors.Add(actor);
		}

		// Token: 0x06045CE5 RID: 285925 RVA: 0x01245D74 File Offset: 0x01243F74
		private void UpdateOcclusionDither()
		{
			if (!this.IsActiveOcclusionDither)
			{
				return;
			}
			UKuroHitResult hitResult = this.CameraPlayerSphereTrace.HitResult;
			int hitCount = hitResult.GetHitCount();
			for (int i = 0; i < hitCount; i++)
			{
				TWeakObjectPtr<AActor> tweakObjectPtr = hitResult.Actors.Get(i);
				AActor aactor = tweakObjectPtr.Get();
				if (aactor != null && aactor.IsValid())
				{
					UPrimitiveComponent uprimitiveComponent = hitResult.Components.Get(i).Get();
					if ((uprimitiveComponent == null || !uprimitiveComponent.ComponentHasTag(CameraCollision.TagIgnoreOcclusionDither)) && CameraCollision.IsCharacterRenderingType(tweakObjectPtr.Get()))
					{
						ABaseCharacter abaseCharacter = tweakObjectPtr.Get() as ABaseCharacter;
						if (abaseCharacter != null && this.CheckOcclusionDitherActive(abaseCharacter))
						{
							Entity entityNoBlueprint = abaseCharacter.GetEntityNoBlueprint();
							OcclusionDitherConfig occlusionDitherConfig;
							if (entityNoBlueprint == null)
							{
								occlusionDitherConfig = null;
							}
							else
							{
								CharacterActorComponent component = entityNoBlueprint.GetComponent<CharacterActorComponent>();
								occlusionDitherConfig = ((component != null) ? component.OcclusionDitherConfig : null);
							}
							OcclusionDitherConfig occlusionDitherConfig2 = occlusionDitherConfig;
							this.SetOcclusionDitherTargetValue(abaseCharacter, (occlusionDitherConfig2 != null) ? occlusionDitherConfig2.OcclusionDitherValue : 1f);
						}
					}
				}
			}
		}

		// Token: 0x06045CE6 RID: 285926 RVA: 0x01245E64 File Offset: 0x01244064
		private void SetAllDitherValue()
		{
			foreach (KeyValuePair<ABaseCharacter, OcclusionDitherData> keyValuePair in this.OcclusionDitherDataMap)
			{
				ABaseCharacter key = keyValuePair.Key;
				OcclusionDitherData value = keyValuePair.Value;
				if (CameraCollision.IsCharacterRenderingType(key))
				{
					float currentValue = value.CurrentValue;
					if (value.TargetCameraDitherValue >= 1f && value.TargetOcclusionDitherValue >= 1f && Singleton<MathUtils>.Instance.IsNearlyEqual((double)currentValue, 1.0, new double?(0.0001)))
					{
						key.SetDitherEffect(1f, ECharacterDitherType.Fight);
						this.SetDitherGroupEffect(key, 1f);
						this.WaitRemoveActorList.Add(key);
					}
					else
					{
						key.SetDitherEffect(currentValue, ECharacterDitherType.Fight);
						this.SetDitherGroupEffect(key, currentValue);
					}
				}
				else
				{
					this.WaitRemoveActorList.Add(key);
				}
			}
			foreach (ABaseCharacter key2 in this.WaitRemoveActorList)
			{
				this.OcclusionDitherDataMap.Remove(key2);
			}
		}

		// Token: 0x06045CE7 RID: 285927 RVA: 0x01245FAC File Offset: 0x012441AC
		private void SetDitherEffect(ABaseCharacter actor, float ditherValue, ECameraDitherType ditherType)
		{
			if (this.CheckIsOcclusionDitherActiveActor(actor))
			{
				if (ditherType == ECameraDitherType.OcclusionDither)
				{
					this.SetOcclusionDitherTargetValue(actor, ditherValue);
					return;
				}
				if (ditherType == ECameraDitherType.CameraDither)
				{
					this.SetCameraDitherTargetValue(actor, ditherValue);
					return;
				}
			}
			else
			{
				actor.SetDitherEffect(ditherValue, ECharacterDitherType.Fight);
				this.SetDitherGroupEffect(actor, ditherValue);
			}
		}

		// Token: 0x06045CE8 RID: 285928 RVA: 0x01245FE0 File Offset: 0x012441E0
		private void TraceElementBetweenCameraAndPlayer(Vector armLocation)
		{
			if (!this.IsPlayerXRayEnable && !this.IsActiveOcclusionDither)
			{
				return;
			}
			UKuroHitResult hitResult = this.CameraPlayerSphereTrace.HitResult;
			if (hitResult != null)
			{
				hitResult.Clear();
			}
			this.CameraPlayerSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraPlayerSphereTrace.Radius = 20f;
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraPlayerSphereTrace, this.CameraTargetLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraPlayerSphereTrace, armLocation);
			this.IsHitSomethingBetweenCameraAndPlayer = Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraPlayerSphereTrace, "FightCameraLogicComponent_CheckCollision_Player");
		}

		// Token: 0x06045CE9 RID: 285929 RVA: 0x01246076 File Offset: 0x01244276
		public void SetCameraCollisionMode(ECameraCollisionMode mode)
		{
			if (this.CollisionMode == mode)
			{
				return;
			}
			this.CollisionMode = mode;
			this.ResetBlendData();
		}

		// Token: 0x04027100 RID: 160000
		public const float MinDither = 0.01f;

		// Token: 0x04027101 RID: 160001
		public const int MaxValue = 9999999;

		// Token: 0x04027102 RID: 160002
		public const int ProbeRatio = 4;

		// Token: 0x04027103 RID: 160003
		public const int PlayerCollisionRadius = 20;

		// Token: 0x04027104 RID: 160004
		public const string ProfileKey1 = "FightCameraLogicComponent_CheckCollision_Camera";

		// Token: 0x04027105 RID: 160005
		public const string ProfileKey2 = "FightCameraLogicComponent_CheckCollision_Npc";

		// Token: 0x04027106 RID: 160006
		public const string ProfileKey3 = "FightCameraLogicComponent_CheckCollision_Camera_Caught_PlayerLocation";

		// Token: 0x04027107 RID: 160007
		public const string ProfileKey4 = "FightCameraLogicComponent_CheckCollision_Player";

		// Token: 0x04027108 RID: 160008
		public const string ProfileKey5 = "FightCameraLogicComponent_CheckCollision_Camera_InPlace";

		// Token: 0x04027109 RID: 160009
		public static readonly FName TagIgnoreOcclusionDither = new FName("Ignore_Occlusion_Dither");

		// Token: 0x0402710A RID: 160010
		[StaticVariableRuleIgnore]
		private static readonly int[] IgnoreNpcDitherTagList = new int[]
		{
			GameplayTagDefine.EGameplayTagId["功能.通用镜头.忽略碰撞隐藏"],
			GameplayTagDefine.EGameplayTagId["载具.摩托.第一人称"]
		};

		// Token: 0x0402710B RID: 160011
		[Nullable(2)]
		private FightCameraLogicComponent Camera;

		// Token: 0x0402710C RID: 160012
		[Nullable(2)]
		private TsBaseCharacter Character;

		// Token: 0x0402710D RID: 160013
		[Nullable(2)]
		private CharacterSwimComponent CharSwimComp;

		// Token: 0x0402710E RID: 160014
		[Nullable(2)]
		private UTraceSphereElement CameraSphereTrace;

		// Token: 0x0402710F RID: 160015
		[Nullable(2)]
		private UTraceSphereElement CameraLeftSphereTrace;

		// Token: 0x04027110 RID: 160016
		[Nullable(2)]
		private UTraceSphereElement CameraRightSphereTrace;

		// Token: 0x04027111 RID: 160017
		[Nullable(2)]
		private UTraceSphereElement CameraNpcSphereTrace;

		// Token: 0x04027112 RID: 160018
		[Nullable(2)]
		private UTraceSphereElement CameraPlayerSphereTrace;

		// Token: 0x04027113 RID: 160019
		[Nullable(2)]
		private UTraceSphereElement CameraInPlaceSphereTrace;

		// Token: 0x04027114 RID: 160020
		private bool IsHitSomethingBetweenCameraAndPlayer;

		// Token: 0x04027115 RID: 160021
		private readonly Vector GravityDirect = Vector.Create();

		// Token: 0x04027116 RID: 160022
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x04027117 RID: 160023
		private readonly Vector EndLocation = Vector.Create();

		// Token: 0x04027118 RID: 160024
		private readonly Vector ArmDirection = Vector.Create();

		// Token: 0x04027119 RID: 160025
		private readonly Vector OffsetVector = Vector.Create();

		// Token: 0x0402711A RID: 160026
		private readonly Vector CameraTargetLocation = Vector.Create();

		// Token: 0x0402711B RID: 160027
		private readonly Vector CameraCollisionLocation = Vector.Create();

		// Token: 0x0402711C RID: 160028
		private readonly Vector CurrentArmVector = Vector.Create();

		// Token: 0x0402711D RID: 160029
		private readonly Vector TargetArmVector = Vector.Create();

		// Token: 0x0402711E RID: 160030
		private readonly Vector NewArmVector = Vector.Create();

		// Token: 0x0402711F RID: 160031
		private readonly Vector TmpVector = Vector.Create();

		// Token: 0x04027120 RID: 160032
		private float CurrentArmLength;

		// Token: 0x04027121 RID: 160033
		private float TargetArmLength;

		// Token: 0x04027122 RID: 160034
		private int MiddleCollisionHitIndex;

		// Token: 0x04027123 RID: 160035
		private bool IsMiddleCollision;

		// Token: 0x04027124 RID: 160036
		private bool IsInPlaceCollision;

		// Token: 0x04027125 RID: 160037
		private bool IsCameraFloatOnWater;

		// Token: 0x04027126 RID: 160038
		public bool IsLeftCollision;

		// Token: 0x04027127 RID: 160039
		public bool IsRightCollision;

		// Token: 0x04027128 RID: 160040
		public bool IsOpenBlend = true;

		// Token: 0x04027129 RID: 160041
		public ECameraCollisionMode CollisionMode;

		// Token: 0x0402712A RID: 160042
		private ECameraBlendPauseType BlendPauseType;

		// Token: 0x0402712B RID: 160043
		public ECollisionBlendState CurrentBlendState;

		// Token: 0x0402712C RID: 160044
		private float CurrentCollisionDifferenceSize;

		// Token: 0x0402712D RID: 160045
		private float CameraCollisionRadius;

		// Token: 0x0402712E RID: 160046
		private float CurrentCameraDitherStartHideDistance;

		// Token: 0x0402712F RID: 160047
		private float CurrentCameraDitherFov;

		// Token: 0x04027130 RID: 160048
		private float CameraCollisionProbeSizeSquared;

		// Token: 0x04027131 RID: 160049
		private float CameraMinFloorZnOffset;

		// Token: 0x04027132 RID: 160050
		private readonly UniqueLockingHandler<ECameraCollisionLockType> CameraCollisionLockingHandler = new UniqueLockingHandler<ECameraCollisionLockType>();

		// Token: 0x04027133 RID: 160051
		private readonly UniqueLockingHandler<ENpcDitherLockType> NpcDitherLockingHandler = new UniqueLockingHandler<ENpcDitherLockType>();

		// Token: 0x04027134 RID: 160052
		public bool IsPlayerXRayEnable = true;

		// Token: 0x04027135 RID: 160053
		private readonly List<ABaseCharacter> DitheredNpcSet = new List<ABaseCharacter>();

		// Token: 0x04027136 RID: 160054
		private readonly Dictionary<ABaseCharacter, float> DitheredNpcDistanceMap = new Dictionary<ABaseCharacter, float>();

		// Token: 0x04027137 RID: 160055
		public bool GmCameraCollisionEnable = true;

		// Token: 0x04027138 RID: 160056
		public bool GmNpcDitherEnable = true;

		// Token: 0x04027139 RID: 160057
		public bool IsActiveOcclusionDither = true;

		// Token: 0x0402713A RID: 160058
		private readonly Dictionary<ABaseCharacter, OcclusionDitherData> OcclusionDitherDataMap = new Dictionary<ABaseCharacter, OcclusionDitherData>();

		// Token: 0x0402713B RID: 160059
		private readonly List<ABaseCharacter> WaitRemoveActorList = new List<ABaseCharacter>();

		// Token: 0x0402713C RID: 160060
		private readonly HashSet<ABaseCharacter> LastFrameActiveDitherActors = new HashSet<ABaseCharacter>();
	}
}
