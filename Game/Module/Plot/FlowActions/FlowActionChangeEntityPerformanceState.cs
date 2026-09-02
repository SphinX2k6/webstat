using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005413 RID: 21523
	public class FlowActionChangeEntityPerformanceState : FlowActionBase
	{
		// Token: 0x06036F1F RID: 225055 RVA: 0x00DF2474 File Offset: 0x00DF0674
		protected unsafe override void OnExecute()
		{
			ChangeEntityPrefabPerformance changeEntityPrefabPerformance = this.ActionInfo.Params as ChangeEntityPrefabPerformance;
			if (changeEntityPrefabPerformance == null)
			{
				return;
			}
			int? num = null;
			EntityHandle entityHandle = null;
			string tagName = "";
			EChangeEntityPrefabPerformanceType type = changeEntityPrefabPerformance.Type;
			if (type != EChangeEntityPrefabPerformanceType.Target)
			{
				if (type == EChangeEntityPrefabPerformanceType.Self)
				{
					num = new int?(this.GetSelfEntityId());
					entityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(num.Value);
					tagName = ((IChangeSelfEntityPrefabPerformance)changeEntityPrefabPerformance).PerformanceTag;
				}
			}
			else
			{
				num = new int?(((IChangeTargetEntityPrefabPerformance)changeEntityPrefabPerformance).EntityId);
				entityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num.Value);
				tagName = ((IChangeTargetEntityPrefabPerformance)changeEntityPrefabPerformance).PerformanceTag;
			}
			if (entityHandle == null || !entityHandle.IsInit)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[ FlowActionChangeEntityPerformanceState] 找不到对应的Entity";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", changeEntityPrefabPerformance.Type);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			SceneItemStateComponent sceneItemStateComponent;
			if (entityHandle == null)
			{
				sceneItemStateComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				sceneItemStateComponent = ((entity != null) ? entity.GetComponent<SceneItemStateComponent>() : null);
			}
			SceneItemStateComponent sceneItemStateComponent2 = sceneItemStateComponent;
			if (sceneItemStateComponent2 == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "[FlowActionChangeEntityPerformanceState] 找不到对应的SceneItemStateComponent";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", num);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
			if (tagIdByName == 0)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Plot;
				ELogAuthor author3 = ELogAuthor.YZH;
				string message3 = "[FlowActionChangeEntityPerformanceState] 找不到对应的StateTag";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("pbDataId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Type", changeEntityPrefabPerformance.Type);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			sceneItemStateComponent2.ChangePerformanceState(tagIdByName, false, true);
		}

		// Token: 0x06036F20 RID: 225056 RVA: 0x00DF2648 File Offset: 0x00DF0848
		private int GetSelfEntityId()
		{
			int? num = null;
			EGeneralContextType? type = this.Context.Context.Type;
			if (type != null)
			{
				EGeneralContextType valueOrDefault = type.GetValueOrDefault();
				if (valueOrDefault != EGeneralContextType.Entity)
				{
					if (valueOrDefault == EGeneralContextType.Trigger)
					{
						num = (this.Context.Context as TriggerContext).TriggerEntityId;
					}
				}
				else
				{
					num = (this.Context.Context as EntityContext).EntityId;
				}
			}
			return num.GetValueOrDefault();
		}
	}
}
