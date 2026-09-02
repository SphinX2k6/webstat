using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using CSharpScript.Game.World.Controller;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B70 RID: 27504
	public class LevelEventCaptureRequest : LevelEventBase
	{
		// Token: 0x06043EC9 RID: 278217 RVA: 0x011942E1 File Offset: 0x011924E1
		public LevelEventCaptureRequest(int id) : base(id)
		{
		}

		// Token: 0x06043ECA RID: 278218 RVA: 0x011942F8 File Offset: 0x011924F8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			LevelEventCaptureRequest.<>c__DisplayClass3_0 CS$<>8__locals1 = new LevelEventCaptureRequest.<>c__DisplayClass3_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.inParams = inParams;
			if (context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
			{
				EntityContext entityContext = context as EntityContext;
				if (entityContext != null)
				{
					CS$<>8__locals1.actionCaptureRequest = (CS$<>8__locals1.inParams as ActionCaptureRequest);
					if (CS$<>8__locals1.actionCaptureRequest != null)
					{
						Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.GetValueOrDefault());
						if (entity == null || !entity.Valid)
						{
							base.FinishExecute(false, false, true);
							return;
						}
						this.EntityId = entityContext.EntityId.Value;
						LevelEventCaptureRequest.<>c__DisplayClass3_1 CS$<>8__locals2 = new LevelEventCaptureRequest.<>c__DisplayClass3_1();
						CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
						CS$<>8__locals2.tmpPositions = new List<Vector>();
						CS$<>8__locals2.visionPositions = new List<Vector>();
						CS$<>8__locals2.visionEntityIds = new List<int>();
						int huluDistanceMin = Singleton<SceneItemCaptureComponent.SceneItemCaptureUtility>.Instance.HuluDistanceMin;
						CS$<>8__locals2.huluDistanceMax = Singleton<SceneItemCaptureComponent.SceneItemCaptureUtility>.Instance.HuluDistanceMax;
						int huluAltitude = Singleton<SceneItemCaptureComponent.SceneItemCaptureUtility>.Instance.HuluAltitude;
						int absorbRadius = Singleton<SceneItemCaptureComponent.SceneItemCaptureUtility>.Instance.GetAbsorbRadius();
						CS$<>8__locals2.playerLocation = Vector.Create(0.0, 0.0, 0.0);
						WorldEntity entity2 = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
						if (entity2 == null || !entity2.Valid)
						{
							base.FinishExecute(false, false, true);
							return;
						}
						CharacterActorComponent component = entity2.GetComponent<CharacterActorComponent>();
						CS$<>8__locals2.playerLocation.DeepCopy(component.ActorLocationProxy);
						Vector vector = Vector.Create(CS$<>8__locals2.playerLocation);
						vector.Z -= (double)component.ScaledHalfHeight;
						CS$<>8__locals2.<ExecuteNew>g__UpdateVisionInfo|1(this.EntityId);
						VisionCaptureModel instance = ModelBase<VisionCaptureModel>.Instance;
						Dictionary<int, bool> dictionary = (instance != null) ? instance.AllVisionEntityIds : null;
						if (dictionary != null)
						{
							foreach (int entityId in dictionary.Keys)
							{
								CS$<>8__locals2.<ExecuteNew>g__UpdateVisionInfo|1(entityId);
							}
						}
						Vector actorLocationProxy = Singleton<EntitySystem>.Instance.Get(this.EntityId).GetComponent<SceneItemActorComponent>().ActorLocationProxy;
						double currentValue = Vector.Distance(actorLocationProxy, vector);
						double distance = Singleton<MathUtils>.Instance.Clamp(currentValue, (double)huluDistanceMin, (double)CS$<>8__locals2.huluDistanceMax);
						CS$<>8__locals2.huluLocation = Singleton<MathUtils>.Instance.GetNextPointWithDistance(vector, actorLocationProxy, distance);
						CS$<>8__locals2.huluLocation.Z += (double)huluAltitude;
						UTraceLineElement lineTrace = ModelBase<TraceElementModel>.Instance.GetLineTrace();
						lineTrace.WorldContextObject = GlobalData.World;
						lineTrace.ActorsToIgnore.Empty(true);
						Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, CS$<>8__locals2.playerLocation);
						Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, CS$<>8__locals2.huluLocation);
						if (Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "VisionCaptureTest"))
						{
							Singleton<TraceElementCommon>.Instance.GetHitLocation(lineTrace.HitResult, 0, CS$<>8__locals2.huluLocation);
							double distance2 = Vector.Distance(CS$<>8__locals2.playerLocation, CS$<>8__locals2.huluLocation) - (double)Singleton<SceneItemCaptureComponent.SceneItemCaptureUtility>.Instance.HuluOffsetOnHit;
							CS$<>8__locals2.huluLocation = Singleton<MathUtils>.Instance.GetNextPointWithDistance(CS$<>8__locals2.playerLocation, CS$<>8__locals2.huluLocation, distance2);
						}
						else
						{
							lineTrace.ClearCacheData(false);
						}
						List<int> list = new List<int>();
						for (int i = 0; i < CS$<>8__locals2.visionEntityIds.Count; i++)
						{
							int item = CS$<>8__locals2.visionEntityIds[i];
							if (Vector.Distance(CS$<>8__locals2.visionPositions[i], CS$<>8__locals2.huluLocation) <= (double)absorbRadius)
							{
								list.Add(item);
							}
						}
						BattleNetController.RequestBatchCaptureEntity(list).ContinueWith(delegate(List<int> succeedEntityIds)
						{
							if (succeedEntityIds.Count > 0)
							{
								bool flag = true;
								foreach (int num in succeedEntityIds)
								{
									Entity entity3 = Singleton<EntitySystem>.Instance.Get(num);
									if (entity3 != null && entity3.Valid)
									{
										CS$<>8__locals2.CS$<>8__locals1.<>4__this.SendGameplayEvent(CS$<>8__locals2.CS$<>8__locals1.actionCaptureRequest, num);
										SceneItemCaptureComponent component2 = entity3.GetComponent<SceneItemCaptureComponent>();
										if (component2 != null)
										{
											if (flag)
											{
												flag = false;
												component2.ExecuteCapture(CS$<>8__locals2.CS$<>8__locals1.<>4__this.SuccessEventGroup, CS$<>8__locals2.huluLocation);
											}
											else
											{
												component2.AfterCapture(false);
											}
										}
									}
								}
								CS$<>8__locals2.CS$<>8__locals1.<>4__this.FinishExecute(true, false, true);
								return;
							}
							CS$<>8__locals2.CS$<>8__locals1.<>4__this.FinishExecute(false, false, true);
						});
						return;
					}
				}
			}
			base.FinishExecute(false, false, true);
		}

		// Token: 0x06043ECB RID: 278219 RVA: 0x01194684 File Offset: 0x01192884
		[NullableContext(1)]
		private void SendGameplayEvent(ActionCaptureRequest config, int entityId)
		{
			ActionInfo actionInfo = new ActionInfo();
			actionInfo.Params = config.SuccessEvent;
			List<ActionInfo> list = new List<ActionInfo>();
			list.Add(actionInfo);
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(list, EntityContext.Create(entityId, null), null);
		}

		// Token: 0x06043ECC RID: 278220 RVA: 0x011946CC File Offset: 0x011928CC
		private void HandleCaptureSuccess(int entityId)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return;
			}
			SceneItemCaptureComponent component = entity.GetComponent<SceneItemCaptureComponent>();
			if (component == null)
			{
				return;
			}
			component.ExecuteCapture(this.SuccessEventGroup, null);
		}

		// Token: 0x06043ECD RID: 278221 RVA: 0x01194701 File Offset: 0x01192901
		protected override void OnReset()
		{
			this.SuccessEventGroup = null;
			this.EntityId = 0;
		}

		// Token: 0x06043ECE RID: 278222 RVA: 0x01194714 File Offset: 0x01192914
		public static void CollectInViewport()
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			List<int> list = new List<int>();
			VisionCaptureModel instance = ModelBase<VisionCaptureModel>.Instance;
			Dictionary<int, bool> dictionary = (instance != null) ? instance.AllVisionEntityIds : null;
			if (dictionary != null)
			{
				FVector2D fvector2D = new FVector2D(0f, 0f);
				foreach (int num in dictionary.Keys)
				{
					if (!list.Contains(num))
					{
						Entity entity = Singleton<EntitySystem>.Instance.Get(num);
						if (entity != null && entity.Valid)
						{
							FVectorDouble actorLocation = entity.GetComponent<BaseActorComponent>().ActorLocation;
							if (UGameplayStatics.D_ProjectWorldToScreen(characterController, actorLocation, ref fvector2D, false))
							{
								list.Add(entity.Id);
							}
						}
					}
				}
			}
			LevelEventCaptureRequest.QuickCollect(list);
		}

		// Token: 0x06043ECF RID: 278223 RVA: 0x011947F0 File Offset: 0x011929F0
		private static UniTask<bool> QuickCollect([Nullable(1)] List<int> entityIds)
		{
			LevelEventCaptureRequest.<QuickCollect>d__8 <QuickCollect>d__;
			<QuickCollect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<QuickCollect>d__.entityIds = entityIds;
			<QuickCollect>d__.<>1__state = -1;
			<QuickCollect>d__.<>t__builder.Start<LevelEventCaptureRequest.<QuickCollect>d__8>(ref <QuickCollect>d__);
			return <QuickCollect>d__.<>t__builder.Task;
		}

		// Token: 0x04025FCC RID: 155596
		[Nullable(2)]
		private string SuccessEventGroup = "";

		// Token: 0x04025FCD RID: 155597
		private int EntityId;
	}
}
