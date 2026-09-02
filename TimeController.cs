using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x0200347D RID: 13437
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class TimeController : ControllerBase<TimeController>
{
	// Token: 0x0601C573 RID: 116083 RVA: 0x0087D3F8 File Offset: 0x0087B5F8
	protected override bool OnInit()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.WorldDone;
		Action handle;
		if ((handle = TimeController.<>O.<0>__OnWorldDone) == null)
		{
			handle = (TimeController.<>O.<0>__OnWorldDone = new Action(TimeController.OnWorldDone));
		}
		instance.Add(name, handle);
		Singleton<EventSystem>.Instance.Add(EEventName.CharBornFinished, new Action<int>(this.OnCharBornFinished));
		return true;
	}

	// Token: 0x0601C574 RID: 116084 RVA: 0x0087D44D File Offset: 0x0087B64D
	protected override void OnTick(float delta)
	{
	}

	// Token: 0x0601C575 RID: 116085 RVA: 0x0087D450 File Offset: 0x0087B650
	protected override bool OnClear()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.WorldDone;
		Action handle;
		if ((handle = TimeController.<>O.<0>__OnWorldDone) == null)
		{
			handle = (TimeController.<>O.<0>__OnWorldDone = new Action(TimeController.OnWorldDone));
		}
		instance.Remove(name, handle);
		Singleton<EventSystem>.Instance.Remove(EEventName.CharBornFinished, new Action<int>(this.OnCharBornFinished));
		if (this._timeCheckTimerId != null)
		{
			TimerSystem.Instance.Remove(this._timeCheckTimerId);
			this._timeCheckTimerId = null;
		}
		return true;
	}

	// Token: 0x0601C576 RID: 116086 RVA: 0x0087D4C8 File Offset: 0x0087B6C8
	private static void OnWorldDone()
	{
		TimeController instance = ControllerBase<TimeController>.Instance;
		if (instance._timeCheckTimerId == null)
		{
			instance._timeCheckTimerId = TimerSystem.Instance.Forever(delegate(float _)
			{
				ControllerBase<TimeController>.Instance.TimeCheckRequest();
			}, 3000f, 1f, null, null, true);
		}
	}

	// Token: 0x0601C577 RID: 116087 RVA: 0x0087D520 File Offset: 0x0087B720
	public unsafe void TimeCheck(long lastClientTime, long serverTime, long serverStopTime, long flowTime, long combatTime)
	{
		double predictedServerCombatTimeOffset = this._predictedServerCombatTimeOffset;
		double predictedServerStopTimeOffset = this._predictedServerStopTimeOffset;
		this._predictedServerCombatTimeOffset = (double)combatTime - Singleton<Time>.Instance.FlowTime;
		this._predictedServerStopTimeOffset = (double)serverStopTime - Singleton<Time>.Instance.WorldTime;
		Singleton<Time>.Instance.SyncTime((double)serverTime, (double)flowTime, this._predictedServerCombatTimeOffset, this._predictedServerStopTimeOffset);
		Singleton<EventSystem>.Instance.Emit<double, double, double, double>(EEventName.TsSyncTime, (double)serverTime, (double)flowTime, this._predictedServerCombatTimeOffset, this._predictedServerStopTimeOffset);
		if (this._predictedServerStopTimeOffset - predictedServerStopTimeOffset > 3000.0 || this._predictedServerCombatTimeOffset - predictedServerCombatTimeOffset > 3000.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "对时通知";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("clientTime", lastClientTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("serverTime", serverTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("serverStopTime", serverStopTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("PredictedServerCombatTimeOffset", this._predictedServerCombatTimeOffset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("PredictedServerStopTimeOffset", this._predictedServerStopTimeOffset);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}
	}

	// Token: 0x0601C578 RID: 116088 RVA: 0x0087D688 File Offset: 0x0087B888
	public void TimeCheckNotify(TimeCheckNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		long clientTime = notify.ClientTime;
		long serverTime = notify.ServerTime;
		long sceneStopTime = notify.SceneStopTime;
		long flowTime = notify.FlowTime;
		long serverStopTime = notify.ServerStopTime;
		this.TimeCheck(clientTime, serverTime, sceneStopTime, flowTime, serverStopTime);
	}

	// Token: 0x0601C579 RID: 116089 RVA: 0x0087D6C8 File Offset: 0x0087B8C8
	public void TimeCheckRequest()
	{
		if (!Singleton<Net>.Instance.IsServerConnected())
		{
			return;
		}
		TimeCheckRequest timeCheckRequest = new TimeCheckRequest();
		timeCheckRequest.ClientTime = (long)Singleton<Time>.Instance.WorldTime;
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			timeCheckRequest.Dilation = Singleton<Time>.Instance.TimeDilation * UGameplayStatics.GetGlobalTimeDilation(GlobalData.World);
		}
		else
		{
			timeCheckRequest.Dilation = Singleton<Time>.Instance.TimeDilation;
		}
		timeCheckRequest.RDilation = Singleton<Time>.Instance.FlowTimeDilation;
		Singleton<Net>.Instance.Call<TimeCheckResponse>(ERequestMessageId.TimeCheckRequest, timeCheckRequest, new Action<TimeCheckResponse, Net.CallbackStatus>(this.<TimeCheckRequest>g__Response|14_0), 0);
	}

	// Token: 0x0601C57A RID: 116090 RVA: 0x0087D75F File Offset: 0x0087B95F
	private static float NormalizeTimeScale(float timeScale)
	{
		if (timeScale <= 0f)
		{
			return 0f;
		}
		return Singleton<MathUtils>.Instance.Clamp(timeScale, 0f, 1f);
	}

	// Token: 0x0601C57B RID: 116091 RVA: 0x0087D784 File Offset: 0x0087B984
	private static float CalcFinalTimeScale(IEnumerable<TimeStopInfo> list)
	{
		float num = 1f;
		bool flag = false;
		foreach (TimeStopInfo timeStopInfo in list)
		{
			flag = true;
			if (timeStopInfo.TimeScale <= 0f)
			{
				return 0f;
			}
			num = Math.Min(num, timeStopInfo.TimeScale);
		}
		if (!flag)
		{
			return 1f;
		}
		return num;
	}

	// Token: 0x0601C57C RID: 116092 RVA: 0x0087D800 File Offset: 0x0087BA00
	public bool AddLock(int instigatorId, bool stopMove, float timeScale = 0f)
	{
		if (this._instigatorList.ContainsKey(instigatorId))
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, (long)instigatorId, "同一实体重复添加时停，将不被处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this._instigatorList[instigatorId] = new TimeStopInfo
		{
			StopMove = stopMove,
			TimeScale = TimeController.NormalizeTimeScale(timeScale)
		};
		Entity entity = Singleton<EntitySystem>.Instance.Get(instigatorId);
		if (entity != null)
		{
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component != null)
			{
				component.AddNormalizeTimeScaleLock("ANS AbsoluteTimeStop Self", false);
			}
		}
		this.RefreshStopState();
		return true;
	}

	// Token: 0x0601C57D RID: 116093 RVA: 0x0087D88A File Offset: 0x0087BA8A
	public bool RemoveLock(int instigatorId)
	{
		if (!this._instigatorList.Remove(instigatorId))
		{
			return false;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(instigatorId);
		if (entity != null)
		{
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component != null)
			{
				component.RemoveNormalizeTimeScaleLock("ANS AbsoluteTimeStop Self", false);
			}
		}
		this.RefreshStopState();
		return true;
	}

	// Token: 0x0601C57E RID: 116094 RVA: 0x0087D8CC File Offset: 0x0087BACC
	private void RefreshStopState()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this._instigatorList.Clear();
		}
		List<int> list = new List<int>();
		foreach (int num in this._instigatorList.Keys)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(num);
			if (entity == null || !entity.Valid)
			{
				list.Add(num);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			int key = list[i];
			this._instigatorList.Remove(key);
		}
		bool flag = this._instigatorList.Count > 0;
		bool flag2 = this.IsFinalStopMove();
		float num2 = TimeController.CalcFinalTimeScale(this._instigatorList.Values);
		if (this._stopState == flag && !flag && this._lastAppliedStopMove == flag2 && this._lastAppliedStopScale == num2)
		{
			return;
		}
		this._stopState = flag;
		this._lastAppliedStopMove = flag2;
		this._lastAppliedStopScale = num2;
		if (this._stopState)
		{
			this.StopInner(flag2, num2);
			return;
		}
		this.RecoverInner();
	}

	// Token: 0x0601C57F RID: 116095 RVA: 0x0087DA00 File Offset: 0x0087BC00
	private bool IsFinalStopMove()
	{
		bool result = true;
		using (Dictionary<int, TimeStopInfo>.ValueCollection.Enumerator enumerator = this._instigatorList.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.StopMove)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x0601C580 RID: 116096 RVA: 0x0087DA60 File Offset: 0x0087BC60
	private void StopInner(bool stopMove, float stopScale)
	{
		List<EntityHandle> list = new List<EntityHandle>();
		ModelBase<CreatureModel>.Instance.GetEntitiesInRange(20000f, EEntityTypeQuery.Character, list, true, true);
		for (int i = 0; i < list.Count; i++)
		{
			EntityHandle entityHandle = list[i];
			if (entityHandle.IsInit)
			{
				if (this._instigatorList.ContainsKey(entityHandle.Id))
				{
					this.RecoverEntityInner(entityHandle);
				}
				else
				{
					EntityHandle entityHandle2 = entityHandle;
					CreatureModel instance = ModelBase<CreatureModel>.Instance;
					WorldEntity entity = entityHandle2.Entity;
					long? num;
					if (entity == null)
					{
						num = null;
					}
					else
					{
						CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
						num = ((component != null) ? new long?(component.GetSummonerId()) : null);
					}
					long? num2 = num;
					EntityHandle entity2 = instance.GetEntity(num2.GetValueOrDefault(-1L));
					bool flag = false;
					while (entity2 != null && entity2 != entityHandle2)
					{
						if (this._instigatorList.ContainsKey(entity2.Id))
						{
							flag = true;
							break;
						}
						entityHandle2 = entity2;
						CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
						WorldEntity entity3 = entity2.Entity;
						long? num3;
						if (entity3 == null)
						{
							num3 = null;
						}
						else
						{
							CreatureDataComponent component2 = entity3.GetComponent<CreatureDataComponent>();
							num3 = ((component2 != null) ? new long?(component2.GetSummonerId()) : null);
						}
						num2 = num3;
						entity2 = instance2.GetEntity(num2.GetValueOrDefault(-1L));
					}
					if (flag)
					{
						this.RecoverEntityInner(entityHandle);
					}
					else
					{
						this.StopEntityInner(entityHandle, stopMove, stopScale);
					}
				}
			}
		}
	}

	// Token: 0x0601C581 RID: 116097 RVA: 0x0087DBB0 File Offset: 0x0087BDB0
	private void RecoverInner()
	{
		List<EntityHandle> list = new List<EntityHandle>(this._timeStopAnimEntitySet);
		for (int i = 0; i < list.Count; i++)
		{
			EntityHandle entityHandle = list[i];
			if (entityHandle.Valid)
			{
				this.RecoverEntityInner(entityHandle);
			}
		}
	}

	// Token: 0x0601C582 RID: 116098 RVA: 0x0087DBF4 File Offset: 0x0087BDF4
	private void StopEntityInner(EntityHandle handle, bool stopMove, float stopScale)
	{
		this._timeStopAnimEntitySet.Add(handle);
		WorldEntity entity = handle.Entity;
		PawnTimeScaleComponent pawnTimeScaleComponent = (entity != null) ? entity.GetComponent<PawnTimeScaleComponent>() : null;
		WorldEntity entity2 = handle.Entity;
		BaseMoveComponent baseMoveComponent = (entity2 != null) ? entity2.GetComponent<BaseMoveComponent>() : null;
		if (pawnTimeScaleComponent != null)
		{
			pawnTimeScaleComponent.RemoveForceTimeScale("ANS AbsoluteTimeStop Other Scale", false);
		}
		if (pawnTimeScaleComponent != null)
		{
			pawnTimeScaleComponent.RemovePauseLock("ANS AbsoluteTimeStop Other");
		}
		if (baseMoveComponent != null)
		{
			baseMoveComponent.RemovePauseLock("ANS AbsoluteTimeStop Other");
		}
		this.RemoveCharacterBulletTimeScale(handle.Id);
		if (stopScale <= 0f)
		{
			if (pawnTimeScaleComponent != null)
			{
				pawnTimeScaleComponent.AddPauseLock("ANS AbsoluteTimeStop Other");
			}
			if (stopMove && baseMoveComponent != null)
			{
				baseMoveComponent.AddPauseLock("ANS AbsoluteTimeStop Other");
			}
			BulletUtil.FrozenCharacterBullet(handle.Id, null, 0f);
			return;
		}
		if (pawnTimeScaleComponent != null)
		{
			pawnTimeScaleComponent.AddForceTimeScale(stopScale, "ANS AbsoluteTimeStop Other Scale", false, ETimeScaleSourceType.InnerPauseLock);
		}
		BulletUtil.UnFrozenCharacterBullet(handle.Id, null);
		Dictionary<int, int> orCreateBulletScaleHandleMap = this.GetOrCreateBulletScaleHandleMap(handle.Id);
		BulletUtil.SetCharacterBulletTimeScale(handle.Id, stopScale, orCreateBulletScaleHandleMap, ETimeScaleSourceType.InnerPauseLock);
	}

	// Token: 0x0601C583 RID: 116099 RVA: 0x0087DCE0 File Offset: 0x0087BEE0
	private void RecoverEntityInner(EntityHandle handle)
	{
		this._timeStopAnimEntitySet.Remove(handle);
		WorldEntity entity = handle.Entity;
		PawnTimeScaleComponent pawnTimeScaleComponent = (entity != null) ? entity.GetComponent<PawnTimeScaleComponent>() : null;
		if (pawnTimeScaleComponent != null)
		{
			pawnTimeScaleComponent.RemoveForceTimeScale("ANS AbsoluteTimeStop Other Scale", false);
		}
		if (pawnTimeScaleComponent != null)
		{
			pawnTimeScaleComponent.RemovePauseLock("ANS AbsoluteTimeStop Other");
		}
		WorldEntity entity2 = handle.Entity;
		BaseMoveComponent baseMoveComponent = (entity2 != null) ? entity2.GetComponent<BaseMoveComponent>() : null;
		if (baseMoveComponent != null)
		{
			baseMoveComponent.RemovePauseLock("ANS AbsoluteTimeStop Other");
		}
		BulletUtil.UnFrozenCharacterBullet(handle.Id, null);
		this.RemoveCharacterBulletTimeScale(handle.Id);
	}

	// Token: 0x0601C584 RID: 116100 RVA: 0x0087DD68 File Offset: 0x0087BF68
	private Dictionary<int, int> GetOrCreateBulletScaleHandleMap(int entityId)
	{
		Dictionary<int, int> dictionary;
		if (!this._timeStopBulletScaleHandleMap.TryGetValue(entityId, out dictionary))
		{
			dictionary = new Dictionary<int, int>();
			this._timeStopBulletScaleHandleMap[entityId] = dictionary;
		}
		return dictionary;
	}

	// Token: 0x0601C585 RID: 116101 RVA: 0x0087DD9C File Offset: 0x0087BF9C
	private void RemoveCharacterBulletTimeScale(int entityId)
	{
		Dictionary<int, int> handleMap;
		if (!this._timeStopBulletScaleHandleMap.TryGetValue(entityId, out handleMap))
		{
			return;
		}
		BulletUtil.RemoveCharacterBulletTimeScale(entityId, handleMap);
		this._timeStopBulletScaleHandleMap.Remove(entityId);
	}

	// Token: 0x0601C586 RID: 116102 RVA: 0x0087DDD0 File Offset: 0x0087BFD0
	private void OnCharBornFinished(int entityId)
	{
		if (this._stopState)
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById != null && entityById.Valid)
			{
				this.StopEntityInner(entityById, this._lastAppliedStopMove, this._lastAppliedStopScale);
			}
		}
	}

	// Token: 0x0601C587 RID: 116103 RVA: 0x0087DE10 File Offset: 0x0087C010
	public bool AddTimeStopRequestLock(int instigatorId, float timeScale = 0f)
	{
		if (this._timeStopRequestInstigatorMap.ContainsKey(instigatorId))
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, (long)instigatorId, "同一实体重复添加副本时停请求，将不被处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this._timeStopRequestInstigatorMap[instigatorId] = new TimeStopInfo
		{
			StopMove = false,
			TimeScale = TimeController.NormalizeTimeScale(timeScale)
		};
		Entity entity = Singleton<EntitySystem>.Instance.Get(instigatorId);
		if (entity != null)
		{
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component != null)
			{
				component.AddNormalizeTimeScaleLock("TIME_STOP_REQUEST_SELF_LOCK", false);
			}
		}
		this.RefreshTimeStopRequestState();
		return true;
	}

	// Token: 0x0601C588 RID: 116104 RVA: 0x0087DE9A File Offset: 0x0087C09A
	public bool RemoveTimeStopRequestLock(int instigatorId)
	{
		if (!this._timeStopRequestInstigatorMap.Remove(instigatorId))
		{
			return false;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(instigatorId);
		if (entity != null)
		{
			PawnTimeScaleComponent component = entity.GetComponent<PawnTimeScaleComponent>();
			if (component != null)
			{
				component.RemoveNormalizeTimeScaleLock("TIME_STOP_REQUEST_SELF_LOCK", false);
			}
		}
		this.RefreshTimeStopRequestState();
		return true;
	}

	// Token: 0x0601C589 RID: 116105 RVA: 0x0087DEDC File Offset: 0x0087C0DC
	private void RefreshTimeStopRequestState()
	{
		float num = TimeController.CalcFinalTimeScale(this._timeStopRequestInstigatorMap.Values);
		if (this._timeStopRequestInstigatorMap.Count == 0)
		{
			this.StopTimeStopRequest();
			return;
		}
		if (this._timeStopRequestInstigatorMap.Count == 1 || this._lastAppliedRequestScale != num)
		{
			this.StartTimeStopRequest(num);
		}
	}

	// Token: 0x0601C58A RID: 116106 RVA: 0x0087DF2C File Offset: 0x0087C12C
	private void StartTimeStopRequest(float timeScale)
	{
		this._lastAppliedRequestScale = timeScale;
		float inverseSelfCenteredTimeDilation = ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
		float num = Singleton<MathUtils>.Instance.Clamp(timeScale, 0f, 1f);
		float flowTimeDilation = (timeScale <= 0f) ? 0f : (inverseSelfCenteredTimeDilation * num);
		Singleton<Time>.Instance.SetFlowTimeDilation(flowTimeDilation);
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			if (entityHandle.IsInit)
			{
				WorldEntity entity = entityHandle.Entity;
				CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
				if (characterBuffComponent != null)
				{
					characterBuffComponent.AddPauseLock("ANS AbsoluteTimeStop", timeScale);
				}
				this._timeStopBuffEntitySet.Add(entityHandle);
			}
		}
		ControllerBase<FormationAttributeController>.Instance.AddPauseLock("ANS AbsoluteTimeStop", timeScale);
		ControllerBase<SkillCdController>.Instance.Pause(ESkillCdPauseReason.AnsAbsoluteTimeStop, timeScale <= 0f);
	}

	// Token: 0x0601C58B RID: 116107 RVA: 0x0087E020 File Offset: 0x0087C220
	private void StopTimeStopRequest()
	{
		this._lastAppliedRequestScale = 1f;
		Singleton<Time>.Instance.SetFlowTimeDilation(ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		foreach (EntityHandle entityHandle in this._timeStopBuffEntitySet)
		{
			WorldEntity entity = entityHandle.Entity;
			CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
			if (characterBuffComponent != null)
			{
				characterBuffComponent.RemovePauseLock("ANS AbsoluteTimeStop");
			}
		}
		this._timeStopBuffEntitySet.Clear();
		ControllerBase<FormationAttributeController>.Instance.RemovePauseLock("ANS AbsoluteTimeStop");
		ControllerBase<SkillCdController>.Instance.Pause(ESkillCdPauseReason.AnsAbsoluteTimeStop, false);
	}

	// Token: 0x0601C58D RID: 116109 RVA: 0x0087E130 File Offset: 0x0087C330
	[NullableContext(2)]
	[CompilerGenerated]
	private void <TimeCheckRequest>g__Response|14_0(TimeCheckResponse response, Net.CallbackStatus callbackStatus)
	{
		if (response == null)
		{
			return;
		}
		long clientTime = response.ClientTime;
		long serverTime = response.ServerTime;
		long sceneStopTime = response.SceneStopTime;
		long flowTime = response.FlowTime;
		long serverStopTime = response.ServerStopTime;
		this.TimeCheck(clientTime, serverTime, sceneStopTime, flowTime, serverStopTime);
	}

	// Token: 0x0400E3EF RID: 58351
	private const int TIME_STOP_DISTANCE = 20000;

	// Token: 0x0400E3F0 RID: 58352
	private const string ABSOLUTE_TIME_STOP_TARGET_LOCK = "ANS AbsoluteTimeStop Other";

	// Token: 0x0400E3F1 RID: 58353
	private const string ABSOLUTE_TIME_STOP_SELF_LOCK = "ANS AbsoluteTimeStop Self";

	// Token: 0x0400E3F2 RID: 58354
	private const string ABSOLUTE_TIME_STOP_TARGET_SCALE_LOCK = "ANS AbsoluteTimeStop Other Scale";

	// Token: 0x0400E3F3 RID: 58355
	private const string TIME_STOP_REQUEST_SELF_LOCK = "TIME_STOP_REQUEST_SELF_LOCK";

	// Token: 0x0400E3F4 RID: 58356
	private double _predictedServerCombatTimeOffset;

	// Token: 0x0400E3F5 RID: 58357
	private double _predictedServerStopTimeOffset;

	// Token: 0x0400E3F6 RID: 58358
	[Nullable(2)]
	private TimerHandle _timeCheckTimerId;

	// Token: 0x0400E3F7 RID: 58359
	private Dictionary<int, TimeStopInfo> _instigatorList = new Dictionary<int, TimeStopInfo>();

	// Token: 0x0400E3F8 RID: 58360
	private HashSet<EntityHandle> _timeStopAnimEntitySet = new HashSet<EntityHandle>();

	// Token: 0x0400E3F9 RID: 58361
	private Dictionary<int, Dictionary<int, int>> _timeStopBulletScaleHandleMap = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x0400E3FA RID: 58362
	private bool _stopState;

	// Token: 0x0400E3FB RID: 58363
	private bool _lastAppliedStopMove = true;

	// Token: 0x0400E3FC RID: 58364
	private float _lastAppliedStopScale;

	// Token: 0x0400E3FD RID: 58365
	private HashSet<EntityHandle> _timeStopBuffEntitySet = new HashSet<EntityHandle>();

	// Token: 0x0400E3FE RID: 58366
	private Dictionary<int, TimeStopInfo> _timeStopRequestInstigatorMap = new Dictionary<int, TimeStopInfo>();

	// Token: 0x0400E3FF RID: 58367
	private float _lastAppliedRequestScale = 1f;

	// Token: 0x0200966C RID: 38508
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031A69 RID: 203369
		[Nullable(0)]
		public static Action <0>__OnWorldDone;
	}
}
