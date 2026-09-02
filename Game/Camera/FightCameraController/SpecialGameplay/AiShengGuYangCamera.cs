using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.AI.AIMoveSplineCount;
using UnrealEngine;

namespace CSharpScript.Game.Camera.FightCameraController.SpecialGameplay
{
	// Token: 0x020070C3 RID: 28867
	[NullableContext(1)]
	[Nullable(0)]
	public class AiShengGuYangCamera : ISpecialGameplayCamera
	{
		// Token: 0x1700A5DE RID: 42462
		// (get) Token: 0x06045FD5 RID: 286677 RVA: 0x0125BD82 File Offset: 0x01259F82
		[Nullable(2)]
		private UCameraComponent Camera
		{
			[NullableContext(2)]
			get
			{
				ACameraActor cameraActor = this.CameraActor;
				if (cameraActor == null || !cameraActor.IsValid())
				{
					return null;
				}
				return this.CameraActor.CameraComponent;
			}
		}

		// Token: 0x06045FD6 RID: 286678 RVA: 0x0125BDA5 File Offset: 0x01259FA5
		public void OnInit(ACameraActor camera, CameraModelInstance cameraModel)
		{
			this.CameraActor = camera;
			this.OnInitInternal();
		}

		// Token: 0x06045FD7 RID: 286679 RVA: 0x0125BDB4 File Offset: 0x01259FB4
		public void Update(float deltaTime)
		{
			TsBaseCharacter flyActor = this.FlyActor;
			if (flyActor == null || !flyActor.IsValid())
			{
				this.OnInitInternal();
			}
			TsBaseCharacter flyActor2 = this.FlyActor;
			if (flyActor2 != null && flyActor2.IsValid())
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null && tagComp.Valid)
				{
					BaseMoveComponent moveComp = this.MoveComp;
					if (moveComp != null && moveComp.Valid)
					{
						CharacterInputComponent inputComp = this.InputComp;
						if (inputComp != null && inputComp.Valid)
						{
							USplineComponent moveSplineComp = this.MoveSplineComp;
							if (moveSplineComp != null && moveSplineComp.IsValid())
							{
								TsGameSplineActor flySplineActor = this.FlySplineActor;
								if (flySplineActor != null && flySplineActor.IsValid())
								{
									CommonEffectMoveSpline2_C cameraMoveSplineActor = this.CameraMoveSplineActor;
									if (cameraMoveSplineActor != null && cameraMoveSplineActor.IsValid())
									{
										UKuroMoveSplineComponent cameraMoveSpline = this.CameraMoveSpline;
										if (cameraMoveSpline != null && cameraMoveSpline.IsValid())
										{
											ACameraActor cameraActor = this.CameraActor;
											if (cameraActor != null && cameraActor.IsValid())
											{
												UCameraComponent camera = this.Camera;
												if (camera != null && camera.IsValid())
												{
													this.IsSprint = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["怪物.AiShengGuYuan.追击玩法.冲刺"]);
													this.InputComp.GetMoveVector(this.InputValue);
													this.MaxInputOffset.Set(1200.0, 1200.0, 0.0);
													if (this.IsSprint)
													{
														this.Camera.SetFieldOfView(120f);
														this.SplineSpeed = 4500f;
														this.CameraMoveSpeed = ((this.CameraDistance >= 2300f) ? (this.SplineSpeed * 1.05f) : (this.SplineSpeed * 0.3f));
													}
													else
													{
														this.SplineSpeed = 2500f;
														this.CameraMoveSpeed = ((this.CameraDistance >= 2300f) ? (this.SplineSpeed * 1.05f) : (this.SplineSpeed * 0.3f));
														this.Camera.SetFieldOfView(105f);
													}
													if (Singleton<MathUtils>.Instance.IsNearlyEqual(Math.Abs(this.InputOffset.X), this.MaxInputOffset.X, new double?(0.0001)))
													{
														if ((this.InputOffset.X > 0.0 && this.InputValue.X <= -0.5) || (this.InputOffset.X < 0.0 && this.InputValue.X >= 0.5))
														{
															double num = (this.InputOffset.X > 0.0) ? (this.InputOffset.X - 70.0) : (this.InputOffset.X + 70.0);
															if (Math.Abs(num) < this.MaxInputOffset.X)
															{
																this.InputOffset.X = Singleton<MathUtils>.Instance.InterpTo(this.InputOffset.X, num, (double)deltaTime, 10.0);
															}
														}
													}
													else if (Math.Abs(this.InputOffset.X) < this.MaxInputOffset.X)
													{
														double num2 = (this.InputValue.X >= 0.5) ? (this.InputOffset.X + 70.0) : (this.InputOffset.X - 70.0);
														if ((this.InputValue.X >= 0.5 || this.InputValue.X <= -0.5) && Math.Abs(num2) < this.MaxInputOffset.X)
														{
															this.InputOffset.X = Singleton<MathUtils>.Instance.InterpTo(this.InputOffset.X, num2, (double)deltaTime, 10.0);
														}
													}
													else
													{
														this.InputOffset.X = ((this.InputOffset.X > 0.0) ? this.MaxInputOffset.X : (-this.MaxInputOffset.X));
													}
													if (Singleton<MathUtils>.Instance.IsNearlyEqual(Math.Abs(this.InputOffset.Y), this.MaxInputOffset.Y, new double?(0.0001)))
													{
														if ((this.InputOffset.Y > 0.0 && this.InputValue.Y <= -0.5) || (this.InputOffset.Y < 0.0 && this.InputValue.Y >= 0.5))
														{
															double num3 = (this.InputOffset.Y > 0.0) ? (this.InputOffset.Y - 70.0) : (this.InputOffset.Y + 70.0);
															if (Math.Abs(num3) < this.MaxInputOffset.Y)
															{
																this.InputOffset.Y = (double)((float)Singleton<MathUtils>.Instance.InterpTo(this.InputOffset.Y, num3, (double)deltaTime, 10.0));
															}
														}
													}
													else if (Math.Abs(this.InputOffset.Y) < this.MaxInputOffset.Y)
													{
														double num4 = (this.InputValue.Y >= 0.5) ? (this.InputOffset.Y + 70.0) : (this.InputOffset.Y - 70.0);
														if ((this.InputValue.Y >= 0.5 || this.InputValue.Y <= -0.5) && Math.Abs(num4) < this.MaxInputOffset.Y)
														{
															this.InputOffset.Y = (double)((float)Singleton<MathUtils>.Instance.InterpTo(this.InputOffset.Y, num4, (double)deltaTime, 10.0));
														}
													}
													else
													{
														this.InputOffset.Y = ((this.InputOffset.Y > 0.0) ? this.MaxInputOffset.Y : (-this.MaxInputOffset.Y));
													}
													FVectorDouble fvectorDouble;
													FVector fvector;
													if (this.First)
													{
														Vector moveSplineLocation = this.MoveSplineLocation;
														fvectorDouble = this.MoveSplineComp.D_GetLocationAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.World);
														moveSplineLocation.FromUeVector(fvectorDouble);
														Vector moveSplineForwardVector = this.MoveSplineForwardVector;
														fvector = this.MoveSplineComp.GetDirectionAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.Local);
														moveSplineForwardVector.FromUeVector(fvector);
														this.MoveSplineForwardVector.Multiply(200.0, this.MoveTowardOffset);
														this.MoveTowardOffset.AdditionEqual(this.MoveSplineLocation);
														this.First = false;
														Vector tempVector = this.TempVector1;
														fvectorDouble = this.FlyActor.D_K2_GetActorLocation();
														tempVector.FromUeVector(fvectorDouble);
														Vector tempVector2 = this.TempVector2;
														fvector = this.FlyActor.GetActorForwardVector();
														tempVector2.FromUeVector(fvector);
														this.TempVector2.MultiplyEqual(-1300.0);
														this.TempVector1.AdditionEqual(this.TempVector2);
														Vector tempVector3 = this.TempVector2;
														fvector = this.FlyActor.GetActorUpVector();
														tempVector3.FromUeVector(fvector);
														this.TempVector2.MultiplyEqual(250.0);
														this.TempVector1.AdditionEqual(this.TempVector2);
														this.CameraActor.D_K2_SetActorLocationAndRotation(this.TempVector1.ToUeVector(false), this.FlyActor.K2_GetActorRotation(), false, ref WorldGlobal.SweepHitResult, false);
														Vector tempVector4 = this.TempVector1;
														fvectorDouble = this.FlyActor.D_K2_GetActorLocation();
														tempVector4.FromUeVector(fvectorDouble);
														Vector tempVector5 = this.TempVector2;
														fvector = this.FlyActor.GetActorForwardVector();
														tempVector5.FromUeVector(fvector);
														this.TempVector2.MultiplyEqual(-1100.0);
														this.TempVector1.AdditionEqual(this.TempVector2);
														Vector tempVector6 = this.TempVector2;
														fvector = this.FlyActor.GetActorUpVector();
														tempVector6.FromUeVector(fvector);
														this.TempVector2.MultiplyEqual(150.0);
														this.TempVector1.AdditionEqual(this.TempVector2);
														this.CameraMoveSplineActor.D_K2_SetActorLocationAndRotation(this.TempVector1.ToUeVector(false), this.FlyActor.K2_GetActorRotation(), false, ref WorldGlobal.SweepHitResult, false);
													}
													this.SplineTempDistance = this.SplineDistance + this.SplineSpeed * deltaTime;
													Vector moveSplineLocation2 = this.MoveSplineLocation;
													fvectorDouble = this.MoveSplineComp.D_GetLocationAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.World);
													moveSplineLocation2.FromUeVector(fvectorDouble);
													Vector moveSplineUpVector = this.MoveSplineUpVector;
													fvector = this.MoveSplineComp.GetUpVectorAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.Local);
													moveSplineUpVector.FromUeVector(fvector);
													Vector moveSplineRightVector = this.MoveSplineRightVector;
													fvector = this.MoveSplineComp.GetRightVectorAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.Local);
													moveSplineRightVector.FromUeVector(fvector);
													Vector moveSplineForwardVector2 = this.MoveSplineForwardVector;
													fvector = this.MoveSplineComp.GetDirectionAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.Local);
													moveSplineForwardVector2.FromUeVector(fvector);
													this.MoveSplineForwardVector.Multiply(200.0, this.MoveTowardOffset);
													this.MoveTowardOffset.AdditionEqual(this.MoveSplineLocation);
													this.MoveSplineUpVector.Multiply(this.InputOffset.X, this.TempVector1);
													this.MoveSplineRightVector.Multiply(this.InputOffset.Y, this.TempVector2);
													this.TempVector1.Addition(this.TempVector2, this.JoystickOffsetLocationX);
													Vector tempVector7 = this.TempVector1;
													fvectorDouble = this.FlyActor.D_K2_GetActorLocation();
													tempVector7.FromUeVector(fvectorDouble);
													Vector tempVector8 = this.TempVector2;
													fvectorDouble = this.CameraActor.D_K2_GetActorLocation();
													tempVector8.FromUeVector(fvectorDouble);
													this.CameraDistance = (float)Vector.Dist(this.TempVector1, this.TempVector2);
													this.MoveTowardOffset.Addition(this.JoystickOffsetLocationX, this.TempVector2);
													this.JoystickPursueDistance = Vector.Dist(this.TempVector1, this.TempVector2);
													this.MoveSplineUpVector.Multiply(Singleton<MathUtils>.Instance.RangeClamp(this.InputOffset.X, -1200.0, 1200.0, -600.0, 600.0), this.TempVector1);
													this.MoveSplineRightVector.Multiply(Singleton<MathUtils>.Instance.RangeClamp(this.InputOffset.Y, -1200.0, 1200.0, -600.0, 600.0), this.TempVector2);
													this.TempVector1.AdditionEqual(this.TempVector2);
													Vector tempVector9 = this.TempVector2;
													fvectorDouble = this.MoveSplineComp.D_GetLocationAtDistanceAlongSpline(this.SplineTempDistance + 2000f, ESplineCoordinateSpace.World);
													tempVector9.FromUeVector(fvectorDouble);
													this.TempVector1.Addition(this.TempVector2, this.CameraAimPointLocation);
													if (this.SplineTempDistance >= this.CurrentLimitPointDistance)
													{
														this.CurrentInputSplineIndex++;
														this.CurrentLimitPointDistance = this.MoveSplineComp.GetDistanceAlongSplineAtSplinePoint(this.CurrentInputSplineIndex);
													}
													if (!this.IsSprint)
													{
														double num5 = (this.JoystickPursueType == 1) ? 100.0 : 200.0;
														double num6 = (this.JoystickPursueType == 3) ? 300.0 : 400.0;
														if (this.JoystickPursueDistance < num5)
														{
															this.JoystickPursueType = 1;
														}
														else if (this.JoystickPursueDistance < num6)
														{
															this.JoystickPursueType = 2;
														}
														else
														{
															this.JoystickPursueType = 3;
														}
														switch (this.CameraPursueType)
														{
														case 0:
															if (this.CameraDistance <= 1000f)
															{
																this.CameraPursueType = 1;
																this.CameraMoveSpeed = this.SplineSpeed * 0.85f;
															}
															else if (this.CameraDistance < 1500f)
															{
																this.CameraPursueType = 2;
																this.CameraMoveSpeed = this.SplineSpeed - 10f;
															}
															else
															{
																this.CameraPursueType = 3;
																this.CameraMoveSpeed = this.SplineSpeed * 1.1f;
															}
															break;
														case 1:
															if (this.CameraDistance >= 1100f)
															{
																this.CameraPursueType = 2;
																this.CameraMoveSpeed = this.SplineSpeed - 100f;
															}
															break;
														case 2:
															if (this.CameraDistance <= 900f)
															{
																this.CameraPursueType = 1;
																this.CameraMoveSpeed = this.SplineSpeed * 0.85f;
															}
															else if (this.CameraDistance >= 1500f)
															{
																this.CameraPursueType = 3;
																this.CameraMoveSpeed = this.SplineSpeed * 1.2f;
															}
															break;
														case 3:
															if (this.CameraDistance <= 1300f)
															{
																this.CameraPursueType = 2;
																this.CameraMoveSpeed = this.SplineSpeed - 1f;
															}
															break;
														}
													}
													if (Singleton<MathUtils>.Instance.IsNearlyZero(this.InputValue.Y, null))
													{
														if (this.IsPlayerOperation && Singleton<Time>.Instance.Now - this.LastPlayerOperationTime > 1000.0)
														{
															this.IsPlayerOperation = false;
														}
														else
														{
															Vector tempVector10 = this.TempVector1;
															fvector = this.FlyActor.GetActorForwardVector();
															tempVector10.FromUeVector(fvector);
															this.TempVector1.Z = 0.0;
															this.TempVector1.Normalize(9.999999747378752E-05);
															Vector tempVector11 = this.TempVector2;
															fvector = this.MoveSplineComp.GetDirectionAtDistanceAlongSpline(this.SplineTempDistance + 1000f, ESplineCoordinateSpace.Local);
															tempVector11.FromUeVector(fvector);
															this.TempVector2.Z = 0.0;
															this.TempVector2.Normalize(9.999999747378752E-05);
															double num7 = Math.Acos(Singleton<MathUtils>.Instance.Clamp(this.TempVector1.DotProduct(this.TempVector2), -1.0, 1.0)) * 57.295780181884766;
															num7 = Singleton<MathUtils>.Instance.Clamp(num7, -25.0, 25.0);
															this.PlayerCameraAngle = (float)(this.AtOriginLeft(Vector.ZeroVectorProxy, this.TempVector2, this.TempVector1) ? (-(float)num7) : num7);
															double to = (double)Singleton<MathUtils>.Instance.RangeClamp(this.PlayerCameraAngle, -25f, 25f, 0f, 790f);
															this.OperateCameraOffsetDistance = (float)Singleton<MathUtils>.Instance.InterpTo((double)this.OperateCameraOffsetDistance, to, (double)deltaTime, 5.0);
														}
													}
													else
													{
														Vector tempVector12 = this.TempVector1;
														fvectorDouble = this.CameraActor.D_K2_GetActorLocation();
														tempVector12.FromUeVector(fvectorDouble);
														Vector tempVector13 = this.TempVector2;
														fvectorDouble = this.FlyActor.D_K2_GetActorLocation();
														tempVector13.FromUeVector(fvectorDouble);
														this.TempVector2.SubtractionEqual(this.TempVector1);
														this.TempVector2.Normalize(9.999999747378752E-05);
														this.TempVector2.Z = 0.0;
														this.TempVector2.Normalize(9.999999747378752E-05);
														this.CameraAimPointLocation.Subtraction(this.TempVector1, this.TempVector3);
														this.TempVector3.Normalize(9.999999747378752E-05);
														this.TempVector3.Z = 0.0;
														this.TempVector3.Normalize(9.999999747378752E-05);
														double num8 = Math.Acos(Singleton<MathUtils>.Instance.Clamp(this.TempVector2.DotProduct(this.TempVector3), -1.0, 1.0)) * 57.295780181884766;
														num8 = Singleton<MathUtils>.Instance.Clamp(num8, -25.0, 25.0);
														this.PlayerCameraAngle = (float)(this.AtOriginLeft(Vector.ZeroVectorProxy, this.TempVector2, this.TempVector3) ? (-(float)num8) : num8);
														this.IsPlayerOperation = true;
														this.LastPlayerOperationTime = Singleton<Time>.Instance.Now;
														double to2 = (double)Singleton<MathUtils>.Instance.RangeClamp(this.PlayerCameraAngle, -25f, 25f, 0f, 790f);
														this.OperateCameraOffsetDistance = (float)Singleton<MathUtils>.Instance.InterpTo((double)this.OperateCameraOffsetDistance, to2, (double)deltaTime, 3.0);
													}
													Vector tempVector14 = this.TempVector1;
													fvectorDouble = this.FlyActor.D_K2_GetActorLocation();
													tempVector14.FromUeVector(fvectorDouble);
													Vector tempVector15 = this.TempVector2;
													fvector = this.FlyActor.GetActorForwardVector();
													tempVector15.FromUeVector(fvector);
													this.TempVector2.MultiplyEqual(-1100.0);
													this.TempVector1.AdditionEqual(this.TempVector2);
													Vector tempVector16 = this.TempVector2;
													fvector = this.FlyActor.GetActorUpVector();
													tempVector16.FromUeVector(fvector);
													this.TempVector2.MultiplyEqual(250.0);
													this.TempVector1.AdditionEqual(this.TempVector2);
													Vector tempVector17 = this.TempVector2;
													fvectorDouble = this.CameraMoveSplineActor.D_K2_GetActorLocation();
													tempVector17.FromUeVector(fvectorDouble);
													Singleton<MathUtils>.Instance.VectorInterpTo(this.TempVector2, this.TempVector1, (double)deltaTime, (double)this.CameraMoveSpeed, this.TempVector3);
													Rotator tempRotator = this.TempRotator1;
													FRotator frotator = this.CameraMoveSplineActor.K2_GetActorRotation();
													tempRotator.FromUeRotator(frotator);
													Rotator tempRotator2 = this.TempRotator2;
													fvectorDouble = this.CameraMoveSplineActor.D_K2_GetActorLocation();
													FVectorDouble fvectorDouble2 = this.CameraAimPointLocation.ToUeVector(false);
													frotator = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble2);
													tempRotator2.FromUeRotator(frotator);
													Singleton<MathUtils>.Instance.RotatorInterpConstantTo(this.TempRotator1, this.TempRotator2, deltaTime, 60f, this.TempRotator3);
													this.CameraMoveSplineActor.D_K2_SetActorLocationAndRotation(this.TempVector3.ToUeVector(false), this.TempRotator3.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
													Rotator tempRotator3 = this.TempRotator1;
													frotator = this.CameraActor.K2_GetActorRotation();
													tempRotator3.FromUeRotator(frotator);
													Singleton<MathUtils>.Instance.RotatorInterpConstantTo(this.TempRotator1, this.TempRotator2, deltaTime, 60f, this.TempRotator3);
													this.CameraInterpDistanceY = (float)Singleton<MathUtils>.Instance.InterpTo((double)this.CameraInterpDistanceY, (double)this.OperateCameraOffsetDistance, (double)deltaTime, 6.0);
													this.CameraActor.D_K2_SetActorLocationAndRotation(this.CameraMoveSpline.D_GetLocationAtDistanceAlongSpline(this.CameraInterpDistanceY, ESplineCoordinateSpace.World), this.TempRotator3.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
													this.TempRotator1.Set(0f, 0f, this.MoveSplineComp.GetRollAtDistanceAlongSpline(this.SplineTempDistance, ESplineCoordinateSpace.Local) * 0.9f);
													this.Camera.K2_SetRelativeRotation(this.TempRotator1.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
													this.SplineDistance = this.SplineTempDistance;
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06045FD8 RID: 286680 RVA: 0x0125D064 File Offset: 0x0125B264
		public void OnDestroy()
		{
			if (this.FlySplineActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("AiShengGuYangCamera.OnDestroy1", this.FlySplineActor, null);
				this.MoveSplineComp = null;
				this.FlySplineActor = null;
			}
			if (this.CameraMoveSplineActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("AiShengGuYangCamera.OnDestroy2", this.CameraMoveSplineActor, null);
				this.CameraMoveSpline = null;
				this.CameraMoveSplineActor = null;
			}
			this.CameraActor = null;
			this.FlyActor = null;
			this.TagComp = null;
			this.MoveComp = null;
			this.InputComp = null;
		}

		// Token: 0x06045FD9 RID: 286681 RVA: 0x0125D0F0 File Offset: 0x0125B2F0
		private void OnInitInternal()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			WorldEntity entity = getCurrentEntity.Entity;
			TsBaseCharacter tsBaseCharacter;
			if (entity == null)
			{
				tsBaseCharacter = null;
			}
			else
			{
				CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
				tsBaseCharacter = ((component != null) ? component.Actor : null);
			}
			TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
			if (tsBaseCharacter2 == null)
			{
				return;
			}
			this.FlyActor = tsBaseCharacter2;
			tsBaseCharacter2.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Flying,
				CustomMode = 0,
				Context = "[AiShengGuYangCamera.OnInitInternal]"
			});
			WorldEntity entity2 = getCurrentEntity.Entity;
			this.MoveComp = ((entity2 != null) ? entity2.GetComponent<BaseMoveComponent>() : null);
			BaseMoveComponent moveComp = this.MoveComp;
			if (moveComp != null && moveComp.Valid)
			{
				this.MoveComp.CanMoveFromInput = false;
			}
			WorldEntity entity3 = getCurrentEntity.Entity;
			this.TagComp = ((entity3 != null) ? entity3.GetComponent<BaseTagComponent>() : null);
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null || !tagComp.Valid)
			{
				return;
			}
			WorldEntity entity4 = getCurrentEntity.Entity;
			this.InputComp = ((entity4 != null) ? entity4.GetComponent<CharacterInputComponent>() : null);
			CharacterInputComponent inputComp = this.InputComp;
			if (inputComp == null || !inputComp.Valid)
			{
				return;
			}
			this.TempTransform.Set(Vector.ZeroVectorProxy, Quat.Create(0f, 0f, 0f, 1f), Vector.OneVectorProxy);
			CommonEffectMoveSpline2_C cameraMoveSplineActor = this.CameraMoveSplineActor;
			if (cameraMoveSplineActor == null || !cameraMoveSplineActor.IsValid())
			{
				this.CameraMoveSplineActor = (Singleton<ActorSystem>.Instance.Get(CommonEffectMoveSpline2_C.StaticClass(), this.TempTransform.ToUeTransform(), null, true) as CommonEffectMoveSpline2_C);
				CommonEffectMoveSpline2_C cameraMoveSplineActor2 = this.CameraMoveSplineActor;
				this.CameraMoveSpline = ((cameraMoveSplineActor2 != null) ? cameraMoveSplineActor2.KuroMoveSpline : null);
			}
			TsGameSplineActor flySplineActor = this.FlySplineActor;
			if (flySplineActor == null || !flySplineActor.IsValid())
			{
				this.FlySplineActor = (Singleton<ActorSystem>.Instance.Get(TsGameSplineActor.StaticClass(), this.TempTransform.ToUeTransform(), null, true) as TsGameSplineActor);
			}
			USplineComponent moveSplineComp = this.MoveSplineComp;
			if (moveSplineComp == null || !moveSplineComp.IsValid())
			{
				TsGameSplineActor flySplineActor2 = this.FlySplineActor;
				if (flySplineActor2 != null && flySplineActor2.IsValid())
				{
					this.MoveSplineComp = GameSplineUtils.InitGameSplineBySplineEntity(118003752, this.FlySplineActor);
				}
			}
		}

