using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02000D15 RID: 3349
[NullableContext(1)]
[Nullable(0)]
public class AiScheduleGroup : IStaticVariableResetter
{
	// Token: 0x17000324 RID: 804
	// (get) Token: 0x060043EB RID: 17387 RVA: 0x00081EB2 File Offset: 0x000800B2
	private static List<AiScheduleGroup.AiAndScore> ScoreArray
	{
		get
		{
			return AiScheduleGroup._scoreArray;
		}
	}

	// Token: 0x17000325 RID: 805
	// (get) Token: 0x060043EC RID: 17388 RVA: 0x00081EB9 File Offset: 0x000800B9
	private static Dictionary<AiController, double> AngleMap
	{
		get
		{
			return AiScheduleGroup._angleMap;
		}
	}

	// Token: 0x17000326 RID: 806
	// (get) Token: 0x060043ED RID: 17389 RVA: 0x00081EC0 File Offset: 0x000800C0
	private static Dictionary<AiController, double> DistanceMap
	{
		get
		{
			return AiScheduleGroup._distanceMap;
		}
	}

	// Token: 0x17000327 RID: 807
	// (get) Token: 0x060043EE RID: 17390 RVA: 0x00081EC7 File Offset: 0x000800C7
	private static HashSet<AiController> NotDistributeAi
	{
		get
		{
			return AiScheduleGroup._notDistributeAi;
		}
	}

	// Token: 0x17000328 RID: 808
	// (get) Token: 0x060043EF RID: 17391 RVA: 0x00081ECE File Offset: 0x000800CE
	private static List<AiController> TmpDeleteArray
	{
		get
		{
			return AiScheduleGroup._tmpDeleteArray;
		}
	}

	// Token: 0x060043F0 RID: 17392 RVA: 0x00081ED8 File Offset: 0x000800D8
	public AiScheduleGroup(AiTeam aiTeam, EntityHandle target)
	{
		this.AiTeam = aiTeam;
		this.Target = target;
		int count = aiTeam.AiTeamAreas.Count;
		for (int i = 0; i < count; i++)
		{
			this.AreaAiList.Add(new List<AiController>());
		}
		WorldEntity entity = this.Target.Entity;
		this.TargetActorComp = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
	}

