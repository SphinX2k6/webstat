using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

// Token: 0x02003056 RID: 12374
[NullableContext(1)]
[Nullable(0)]
public class CharacterInteractivePerformComponent : EntityComponent
{
	// Token: 0x06019641 RID: 104001 RVA: 0x00753228 File Offset: 0x00751428
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		return true;
	}

	// Token: 0x06019642 RID: 104002 RVA: 0x0075325E File Offset: 0x0075145E
	protected override bool OnEnd()
	{
		this.FinishRequest();
		return true;
	}

	// Token: 0x06019643 RID: 104003 RVA: 0x00753267 File Offset: 0x00751467
	protected void AddGlobalEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotBegin));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleBegin));
	}

	// Token: 0x06019644 RID: 104004 RVA: 0x007532A4 File Offset: 0x007514A4
	protected void AddEntityEvents(Entity entity)
	{
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChange));
	}

	// Token: 0x06019645 RID: 104005 RVA: 0x00753322 File Offset: 0x00751522
	protected void RemoveGlobalEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotBegin));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleBegin));
	}

	// Token: 0x06019646 RID: 104006 RVA: 0x0075335C File Offset: 0x0075155C
	protected void RemoveEntityEvents(Entity entity)
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChange));
	}

	// Token: 0x06019647 RID: 104007 RVA: 0x007533DA File Offset: 0x007515DA
	protected void OnPlotBegin(PlotInfo plotInfo)
	{
		this.TryInterruptResponse("剧情开始");
	}

	// Token: 0x06019648 RID: 104008 RVA: 0x007533E8 File Offset: 0x007515E8
	protected void OnBattleBegin(bool isInBattleState)
	{
		if (!isInBattleState)
		{
			return;
		}
		this.TryInterruptResponse("战斗开始");
	}

	// Token: 0x06019649 RID: 104009 RVA: 0x007533FA File Offset: 0x007515FA
	protected void OnUseSkill(int entityId, int skillId, bool IsAutonomousProxy)
	{
		this.TryInterruptResponse("使用技能");
	}

	// Token: 0x0601964A RID: 104010 RVA: 0x00753408 File Offset: 0x00751608
	protected void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		this.TryInterruptResponse("实体移除");
	}

	// Token: 0x0601964B RID: 104011 RVA: 0x00753416 File Offset: 0x00751616
	protected void OnPositionStateChange(global::ECharPositionState oldMoveState, global::ECharPositionState newMoveState)
	{
		if (newMoveState == global::ECharPositionState.Ground)
		{
			return;
		}
		this.TryInterruptResponse("位置模式改变");
	}

	// Token: 0x0601964C RID: 104012 RVA: 0x00753428 File Offset: 0x00751628
	protected void OnMoveStateChange(global::ECharMoveState oldMoveState, global::ECharMoveState newMoveState)
	{
		if (newMoveState == global::ECharMoveState.Stand)
		{
			return;
		}
		this.TryInterruptResponse("移动模式改变");
	}

	// Token: 0x0601964D RID: 104013 RVA: 0x0075343C File Offset: 0x0075163C
	public bool CanResponse()
	{
		if (this.TagComp == null)
		{
			return false;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = false;
		}
		else
		{
			BaseMoveComponent moveComp = actorComp.MoveComp;
			flag = ((moveComp != null) ? new bool?(moveComp.HasMoveInput) : null).GetValueOrDefault();
		}
		return !flag && !ModelBase<PlotModel>.Instance.IsInPlot && this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"]) && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]) && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]);
	}

	// Token: 0x0601964E RID: 104014 RVA: 0x007534F4 File Offset: 0x007516F4
	protected void AddConditionEvents(Entity entity, string type)
	{
		if (type == "HandInSeat")
		{
			this.ListenCharActionType = new ECharacterActionType?(ECharacterActionType.Sit);
			Singleton<EventSystem>.Instance.AddWithTarget(entity, EEventName.CharActionStateChange, new Action<ECharacterActionType, bool>(this.OnCharActionStateChange));
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool, EHoldingHandsRoleState, EHandType>(entity, EEventName.CharHoldingHandsChanged, new Action<int, bool, EHoldingHandsRoleState, EHandType>(this.OnCharHoldingHandsChange));
		}
	}

	// Token: 0x0601964F RID: 104015 RVA: 0x00753554 File Offset: 0x00751754
	protected void RemoveConditionEvents(Entity entity, string type)
	{
		if (type == "HandInSeat")
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool, EHoldingHandsRoleState, EHandType>(entity, EEventName.CharHoldingHandsChanged, new Action<int, bool, EHoldingHandsRoleState, EHandType>(this.OnCharHoldingHandsChange));
			Singleton<EventSystem>.Instance.RemoveWithTarget(entity, EEventName.CharActionStateChange, new Action<ECharacterActionType, bool>(this.OnCharActionStateChange));
			this.ListenCharActionType = null;
		}
	}

	// Token: 0x06019650 RID: 104016 RVA: 0x007535B4 File Offset: 0x007517B4
	protected bool CanResponseForHandInSeat()
	{
		CharacterActionComponent component = base.Entity.GetComponent<CharacterActionComponent>();
		if (component == null || !component.IsSitDown)
		{
			return false;
		}
		CharacterHoldingHandsComponent component2 = base.Entity.GetComponent<CharacterHoldingHandsComponent>();
		return component2 != null && component2.IsSitDownWithHoldingHands();
	}

	// Token: 0x06019651 RID: 104017 RVA: 0x007535F4 File Offset: 0x007517F4
	protected void OnCharHoldingHandsChange(int _1, bool _2, EHoldingHandsRoleState _3, EHandType _4)
	{
		this.TryInterruptResponse("牵手状态改变");
	}

	// Token: 0x06019652 RID: 104018 RVA: 0x00753604 File Offset: 0x00751804
	protected void OnCharActionStateChange(ECharacterActionType action, bool state)
	{
		ECharacterActionType? listenCharActionType = this.ListenCharActionType;
		if (!(listenCharActionType.GetValueOrDefault() == action & listenCharActionType != null))
		{
			return;
		}
		if (state)
		{
			return;
		}
		this.TryInterruptResponse("角色交互行为状态改变");
	}

	// Token: 0x06019653 RID: 104019 RVA: 0x0075363F File Offset: 0x0075183F
	public void AddRequestSignal(IRequestPerformParams request)
	{
		this.RequestCacheList[request.Signal] = request;
		this.TryResponse(request.Signal);
	}

	// Token: 0x06019654 RID: 104020 RVA: 0x00753660 File Offset: 0x00751860
	public void RemoveRequestSignal(int signal)
	{
		this.RequestCacheList.Remove(signal);
	}

	// Token: 0x06019655 RID: 104021 RVA: 0x0075366F File Offset: 0x0075186F
	public void AddResponseSignal(int signal, string context = "")
	{
		this.ResponseCacheList.Add(signal);
		this.TryResponse(signal);
	}

	// Token: 0x06019656 RID: 104022 RVA: 0x00753686 File Offset: 0x00751886
	public void RemoveResponseSignal(int signal)
	{
		this.ResponseCacheList.Remove(signal);
	}

	// Token: 0x06019657 RID: 104023 RVA: 0x00753698 File Offset: 0x00751898
	protected bool TryResponse(int signal)
	{
		if (!this.CanResponse())
		{
			return false;
		}
		if (this.CurHandleRequest != null)
		{
			return false;
		}
		if (!this.ResponseCacheList.Contains(signal))
		{
			return false;
		}
		IRequestPerformParams requestPerformParams;
		if (!this.RequestCacheList.TryGetValue(signal, out requestPerformParams) || requestPerformParams == null)
		{
			return false;
		}
		AnsPerform? configData = ConfigBase<AnsPerformConfig>.Instance.GetConfigData(requestPerformParams.Signal);
		if (configData == null || !this.RequestConditionCheck(requestPerformParams, configData.Value))
		{
			return false;
		}
		this.ResponseToRequest(requestPerformParams, configData.Value);
		return true;
	}

	// Token: 0x06019658 RID: 104024 RVA: 0x00753719 File Offset: 0x00751919
	protected bool RequestConditionCheck(IRequestPerformParams request, AnsPerform config)
	{
		return config.Condition == "HandInSeat" && this.CanResponseForHandInSeat();
	}

	// Token: 0x06019659 RID: 104025 RVA: 0x00753738 File Offset: 0x00751938
	protected void ResponseToRequest(IRequestPerformParams request, AnsPerform config)
	{
		if (!this.ResponseActionStart(config))
		{
			return;
		}
		this.CurHandleRequest = request;
		this.CurHandleConfig = new AnsPerform?(config);
		this.RemoveRequestSignal(request.Signal);
		this.RemoveResponseSignal(request.Signal);
		this.AddGlobalEvents();
		this.AddEntityEvents(base.Entity);
		this.AddEntityEvents(request.Source);
		this.AddConditionEvents(base.Entity, config.Condition);
	}

	// Token: 0x0601965A RID: 104026 RVA: 0x007537AC File Offset: 0x007519AC
	protected unsafe bool ResponseActionStart(AnsPerform config)
	{
		if (this.AnimComp == null)
		{
			return false;
		}
		string path = this.GetRoleMontagePathFromName(config.Action);
		if (path == "")
		{
			return false;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(path, delegate([Nullable(2)] UAnimMontage montage, string _)
		{
			if (montage == null || !montage.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BasePerform;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[InteractivePerform] 加载响应Montage失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "PbDataId";
				CharacterActorComponent actorComp = this.ActorComp;
				ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Signal", config.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Path", path);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.FinishRequest();
				return;
			}
			this.PlayResponseMontage(montage);
		}, 100, "js_undefined");
		return true;
	}

	// Token: 0x0601965B RID: 104027 RVA: 0x00753827 File Offset: 0x00751A27
	protected void ResponseActionAbort()
	{
		if (this.CurResponseMontage == null)
		{
			return;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
		if (mainAnimInstance == null)
		{
			return;
		}
		mainAnimInstance.Montage_Stop(0f, this.CurResponseMontage);
	}

	// Token: 0x0601965C RID: 104028 RVA: 0x00753857 File Offset: 0x00751A57
	protected bool TryInterruptResponse(string context)
	{
		if (this.CurHandleRequest == null)
		{
			return false;
		}
		this.ResponseActionAbort();
		this.FinishRequest();
		return true;
	}

	// Token: 0x0601965D RID: 104029 RVA: 0x00753870 File Offset: 0x00751A70
	protected void FinishRequest()
	{
		if (this.CurHandleRequest == null)
		{
			return;
		}
		this.RemoveGlobalEvents();
		this.RemoveEntityEvents(base.Entity);
		this.RemoveEntityEvents(this.CurHandleRequest.Source);
		this.RemoveConditionEvents(base.Entity, this.CurHandleConfig.Value.Condition);
		this.CurHandleRequest = null;
		this.CurHandleConfig = null;
	}

	// Token: 0x0601965E RID: 104030 RVA: 0x007538DC File Offset: 0x00751ADC
	protected void PlayResponseMontage(UAnimMontage montage)
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.Montage_Play(montage, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
			}
		}
		CharacterAnimationComponent animComp2 = this.AnimComp;
		if (animComp2 != null)
		{
			UAnimInstance mainAnimInstance2 = animComp2.MainAnimInstance;
			if (mainAnimInstance2 != null)
			{
				mainAnimInstance2.OnMontageEnded.Add(new Action<UAnimMontage, bool>(this.OnResponseMontageEnd));
			}
		}
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.通用过程标识.强制更新源姿势"]));
		}
		BaseTagComponent tagComp2 = this.TagComp;
		if (tagComp2 != null)
		{
			tagComp2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.通用过程标识.强制关闭IK"]));
		}
		this.CurResponseMontage = montage;
	}

	// Token: 0x0601965F RID: 104031 RVA: 0x00753994 File Offset: 0x00751B94
	[NullableContext(2)]
	protected void OnResponseMontageEnd(UAnimMontage montage, bool bInterrupt)
	{
		if (montage != this.CurResponseMontage)
		{
			return;
		}
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.通用过程标识.强制关闭IK"]));
		}
		BaseTagComponent tagComp2 = this.TagComp;
		if (tagComp2 != null)
		{
			tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.通用过程标识.强制更新源姿势"]));
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnResponseMontageEnd));
			}
		}
		this.CurResponseMontage = null;
		this.FinishRequest();
	}

	// Token: 0x06019660 RID: 104032 RVA: 0x00753A34 File Offset: 0x00751C34
	protected string GetRoleMontagePathFromName(string name)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		string text = (actorComp != null) ? actorComp.CreatureData.GetModelConfig().蓝图.ToAssetPathName() : null;
		if (text == null || text == "" || text == "None")
		{
			return "";
		}
		int num = text.LastIndexOf('/');
		int length = text.LastIndexOf('/', num - 1);
		string text2 = text.Substring(0, length);
		return string.Concat(new string[]
		{
			text2,
			"/BaseAnim/",
			name,
			".",
			name
		});
	}

	// Token: 0x06019661 RID: 104033 RVA: 0x00753ACC File Offset: 0x00751CCC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterInteractivePerformComponent characterInteractivePerformComponent = (CharacterInteractivePerformComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterInteractivePerformComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterInteractivePerformComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterInteractivePerformComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RequestCacheList"))
		{
			if (characterInteractivePerformComponent.RequestCacheList == null)
			{
				this.RequestCacheList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, IRequestPerformParams>>(this.RequestCacheList), "RequestCacheList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ResponseCacheList"))
		{
			if (characterInteractivePerformComponent.ResponseCacheList == null)
			{
				this.ResponseCacheList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.ResponseCacheList), "ResponseCacheList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurHandleRequest"))
		{
			if (characterInteractivePerformComponent.CurHandleRequest == null)
			{
				this.CurHandleRequest = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IRequestPerformParams>(this.CurHandleRequest), "CurHandleRequest"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurHandleConfig"))
		{
			this.CurHandleConfig = characterInteractivePerformComponent.CurHandleConfig;
		}
		if (base.CanResetComponentProperty("ListenCharActionType"))
		{
			this.ListenCharActionType = characterInteractivePerformComponent.ListenCharActionType;
		}
		if (base.CanResetComponentProperty("CurResponseMontage"))
		{
			if (characterInteractivePerformComponent.CurResponseMontage == null)
			{
				this.CurResponseMontage = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimMontage>(this.CurResponseMontage), "CurResponseMontage"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C8F7 RID: 51447
	public static readonly string[] animationList = new string[]
	{
		"/Game/Aki/Character/Role/MaleM/BaseAnim/AM_Sit_1_Stand.AM_Sit_1_Stand",
		"/Game/Aki/Character/Role/FemaleM/BaseAnim/AM_Sit_1_Stand.AM_Sit_1_Stand"
	};

	// Token: 0x0400C8F8 RID: 51448
	[Nullable(2)]
	protected CharacterActorComponent ActorComp;

	// Token: 0x0400C8F9 RID: 51449
	[Nullable(2)]
	protected CharacterAnimationComponent AnimComp;

	// Token: 0x0400C8FA RID: 51450
	[Nullable(2)]
	protected BaseTagComponent TagComp;

	// Token: 0x0400C8FB RID: 51451
	protected Dictionary<int, IRequestPerformParams> RequestCacheList = new Dictionary<int, IRequestPerformParams>();

	// Token: 0x0400C8FC RID: 51452
	protected HashSet<int> ResponseCacheList = new HashSet<int>();

	// Token: 0x0400C8FD RID: 51453
	[Nullable(2)]
	protected IRequestPerformParams CurHandleRequest;

	// Token: 0x0400C8FE RID: 51454
	protected AnsPerform? CurHandleConfig;

	// Token: 0x0400C8FF RID: 51455
	protected ECharacterActionType? ListenCharActionType;

	// Token: 0x0400C900 RID: 51456
	[Nullable(2)]
	protected UAnimMontage CurResponseMontage;
}
