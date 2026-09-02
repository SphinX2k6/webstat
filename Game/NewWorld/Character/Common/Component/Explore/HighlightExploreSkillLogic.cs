using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004953 RID: 18771
	[NullableContext(2)]
	[Nullable(0)]
	public class HighlightExploreSkillLogic
	{
		// Token: 0x06031153 RID: 201043 RVA: 0x00C35B0C File Offset: 0x00C33D0C
		[NullableContext(1)]
		public void Init(BaseExploreComponent exploreComponent)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			string message = exploreComponent.LogKey + "高亮模块初始化";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", exploreComponent.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ExploreComponent = exploreComponent;
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(this.HighlightTagId))
			{
				this.TagComponent.RemoveTag(new int?(this.HighlightTagId));
				BaseTagComponent tagComponent2 = exploreComponent.TagComponent;
				if (tagComponent2 != null)
				{
					tagComponent2.AddTag(new int?(this.HighlightTagId));
				}
			}
			this.TagComponent = exploreComponent.TagComponent;
		}

		// Token: 0x06031154 RID: 201044 RVA: 0x00C35BBC File Offset: 0x00C33DBC
		public void Dispose()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CK;
			BaseExploreComponent exploreComponent = this.ExploreComponent;
			string message = ((exploreComponent != null) ? exploreComponent.LogKey : null) + "高亮模块清理";
			string item = "EntityId";
			BaseExploreComponent exploreComponent2 = this.ExploreComponent;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (exploreComponent2 != null) ? new int?(exploreComponent2.Entity.Id) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.Highlighting)
			{
				this.OnHideHighlightExploreSkill(true);
			}
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			this.ExploreComponent = null;
			this.TagComponent = null;
		}

		// Token: 0x06031155 RID: 201045 RVA: 0x00C35C6C File Offset: 0x00C33E6C
		public int GetHighlightSkillId()
		{
			if (!this.Highlighting)
			{
				return 0;
			}
			SVisionData visionData = PhantomUtil.GetVisionData((int)this.ExploreToolId);
			if (visionData != null && visionData.类型 == EVisionType.探索)
			{
				return visionData.技能ID;
			}
			return 0;
		}

		// Token: 0x06031156 RID: 201046 RVA: 0x00C35CB3 File Offset: 0x00C33EB3
		public int GetHighlightExploreToolId()
		{
			if (!this.Highlighting)
			{
				return 0;
			}
			return (int)this.ExploreToolId;
		}

		// Token: 0x06031157 RID: 201047 RVA: 0x00C35CC8 File Offset: 0x00C33EC8
		public unsafe void ShowHighlightExploreSkill(int exploreToolId, float duration, bool? needRevertSkill, string tagName = null, int? itemId = null, bool? needTips = null, bool? autoHideAfterUseExploreSkill = null)
		{
			if (this.Highlighting)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CK;
				string message = "上一次高亮探索技能未结束";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前ExploreToolId", this.ExploreToolId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("高亮ExploreToolId", exploreToolId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (exploreToolId == 1013 && ModelBase<GameModeModel>.Instance.IsMulti)
			{
				return;
			}
			if ((exploreToolId == 3001 && itemId == null) || (exploreToolId != 3001 && itemId != null))
			{
				return;
			}
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName ?? "角色.Common.技能通用标识.探索技能高亮");
			if (tagIdByName == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "高亮探索技能对应Tag未注册,请检查";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagName", tagName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData().IsExploreSkillIdAllowEquip(exploreToolId))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelEvent;
				ELogAuthor author3 = ELogAuthor.CK;
				string message3 = "尝试高亮的探索技能禁止在当前轮盘类型装配";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", exploreToolId);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			if (!this.ExploreComponent.CheckAllowLevelEventHighlightSkill())
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.LevelEvent;
				ELogAuthor author4 = ELogAuthor.CK;
				string message4 = "尝试高亮技能失败, CheckAllowLevelEventHighlightSkill判定不通过";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Id", exploreToolId);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			this.HighlightTagId = tagIdByName;
			this.ExploreToolId = (ERouletteExploreId)exploreToolId;
			this.ItemId = itemId.GetValueOrDefault(-1);
			this.NeedRevertSkill = needRevertSkill.GetValueOrDefault();
			this.Duration = ((duration > 0f) ? (duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond) : -1f);
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.LevelEvent;
			ELogAuthor author5 = ELogAuthor.CK;
			string message5 = "主动触发玩家探索技能高亮";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("Id", exploreToolId);
			instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			this.OnShowHighlightExploreSkill(needTips.GetValueOrDefault(), autoHideAfterUseExploreSkill.GetValueOrDefault(true));
		}

		// Token: 0x06031158 RID: 201048 RVA: 0x00C35EBC File Offset: 0x00C340BC
		public void HideHighlightExploreSkill()
		{
			if (!this.Highlighting)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.CK;
			string message = "主动触发玩家探索技能取消高亮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnHideHighlightExploreSkill(this.NeedRevertSkill);
		}

		// Token: 0x06031159 RID: 201049 RVA: 0x00C35F0F File Offset: 0x00C3410F
		private void TryAddTag()
		{
			if (this.TagComponent != null && !this.TagComponent.HasTag(this.HighlightTagId))
			{
				this.TagComponent.AddTag(new int?(this.HighlightTagId));
			}
		}

		// Token: 0x0603115A RID: 201050 RVA: 0x00C35F42 File Offset: 0x00C34142
		private void TryRemoveTag()
		{
			if (this.TagComponent != null && this.TagComponent.HasTag(this.HighlightTagId))
			{
				this.TagComponent.RemoveTag(new int?(this.HighlightTagId));
			}
		}

		// Token: 0x0603115B RID: 201051 RVA: 0x00C35F78 File Offset: 0x00C34178
		private void OnShowHighlightExploreSkill(bool needTips, bool autoHideAfterUseExploreSkill)
		{
			this.Highlighting = true;
			this.ExploreComponent.OnLevelEventHighlightSkillUpdate(true);
			EExploreSkillLayer layer = this.NeedRevertSkill ? EExploreSkillLayer.LevelEvent : EExploreSkillLayer.Roulette;
			if (this.ExploreToolId == ERouletteExploreId.道具装配)
			{
				ControllerBase<SpecialItemController>.Instance.EquipSpecialItem(this.ItemId, true, needTips, layer);
				ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId((int)this.ExploreToolId, layer, "触发技能高亮");
			}
			else if (ModelBase<CharacterExploreModel>.Instance.CheckNeedChangeSkill((int)this.ExploreToolId, EExploreSkillLayer.LevelEvent))
			{
				ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest((int)this.ExploreToolId, null, false);
				ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId((int)this.ExploreToolId, layer, "触发技能高亮");
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.CK;
			string message = "开始监听高亮事件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (autoHideAfterUseExploreSkill)
			{
				Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseExploreSkill));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnChangeSelectedExploreId, new Action(this.OnChangeExploreSkill));
			this.TryAddTag();
			this.StartTimer();
		}

		// Token: 0x0603115C RID: 201052 RVA: 0x00C36090 File Offset: 0x00C34290
		private void StartTimer()
		{
			if (this.Duration < 0f)
			{
				return;
			}
			if (this.Duration > 180000f)
			{
				this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.StartTimer();
				}, 180000f, null, null, true, 1f);
				return;
			}
			if (this.Duration < 20f)
			{
				this.OnHighlightTimeUp();
				return;
			}
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.OnHighlightTimeUp();
			}, this.Duration, null, null, true, 1f);
		}

		// Token: 0x0603115D RID: 201053 RVA: 0x00C36120 File Offset: 0x00C34320
		private void OnHideHighlightExploreSkill(bool needRevertSkill)
		{
			this.Highlighting = false;
			this.ExploreComponent.OnLevelEventHighlightSkillUpdate(false);
			this.TryRemoveTag();
			if (needRevertSkill)
			{
				bool flag = true;
				if (this.ExploreToolId == ERouletteExploreId.辅助机)
				{
					int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
					WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
					PlayerFollowableComponent playerFollowableComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerFollowableComponent>() : null;
					if (playerFollowableComponent != null && playerFollowableComponent.IsFollowerEnable())
					{
						flag = false;
					}
				}
				ModelBase<CharacterExploreModel>.Instance.ResetExplodeSkillId(EExploreSkillLayer.LevelEvent, "OnHideHighlightExploreSkill");
				if (flag)
				{
					int topLayerExplodeSkillId = ModelBase<CharacterExploreModel>.Instance.GetTopLayerExplodeSkillId();
					ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(topLayerExplodeSkillId, null, false);
				}
				else
				{
					ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId((int)this.ExploreToolId, EExploreSkillLayer.Roulette, "取消技能高亮");
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.CK;
			string message = "停止监听高亮事件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<EventSystem>.Instance.Has<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseExploreSkill)))
			{
				Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseExploreSkill));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeSelectedExploreId, new Action(this.OnChangeExploreSkill));
			if (this.TimerHandle != null && TimerSystem.Instance.Has(this.TimerHandle))
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			this.Duration = 0f;
		}

		// Token: 0x0603115E RID: 201054 RVA: 0x00C36290 File Offset: 0x00C34490
		private void OnHighlightTimeUp()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.CK;
			string message = "高亮时间结束，玩家探索技能取消高亮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnHideHighlightExploreSkill(this.NeedRevertSkill);
		}

		// Token: 0x0603115F RID: 201055 RVA: 0x00C362DC File Offset: 0x00C344DC
		private void OnChangeExploreSkill()
		{
			if (ModelBase<RouletteModel>.Instance.CurrentExploreSkillId != (int)this.ExploreToolId)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CK;
				string message = "切换探索技能，玩家探索技能取消高亮";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.TryRemoveTag();
				return;
			}
			if (this.ExploreToolId != ERouletteExploreId.道具装配)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.CK;
				string message2 = "切换探索技能，玩家探索技能高亮";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", this.ExploreToolId);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.TryAddTag();
				return;
			}
			if (ModelBase<RouletteModel>.Instance.CurrentEquipItemId == this.ItemId)
			{
				this.TryAddTag();
				return;
			}
			this.TryRemoveTag();
		}

		// Token: 0x06031160 RID: 201056 RVA: 0x00C36398 File Offset: 0x00C34598
		private void OnUseExploreSkill(int charId, int skillId, bool isAutonomousProxy)
		{
			int num = this.ExploreToolId - ERouletteExploreId.钩索 + 210001;
			if (skillId != num)
			{
				SVisionData visionData = PhantomUtil.GetVisionData((int)this.ExploreToolId);
				if (visionData != null)
				{
					num = visionData.技能ID;
				}
			}
			if (skillId == num)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CK;
				string message = "使用高亮技能，玩家探索技能取消高亮";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OnHideHighlightExploreSkill(this.NeedRevertSkill);
			}
		}

		// Token: 0x0401C418 RID: 115736
		[Nullable(1)]
		private const string DEFAULT_HIGHLIGHT_TAG = "角色.Common.技能通用标识.探索技能高亮";

		// Token: 0x0401C419 RID: 115737
		private int HighlightTagId = GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.探索技能高亮"];

		// Token: 0x0401C41A RID: 115738
		private ERouletteExploreId ExploreToolId = ERouletteExploreId.钩索;

		// Token: 0x0401C41B RID: 115739
		private int ItemId = -1;

		// Token: 0x0401C41C RID: 115740
		private bool NeedRevertSkill;

		// Token: 0x0401C41D RID: 115741
		private bool Highlighting;

		// Token: 0x0401C41E RID: 115742
		private float Duration;

		// Token: 0x0401C41F RID: 115743
		private TimerHandle TimerHandle;

		// Token: 0x0401C420 RID: 115744
		private BaseTagComponent TagComponent;

		// Token: 0x0401C421 RID: 115745
		private BaseExploreComponent ExploreComponent;
	}
}
