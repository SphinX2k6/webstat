using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.UI.Manager;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070BA RID: 28858
	[NullableContext(1)]
	[Nullable(0)]
	public class SettlementCamera
	{
		// Token: 0x06045F7A RID: 286586 RVA: 0x012580F5 File Offset: 0x012562F5
		public void Init(FightCameraLogicComponent camera)
		{
			this.Camera = camera;
			this.CameraSphereTrace = new UTraceSphereElement
			{
				bIsSingle = false,
				bTraceComplex = false,
				bIgnoreSelf = true
			};
		}

		// Token: 0x06045F7B RID: 286587 RVA: 0x01258120 File Offset: 0x01256320
		private void SetSettlementCamera(EDynamicSettlementType settlementConfigType)
		{
			SSettlementCamera dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<SSettlementCamera>(EDataTable.FightSettlementCamera, settlementConfigType.ToEnumString());
			if (dataTableRowFromName == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "无结算镜头配置数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SettlementCameraConfig = dataTableRowFromName;
			this.CameraModifier = dataTableRowFromName.CameraModifier;
			this.CameraModifierArmLength = this.CameraModifier.Settings.ArmLength;
			if (this.CameraModifierArmLength < 100f)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】臂长配置过小:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierArmLength);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(100);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierArmLength = 100f;
			}
			this.CameraModifierPitchMin = this.SettlementCameraConfig.MinRandomPitch;
			if (this.CameraModifierPitchMin > 90f || this.CameraModifierPitchMin < -90f)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 4);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】最小Pitch配置不正确:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierPitchMin);
				defaultInterpolatedStringHandler.AppendLiteral(",合理区间为(");
				defaultInterpolatedStringHandler.AppendFormatted<int>(-90);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<int>(90);
				defaultInterpolatedStringHandler.AppendLiteral("),将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(-5);
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierPitchMin = -5f;
			}
			this.CameraModifierPitchMax = this.SettlementCameraConfig.MaxRandomPitch;
			if (this.CameraModifierPitchMax > 90f || this.CameraModifierPitchMax < -90f)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Camera;
				ELogAuthor author3 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 4);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】最大Pitch配置不正确:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierPitchMax);
				defaultInterpolatedStringHandler.AppendLiteral(",合理区间为(");
				defaultInterpolatedStringHandler.AppendFormatted<int>(-90);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted<int>(90);
				defaultInterpolatedStringHandler.AppendLiteral("),将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(-8);
				instance3.Error(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierPitchMax = -8f;
			}
			this.CameraModifierTopAdditionZ = this.SettlementCameraConfig.TopAdditionZ;
			if (this.CameraModifierTopAdditionZ < 50f)
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.Camera;
				ELogAuthor author4 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】探测合法值上限叠加值过小:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierTopAdditionZ);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(50);
				instance4.Error(module4, author4, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierTopAdditionZ = 50f;
			}
			this.CameraModifierBottomAdditionZ = this.SettlementCameraConfig.BottomAdditionZ;
			if (this.CameraModifierBottomAdditionZ < 50f)
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.Camera;
				ELogAuthor author5 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】探测合法值下限叠加值过小:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierBottomAdditionZ);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(50);
				instance5.Error(module5, author5, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierBottomAdditionZ = 50f;
			}
			this.CameraModifierLeftYawRangeMin = this.SettlementCameraConfig.LeftMinYawRange;
			this.CameraModifierLeftYawRangeMax = this.SettlementCameraConfig.LeftMaxYawRange;
			if (this.CameraModifierLeftYawRangeMin < -180f)
			{
				global::Log instance6 = Singleton<global::Log>.Instance;
				ELogModule module6 = ELogModule.Camera;
				ELogAuthor author6 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】左侧Yaw区间合法值最小值过小:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierLeftYawRangeMin);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(-180);
				instance6.Error(module6, author6, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierLeftYawRangeMin = -180f;
			}
			if (this.CameraModifierLeftYawRangeMax > 0f)
			{
				global::Log instance7 = Singleton<global::Log>.Instance;
				ELogModule module7 = ELogModule.Camera;
				ELogAuthor author7 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】左侧Yaw区间合法值最大值过大:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierLeftYawRangeMax);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(0);
				instance7.Error(module7, author7, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierLeftYawRangeMax = 0f;
			}
			if (this.CameraModifierLeftYawRangeMax < this.CameraModifierLeftYawRangeMin)
			{
				global::Log instance8 = Singleton<global::Log>.Instance;
				ELogModule module8 = ELogModule.Camera;
				ELogAuthor author8 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 4);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】左侧Yaw区间合法值最小值大于最大值,最小值:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierLeftYawRangeMin);
				defaultInterpolatedStringHandler.AppendLiteral(",最大值:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierLeftYawRangeMax);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为,最小值:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(-180);
				defaultInterpolatedStringHandler.AppendLiteral(",最大值:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(0);
				instance8.Error(module8, author8, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierLeftYawRangeMin = -180f;
				this.CameraModifierLeftYawRangeMax = 0f;
			}
			this.CameraModifierRightYawRangeMin = this.SettlementCameraConfig.RightMinYawRange;
			this.CameraModifierRightYawRangeMax = this.SettlementCameraConfig.RightMaxYawRange;
			if (this.CameraModifierRightYawRangeMin < 0f)
			{
				global::Log instance9 = Singleton<global::Log>.Instance;
				ELogModule module9 = ELogModule.Camera;
				ELogAuthor author9 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】右侧Yaw区间合法值最小值过小:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierRightYawRangeMin);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(0);
				instance9.Error(module9, author9, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierRightYawRangeMin = 0f;
			}
			if (this.CameraModifierRightYawRangeMax > 180f)
			{
				global::Log instance10 = Singleton<global::Log>.Instance;
				ELogModule module10 = ELogModule.Camera;
				ELogAuthor author10 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】右侧Yaw区间合法值最大值过大:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierRightYawRangeMax);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(180);
				instance10.Error(module10, author10, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierRightYawRangeMax = 180f;
			}
			if (this.CameraModifierRightYawRangeMax < this.CameraModifierRightYawRangeMin)
			{
				global::Log instance11 = Singleton<global::Log>.Instance;
				ELogModule module11 = ELogModule.Camera;
				ELogAuthor author11 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 4);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】右侧Yaw区间合法值最小值大于最大值,最小值:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierRightYawRangeMin);
				defaultInterpolatedStringHandler.AppendLiteral(",最大值:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierRightYawRangeMax);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为,最小值:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(0);
				defaultInterpolatedStringHandler.AppendLiteral(",最大值:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(180);
				instance11.Error(module11, author11, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierRightYawRangeMin = 0f;
				this.CameraModifierRightYawRangeMax = 180f;
			}
			this.CameraModifierValidRangeMin = this.SettlementCameraConfig.MinValidYawRange;
			if (this.CameraModifierValidRangeMin < 0f)
			{
				global::Log instance12 = Singleton<global::Log>.Instance;
				ELogModule module12 = ELogModule.Camera;
				ELogAuthor author12 = ELogAuthor.LJM;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
				defaultInterpolatedStringHandler.AppendLiteral("【结算镜头】最小合法区间过小:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CameraModifierValidRangeMin);
				defaultInterpolatedStringHandler.AppendLiteral(",将自动修正为:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(0);
				instance12.Error(module12, author12, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifierValidRangeMin = 0f;
			}
			if (StringUtils.IsEmpty(this.CameraModifier.Settings.ModifySettingsAdditional.Name))
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Camera, ELogAuthor.LJM, "【结算镜头】没有配置CameraModifier名称，将自动修正为 SettlementCamera", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CameraModifier.Settings.ModifySettingsAdditional.Name = "SettlementCamera";
			}
			Vector cameraModifierCharacterOffset = this.CameraModifierCharacterOffset;
			FVector characterOffset = this.SettlementCameraConfig.CharacterOffset;
			FVectorDouble fvectorDouble = characterOffset;
			cameraModifierCharacterOffset.DeepCopy(fvectorDouble);
		}

		// Token: 0x06045F7C RID: 286588 RVA: 0x012588B4 File Offset: 0x01256AB4
		public void PlaySettlementCamera(EDynamicSettlementType settlementType)
		{
			if (ControllerBase<CameraController>.Instance.IsSequenceCameraInCinematic(this.Camera.CameraModel.CameraName))
			{
				return;
			}
			if (this.Camera.ContainsTag(SettlementCamera.BanSettlementCamera, false))
			{
				return;
			}
			this.SetSettlementCamera(settlementType);
			if (this.SettlementCameraConfig == null || this.CameraModifier == null)
			{
				return;
			}
			this.PlayerYaw = this.Camera.PlayerRotatorInGravity.Yaw;
			this.PlayerLocation = this.Camera.PlayerLocation;
			this.CameraSphereRadius = Math.Max(this.Camera.FinalCameraDistance, this.CameraModifierArmLength);
			this.CameraSphereTrace.bTraceComplex = false;
			UKuroHitResult hitResult = this.CameraSphereTrace.HitResult;
			if (hitResult != null)
			{
				hitResult.Clear();
			}
			this.CameraSphereTrace.WorldContextObject = GlobalData.World;
			this.CameraSphereTrace.Radius = this.CameraSphereRadius;
			this.CameraSphereTrace.ActorsToIgnore.Add(this.Camera.Character);
			this.CameraSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Camera);
			this.CameraSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
			this.CameraSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnMonster);
			this.CameraSphereTrace.AddObjectTypeQuery(KuroObjectTypeQuery.PawnPlayer);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.CameraSphereTrace, this.Camera.PlayerLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.CameraSphereTrace, this.Camera.PlayerLocation);
			Singleton<TraceElementCommon>.Instance.SphereTrace(this.CameraSphereTrace, "FightCameraLogicComponent_TraceValidRange_Camera");
			this.UpdateRotator(this.CameraSphereTrace.HitResult);
			this.PlaySettlementCameraInternal();
			BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
			if (bpEventManager.IsValid())
			{
				bpEventManager.当触发结算镜头时.Broadcast();
			}
		}

		// Token: 0x06045F7D RID: 286589 RVA: 0x01258A73 File Offset: 0x01256C73
		public void UpdateRotator(UKuroHitResult hitResult)
		{
			this.UpdateHitActorMap(hitResult);
			this.UpdateInvalidYawRangeArray(hitResult);
			this.UpdateValidYawRangeArray();
			this.UpdateFinalRotator();
		}

		// Token: 0x06045F7E RID: 286590 RVA: 0x01258A90 File Offset: 0x01256C90
		public void UpdateFinalRotator()
		{
			this.TmpYawRange.Clear();
			foreach (SettlementCamera.YawRange yawRange in this.LeftYawRangeArray)
			{
				if (yawRange.Max - yawRange.Min > this.CameraModifierValidRangeMin)
				{
					this.TmpYawRange.Add(yawRange);
				}
			}
			foreach (SettlementCamera.YawRange yawRange2 in this.RightYawRangeArray)
			{
				if (yawRange2.Max - yawRange2.Min > this.CameraModifierValidRangeMin)
				{
					this.TmpYawRange.Add(yawRange2);
				}
			}
			if (this.TmpYawRange.Count > 0)
			{
				SettlementCamera.YawRange randomArrayItem = ObjectUtils.GetRandomArrayItem<SettlementCamera.YawRange>(this.TmpYawRange);
				double num = (double)(Singleton<MathUtils>.Instance.Lerp(randomArrayItem.Min, randomArrayItem.Max, Singleton<MathUtils>.Instance.Random.NextSingle()) + this.PlayerYaw);
				this.FinalRotator.Pitch = Singleton<MathUtils>.Instance.Lerp(this.CameraModifierPitchMin, this.CameraModifierPitchMax, Singleton<MathUtils>.Instance.Random.NextSingle());
				this.FinalRotator.Yaw = (float)MathCommon.WrapAngle(num + 180.0);
				this.FinalRotator.Roll = 0f;
				return;
			}
			if (this.Camera.IsInNormalGravityMode())
			{
				this.Camera.CameraForward.ToOrientationRotator(this.FinalRotator);
				return;
			}
			CameraUtility.GetVectorInGravity(this.Camera.CameraForward, this.TmpVector);
			this.TmpVector.Rotation(this.FinalRotator);
		}

		// Token: 0x06045F7F RID: 286591 RVA: 0x01258C5C File Offset: 0x01256E5C
		public void PlaySettlementCameraInternal()
		{
			ControllerBase<CameraController>.Instance.StopAllCameraShakes();
			this.FinalRotator.SubtractionEqual(this.Camera.PlayerRotatorInGravity);
			this.CameraModifier.Settings.ArmRotation = new FRotator(this.FinalRotator.Pitch, this.FinalRotator.Yaw, this.FinalRotator.Roll);
			this.CameraModifier.Settings.ModifySettingsAdditional.ArmOffset.Set((float)this.CameraModifierCharacterOffset.X, (float)this.CameraModifierCharacterOffset.Y, (float)this.CameraModifierCharacterOffset.Z);
			this.Camera.CameraModifyController.ApplyCameraModify(null, this.CameraModifier.Duration, this.CameraModifier.BlendInTime, this.CameraModifier.BlendOutTime, this.CameraModifier.BreakBlendOutTime, this.CameraModifier.Settings, null, new OneOf<CurveBase, SBaseCurve>(this.CameraModifier.BlendInCurve), new OneOf<CurveBase, SBaseCurve>(this.CameraModifier.BlendOutCurve), this.Camera.Character, "HitCase", default(OneOf<TsBaseCharacter, TsBaseVehicle>));
		}

		// Token: 0x06045F80 RID: 286592 RVA: 0x01258D94 File Offset: 0x01256F94
		public bool IsPlayingSettlementCamera()
		{
			return this.Camera.CameraModifyController.IsModified && !(this.CameraModifier == null) && this.Camera.CameraModifyController.ModifySettings.Name == this.CameraModifier.Settings.ModifySettingsAdditional.Name;
		}

		// Token: 0x06045F81 RID: 286593 RVA: 0x01258DF4 File Offset: 0x01256FF4
		[NullableContext(2)]
		private unsafe void UpdateHitActorMap(UKuroHitResult hitResult)
		{
			this.ActorHitResultIndexMap.Clear();
			this.ActorHitResultIndexArrayMap.Clear();
			this.HitResultIndexRadiusMap.Clear();
			if (hitResult == null)
			{
				return;
			}
			int hitCount = hitResult.GetHitCount();
			double num = this.Camera.PlayerLocationInGravity.Z + (double)this.CameraModifierTopAdditionZ;
			double num2 = this.Camera.PlayerLocationInGravity.Z - (double)this.CameraModifierBottomAdditionZ;
			for (int i = 0; i < hitCount; i++)
			{
				AActor aactor = hitResult.Actors.Get(i);
				if (aactor != null)
				{
					TArray<TWeakObjectPtr<UPrimitiveComponent>> components = hitResult.Components;
					TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr = (components != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components.Get(i)) : null;
					USceneComponent usceneComponent = (tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null;
					if (usceneComponent != null)
					{
						Singleton<TraceElementCommon>.Instance.GetImpactPoint(this.CameraSphereTrace.HitResult, i, this.TmpVector);
						double num3 = (double)CameraUtility.GetZnInGravity(this.TmpVector);
						if (num3 >= num2 && num3 <= num)
						{
							if (usceneComponent is UStaticMeshComponent)
							{
								if (!this.ActorHitResultIndexMap.TryAdd(aactor, i))
								{
									int index = this.ActorHitResultIndexMap[aactor];
									Singleton<TraceElementCommon>.Instance.GetImpactPoint(this.CameraSphereTrace.HitResult, index, this.TmpVector2);
									double num4 = Vector.DistSquared(this.TmpVector, this.Camera.PlayerLocation);
									if (Vector.DistSquared(this.TmpVector2, this.Camera.PlayerLocation) < num4)
									{
										this.ActorHitResultIndexMap[aactor] = i;
									}
								}
							}
							else
							{
								UShapeComponent ushapeComponent = usceneComponent as UShapeComponent;
								if (ushapeComponent != null && (double)this.GetShapeComponentRadius(ushapeComponent) > 30.0)
								{
									List<int> list;
									if (!this.ActorHitResultIndexArrayMap.TryGetValue(aactor, out list))
									{
										Dictionary<AActor, List<int>> actorHitResultIndexArrayMap = this.ActorHitResultIndexArrayMap;
										AActor key = aactor;
										int num5 = 1;
										List<int> list2 = new List<int>(num5);
										CollectionsMarshal.SetCount<int>(list2, num5);
										Span<int> span = CollectionsMarshal.AsSpan<int>(list2);
										int index2 = 0;
										*span[index2] = i;
										actorHitResultIndexArrayMap[key] = list2;
									}
									else
									{
										list.Add(i);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06045F82 RID: 286594 RVA: 0x0125900C File Offset: 0x0125720C
		[NullableContext(0)]
		private ValueTuple<double, double> GetActorBoundExtent(FTransformDouble transform, [Nullable(1)] UStaticMeshComponent staticMeshComponent)
		{
			FVector fvector = default(FVector);
			staticMeshComponent.GetLocalBounds(ref fvector, ref this.Extent);
			double item = (double)(this.Extent.X * transform.GetScale3D().X);
			double item2 = (double)(this.Extent.Y * transform.GetScale3D().Y);
			return new ValueTuple<double, double>(item, item2);
		}

		// Token: 0x06045F83 RID: 286595 RVA: 0x01259068 File Offset: 0x01257268
		private void UpdateInvalidYawRangeArray(UKuroHitResult hitResult)
		{
			this.InvalidYawRangeArray.Clear();
			foreach (KeyValuePair<AActor, int> keyValuePair in this.ActorHitResultIndexMap)
			{
				AActor key = keyValuePair.Key;
				int value = keyValuePair.Value;
				TArray<TWeakObjectPtr<UPrimitiveComponent>> components = hitResult.Components;
				TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr = (components != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components.Get(value)) : null;
				USceneComponent usceneComponent = (tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null;
				if (usceneComponent != null)
				{
					Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, value, this.TmpVector);
					this.InvalidYawRangeArray.Add(this.GetStaticMeshInvalidYawRange(key.D_GetTransform(), usceneComponent as UStaticMeshComponent, this.TmpVector));
				}
			}
			Comparison<int> <>9__0;
			foreach (KeyValuePair<AActor, List<int>> keyValuePair2 in this.ActorHitResultIndexArrayMap)
			{
				List<int> value2 = keyValuePair2.Value;
				List<int> list = value2;
				Comparison<int> comparison;
				if ((comparison = <>9__0) == null)
				{
					comparison = (<>9__0 = delegate(int a, int b)
					{
						TArray<TWeakObjectPtr<UPrimitiveComponent>> components3 = hitResult.Components;
						TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr2 = (components3 != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components3.Get(a)) : null;
						USceneComponent usceneComponent3 = (tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null;
						TArray<TWeakObjectPtr<UPrimitiveComponent>> components4 = hitResult.Components;
						tweakObjectPtr2 = ((components4 != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components4.Get(b)) : null);
						USceneComponent usceneComponent4 = (tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null;
						if (usceneComponent4 == null)
						{
							return -1;
						}
						if (usceneComponent3 == null)
						{
							return 1;
						}
						double value3 = (double)this.GetHitComponentRadius(usceneComponent3 as UShapeComponent, a);
						return ((double)this.GetHitComponentRadius(usceneComponent4 as UShapeComponent, b)).CompareTo(value3);
					});
				}
				list.Sort(comparison);
				int num = 0;
				while (num < value2.Count && num < 4)
				{
					TArray<TWeakObjectPtr<UPrimitiveComponent>> components2 = hitResult.Components;
					TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr = (components2 != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components2.Get(value2[num])) : null;
					USceneComponent usceneComponent2 = (tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null;
					if (usceneComponent2 != null)
					{
						this.InvalidYawRangeArray.Add(this.GetShapeInvalidYawRange(usceneComponent2 as UShapeComponent, value2[num]));
					}
					num++;
				}
			}
		}

		// Token: 0x06045F84 RID: 286596 RVA: 0x01259270 File Offset: 0x01257470
		private SettlementCamera.YawRange GetShapeInvalidYawRange(UShapeComponent hitComponent, int hitComponentIndex)
		{
			Vector tmpVector = this.TmpVector;
			FVectorDouble fvectorDouble = hitComponent.D_K2_GetComponentLocation();
			tmpVector.DeepCopy(fvectorDouble);
			float cameraSphereRadius = this.CameraSphereRadius;
			float hitComponentRadius = this.GetHitComponentRadius(hitComponent, hitComponentIndex);
			float num = (float)Vector.Dist2D(this.Camera.PlayerLocation, this.TmpVector);
			float num2 = this.ConvertPointToAngle(this.TmpVector);
			float num3;
			if (num < cameraSphereRadius)
			{
				num3 = (float)Math.Atan((double)(hitComponentRadius / num));
			}
			else
			{
				num3 = (float)Singleton<MathUtils>.Instance.GetObliqueTriangleAngle((double)cameraSphereRadius, (double)num, (double)hitComponentRadius);
			}
			num3 *= 57.29578f;
			return new SettlementCamera.YawRange(num2 - num3, num2 + num3);
		}

		// Token: 0x06045F85 RID: 286597 RVA: 0x01259300 File Offset: 0x01257500
		private SettlementCamera.YawRange GetStaticMeshInvalidYawRange(FTransformDouble hitTransform, UStaticMeshComponent hitComponent, Vector impactPoint)
		{
			FVectorDouble fvectorDouble = this.PlayerLocation.ToUeVector(false);
			FVectorDouble fvectorDouble2 = hitTransform.InverseTransformPositionNoScale(fvectorDouble);
			fvectorDouble = impactPoint.ToUeVector(false);
			FVectorDouble fvectorDouble3 = hitTransform.InverseTransformPositionNoScale(fvectorDouble);
			double num = (double)this.CameraSphereRadius;
			ValueTuple<double, double> actorBoundExtent = this.GetActorBoundExtent(hitTransform, hitComponent);
			double item = actorBoundExtent.Item1;
			double item2 = actorBoundExtent.Item2;
			Vector vector = Vector.Create();
			Vector vector2 = Vector.Create();
			if (fvectorDouble2.Y >= -item2 && fvectorDouble2.Y <= item2)
			{
				double num2 = item2 + fvectorDouble2.Y;
				double num3 = item2 - fvectorDouble2.Y;
				double num4 = fvectorDouble3.X - fvectorDouble2.X;
				double num5;
				if (num2 * num2 + num4 * num4 > num * num)
				{
					num5 = fvectorDouble2.Y - Math.Sqrt(num * num - num4 * num4);
				}
				else
				{
					num5 = fvectorDouble2.Y - num2;
				}
				double num6;
				if (num3 * num3 + num4 * num4 > num * num)
				{
					num6 = fvectorDouble2.Y + Math.Sqrt(num * num - num4 * num4);
				}
				else
				{
					num6 = fvectorDouble2.Y + num3;
				}
				vector.X = fvectorDouble3.X;
				vector.Y = (double)((float)((fvectorDouble2.X <= 0.0) ? num5 : num6));
				vector.Z = fvectorDouble3.Z;
				vector2.X = fvectorDouble3.X;
				vector2.Y = (double)((float)((fvectorDouble2.X > 0.0) ? num5 : num6));
				vector2.Z = fvectorDouble3.Z;
			}
			else if (fvectorDouble2.X >= -item && fvectorDouble2.X <= item)
			{
				double num7 = item - fvectorDouble2.X;
				double num8 = item + fvectorDouble2.X;
				double num9 = fvectorDouble3.Y - fvectorDouble2.Y;
				double num5;
				if (num7 * num7 + num9 * num9 > num * num)
				{
					num5 = fvectorDouble2.X - Math.Sqrt(num * num - num9 * num9);
				}
				else
				{
					num5 = fvectorDouble2.X - num7;
				}
				double num6;
				if (num8 * num8 + num9 * num9 > num * num)
				{
					num6 = fvectorDouble2.X + Math.Sqrt(num * num - num9 * num9);
				}
				else
				{
					num6 = fvectorDouble2.X + num8;
				}
				vector.X = ((fvectorDouble2.Y <= 0.0) ? num5 : num6);
				vector.Y = (double)((float)fvectorDouble3.Y);
				vector.Z = fvectorDouble3.Z;
				vector2.X = ((fvectorDouble2.Y > 0.0) ? num5 : num6);
				vector2.Y = (double)((float)fvectorDouble3.Y);
				vector2.Z = fvectorDouble3.Z;
			}
			else if (fvectorDouble2.Y < -item2 && fvectorDouble2.X < -item)
			{
				double num10 = item - fvectorDouble2.X;
				double num11 = item2 - fvectorDouble2.Y;
				double num12 = fvectorDouble3.X - fvectorDouble2.X;
				double num13 = fvectorDouble3.Y - fvectorDouble2.Y;
				double num5;
				if (num10 * num10 + num13 * num13 > num * num)
				{
					num5 = fvectorDouble2.X + Math.Sqrt(num * num - num13 * num13);
				}
				else
				{
					num5 = fvectorDouble2.X + num10;
				}
				double num6;
				if (num11 * num11 + num12 * num12 > num * num)
				{
					num6 = fvectorDouble2.Y + Math.Sqrt(num * num - num12 * num12);
				}
				else
				{
					num6 = fvectorDouble2.Y + num11;
				}
				vector.X = num5;
				vector.Y = (double)((float)fvectorDouble3.Y);
				vector.Z = fvectorDouble3.Z;
				vector2.X = fvectorDouble3.X;
				vector2.Y = (double)((float)num6);
				vector2.Z = fvectorDouble3.Z;
			}
			else if (fvectorDouble2.Y > item2 && fvectorDouble2.X < -item)
			{
				double num14 = item - fvectorDouble2.X;
				double num15 = item2 + fvectorDouble2.Y;
				double num16 = fvectorDouble3.X - fvectorDouble2.X;
				double num17 = fvectorDouble3.Y - fvectorDouble2.Y;
				double num5;
				if (num14 * num14 + num17 * num17 > num * num)
				{
					num5 = fvectorDouble2.X + Math.Sqrt(num * num - num17 * num17);
				}
				else
				{
					num5 = fvectorDouble2.X + num14;
				}
				double num6;
				if (num15 * num15 + num16 * num16 > num * num)
				{
					num6 = fvectorDouble2.Y - Math.Sqrt(num * num - num16 * num16);
				}
				else
				{
					num6 = fvectorDouble2.Y - num15;
				}
				vector2.X = num5;
				vector2.Y = (double)((float)fvectorDouble3.Y);
				vector2.Z = fvectorDouble3.Z;
				vector.X = fvectorDouble3.X;
				vector.Y = (double)((float)num6);
				vector.Z = fvectorDouble3.Z;
			}
			else if (fvectorDouble2.Y < -item2 && fvectorDouble2.X > item)
			{
				double num18 = item + fvectorDouble2.X;
				double num19 = item2 - fvectorDouble2.Y;
				double num20 = fvectorDouble3.X - fvectorDouble2.X;
				double num21 = fvectorDouble3.Y - fvectorDouble2.Y;
				double num5;
				if (num18 * num18 + num21 * num21 > num * num)
				{
					num5 = fvectorDouble2.X - Math.Sqrt(num * num - num21 * num21);
				}
				else
				{
					num5 = fvectorDouble2.X - num18;
				}
				double num6;
				if (num19 * num19 + num20 * num20 > num * num)
				{
					num6 = fvectorDouble2.Y + Math.Sqrt(num * num - num20 * num20);
				}
				else
				{
					num6 = fvectorDouble2.Y + num19;
				}
				vector.X = fvectorDouble3.X;
				vector.Y = (double)((float)num6);
				vector.Z = fvectorDouble3.Z;
				vector2.X = num5;
				vector2.Y = (double)((float)fvectorDouble3.Y);
				vector2.Z = fvectorDouble3.Z;
			}
			else if (fvectorDouble2.Y > item2 && fvectorDouble2.X > item)
			{
				double num22 = item + fvectorDouble2.X;
				double num23 = item2 + fvectorDouble2.Y;
				double num24 = fvectorDouble3.X - fvectorDouble2.X;
				double num25 = fvectorDouble3.Y - fvectorDouble2.Y;
				double num5;
				if (num22 * num22 + num25 * num25 > num * num)
				{
					num5 = fvectorDouble2.X - Math.Sqrt(num * num - num25 * num25);
				}
				else
				{
					num5 = fvectorDouble2.X - num22;
				}
				double num6;
				if (num23 * num23 + num24 * num24 > num * num)
				{
					num6 = fvectorDouble2.Y - Math.Sqrt(num * num - num24 * num24);
				}
				else
				{
					num6 = fvectorDouble2.Y - num23;
				}
				vector.X = num5;
				vector.Y = (double)((float)fvectorDouble3.Y);
				vector.Z = fvectorDouble3.Z;
				vector2.X = fvectorDouble3.X;
				vector2.Y = (double)((float)num6);
				vector2.Z = fvectorDouble3.Z;
			}
			fvectorDouble = vector.ToUeVector(false);
			FVectorDouble uePoint = hitTransform.TransformPositionNoScale(fvectorDouble);
			fvectorDouble = vector2.ToUeVector(false);
			FVectorDouble uePoint2 = hitTransform.TransformPositionNoScale(fvectorDouble);
			float num26 = this.ConvertUePointToAngle(uePoint);
			float num27 = this.ConvertUePointToAngle(uePoint2);
			if (this.Camera.IsInNormalGravityMode())
			{
				return new SettlementCamera.YawRange(num26, num27);
			}
			double num28 = (double)Math.Abs(num26 - num27);
			double num29 = Singleton<MathUtils>.Instance.WrapAngle((double)(num26 + num27) * 0.5);
			return new SettlementCamera.YawRange((float)Singleton<MathUtils>.Instance.WrapAngle(num29 - num28 / 2.0), (float)Singleton<MathUtils>.Instance.WrapAngle(num29 + num28 / 2.0));
		}

		// Token: 0x06045F86 RID: 286598 RVA: 0x01259A64 File Offset: 0x01257C64
		private void UpdateValidYawRangeArray()
		{
			this.LeftYawRangeArray.Clear();
			this.RightYawRangeArray.Clear();
			this.LeftYawRangeArray.Add(new SettlementCamera.YawRange(this.CameraModifierLeftYawRangeMin, this.CameraModifierLeftYawRangeMax));
			this.RightYawRangeArray.Add(new SettlementCamera.YawRange(this.CameraModifierRightYawRangeMin, this.CameraModifierRightYawRangeMax));
			foreach (SettlementCamera.YawRange yawRange in this.InvalidYawRangeArray)
			{
				float num = MathCommon.WrapAngle(yawRange.Max - this.PlayerYaw);
				float num2 = MathCommon.WrapAngle(yawRange.Min - this.PlayerYaw);
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				float num6 = 0f;
				float num7 = 0f;
				float num8 = 0f;
				float num9 = 0f;
				float num10 = 0f;
				int num11 = 0;
				int num12 = 0;
				if (num < 0f && num2 < 0f)
				{
					if (num < num2)
					{
						num11 = 1;
						num3 = num;
						num4 = num2;
					}
					else
					{
						num11 = 2;
						num3 = -180f;
						num4 = num2;
						num5 = num;
						num6 = 0f;
						num12 = 1;
						num7 = 0f;
						num8 = 180f;
					}
				}
				else if (num > 0f && num2 > 0f)
				{
					if (num < num2)
					{
						num12 = 1;
						num7 = num;
						num8 = num2;
					}
					else
					{
						num12 = 2;
						num7 = 0f;
						num8 = num2;
						num9 = num;
						num10 = 180f;
						num11 = 1;
						num3 = -180f;
						num4 = 0f;
					}
				}
				else if (num < 0f && num2 > 0f)
				{
					num11 = 1;
					num12 = 1;
					num3 = num;
					num4 = 0f;
					num7 = 0f;
					num8 = num2;
				}
				else if (num > 0f && num2 < 0f)
				{
					num11 = 1;
					num12 = 1;
					num3 = -180f;
					num4 = num2;
					num7 = num;
					num8 = 180f;
				}
				for (int i = this.LeftYawRangeArray.Count - 1; i >= 0; i--)
				{
					bool flag = true;
					SettlementCamera.YawRange yawRange2 = this.LeftYawRangeArray[i];
					if (num11 >= 2 && yawRange2.Min <= num6 && yawRange2.Max >= num5)
					{
						float from = Math.Max(yawRange2.Min, num5);
						float to = Math.Min(yawRange2.Max, num6);
						this.LeftYawRangeArray.Add(new SettlementCamera.YawRange(from, to));
					}
					if (num11 >= 1 && yawRange2.Min <= num4 && yawRange2.Max >= num3)
					{
						flag = false;
						yawRange2.Min = Math.Max(yawRange2.Min, num3);
						yawRange2.Max = Math.Min(yawRange2.Max, num4);
					}
					if (flag)
					{
						this.LeftYawRangeArray.RemoveAt(i);
					}
				}
				for (int j = this.RightYawRangeArray.Count - 1; j >= 0; j--)
				{
					bool flag2 = true;
					SettlementCamera.YawRange yawRange3 = this.RightYawRangeArray[j];
					if (num12 >= 2 && yawRange3.Min <= num10 && yawRange3.Max >= num9)
					{
						float from2 = Math.Max(yawRange3.Min, num9);
						float to2 = Math.Min(yawRange3.Max, num10);
						this.RightYawRangeArray.Add(new SettlementCamera.YawRange(from2, to2));
					}
					if (num12 >= 1 && yawRange3.Min <= num8 && yawRange3.Max >= num7)
					{
						flag2 = false;
						yawRange3.Min = Math.Max(yawRange3.Min, num7);
						yawRange3.Max = Math.Min(yawRange3.Max, num8);
					}
					if (flag2)
					{
						this.RightYawRangeArray.RemoveAt(j);
					}
				}
			}
		}

		// Token: 0x06045F87 RID: 286599 RVA: 0x01259E10 File Offset: 0x01258010
		private float GetHitComponentRadius(UShapeComponent hitComponent, int index)
		{
			if (!this.HitResultIndexRadiusMap.ContainsKey(index))
			{
				this.HitResultIndexRadiusMap[index] = this.GetShapeComponentRadius(hitComponent);
			}
			return this.HitResultIndexRadiusMap[index];
		}

		// Token: 0x06045F88 RID: 286600 RVA: 0x01259E40 File Offset: 0x01258040
		[NullableContext(2)]
		private float GetShapeComponentRadius(UShapeComponent hitComponent)
		{
			if (hitComponent == null)
			{
				return 0f;
			}
			UCapsuleComponent ucapsuleComponent = hitComponent as UCapsuleComponent;
			if (ucapsuleComponent != null)
			{
				return ucapsuleComponent.CapsuleRadius;
			}
			UBoxComponent uboxComponent = hitComponent as UBoxComponent;
			if (uboxComponent != null)
			{
				return Math.Max(uboxComponent.BoxExtent.X, uboxComponent.BoxExtent.Y);
			}
			USphereComponent usphereComponent = hitComponent as USphereComponent;
			if (usphereComponent != null)
			{
				return usphereComponent.SphereRadius;
			}
			return 0f;
		}

		// Token: 0x06045F89 RID: 286601 RVA: 0x01259EA3 File Offset: 0x012580A3
		private float ConvertUePointToAngle(FVectorDouble uePoint)
		{
			this.TmpVector.Set(uePoint.X, uePoint.Y, uePoint.Z);
			return this.ConvertPointToAngle(this.TmpVector);
		}

		// Token: 0x06045F8A RID: 286602 RVA: 0x01259ED0 File Offset: 0x012580D0
		private float ConvertPointToAngle(Vector point)
		{
			point.Subtraction(this.PlayerLocation, this.TmpVector);
			if (this.Camera.IsInNormalGravityMode())
			{
				return (float)(this.TmpVector.HeadingAngle() * 57.295780181884766);
			}
			CameraUtility.GetVectorInGravity(this.TmpVector, this.TmpVector);
			this.TmpVector.Rotation(this.TmpRotator);
			return Singleton<MathUtils>.Instance.WrapAngle(this.TmpRotator.Yaw);
		}

		// Token: 0x06045F8B RID: 286603 RVA: 0x01259F4C File Offset: 0x0125814C
		public void SetDrawDebugEnable(bool isEnable)
		{
			if (isEnable)
			{
				this.CameraSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
				this.CameraSphereTrace.DrawTime = 10f;
			}
			else
			{
				this.CameraSphereTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
				this.CameraSphereTrace.DrawTime = 0f;
			}
			this.EnableDebugDraw = isEnable;
		}

		// Token: 0x06045F8C RID: 286604 RVA: 0x01259FA0 File Offset: 0x012581A0
		private void DrawDebugInvalidRange()
		{
			foreach (SettlementCamera.YawRange yawRange in this.InvalidYawRangeArray)
			{
				float min = yawRange.Min;
				float max = yawRange.Max;
				Vector vector = Vector.Create();
				float num = max - min;
				if (num < 0f)
				{
					num += 360f;
				}
				Rotator rotator = new Rotator(0f, num / 2f + min, 0f);
				CameraUtility.GetRotatorInGravity(rotator, rotator);
				rotator.Vector(vector);
				UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, this.PlayerLocation.ToUeVector(false), vector.ToUeVector(false), this.Camera.FinalCameraDistance, MathCommon.UnwindDegrees(max - min) * 0.017453292f / 2f, 0f, 100, ColorUtils.LinearRed, 10f, 1f);
			}
		}

		// Token: 0x06045F8D RID: 286605 RVA: 0x0125A098 File Offset: 0x01258298
		private void DrawDebugValidRange()
		{
			foreach (SettlementCamera.YawRange yawRange in this.LeftYawRangeArray)
			{
				float num = yawRange.Min + this.PlayerYaw;
				float num2 = yawRange.Max + this.PlayerYaw;
				Rotator rotator = new Rotator(0f, (num2 + num) / 2f, 0f);
				CameraUtility.GetRotatorInGravity(rotator, rotator);
				Vector vector = Vector.Create();
				rotator.Vector(vector);
				UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, this.Camera.PlayerLocation.ToUeVector(false), vector.ToUeVector(false), this.Camera.FinalCameraDistance, MathCommon.UnwindDegrees(num2 - num) * 0.017453292f / 2f, 0f, 100, ColorUtils.LinearCyan, 10f, 1f);
			}
			foreach (SettlementCamera.YawRange yawRange2 in this.RightYawRangeArray)
			{
				float num3 = yawRange2.Min + this.PlayerYaw;
				float num4 = yawRange2.Max + this.PlayerYaw;
				Rotator rotator2 = new Rotator(0f, (num4 + num3) / 2f, 0f);
				CameraUtility.GetRotatorInGravity(rotator2, rotator2);
				Vector vector2 = Vector.Create();
				rotator2.Vector(vector2);
				UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, this.Camera.PlayerLocation.ToUeVector(false), vector2.ToUeVector(false), this.Camera.FinalCameraDistance, MathCommon.UnwindDegrees(num4 - num3) * 0.017453292f / 2f, 0f, 100, ColorUtils.LinearCyan, 10f, 1f);
			}
		}

		// Token: 0x06045F8E RID: 286606 RVA: 0x0125A270 File Offset: 0x01258470
		private void DrawDebugCameraFocus()
		{
			FTransformDouble actorTransform = this.Camera.Character.CharacterActorComponent.ActorTransform;
			FVectorDouble fvectorDouble = this.CameraModifierCharacterOffset.ToUeVector(false);
			FVectorDouble center = actorTransform.TransformPositionNoScale(fvectorDouble);
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, center, 10f, 12, new FLinearColor?(new FLinearColor()), 10f, 0f);
		}

		// Token: 0x06045F8F RID: 286607 RVA: 0x0125A2D0 File Offset: 0x012584D0
		private void DrawDebugFinalDirection()
		{
			Vector vector = Vector.Create();
			this.FinalRotator.Vector(vector);
			Vector vector2 = Vector.Create();
			vector.MultiplyEqual((double)this.Camera.FinalCameraDistance);
			vector.Addition(this.PlayerLocation, vector2);
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, this.PlayerLocation.ToUeVector(false), vector2.ToUeVector(false), this.Camera.FinalCameraDistance, ColorUtils.LinearRed, 10f, 5f);
		}

		// Token: 0x06045F90 RID: 286608 RVA: 0x0125A350 File Offset: 0x01258550
		public void Clear()
		{
			if (this.CameraSphereTrace != null)
			{
				this.CameraSphereTrace.Dispose();
				this.CameraSphereTrace = null;
			}
			this.Camera = null;
			this.ActorHitResultIndexMap.Clear();
			this.ActorHitResultIndexArrayMap.Clear();
			this.HitResultIndexRadiusMap.Clear();
			this.InvalidYawRangeArray.Clear();
			this.LeftYawRangeArray.Clear();
			this.RightYawRangeArray.Clear();
			this.TmpYawRange.Clear();
		}

		// Token: 0x0402734C RID: 160588
		private const int MIN_CAMERA_DISTANCE = 100;

		// Token: 0x0402734D RID: 160589
		private const int TARGET_PITCH_MIN = -5;

		// Token: 0x0402734E RID: 160590
		private const int TARGET_PITCH_MAX = -8;

		// Token: 0x0402734F RID: 160591
		private const int TRACE_TOP_ADDITION_Z = 50;

		// Token: 0x04027350 RID: 160592
		private const int TRACE_BOTTOM_ADDITION_Z = 50;

		// Token: 0x04027351 RID: 160593
		private const int LEFT_YAW_RANGE_MIN = -180;

		// Token: 0x04027352 RID: 160594
		private const int LEFT_YAW_RANGE_MAX = 0;

		// Token: 0x04027353 RID: 160595
		private const int RIGHT_YAW_RANGE_MIN = 0;

		// Token: 0x04027354 RID: 160596
		private const int RIGHT_YAW_RANGE_MAX = 180;

		// Token: 0x04027355 RID: 160597
		private const int MIN_VALID_YAW_RANGE = 0;

		// Token: 0x04027356 RID: 160598
		private const int MIN_SHAPE_RADUIS = 30;

		// Token: 0x04027357 RID: 160599
		private const int MAX_CACHE_CAPSULE_COUNT = 4;

		// Token: 0x04027358 RID: 160600
		private const int PITCH_MAX = 90;

		// Token: 0x04027359 RID: 160601
		private const int PITCH_MIN = -90;

		// Token: 0x0402735A RID: 160602
		private const int MINUS_FLAT_ANGLE = -180;

		// Token: 0x0402735B RID: 160603
		private const int FLAT_ANGLE = 180;

		// Token: 0x0402735C RID: 160604
		private const string PROFILE_KEY = "FightCameraLogicComponent_TraceValidRange_Camera";

		// Token: 0x0402735D RID: 160605
		[StaticVariableRuleIgnore]
		private static readonly int BanSettlementCamera = GameplayTagDefine.EGameplayTagId["功能.通用镜头.屏蔽终结镜头"];

		// Token: 0x0402735E RID: 160606
		private const double DEBUG_DRAW_DURATION = 10.0;

		// Token: 0x0402735F RID: 160607
		private const double DEBUG_DRAW_RADIUS = 10.0;

		// Token: 0x04027360 RID: 160608
		private const int DEBUG_DRAW_SEGMENTS = 12;

		// Token: 0x04027361 RID: 160609
		private const double THICKNESS = 5.0;

		// Token: 0x04027362 RID: 160610
		[Nullable(2)]
		private FightCameraLogicComponent Camera;

		// Token: 0x04027363 RID: 160611
		private float CameraSphereRadius = 100f;

		// Token: 0x04027364 RID: 160612
		[Nullable(2)]
		private UTraceSphereElement CameraSphereTrace;

		// Token: 0x04027365 RID: 160613
		[Nullable(2)]
		private SSettlementCamera SettlementCameraConfig;

		// Token: 0x04027366 RID: 160614
		[Nullable(2)]
		private SCameraModifier CameraModifier;

		// Token: 0x04027367 RID: 160615
		private float CameraModifierArmLength = 100f;

		// Token: 0x04027368 RID: 160616
		private float CameraModifierPitchMin = -5f;

		// Token: 0x04027369 RID: 160617
		private float CameraModifierPitchMax = -8f;

		// Token: 0x0402736A RID: 160618
		private float CameraModifierTopAdditionZ = 50f;

		// Token: 0x0402736B RID: 160619
		private float CameraModifierBottomAdditionZ = 50f;

		// Token: 0x0402736C RID: 160620
		private float CameraModifierLeftYawRangeMin = -180f;

		// Token: 0x0402736D RID: 160621
		private float CameraModifierLeftYawRangeMax;

		// Token: 0x0402736E RID: 160622
		private float CameraModifierRightYawRangeMin;

		// Token: 0x0402736F RID: 160623
		private float CameraModifierRightYawRangeMax = 180f;

		// Token: 0x04027370 RID: 160624
		private float CameraModifierValidRangeMin;

		// Token: 0x04027371 RID: 160625
		private readonly Vector CameraModifierCharacterOffset = Vector.Create();

		// Token: 0x04027372 RID: 160626
		private float PlayerYaw;

		// Token: 0x04027373 RID: 160627
		[Nullable(2)]
		private Vector PlayerLocation;

		// Token: 0x04027374 RID: 160628
		private readonly Rotator FinalRotator = Rotator.Create();

		// Token: 0x04027375 RID: 160629
		private readonly Dictionary<AActor, int> ActorHitResultIndexMap = new Dictionary<AActor, int>();

		// Token: 0x04027376 RID: 160630
		private readonly Dictionary<AActor, List<int>> ActorHitResultIndexArrayMap = new Dictionary<AActor, List<int>>();

		// Token: 0x04027377 RID: 160631
		private readonly Dictionary<int, float> HitResultIndexRadiusMap = new Dictionary<int, float>();

		// Token: 0x04027378 RID: 160632
		private FVector Extent = new FVector();

		// Token: 0x04027379 RID: 160633
		private readonly List<SettlementCamera.YawRange> InvalidYawRangeArray = new List<SettlementCamera.YawRange>();

		// Token: 0x0402737A RID: 160634
		private readonly List<SettlementCamera.YawRange> LeftYawRangeArray = new List<SettlementCamera.YawRange>();

		// Token: 0x0402737B RID: 160635
		private readonly List<SettlementCamera.YawRange> RightYawRangeArray = new List<SettlementCamera.YawRange>();

		// Token: 0x0402737C RID: 160636
		private readonly Vector TmpVector = Vector.Create();

		// Token: 0x0402737D RID: 160637
		private readonly Vector TmpVector2 = Vector.Create();

		// Token: 0x0402737E RID: 160638
		private readonly Rotator TmpRotator = Rotator.Create();

		// Token: 0x0402737F RID: 160639
		private readonly List<SettlementCamera.YawRange> TmpYawRange = new List<SettlementCamera.YawRange>();

		// Token: 0x04027380 RID: 160640
		public bool EnableDebugDraw;

		// Token: 0x0200CCC4 RID: 52420
		[NullableContext(0)]
		public class YawRange
		{
			// Token: 0x0604FBFF RID: 326655 RVA: 0x0163B5C9 File Offset: 0x016397C9
			public YawRange(float from, float to)
			{
			}

			// Token: 0x0403ECB7 RID: 257207
			public float Min = from;

			// Token: 0x0403ECB8 RID: 257208
			public float Max = to;
		}
	}
}
