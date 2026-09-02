using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F87 RID: 28551
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowAddCueAction : LevelFlowActionBase
	{
		// Token: 0x06045173 RID: 282995 RVA: 0x012042A3 File Offset: 0x012024A3
		public LevelFlowAddCueAction Init(int entityId, List<long> cueIdList, bool isFloater = false)
		{
			this.EntityId = entityId;
			this.CueIdList = cueIdList;
			this.IsFloater = isFloater;
			return this;
		}

		// Token: 0x06045174 RID: 282996 RVA: 0x012042BC File Offset: 0x012024BC
		protected override void OnExecute()
		{
			EntityHandle entityHandle;
			if (this.IsFloater)
			{
				entityHandle = FollowUtils.GetPlayerFollowShooter(ModelBase<CreatureModel>.Instance.GetPlayerId());
			}
			else
			{
				entityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			}
			if (entityHandle == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Entity加载超时或已被移除";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			WorldEntity entity = entityHandle.Entity;
			if (entity == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "未找到实体";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			BaseGameplayCueComponent component = entity.GetComponent<BaseGameplayCueComponent>();
			if (component == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "实体没有BaseGameplayCueComponent";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(false);
				return;
			}
			foreach (long cueId in this.CueIdList)
			{
				component.AddCue(cueId, null);
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045175 RID: 282997 RVA: 0x0120441C File Offset: 0x0120261C
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("CueIdList", string.Join<long>(",", this.CueIdList));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x040268D7 RID: 157911
		public int EntityId;

		// Token: 0x040268D8 RID: 157912
		public bool IsFloater;

		// Token: 0x040268D9 RID: 157913
		public List<long> CueIdList = new List<long>();
	}
}
