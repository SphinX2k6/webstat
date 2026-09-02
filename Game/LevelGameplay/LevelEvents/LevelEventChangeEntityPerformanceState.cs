using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B72 RID: 27506
	public class LevelEventChangeEntityPerformanceState : LevelEventBase
	{
		// Token: 0x06043EDB RID: 278235 RVA: 0x01197006 File Offset: 0x01195206
		public LevelEventChangeEntityPerformanceState(int id) : base(id)
		{
		}

		// Token: 0x06043EDC RID: 278236 RVA: 0x01197010 File Offset: 0x01195210
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ChangeEntityPrefabPerformance actionInfo = inParams as ChangeEntityPrefabPerformance;
			if (actionInfo == null)
			{
				return;
			}
			int? entityId = null;
			EntityHandle handle = null;
			string performanceTag = null;
			IChangeTargetEntityPrefabPerformance changeTargetEntityPrefabPerformance = actionInfo as IChangeTargetEntityPrefabPerformance;
			if (changeTargetEntityPrefabPerformance == null)
			{
				IChangeSelfEntityPrefabPerformance changeSelfEntityPrefabPerformance = actionInfo as IChangeSelfEntityPrefabPerformance;
				if (changeSelfEntityPrefabPerformance != null)
				{
					EntityContext entityContext = context as EntityContext;
					if (entityContext == null)
					{
						return;
					}
					entityId = entityContext.EntityId;
					handle = ModelBase<CreatureModel>.Instance.GetEntityById(entityId.Value);
					performanceTag = changeSelfEntityPrefabPerformance.PerformanceTag;
				}
			}
			else
			{
				entityId = new int?(changeTargetEntityPrefabPerformance.EntityId);
				handle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId.Value);
				performanceTag = changeTargetEntityPrefabPerformance.PerformanceTag;
			}
			if (entityId == null)
			{
				return;
			}
			WaitEntityTask.CreateWithPbDataId("LevelEventChangeEntityPerformanceState.ExecuteNew", entityId.Value, delegate(bool? result)
			{
				if (!result.GetValueOrDefault())
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.WLJ;
					string message = "[ LevelEventChangeEntityPerformanceState] 找不到对应的Entity";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", entityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", actionInfo.Type);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				EntityHandle handle = handle;
				SceneItemStateComponent sceneItemStateComponent;
				if (handle == null)
				{
					sceneItemStateComponent = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					sceneItemStateComponent = ((entity != null) ? entity.GetComponent<SceneItemStateComponent>() : null);
				}
				SceneItemStateComponent sceneItemStateComponent2 = sceneItemStateComponent;
				if (sceneItemStateComponent2 == null)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.WLJ;
					string message2 = "[LevelEventChangeEntityPerformanceState] 找不到对应的SceneItemStateComponent";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", entityId);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				int tagIdByName = GameplayTagUtils.GetTagIdByName(performanceTag);
				if (tagIdByName == 0)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.LevelEvent;
					ELogAuthor author3 = ELogAuthor.WLJ;
					string message3 = "[LevelEventChangeEntityPerformanceState] 找不到对应的StateTag";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("pbDataId", entityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Type", actionInfo.Type);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return;
				}
				sceneItemStateComponent2.ChangePerformanceState(tagIdByName, false, true);
			}, 60000, true, false);
		}
	}
}
