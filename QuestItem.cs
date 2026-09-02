using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002669 RID: 9833
[NullableContext(1)]
[Nullable(0)]
public class QuestItem : UiPanelBase
{
	// Token: 0x060135DD RID: 79325 RVA: 0x00563BFC File Offset: 0x00561DFC
	[NullableContext(2)]
	public QuestItem(TQuestItemSelectHandle toggleSelectHandle)
	{
		this.ToggleSelectHandle = toggleSelectHandle;
	}

	// Token: 0x060135DE RID: 79326 RVA: 0x00563C0C File Offset: 0x00561E0C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060135DF RID: 79327 RVA: 0x00563E70 File Offset: 0x00562070
	protected override void OnStart()
	{
		this.ToggleSpriteComponent = (base.GetItem(7).GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition);
		this.ToggleSpriteComponent.SetEnable(false);
		base.GetItem(7).SetColor(this.ToggleSpriteComponent.TransitionState.CheckedHoverState.Color);
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060135E0 RID: 79328 RVA: 0x00563EE8 File Offset: 0x005620E8
	public void OnTick(float delta)
	{
		if (this.QuestId == 0)
		{
			return;
		}
		if (this.TickTime > 1000f)
		{
			this.TickTime -= 1000f;
			this.UpdateCountDownText(this.QuestId, true);
		}
		this.TickTime += delta;
	}

	// Token: 0x060135E1 RID: 79329 RVA: 0x00563F38 File Offset: 0x00562138
	public void UpdateItem(int inQuestId, int inQuestType)
	{
		this.QuestId = inQuestId;
		this.QuestType = inQuestType;
		this.UpdateToggle();
		this.UpdateTrackIconActive();
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.QuestId);
		if (quest == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "任务界面任务Item更新时找不到任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务Id", this.QuestId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.TreeId = quest.TreeId.GetValueOrDefault();
		this.SetColorSprite(quest);
		this.SetCircleSprite(quest);
		this.SetLockIcon();
		this.SetTrackIcon(quest);
		this.UpdateQuestName(quest);
		this.UpdateDistance(quest);
		this.UpdateFunctionIcon(quest);
		this.SetConditionText(quest);
		this.SetQuestTag(quest);
		bool uiactive = ModelBase<QuestNewModel>.Instance.IsInFocusOnQuest(this.QuestId);
		UUISprite sprite = base.GetSprite(14);
		if (sprite != null)
		{
			sprite.SetUIActive(uiactive);
		}
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.QuestViewItem, base.GetItem(6), null, this.QuestId);
	}