		// Token: 0x06045FDA RID: 286682 RVA: 0x0125D304 File Offset: 0x0125B504
		private bool AtOriginLeft(Vector origin, Vector target, Vector originDirection)
		{
			FVectorDouble fvectorDouble = origin.ToUeVector(false);
			FVectorDouble fvectorDouble2 = originDirection.ToUeVector(false);
			Vector vector = Vector.Create(UKismetMathLibrary.GetRightVector(UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble2)));
			Vector vector2 = Vector.Create();
			target.Subtraction(origin, vector2);
			vector2.Normalize(9.99999993922529E-09);
			return Math.Acos(Singleton<MathUtils>.Instance.Clamp(vector.DotProduct(vector2), -1.0, 1.0)) * 57.295780181884766 > 90.0;
		}

		// Token: 0x040273B4 RID: 160692
		[Nullable(2)]
		private ACameraActor CameraActor;

		// Token: 0x040273B5 RID: 160693
		[Nullable(2)]
		private TsBaseCharacter FlyActor;

		// Token: 0x040273B6 RID: 160694
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x040273B7 RID: 160695
		[Nullable(2)]
		private BaseMoveComponent MoveComp;

		// Token: 0x040273B8 RID: 160696
		[Nullable(2)]
		private CharacterInputComponent InputComp;

