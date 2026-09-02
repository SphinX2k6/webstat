using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CCF RID: 27855
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelConditionCheckCharacterTagsRestrict : LevelConditionBase, IStaticVariableResetter
	{
		// Token: 0x060443BE RID: 279486 RVA: 0x011B8105 File Offset: 0x011B6305
		static LevelConditionCheckCharacterTagsRestrict()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelConditionCheckCharacterTagsRestrict.CreateStaticDefaultValue), new Action(LevelConditionCheckCharacterTagsRestrict.ResetStaticDefaultValue));
		}

		// Token: 0x060443BF RID: 279487 RVA: 0x011B8124 File Offset: 0x011B6324
		public static void CreateStaticDefaultValue()
		{
			LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks = new Dictionary<TTagChangedCallback, List<int>>();
			LevelConditionCheckCharacterTagsRestrict.CallbackWrappers = new Dictionary<TTagChangedCallback, BaseTagComponent.TTagSwitchedCallback>();
			LevelConditionCheckCharacterTagsRestrict.SubscribedEntity = null;
		}

		// Token: 0x060443C0 RID: 279488 RVA: 0x011B8140 File Offset: 0x011B6340
		public static void ResetStaticDefaultValue()
		{
			LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks = null;
			LevelConditionCheckCharacterTagsRestrict.CallbackWrappers = null;
			LevelConditionCheckCharacterTagsRestrict.SubscribedEntity = null;
		}

		// Token: 0x060443C1 RID: 279489 RVA: 0x011B8154 File Offset: 0x011B6354
		private static List<string> ParseTagNames([Nullable(2)] string raw)
		{
			if (string.IsNullOrEmpty(raw))
			{
				return new List<string>();
			}
			return raw.TrimStart('[').TrimEnd(']').Split(',', StringSplitOptions.None).ToList<string>();
		}

		// Token: 0x060443C2 RID: 279490 RVA: 0x011B8180 File Offset: 0x011B6380
		public static List<string> GetTagNames(Condition inConditionInfo)
		{
			List<string> list = new List<string>();
			list.AddRange(LevelConditionCheckCharacterTagsRestrict.ParseTagNames(inConditionInfo.GetLimitParams("RequireTags")));
			list.AddRange(LevelConditionCheckCharacterTagsRestrict.ParseTagNames(inConditionInfo.GetLimitParams("BanTags")));
			return list;
		}

		// Token: 0x060443C3 RID: 279491 RVA: 0x011B81B8 File Offset: 0x011B63B8
		private static BaseTagComponent.TTagSwitchedCallback GetWrapper(TTagChangedCallback callback)
		{
			BaseTagComponent.TTagSwitchedCallback ttagSwitchedCallback;
			if (!LevelConditionCheckCharacterTagsRestrict.CallbackWrappers.TryGetValue(callback, out ttagSwitchedCallback))
			{
				ttagSwitchedCallback = delegate(int tagId, bool tagExist)
				{
					callback(new object[]
					{
						tagId,
						tagExist
					});
				};
				LevelConditionCheckCharacterTagsRestrict.CallbackWrappers[callback] = ttagSwitchedCallback;
			}
			return ttagSwitchedCallback;
		}

		// Token: 0x060443C4 RID: 279492 RVA: 0x011B8208 File Offset: 0x011B6408
		public static void RegisterEvents(Condition inConditionInfo, TTagChangedCallback callback)
		{
			if (LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks.Count == 0)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.OnChangeRole;
				Action<EntityHandle, EntityHandle> handle;
				if ((handle = LevelConditionCheckCharacterTagsRestrict.<>O.<0>__OnChangeRole) == null)
				{
					handle = (LevelConditionCheckCharacterTagsRestrict.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(LevelConditionCheckCharacterTagsRestrict.OnChangeRole));
				}
				instance.Add(name, handle);
				SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
				WorldEntity subscribedEntity;
				if (instance2 == null)
				{
					subscribedEntity = null;
				}
				else
				{
					EntityHandle getCurrentEntity = instance2.GetCurrentEntity;
					subscribedEntity = ((getCurrentEntity != null) ? getCurrentEntity.Entity : null);
				}
				LevelConditionCheckCharacterTagsRestrict.SubscribedEntity = subscribedEntity;
			}
			List<int> list = new List<int>();
			foreach (string tagName in LevelConditionCheckCharacterTagsRestrict.GetTagNames(inConditionInfo))
			{
				list.Add(GameplayTagUtils.GetTagIdByName(tagName));
			}
			LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks[callback] = list;
			LevelConditionCheckCharacterTagsRestrict.SubscribeCallback(callback, list);
		}

		// Token: 0x060443C5 RID: 279493 RVA: 0x011B82D4 File Offset: 0x011B64D4
		public static void UnRegisterEvents(Condition inConditionInfo, TTagChangedCallback callback)
		{
			if (!LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks.Remove(callback))
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (string tagName in LevelConditionCheckCharacterTagsRestrict.GetTagNames(inConditionInfo))
			{
				list.Add(GameplayTagUtils.GetTagIdByName(tagName));
			}
			LevelConditionCheckCharacterTagsRestrict.UnsubscribeCallback(callback, list);
			LevelConditionCheckCharacterTagsRestrict.CallbackWrappers.Remove(callback);
			if (LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks.Count == 0)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.OnChangeRole;
				Action<EntityHandle, EntityHandle> handle;
				if ((handle = LevelConditionCheckCharacterTagsRestrict.<>O.<0>__OnChangeRole) == null)
				{
					handle = (LevelConditionCheckCharacterTagsRestrict.<>O.<0>__OnChangeRole = new Action<EntityHandle, EntityHandle>(LevelConditionCheckCharacterTagsRestrict.OnChangeRole));
				}
				instance.Remove(name, handle);
				LevelConditionCheckCharacterTagsRestrict.SubscribedEntity = null;
			}
		}

		// Token: 0x060443C6 RID: 279494 RVA: 0x011B8390 File Offset: 0x011B6590
		private static void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			foreach (KeyValuePair<TTagChangedCallback, List<int>> keyValuePair in LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks)
			{
				TTagChangedCallback ttagChangedCallback;
				List<int> list;
				keyValuePair.Deconstruct(out ttagChangedCallback, out list);
				TTagChangedCallback callback = ttagChangedCallback;
				List<int> tagIds = list;
				LevelConditionCheckCharacterTagsRestrict.UnsubscribeCallback(callback, tagIds);
			}
			LevelConditionCheckCharacterTagsRestrict.SubscribedEntity = ((newEntity != null) ? newEntity.Entity : null);
			foreach (KeyValuePair<TTagChangedCallback, List<int>> keyValuePair in LevelConditionCheckCharacterTagsRestrict.RegisteredCallbacks)
			{
				TTagChangedCallback ttagChangedCallback;
				List<int> list;
				keyValuePair.Deconstruct(out ttagChangedCallback, out list);
				TTagChangedCallback callback2 = ttagChangedCallback;
				List<int> tagIds2 = list;
				LevelConditionCheckCharacterTagsRestrict.SubscribeCallback(callback2, tagIds2);
			}
		}

		// Token: 0x060443C7 RID: 279495 RVA: 0x011B8454 File Offset: 0x011B6654
		private static void SubscribeCallback(TTagChangedCallback callback, List<int> tagIds)
		{
			WorldEntity subscribedEntity = LevelConditionCheckCharacterTagsRestrict.SubscribedEntity;
			BaseTagComponent baseTagComponent = (subscribedEntity != null) ? subscribedEntity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent == null)
			{
				return;
			}
			BaseTagComponent.TTagSwitchedCallback wrapper = LevelConditionCheckCharacterTagsRestrict.GetWrapper(callback);
			foreach (int tagId in tagIds)
			{
				baseTagComponent.AddTagAddOrRemoveListener(tagId, wrapper, null);
			}
		}

		// Token: 0x060443C8 RID: 279496 RVA: 0x011B84C4 File Offset: 0x011B66C4
		private static void UnsubscribeCallback(TTagChangedCallback callback, List<int> tagIds)
		{
			WorldEntity subscribedEntity = LevelConditionCheckCharacterTagsRestrict.SubscribedEntity;
			BaseTagComponent baseTagComponent = (subscribedEntity != null) ? subscribedEntity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent == null)
			{
				return;
			}
			BaseTagComponent.TTagSwitchedCallback wrapper = LevelConditionCheckCharacterTagsRestrict.GetWrapper(callback);
			foreach (int tagId in tagIds)
			{
				baseTagComponent.RemoveTagAddOrRemoveListener(tagId, wrapper);
			}
		}

		// Token: 0x060443C9 RID: 279497 RVA: 0x011B8530 File Offset: 0x011B6730
		private List<int> ParseTagIds([Nullable(2)] string raw)
		{
			List<int> list = new List<int>();
			foreach (string tagName in LevelConditionCheckCharacterTagsRestrict.ParseTagNames(raw))
			{
				list.Add(GameplayTagUtils.GetTagIdByName(tagName));
			}
			return list;
		}

		// Token: 0x060443CA RID: 279498 RVA: 0x011B8590 File Offset: 0x011B6790
		private TagIdRule GetRule(Condition inConditionInfo)
		{
			TagIdRule tagIdRule;
			if (!this.RuleCache.TryGetValue(inConditionInfo.Id, out tagIdRule))
			{
				tagIdRule = new TagIdRule
				{
					RequireTags = this.ParseTagIds(inConditionInfo.GetLimitParams("RequireTags")),
					BanTags = this.ParseTagIds(inConditionInfo.GetLimitParams("BanTags")),
					LastReached = false
				};
				this.RuleCache[inConditionInfo.Id] = tagIdRule;
			}
			return tagIdRule;
		}

		// Token: 0x060443CB RID: 279499 RVA: 0x011B8604 File Offset: 0x011B6804
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			LevelConditionCheckCharacterTagsRestrict.<>c__DisplayClass17_0 CS$<>8__locals1 = new LevelConditionCheckCharacterTagsRestrict.<>c__DisplayClass17_0();
			TagIdRule rule = this.GetRule(inConditionInfo);
			if (rule.RequireTags.Count == 0 && rule.BanTags.Count == 0)
			{
				return false;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return false;
			}
			LevelConditionCheckCharacterTagsRestrict.<>c__DisplayClass17_0 CS$<>8__locals2 = CS$<>8__locals1;
			WorldEntity entity = getCurrentEntity.Entity;
			CS$<>8__locals2.tagComp = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			if (CS$<>8__locals1.tagComp == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelCondition, ELogAuthor.CB, "[CheckRoleStateTag]无法获取当前角色BaseTagComponent组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			bool flag = true;
			bool flag2 = false;
			if (rule.RequireTags.Count > 0)
			{
				flag = rule.RequireTags.All((int tagId) => CS$<>8__locals1.tagComp.HasTag(tagId));
			}
			if (rule.BanTags.Count > 0)
			{
				flag2 = rule.BanTags.Any((int tagId) => CS$<>8__locals1.tagComp.HasTag(tagId));
			}
			rule.LastReached = (flag2 || !flag);
			bool lastReached = rule.LastReached;
			return rule.LastReached;
		}

		// Token: 0x040260CE RID: 155854
		private readonly Dictionary<int, TagIdRule> RuleCache = new Dictionary<int, TagIdRule>();

		// Token: 0x040260CF RID: 155855
		private static Dictionary<TTagChangedCallback, List<int>> RegisteredCallbacks;

		// Token: 0x040260D0 RID: 155856
		private static Dictionary<TTagChangedCallback, BaseTagComponent.TTagSwitchedCallback> CallbackWrappers;

		// Token: 0x040260D1 RID: 155857
		[Nullable(2)]
		private static WorldEntity SubscribedEntity;

		// Token: 0x0200CB1A RID: 51994
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403E580 RID: 255360
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<EntityHandle, EntityHandle> <0>__OnChangeRole;
		}
	}
}