	// Token: 0x060135E2 RID: 79330 RVA: 0x00564036 File Offset: 0x00562236
	public void SetActiveItem(bool value)
	{
		this.SetActive(value);
		if (!value)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.QuestViewItem);
		}
	}

	// Token: 0x060135E3 RID: 79331 RVA: 0x00564050 File Offset: 0x00562250
	private void SetColorSprite(TQuest quest)
	{
		string questTypeColor = ConfigBase<QuestNewConfig>.Instance.GetQuestTypeColor((int)quest.Type);
		UUISprite sprite = base.GetSprite(5);
		if (StringUtils.IsEmpty(questTypeColor))
		{
			sprite.SetUIActive(false);
			return;
		}
		sprite.SetUIActive(true);
		sprite.SetColor(FColor.FromHex(questTypeColor));
	}

	// Token: 0x060135E4 RID: 79332 RVA: 0x0056409C File Offset: 0x0056229C
	private void SetCircleSprite(TQuest quest)
	{
		UUISprite sprite = base.GetSprite(15);
		if (!ModelBase<QuestNewModel>.Instance.IsQuestUnlock(this.QuestId))
		{
			sprite.SetUIActive(false);
			return;
		}
		string questMainTypeCircleColor = ConfigBase<QuestNewConfig>.Instance.GetQuestMainTypeCircleColor((int)quest.Type);
		if (StringUtils.IsEmpty(questMainTypeCircleColor))
		{
			sprite.SetUIActive(false);
			return;
		}
		sprite.SetUIActive(true);
		sprite.SetColor(FColor.FromHex(questMainTypeCircleColor));
	}

	// Token: 0x060135E5 RID: 79333 RVA: 0x00564100 File Offset: 0x00562300
	private void SetLockIcon()
	{
		string questLockIconPath = ModelBase<QuestNewModel>.Instance.GetQuestLockIconPath(this.QuestId);
		UUISprite sprite = base.GetSprite(1);
		if (StringUtils.IsEmpty(questLockIconPath))
		{
			sprite.SetUIActive(false);
			return;
		}
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		int? num = (curTrackedQuest != null) ? new int?(curTrackedQuest.Id) : null;
		int questId = this.QuestId;
		if (num.GetValueOrDefault() == questId & num != null)
		{
			sprite.SetUIActive(false);
			return;
		}
		this.SetSpriteByPath(questLockIconPath, sprite, true, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x060135E6 RID: 79334 RVA: 0x0056419C File Offset: 0x0056239C
	private void SetTrackIcon(global::Quest quest)
	{
		this.SetSpriteByPath(ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(quest.QuestMarkId), base.GetSprite(0), false, null, null);
	}

	// Token: 0x060135E7 RID: 79335 RVA: 0x005641D4 File Offset: 0x005623D4
	private void SetTrackBgSprite()
	{
		UUISprite sprite = base.GetSprite(16);
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.QuestId);
		if (quest == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		string questMainTypeTrackBgColor = ConfigBase<QuestNewConfig>.Instance.GetQuestMainTypeTrackBgColor((int)quest.Type);
		if (StringUtils.IsEmpty(questMainTypeTrackBgColor))
		{
			sprite.SetUIActive(false);
			return;
		}
		sprite.SetUIActive(true);
		sprite.SetColor(FColor.FromHex(questMainTypeTrackBgColor));
	}

	// Token: 0x060135E8 RID: 79336 RVA: 0x0056423C File Offset: 0x0056243C
	public void UpdateTrackIconActive()
	{
		EToggleState toggleState = base.GetExtendToggle(4).ToggleState;
		int questId = this.QuestId;
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		int? num = (curTrackedQuest != null) ? new int?(curTrackedQuest.Id) : null;
		bool uiactive = questId == num.GetValueOrDefault() & num != null;
		this.RefreshYellowItemShowState(toggleState);
		base.GetSprite(0).SetUIActive(uiactive);
		this.SetTrackBgSprite();
	}

	// Token: 0x060135E9 RID: 79337 RVA: 0x005642AC File Offset: 0x005624AC
	private void UpdateToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		extendToggle.OnStateChange.Clear();
		extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x060135EA RID: 79338 RVA: 0x005642D6 File Offset: 0x005624D6
	private void OnToggleStateChange(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.ToggleSelectHandle(this.QuestId);
		}
	}

	// Token: 0x060135EB RID: 79339 RVA: 0x005642ED File Offset: 0x005624ED
	private void UpdateQuestName(global::Quest quest)
	{
		base.GetText(2).SetText(quest.Name, true);
	}

	// Token: 0x060135EC RID: 79340 RVA: 0x00564304 File Offset: 0x00562504
	private void UpdateDistance(global::Quest quest)
	{
		UUIText text = base.GetText(3);
		if (quest.IsSuspend())
		{
			text.SetUIActive(false);
			return;
		}
		BehaviorNodeBase currentActiveChildQuestNode = quest.GetCurrentActiveChildQuestNode();
		if (currentActiveChildQuestNode == null)
		{
			text.SetUIActive(false);
			return;
		}
		if (!ControllerBase<GeneralLogicTreeController>.Instance.IsShowNodeTrackDistance(quest.TreeId.Value, currentActiveChildQuestNode.NodeId))
		{
			text.SetUIActive(false);
			return;
		}
		BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(quest.TreeId.Value), false);
		if (behaviorTree == null)
		{
			text.SetUIActive(false);
			return;
		}
		if (MapUtil.GetDungeonsRelation(ModelBase<CreatureModel>.Instance.GetInstanceId(), behaviorTree.DungeonId) == EDungeonRelationType.DifferentWorld)
		{
			text.SetUIActive(false);
			return;
		}
		double? trackDistance = quest.GetTrackDistance(currentActiveChildQuestNode.NodeId);
		if (!quest.IsInTrackRange() && trackDistance != null)
		{
			double? num = trackDistance;
			double num2 = 0.0;
			if (!(num.GetValueOrDefault() <= num2 & num != null))
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "Meter", new <>z__ReadOnlySingleElementList<object>(trackDistance));
				text.SetUIActive(true);
				return;
			}
		}
		text.SetUIActive(false);
	}

	// Token: 0x060135ED RID: 79341 RVA: 0x00564420 File Offset: 0x00562620
	public void UpdateFunctionIcon(global::Quest quest)
	{
		UUITexture texture = base.GetTexture(8);
		UUISprite sprite = base.GetSprite(9);
		if (quest != null && quest.Type == EQuest.Guide && quest.FunctionId != null)
		{
			int? functionId = quest.FunctionId;
			int num = 0;
			if (!(functionId.GetValueOrDefault() == num & functionId != null))
			{
				FunctionCondition? config = ConfigFunctionConditionByFunctionId.GetConfig(quest.FunctionId.Value, true);
				if (config == null)
				{
					texture.SetUIActive(false);
					sprite.SetUIActive(false);
					return;
				}
				if (!StringUtils.IsBlank(config.Value.Icon))
				{
					base.SetTextureByPath(config.Value.Icon, texture, null, null);
					texture.SetUIActive(true);
					sprite.SetUIActive(false);
					return;
				}
				if (!StringUtils.IsBlank(config.Value.IconSprite))
				{
					this.SetSpriteByPath(config.Value.IconSprite, sprite, false, null, null);
					sprite.SetUIActive(true);
					texture.SetUIActive(false);
					return;
				}
				texture.SetUIActive(false);
				sprite.SetUIActive(false);
				return;
			}
		}
		texture.SetUIActive(false);
		sprite.SetUIActive(false);
	}

	// Token: 0x060135EE RID: 79342 RVA: 0x00564550 File Offset: 0x00562750
	private void SetConditionText(global::Quest quest)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		this.IsNeedCountDown = false;
		UUIText text = base.GetText(10);
		EQuestSpecialState questSpecialState = instance.GetQuestSpecialState(quest);
		string text2 = null;
		string text3 = null;
		switch (questSpecialState)
		{
		case EQuestSpecialState.PreShow:
			text2 = ModelBase<QuestNewModel>.Instance.GetShowQuestConditionDescribe(quest.Id);
			text3 = (ConfigCommonParamById.GetStringConfig("TaskUnableColor") ?? "");
			break;
		case EQuestSpecialState.LockByLackResource:
			text2 = (ConfigMultiTextLang.GetLocalTextNew("DownloadResource", null) ?? "DownloadResource");
			text3 = (ConfigCommonParamById.GetStringConfig("TaskUnableColor") ?? "");
			break;
		case EQuestSpecialState.Suspend:
		{
			string suspendText = quest.GetSuspendText();
			text2 = ((suspendText != null) ? suspendText.Split('，', StringSplitOptions.None)[0] : null);
			text3 = (ConfigCommonParamById.GetStringConfig("TaskUnableColor") ?? "");
			break;
		}
		case EQuestSpecialState.LockQuestSuspendByOnline:
			text2 = (ConfigBase<TextConfig>.Instance.GetTextById("SuspendByOnline") ?? "SuspendByOnline");
			text3 = (ConfigCommonParamById.GetStringConfig("TaskUnableColor") ?? "");
			break;
		case EQuestSpecialState.HasRecommendQuest:
		{
			List<int> recommendPreQuest = quest.GetRecommendPreQuest();
			string item = "";
			if (recommendPreQuest != null && recommendPreQuest.Count > 0)
			{
				global::Quest quest2 = ModelBase<QuestNewModel>.Instance.GetQuest(recommendPreQuest[0]);
				item = (((quest2 != null) ? quest2.Name : null) ?? "");
			}
			Singleton<LguiUtil>.Instance.SetLocalText(text, "QuestRecommendTip", new <>z__ReadOnlySingleElementList<object>(item));
			text3 = (ConfigCommonParamById.GetStringConfig("TaskRemindColor") ?? "");
			break;
		}
		case EQuestSpecialState.RefOccupiedEntity:
		{
			string refOccupiedEntityText = quest.GetRefOccupiedEntityText();
			text2 = ((refOccupiedEntityText != null) ? refOccupiedEntityText.Split('，', StringSplitOptions.None)[0] : null);
			text3 = (ConfigCommonParamById.GetStringConfig("TaskUnableColor") ?? "");
			break;
		}
		case EQuestSpecialState.LockByFocusMode:
			text2 = (ConfigMultiTextLang.GetLocalTextNew("Task_Focus_Tips01", null) ?? "Task_Focus_Tips01");
			text3 = (ConfigCommonParamById.GetStringConfig("TaskUnableColor") ?? "");
			break;
		case EQuestSpecialState.ActivityGuideQuest:
		case EQuestSpecialState.ActivityQuest:
			this.IsNeedCountDown = true;
			this.UpdateCountDownText(quest.Id, false);
			text3 = (ConfigCommonParamById.GetStringConfig("TaskCountDownColor") ?? "");
			break;
		}
		if (text3 != null && !StringUtils.IsBlank(text3))
		{
			FColor color = FColor.FromHex(text3);
			text.SetColor(color);
		}
		if (text2 != null && !StringUtils.IsBlank(text2))
		{
			text.SetText(text2, true);
			text.SetUIActive(true);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x060135EF RID: 79343 RVA: 0x005647B0 File Offset: 0x005629B0
	private void UpdateCountDownText(int questId, bool bSendEvent)
	{
		if (!this.IsNeedCountDown)
		{
			return;
		}
		if (ModelBase<QuestNewModel>.Instance.GetQuest(this.QuestId) == null)
		{
			if (bSendEvent)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityQuestCountdownEnd, questId);
				this.IsNeedCountDown = false;
			}
			return;
		}
		UUIText text = base.GetText(10);
		int num = ModelBase<QuestNewModel>.Instance.GetQuestBindingActivityId(questId);
		ActivityBaseData activityById;
		if (num != 0)
		{
			activityById = ModelBase<ActivityModel>.Instance.GetActivityById(num);
			if (activityById != null)
			{
				ActivityBaseData activityBaseData = activityById;
				if (activityBaseData.LocalConfig != null && activityBaseData.LocalConfig.GetValueOrDefault().IfShowQuestLeftTime)
				{
					goto IL_BD;
				}
			}
			text.SetUIActive(false);
			return;
		}
		num = ModelBase<QuestNewModel>.Instance.GetQuestActivityId(questId);
		activityById = ModelBase<ActivityModel>.Instance.GetActivityById(num);
		if (activityById == null || !ModelBase<QuestNewModel>.Instance.GetQuestShowQuestLeftTime(questId))
		{
			text.SetUIActive(false);
			return;
		}
		IL_BD:
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		if (localTextNew == null)
		{
			text.SetUIActive(false);
			return;
		}
		if (!activityById.CheckIfInOpenTime())
		{
			if (bSendEvent)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityQuestCountdownEnd, questId);
				this.IsNeedCountDown = false;
			}
			return;
		}
		if (activityById.EndOpenTime == 0L)
		{
			text.SetUIActive(false);
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = (double)activityById.EndOpenTime - serverTime;
		string activityGuideQuestRemainTimeText = ModelBase<QuestNewModel>.Instance.GetActivityGuideQuestRemainTimeText(remainTime, localTextNew);
		text.SetText(activityGuideQuestRemainTimeText, true);
	}

	// Token: 0x060135F0 RID: 79344 RVA: 0x005648F8 File Offset: 0x00562AF8
	private unsafe void SetQuestTag(global::Quest quest)
	{
		QuestItem.<>c__DisplayClass29_0 CS$<>8__locals1 = new QuestItem.<>c__DisplayClass29_0();
		CS$<>8__locals1.questTagRoot = base.GetItem(11);
		if (CS$<>8__locals1.questTagRoot == null)
		{
			return;
		}
		int num = this.IsOnlineDisabledByQuestId(this.QuestId) ? 9 : quest.TagId;
		if (num == 0)
		{
			CS$<>8__locals1.questTagRoot.SetUIActive(false);
			return;
		}
		CS$<>8__locals1.questTagConfig = ConfigQuestTagById.GetConfig(num, true);
		if (CS$<>8__locals1.questTagConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到任务标签配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("questId", quest.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TagId", num);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		CS$<>8__locals1.tagText = base.GetText(13);
		UUIText tagText = CS$<>8__locals1.tagText;
		if (tagText != null)
		{
			tagText.SetText("", true);
		}
		UUISprite sprite = base.GetSprite(12);
		if (sprite != null)
		{
			this.SetSpriteByPath(CS$<>8__locals1.questTagConfig.Value.BgSpritePath, sprite, CS$<>8__locals1.questTagConfig.Value.UseOriginalSize, null, delegate(bool success)
			{
				if (success && CS$<>8__locals1.questTagConfig.Value.UseOriginalSize)
				{
					base.<SetQuestTag>g__DoSetTextAndShow|0();
				}
			});
		}
		if (!CS$<>8__locals1.questTagConfig.Value.UseOriginalSize)
		{
			CS$<>8__locals1.<SetQuestTag>g__DoSetTextAndShow|0();
		}
	}

	// Token: 0x060135F1 RID: 79345 RVA: 0x00564A5C File Offset: 0x00562C5C
	private bool IsOnlineDisabledByQuestId(int questId)
	{
		IReadOnlyDictionary<DisableOnlineSource, EDisableOnlineType> onlineDisabledSource = ModelBase<OnlineModel>.Instance.GetOnlineDisabledSource();
		if (onlineDisabledSource == null)
		{
			return false;
		}
		foreach (KeyValuePair<DisableOnlineSource, EDisableOnlineType> keyValuePair in onlineDisabledSource)
		{
			DisableOnlineSource disableOnlineSource;
			EDisableOnlineType edisableOnlineType;
			keyValuePair.Deconstruct(out disableOnlineSource, out edisableOnlineType);
			DisableOnlineSource disableOnlineSource2 = disableOnlineSource;
			if (disableOnlineSource2.Type == EDisableOnlineType.NonOnlineQuest && disableOnlineSource2.TreeId == questId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060135F2 RID: 79346 RVA: 0x00564AD8 File Offset: 0x00562CD8
	public void SetSelected(bool value)
	{
		EToggleState state = value ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(4).SetToggleState(state, false, false, false);
		if (value)
		{
			this.ClickHandle();
		}
		this.RefreshYellowItemShowState(state);
	}

	// Token: 0x060135F3 RID: 79347 RVA: 0x00564B10 File Offset: 0x00562D10
	private void RefreshYellowItemShowState(EToggleState state)
	{
		UUIItem item = base.GetItem(7);
		if (state == EToggleState.ETT_Checked)
		{
			int questId = this.QuestId;
			global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
			int? num = (curTrackedQuest != null) ? new int?(curTrackedQuest.Id) : null;
			if (!(questId == num.GetValueOrDefault() & num != null))
			{
				item.SetUIActive(true);
			}
			else
			{
				item.SetUIActive(false);
			}
			UUISprite sprite = base.GetSprite(1);
			if (item != null)
			{
				UUIItem parentAsUIItem = item.GetParentAsUIItem();
				if (parentAsUIItem == null)
				{
					return;
				}
				parentAsUIItem.SetUIActive(!sprite.bIsUIActive);
				return;
			}
		}
		else
		{
			item.SetUIActive(false);
		}
	}

	// Token: 0x060135F4 RID: 79348 RVA: 0x00564BA4 File Offset: 0x00562DA4
	public void SetNotAllowNoneSelect()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		UUIItem uuiitem = extendToggle.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetRaycastTarget(extendToggle.ToggleState != EToggleState.ETT_Checked);
	}

	// Token: 0x060135F5 RID: 79349 RVA: 0x00564BDD File Offset: 0x00562DDD
	private void ClickHandle()
	{
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.UpdateQuestDetails, this.QuestId, true);
	}

	// Token: 0x060135F6 RID: 79350 RVA: 0x00564BF6 File Offset: 0x00562DF6
	public UUIItem GetTaskToggleItem()
	{
		return base.GetExtendToggle(4).RootUIComp;
	}

	// Token: 0x060135F7 RID: 79351 RVA: 0x00564C09 File Offset: 0x00562E09
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x04009729 RID: 38697
	private const int TICK_INTERVAL = 1000;

	// Token: 0x0400972A RID: 38698
	private const int ONLINE_LIMIT_TAG_ID = 9;

	// Token: 0x0400972B RID: 38699
	public int QuestId;

	// Token: 0x0400972C RID: 38700
	public long TreeId;

	// Token: 0x0400972D RID: 38701
	public int QuestType;

	// Token: 0x0400972E RID: 38702
	private bool IsNeedCountDown;

	// Token: 0x0400972F RID: 38703
	private float TickTime;

	// Token: 0x04009730 RID: 38704
	[Nullable(2)]
	private readonly TQuestItemSelectHandle ToggleSelectHandle;

	// Token: 0x04009731 RID: 38705
	[Nullable(2)]
	private UUIExtendToggleSpriteTransition ToggleSpriteComponent;

	// Token: 0x020089FB RID: 35323
	[NullableContext(0)]
	private class EQuestItemComponent
	{
		// Token: 0x0402E8A0 RID: 190624
		public const int TrackIcon = 0;

		// Token: 0x0402E8A1 RID: 190625
		public const int LockIcon = 1;

		// Token: 0x0402E8A2 RID: 190626
		public const int QuestNameText1 = 2;

		// Token: 0x0402E8A3 RID: 190627
		public const int QuestDistanceText1 = 3;

		// Token: 0x0402E8A4 RID: 190628
		public const int Toggle = 4;

		// Token: 0x0402E8A5 RID: 190629
		public const int ColorSprite = 5;

		// Token: 0x0402E8A6 RID: 190630
		public const int RedDot = 6;

		// Token: 0x0402E8A7 RID: 190631
		public const int YellowDot = 7;

		// Token: 0x0402E8A8 RID: 190632
		public const int FunctionIcon = 8;

		// Token: 0x0402E8A9 RID: 190633
		public const int FunctionSpriteIcon = 9;

		// Token: 0x0402E8AA RID: 190634
		public const int ConditionText = 10;

		// Token: 0x0402E8AB RID: 190635
		public const int QuestTagRoot = 11;

		// Token: 0x0402E8AC RID: 190636
		public const int QuestTagBgSprite = 12;

		// Token: 0x0402E8AD RID: 190637
		public const int QuestTagText = 13;

		// Token: 0x0402E8AE RID: 190638
		public const int FocusModeSprite = 14;

		// Token: 0x0402E8AF RID: 190639
		public const int CircleSprite = 15;

		// Token: 0x0402E8B0 RID: 190640
		public const int TrackBgSprite = 16;
	}
}
