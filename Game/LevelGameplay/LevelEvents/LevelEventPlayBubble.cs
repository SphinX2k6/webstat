using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BBF RID: 27583
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventPlayBubble : LevelEventBase
	{
		// Token: 0x0604403F RID: 278591 RVA: 0x011A278E File Offset: 0x011A098E
		public LevelEventPlayBubble(int id) : base(id)
		{
		}

		// Token: 0x06044040 RID: 278592 RVA: 0x011A2798 File Offset: 0x011A0998
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayBubble playBubble = inParams as PlayBubble;
			if (playBubble == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			CharacterDynamicFlowData characterDynamicFlowData = null;
			int? entityId = playBubble.EntityId;
			if (entityId != null && entityId.GetValueOrDefault() != 0)
			{
				GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext != null)
				{
					BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(generalLogicTreeContext.TreeIncId), false);
					if (behaviorTree != null)
					{
						behaviorTree.AddDynamicFlowNpc(playBubble.EntityId.Value);
					}
				}
				characterDynamicFlowData = this.CreateCharacterFlowDataFromPbDataId(playBubble.EntityId.Value, playBubble.Flow);
			}
			else
			{
				int id = 0;
				EntityContext entityContext = context as EntityContext;
				if (entityContext != null)
				{
					id = entityContext.EntityId.GetValueOrDefault();
				}
				else
				{
					TriggerContext triggerContext = context as TriggerContext;
					if (triggerContext != null)
					{
						id = triggerContext.TriggerEntityId.GetValueOrDefault();
					}
				}
				Entity entity = Singleton<EntitySystem>.Instance.Get(id);
				BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
				long? num = (baseActorComponent != null) ? new long?(baseActorComponent.CreatureData.GetCreatureDataId()) : null;
				if (num != null)
				{
					characterDynamicFlowData = this.CreateCharacterFlowDataFromCreatureId(num.Value, playBubble.Flow);
				}
			}
			if (characterDynamicFlowData == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "添加动态冒泡失败,无法创建动态冒泡数据";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", playBubble.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowId", playBubble.Flow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowName", playBubble.Flow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("State", playBubble.Flow.StateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("ContextType", context.Type);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				base.FinishExecute(false, false, true);
				return;
			}
			ControllerBase<DynamicFlowController>.Instance.AddDynamicFlow(characterDynamicFlowData);
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044041 RID: 278593 RVA: 0x011A29BC File Offset: 0x011A0BBC
		private unsafe CharacterDynamicFlowData CreateCharacterFlowDataFromPbDataId(int pbDataId, IBubbleIndex flowIndex)
		{
			CharacterDynamicFlowData characterDynamicFlowData = new CharacterDynamicFlowData();
			AddPlayBubble addPlayBubble = new AddPlayBubble();
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = pbDataId;
			addPlayBubble.EntityIds = list;
			addPlayBubble.Flow = flowIndex;
			addPlayBubble.WaitTime = new int?(0);
			AddPlayBubble bubbleData = addPlayBubble;
			DynamicFlowActorInfo masterInfo = new DynamicFlowActorInfo();
			masterInfo.PbDataId = pbDataId;
			characterDynamicFlowData.MasterInfo = masterInfo;
			characterDynamicFlowData.BubbleData = bubbleData;
			characterDynamicFlowData.Type = new EDynamicFlowType?(EDynamicFlowType.LevelEventClient);
			characterDynamicFlowData.Callback = delegate()
			{
				ControllerBase<DynamicFlowController>.Instance.RemoveDynamicFlow(masterInfo);
			};
			return characterDynamicFlowData;
		}

		// Token: 0x06044042 RID: 278594 RVA: 0x011A2A60 File Offset: 0x011A0C60
		private CharacterDynamicFlowData CreateCharacterFlowDataFromCreatureId(long creatureId, IBubbleIndex flowIndex)
		{
			CharacterDynamicFlowData characterDynamicFlowData = new CharacterDynamicFlowData();
			AddPlayBubble bubbleData = new AddPlayBubble
			{
				EntityIds = new List<int>(),
				Flow = flowIndex,
				WaitTime = new int?(0)
			};
			DynamicFlowActorInfo masterInfo = new DynamicFlowActorInfo();
			masterInfo.CreatureId = creatureId;
			characterDynamicFlowData.MasterInfo = masterInfo;
			characterDynamicFlowData.BubbleData = bubbleData;
			characterDynamicFlowData.Type = new EDynamicFlowType?(EDynamicFlowType.LevelEventClient);
			characterDynamicFlowData.Callback = delegate()
			{
				ControllerBase<DynamicFlowController>.Instance.RemoveDynamicFlow(masterInfo);
			};
			return characterDynamicFlowData;
		}
	}
}
