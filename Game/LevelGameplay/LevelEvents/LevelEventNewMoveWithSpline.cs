using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BB7 RID: 27575
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventNewMoveWithSpline : LevelEventBase
	{
		// Token: 0x06044010 RID: 278544 RVA: 0x011A06AE File Offset: 0x0119E8AE
		public LevelEventNewMoveWithSpline(int id) : base(id)
		{
		}

		// Token: 0x06044011 RID: 278545 RVA: 0x011A06B8 File Offset: 0x0119E8B8
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			NewMoveWithSpline @params = inParams as NewMoveWithSpline;
			if (GeneralContext.ExtractContext<SplinePointArrivalContext>(this.BaseContext ?? context, EGeneralContextType.SplinePointArrival) != null)
			{
				this.TryClientSceneItemSplineMove(@params);
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044012 RID: 278546 RVA: 0x011A06F0 File Offset: 0x0119E8F0
		private unsafe void TryClientSceneItemSplineMove(NewMoveWithSpline @params)
		{
			if (@params.MoveTarget.Type != ENewSplineMoveTargetType.SceneItem)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[LevelEventNewMoveWithSpline] 新样条运动客户端先行: 非SceneItem目标，跳过客户端先行";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SplineEntityId", @params.SplineEntityId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!this.IsAsync)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[LevelEventNewMoveWithSpline] 新样条运动客户端先行: 不支持同步行为，跳过客户端先行";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SplineEntityId", @params.SplineEntityId);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			ISceneItemNewSplineMoveTarget sceneItemNewSplineMoveTarget = @params.MoveTarget as ISceneItemNewSplineMoveTarget;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(sceneItemNewSplineMoveTarget.EntityId);
			SceneItemMoveComponent sceneItemMoveComponent;
			if (entityByPbDataId == null)
			{
				sceneItemMoveComponent = null;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				sceneItemMoveComponent = ((entity != null) ? entity.GetComponent<SceneItemMoveComponent>() : null);
			}
			SceneItemMoveComponent sceneItemMoveComponent2 = sceneItemMoveComponent;
			if (sceneItemMoveComponent2 == null || !sceneItemMoveComponent2.Valid)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[LevelEventNewMoveWithSpline] SceneItemMoveComponent无效，跳过客户端先行移动";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("PbDataId", sceneItemNewSplineMoveTarget.EntityId);
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			ISceneItemSplineMoveConfig sceneItemSplineMoveConfig = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralConfig();
			if (!SceneItemSplineMoveTaskUtils.ParseNewMoveWithSplineActionToGeneralConfig(@params, sceneItemSplineMoveConfig))
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[LevelEventNewMoveWithSpline] 解析新样条配置失败，跳过客户端先行";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", sceneItemNewSplineMoveTarget.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineEntityId", @params.SplineEntityId);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			SceneItemSplineMoveRuntimeData sceneItemSplineMoveRuntimeData = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralRuntimeData();
			if (@params.IsStartFromCurrentPos.GetValueOrDefault())
			{
				BaseActorComponent baseActorComponent;
				if (entityByPbDataId == null)
				{
					baseActorComponent = null;
				}
				else
				{
					WorldEntity entity2 = entityByPbDataId.Entity;
					baseActorComponent = ((entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null);
				}
				BaseActorComponent baseActorComponent2 = baseActorComponent;
				if (baseActorComponent2 != null)
				{
					sceneItemSplineMoveRuntimeData.CurPos = Vector.Create(baseActorComponent2.ActorLocationProxy);
					sceneItemSplineMoveRuntimeData.CurRot = Rotator.Create(baseActorComponent2.ActorRotationProxy);
				}
			}
			if (sceneItemMoveComponent2.GetCurSplineMoveTask() != null)
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.SceneItem;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[LevelEventNewMoveWithSpline] 样条运动中，客户端先行切轨";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", sceneItemNewSplineMoveTarget.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SplineEntityId", @params.SplineEntityId);
				instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				sceneItemMoveComponent2.SwitchSplineMoveTask(new SceneItemSplineMoveTaskParam
				{
					SplineId = @params.SplineEntityId,
					SplineMoveConfig = sceneItemSplineMoveConfig,
					EnableSplineMoveSync = true,
					EnableMovementSync = false,
					NeedMoveToStartPoint = false,
					SplineMoveRuntimeData = sceneItemSplineMoveRuntimeData,
					Context = this.BaseContext
				});
				return;
			}
			global::Log instance6 = Singleton<global::Log>.Instance;
			ELogModule module6 = ELogModule.SceneItem;
			ELogAuthor author6 = ELogAuthor.ZYL;
			string message6 = "[LevelEventNewMoveWithSpline] 未在样条运动中，客户端先行启动新样条";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PbDataId", sceneItemNewSplineMoveTarget.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("SplineEntityId", @params.SplineEntityId);
			instance6.Info(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			sceneItemMoveComponent2.StartSplineMoveTask(new SceneItemSplineMoveTaskParam
			{
				SplineId = @params.SplineEntityId,
				SplineMoveConfig = sceneItemSplineMoveConfig,
				EnableSplineMoveSync = true,
				EnableMovementSync = false,
				NeedMoveToStartPoint = false,
				SplineMoveRuntimeData = sceneItemSplineMoveRuntimeData,
				Context = this.BaseContext
			});
		}
	}
}