		// Token: 0x040273B9 RID: 160697
		[Nullable(2)]
		private TsGameSplineActor FlySplineActor;

		// Token: 0x040273BA RID: 160698
		[Nullable(2)]
		private USplineComponent MoveSplineComp;

		// Token: 0x040273BB RID: 160699
		[Nullable(2)]
		private CommonEffectMoveSpline2_C CameraMoveSplineActor;

		// Token: 0x040273BC RID: 160700
		[Nullable(2)]
		private UKuroMoveSplineComponent CameraMoveSpline;

		// Token: 0x040273BD RID: 160701
		private float SplineDistance;

		// Token: 0x040273BE RID: 160702
		private readonly Vector InputValue = Vector.Create();

		// Token: 0x040273BF RID: 160703
		private readonly Vector InputOffset = Vector.Create();

		// Token: 0x040273C0 RID: 160704
		private readonly Vector MaxInputOffset = Vector.Create();

		// Token: 0x040273C1 RID: 160705
		private int CurrentInputSplineIndex = 1;

		// Token: 0x040273C2 RID: 160706
		private bool IsSprint;

		// Token: 0x040273C3 RID: 160707
		private float SplineSpeed;

		// Token: 0x040273C4 RID: 160708
		private float CameraDistance;

		// Token: 0x040273C5 RID: 160709
		private float CameraMoveSpeed;

