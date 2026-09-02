using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020030EC RID: 12524
[NullableContext(1)]
[Nullable(0)]
public class PawnHeadInfoComponent : EntityComponent, INpcIconFunction, IComponentDependency
{
	// Token: 0x17002310 RID: 8976
	// (get) Token: 0x06019E49 RID: 106057 RVA: 0x00792D15 File Offset: 0x00790F15
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(BaseActorComponent),
				typeof(CreatureDataComponent)
			};
		}
	}

	// Token: 0x06019E4A RID: 106058 RVA: 0x00792D38 File Offset: 0x00790F38
	protected override bool OnStart()
	{
		this.PawnInfoManageComp = base.Entity.GetComponent<PawnInfoManageComponent>();
		this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
		this.PawnPerceptionComp = base.Entity.GetComponent<PawnPerceptionComponent>();
		this.PawnInteractComp = base.Entity.GetComponent<PawnInteractNewComponent>();
		this.SelfLocationVector = global::Vector.Create();
		this.InitBaseInfo();
		CharacterActorComponent characterActorComponent = this.ActorComp as CharacterActorComponent;
		if (characterActorComponent != null)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int>(base.Entity, EEventName.CharBornFinished, new Action<int>(this.OnCharBornFinished));
			if (this.ActorComp.CreatureData.IsRole() && !characterActorComponent.IsRoleAndCtrlByMe)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.RefreshPlayerInfoVisible, new Action(this.RefreshPlayerInfoState));
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
			}
		}
		else
		{
			this.IsFixBornFinish = true;
			this.InitHeadIcon();
		}
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnAddDynamicOption, new Action(this.UpdateQuestIcon));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnRemoveDynamicOption, new Action(this.UpdateQuestIcon));
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnUpdateQuestIcon));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnInteractionSpotStateChange, new Action<bool>(this.UpdateInteractionSpotVisible));
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnEntityNameChanged, new Action(this.ResetCharacterInfo));
		return true;
	}

	// Token: 0x06019E4B RID: 106059 RVA: 0x00792EF4 File Offset: 0x007910F4
	private void InitBaseInfo()
	{
		CreatureDataComponent creatureData = this.ActorComp.CreatureData;
		if (creatureData == null)
		{
			return;
		}
		BaseInfoComponent baseInfo = creatureData.GetBaseInfo();
		this.IsShowNameOnHead = ((baseInfo != null) ? baseInfo.IsShowNameOnHead : null).GetValueOrDefault();
	}

	// Token: 0x06019E4C RID: 106060 RVA: 0x00792F3A File Offset: 0x0079113A
	private void OnCharBornFinished(int _)
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<int>(base.Entity, EEventName.CharBornFinished, new Action<int>(this.OnCharBornFinished));
		this.IsFixBornFinish = true;
		this.InitHeadIcon();
	}

	// Token: 0x06019E4D RID: 106061 RVA: 0x00792F6C File Offset: 0x0079116C
	private void InitHeadIcon()
	{
		bool isPendingCreateBeforeFixBorn = this.IsPendingCreateBeforeFixBorn;
		this.IsPendingCreateBeforeFixBorn = false;
		this.RefreshPlayerInfoState();
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		BaseInfoComponent baseInfoComponent = (component != null) ? component.GetBaseInfo() : null;
		if (baseInfoComponent != null && baseInfoComponent.HeadInfo != null)
		{
			this.AutoDestroyCheck = false;
			this.TryCreateIconComponent();
			return;
		}
		string text = (component != null) ? component.GetEntityTidName() : null;
		if (!string.IsNullOrEmpty(text) && Singleton<PublicUtil>.Instance.GetConfigTextByKey(text) != "")
		{
			int num = Math.Max(ConfigBase<NpcIconConfig>.Instance.GetNpcIconHeadInfoLimitMaxDistance(), 3000);
			int num2 = num + 500;
			uint gameBudgetManagedToken = base.Entity.GameBudgetManagedToken;
			this.PlayerNearbyEvent = ControllerBase<EnvironmentalPerceptionController>.Instance.CreatePlayerPerceptionEvent();
			this.PlayerNearbyEvent.Init((float)num, gameBudgetManagedToken, delegate
			{
				this.IsHeadNameInUse = true;
				this.TryCreateIconComponent();
			}, delegate
			{
				this.IsHeadNameInUse = false;
			}, new Action(this.DestroyPlayerNearbyEvent), null, (float)num2, null);
			if (gameBudgetManagedToken != 0U)
			{
				UKuroPerceptionInterface.MarkElementDisable(gameBudgetManagedToken, !base.Entity.Active);
			}
			return;
		}
		if (isPendingCreateBeforeFixBorn)
		{
			this.TryCreateIconComponent();
		}
	}

	// Token: 0x06019E4E RID: 106062 RVA: 0x00793094 File Offset: 0x00791294
	protected void DestroyPlayerNearbyEvent()
	{
		if (this.PlayerNearbyEvent != null)
		{
			ControllerBase<EnvironmentalPerceptionController>.Instance.DestroyPlayerPerceptionEvent(this.PlayerNearbyEvent);
			this.PlayerNearbyEvent = null;
		}
	}

	// Token: 0x06019E4F RID: 106063 RVA: 0x007930B5 File Offset: 0x007912B5
	private void TryCreateIconComponent()
	{
		if (this.IconCompCreatedPromise != null)
		{
			return;
		}
		this.IconCompCreatedPromise = new CustomPromise();
		if (!this.IsFixBornFinish)
		{
			this.IsPendingCreateBeforeFixBorn = true;
			return;
		}
		this.CreateIconComponent();
	}

	// Token: 0x06019E50 RID: 106064 RVA: 0x007930E4 File Offset: 0x007912E4
	protected void TryDestroyIconComponent(float delta)
	{
		if (!this.AutoDestroyCheck)
		{
			return;
		}
		if (this.IconComponent == null)
		{
			this.DestroyIconCompCountDown = 0f;
			return;
		}
		if (this.IsHeadNameInUse)
		{
			this.DestroyIconCompCountDown = 0f;
			return;
		}
		if (this.IsQuestIconInUse || this.IconComponent.IsHeadIconActive())
		{
			this.DestroyIconCompCountDown = 0f;
			return;
		}
		if (this.IsPlayerInfoInUse)
		{
			this.DestroyIconCompCountDown = 0f;
			return;
		}
		if (this.IconComponent.IsDialogueTextActive())
		{
			this.DestroyIconCompCountDown = 0f;
			return;
		}
		this.DestroyIconCompCountDown += delta;
		if (this.DestroyIconCompCountDown >= 6000f)
		{
			this.DestroyIconComponent();
		}
	}

	// Token: 0x06019E51 RID: 106065 RVA: 0x00793194 File Offset: 0x00791394
	protected void DestroyIconComponent()
	{
		if (this.IconCompCreatedPromise == null)
		{
			return;
		}
		if (this.IconCompCreatedPromise.IsPending)
		{
			this.IconCompCreatedPromise.SetResult();
		}
		this.IconCompCreatedPromise = null;
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent != null)
		{
			iconComponent.Destroy();
		}
		this.IconComponent = null;
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component != null)
		{
			component.GetPbDataId();
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.DisActiveBattleView, new Action(this.DisActiveBattleView));
	}

	// Token: 0x06019E52 RID: 106066 RVA: 0x00793214 File Offset: 0x00791414
	private UniTask CreateIconComponent()
	{
		PawnHeadInfoComponent.<CreateIconComponent>d__38 <CreateIconComponent>d__;
		<CreateIconComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateIconComponent>d__.<>4__this = this;
		<CreateIconComponent>d__.<>1__state = -1;
		<CreateIconComponent>d__.<>t__builder.Start<PawnHeadInfoComponent.<CreateIconComponent>d__38>(ref <CreateIconComponent>d__);
		return <CreateIconComponent>d__.<>t__builder.Task;
	}

	// Token: 0x06019E53 RID: 106067 RVA: 0x00793258 File Offset: 0x00791458
	private UniTask CreateIconComponentImp()
	{
		PawnHeadInfoComponent.<CreateIconComponentImp>d__39 <CreateIconComponentImp>d__;
		<CreateIconComponentImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateIconComponentImp>d__.<>4__this = this;
		<CreateIconComponentImp>d__.<>1__state = -1;
		<CreateIconComponentImp>d__.<>t__builder.Start<PawnHeadInfoComponent.<CreateIconComponentImp>d__39>(ref <CreateIconComponentImp>d__);
		return <CreateIconComponentImp>d__.<>t__builder.Task;
	}

	// Token: 0x06019E54 RID: 106068 RVA: 0x0079329C File Offset: 0x0079149C
	protected override bool OnEnd()
	{
		this.DestroyIconComponent();
		if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.CharBornFinished, new Action<int>(this.OnCharBornFinished)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharBornFinished, new Action<int>(this.OnCharBornFinished));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnAddDynamicOption, new Action(this.UpdateQuestIcon)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnAddDynamicOption, new Action(this.UpdateQuestIcon));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnRemoveDynamicOption, new Action(this.UpdateQuestIcon)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnRemoveDynamicOption, new Action(this.UpdateQuestIcon));
		}
		if (Singleton<EventSystem>.Instance.Has(EEventName.RefreshPlayerInfoVisible, new Action(this.RefreshPlayerInfoState)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshPlayerInfoVisible, new Action(this.RefreshPlayerInfoState));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnUpdateQuestIcon));
		if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnInteractionSpotStateChange, new Action<bool>(this.UpdateInteractionSpotVisible)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnInteractionSpotStateChange, new Action<bool>(this.UpdateInteractionSpotVisible));
		}
		if (Singleton<EventSystem>.Instance.Has(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnEntityNameChanged, new Action(this.ResetCharacterInfo)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnEntityNameChanged, new Action(this.ResetCharacterInfo));
		}
		return true;
	}

	// Token: 0x06019E55 RID: 106069 RVA: 0x007934DC File Offset: 0x007916DC
	public override void OnEntityWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
	{
		if (this.GetEntityType() == EEntityType.SceneItem)
		{
			SceneItemActorComponent sceneItemActorComponent = this.ActorComp as SceneItemActorComponent;
			if (sceneItemActorComponent == null || sceneItemActorComponent.PrefabRadius == 0f || sceneItemActorComponent.CurLevelPrefabShowActor is AEffectSystemActor)
			{
				NpcIconComponent iconComponent = this.IconComponent;
				if (iconComponent == null)
				{
					return;
				}
				iconComponent.OnNpcWasRecentlyRenderedOnScreenChange(true);
				return;
			}
		}
		NpcIconComponent iconComponent2 = this.IconComponent;
		if (iconComponent2 == null)
		{
			return;
		}
		iconComponent2.OnNpcWasRecentlyRenderedOnScreenChange(wasRecentlyRenderedOnScreen);
	}

	// Token: 0x06019E56 RID: 106070 RVA: 0x0079353E File Offset: 0x0079173E
	private void InitNpcIcon()
	{
		this.SetCharacterIconLocation();
		this.UpdateQuestIcon();
		this.ResetCharacterInfo();
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.SetInteractionSpotVisible(this.PendingInteractionSpotVisible);
	}

	// Token: 0x06019E57 RID: 106071 RVA: 0x00793568 File Offset: 0x00791768
	protected void SetCharacterIconLocation()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.SetCharacterIconLocation();
	}

	// Token: 0x06019E58 RID: 106072 RVA: 0x0079357A File Offset: 0x0079177A
	private void ResetCharacterInfo()
	{
		this.TryCreateIconComponent();
		PawnInfoManageComponent pawnInfoManageComp = this.PawnInfoManageComp;
		if (pawnInfoManageComp != null)
		{
			pawnInfoManageComp.UpdateNameAndHeadInfo();
		}
		this.SetCharacterName();
		this.SetCharacterSecondName();
		this.SetCharacterFunctionIcon();
	}

	// Token: 0x06019E59 RID: 106073 RVA: 0x007935A5 File Offset: 0x007917A5
	private void SetCharacterName()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		PawnInfoManageComponent pawnInfoManageComp = this.PawnInfoManageComp;
		iconComponent.SetCharacterName((pawnInfoManageComp != null) ? pawnInfoManageComp.PawnName : null);
	}

	// Token: 0x06019E5A RID: 106074 RVA: 0x007935C9 File Offset: 0x007917C9
	protected void SetCharacterSecondName()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		PawnInfoManageComponent pawnInfoManageComp = this.PawnInfoManageComp;
		iconComponent.SetCharacterSecondName((pawnInfoManageComp != null) ? pawnInfoManageComp.SecondName : null);
	}

	// Token: 0x06019E5B RID: 106075 RVA: 0x007935ED File Offset: 0x007917ED
	protected void SetCharacterFunctionIcon()
	{
		if (this.IsQuestIconInUse)
		{
			return;
		}
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		PawnInfoManageComponent pawnInfoManageComp = this.PawnInfoManageComp;
		iconComponent.SetCharacterFunctionIcon((pawnInfoManageComp != null) ? pawnInfoManageComp.FunctionIcon : null);
	}

	// Token: 0x06019E5C RID: 106076 RVA: 0x0079361A File Offset: 0x0079181A
	protected void SetCharacterQuestIcon(TaskMark mark)
	{
		if (!this.IsQuestIconInUse)
		{
			return;
		}
		this.IconComponent.SetNpcQuest(mark.NpcTaskIcon);
		this.IconComponent.MaxShowQuestDisSquared = (float)mark.IconDistant;
	}

	// Token: 0x06019E5D RID: 106077 RVA: 0x0079364A File Offset: 0x0079184A
	protected void SetPlayerInfoIcon(string path)
	{
		this.IconComponent.SetPlayerInfoIcon(path);
	}

	// Token: 0x06019E5E RID: 106078 RVA: 0x00793658 File Offset: 0x00791858
	protected override void OnEnable()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.SetHeadItemState(true);
	}

	// Token: 0x06019E5F RID: 106079 RVA: 0x0079366B File Offset: 0x0079186B
	protected override void OnDisable(string reason)
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.SetHeadItemState(false);
	}

	// Token: 0x06019E60 RID: 106080 RVA: 0x0079367E File Offset: 0x0079187E
	private EEntityType GetEntityType()
	{
		return base.Entity.GetComponent<CreatureDataComponent>().GetEntityType();
	}

	// Token: 0x06019E61 RID: 106081 RVA: 0x00793690 File Offset: 0x00791890
	private void OnTextLanguageChange(string oldLang, string newLang)
	{
		this.SetCharacterName();
		this.SetCharacterSecondName();
	}

	// Token: 0x06019E62 RID: 106082 RVA: 0x0079369E File Offset: 0x0079189E
	private void DisActiveBattleView()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.SetRootItemState(false);
	}

	// Token: 0x06019E63 RID: 106083 RVA: 0x007936B4 File Offset: 0x007918B4
	protected override void OnTick(float deltaTime)
	{
		base.OnTick(deltaTime);
		if (this.IsNeedTickCheckQuestIcon)
		{
			this.TickTime += deltaTime;
			if (this.TickTime > 1000f)
			{
				this.TickTime -= 1000f;
				this.UpdateQuestIcon();
			}
		}
		this.TryDestroyIconComponent(deltaTime);
	}

	// Token: 0x06019E64 RID: 106084 RVA: 0x0079370A File Offset: 0x0079190A
	private void OnUpdateQuestIcon(int id, QuestState status, EQuestStatusUpdateReason _)
	{
		this.UpdateQuestIcon();
	}

	// Token: 0x06019E65 RID: 106085 RVA: 0x00793714 File Offset: 0x00791914
	private void UpdateQuestIcon()
	{
		PawnInteractNewComponent pawnInteractComp = this.PawnInteractComp;
		PawnInteractController pawnInteractController = (pawnInteractComp != null) ? pawnInteractComp.GetInteractController() : null;
		if (pawnInteractController == null || pawnInteractController.QuestOptionList.Count == 0)
		{
			this.RefreshNpcQuest(null);
			return;
		}
		bool flag = false;
		foreach (CommonInteractOption commonInteractOption in pawnInteractController.QuestOptionList)
		{
			if (commonInteractOption.Context != null)
			{
				int? questMarkIdByContext = this.GetQuestMarkIdByContext(commonInteractOption.Context);
				if (questMarkIdByContext != null)
				{
					if (ControllerBase<LevelGeneralController>.Instance.CheckConditionNew(commonInteractOption.Condition, this.ActorComp.Owner, null, null))
					{
						this.RefreshNpcQuest(new int?(questMarkIdByContext.Value));
						this.IsNeedTickCheckQuestIcon = false;
						return;
					}
					flag = true;
				}
			}
		}
		if (flag)
		{
			this.IsNeedTickCheckQuestIcon = true;
		}
	}

	// Token: 0x06019E66 RID: 106086 RVA: 0x0079380C File Offset: 0x00791A0C
	private UniTask RefreshNpcQuest(int? markId = null)
	{
		PawnHeadInfoComponent.<RefreshNpcQuest>d__58 <RefreshNpcQuest>d__;
		<RefreshNpcQuest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshNpcQuest>d__.<>4__this = this;
		<RefreshNpcQuest>d__.markId = markId;
		<RefreshNpcQuest>d__.<>1__state = -1;
		<RefreshNpcQuest>d__.<>t__builder.Start<PawnHeadInfoComponent.<RefreshNpcQuest>d__58>(ref <RefreshNpcQuest>d__);
		return <RefreshNpcQuest>d__.<>t__builder.Task;
	}

	// Token: 0x06019E67 RID: 106087 RVA: 0x00793858 File Offset: 0x00791A58
	private int? GetQuestMarkIdByContext(GeneralContext context)
	{
		int? result = null;
		EGeneralContextType? type = context.Type;
		if (type != null)
		{
			EGeneralContextType valueOrDefault = type.GetValueOrDefault();
			if (valueOrDefault != EGeneralContextType.Quest)
			{
				if (valueOrDefault == EGeneralContextType.GeneralLogicTree)
				{
					GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
					BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(generalLogicTreeContext.TreeIncId), false);
					if (behaviorTree != null && behaviorTree.BtType == BtType.Quest)
					{
						global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(generalLogicTreeContext.TreeConfigId);
						if (quest != null && quest.Type == EQuest.Daily)
						{
							BehaviorNodeBase node = behaviorTree.GetNode(generalLogicTreeContext.NodeId);
							if (node != null && node.ContainTag(EBehaviorTreeTag.CanShow))
							{
								result = new int?(behaviorTree.GetTrackIconId());
							}
						}
					}
				}
			}
			else
			{
				QuestContext questContext = context as QuestContext;
				global::Quest quest2 = ModelBase<QuestNewModel>.Instance.GetQuest(questContext.QuestId);
				if (quest2 != null && !quest2.HideAcceptQuestMark.GetValueOrDefault())
				{
					result = new int?(quest2.QuestMarkId);
				}
			}
		}
		return result;
	}

	// Token: 0x06019E68 RID: 106088 RVA: 0x00793957 File Offset: 0x00791B57
	private void UpdateInteractionSpotVisible(bool isVisible)
	{
		if (this.IconComponent != null)
		{
			this.IconComponent.SetInteractionSpotVisible(isVisible);
			return;
		}
		this.PendingInteractionSpotVisible = isVisible;
	}

	// Token: 0x06019E69 RID: 106089 RVA: 0x00793978 File Offset: 0x00791B78
	public UniTask SetDialogueText(string text, float removeSeconds = -1f, bool redDot = false)
	{
		PawnHeadInfoComponent.<SetDialogueText>d__61 <SetDialogueText>d__;
		<SetDialogueText>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetDialogueText>d__.<>4__this = this;
		<SetDialogueText>d__.text = text;
		<SetDialogueText>d__.removeSeconds = removeSeconds;
		<SetDialogueText>d__.redDot = redDot;
		<SetDialogueText>d__.<>1__state = -1;
		<SetDialogueText>d__.<>t__builder.Start<PawnHeadInfoComponent.<SetDialogueText>d__61>(ref <SetDialogueText>d__);
		return <SetDialogueText>d__.<>t__builder.Task;
	}

	// Token: 0x06019E6A RID: 106090 RVA: 0x007939D3 File Offset: 0x00791BD3
	public void UpdateDialogUseState(bool value)
	{
		this.IsDialogIconInUse = value;
	}

	// Token: 0x06019E6B RID: 106091 RVA: 0x007939DC File Offset: 0x00791BDC
	public void UpdateDialogScale(float newScale)
	{
		if (newScale <= 0f || this.DialogWorldScale3D == newScale)
		{
			return;
		}
		this.DialogWorldScale3D = newScale;
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.UpdateDialogWorldScale();
	}

	// Token: 0x06019E6C RID: 106092 RVA: 0x00793A07 File Offset: 0x00791C07
	public float GetDialogWorldScale3D()
	{
		return this.DialogWorldScale3D;
	}

	// Token: 0x06019E6D RID: 106093 RVA: 0x00793A0F File Offset: 0x00791C0F
	public void HideDialogueText()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.HideDialogueText();
	}

	// Token: 0x06019E6E RID: 106094 RVA: 0x00793A21 File Offset: 0x00791C21
	public global::Vector GetSelfLocation()
	{
		return this.ActorComp.ActorLocationProxy;
	}

	// Token: 0x06019E6F RID: 106095 RVA: 0x00793A30 File Offset: 0x00791C30
	[NullableContext(2)]
	public UPrimitiveComponent GetAttachToMeshComponent()
	{
		if (this.GetEntityType() != EEntityType.SceneItem)
		{
			return this.ActorComp.SkeletalMesh;
		}
		CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent component = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent>();
		if (component != null && component.Valid)
		{
			return component.GetSkeletalMeshComponent();
		}
		return (this.ActorComp as SceneItemActorComponent).GetStaticMeshComponent();
	}

	// Token: 0x06019E70 RID: 106096 RVA: 0x00793A80 File Offset: 0x00791C80
	public string GetAttachToSocketName()
	{
		PawnInfoManageComponent pawnInfoManageComp = this.PawnInfoManageComp;
		return ((pawnInfoManageComp != null) ? pawnInfoManageComp.GetHeadStateSocketName() : null) ?? ConfigBase<NpcIconConfig>.Instance.GetNpcIconSocketName();
	}

	// Token: 0x06019E71 RID: 106097 RVA: 0x00793AA4 File Offset: 0x00791CA4
	public unsafe void GetAttachToLocation(global::Vector outVec)
	{
		BaseCharacterComponent baseCharacterComponent = this.ActorComp as BaseCharacterComponent;
		if (baseCharacterComponent != null)
		{
			FVectorDouble fvectorDouble = baseCharacterComponent.SkeletalMesh.D_K2_GetComponentLocation();
			outVec.Set(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z + (double)(2f * baseCharacterComponent.HalfHeight));
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HudUnit;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "获取根头顶组件位置";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			BaseActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RootLocation", outVec);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ActorLocation", baseCharacterComponent.ActorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("MeshLocation", fvectorDouble);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.ActorComp.SkeletalMesh;
		SceneItemActorComponent sceneItemActorComponent = this.ActorComp as SceneItemActorComponent;
		if (sceneItemActorComponent != null && uskeletalMeshComponent == null)
		{
			ASkeletalMeshActor interactionSkeletalMeshActor = sceneItemActorComponent.GetInteractionSkeletalMeshActor();
			uskeletalMeshComponent = ((interactionSkeletalMeshActor != null) ? interactionSkeletalMeshActor.SkeletalMeshComponent : null);
		}
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		FVectorDouble fvectorDouble2 = uskeletalMeshComponent.D_K2_GetComponentLocation();
		outVec.FromUeVector(fvectorDouble2);
	}

	// Token: 0x06019E72 RID: 106098 RVA: 0x00793BF9 File Offset: 0x00791DF9
	public double GetAddOffsetZ()
	{
		PawnInfoManageComponent pawnInfoManageComp = this.PawnInfoManageComp;
		return (double)((pawnInfoManageComp != null) ? pawnInfoManageComp.GetHeadStateOffset() : 0f);
	}

	// Token: 0x06019E73 RID: 106099 RVA: 0x00793C12 File Offset: 0x00791E12
	public bool IsShowNameInfo()
	{
		return this.IsShowNameOnHead;
	}

	// Token: 0x06019E74 RID: 106100 RVA: 0x00793C1A File Offset: 0x00791E1A
	public bool IsShowPlayerInfo()
	{
		return this.IsPlayerInfoInUse;
	}

	// Token: 0x06019E75 RID: 106101 RVA: 0x00793C22 File Offset: 0x00791E22
	public bool IsShowQuestInfo()
	{
		return this.InternalIsShowQuestInfo;
	}

	// Token: 0x06019E76 RID: 106102 RVA: 0x00793C2A File Offset: 0x00791E2A
	public bool IsDialogTextActive()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		return iconComponent != null && iconComponent.IsDialogueTextActive();
	}

	// Token: 0x06019E77 RID: 106103 RVA: 0x00793C40 File Offset: 0x00791E40
	public bool CanTick(float deltaTime)
	{
		if (this.IconComponent == null)
		{
			return false;
		}
		BaseActorComponent actorComp = this.ActorComp;
		if ((actorComp == null || !actorComp.CreatureData.IsRole()) && this.PawnPerceptionComp == null)
		{
			return false;
		}
		if (!this.CanShowHeadItem())
		{
			this.IconComponent.SetRootItemState(false);
			return false;
		}
		this.IconComponent.SetRootItemState(true);
		return true;
	}

	// Token: 0x06019E78 RID: 106104 RVA: 0x00793CA0 File Offset: 0x00791EA0
	public bool CanShowHeadItem()
	{
		return this.ShowHeadInfo && !ModelBase<PlotModel>.Instance.IsInHighLevelPlot() && Singleton<UiModel>.Instance.IsInMainView && base.Entity.Active;
	}

	// Token: 0x06019E79 RID: 106105 RVA: 0x00793CD8 File Offset: 0x00791ED8
	public bool IsInHeadItemShowRange(double disSquared, double maxShowRangeDisSquared, double minShowRangeDisSquared)
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		int? num = (component != null) ? new int?(component.GetPbDataId()) : null;
		ITrackData trackData = ModelBase<TrackModel>.Instance.IsTargetTracking(num.GetValueOrDefault());
		if (trackData != null && trackData.TrackSource != ETrackSource.MapMark)
		{
			global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation != null)
			{
				this.SelfLocationVector.DeepCopy(this.GetSelfLocation());
				double num2 = global::Vector.DistSquared(playerLocation, this.SelfLocationVector);
				float? num3 = trackData.TrackHideDis * trackData.TrackHideDis * (float)100;
				float num4 = (float)100;
				double? num5 = (num3 != null) ? new double?((double)(num3.GetValueOrDefault() * num4)) : null;
				return num2 < num5.GetValueOrDefault() & num5 != null;
			}
		}
		return disSquared < maxShowRangeDisSquared && disSquared > minShowRangeDisSquared;
	}

	// Token: 0x06019E7A RID: 106106 RVA: 0x00793E17 File Offset: 0x00792017
	public bool GetRootItemState()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		return iconComponent != null && iconComponent.GetRootItemState();
	}

	// Token: 0x06019E7B RID: 106107 RVA: 0x00793E2A File Offset: 0x0079202A
	public void EnableHeadInfo(bool enable)
	{
		if (this.ShowHeadInfo == enable)
		{
			return;
		}
		this.ShowHeadInfo = enable;
	}

	// Token: 0x06019E7C RID: 106108 RVA: 0x00793E40 File Offset: 0x00792040
	public bool CanShowPlayerInfo()
	{
		BaseActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.CreatureData.IsRole())
		{
			return false;
		}
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return false;
		}
		int playerId = this.ActorComp.CreatureData.GetPlayerId();
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int num = playerId;
		return !(id.GetValueOrDefault() == num & id != null) && ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId) != null;
	}

	// Token: 0x06019E7D RID: 106109 RVA: 0x00793EC0 File Offset: 0x007920C0
	public void RefreshPlayerInfoState()
	{
		bool flag = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.ShowOtherName, true, true) > 0 && this.CanShowPlayerInfo();
		if (this.IsPlayerInfoInUse == flag)
		{
			return;
		}
		this.IsPlayerInfoInUse = flag;
		this.UpdatePlayerInfoIcon(flag);
	}

	// Token: 0x06019E7E RID: 106110 RVA: 0x00793F1A File Offset: 0x0079211A
	private void OnCharacterMorphTypeChanged(Entity entity, EMorphType newMorphType, EMorphType oldMorphType)
	{
		this.SetCharacterIconLocation();
	}

	// Token: 0x06019E7F RID: 106111 RVA: 0x00793F24 File Offset: 0x00792124
	protected UniTask UpdatePlayerInfoIcon(bool active)
	{
		PawnHeadInfoComponent.<UpdatePlayerInfoIcon>d__83 <UpdatePlayerInfoIcon>d__;
		<UpdatePlayerInfoIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdatePlayerInfoIcon>d__.<>4__this = this;
		<UpdatePlayerInfoIcon>d__.active = active;
		<UpdatePlayerInfoIcon>d__.<>1__state = -1;
		<UpdatePlayerInfoIcon>d__.<>t__builder.Start<PawnHeadInfoComponent.<UpdatePlayerInfoIcon>d__83>(ref <UpdatePlayerInfoIcon>d__);
		return <UpdatePlayerInfoIcon>d__.<>t__builder.Task;
	}

	// Token: 0x06019E80 RID: 106112 RVA: 0x00793F70 File Offset: 0x00792170
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PawnHeadInfoComponent pawnHeadInfoComponent = (PawnHeadInfoComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (pawnHeadInfoComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PawnInfoManageComp"))
		{
			if (pawnHeadInfoComponent.PawnInfoManageComp == null)
			{
				this.PawnInfoManageComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnInfoManageComponent>(this.PawnInfoManageComp), "PawnInfoManageComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PawnPerceptionComp"))
		{
			if (pawnHeadInfoComponent.PawnPerceptionComp == null)
			{
				this.PawnPerceptionComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnPerceptionComponent>(this.PawnPerceptionComp), "PawnPerceptionComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PawnInteractComp"))
		{
			if (pawnHeadInfoComponent.PawnInteractComp == null)
			{
				this.PawnInteractComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnInteractNewComponent>(this.PawnInteractComp), "PawnInteractComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SelfLocationVector"))
		{
			if (pawnHeadInfoComponent.SelfLocationVector == null)
			{
				this.SelfLocationVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SelfLocationVector), "SelfLocationVector"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IconComponent"))
		{
			if (pawnHeadInfoComponent.IconComponent == null)
			{
				this.IconComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<NpcIconComponent>(this.IconComponent), "IconComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IconCompCreatedPromise"))
		{
			if (pawnHeadInfoComponent.IconCompCreatedPromise == null)
			{
				this.IconCompCreatedPromise = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CustomPromise>(this.IconCompCreatedPromise), "IconCompCreatedPromise"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PlayerNearbyEvent"))
		{
			if (pawnHeadInfoComponent.PlayerNearbyEvent == null)
			{
				this.PlayerNearbyEvent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.PlayerNearbyEvent), "PlayerNearbyEvent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AutoDestroyCheck"))
		{
			this.AutoDestroyCheck = pawnHeadInfoComponent.AutoDestroyCheck;
		}
		if (base.CanResetComponentProperty("DestroyIconCompCountDown"))
		{
			this.DestroyIconCompCountDown = pawnHeadInfoComponent.DestroyIconCompCountDown;
		}
		if (base.CanResetComponentProperty("IsFixBornFinish"))
		{
			this.IsFixBornFinish = pawnHeadInfoComponent.IsFixBornFinish;
		}
		if (base.CanResetComponentProperty("IsPendingCreateBeforeFixBorn"))
		{
			this.IsPendingCreateBeforeFixBorn = pawnHeadInfoComponent.IsPendingCreateBeforeFixBorn;
		}
		if (base.CanResetComponentProperty("IsQuestIconInUse"))
		{
			this.IsQuestIconInUse = pawnHeadInfoComponent.IsQuestIconInUse;
		}
		if (base.CanResetComponentProperty("IsDialogIconInUse"))
		{
			this.IsDialogIconInUse = pawnHeadInfoComponent.IsDialogIconInUse;
		}
		if (base.CanResetComponentProperty("DialogWorldScale3D"))
		{
			this.DialogWorldScale3D = pawnHeadInfoComponent.DialogWorldScale3D;
		}
		if (base.CanResetComponentProperty("IsHeadNameInUse"))
		{
			this.IsHeadNameInUse = pawnHeadInfoComponent.IsHeadNameInUse;
		}
		if (base.CanResetComponentProperty("IsPlayerInfoInUse"))
		{
			this.IsPlayerInfoInUse = pawnHeadInfoComponent.IsPlayerInfoInUse;
		}
		if (base.CanResetComponentProperty("IsShowNameOnHead"))
		{
			this.IsShowNameOnHead = pawnHeadInfoComponent.IsShowNameOnHead;
		}
		if (base.CanResetComponentProperty("ShowHeadInfo"))
		{
			this.ShowHeadInfo = pawnHeadInfoComponent.ShowHeadInfo;
		}
		if (base.CanResetComponentProperty("TickTime"))
		{
			this.TickTime = pawnHeadInfoComponent.TickTime;
		}
		if (base.CanResetComponentProperty("IsNeedTickCheckQuestIcon"))
		{
			this.IsNeedTickCheckQuestIcon = pawnHeadInfoComponent.IsNeedTickCheckQuestIcon;
		}
		if (base.CanResetComponentProperty("PendingInteractionSpotVisible"))
		{
			this.PendingInteractionSpotVisible = pawnHeadInfoComponent.PendingInteractionSpotVisible;
		}
		return true;
	}

	// Token: 0x0400CF99 RID: 53145
	private const int CHECK_QUEST_ICON_INTERVAL = 1000;

	// Token: 0x0400CF9A RID: 53146
	private const int DESTROY_ICON_COMP_TIME = 6000;

	// Token: 0x0400CF9B RID: 53147
	private const int MAX_ICON_COMP_DISTANCE = 3000;

	// Token: 0x0400CF9C RID: 53148
	private const string PLAYER_INFO_DECORATOR_KEY = "PrefabTextItem_PlayerName_Text";

	// Token: 0x0400CF9D RID: 53149
	[StaticVariableRuleIgnore]
	private static readonly string[] playerInfoIconPaths = new string[]
	{
		"/Game/Aki/UI/UIResources/Common/Atlas/SP_Common1P.SP_Common1P",
		"/Game/Aki/UI/UIResources/Common/Atlas/SP_Common2P.SP_Common2P",
		"/Game/Aki/UI/UIResources/Common/Atlas/SP_Common3P.SP_Common3P"
	};

	// Token: 0x0400CF9E RID: 53150
	[Nullable(2)]
	private BaseActorComponent ActorComp;

	// Token: 0x0400CF9F RID: 53151
	[Nullable(2)]
	private PawnInfoManageComponent PawnInfoManageComp;

	// Token: 0x0400CFA0 RID: 53152
	[Nullable(2)]
	private PawnPerceptionComponent PawnPerceptionComp;

	// Token: 0x0400CFA1 RID: 53153
	[Nullable(2)]
	private PawnInteractNewComponent PawnInteractComp;

	// Token: 0x0400CFA2 RID: 53154
	[Nullable(2)]
	private global::Vector SelfLocationVector;

	// Token: 0x0400CFA3 RID: 53155
	[Nullable(2)]
	private NpcIconComponent IconComponent;

	// Token: 0x0400CFA4 RID: 53156
	[Nullable(2)]
	private CustomPromise IconCompCreatedPromise;

	// Token: 0x0400CFA5 RID: 53157
	[Nullable(2)]
	private PlayerPerceptionEvent PlayerNearbyEvent;

	// Token: 0x0400CFA6 RID: 53158
	private bool AutoDestroyCheck = true;

	// Token: 0x0400CFA7 RID: 53159
	private float DestroyIconCompCountDown;

	// Token: 0x0400CFA8 RID: 53160
	private bool IsFixBornFinish;

	// Token: 0x0400CFA9 RID: 53161
	private bool IsPendingCreateBeforeFixBorn;

	// Token: 0x0400CFAA RID: 53162
	private bool IsQuestIconInUse;

	// Token: 0x0400CFAB RID: 53163
	protected bool IsDialogIconInUse;

	// Token: 0x0400CFAC RID: 53164
	protected float DialogWorldScale3D = 0.5f;

	// Token: 0x0400CFAD RID: 53165
	private bool IsHeadNameInUse;

	// Token: 0x0400CFAE RID: 53166
	private bool IsPlayerInfoInUse;

	// Token: 0x0400CFAF RID: 53167
	private readonly bool InternalIsShowQuestInfo;

	// Token: 0x0400CFB0 RID: 53168
	private bool IsShowNameOnHead;

	// Token: 0x0400CFB1 RID: 53169
	private bool ShowHeadInfo = true;

	// Token: 0x0400CFB2 RID: 53170
	private float TickTime;

	// Token: 0x0400CFB3 RID: 53171
	private bool IsNeedTickCheckQuestIcon;

	// Token: 0x0400CFB4 RID: 53172
	private bool PendingInteractionSpotVisible;
}
