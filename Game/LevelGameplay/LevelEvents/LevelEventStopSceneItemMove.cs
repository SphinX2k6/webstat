using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C10 RID: 27664
	public class LevelEventStopSceneItemMove : LevelEventBase
	{
		// Token: 0x06044179 RID: 278905 RVA: 0x011ADF9C File Offset: 0x011AC19C
		public LevelEventStopSceneItemMove(int id) : base(id)
		{
		}

		// Token: 0x0604417A RID: 278906 RVA: 0x011ADFA8 File Offset: 0x011AC1A8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CH, "参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			this.Params = (inParams as StopSceneItemMove);
			List<int> entityIds = this.Params.EntityIds;
			base.CreateWaitEntityTask(entityIds);
		}

		// Token: 0x0604417B RID: 278907 RVA: 0x011AE000 File Offset: 0x011AC200
		protected override void ExecuteWhenEntitiesReady()
		{
			if (this.Params == null)
			{
				return;
			}
			List<int> entityIds = this.Params.EntityIds;
			List<ValueTuple<Entity, global::Vector, FVectorDouble?>> list = new List<ValueTuple<Entity, global::Vector, FVectorDouble?>>();
			SceneItemStopRequest sceneItemStopRequest = SceneItemStopRequest.Create();
			bool flag = this.Params.StopType.GetValueOrDefault() == EStopSceneItemMoveType.StopAtNextPos;
			foreach (int num in entityIds)
			{
				SceneItemStopInfo sceneItemStopInfo = SceneItemStopInfo.Create();
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				if (entityByPbDataId == null || !entityByPbDataId.Valid)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.CH;
					string message = "实体不合法";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					SceneItemMoveComponent component = entityByPbDataId.Entity.GetComponent<SceneItemMoveComponent>();
					if (component == null || !component.Valid)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.CH;
						string message2 = "Entity找不到SceneItemMoveComponent";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", num);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else
					{
						ValueTuple<bool, FVectorDouble, FVectorDouble>? valueTuple3 = null;
						if (flag)
						{
							valueTuple3 = new ValueTuple<bool, FVectorDouble, FVectorDouble>?(component.GetNextTarget());
						}
						CreatureDataComponent component2 = entityByPbDataId.Entity.GetComponent<CreatureDataComponent>();
						BaseActorComponent component3 = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
						sceneItemStopInfo.EntityId = Singleton<MathUtils>.Instance.NumberToLong(component2.GetCreatureDataId());
						sceneItemStopInfo.Location = Aki.Protocol.Vector.Create();
						sceneItemStopInfo.Location.X = (float)component3.ActorLocationProxy.X;
						sceneItemStopInfo.Location.Y = (float)component3.ActorLocationProxy.Y;
						sceneItemStopInfo.Location.Z = (float)component3.ActorLocationProxy.Z;
						ValueTuple<WorldEntity, global::Vector, FVectorDouble?> valueTuple4 = new ValueTuple<WorldEntity, global::Vector, FVectorDouble?>(entityByPbDataId.Entity, global::Vector.Create(component3.ActorLocationProxy), (valueTuple3 != null && valueTuple3.GetValueOrDefault().Item1) ? ((valueTuple3 != null) ? new FVectorDouble?(valueTuple3.GetValueOrDefault().Item3) : null) : null);
						if (flag && valueTuple3.Value.Item1)
						{
							sceneItemStopInfo.Location.X = (float)valueTuple3.Value.Item2.X;
							sceneItemStopInfo.Location.Y = (float)valueTuple3.Value.Item2.Y;
							sceneItemStopInfo.Location.Z = (float)valueTuple3.Value.Item2.Z;
							valueTuple4.Item2 = global::Vector.Create(valueTuple3.Value.Item2);
							valueTuple4.Item3 = new FVectorDouble?(valueTuple3.Value.Item3);
						}
						if (component.IsMoving)
						{
							sceneItemStopRequest.StopInfos.Add(sceneItemStopInfo);
						}
						List<ValueTuple<Entity, global::Vector, FVectorDouble?>> list2 = list;
						ValueTuple<WorldEntity, global::Vector, FVectorDouble?> valueTuple5 = valueTuple4;
						list2.Add(new ValueTuple<Entity, global::Vector, FVectorDouble?>(valueTuple5.Item1, valueTuple5.Item2, valueTuple5.Item3));
					}
				}
			}
			Singleton<Net>.Instance.Call<SceneItemStopResponse>(ERequestMessageId.SceneItemStopRequest, sceneItemStopRequest, delegate(SceneItemStopResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.SceneItemStopResponse, null, true, true);
				}
			}, 0);
			foreach (ValueTuple<Entity, global::Vector, FVectorDouble?> valueTuple6 in list)
			{
				SceneItemMoveComponent component4 = valueTuple6.Item1.GetComponent<SceneItemMoveComponent>();
				component4.StopMove(true, true);
				BaseActorComponent component5 = valueTuple6.Item1.GetComponent<BaseActorComponent>();
				global::Vector v = global::Vector.Create((component5 != null) ? component5.ActorLocationProxy : null);
				if (valueTuple6.Item3 != null)
				{
					double num2 = global::Vector.Distance(v, valueTuple6.Item2) / valueTuple6.Item3.Value.Size();
					component4.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(valueTuple6.Item2, (float)num2, 0f, -1f, -1f));
				}
			}
		}

		// Token: 0x0604417C RID: 278908 RVA: 0x011AE434 File Offset: 0x011AC634
		protected override void OnReset()
		{
			this.Params = null;
		}

		// Token: 0x04026091 RID: 155793
		[Nullable(2)]
		private StopSceneItemMove Params;
	}
}
