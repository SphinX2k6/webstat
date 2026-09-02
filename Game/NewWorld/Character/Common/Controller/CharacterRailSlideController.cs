using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.RailSlideFollower;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048F5 RID: 18677
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CharacterRailSlideController : ControllerBase<CharacterRailSlideController>
	{
		// Token: 0x06030C3E RID: 199742 RVA: 0x00C0B998 File Offset: 0x00C09B98
		public void SetEntityRail(int entityId, int railId)
		{
			int num;
			int num2;
			if (this.EntityRailMap.TryGetValue(entityId, out num) && num != railId && this.RailToEntityMap.TryGetValue(num, out num2) && num2 == entityId)
			{
				this.RailToEntityMap.Remove(num);
			}
			this.EntityRailMap[entityId] = railId;
			this.RailToEntityMap[railId] = entityId;
			this.TriggerFollowers(railId);
		}

		// Token: 0x06030C3F RID: 199743 RVA: 0x00C0B9FC File Offset: 0x00C09BFC
		public void RemoveEntityRail(int entityId)
		{
			int key;
			if (this.EntityRailMap.TryGetValue(entityId, out key))
			{
				this.EntityRailMap.Remove(entityId);
				int num;
				if (this.RailToEntityMap.TryGetValue(key, out num) && num == entityId)
				{
					this.RailToEntityMap.Remove(key);
				}
			}
		}

		// Token: 0x06030C40 RID: 199744 RVA: 0x00C0BA48 File Offset: 0x00C09C48
		public int? GetEntityRailId(int entityId)
		{
			int value;
			if (!this.EntityRailMap.TryGetValue(entityId, out value))
			{
				return null;
			}
			return new int?(value);
		}

		// Token: 0x06030C41 RID: 199745 RVA: 0x00C0BA78 File Offset: 0x00C09C78
		public void AddRailFollower(int pbDataId, int railId, string followerDaPath, string daPath)
		{
			RailSlideFollowerParams railSlideFollowerParams = this.InitRailSlideFollowerParams(followerDaPath);
			if (railSlideFollowerParams == null)
			{
				return;
			}
			List<CharacterRailSlideController.RailFollowerEntry> list;
			if (!this.RailFollowerMap.TryGetValue(railId, out list))
			{
				list = new List<CharacterRailSlideController.RailFollowerEntry>();
				this.RailFollowerMap[railId] = list;
			}
			CharacterRailSlideController.RailFollowerEntry railFollowerEntry = list.Find((CharacterRailSlideController.RailFollowerEntry f) => f.PbDataId == pbDataId && f.RailId == railId);
			if (railFollowerEntry != null)
			{
				railFollowerEntry.Params = railSlideFollowerParams;
			}
			else
			{
				list.Add(new CharacterRailSlideController.RailFollowerEntry
				{
					PbDataId = pbDataId,
					Params = railSlideFollowerParams,
					DaPath = daPath,
					RailId = railId
				});
			}
			if (this.GetRailActiveEntity(railId) != 0)
			{
				if (railSlideFollowerParams.DelayStartFollow > 20f)
				{
					TimerSystem.FlowTimeInstance.Delay(delegate(float delta)
					{
						this.TriggerFollowers(railId);
					}, Singleton<MathUtils>.Instance.Clamp(railSlideFollowerParams.DelayStartFollow, 20f, 180000f), null, null, true, 1f);
					return;
				}
				this.TriggerFollowers(railId);
			}
		}

		// Token: 0x06030C42 RID: 199746 RVA: 0x00C0BB8C File Offset: 0x00C09D8C
		private int GetRailActiveEntity(int railId)
		{
			int result;
			if (!this.RailToEntityMap.TryGetValue(railId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x06030C43 RID: 199747 RVA: 0x00C0BBAC File Offset: 0x00C09DAC
		private void TriggerFollowers(int railId)
		{
			List<CharacterRailSlideController.RailFollowerEntry> list;
			if (!this.RailFollowerMap.TryGetValue(railId, out list) || list.Count == 0)
			{
				return;
			}
			List<CharacterRailSlideController.RailFollowerEntry> list2 = new List<CharacterRailSlideController.RailFollowerEntry>(list);
			list.Clear();
			this.RailFollowerMap.Remove(railId);
			foreach (CharacterRailSlideController.RailFollowerEntry railFollowerEntry in list2)
			{
				if (!this.ActiveFollowerMap.ContainsKey(railFollowerEntry.PbDataId))
				{
					CreatureModel instance = ModelBase<CreatureModel>.Instance;
					WorldEntity worldEntity;
					if (instance == null)
					{
						worldEntity = null;
					}
					else
					{
						EntityHandle entityByPbDataId = instance.GetEntityByPbDataId(railFollowerEntry.PbDataId);
						worldEntity = ((entityByPbDataId != null) ? entityByPbDataId.Entity : null);
					}
					WorldEntity worldEntity2 = worldEntity;
					if (worldEntity2 != null && !worldEntity2.IsInit)
					{
						CharacterRailSlideController.<>c__DisplayClass23_0 CS$<>8__locals1 = new CharacterRailSlideController.<>c__DisplayClass23_0();
						CS$<>8__locals1.<>4__this = this;
						CS$<>8__locals1.capturedEntity = worldEntity2;
						CS$<>8__locals1.capturedFollower = railFollowerEntry;
						CS$<>8__locals1.capturedRailId = railId;
						Singleton<EventSystem>.Instance.AddWithTarget<int>(worldEntity2, EEventName.CharBornFinished, new Action<int>(CS$<>8__locals1.<TriggerFollowers>g__Handler|0));
					}
					else
					{
						CharacterRailSlideComponent characterRailSlideComponent = (worldEntity2 != null) ? worldEntity2.GetComponent<CharacterRailSlideComponent>() : null;
						this.ActiveFollowerMap[railFollowerEntry.PbDataId] = new CharacterRailSlideController.ActiveFollowerState
						{
							Params = railFollowerEntry.Params,
							LastDist = ((characterRailSlideComponent != null) ? characterRailSlideComponent.GetCurrentRailDistance() : 0f),
							CurrentSide = railFollowerEntry.Params.FollowOnRight,
							RadVelocity = 0f,
							SmoothedLeaderRad = 0f
						};
						if (characterRailSlideComponent != null)
						{
							characterRailSlideComponent.StartFollowerRailSlide(railId, railFollowerEntry.DaPath, false, null);
						}
					}
				}
			}
		}

		// Token: 0x06030C44 RID: 199748 RVA: 0x00C0BD48 File Offset: 0x00C09F48
		private RailSlideFollowerParams InitRailSlideFollowerParams(string daPath)
		{
			BP_RailSlideFollowerConfig_C bp_RailSlideFollowerConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_RailSlideFollowerConfig_C>(daPath, "js_undefined");
			if (bp_RailSlideFollowerConfig_C == null || !bp_RailSlideFollowerConfig_C.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[RailSlide] 获取Follower参数DA失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DaPath", daPath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return new RailSlideFollowerParams(bp_RailSlideFollowerConfig_C);
		}

		// Token: 0x06030C45 RID: 199749 RVA: 0x00C0BDA8 File Offset: 0x00C09FA8
		public float GetRailSlideFollowerDist(int pbDataId, int railId, float followerCurrentDist, float splineLength, float deltaMs)
		{
			CharacterRailSlideController.IActiveFollowerState activeFollowerState;
			if (!this.ActiveFollowerMap.TryGetValue(pbDataId, out activeFollowerState))
			{
				return followerCurrentDist;
			}
			int railActiveEntity = this.GetRailActiveEntity(railId);
			if (railActiveEntity == 0)
			{
				return followerCurrentDist;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			object obj;
			if (instance == null)
			{
				obj = null;
			}
			else
			{
				EntityHandle entityById = instance.GetEntityById(railActiveEntity);
				obj = ((entityById != null) ? entityById.Entity : null);
			}
			object obj2 = obj;
			CharacterRailSlideComponent characterRailSlideComponent = (obj2 != null) ? obj2.GetComponent<CharacterRailSlideComponent>() : null;
			if (characterRailSlideComponent == null)
			{
				return followerCurrentDist;
			}
			float num = Math.Min(characterRailSlideComponent.GetCurrentRailDistance() + activeFollowerState.Params.FrontDistance, splineLength - 1f);
			float num2 = num - followerCurrentDist;
			float num3 = deltaMs * 0.001f;
			float val = activeFollowerState.Params.FollowerLerpSpeed * num3;
			float value = num2 * (1f - (float)Math.Exp((double)(-(double)activeFollowerState.Params.FollowSpeedStepRate * num3)));
			float num4 = (float)Math.Sign(num2) * Math.Min(Math.Abs(value), val);
			float num5 = (Math.Abs(num2) <= Math.Max(Math.Abs(num4), 20f)) ? num : (followerCurrentDist + num4);
			activeFollowerState.LastDist = num5;
			return num5;
		}

		// Token: 0x06030C46 RID: 199750 RVA: 0x00C0BEA4 File Offset: 0x00C0A0A4
		public float GetFollowerTargetRad(int followerPbDataId, int railId, float followerCurrentRad, float followerRadius, float deltaMs, float effectiveMaxLinearVelocity)
		{
			CharacterRailSlideController.IActiveFollowerState activeFollowerState;
			if (!this.ActiveFollowerMap.TryGetValue(followerPbDataId, out activeFollowerState) || followerRadius <= 0f)
			{
				return followerCurrentRad;
			}
			RailSlideFollowerParams @params = activeFollowerState.Params;
			int railActiveEntity = this.GetRailActiveEntity(railId);
			if (railActiveEntity == 0)
			{
				return followerCurrentRad;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			object obj;
			if (instance == null)
			{
				obj = null;
			}
			else
			{
				EntityHandle entityById = instance.GetEntityById(railActiveEntity);
				obj = ((entityById != null) ? entityById.Entity : null);
			}
			object obj2 = obj;
			CharacterRailSlideComponent characterRailSlideComponent = (obj2 != null) ? obj2.GetComponent<CharacterRailSlideComponent>() : null;
			if (characterRailSlideComponent == null)
			{
				return followerCurrentRad;
			}
			float currentRad = characterRailSlideComponent.GetCurrentRad();
			float num = deltaMs * 0.001f;
			float num2 = 1f;
			activeFollowerState.SmoothedLeaderRad += (currentRad - activeFollowerState.SmoothedLeaderRad) * (1f - (float)Math.Exp((double)(-(double)num2 * num)));
			bool flag = activeFollowerState.CurrentSide;
			if (@params.AutoChangeSide && @params.DynamicDistance > 0f && Math.Abs(currentRad * followerRadius) > @params.DynamicDistance && currentRad > 0f == flag)
			{
				flag = !flag;
				activeFollowerState.CurrentSide = flag;
			}
			float num3 = (flag ? activeFollowerState.Params.SideDistance.Item2 : activeFollowerState.Params.SideDistance.Item1) / followerRadius;
			float num4 = activeFollowerState.SmoothedLeaderRad + (flag ? num3 : (-num3));
			float num5 = Math.Abs(activeFollowerState.LastDist - characterRailSlideComponent.GetCurrentRailDistance());
			float num6 = 80f;
			if (num5 < num6)
			{
				float num7 = num6 / followerRadius;
				if (Math.Abs(num4 - activeFollowerState.SmoothedLeaderRad) < num7)
				{
					num4 = activeFollowerState.SmoothedLeaderRad + (flag ? num7 : (-num7));
				}
			}
			float maxAngVel = effectiveMaxLinearVelocity / followerRadius;
			float num8 = this.StepFollowerApproach(followerCurrentRad, num4, followerRadius, num, maxAngVel, @params.ToleranceDistance, activeFollowerState);
			if (num5 < num6)
			{
				float num9 = num6 / followerRadius;
				if (Math.Abs(num8 - currentRad) < num9)
				{
					num8 = currentRad + (flag ? num9 : (-num9));
					activeFollowerState.RadVelocity = 0f;
				}
			}
			return num8;
		}

		// Token: 0x06030C47 RID: 199751 RVA: 0x00C0C080 File Offset: 0x00C0A280
		private float StepFollowerApproach(float current, float target, float radius, float dt, float maxAngVel, float toleranceDist, CharacterRailSlideController.IActiveFollowerState activeData)
		{
			float value = target - current;
			float num = Math.Abs(value) * radius;
			bool flag = Math.Abs(activeData.RadVelocity) < 0.001f;
			float num2 = 3f;
			float num3 = 5f;
			float num4;
			if (flag && num < toleranceDist)
			{
				num4 = 0f;
			}
			else if (!flag && num < toleranceDist * 0.5f)
			{
				num4 = 0f;
			}
			else
			{
				num4 = (float)Math.Sign(value) * Math.Min(maxAngVel, Math.Abs(value) * num2);
			}
			float num5 = maxAngVel * num3;
			float value2 = num4 - activeData.RadVelocity;
			float num6 = num5 * dt;
			if (Math.Abs(value2) > num6)
			{
				activeData.RadVelocity += (float)Math.Sign(value2) * num6;
			}
			else
			{
				activeData.RadVelocity = num4;
			}
			if (Math.Abs(activeData.RadVelocity) < 0.001f)
			{
				activeData.RadVelocity = 0f;
				return current;
			}
			float num7 = activeData.RadVelocity * dt;
			if (Math.Abs(num7) >= Math.Abs(value))
			{
				activeData.RadVelocity = 0f;
				return target;
			}
			return current + num7;
		}

		// Token: 0x06030C48 RID: 199752 RVA: 0x00C0C196 File Offset: 0x00C0A396
		public void RemoveActiveFollower(int pbDataId)
		{
			this.ActiveFollowerMap.Remove(pbDataId);
		}

		// Token: 0x06030C49 RID: 199753 RVA: 0x00C0C1A8 File Offset: 0x00C0A3A8
		public float CalcParabolicHeight(IJumpProjectileParams projectileParams, float rate)
		{
			float num = rate * projectileParams.Length;
			return projectileParams.ProjectileA * num * num + projectileParams.ProjectileB * num;
		}

		// Token: 0x06030C4A RID: 199754 RVA: 0x00C0C1D4 File Offset: 0x00C0A3D4
		public IJumpProjectileParams CalcParabolicCoefficients(float h0, float linearDist, float splineLength, RailSlideParams config, float halfHeightOffset = 0f)
		{
			float num = (float)Math.Log10((double)Math.Max(1f, Math.Min((float)config.MaxJumpDistance, linearDist) * 0.01f)) * (float)config.MaxJumpHeight + (float)config.BaseJumpHeight + Math.Max(0f, h0) - halfHeightOffset;
			float num2 = (float)Math.Sqrt((double)(num * (num - h0)));
			float projectileB = 2f * (num + num2) / splineLength;
			float projectileA = -1f * (2f * num + 2f * num2 - h0) / (splineLength * splineLength);
			float allTime = (float)config.AllTimeForJump * 0.001f;
			return new JumpProjectileParams
			{
				Length = splineLength,
				Height0 = h0,
				AllTime = allTime,
				ProjectileA = projectileA,
				ProjectileB = projectileB
			};
		}

		// Token: 0x06030C4B RID: 199755 RVA: 0x00C0C29C File Offset: 0x00C0A49C
		[return: Nullable(0)]
		public ValueTuple<float, float> CalcEnterRailDistance(float horSpeed, float verSpeed, float startDist, float splineLength, Vector startLocation, Vector nearestPoint, Vector direction, Vector gravityDirect, float halfHeight)
		{
			float height = Math.Max((float)Vector.PointPlaneDist(nearestPoint, startLocation, gravityDirect), halfHeight);
			float num = this.CalcHorizontalLandingDistance(horSpeed, verSpeed, height);
			float num2 = Math.Max(100f, num) + startDist;
			if (startDist == 0f)
			{
				float num3 = (float)Vector.PointPlaneDist(startLocation, nearestPoint, direction);
				if (num3 < 0f)
				{
					num2 = Math.Max(num2 + num3, 1f);
				}
			}
			if (num2 >= splineLength)
			{
				num2 = splineLength - 1f;
			}
			return new ValueTuple<float, float>(num2, num);
		}

		// Token: 0x06030C4C RID: 199756 RVA: 0x00C0C318 File Offset: 0x00C0A518
		public SplineCurve BuildTwoPointSplineCurve(Vector start, Vector end, Vector startTangent = null)
		{
			InterpCurvePointVector interpCurvePointVector = new InterpCurvePointVector((startTangent != null) ? global::EInterpCurveMode.CurveAutoClamped : global::EInterpCurveMode.Linear);
			interpCurvePointVector.InVal = 0f;
			interpCurvePointVector.OutVal.DeepCopy(start);
			if (startTangent != null)
			{
				interpCurvePointVector.ArriveTangent.DeepCopy(startTangent);
				interpCurvePointVector.LeaveTangent.DeepCopy(startTangent);
			}
			InterpCurvePointVector interpCurvePointVector2 = new InterpCurvePointVector(global::EInterpCurveMode.CurveAutoClamped);
			interpCurvePointVector2.InVal = 1f;
			interpCurvePointVector2.OutVal.DeepCopy(end);
			SplineCurve splineCurve = new SplineCurve(10);
			splineCurve.InitPoints(new List<InterpCurvePointVector>
			{
				interpCurvePointVector,
				interpCurvePointVector2
			}, null);
			return splineCurve;
		}

		// Token: 0x06030C4D RID: 199757 RVA: 0x00C0C3A4 File Offset: 0x00C0A5A4
		[return: Nullable(0)]
		public ValueTuple<float, float> CalcJumpOffsetWithCorrection(float startDist, float speed, RailSlideParams config, Vector startLocation, Vector nearestPoint, Vector direction, bool addBlendDistance, float splineLength)
		{
			ValueTuple<float, float> valueTuple = this.CalcJumpOffsetDistance(startDist, speed, config, addBlendDistance);
			float item = valueTuple.Item1;
			float item2 = valueTuple.Item2;
			float num = item;
			if (startDist == 0f)
			{
				double num2 = Vector.PointPlaneDist(startLocation, nearestPoint, direction);
				if (num2 < 0.0)
				{
					num = Math.Max(100f, (float)((double)num + num2));
				}
			}
			if (num >= splineLength)
			{
				num = splineLength - 1f;
			}
			return new ValueTuple<float, float>(num, item2);
		}

		// Token: 0x06030C4E RID: 199758 RVA: 0x00C0C410 File Offset: 0x00C0A610
		private float CalcHorizontalLandingDistance(float horSpeed, float verSpeed, float height)
		{
			float num = Math.Max(0f, height);
			float num2 = verSpeed * 0.0010204081f;
			return ((float)Math.Sqrt((double)(num2 * num2 + 2f * num * 0.0010204081f)) - num2) * horSpeed;
		}

		// Token: 0x06030C4F RID: 199759 RVA: 0x00C0C450 File Offset: 0x00C0A650
		[NullableContext(0)]
		private ValueTuple<float, float> CalcJumpOffsetDistance(float startDist, float speed, [Nullable(1)] RailSlideParams config, bool addBlendDistance)
		{
			int jumpAcceleration = config.JumpAcceleration;
			int targetSpeedForJump = config.TargetSpeedForJump;
			float num = (float)config.JumpBlendTime * 0.001f;
			float num2 = Math.Abs(((float)targetSpeedForJump - speed) / (float)jumpAcceleration);
			float num3 = 0f;
			float num4 = startDist;
			if (addBlendDistance)
			{
				if (num2 > num)
				{
					num3 = speed * num + (float)jumpAcceleration * num * num * 0.5f;
				}
				else
				{
					num3 = speed * num2 + (float)jumpAcceleration * num2 * num2 * 0.5f + (float)targetSpeedForJump * (num - num2);
				}
				num4 += num3;
			}
			num4 += (float)(targetSpeedForJump * config.AllTimeForJump) * 0.001f * config.BaseJumpDistanceRate;
			return new ValueTuple<float, float>(Math.Max(100f, num4), num3);
		}

		// Token: 0x06030C50 RID: 199760 RVA: 0x00C0C504 File Offset: 0x00C0A704
		[return: Nullable(0)]
		public ValueTuple<float, float> CalcSlopeAngle(Vector moveDirection, Vector gravityUp)
		{
			float num = (float)moveDirection.DotProduct(gravityUp);
			return new ValueTuple<float, float>(Math.Abs((float)Math.Acos((double)Math.Max(-1f, Math.Min(1f, num))) * 57.29578f - 90f), num);
		}

		// Token: 0x06030C51 RID: 199761 RVA: 0x00C0C550 File Offset: 0x00C0A750
		[return: Nullable(0)]
		public ValueTuple<float, float, float> DecomposeVelocity(Vector velocity, Vector tangentDirection, Vector gravityDirect, float fallbackHorSpeed)
		{
			bool flag = velocity.IsNearlyZero(9.999999747378752E-05);
			float num = (float)velocity.DotProduct(tangentDirection);
			object obj = (num > 0f && !flag) ? num : fallbackHorSpeed;
			float num2 = (float)velocity.DotProduct(gravityDirect);
			float num3 = (num2 > 0f && !flag) ? num2 : 0f;
			object obj2 = obj;
			float item = (float)Math.Sqrt(obj2 * obj2 + num3 * num3);
			return new ValueTuple<float, float, float>(obj2, num3, item);
		}

		// Token: 0x06030C52 RID: 199762 RVA: 0x00C0C5BC File Offset: 0x00C0A7BC
		public float CalcSpeedStep(float currentSpeed, float targetSpeed, float acceleration, float deltaMs, float slopeAngle, float maxSlopeAngle)
		{
			float num = Math.Min(slopeAngle, maxSlopeAngle) / maxSlopeAngle;
			float num2 = deltaMs * Math.Min(Math.Abs(acceleration), Math.Abs(targetSpeed)) * 0.001f * ((slopeAngle > 1f) ? num : 1f);
			float num3 = currentSpeed - targetSpeed;
			if (Math.Abs(num3) > num2)
			{
				return currentSpeed + ((num3 > 0f) ? (-num2) : num2);
			}
			return targetSpeed;
		}

		// Token: 0x06030C53 RID: 199763 RVA: 0x00C0C624 File Offset: 0x00C0A824
		public void StepDampedOscillator(IRailControlData data, float input, float deltaMs)
		{
			float num = deltaMs * 0.001f;
			float num2 = Math.Max(-1f, Math.Min(1f, input));
			float num3 = 1f;
			if (!data.IgnoreMaxAngle)
			{
				float num4 = Math.Abs(data.Rad) / data.MaxAngle;
				float num5 = Math.Max(0f, 1f - num4);
				num3 = ((num2 * data.Rad > 0f) ? (num5 * num5) : 1f);
			}
			float num6 = num2 * num3 * data.InputCoefficient - data.RegressionSpeed * data.Rad - data.Damping * data.AngularVelocity;
			float num7 = data.AngularVelocity + num6 * num;
			float num8 = (data.Radius > 1f) ? Math.Min(data.GetLimitLinearVelocity() / data.Radius, data.MaxAngularVelocity) : data.MaxAngularVelocity;
			num7 = Math.Max(-num8, Math.Min(num8, num7));
			float num9 = data.Rad + num7 * num;
			if (!data.IgnoreMaxAngle)
			{
				num9 = Math.Max(-data.MaxAngle, Math.Min(data.MaxAngle, num9));
				if ((num9 >= data.MaxAngle && num7 > 0f) || (num9 <= -data.MaxAngle && num7 < 0f))
				{
					num7 = 0f;
				}
			}
			data.Rad = num9;
			data.AngularVelocity = num7;
		}

		// Token: 0x06030C54 RID: 199764 RVA: 0x00C0C788 File Offset: 0x00C0A988
		public void CalcCircularArcOffset(IRailControlData data, Vector outOffset, Rotator outRotator, Vector tmpVector)
		{
			float num = data.Rad * 57.29578f;
			outOffset.DeepCopy(data.ToCenterVector);
			outOffset.RotateAngleAxis((double)num, data.SplineForwardVector, outOffset);
			tmpVector.DeepCopy(outOffset);
			if (!data.InnerArc)
			{
				tmpVector.UnaryNegation(tmpVector);
			}
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(data.SplineForwardVector, tmpVector, outRotator);
			outRotator.Normalize(outRotator);
			outOffset.MultiplyEqual((double)(-(double)data.Radius));
			outOffset.AdditionEqual(data.CenterLocation);
			tmpVector.MultiplyEqual((double)data.HalfHeight);
			outOffset.AdditionEqual(tmpVector);
			outOffset.SubtractionEqual(data.DefaultLocation);
		}

		// Token: 0x06030C55 RID: 199765 RVA: 0x00C0C832 File Offset: 0x00C0AA32
		public void DebugDrawSphere(bool debug, Vector location, FLinearColor color, float duration = 15f)
		{
			if (GlobalData.IsPlayInEditor && debug)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, location.ToUeVector(false), 20f, 10, new FLinearColor?(color), duration, 0f);
			}
		}

		// Token: 0x06030C56 RID: 199766 RVA: 0x00C0C862 File Offset: 0x00C0AA62
		public void DebugDrawArrow(bool debug, Vector start, Vector end, FLinearColor color)
		{
			if (GlobalData.IsPlayInEditor && debug)
			{
				UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, start.ToUeVector(false), end.ToUeVector(false), 100f, color, 0f, 0f);
			}
		}

		// Token: 0x06030C57 RID: 199767 RVA: 0x00C0C898 File Offset: 0x00C0AA98
		public void DebugDrawCurve(bool debug, SplineCurve curve, Vector outVector, FLinearColor color)
		{
		}

		// Token: 0x0401C053 RID: 114771
		private const float MS_TO_SECOUND = 0.001f;

		// Token: 0x0401C054 RID: 114772
		private const float CENTIMETER_TO_METER = 0.01f;

		// Token: 0x0401C055 RID: 114773
		private const float GRAVITY_ACCELERATION = 980f;

		// Token: 0x0401C056 RID: 114774
		private const float GRAVITY_ACCELERATION_RECIPROCAL = 0.0010204081f;

		// Token: 0x0401C057 RID: 114775
		private const float MIN_EFFECTIVE_RADIUS = 1f;

		// Token: 0x0401C058 RID: 114776
		private const float FOLLOWER_TOLERANCE_DIST = 20f;

		// Token: 0x0401C059 RID: 114777
		private const float SAFE_DISTANCE = 80f;

		// Token: 0x0401C05A RID: 114778
		private const float DEBUG_DRAW_RADIUS = 20f;

		// Token: 0x0401C05B RID: 114779
		private const float DEBUG_DRAW_DURATION = 15f;

		// Token: 0x0401C05C RID: 114780
		private const int DEBUG_DRAW_SEGMENTS = 10;

		// Token: 0x0401C05D RID: 114781
		private const float MIN_ENTER_RAIL_DISTANCE = 100f;

		// Token: 0x0401C05E RID: 114782
		private readonly Dictionary<int, int> EntityRailMap = new Dictionary<int, int>();

		// Token: 0x0401C05F RID: 114783
		private readonly Dictionary<int, int> RailToEntityMap = new Dictionary<int, int>();

		// Token: 0x0401C060 RID: 114784
		private readonly Dictionary<int, CharacterRailSlideController.IActiveFollowerState> ActiveFollowerMap = new Dictionary<int, CharacterRailSlideController.IActiveFollowerState>();

		// Token: 0x0401C061 RID: 114785
		private readonly Dictionary<int, List<CharacterRailSlideController.RailFollowerEntry>> RailFollowerMap = new Dictionary<int, List<CharacterRailSlideController.RailFollowerEntry>>();

		// Token: 0x0200A9B0 RID: 43440
		private interface IActiveFollowerState
		{
			// Token: 0x1700A935 RID: 43317
			// (get) Token: 0x0604B210 RID: 307728
			// (set) Token: 0x0604B211 RID: 307729
			RailSlideFollowerParams Params { get; set; }

			// Token: 0x1700A936 RID: 43318
			// (get) Token: 0x0604B212 RID: 307730
			// (set) Token: 0x0604B213 RID: 307731
			float LastDist { get; set; }

			// Token: 0x1700A937 RID: 43319
			// (get) Token: 0x0604B214 RID: 307732
			// (set) Token: 0x0604B215 RID: 307733
			bool CurrentSide { get; set; }

			// Token: 0x1700A938 RID: 43320
			// (get) Token: 0x0604B216 RID: 307734
			// (set) Token: 0x0604B217 RID: 307735
			float RadVelocity { get; set; }

			// Token: 0x1700A939 RID: 43321
			// (get) Token: 0x0604B218 RID: 307736
			// (set) Token: 0x0604B219 RID: 307737
			float SmoothedLeaderRad { get; set; }
		}

		// Token: 0x0200A9B1 RID: 43441
		[Nullable(0)]
		private class ActiveFollowerState : CharacterRailSlideController.IActiveFollowerState
		{
			// Token: 0x1700A93A RID: 43322
			// (get) Token: 0x0604B21A RID: 307738 RVA: 0x0147364F File Offset: 0x0147184F
			// (set) Token: 0x0604B21B RID: 307739 RVA: 0x01473657 File Offset: 0x01471857
			public RailSlideFollowerParams Params { get; set; }

			// Token: 0x1700A93B RID: 43323
			// (get) Token: 0x0604B21C RID: 307740 RVA: 0x01473660 File Offset: 0x01471860
			// (set) Token: 0x0604B21D RID: 307741 RVA: 0x01473668 File Offset: 0x01471868
			public float LastDist { get; set; }

			// Token: 0x1700A93C RID: 43324
			// (get) Token: 0x0604B21E RID: 307742 RVA: 0x01473671 File Offset: 0x01471871
			// (set) Token: 0x0604B21F RID: 307743 RVA: 0x01473679 File Offset: 0x01471879
			public bool CurrentSide { get; set; }

			// Token: 0x1700A93D RID: 43325
			// (get) Token: 0x0604B220 RID: 307744 RVA: 0x01473682 File Offset: 0x01471882
			// (set) Token: 0x0604B221 RID: 307745 RVA: 0x0147368A File Offset: 0x0147188A
			public float RadVelocity { get; set; }

			// Token: 0x1700A93E RID: 43326
			// (get) Token: 0x0604B222 RID: 307746 RVA: 0x01473693 File Offset: 0x01471893
			// (set) Token: 0x0604B223 RID: 307747 RVA: 0x0147369B File Offset: 0x0147189B
			public float SmoothedLeaderRad { get; set; }
		}

		// Token: 0x0200A9B2 RID: 43442
		[Nullable(0)]
		private class RailFollowerEntry
		{
			// Token: 0x04034887 RID: 215175
			public int PbDataId;

			// Token: 0x04034888 RID: 215176
			public RailSlideFollowerParams Params;

			// Token: 0x04034889 RID: 215177
			public string DaPath;

			// Token: 0x0403488A RID: 215178
			public int RailId;
		}
	}
}
