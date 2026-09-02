using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Framework;
using UnrealEngine;

// Token: 0x02001C8F RID: 7311
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class FreezeOnSightController : ControllerBase<FreezeOnSightController>
{
	// Token: 0x0600D600 RID: 54784 RVA: 0x00392020 File Offset: 0x00390220
	protected override bool OnInit()
	{
		base.InitTickOptimize(-1, 1);
		GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig("FreezeOnSight.SearchRange", true);
		float value;
		if (config != null && float.TryParse(config.Value.Value, out value))
		{
			this.SearchRange = new float?(value);
		}
		GlobalConfigFromCsv? config2 = ConfigGlobalConfigFromCsvByName.GetConfig("FreezeOnSight.AddBuffDist", true);
		float value2;
		if (config2 != null && float.TryParse(config2.Value.Value, out value2))
		{
			this.AddBuffDist = new float?(value2);
		}
		base.PauseTick();
		return true;
	}

	// Token: 0x0600D601 RID: 54785 RVA: 0x003920B0 File Offset: 0x003902B0
	protected override void OnTick(float delta)
	{
		if (this.SearchRange == null)
		{
			return;
		}
		this.QueryMonsterResultCache.Clear();
		ModelBase<CreatureModel>.Instance.GetEntitiesInRange(this.SearchRange.Value, EEntityTypeQuery.PasserbyNPC, this.QueryMonsterResultCache, true, false);
		double num = 3.402823466E+38;
		bool flag = false;
		float viewAngleDeg = 0f;
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.CH, "[FreezeOnSightController] 玩家不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CharacterActorComponent component = worldEntity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return;
		}
		global::Vector vector = new global::Vector();
		vector.DeepCopy(component.ActorLocationProxy);
		foreach (EntityHandle entityHandle in this.QueryMonsterResultCache)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null)
			{
				CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
				if (component2 != null && component2.GetTemplateId() == 947850000)
				{
					BaseTagComponent component3 = entity.GetComponent<BaseTagComponent>();
					if (component3 != null && component3.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
					{
						CharacterActorComponent component4 = entity.GetComponent<CharacterActorComponent>();
						if (component4 != null)
						{
							global::Vector vector2 = new global::Vector();
							vector2.DeepCopy(component4.ActorLocationProxy);
							double num2 = global::Vector.Distance(vector, vector2);
							if (num2 < num)
							{
								num = num2;
								flag = this.IsBlock(component4, component);
								if (!flag)
								{
									viewAngleDeg = this.GetPlayerToMonsterViewAngleDeg(component, component4);
								}
							}
						}
					}
				}
			}
		}
		bool flag2 = this.HasTarget(num);
		bool flag3 = this.HasTarget(this.LastDistance);
		if (flag2 != flag3 || flag2)
		{
			this.ProcessAudioEvent(flag2, flag3, flag, num, viewAngleDeg);
		}
		this.LastDistance = num;
	}

	// Token: 0x0600D602 RID: 54786 RVA: 0x00392280 File Offset: 0x00390480
	private bool HasTarget(double dist)
	{
		return dist != 3.402823466E+38;
	}

	// Token: 0x0600D603 RID: 54787 RVA: 0x00392294 File Offset: 0x00390494
	private void ProcessAudioEvent(bool hasTarget, bool lastHasTarget, bool isBlock, double distance, float viewAngleDeg)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity != null)
		{
			BaseBuffComponent component = worldEntity.GetComponent<BaseBuffComponent>();
			float valueOrDefault = this.AddBuffDist.GetValueOrDefault(500f);
			if (hasTarget && distance < (double)valueOrDefault)
			{
				if (!component.HasBuff(640031030L, false))
				{
					Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CH, "[FreezeOnSightController] 发现目标", default(ReadOnlySpan<ValueTuple<string, object>>));
					if (component != null)
					{
						component.AddBuff(640031030L, new AddBuffParam
						{
							InstigatorId = component.CreatureDataId,
							Reason = "ActorAssistant.ControlBindingEntity"
						});
					}
				}
			}
			else if (component.HasBuff(640031030L, false))
			{
				Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CH, "[FreezeOnSightController] 失去目标", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (component != null)
				{
					component.RemoveBuff(640031030L, -1, "ActorAssistant.ControlBindingEntity", null, null, null);
				}
			}
		}
		if (hasTarget)
		{
			Singleton<AudioSystem>.Instance.SetRtpcValue("woodman_heartbeat", (float)Math.Min(distance, 1500.0), null);
			Singleton<AudioSystem>.Instance.SetRtpcValue("woodman_block", isBlock > false, null);
			Singleton<AudioSystem>.Instance.SetRtpcValue("woodman_azimuth", viewAngleDeg, null);
			return;
		}
		Singleton<AudioSystem>.Instance.SetRtpcValue("woodman_heartbeat", 1500f, null);
		Singleton<AudioSystem>.Instance.SetRtpcValue("woodman_block", 0f, null);
		Singleton<AudioSystem>.Instance.SetRtpcValue("woodman_azimuth", 0f, null);
	}

	// Token: 0x0600D604 RID: 54788 RVA: 0x0039245C File Offset: 0x0039065C
	private float GetPlayerToMonsterViewAngleDeg(CharacterActorComponent playerActorComponent, CharacterActorComponent monsterActorComponent)
	{
		global::Vector inB = global::Vector.Create(playerActorComponent.ActorLocationProxy);
		global::Vector.Create(monsterActorComponent.ActorLocationProxy).Subtraction(inB, this.TmpToMonsterDir);
		this.TmpToMonsterDir.Z = 0.0;
		if (this.TmpToMonsterDir.Size() < 0.0001)
		{
			return 0f;
		}
		this.TmpToMonsterDir.Normalize(9.99999993922529E-09);
		float num = (float)Singleton<MathUtils>.Instance.GetAngleByVector2D(this.TmpToMonsterDir);
		float yaw = playerActorComponent.ActorRotationProxy.Yaw;
		return Singleton<MathUtils>.Instance.WrapAngle(num - yaw);
	}

	// Token: 0x0600D605 RID: 54789 RVA: 0x00392500 File Offset: 0x00390700
	public void OpenFreezeOnSightGameplay()
	{
		base.ResumeTick();
		Singleton<AudioSystem>.Instance.PostEvent("play_gp_woodman_heartbeat_loop");
		Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CH, "开启木头人玩法", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600D606 RID: 54790 RVA: 0x00392540 File Offset: 0x00390740
	public void CloseFreezeOnSightGameplay()
	{
		base.PauseTick();
		Singleton<AudioSystem>.Instance.PostEvent("stop_gp_woodman_heartbeat_loop");
		Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CH, "关闭木头人玩法", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600D607 RID: 54791 RVA: 0x00392580 File Offset: 0x00390780
	public bool IsBlock(CharacterActorComponent monsterActorComponent, CharacterActorComponent playerActorComponent)
	{
		global::Vector vector = global::Vector.Create(monsterActorComponent.ActorLocationProxy);
		float halfHeight = monsterActorComponent.HalfHeight;
		vector.Z += (double)halfHeight;
		global::Vector vector2 = global::Vector.Create(playerActorComponent.ActorLocationProxy);
		float halfHeight2 = playerActorComponent.HalfHeight;
		vector2.Z += (double)halfHeight2;
		UTraceLineElement traceElement = this.GetTraceElement();
		traceElement.ActorsToIgnore.Empty(true);
		traceElement.ActorsToIgnore.Add(monsterActorComponent.Owner);
		traceElement.ActorsToIgnore.Add(playerActorComponent.Owner);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(traceElement, vector2);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(traceElement, vector);
		return Singleton<TraceElementCommon>.Instance.LineTrace(traceElement, "FreezeOnSightController.IsBlock");
	}

	// Token: 0x0600D608 RID: 54792 RVA: 0x00392638 File Offset: 0x00390838
	private UTraceLineElement GetTraceElement()
	{
		if (this.TraceElement != null)
		{
			return this.TraceElement;
		}
		this.TraceElement = new UTraceLineElement();
		this.TraceElement.bTraceComplex = true;
		this.TraceElement.bIgnoreSelf = true;
		this.TraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		this.TraceElement.WorldContextObject = GlobalData.World;
		return this.TraceElement;
	}

	// Token: 0x04006577 RID: 25975
	private const int FREEZE_ON_SIGHT_MONSTER_TEMPLATE_ID = 947850000;

	// Token: 0x04006578 RID: 25976
	private const int SCENE_EFFECT_BUFF_ID = 640031030;

	// Token: 0x04006579 RID: 25977
	private const string START_HEART_BEAT_AUDIO_EVENT = "play_gp_woodman_heartbeat_loop";

	// Token: 0x0400657A RID: 25978
	private const string STOP_HEART_BEAT_AUDIO_EVENT = "stop_gp_woodman_heartbeat_loop";

	// Token: 0x0400657B RID: 25979
	private const string HERAT_BEAT_DISTANCE_RTPC_EVENT = "woodman_heartbeat";

	// Token: 0x0400657C RID: 25980
	private const string HERAT_BEAT_BLOCK_RTPC_EVENT = "woodman_block";

	// Token: 0x0400657D RID: 25981
	private const string HERAT_BEAT_AZIMUTH_RTPC_EVENT = "woodman_azimuth";

	// Token: 0x0400657E RID: 25982
	private const float MAX_DISTANCE_RTPC_VALUE = 1500f;

	// Token: 0x0400657F RID: 25983
	private const float MAX_DISTANCE_ADD_BUFF = 500f;

	// Token: 0x04006580 RID: 25984
	private float? SearchRange;

	// Token: 0x04006581 RID: 25985
	private float? AddBuffDist;

	// Token: 0x04006582 RID: 25986
	private readonly List<EntityHandle> QueryMonsterResultCache = new List<EntityHandle>();

	// Token: 0x04006583 RID: 25987
	private double LastDistance = 3.402823466E+38;

	// Token: 0x04006584 RID: 25988
	[Nullable(2)]
	private UTraceLineElement TraceElement;

	// Token: 0x04006585 RID: 25989
	private global::Vector TmpToMonsterDir = global::Vector.Create();
}