		// Token: 0x040273C6 RID: 160710
		private readonly Vector MoveSplineLocation = Vector.Create();

		// Token: 0x040273C7 RID: 160711
		private readonly Vector MoveSplineUpVector = Vector.Create();

		// Token: 0x040273C8 RID: 160712
		private readonly Vector MoveSplineRightVector = Vector.Create();

		// Token: 0x040273C9 RID: 160713
		private readonly Vector MoveSplineForwardVector = Vector.Create();

		// Token: 0x040273CA RID: 160714
		private readonly Vector MoveTowardOffset = Vector.Create();

		// Token: 0x040273CB RID: 160715
		private float SplineTempDistance;

		// Token: 0x040273CC RID: 160716
		private readonly Vector JoystickOffsetLocationX = Vector.Create();

		// Token: 0x040273CD RID: 160717
		private double JoystickPursueDistance;

		// Token: 0x040273CE RID: 160718
		private readonly Vector CameraAimPointLocation = Vector.Create();

		// Token: 0x040273CF RID: 160719
		private int JoystickPursueType;

		// Token: 0x040273D0 RID: 160720
		private int CameraPursueType;

		// Token: 0x040273D1 RID: 160721
		private bool IsPlayerOperation = true;

		// Token: 0x040273D2 RID: 160722
		private double LastPlayerOperationTime;

