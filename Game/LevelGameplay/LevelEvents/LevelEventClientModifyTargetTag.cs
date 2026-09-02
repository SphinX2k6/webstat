using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B7C RID: 27516
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventClientModifyTargetTag : LevelEventBase
	{
		// Token: 0x06043F04 RID: 278276 RVA: 0x01198548 File Offset: 0x01196748
		public LevelEventClientModifyTargetTag(int id) : base(id)
		{
		}

		// Token: 0x06043F05 RID: 278277 RVA: 0x01198554 File Offset: 0x01196754
		private bool ModifySceneItemTag(int? contextEntityId, ClientModifyTargetTag clientModifyTargetTagParams)
		{
			EntityHandle entityHandle = null;
			EClientModifyTargetType type = clientModifyTargetTagParams.Target.Type;
			if (type != EClientModifyTargetType.Self)
			{
				if (type == EClientModifyTargetType.Player)
				{
					entityHandle = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				}
			}
			else if (contextEntityId != null)
			{
				entityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(contextEntityId.Value);
			}
			if (entityHandle != null && entityHandle.Valid)
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity != null && entity.Valid)
				{
					BaseTagComponent baseTagComponent = entityHandle.Entity.CheckGetComponent<BaseTagComponent>();
					if (baseTagComponent == null)
					{
						return false;
					}
					if (clientModifyTargetTagParams.IsAddTag)
					{
						using (List<string>.Enumerator enumerator = clientModifyTargetTagParams.PerformanceTag.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								string tagName = enumerator.Current;
								int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
								ControllerBase<LevelGamePlayController>.Instance.ClientAddTagToTarget(entityHandle, tagIdByName);
								baseTagComponent.AddTag(new int?(tagIdByName));
							}
							return true;
						}
					}
					foreach (string tagName2 in clientModifyTargetTagParams.PerformanceTag)
					{
						int tagIdByName2 = GameplayTagUtils.GetTagIdByName(tagName2);
						if (ControllerBase<LevelGamePlayController>.Instance.ClientRemoveTagFromTarget(entityHandle.Id, tagIdByName2))
						{
							baseTagComponent.RemoveTag(new int?(tagIdByName2));
						}
						else
						{
							global::Log instance = Singleton<global::Log>.Instance;
							ELogModule module = ELogModule.LevelEvent;
							ELogAuthor author = ELogAuthor.XDW;
							string message = "ClientModifyTargetTag 不能删除非本行为添加的Tag";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Params", clientModifyTargetTagParams);
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06043F06 RID: 278278 RVA: 0x011986D4 File Offset: 0x011968D4
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ClientModifyTargetTag clientModifyTargetTag = inParams as ClientModifyTargetTag;
			if (clientModifyTargetTag == null)
			{
				return;
			}
			EGeneralContextType? type = context.Type;
			if (type != null)
			{
				EGeneralContextType valueOrDefault = type.GetValueOrDefault();
				if (valueOrDefault == EGeneralContextType.Entity)
				{
					this.ModifySceneItemTag((context as EntityContext).EntityId, clientModifyTargetTag);
					return;
				}
				if (valueOrDefault == EGeneralContextType.Trigger)
				{
					this.ModifySceneItemTag((context as TriggerContext).TriggerEntityId, clientModifyTargetTag);
					return;
				}
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.XDW;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ClientModifyTargetTag 没有支持的类型 ");
			defaultInterpolatedStringHandler.AppendFormatted<EGeneralContextType?>(context.Type);
			string message = defaultInterpolatedStringHandler.ToStringAndClear();
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Params", inParams);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Context", context);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}
}