	// Token: 0x060043F1 RID: 17393 RVA: 0x00081FA0 File Offset: 0x000801A0
	[return: Nullable(2)]
	public AiAreaMemberData GetMemberData(AiController ai)
	{
		AiAreaMemberData result;
		if (!this.MemberDataMap.TryGetValue(ai, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x060043F2 RID: 17394 RVA: 0x00081FC0 File Offset: 0x000801C0
	public bool TryAdd(AiController ai)
	{
		if (this.MemberDataMap.ContainsKey(ai))
		{
			return false;
		}
		this.MemberDataMap[ai] = new AiAreaMemberData(this);
		this.HasNewMember = true;
		return true;
	}

	// Token: 0x060043F3 RID: 17395 RVA: 0x00081FEC File Offset: 0x000801EC
	public bool Remove(AiController ai)
	{
		if (!this.MemberDataMap.Remove(ai))
		{
			return false;
		}
		CharacterAiComponent charAiDesignComp = ai.CharAiDesignComp;
		if (charAiDesignComp != null && charAiDesignComp.Valid)
		{
			int id = ai.CharAiDesignComp.Entity.Id;
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(id, "TeamIndex");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(id, "TeamAttacker");
		}
		this.Attackers.Remove(ai);
		return true;
	}

	// Token: 0x060043F4 RID: 17396 RVA: 0x0008205C File Offset: 0x0008025C
	public bool IsEmpty()
	{
		return this.MemberDataMap.Count == 0;
	}

	// Token: 0x17000329 RID: 809
	// (get) Token: 0x060043F5 RID: 17397 RVA: 0x0008206C File Offset: 0x0008026C
	// (set) Token: 0x060043F6 RID: 17398 RVA: 0x00082074 File Offset: 0x00080274
	public EntityHandle Target { get; set; }

	// Token: 0x060043F7 RID: 17399 RVA: 0x00082080 File Offset: 0x00080280
	public void CheckTargetAndRemove()
	{
		foreach (AiController aiController in new List<AiController>(this.MemberDataMap.Keys))
		{
			if (!this.AiTeam.TeamMemberToGroup.ContainsKey(aiController))
			{
				this.MemberDataMap.Remove(aiController);
				this.Attackers.Remove(aiController);
			}
			else
			{
				EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
				if (currentTarget == null || !currentTarget.Valid || currentTarget != this.Target)
				{
					this.MemberDataMap.Remove(aiController);
					this.Attackers.Remove(aiController);
				}
			}
		}
	}

	// Token: 0x060043F8 RID: 17400 RVA: 0x00082148 File Offset: 0x00080348
	public void ScheduleGroup()
	{
		if ((double)this.NextScheduleMoveTime < Singleton<Time>.Instance.WorldTime || this.HasNewMember)
		{
			this.ScheduleMove();
		}
		else
		{
			this.RefreshAreaEntityLocation();
		}
		this.ScheduleAttack();
		this.HasNewMember = false;
	}

	// Token: 0x060043F9 RID: 17401 RVA: 0x00082180 File Offset: 0x00080380
	private void ScheduleMove()
	{
		AiTeamLevelNew? aiTeamLevel = this.AiTeam.AiTeamLevel;
		this.NextScheduleMoveTime = (float)(Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamLevel.Value.AllocationPeriodic.Value.Min, (double)aiTeamLevel.Value.AllocationPeriodic.Value.Max));
		ValueTuple<global::Vector, float, float> targetLocationYawRadius = this.GetTargetLocationYawRadius();
		global::Vector item = targetLocationYawRadius.Item1;
		float item2 = targetLocationYawRadius.Item2;
		float item3 = targetLocationYawRadius.Item3;
		AiScheduleGroup.AngleMap.Clear();
		AiScheduleGroup.DistanceMap.Clear();
		this.DistributeArea(item, item2);
		this.DistributeAngleAndDistance(item3);
		AiScheduleGroup.AngleMap.Clear();
		AiScheduleGroup.DistanceMap.Clear();
	}

	// Token: 0x060043FA RID: 17402 RVA: 0x0008224C File Offset: 0x0008044C
	private unsafe void DistributeArea(global::Vector targetLocation, float controllerYaw)
	{
		AiScheduleGroup.NotDistributeAi.Clear();
		double num = 1.0;
		foreach (AiController aiController in this.MemberDataMap.Keys)
		{
			global::Vector actorLocationProxy = aiController.CharActorComp.ActorLocationProxy;
			actorLocationProxy.Subtraction(targetLocation, AiScheduleGroup.TmpVector);
			float num2;
			for (num2 = Singleton<GravityUtils>.Instance.GetYawInInverseQuat(AiScheduleGroup.TmpVector, this.InverseGravityQuat) - controllerYaw; num2 > 180f; num2 -= 360f)
			{
			}
			while (-num2 > 180f)
			{
				num2 += 360f;
			}
			AiScheduleGroup.AngleMap[aiController] = (double)num2;
			double num3 = global::Vector.DistSquared2D(actorLocationProxy, targetLocation);
			if (num3 > num)
			{
				num = num3;
			}
			AiScheduleGroup.DistanceMap[aiController] = num3;
			AiScheduleGroup.NotDistributeAi.Add(aiController);
		}
		num += 1.0;
		int num4 = 0;
		foreach (AiTeamAreaNew aiTeamAreaNew in this.AiTeam.AiTeamAreas)
		{
			Dictionary<int, int> dictionary = this.AiTeam.AreaCharTypeToPriority[num4];
			Dictionary<int, int> dictionary2 = (num4 + 1 < this.AiTeam.AiTeamAreas.Count) ? this.AiTeam.AreaCharTypeToPriority[num4 + 1] : null;
			AiScheduleGroup.ScoreArray.Clear();
			foreach (AiController aiController2 in AiScheduleGroup.NotDistributeAi)
			{
				int num5;
				if (dictionary.TryGetValue(aiController2.AiBase.Value.MonsterType, out num5))
				{
					AiScheduleGroup.AiAndScore aiAndScore = AiScheduleGroup.AiAndScore.Get();
					aiAndScore.Ai = aiController2;
					aiAndScore.Score = (double)num5 + AiScheduleGroup.DistanceMap[aiController2] / num;
					AiScheduleGroup.ScoreArray.Add(aiAndScore);
				}
			}
			List<AiScheduleGroup.AiAndScore> scoreArray = AiScheduleGroup.ScoreArray;
			Comparison<AiScheduleGroup.AiAndScore> comparison;
			if ((comparison = AiScheduleGroup.<>O.<0>__Compare) == null)
			{
				comparison = (AiScheduleGroup.<>O.<0>__Compare = new Comparison<AiScheduleGroup.AiAndScore>(AiScheduleGroup.AiAndScore.Compare));
			}
			scoreArray.Sort(comparison);
			List<AiController> list = this.AreaAiList[num4];
			list.Clear();
			int num6 = 0;
			foreach (AiScheduleGroup.AiAndScore aiAndScore2 in AiScheduleGroup.ScoreArray)
			{
				if (num6 < aiTeamAreaNew.MaxCharacter || (dictionary2 == null || !dictionary2.ContainsKey(aiAndScore2.Ai.AiBase.Value.MonsterType)))
				{
					list.Add(aiAndScore2.Ai);
					AiScheduleGroup.NotDistributeAi.Remove(aiAndScore2.Ai);
				}
				num6++;
			}
			AiScheduleGroup.AiAndScore.ReleaseArray(AiScheduleGroup.ScoreArray);
			num4++;
		}
		if (AiScheduleGroup.NotDistributeAi.Count > 0)
		{
			using (HashSet<AiController>.Enumerator enumerator3 = AiScheduleGroup.NotDistributeAi.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					AiController aiController3 = enumerator3.Current;
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.AI;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "NotDistributeAi";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TeamId", this.AiTeam.AiTeamLevel.Value.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CharType", aiController3.AiBase.Value.MonsterType);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			foreach (AiController key in AiScheduleGroup.NotDistributeAi)
			{
				this.MemberDataMap[key].AreaIndex = -1;
			}
			AiScheduleGroup.NotDistributeAi.Clear();
		}
		num4 = 0;
		foreach (AiTeamAreaNew aiTeamAreaNew2 in this.AiTeam.AiTeamAreas)
		{
			foreach (AiController key2 in this.AreaAiList[num4])
			{
				AiAreaMemberData aiAreaMemberData = this.MemberDataMap[key2];
				aiAreaMemberData.NextUpdateCenterTime = (float)(Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamAreaNew2.ReactionTime.Value.Min, (double)aiTeamAreaNew2.ReactionTime.Value.Max));
				aiAreaMemberData.CachedTargetLocation.DeepCopy(targetLocation);
				aiAreaMemberData.CachedControllerYaw = controllerYaw;
			}
			num4++;
		}
	}

	// Token: 0x060043FB RID: 17403 RVA: 0x00082804 File Offset: 0x00080A04
	private void DistributeAngleAndDistance(float targetRadius)
	{
		int num = 0;
		float prevInZoneUsedAngle = 0f;
		foreach (AiTeamAreaNew aiTeamAreaNew in this.AiTeam.AiTeamAreas)
		{
			List<AiController> list = this.AreaAiList[num];
			if (list.Count == 0)
			{
				num++;
			}
			else
			{
				AiScheduleGroup.ScoreArray.Clear();
				foreach (AiController aiController in list)
				{
					AiScheduleGroup.AiAndScore aiAndScore = AiScheduleGroup.AiAndScore.Get();
					aiAndScore.Ai = aiController;
					aiAndScore.Score = AiScheduleGroup.AngleMap[aiController];
					AiScheduleGroup.ScoreArray.Add(aiAndScore);
				}
				List<AiScheduleGroup.AiAndScore> scoreArray = AiScheduleGroup.ScoreArray;
				Comparison<AiScheduleGroup.AiAndScore> comparison;
				if ((comparison = AiScheduleGroup.<>O.<0>__Compare) == null)
				{
					comparison = (AiScheduleGroup.<>O.<0>__Compare = new Comparison<AiScheduleGroup.AiAndScore>(AiScheduleGroup.AiAndScore.Compare));
				}
				scoreArray.Sort(comparison);
				for (int i = 0; i < AiScheduleGroup.ScoreArray.Count; i++)
				{
					list[i] = AiScheduleGroup.ScoreArray[i].Ai;
				}
				AiScheduleGroup.AiAndScore.ReleaseArray(AiScheduleGroup.ScoreArray);
				int num2 = Math.Min(list.Count, aiTeamAreaNew.MaxCharacter);
				int num3 = list.Count - num2;
				int num4 = (int)Math.Ceiling((double)num3 / 2.0);
				int num5 = num3 - num4;
				float num6 = (aiTeamAreaNew.AreaDistance.Value.Max - aiTeamAreaNew.AreaDistance.Value.Min) * 0.5f;
				float distanceCenter = targetRadius + aiTeamAreaNew.AreaDistance.Value.Min + num6;
				if (num4 > 0)
				{
					this.DistributeAngleAndDistanceOneSide(num, 0, num4, -180f, -aiTeamAreaNew.AreaAngle, 0.333f, AiScheduleGroup.EDistributeRule.RightFirst, false, distanceCenter, num6, 0f);
				}
				if (num2 > 0)
				{
					prevInZoneUsedAngle = this.DistributeAngleAndDistanceOneSide(num, num4, num4 + num2, -aiTeamAreaNew.AreaAngle, aiTeamAreaNew.AreaAngle, 2f, AiScheduleGroup.EDistributeRule.MiddleFirst, true, distanceCenter, num6, prevInZoneUsedAngle);
				}
				else
				{
					prevInZoneUsedAngle = 0f;
				}
				if (num5 > 0)
				{
					this.DistributeAngleAndDistanceOneSide(num, num4 + num2, list.Count, aiTeamAreaNew.AreaAngle, 180f, 0.333f, AiScheduleGroup.EDistributeRule.LeftFirst, false, distanceCenter, num6, 0f);
				}
				num++;
			}
		}
	}

	// Token: 0x060043FC RID: 17404 RVA: 0x00082A9C File Offset: 0x00080C9C
	private float DistributeAngleAndDistanceOneSide(int areaIndex, int startIndex, int endIndex, float startDegree, float endDegree, float maxAnglePerOneRadius, AiScheduleGroup.EDistributeRule distributeRule, bool inZone, float distanceCenter, float maxDistanceOffset, float prevInZoneUsedAngle = 0f)
	{
		List<AiController> list = this.AreaAiList[areaIndex];
		float num = 0f;
		for (int i = startIndex; i < endIndex; i++)
		{
			AiController aiController = list[i];
			num += Singleton<MathUtils>.Instance.Clamp(aiController.CharActorComp.Radius, 30f, 100f);
		}
		float num2 = Math.Min(maxAnglePerOneRadius, (endDegree - startDegree) / num);
		float num3;
		switch (distributeRule)
		{
		case AiScheduleGroup.EDistributeRule.RightFirst:
			num3 = endDegree - num2 * num;
			goto IL_98;
		case AiScheduleGroup.EDistributeRule.MiddleFirst:
			num3 = (startDegree + endDegree - num2 * num) * 0.5f;
			goto IL_98;
		}
		num3 = startDegree;
		IL_98:
		for (int j = startIndex; j < endIndex; j++)
		{
			AiController aiController2 = list[j];
			AiAreaMemberData aiAreaMemberData = this.MemberDataMap[aiController2];
			aiAreaMemberData.AreaIndex = areaIndex;
			aiAreaMemberData.InZone = inZone;
			aiAreaMemberData.MaxAngleOffset = num2 * Singleton<MathUtils>.Instance.Clamp(aiController2.CharActorComp.Radius, 30f, 100f) * 0.5f;
			aiAreaMemberData.AngleCenter = num3 + aiAreaMemberData.MaxAngleOffset;
			aiAreaMemberData.DistanceCenter = distanceCenter;
			aiAreaMemberData.MaxDistanceOffset = maxDistanceOffset;
			num3 += aiAreaMemberData.MaxAngleOffset * 2f;
		}
		return 0f;
	}

	// Token: 0x060043FD RID: 17405 RVA: 0x00082BE8 File Offset: 0x00080DE8
	private void RefreshAreaEntityLocation()
	{
		global::Vector vector = null;
		float cachedControllerYaw = 0f;
		int num = 0;
		foreach (AiTeamAreaNew aiTeamAreaNew in this.AiTeam.AiTeamAreas)
		{
			foreach (AiController key in this.AreaAiList[num])
			{
				AiAreaMemberData aiAreaMemberData;
				if (this.MemberDataMap.TryGetValue(key, out aiAreaMemberData) && Singleton<Time>.Instance.WorldTime > (double)aiAreaMemberData.NextUpdateCenterTime)
				{
					if (vector == null)
					{
						ValueTuple<global::Vector, float, float> targetLocationYawRadius = this.GetTargetLocationYawRadius();
						global::Vector item = targetLocationYawRadius.Item1;
						float item2 = targetLocationYawRadius.Item2;
						vector = item;
						cachedControllerYaw = item2;
					}
					aiAreaMemberData.NextUpdateCenterTime = (float)(Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamAreaNew.ReactionTime.Value.Min, (double)aiTeamAreaNew.ReactionTime.Value.Max));
					aiAreaMemberData.CachedTargetLocation.DeepCopy(vector);
					aiAreaMemberData.CachedControllerYaw = cachedControllerYaw;
				}
			}
			num++;
		}
	}

