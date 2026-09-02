using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F99 RID: 28569
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowModifyTargetTag : LevelFlowActionBase
	{
		// Token: 0x060451CF RID: 283087 RVA: 0x0120754D File Offset: 0x0120574D
		public LevelFlowModifyTargetTag Init(int entityId, bool isAddTag, List<string> tagList)
		{
			this.EntityId = entityId;
			this.IsAddTag = isAddTag;
			this.TagList = tagList;
			return this;
		}

		// Token: 0x060451D0 RID: 283088 RVA: 0x01207568 File Offset: 0x01205768
		protected override void OnExecute()
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById != null && entityById.Valid)
			{
				WorldEntity entity = entityById.Entity;
				if (entity != null && entity.Valid)
				{
					BaseTagComponent baseTagComponent = entityById.Entity.CheckGetComponent<BaseTagComponent>();
					if (baseTagComponent == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.LevelFlow;
						ELogAuthor author = ELogAuthor.BB;
						string message = "LevelFlowModifyTargetTag 实体不存在TagComponent";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						base.FinishExecute(false);
						return;
					}
					if (this.IsAddTag)
					{
						using (List<string>.Enumerator enumerator = this.TagList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string tagName = enumerator.Current;
								int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
								ControllerBase<LevelGamePlayController>.Instance.ClientAddTagToTarget(entityById, tagIdByName);
								baseTagComponent.AddTag(new int?(tagIdByName));
							}
							goto IL_170;
						}
					}
					foreach (string tagName2 in this.TagList)
					{
						int tagIdByName2 = GameplayTagUtils.GetTagIdByName(tagName2);
						if (ControllerBase<LevelGamePlayController>.Instance.ClientRemoveTagFromTarget(entityById.Id, tagIdByName2))
						{
							baseTagComponent.RemoveTag(new int?(tagIdByName2));
						}
					}
					IL_170:
					base.FinishExecute(true);
					return;
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.LevelFlow;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "LevelFlowModifyTargetTag 实体不存在";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", this.EntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
		}

		// Token: 0x060451D1 RID: 283089 RVA: 0x01207708 File Offset: 0x01205908
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("isAddTag", this.IsAddTag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("TagList", string.Join(",", this.TagList));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}

		// Token: 0x040268FB RID: 157947
		private int EntityId;

		// Token: 0x040268FC RID: 157948
		private bool IsAddTag;

		// Token: 0x040268FD RID: 157949
		private List<string> TagList = new List<string>();
	}
}
