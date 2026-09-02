using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02003202 RID: 12802
public class RoleTagComponent : BaseTagComponent
{
	// Token: 0x0601A8EC RID: 108780 RVA: 0x007DDB16 File Offset: 0x007DBD16
	[NullableContext(2)]
	protected override bool OnCreate(IEntityArgs args = null)
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoaded));
		return true;
	}

	// Token: 0x0601A8ED RID: 108781 RVA: 0x007DDB35 File Offset: 0x007DBD35
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoaded));
		return true;
	}

	// Token: 0x0601A8EE RID: 108782 RVA: 0x007DDB54 File Offset: 0x007DBD54
	private unsafe void OnFormationLoaded()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		int playerId = component.GetPlayerId();
		List<SceneTeamItem> teamItemsByPlayer = ModelBase<SceneTeamModel>.Instance.GetTeamItemsByPlayer(playerId);
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
		BaseTagComponent baseTagComponent = (playerEntity != null) ? playerEntity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "RoleTagComponent初始化时找不到对应的PlayerTag组件";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", (component != null) ? new int?(component.GetPlayerId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Entity", base.Entity.Id);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		bool flag = teamItemsByPlayer.Exists(delegate(SceneTeamItem formationIns)
		{
			EntityHandle entityHandle = formationIns.EntityHandle;
			return ((entityHandle != null) ? entityHandle.Entity : null) == base.Entity;
		}) && baseTagComponent != null;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (flag)
		{
			TagContainer tagContainer = this.TagContainer;
			TagContainer tagContainer2 = baseTagComponent.TagContainer;
			foreach (int num in this.TagContainer.GetAllExactTags())
			{
				dictionary[num] = tagContainer2.GetExactTagCount(num) - tagContainer.GetRawTagCount(ETagChannel.Player, num);
			}
			using (IEnumerator<int> enumerator = baseTagComponent.TagContainer.GetAllExactTags().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int num2 = enumerator.Current;
					if (!dictionary.ContainsKey(num2))
					{
						dictionary[num2] = tagContainer2.GetExactTagCount(num2) - tagContainer.GetRawTagCount(ETagChannel.Player, num2);
					}
				}
				goto IL_1EE;
			}
		}
		foreach (int num3 in this.TagContainer.GetAllExactTags())
		{
			dictionary[num3] = -this.TagContainer.GetRawTagCount(ETagChannel.Player, num3);
		}
		IL_1EE:
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			this.TagContainer.UpdateExactTag(ETagChannel.Player, keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x0601A8EF RID: 108783 RVA: 0x007DDDCC File Offset: 0x007DBFCC
	protected override void OnAnyTagChanged(int tagId, int newCount, int oldCount, int exactTagId)
	{
		if (tagId == 0 || oldCount == newCount)
		{
			return;
		}
		if ((tagId == GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"] || tagId == GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.后台"] || tagId == GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]) && ((newCount > 0 && oldCount <= 0) || (newCount <= 0 && oldCount > 0)))
		{
			GameplayTagPush gameplayTagPush = GameplayTagPush.Create();
			gameplayTagPush.TagId = tagId;
			gameplayTagPush.TagCount = newCount;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.GameplayTagPush, base.Entity, gameplayTagPush, null, null, null);
		}
		base.OnAnyTagChanged(tagId, newCount, oldCount, exactTagId);
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		int? num = (component != null) ? new int?(component.GetPlayerId()) : null;
		if (num != null)
		{
			WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(num.Value);
			PlayerBuffComponent playerBuffComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerBuffComponent>() : null;
			if (playerBuffComponent == null)
			{
				return;
			}
			playerBuffComponent.OnTagChanged(tagId);
		}
	}

	// Token: 0x0601A8F0 RID: 108784 RVA: 0x007DDECF File Offset: 0x007DC0CF
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleTagComponent roleTagComponent = (RoleTagComponent)componentTemplate;
		return true;
	}
}