		// Token: 0x040273D3 RID: 160723
		private float PlayerCameraAngle;

		// Token: 0x040273D4 RID: 160724
		private float OperateCameraOffsetDistance;

		// Token: 0x040273D5 RID: 160725
		private float CurrentLimitPointDistance;

		// Token: 0x040273D6 RID: 160726
		private float CameraInterpDistanceY;

		// Token: 0x040273D7 RID: 160727
		private bool First = true;

		// Token: 0x040273D8 RID: 160728
		private readonly Vector TempVector1 = Vector.Create();

		// Token: 0x040273D9 RID: 160729
		private readonly Vector TempVector2 = Vector.Create();

		// Token: 0x040273DA RID: 160730
		private readonly Vector TempVector3 = Vector.Create();

		// Token: 0x040273DB RID: 160731
		private readonly Rotator TempRotator1 = Rotator.Create();

		// Token: 0x040273DC RID: 160732
		private readonly Rotator TempRotator2 = Rotator.Create();

		// Token: 0x040273DD RID: 160733
		private readonly Rotator TempRotator3 = Rotator.Create();

		// Token: 0x040273DE RID: 160734
		private readonly Transform TempTransform = Transform.Create(Quat.Create(0f, 0f, 0f, 1f), Vector.ZeroVectorProxy, Vector.OneVectorProxy);
	}
}