	// Token: 0x060043FE RID: 17406 RVA: 0x00082D5C File Offset: 0x00080F5C
	private void ScheduleAttack()
	{
		CharacterActorComponent targetActorComp = this.TargetActorComp;
		Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(targetActorComp, this.GravityQuat);
		this.GravityQuat.Inverse(this.InverseGravityQuat);
		AiScheduleGroup.ScoreArray.Clear();
		int newAttackerCount = this.DeleteAttackersAndCollectWatchers();
		this.SelectNewAttackers(newAttackerCount);
		AiScheduleGroup.AiAndScore.ReleaseArray(AiScheduleGroup.ScoreArray);
	}

	// Token: 0x060043FF RID: 17407 RVA: 0x00082DB4 File Offset: 0x00080FB4
	private int DeleteAttackersAndCollectWatchers()
	{
		AiTeamLevelNew? aiTeamLevel = this.AiTeam.AiTeamLevel;
		AiScheduleGroup.TmpDeleteArray.Clear();
		foreach (AiController aiController in this.Attackers)
		{
			AiAreaMemberData aiAreaMemberData = this.MemberDataMap[aiController];
			if (aiController.CharActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"]))
			{
				if (aiAreaMemberData.NextScheduleTimeBeAttack == null)
				{
					aiAreaMemberData.NextScheduleTimeBeAttack = new double?((double)((float)(Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamLevel.Value.BeAttackCountDown.Value.Min, (double)aiTeamLevel.Value.BeAttackCountDown.Value.Max))));
				}
				else if (aiAreaMemberData.NextScheduleTimeBeAttack.Value < Singleton<Time>.Instance.WorldTime)
				{
					AiScheduleGroup.TmpDeleteArray.Add(aiController);
					continue;
				}
			}
			else
			{
				aiAreaMemberData.NextScheduleTimeBeAttack = null;
			}
			if (!aiAreaMemberData.HasAttack)
			{
				if (aiAreaMemberData.NextScheduleTimeNoAttack < Singleton<Time>.Instance.WorldTime)
				{
					AiScheduleGroup.TmpDeleteArray.Add(aiController);
				}
				else if (aiController.CharActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
				{
					aiAreaMemberData.HasAttack = true;
					ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(aiController.CharAiDesignComp.Entity.Id, "TeamAttacker");
				}
			}
			else if (aiAreaMemberData.NextScheduleTimeAttack < Singleton<Time>.Instance.WorldTime && (!aiController.CharActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) || aiAreaMemberData.NextScheduleTimeOut < Singleton<Time>.Instance.WorldTime))
			{
				AiScheduleGroup.TmpDeleteArray.Add(aiController);
			}
		}
		int num = Math.Min(aiTeamLevel.Value.AttackerNum - (this.Attackers.Count - AiScheduleGroup.TmpDeleteArray.Count), this.MemberDataMap.Count - this.Attackers.Count);
		if (num > 0)
		{
			ValueTuple<global::Vector, float, float> targetLocationYawRadius = this.GetTargetLocationYawRadius();
			global::Vector item = targetLocationYawRadius.Item1;
			float item2 = targetLocationYawRadius.Item2;
			int num2 = 0;
			foreach (List<AiController> list in this.AreaAiList)
			{
				AiTeamAttack aiTeamAttack = this.AiTeam.AiTeamAttacks[num2];
				foreach (AiController aiController2 in list)
				{
					AiAreaMemberData valueOrDefault = this.MemberDataMap.GetValueOrDefault(aiController2);
					if (valueOrDefault != null && valueOrDefault.InZone && !valueOrDefault.IsAttacker && !aiController2.CharActorComp.Entity.CheckGetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
					{
						global::Vector actorLocationProxy = aiController2.CharActorComp.ActorLocationProxy;
						actorLocationProxy.Subtraction(item, AiScheduleGroup.TmpVector);
						float num3;
						for (num3 = Singleton<GravityUtils>.Instance.GetYawInInverseQuat(AiScheduleGroup.TmpVector, this.InverseGravityQuat) - item2; num3 > 180f; num3 -= 360f)
						{
						}
						while (-num3 > 180f)
						{
							num3 += 360f;
						}
						num3 = Math.Abs(num3);
						double num4 = Math.Abs(global::Vector.Dist2D(actorLocationProxy, item) - (double)valueOrDefault.DistanceCenter);
						double score = (double)(aiTeamAttack.ExtraWeight - aiTeamAttack.AngleCoefficient * num3 / (valueOrDefault.MaxAngleOffset * 2f)) - (double)aiTeamAttack.DistanceCoefficient * num4 / (double)(valueOrDefault.MaxDistanceOffset * 2f);
						AiScheduleGroup.AiAndScore aiAndScore = AiScheduleGroup.AiAndScore.Get();
						aiAndScore.Ai = aiController2;
						aiAndScore.Score = score;
						AiScheduleGroup.ScoreArray.Add(aiAndScore);
					}
				}
				num2++;
			}
			using (List<AiController>.Enumerator enumerator3 = AiScheduleGroup.TmpDeleteArray.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					AiController aiController3 = enumerator3.Current;
					this.MemberDataMap[aiController3].IsAttacker = false;
					this.Attackers.Remove(aiController3);
					ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(aiController3.CharAiDesignComp.Entity.Id, "TeamAttacker");
				}
				return num;
			}
		}
		foreach (AiController aiController4 in AiScheduleGroup.TmpDeleteArray)
		{
			AiAreaMemberData aiAreaMemberData2 = this.MemberDataMap[aiController4];
			aiAreaMemberData2.NextScheduleTimeAttack = (double)((float)(Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamLevel.Value.AttackCountDown.Value.Min, (double)aiTeamLevel.Value.AttackCountDown.Value.Max)));
			double randomRange = Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamLevel.Value.NoAttackCountDown.Value.Min, (double)aiTeamLevel.Value.NoAttackCountDown.Value.Max);
			aiAreaMemberData2.NextScheduleTimeNoAttack = Singleton<Time>.Instance.WorldTime + randomRange;
			aiAreaMemberData2.NextScheduleTimeOut = Singleton<Time>.Instance.WorldTime + randomRange * 2.0;
			aiAreaMemberData2.HasAttack = false;
			ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(aiController4.CharAiDesignComp.Entity.Id, "TeamAttacker", true);
		}
		return num;
	}

	// Token: 0x06004400 RID: 17408 RVA: 0x00083428 File Offset: 0x00081628
	private void SelectNewAttackers(int newAttackerCount)
	{
		List<AiScheduleGroup.AiAndScore> scoreArray = AiScheduleGroup.ScoreArray;
		Comparison<AiScheduleGroup.AiAndScore> comparison;
		if ((comparison = AiScheduleGroup.<>O.<0>__Compare) == null)
		{
			comparison = (AiScheduleGroup.<>O.<0>__Compare = new Comparison<AiScheduleGroup.AiAndScore>(AiScheduleGroup.AiAndScore.Compare));
		}
		scoreArray.Sort(comparison);
		int num = 0;
		int num2 = 0;
		int[] array = new int[6];
		foreach (AiScheduleGroup.AiAndScore aiAndScore in AiScheduleGroup.ScoreArray)
		{
			if (aiAndScore.Ai.AiBase.Value.MonsterType <= 3)
			{
				num++;
			}
			else
			{
				num2++;
			}
			array[aiAndScore.Ai.AiBase.Value.MonsterType - 1]++;
		}
		int[] array2 = new int[6];
		AiTeamLevelNew? aiTeamLevel = this.AiTeam.AiTeamLevel;
		for (int i = 0; i < newAttackerCount; i++)
		{
			bool flag;
			if (num > 0 && num2 > 0)
			{
				flag = (Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)(aiTeamLevel.Value.EliteRatio()[0] + aiTeamLevel.Value.EliteRatio()[1])) < (double)aiTeamLevel.Value.EliteRatio()[0]);
			}
			else if (num > 0)
			{
				flag = true;
			}
			else
			{
				if (num2 <= 0)
				{
					break;
				}
				flag = false;
			}
			int num3;
			if (flag)
			{
				num--;
				num3 = 0;
			}
			else
			{
				num2--;
				num3 = 3;
			}
			float num4 = 0f;
			int num5 = 0;
			for (int j = 0; j < 3; j++)
			{
				if (array[num3 + j] > 0)
				{
					num4 += aiTeamLevel.Value.RangeRatio()[j];
					if (Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)num4) < (double)aiTeamLevel.Value.RangeRatio()[j])
					{
						num5 = num3 + j;
					}
				}
			}
			array[num5]--;
			array2[num5]++;
		}
		for (int k = AiScheduleGroup.ScoreArray.Count - 1; k >= 0; k--)
		{
			AiScheduleGroup.AiAndScore aiAndScore2 = AiScheduleGroup.ScoreArray[k];
			if (array2[aiAndScore2.Ai.AiBase.Value.MonsterType - 1] > 0)
			{
				array2[aiAndScore2.Ai.AiBase.Value.MonsterType - 1]--;
				AiAreaMemberData aiAreaMemberData = this.MemberDataMap[aiAndScore2.Ai];
				aiAreaMemberData.IsAttacker = true;
				aiAreaMemberData.HasAttack = false;
				aiAreaMemberData.NextScheduleTimeAttack = Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamLevel.Value.AttackCountDown.Value.Min, (double)aiTeamLevel.Value.AttackCountDown.Value.Max);
				double randomRange = Singleton<MathUtils>.Instance.GetRandomRange((double)aiTeamLevel.Value.NoAttackCountDown.Value.Min, (double)aiTeamLevel.Value.NoAttackCountDown.Value.Max);
				aiAreaMemberData.NextScheduleTimeNoAttack = Singleton<Time>.Instance.WorldTime + randomRange;
				aiAreaMemberData.NextScheduleTimeOut = Singleton<Time>.Instance.WorldTime + randomRange * 2.0;
				aiAreaMemberData.NextScheduleTimeBeAttack = null;
				ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(aiAndScore2.Ai.CharAiDesignComp.Entity.Id, "TeamAttacker", true);
				this.Attackers.Add(aiAndScore2.Ai);
			}
		}
	}

	// Token: 0x06004401 RID: 17409 RVA: 0x000837F0 File Offset: 0x000819F0
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private ValueTuple<global::Vector, float, float> GetTargetLocationYawRadius()
	{
		CharacterActorComponent targetActorComp = this.TargetActorComp;
		CharacterInputComponent component = this.Target.Entity.GetComponent<CharacterInputComponent>();
		float item = 0f;
		if (component != null && component.Valid && component.CharacterController != null)
		{
			global::Vector tmpCtrlForward = AiScheduleGroup.TmpCtrlForward;
			FVector fvector = component.CharacterController.GetActorForwardVector();
			FVectorDouble fvectorDouble = fvector;
			tmpCtrlForward.DeepCopy(fvectorDouble);
			if (targetActorComp.MoveComp != null && !targetActorComp.MoveComp.IsStandardGravity && Math.Abs(targetActorComp.MoveComp.GravityUp.DotProduct(AiScheduleGroup.TmpCtrlForward)) > 0.9999)
			{
				global::Vector tmpCtrlForward2 = AiScheduleGroup.TmpCtrlForward;
				fvector = component.CharacterController.GetActorUpVector();
				fvectorDouble = fvector;
				tmpCtrlForward2.DeepCopy(fvectorDouble);
			}
			item = Singleton<GravityUtils>.Instance.GetYawInInverseQuat(AiScheduleGroup.TmpCtrlForward, this.InverseGravityQuat);
		}
		return new ValueTuple<global::Vector, float, float>(targetActorComp.ActorLocationProxy, item, targetActorComp.ScaledRadius);
	}

	// Token: 0x06004402 RID: 17410 RVA: 0x000838DB File Offset: 0x00081ADB
	static AiScheduleGroup()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AiScheduleGroup.CreateStaticDefaultValue), new Action(AiScheduleGroup.ResetStaticDefaultValue));
	}

	// Token: 0x06004403 RID: 17411 RVA: 0x0008390E File Offset: 0x00081B0E
	public static void CreateStaticDefaultValue()
	{
		AiScheduleGroup._scoreArray = new List<AiScheduleGroup.AiAndScore>();
		AiScheduleGroup._angleMap = new Dictionary<AiController, double>();
		AiScheduleGroup._distanceMap = new Dictionary<AiController, double>();
		AiScheduleGroup._notDistributeAi = new HashSet<AiController>();
		AiScheduleGroup._tmpDeleteArray = new List<AiController>();
	}

	// Token: 0x06004404 RID: 17412 RVA: 0x00083942 File Offset: 0x00081B42
	public static void ResetStaticDefaultValue()
	{
		AiScheduleGroup._scoreArray = null;
		AiScheduleGroup._angleMap = null;
		AiScheduleGroup._distanceMap = null;
		AiScheduleGroup._notDistributeAi = null;
		AiScheduleGroup._tmpDeleteArray = null;
	}

	// Token: 0x040011C4 RID: 4548
	private const string BLACKBOARD_KEY_AREA_INDEX = "TeamIndex";

	// Token: 0x040011C5 RID: 4549
	private const string BLACKBOARD_KEY_ATTACKER = "TeamAttacker";

	// Token: 0x040011C6 RID: 4550
	private const float MAX_OUT_ZONE_ANGLE_PER_ONE_RADIUS = 0.333f;

	// Token: 0x040011C7 RID: 4551
	private const float MAX_IN_ZONE_ANGLE_PER_ONE_RADIUS = 2f;

	// Token: 0x040011C8 RID: 4552
	private const int MAX_ELITE_TYPE = 3;

	// Token: 0x040011C9 RID: 4553
	private const int MAX_CHAR_TYPE = 6;

	// Token: 0x040011CA RID: 4554
	private const float MIN_RADIUS = 30f;

	// Token: 0x040011CB RID: 4555
	private const float MAX_RADIUS = 100f;

	// Token: 0x040011CC RID: 4556
	private const float MINUS_HALF_CIRCLE = -180f;

	// Token: 0x040011CD RID: 4557
	private readonly Dictionary<AiController, AiAreaMemberData> MemberDataMap = new Dictionary<AiController, AiAreaMemberData>();

	// Token: 0x040011CE RID: 4558
	[Nullable(2)]
	private readonly CharacterActorComponent TargetActorComp;

	// Token: 0x040011CF RID: 4559
	private readonly HashSet<AiController> Attackers = new HashSet<AiController>();

	// Token: 0x040011D0 RID: 4560
	private bool HasNewMember;

	// Token: 0x040011D1 RID: 4561
	private float NextScheduleMoveTime;

	// Token: 0x040011D2 RID: 4562
	private readonly List<List<AiController>> AreaAiList = new List<List<AiController>>();

	// Token: 0x040011D3 RID: 4563
	public readonly Quat GravityQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x040011D4 RID: 4564
	public readonly Quat InverseGravityQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x040011D5 RID: 4565
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<AiScheduleGroup.AiAndScore> _scoreArray;

	// Token: 0x040011D6 RID: 4566
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<AiController, double> _angleMap;

	// Token: 0x040011D7 RID: 4567
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<AiController, double> _distanceMap;

	// Token: 0x040011D8 RID: 4568
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static HashSet<AiController> _notDistributeAi;

	// Token: 0x040011D9 RID: 4569
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<AiController> _tmpDeleteArray;

	// Token: 0x040011DA RID: 4570
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpCtrlForward = global::Vector.Create();

	// Token: 0x040011DB RID: 4571
	[StaticVariableRuleIgnore]
	private static readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x040011DC RID: 4572
	private readonly AiTeam AiTeam;

	// Token: 0x0200720D RID: 29197
	[NullableContext(0)]
	private enum EDistributeRule
	{
		// Token: 0x04027A29 RID: 162345
		RightFirst,
		// Token: 0x04027A2A RID: 162346
		MiddleFirst,
		// Token: 0x04027A2B RID: 162347
		LeftFirst
	}

	// Token: 0x0200720E RID: 29198
	[Nullable(0)]
	public class AiAndScore : IStaticVariableResetter
	{
		// Token: 0x1700A773 RID: 42867
		// (get) Token: 0x06046844 RID: 288836 RVA: 0x012AED81 File Offset: 0x012ACF81
		private static List<AiScheduleGroup.AiAndScore> Pool
		{
			get
			{
				return AiScheduleGroup.AiAndScore._pool;
			}
		}

		// Token: 0x06046845 RID: 288837 RVA: 0x012AED88 File Offset: 0x012ACF88
		[NullableContext(2)]
		public static AiScheduleGroup.AiAndScore Get()
		{
			if (AiScheduleGroup.AiAndScore.Pool.Count == 0)
			{
				return new AiScheduleGroup.AiAndScore();
			}
			List<AiScheduleGroup.AiAndScore> pool = AiScheduleGroup.AiAndScore.Pool;
			AiScheduleGroup.AiAndScore result = pool[pool.Count - 1];
			AiScheduleGroup.AiAndScore.Pool.RemoveAt(AiScheduleGroup.AiAndScore.Pool.Count - 1);
			return result;
		}

		// Token: 0x06046846 RID: 288838 RVA: 0x012AEDC4 File Offset: 0x012ACFC4
		public static void Release(AiScheduleGroup.AiAndScore item)
		{
			item.Ai = null;
			AiScheduleGroup.AiAndScore.Pool.Add(item);
		}

		// Token: 0x06046847 RID: 288839 RVA: 0x012AEDD8 File Offset: 0x012ACFD8
		public static void ReleaseArray(List<AiScheduleGroup.AiAndScore> array)
		{
			foreach (AiScheduleGroup.AiAndScore aiAndScore in array)
			{
				aiAndScore.Ai = null;
				AiScheduleGroup.AiAndScore.Pool.Add(aiAndScore);
			}
			array.Clear();
		}

		// Token: 0x06046848 RID: 288840 RVA: 0x012AEE38 File Offset: 0x012AD038
		private AiAndScore()
		{
		}

		// Token: 0x06046849 RID: 288841 RVA: 0x012AEE40 File Offset: 0x012AD040
		public static int Compare(AiScheduleGroup.AiAndScore a, AiScheduleGroup.AiAndScore b)
		{
			return a.Score.CompareTo(b.Score);
		}

		// Token: 0x0604684A RID: 288842 RVA: 0x012AEE53 File Offset: 0x012AD053
		static AiAndScore()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(AiScheduleGroup.AiAndScore.CreateStaticDefaultValue), new Action(AiScheduleGroup.AiAndScore.ResetStaticDefaultValue));
		}

		// Token: 0x0604684B RID: 288843 RVA: 0x012AEE72 File Offset: 0x012AD072
		public static void CreateStaticDefaultValue()
		{
			AiScheduleGroup.AiAndScore._pool = new List<AiScheduleGroup.AiAndScore>();
		}

		// Token: 0x0604684C RID: 288844 RVA: 0x012AEE7E File Offset: 0x012AD07E
		public static void ResetStaticDefaultValue()
		{
			AiScheduleGroup.AiAndScore._pool = null;
		}

		// Token: 0x04027A2C RID: 162348
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static List<AiScheduleGroup.AiAndScore> _pool;

		// Token: 0x04027A2D RID: 162349
		[Nullable(2)]
		public AiController Ai;

		// Token: 0x04027A2E RID: 162350
		public double Score;
	}

	// Token: 0x0200720F RID: 29199
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027A2F RID: 162351
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<AiScheduleGroup.AiAndScore> <0>__Compare;
	}
}
