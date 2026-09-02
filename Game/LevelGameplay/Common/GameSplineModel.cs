using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common
{
	// Token: 0x02006F2A RID: 28458
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class GameSplineModel : ModelBase<GameSplineModel>
	{
		// Token: 0x06044E91 RID: 282257 RVA: 0x011F0814 File Offset: 0x011EEA14
		private void CheckAndReleaseActor(float _)
		{
			foreach (KeyValuePair<int, ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>> keyValuePair in this.ActorMaps)
			{
				int key = keyValuePair.Key;
				ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>> value = keyValuePair.Value;
				foreach (ActorId actorId in value.Item3)
				{
					switch (actorId.Type)
					{
					case EIdType.PbDataId:
						if (ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(actorId.Id) == null)
						{
							value.Item3.Remove(actorId);
						}
						break;
					case EIdType.EntityId:
						if (Singleton<EntitySystem>.Instance.Get(actorId.Id) == null)
						{
							value.Item3.Remove(actorId);
						}
						break;
					case EIdType.SimpleCombatId:
						if (ModelBase<TowerDefenseEventModel>.Instance.GetEntity((long)actorId.Id) == null)
						{
							KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
							if (curSubModel == null || !curSubModel.IsCreatureIdValid(actorId.Id))
							{
								value.Item3.Remove(actorId);
							}
						}
						break;
					case EIdType.SimpleCombatPreviewId:
						if (!ControllerBase<TowerDefenseEventController>.Instance.IsInPreview())
						{
							value.Item3.Remove(actorId);
						}
						break;
					}
				}
				if (value.Item3.Count == 0)
				{
					Singleton<ActorSystem>.Instance.Put("GameSplineModel.CheckAndReleaseActor", value.Item1, null);
					this.ActorMaps.Remove(key);
				}
			}
			if (this.ActorMaps.Count == 0 && this.Timer != null)
			{
				TimerSystem.Instance.Remove(this.Timer);
				this.Timer = null;
			}
		}

		// Token: 0x06044E92 RID: 282258 RVA: 0x011F0A00 File Offset: 0x011EEC00
		[NullableContext(1)]
		public USplineComponent LoadAndGetSplineComponent(int splineId, int id, EIdType idType = EIdType.PbDataId)
		{
			ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>> value;
			ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>? valueTuple;
			if (!this.ActorMaps.TryGetValue(splineId, out value))
			{
				TsGameSplineActor tsGameSplineActor = Singleton<ActorSystem>.Instance.Get(TsGameSplineActor.StaticClass(), new FTransformDouble(), null, true) as TsGameSplineActor;
				valueTuple = new ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>?(new ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>(tsGameSplineActor, GameSplineUtils.InitGameSplineBySplineEntity(splineId, tsGameSplineActor), new HashSet<ActorId>()));
				this.ActorMaps[splineId] = valueTuple.Value;
				if (this.Timer == null)
				{
					this.Timer = TimerSystem.Instance.Forever(new TTimerAction(this.CheckAndReleaseActor), 5000f, 1f, null, null, true);
				}
			}
			else
			{
				valueTuple = new ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>?(value);
			}
			valueTuple.Value.Item3.Add(new ActorId(id, idType));
			return valueTuple.Value.Item2;
		}

		// Token: 0x06044E93 RID: 282259 RVA: 0x011F0AC8 File Offset: 0x011EECC8
		public TsGameSplineActor GetSplineActorBySplineId(int splineId)
		{
			ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>> valueTuple;
			if (!this.ActorMaps.TryGetValue(splineId, out valueTuple))
			{
				return null;
			}
			return valueTuple.Item1;
		}

		// Token: 0x06044E94 RID: 282260 RVA: 0x011F0AF0 File Offset: 0x011EECF0
		public void ReleaseSpline(int splineId, long id, EIdType idType = EIdType.PbDataId)
		{
			ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>> valueTuple;
			if (!this.ActorMaps.TryGetValue(splineId, out valueTuple))
			{
				return;
			}
			foreach (ActorId actorId in valueTuple.Item3)
			{
				if ((long)actorId.Id == id && actorId.Type == idType)
				{
					valueTuple.Item3.Remove(actorId);
				}
			}
		}

		// Token: 0x040266BE RID: 157374
		private const int TIMER_PERIOD = 5000;

		// Token: 0x040266BF RID: 157375
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1,
			1,
			1
		})]
		private readonly Dictionary<int, ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>> ActorMaps = new Dictionary<int, ValueTuple<TsGameSplineActor, USplineComponent, HashSet<ActorId>>>();

		// Token: 0x040266C0 RID: 157376
		private TimerHandle Timer;

		// Token: 0x040266C1 RID: 157377
		public float CurWindPipelineResistance;

		// Token: 0x040266C2 RID: 157378
		public float CurWindPipelineSpeedLimit;
	}
}
