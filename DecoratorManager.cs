using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Ai;
using Aki.Protocol.Debug;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component;

// Token: 0x02003510 RID: 13584
public class DecoratorManager
{
	// Token: 0x0601CAD6 RID: 117462 RVA: 0x008AF4E4 File Offset: 0x008AD6E4
	public static bool Init()
	{
		Action<Entity, AiInformationNotify, CombatCommon> callBack;
		if ((callBack = DecoratorManager.<>O.<0>__AiInformationNotify) == null)
		{
			callBack = (DecoratorManager.<>O.<0>__AiInformationNotify = new Action<Entity, AiInformationNotify, CombatCommon>(AiController.AiInformationNotify));
		}
		CombatNet.Listen<AiInformationNotify>(callBack, ENotifyMessageId.AiInformationNotify, true, false);
		Action<Entity, AiBlackboardCdNotify, CombatCommon> callBack2;
		if ((callBack2 = DecoratorManager.<>O.<1>__AiInformationS) == null)
		{
			callBack2 = (DecoratorManager.<>O.<1>__AiInformationS = new Action<Entity, AiBlackboardCdNotify, CombatCommon>(AiController.AiInformationS));
		}
		CombatNet.Listen<AiBlackboardCdNotify>(callBack2, ENotifyMessageId.AiBlackboardCdNotify, true, false);
		Action<Entity, NewLinkNotify, CombatCommon> callBack3;
		if ((callBack3 = DecoratorManager.<>O.<2>__OnNewLinkStateNotify) == null)
		{
			callBack3 = (DecoratorManager.<>O.<2>__OnNewLinkStateNotify = new Action<Entity, NewLinkNotify, CombatCommon>(BattleLinkController.OnNewLinkStateNotify));
		}
		CombatNet.Listen<NewLinkNotify>(callBack3, ENotifyMessageId.NewLinkNotify, false, false);
		Action<Entity, EntityIsVisibleNotify, CombatCommon> callBack4;
		if ((callBack4 = DecoratorManager.<>O.<3>__EntityIsVisibleNotify) == null)
		{
			callBack4 = (DecoratorManager.<>O.<3>__EntityIsVisibleNotify = new Action<Entity, EntityIsVisibleNotify, CombatCommon>(CombatMessageController.EntityIsVisibleNotify));
		}
		CombatNet.Listen<EntityIsVisibleNotify>(callBack4, ENotifyMessageId.EntityIsVisibleNotify, true, true);
		Action<Entity, ActorVisibleNotify, CombatCommon> callBack5;
		if ((callBack5 = DecoratorManager.<>O.<4>__ActorIsVisibleNotify) == null)
		{
			callBack5 = (DecoratorManager.<>O.<4>__ActorIsVisibleNotify = new Action<Entity, ActorVisibleNotify, CombatCommon>(CombatMessageController.ActorIsVisibleNotify));
		}
		CombatNet.Listen<ActorVisibleNotify>(callBack5, ENotifyMessageId.ActorVisibleNotify, true, true);
		Action<Entity, EntityLoadCompleteNotify, CombatCommon> callBack6;
		if ((callBack6 = DecoratorManager.<>O.<5>__EntityLoadCompleteNotify) == null)
		{
			callBack6 = (DecoratorManager.<>O.<5>__EntityLoadCompleteNotify = new Action<Entity, EntityLoadCompleteNotify, CombatCommon>(CombatMessageController.EntityLoadCompleteNotify));
		}
		CombatNet.Listen<EntityLoadCompleteNotify>(callBack6, ENotifyMessageId.EntityLoadCompleteNotify, false, false);
		Action<Entity, PlayerRebackSceneNotify, CombatCommon> callBack7;
		if ((callBack7 = DecoratorManager.<>O.<6>__PlayerRebackSceneNotify) == null)
		{
			callBack7 = (DecoratorManager.<>O.<6>__PlayerRebackSceneNotify = new Action<Entity, PlayerRebackSceneNotify, CombatCommon>(CombatMessageController.PlayerRebackSceneNotify));
		}
		CombatNet.Listen<PlayerRebackSceneNotify>(callBack7, ENotifyMessageId.PlayerRebackSceneNotify, false, false);
		Action<Entity, MaterialNotify, CombatCommon> callBack8;
		if ((callBack8 = DecoratorManager.<>O.<7>__MaterialNotify) == null)
		{
			callBack8 = (DecoratorManager.<>O.<7>__MaterialNotify = new Action<Entity, MaterialNotify, CombatCommon>(CombatMessageController.MaterialNotify));
		}
		CombatNet.Listen<MaterialNotify>(callBack8, ENotifyMessageId.MaterialNotify, true, true);
		Action<Entity, EntityStaticHookMoveNotify, CombatCommon> callBack9;
		if ((callBack9 = DecoratorManager.<>O.<8>__OnHookMoveNotify) == null)
		{
			callBack9 = (DecoratorManager.<>O.<8>__OnHookMoveNotify = new Action<Entity, EntityStaticHookMoveNotify, CombatCommon>(RoleSceneInteractController.OnHookMoveNotify));
		}
		CombatNet.Listen<EntityStaticHookMoveNotify>(callBack9, ENotifyMessageId.EntityStaticHookMoveNotify, false, false);
		Action<Entity, UseSkillNotify, CombatCommon> callBack10;
		if ((callBack10 = DecoratorManager.<>O.<9>__UseSkillNotify) == null)
		{
			callBack10 = (DecoratorManager.<>O.<9>__UseSkillNotify = new Action<Entity, UseSkillNotify, CombatCommon>(SkillMessageController.UseSkillNotify));
		}
		CombatNet.Listen<UseSkillNotify>(callBack10, ENotifyMessageId.UseSkillNotify, true, true);
		Action<Entity, SkillNotify, CombatCommon> callBack11;
		if ((callBack11 = DecoratorManager.<>O.<10>__SkillNotify) == null)
		{
			callBack11 = (DecoratorManager.<>O.<10>__SkillNotify = new Action<Entity, SkillNotify, CombatCommon>(SkillMessageController.SkillNotify));
		}
		CombatNet.Listen<SkillNotify>(callBack11, ENotifyMessageId.SkillNotify, true, true);
		Action<Entity, EndSkillNotify, CombatCommon> callBack12;
		if ((callBack12 = DecoratorManager.<>O.<11>__EndSkillNotify) == null)
		{
			callBack12 = (DecoratorManager.<>O.<11>__EndSkillNotify = new Action<Entity, EndSkillNotify, CombatCommon>(SkillMessageController.EndSkillNotify));
		}
		CombatNet.Listen<EndSkillNotify>(callBack12, ENotifyMessageId.EndSkillNotify, true, true);
		Action<Entity, CreateBulletNotify, CombatCommon> callBack13;
		if ((callBack13 = DecoratorManager.<>O.<12>__CreateBulletNotify) == null)
		{
			callBack13 = (DecoratorManager.<>O.<12>__CreateBulletNotify = new Action<Entity, CreateBulletNotify, CombatCommon>(BulletController.CreateBulletNotify));
		}
		CombatNet.Listen<CreateBulletNotify>(callBack13, ENotifyMessageId.CreateBulletNotify, true, false);
		Action<Entity, DestroyBulletNotify, CombatCommon> callBack14;
		if ((callBack14 = DecoratorManager.<>O.<13>__DestroyBulletNotify) == null)
		{
			callBack14 = (DecoratorManager.<>O.<13>__DestroyBulletNotify = new Action<Entity, DestroyBulletNotify, CombatCommon>(BulletController.DestroyBulletNotify));
		}
		CombatNet.Listen<DestroyBulletNotify>(callBack14, ENotifyMessageId.DestroyBulletNotify, true, false);
		Action<Entity, ModifyBulletParamsNotify, CombatCommon> callBack15;
		if ((callBack15 = DecoratorManager.<>O.<14>__ModifyBulletParamsNotify) == null)
		{
			callBack15 = (DecoratorManager.<>O.<14>__ModifyBulletParamsNotify = new Action<Entity, ModifyBulletParamsNotify, CombatCommon>(BulletController.ModifyBulletParamsNotify));
		}
		CombatNet.Listen<ModifyBulletParamsNotify>(callBack15, ENotifyMessageId.ModifyBulletParamsNotify, true, false);
		Action<Entity, ApplyGameplayEffectNotify, CombatCommon> callBack16;
		if ((callBack16 = DecoratorManager.<>O.<15>__BroadcastAddBuffNotify) == null)
		{
			callBack16 = (DecoratorManager.<>O.<15>__BroadcastAddBuffNotify = new Action<Entity, ApplyGameplayEffectNotify, CombatCommon>(BaseBuffComponent.BroadcastAddBuffNotify));
		}
		CombatNet.Listen<ApplyGameplayEffectNotify>(callBack16, ENotifyMessageId.ApplyGameplayEffectNotify, false, false);
		Action<Entity, ApplyBuffFailedNotify, CombatCommon> callBack17;
		if ((callBack17 = DecoratorManager.<>O.<16>__BroadcastAddBuffFailedNotify) == null)
		{
			callBack17 = (DecoratorManager.<>O.<16>__BroadcastAddBuffFailedNotify = new Action<Entity, ApplyBuffFailedNotify, CombatCommon>(BaseBuffComponent.BroadcastAddBuffFailedNotify));
		}
		CombatNet.Listen<ApplyBuffFailedNotify>(callBack17, ENotifyMessageId.ApplyBuffFailedNotify, false, false);
		Action<Entity, BuffStackCountNotify, CombatCommon> callBack18;
		if ((callBack18 = DecoratorManager.<>O.<17>__BroadcastBuffStackChangedNotify) == null)
		{
			callBack18 = (DecoratorManager.<>O.<17>__BroadcastBuffStackChangedNotify = new Action<Entity, BuffStackCountNotify, CombatCommon>(BaseBuffComponent.BroadcastBuffStackChangedNotify));
		}
		CombatNet.Listen<BuffStackCountNotify>(callBack18, ENotifyMessageId.BuffStackCountNotify, false, false);
		Action<Entity, RemoveGameplayEffectNotify, CombatCommon> callBack19;
		if ((callBack19 = DecoratorManager.<>O.<18>__BroadcastRemoveBuffNotify) == null)
		{
			callBack19 = (DecoratorManager.<>O.<18>__BroadcastRemoveBuffNotify = new Action<Entity, RemoveGameplayEffectNotify, CombatCommon>(BaseBuffComponent.BroadcastRemoveBuffNotify));
		}
		CombatNet.Listen<RemoveGameplayEffectNotify>(callBack19, ENotifyMessageId.RemoveGameplayEffectNotify, false, false);
		Action<Entity, BuffDurationNotify, CombatCommon> callBack20;
		if ((callBack20 = DecoratorManager.<>O.<19>__BuffDurationNotify) == null)
		{
			callBack20 = (DecoratorManager.<>O.<19>__BuffDurationNotify = new Action<Entity, BuffDurationNotify, CombatCommon>(BaseBuffComponent.BuffDurationNotify));
		}
		CombatNet.Listen<BuffDurationNotify>(callBack20, ENotifyMessageId.BuffDurationNotify, false, false);
		Action<Entity, ApplyBuffS2cRequestNotify, CombatCommon> callBack21;
		if ((callBack21 = DecoratorManager.<>O.<20>__OrderAddBuffS2cNotify) == null)
		{
			callBack21 = (DecoratorManager.<>O.<20>__OrderAddBuffS2cNotify = new Action<Entity, ApplyBuffS2cRequestNotify, CombatCommon>(BaseBuffComponent.OrderAddBuffS2cNotify));
		}
		CombatNet.Listen<ApplyBuffS2cRequestNotify>(callBack21, ENotifyMessageId.ApplyBuffS2cRequestNotify, false, true);
		Action<Entity, RemoveBuffS2cRequestNotify, CombatCommon> callBack22;
		if ((callBack22 = DecoratorManager.<>O.<21>__OrderRemoveBuffS2cNotify) == null)
		{
			callBack22 = (DecoratorManager.<>O.<21>__OrderRemoveBuffS2cNotify = new Action<Entity, RemoveBuffS2cRequestNotify, CombatCommon>(BaseBuffComponent.OrderRemoveBuffS2cNotify));
		}
		CombatNet.Listen<RemoveBuffS2cRequestNotify>(callBack22, ENotifyMessageId.RemoveBuffS2cRequestNotify, false, false);
		Action<Entity, RemoveBuffByIdS2cRequestNotify, CombatCommon> callBack23;
		if ((callBack23 = DecoratorManager.<>O.<22>__OrderRemoveBuffByIdS2cNotify) == null)
		{
			callBack23 = (DecoratorManager.<>O.<22>__OrderRemoveBuffByIdS2cNotify = new Action<Entity, RemoveBuffByIdS2cRequestNotify, CombatCommon>(BaseBuffComponent.OrderRemoveBuffByIdS2cNotify));
		}
		CombatNet.Listen<RemoveBuffByIdS2cRequestNotify>(callBack23, ENotifyMessageId.RemoveBuffByIdS2cRequestNotify, false, false);
		Action<Entity, RemoveBuffByServerIdS2cRequestNotify, CombatCommon> callBack24;
		if ((callBack24 = DecoratorManager.<>O.<23>__OrderRemoveBuffByServerIdNotify) == null)
		{
			callBack24 = (DecoratorManager.<>O.<23>__OrderRemoveBuffByServerIdNotify = new Action<Entity, RemoveBuffByServerIdS2cRequestNotify, CombatCommon>(BaseBuffComponent.OrderRemoveBuffByServerIdNotify));
		}
		CombatNet.Listen<RemoveBuffByServerIdS2cRequestNotify>(callBack24, ENotifyMessageId.RemoveBuffByServerIdS2cRequestNotify, false, false);
		Action<Entity, OrderApplyBuffNotify, CombatCommon> callBack25;
		if ((callBack25 = DecoratorManager.<>O.<24>__OrderAddBuffNotify) == null)
		{
			callBack25 = (DecoratorManager.<>O.<24>__OrderAddBuffNotify = new Action<Entity, OrderApplyBuffNotify, CombatCommon>(BaseBuffComponent.OrderAddBuffNotify));
		}
		CombatNet.Listen<OrderApplyBuffNotify>(callBack25, ENotifyMessageId.OrderApplyBuffNotify, false, false);
		Action<Entity, OrderRemoveBuffNotify, CombatCommon> callBack26;
		if ((callBack26 = DecoratorManager.<>O.<25>__OrderRemoveBuffNotify) == null)
		{
			callBack26 = (DecoratorManager.<>O.<25>__OrderRemoveBuffNotify = new Action<Entity, OrderRemoveBuffNotify, CombatCommon>(BaseBuffComponent.OrderRemoveBuffNotify));
		}
		CombatNet.Listen<OrderRemoveBuffNotify>(callBack26, ENotifyMessageId.OrderRemoveBuffNotify, false, false);
		Action<Entity, OrderRemoveBuffByTagsNotify, CombatCommon> callBack27;
		if ((callBack27 = DecoratorManager.<>O.<26>__OrderRemoveBuffByTagsNotify) == null)
		{
			callBack27 = (DecoratorManager.<>O.<26>__OrderRemoveBuffByTagsNotify = new Action<Entity, OrderRemoveBuffByTagsNotify, CombatCommon>(BaseBuffComponent.OrderRemoveBuffByTagsNotify));
		}
		CombatNet.Listen<OrderRemoveBuffByTagsNotify>(callBack27, ENotifyMessageId.OrderRemoveBuffByTagsNotify, false, false);
		Action<Entity, ActivateBuffNotify, CombatCommon> callBack28;
		if ((callBack28 = DecoratorManager.<>O.<27>__BroadcastActivateBuffNotify) == null)
		{
			callBack28 = (DecoratorManager.<>O.<27>__BroadcastActivateBuffNotify = new Action<Entity, ActivateBuffNotify, CombatCommon>(BaseBuffComponent.BroadcastActivateBuffNotify));
		}
		CombatNet.Listen<ActivateBuffNotify>(callBack28, ENotifyMessageId.ActivateBuffNotify, false, false);
		Action<Entity, TransformBuffStackNotify, CombatCommon> callBack29;
		if ((callBack29 = DecoratorManager.<>O.<28>__BroadcastTransformBuffStackNotify) == null)
		{
			callBack29 = (DecoratorManager.<>O.<28>__BroadcastTransformBuffStackNotify = new Action<Entity, TransformBuffStackNotify, CombatCommon>(BaseBuffComponent.BroadcastTransformBuffStackNotify));
		}
		CombatNet.Listen<TransformBuffStackNotify>(callBack29, ENotifyMessageId.TransformBuffStackNotify, false, false);
		Action<Entity, DamageExecuteNotify, CombatCommon> callBack30;
		if ((callBack30 = DecoratorManager.<>O.<29>__OnDamageExecuteNotify) == null)
		{
			callBack30 = (DecoratorManager.<>O.<29>__OnDamageExecuteNotify = new Action<Entity, DamageExecuteNotify, CombatCommon>(BaseDamageComponent.OnDamageExecuteNotify));
		}
		CombatNet.Listen<DamageExecuteNotify>(callBack30, ENotifyMessageId.DamageExecuteNotify, false, false);
		Action<Entity, GameplayCueNotify, CombatCommon> callBack31;
		if ((callBack31 = DecoratorManager.<>O.<30>__GameplayCueNotify) == null)
		{
			callBack31 = (DecoratorManager.<>O.<30>__GameplayCueNotify = new Action<Entity, GameplayCueNotify, CombatCommon>(BaseGameplayCueComponent.GameplayCueNotify));
		}
		CombatNet.Listen<GameplayCueNotify>(callBack31, ENotifyMessageId.GameplayCueNotify, true, false);
		Action<Entity, AttributeChangedNotify, CombatCommon> callBack32;
		if ((callBack32 = DecoratorManager.<>O.<31>__AttributeChangedNotify) == null)
		{
			callBack32 = (DecoratorManager.<>O.<31>__AttributeChangedNotify = new Action<Entity, AttributeChangedNotify, CombatCommon>(CharacterAttributeComponent.AttributeChangedNotify));
		}
		CombatNet.Listen<AttributeChangedNotify>(callBack32, ENotifyMessageId.AttributeChangedNotify, true, false);
		Action<Entity, RecoverPropChangedNotify, CombatCommon> callBack33;
		if ((callBack33 = DecoratorManager.<>O.<32>__RecoverPropChangedNotify) == null)
		{
			callBack33 = (DecoratorManager.<>O.<32>__RecoverPropChangedNotify = new Action<Entity, RecoverPropChangedNotify, CombatCommon>(CharacterAttributeComponent.RecoverPropChangedNotify));
		}
		CombatNet.Listen<RecoverPropChangedNotify>(callBack33, ENotifyMessageId.RecoverPropChangedNotify, true, false);
		Action<Entity, DamageRecordNotify, CombatCommon> callBack34;
		if ((callBack34 = DecoratorManager.<>O.<33>__OnDamageRecordNotify) == null)
		{
			callBack34 = (DecoratorManager.<>O.<33>__OnDamageRecordNotify = new Action<Entity, DamageRecordNotify, CombatCommon>(CharacterGasDebugComponent.OnDamageRecordNotify));
		}
		CombatNet.Listen<DamageRecordNotify>(callBack34, ENotifyMessageId.DamageRecordNotify, true, false);
		Action<Entity, PassiveSkillAddNotify, CombatCommon> callBack35;
		if ((callBack35 = DecoratorManager.<>O.<34>__PassiveSkillAddNotify) == null)
		{
			callBack35 = (DecoratorManager.<>O.<34>__PassiveSkillAddNotify = new Action<Entity, PassiveSkillAddNotify, CombatCommon>(CharacterPassiveSkillComponent.PassiveSkillAddNotify));
		}
		CombatNet.Listen<PassiveSkillAddNotify>(callBack35, ENotifyMessageId.PassiveSkillAddNotify, false, false);
		Action<Entity, PassiveSkillRemoveNotify, CombatCommon> callBack36;
		if ((callBack36 = DecoratorManager.<>O.<35>__PassiveSkillRemoveNotify) == null)
		{
			callBack36 = (DecoratorManager.<>O.<35>__PassiveSkillRemoveNotify = new Action<Entity, PassiveSkillRemoveNotify, CombatCommon>(CharacterPassiveSkillComponent.PassiveSkillRemoveNotify));
		}
		CombatNet.Listen<PassiveSkillRemoveNotify>(callBack36, ENotifyMessageId.PassiveSkillRemoveNotify, false, false);
		Action<Entity, PlayerBattleStateChangeNotify, CombatCommon> callBack37;
		if ((callBack37 = DecoratorManager.<>O.<36>__OnPlayerBattleStateChangeNotify) == null)
		{
			callBack37 = (DecoratorManager.<>O.<36>__OnPlayerBattleStateChangeNotify = new Action<Entity, PlayerBattleStateChangeNotify, CombatCommon>(CharacterUnifiedStateComponent.OnPlayerBattleStateChangeNotify));
		}
		CombatNet.Listen<PlayerBattleStateChangeNotify>(callBack37, ENotifyMessageId.PlayerBattleStateChangeNotify, false, false);
		Action<Entity, HitNotify, CombatCommon> callBack38;
		if ((callBack38 = DecoratorManager.<>O.<37>__HitNotify) == null)
		{
			callBack38 = (DecoratorManager.<>O.<37>__HitNotify = new Action<Entity, HitNotify, CombatCommon>(BaseHitComponent.HitNotify));
		}
		CombatNet.Listen<HitNotify>(callBack38, ENotifyMessageId.HitNotify, true, false);
		Action<Entity, AiHateNotify, CombatCommon> callBack39;
		if ((callBack39 = DecoratorManager.<>O.<38>__AiHateNotify) == null)
		{
			callBack39 = (DecoratorManager.<>O.<38>__AiHateNotify = new Action<Entity, AiHateNotify, CombatCommon>(CharacterAiComponent.AiHateNotify));
		}
		CombatNet.Listen<AiHateNotify>(callBack39, ENotifyMessageId.AiHateNotify, true, false);
		Action<Entity, BoneVisibleChangeNotify, CombatCommon> callBack40;
		if ((callBack40 = DecoratorManager.<>O.<39>__BoneVisibleChangeNotify) == null)
		{
			callBack40 = (DecoratorManager.<>O.<39>__BoneVisibleChangeNotify = new Action<Entity, BoneVisibleChangeNotify, CombatCommon>(CharacterAnimationComponent.BoneVisibleChangeNotify));
		}
		CombatNet.Listen<BoneVisibleChangeNotify>(callBack40, ENotifyMessageId.BoneVisibleChangeNotify, true, false);
		Action<Entity, AnimationGameplayTagNotify, CombatCommon> callBack41;
		if ((callBack41 = DecoratorManager.<>O.<40>__AnimationGameplayTagNotify) == null)
		{
			callBack41 = (DecoratorManager.<>O.<40>__AnimationGameplayTagNotify = new Action<Entity, AnimationGameplayTagNotify, CombatCommon>(CharacterAnimationSyncComponent.AnimationGameplayTagNotify));
		}
		CombatNet.Listen<AnimationGameplayTagNotify>(callBack41, ENotifyMessageId.AnimationGameplayTagNotify, true, false);
		Action<Entity, AnimationStateChangedNotify, CombatCommon> callBack42;
		if ((callBack42 = DecoratorManager.<>O.<41>__AnimationStateChangedNotify) == null)
		{
			callBack42 = (DecoratorManager.<>O.<41>__AnimationStateChangedNotify = new Action<Entity, AnimationStateChangedNotify, CombatCommon>(CharacterAnimationSyncComponent.AnimationStateChangedNotify));
		}
		CombatNet.Listen<AnimationStateChangedNotify>(callBack42, ENotifyMessageId.AnimationStateChangedNotify, true, false);
		Action<Entity, PackAnimChangedNotify, CombatCommon> callBack43;
		if ((callBack43 = DecoratorManager.<>O.<42>__PackAnimChangedNotify) == null)
		{
			callBack43 = (DecoratorManager.<>O.<42>__PackAnimChangedNotify = new Action<Entity, PackAnimChangedNotify, CombatCommon>(CharacterAnimationSyncComponent.PackAnimChangedNotify));
		}
		CombatNet.Listen<PackAnimChangedNotify>(callBack43, ENotifyMessageId.PackAnimChangedNotify, false, false);
		Action<Entity, AnimationStateInitNotify, CombatCommon> callBack44;
		if ((callBack44 = DecoratorManager.<>O.<43>__AnimationStateInitNotify) == null)
		{
			callBack44 = (DecoratorManager.<>O.<43>__AnimationStateInitNotify = new Action<Entity, AnimationStateInitNotify, CombatCommon>(CharacterAnimationSyncComponent.AnimationStateInitNotify));
		}
		CombatNet.Listen<AnimationStateInitNotify>(callBack44, ENotifyMessageId.AnimationStateInitNotify, false, false);
		Action<Entity, AddCombineEntitiesRelationNotify, CombatCommon> callBack45;
		if ((callBack45 = DecoratorManager.<>O.<44>__AddCombineEntitiesRelationNotify) == null)
		{
			callBack45 = (DecoratorManager.<>O.<44>__AddCombineEntitiesRelationNotify = new Action<Entity, AddCombineEntitiesRelationNotify, CombatCommon>(CharacterAttachComponent.AddCombineEntitiesRelationNotify));
		}
		CombatNet.Listen<AddCombineEntitiesRelationNotify>(callBack45, ENotifyMessageId.AddCombineEntitiesRelationNotify, true, false);
		Action<Entity, RemoveCombineRelationNotify, CombatCommon> callBack46;
		if ((callBack46 = DecoratorManager.<>O.<45>__RemoveCombineRelationNotify) == null)
		{
			callBack46 = (DecoratorManager.<>O.<45>__RemoveCombineRelationNotify = new Action<Entity, RemoveCombineRelationNotify, CombatCommon>(CharacterAttachComponent.RemoveCombineRelationNotify));
		}
		CombatNet.Listen<RemoveCombineRelationNotify>(callBack46, ENotifyMessageId.RemoveCombineRelationNotify, true, false);
		Action<Entity, CaughtNotify, CombatCommon> callBack47;
		if ((callBack47 = DecoratorManager.<>O.<46>__CaughtNotify) == null)
		{
			callBack47 = (DecoratorManager.<>O.<46>__CaughtNotify = new Action<Entity, CaughtNotify, CombatCommon>(CharacterCaughtNewComponent.CaughtNotify));
		}
		CombatNet.Listen<CaughtNotify>(callBack47, ENotifyMessageId.CaughtNotify, true, false);
		Action<Entity, LogicStateInitNotify, CombatCommon> callBack48;
		if ((callBack48 = DecoratorManager.<>O.<47>__LogicStateInitNotify) == null)
		{
			callBack48 = (DecoratorManager.<>O.<47>__LogicStateInitNotify = new Action<Entity, LogicStateInitNotify, CombatCommon>(CharacterLogicStateSyncComponent.LogicStateInitNotify));
		}
		CombatNet.Listen<LogicStateInitNotify>(callBack48, ENotifyMessageId.LogicStateInitNotify, true, false);
		Action<Entity, SwitchLogicStateNotify, CombatCommon> callBack49;
		if ((callBack49 = DecoratorManager.<>O.<48>__SwitchLogicStateNotify) == null)
		{
			callBack49 = (DecoratorManager.<>O.<48>__SwitchLogicStateNotify = new Action<Entity, SwitchLogicStateNotify, CombatCommon>(CharacterLogicStateSyncComponent.SwitchLogicStateNotify));
		}
		CombatNet.Listen<SwitchLogicStateNotify>(callBack49, ENotifyMessageId.SwitchLogicStateNotify, true, false);
		Action<Entity, PartUpdateNotify, CombatCommon> callBack50;
		if ((callBack50 = DecoratorManager.<>O.<49>__PartUpdateNotify) == null)
		{
			callBack50 = (DecoratorManager.<>O.<49>__PartUpdateNotify = new Action<Entity, PartUpdateNotify, CombatCommon>(CharacterPartComponent.PartUpdateNotify));
		}
		CombatNet.Listen<PartUpdateNotify>(callBack50, ENotifyMessageId.PartUpdateNotify, false, false);
		Action<Entity, PartComponentInitNotify, CombatCommon> callBack51;
		if ((callBack51 = DecoratorManager.<>O.<50>__PartComponentInitNotify) == null)
		{
			callBack51 = (DecoratorManager.<>O.<50>__PartComponentInitNotify = new Action<Entity, PartComponentInitNotify, CombatCommon>(CharacterPartComponent.PartComponentInitNotify));
		}
		CombatNet.Listen<PartComponentInitNotify>(callBack51, ENotifyMessageId.PartComponentInitNotify, false, false);
		Action<Entity, ShieldUpdateNotify, CombatCommon> callBack52;
		if ((callBack52 = DecoratorManager.<>O.<51>__OnShieldUpdateNotify) == null)
		{
			callBack52 = (DecoratorManager.<>O.<51>__OnShieldUpdateNotify = new Action<Entity, ShieldUpdateNotify, CombatCommon>(CharacterShieldComponent.OnShieldUpdateNotify));
		}
		CombatNet.Listen<ShieldUpdateNotify>(callBack52, ENotifyMessageId.ShieldUpdateNotify, false, false);
		Action<Entity, ChangeStateNotify, CombatCommon> callBack53;
		if ((callBack53 = DecoratorManager.<>O.<52>__ChangeStateNotify) == null)
		{
			callBack53 = (DecoratorManager.<>O.<52>__ChangeStateNotify = new Action<Entity, ChangeStateNotify, CombatCommon>(CharacterStateMachineNewComponent.ChangeStateNotify));
		}
		CombatNet.Listen<ChangeStateNotify>(callBack53, ENotifyMessageId.ChangeStateNotify, true, false);
		Action<Entity, ChangeStateConfirmNotify, CombatCommon> callBack54;
		if ((callBack54 = DecoratorManager.<>O.<53>__ChangeStateConfirmNotify) == null)
		{
			callBack54 = (DecoratorManager.<>O.<53>__ChangeStateConfirmNotify = new Action<Entity, ChangeStateConfirmNotify, CombatCommon>(CharacterStateMachineNewComponent.ChangeStateConfirmNotify));
		}
		CombatNet.Listen<ChangeStateConfirmNotify>(callBack54, ENotifyMessageId.ChangeStateConfirmNotify, true, false);
		Action<Entity, FsmResetNotify, CombatCommon> callBack55;
		if ((callBack55 = DecoratorManager.<>O.<54>__FsmResetNotify) == null)
		{
			callBack55 = (DecoratorManager.<>O.<54>__FsmResetNotify = new Action<Entity, FsmResetNotify, CombatCommon>(CharacterStateMachineNewComponent.FsmResetNotify));
		}
		CombatNet.Listen<FsmResetNotify>(callBack55, ENotifyMessageId.FsmResetNotify, true, false);
		Action<Entity, FsmBlackboardNotify, CombatCommon> callBack56;
		if ((callBack56 = DecoratorManager.<>O.<55>__FsmBlackboardNotify) == null)
		{
			callBack56 = (DecoratorManager.<>O.<55>__FsmBlackboardNotify = new Action<Entity, FsmBlackboardNotify, CombatCommon>(CharacterStateMachineNewComponent.FsmBlackboardNotify));
		}
		CombatNet.Listen<FsmBlackboardNotify>(callBack56, ENotifyMessageId.FsmBlackboardNotify, true, false);
		Action<Entity, FsmCustomBlackboardNotify, CombatCommon> callBack57;
		if ((callBack57 = DecoratorManager.<>O.<56>__FsmCustomBlackboardNotify) == null)
		{
			callBack57 = (DecoratorManager.<>O.<56>__FsmCustomBlackboardNotify = new Action<Entity, FsmCustomBlackboardNotify, CombatCommon>(CharacterStateMachineNewComponent.FsmCustomBlackboardNotify));
		}
		CombatNet.Listen<FsmCustomBlackboardNotify>(callBack57, ENotifyMessageId.FsmCustomBlackboardNotify, true, false);
		Action<Entity, FsmMontageDurationNotify, CombatCommon> callBack58;
		if ((callBack58 = DecoratorManager.<>O.<57>__FsmMontageDurationNotify) == null)
		{
			callBack58 = (DecoratorManager.<>O.<57>__FsmMontageDurationNotify = new Action<Entity, FsmMontageDurationNotify, CombatCommon>(CharacterStateMachineNewComponent.FsmMontageDurationNotify));
		}
		CombatNet.Listen<FsmMontageDurationNotify>(callBack58, ENotifyMessageId.FsmMontageDurationNotify, true, false);
		Action<Entity, VisionTriggerNotify, CombatCommon> callBack59;
		if ((callBack59 = DecoratorManager.<>O.<58>__VisionTriggerNotify) == null)
		{
			callBack59 = (DecoratorManager.<>O.<58>__VisionTriggerNotify = new Action<Entity, VisionTriggerNotify, CombatCommon>(CharacterVisionComponent.VisionTriggerNotify));
		}
		CombatNet.Listen<VisionTriggerNotify>(callBack59, ENotifyMessageId.VisionTriggerNotify, true, false);
		Action<Entity, DrownNotify, CombatCommon> callBack60;
		if ((callBack60 = DecoratorManager.<>O.<59>__DrownNotify) == null)
		{
			callBack60 = (DecoratorManager.<>O.<59>__DrownNotify = new Action<Entity, DrownNotify, CombatCommon>(RoleDeathComponent.DrownNotify));
		}
		CombatNet.Listen<DrownNotify>(callBack60, ENotifyMessageId.DrownNotify, true, false);
		Action<Entity, ExecuteQteNotify, CombatCommon> callBack61;
		if ((callBack61 = DecoratorManager.<>O.<60>__ExecuteQteNotify) == null)
		{
			callBack61 = (DecoratorManager.<>O.<60>__ExecuteQteNotify = new Action<Entity, ExecuteQteNotify, CombatCommon>(RoleQteComponent.ExecuteQteNotify));
		}
		CombatNet.Listen<ExecuteQteNotify>(callBack61, ENotifyMessageId.ExecuteQteNotify, true, false);
		Action<Entity, MotorSummonAndRideNotify, CombatCommon> callBack62;
		if ((callBack62 = DecoratorManager.<>O.<61>__MotorSummonAndRideNotify) == null)
		{
			callBack62 = (DecoratorManager.<>O.<61>__MotorSummonAndRideNotify = new Action<Entity, MotorSummonAndRideNotify, CombatCommon>(VehicleController.MotorSummonAndRideNotify));
		}
		CombatNet.Listen<MotorSummonAndRideNotify>(callBack62, ENotifyMessageId.MotorSummonAndRideNotify, true, false);
		Action<Entity, EntityLivingStatusNotify, CombatCommon> callBack63;
		if ((callBack63 = DecoratorManager.<>O.<62>__ExecuteEntityLivingStatus) == null)
		{
			callBack63 = (DecoratorManager.<>O.<62>__ExecuteEntityLivingStatus = new Action<Entity, EntityLivingStatusNotify, CombatCommon>(BattleLogicController.ExecuteEntityLivingStatus));
		}
		CombatNet.Listen<EntityLivingStatusNotify>(callBack63, ENotifyMessageId.EntityLivingStatusNotify, true, false);
		Action<Entity, ModifyEntityCampNotify, CombatCommon> callBack64;
		if ((callBack64 = DecoratorManager.<>O.<63>__OnModifyEntityCampNotify) == null)
		{
			callBack64 = (DecoratorManager.<>O.<63>__OnModifyEntityCampNotify = new Action<Entity, ModifyEntityCampNotify, CombatCommon>(CreatureController.OnModifyEntityCampNotify));
		}
		CombatNet.Listen<ModifyEntityCampNotify>(callBack64, ENotifyMessageId.ModifyEntityCampNotify, false, false);
		Func<Entity, UseSkillNotify, CombatCommon, bool> callBack65;
		if ((callBack65 = DecoratorManager.<>O.<64>__PreUseSkillNotify) == null)
		{
			callBack65 = (DecoratorManager.<>O.<64>__PreUseSkillNotify = new Func<Entity, UseSkillNotify, CombatCommon, bool>(SkillMessageController.PreUseSkillNotify));
		}
		CombatNet.Preprocess<UseSkillNotify>(callBack65, ENotifyMessageId.UseSkillNotify);
		Func<Entity, HitNotify, CombatCommon, bool> callBack66;
		if ((callBack66 = DecoratorManager.<>O.<65>__PreHitNotify) == null)
		{
			callBack66 = (DecoratorManager.<>O.<65>__PreHitNotify = new Func<Entity, HitNotify, CombatCommon, bool>(BaseHitComponent.PreHitNotify));
		}
		CombatNet.Preprocess<HitNotify>(callBack66, ENotifyMessageId.HitNotify);
		return true;
	}

	// Token: 0x020096A6 RID: 38566
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031B33 RID: 203571
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AiInformationNotify, CombatCommon> <0>__AiInformationNotify;

		// Token: 0x04031B34 RID: 203572
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AiBlackboardCdNotify, CombatCommon> <1>__AiInformationS;

		// Token: 0x04031B35 RID: 203573
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, NewLinkNotify, CombatCommon> <2>__OnNewLinkStateNotify;

		// Token: 0x04031B36 RID: 203574
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, EntityIsVisibleNotify, CombatCommon> <3>__EntityIsVisibleNotify;

		// Token: 0x04031B37 RID: 203575
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ActorVisibleNotify, CombatCommon> <4>__ActorIsVisibleNotify;

		// Token: 0x04031B38 RID: 203576
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, EntityLoadCompleteNotify, CombatCommon> <5>__EntityLoadCompleteNotify;

		// Token: 0x04031B39 RID: 203577
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PlayerRebackSceneNotify, CombatCommon> <6>__PlayerRebackSceneNotify;

		// Token: 0x04031B3A RID: 203578
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, MaterialNotify, CombatCommon> <7>__MaterialNotify;

		// Token: 0x04031B3B RID: 203579
		[Nullable(new byte[]
		{
			0,
			2,
			2,
			2
		})]
		public static Action<Entity, EntityStaticHookMoveNotify, CombatCommon> <8>__OnHookMoveNotify;

		// Token: 0x04031B3C RID: 203580
		[Nullable(new byte[]
		{
			0,
			2,
			2,
			2
		})]
		public static Action<Entity, UseSkillNotify, CombatCommon> <9>__UseSkillNotify;

		// Token: 0x04031B3D RID: 203581
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, SkillNotify, CombatCommon> <10>__SkillNotify;

		// Token: 0x04031B3E RID: 203582
		[Nullable(new byte[]
		{
			0,
			2,
			2,
			2
		})]
		public static Action<Entity, EndSkillNotify, CombatCommon> <11>__EndSkillNotify;

		// Token: 0x04031B3F RID: 203583
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, CreateBulletNotify, CombatCommon> <12>__CreateBulletNotify;

		// Token: 0x04031B40 RID: 203584
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, DestroyBulletNotify, CombatCommon> <13>__DestroyBulletNotify;

		// Token: 0x04031B41 RID: 203585
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ModifyBulletParamsNotify, CombatCommon> <14>__ModifyBulletParamsNotify;

		// Token: 0x04031B42 RID: 203586
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ApplyGameplayEffectNotify, CombatCommon> <15>__BroadcastAddBuffNotify;

		// Token: 0x04031B43 RID: 203587
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ApplyBuffFailedNotify, CombatCommon> <16>__BroadcastAddBuffFailedNotify;

		// Token: 0x04031B44 RID: 203588
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, BuffStackCountNotify, CombatCommon> <17>__BroadcastBuffStackChangedNotify;

		// Token: 0x04031B45 RID: 203589
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, RemoveGameplayEffectNotify, CombatCommon> <18>__BroadcastRemoveBuffNotify;

		// Token: 0x04031B46 RID: 203590
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, BuffDurationNotify, CombatCommon> <19>__BuffDurationNotify;

		// Token: 0x04031B47 RID: 203591
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ApplyBuffS2cRequestNotify, CombatCommon> <20>__OrderAddBuffS2cNotify;

		// Token: 0x04031B48 RID: 203592
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, RemoveBuffS2cRequestNotify, CombatCommon> <21>__OrderRemoveBuffS2cNotify;

		// Token: 0x04031B49 RID: 203593
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, RemoveBuffByIdS2cRequestNotify, CombatCommon> <22>__OrderRemoveBuffByIdS2cNotify;

		// Token: 0x04031B4A RID: 203594
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, RemoveBuffByServerIdS2cRequestNotify, CombatCommon> <23>__OrderRemoveBuffByServerIdNotify;

		// Token: 0x04031B4B RID: 203595
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, OrderApplyBuffNotify, CombatCommon> <24>__OrderAddBuffNotify;

		// Token: 0x04031B4C RID: 203596
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, OrderRemoveBuffNotify, CombatCommon> <25>__OrderRemoveBuffNotify;

		// Token: 0x04031B4D RID: 203597
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, OrderRemoveBuffByTagsNotify, CombatCommon> <26>__OrderRemoveBuffByTagsNotify;

		// Token: 0x04031B4E RID: 203598
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ActivateBuffNotify, CombatCommon> <27>__BroadcastActivateBuffNotify;

		// Token: 0x04031B4F RID: 203599
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, TransformBuffStackNotify, CombatCommon> <28>__BroadcastTransformBuffStackNotify;

		// Token: 0x04031B50 RID: 203600
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, DamageExecuteNotify, CombatCommon> <29>__OnDamageExecuteNotify;

		// Token: 0x04031B51 RID: 203601
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, GameplayCueNotify, CombatCommon> <30>__GameplayCueNotify;

		// Token: 0x04031B52 RID: 203602
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AttributeChangedNotify, CombatCommon> <31>__AttributeChangedNotify;

		// Token: 0x04031B53 RID: 203603
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, RecoverPropChangedNotify, CombatCommon> <32>__RecoverPropChangedNotify;

		// Token: 0x04031B54 RID: 203604
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, DamageRecordNotify, CombatCommon> <33>__OnDamageRecordNotify;

		// Token: 0x04031B55 RID: 203605
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PassiveSkillAddNotify, CombatCommon> <34>__PassiveSkillAddNotify;

		// Token: 0x04031B56 RID: 203606
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PassiveSkillRemoveNotify, CombatCommon> <35>__PassiveSkillRemoveNotify;

		// Token: 0x04031B57 RID: 203607
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PlayerBattleStateChangeNotify, CombatCommon> <36>__OnPlayerBattleStateChangeNotify;

		// Token: 0x04031B58 RID: 203608
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, HitNotify, CombatCommon> <37>__HitNotify;

		// Token: 0x04031B59 RID: 203609
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AiHateNotify, CombatCommon> <38>__AiHateNotify;

		// Token: 0x04031B5A RID: 203610
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, BoneVisibleChangeNotify, CombatCommon> <39>__BoneVisibleChangeNotify;

		// Token: 0x04031B5B RID: 203611
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AnimationGameplayTagNotify, CombatCommon> <40>__AnimationGameplayTagNotify;

		// Token: 0x04031B5C RID: 203612
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AnimationStateChangedNotify, CombatCommon> <41>__AnimationStateChangedNotify;

		// Token: 0x04031B5D RID: 203613
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PackAnimChangedNotify, CombatCommon> <42>__PackAnimChangedNotify;

		// Token: 0x04031B5E RID: 203614
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AnimationStateInitNotify, CombatCommon> <43>__AnimationStateInitNotify;

		// Token: 0x04031B5F RID: 203615
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, AddCombineEntitiesRelationNotify, CombatCommon> <44>__AddCombineEntitiesRelationNotify;

		// Token: 0x04031B60 RID: 203616
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, RemoveCombineRelationNotify, CombatCommon> <45>__RemoveCombineRelationNotify;

		// Token: 0x04031B61 RID: 203617
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, CaughtNotify, CombatCommon> <46>__CaughtNotify;

		// Token: 0x04031B62 RID: 203618
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, LogicStateInitNotify, CombatCommon> <47>__LogicStateInitNotify;

		// Token: 0x04031B63 RID: 203619
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, SwitchLogicStateNotify, CombatCommon> <48>__SwitchLogicStateNotify;

		// Token: 0x04031B64 RID: 203620
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PartUpdateNotify, CombatCommon> <49>__PartUpdateNotify;

		// Token: 0x04031B65 RID: 203621
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, PartComponentInitNotify, CombatCommon> <50>__PartComponentInitNotify;

		// Token: 0x04031B66 RID: 203622
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ShieldUpdateNotify, CombatCommon> <51>__OnShieldUpdateNotify;

		// Token: 0x04031B67 RID: 203623
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ChangeStateNotify, CombatCommon> <52>__ChangeStateNotify;

		// Token: 0x04031B68 RID: 203624
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ChangeStateConfirmNotify, CombatCommon> <53>__ChangeStateConfirmNotify;

		// Token: 0x04031B69 RID: 203625
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, FsmResetNotify, CombatCommon> <54>__FsmResetNotify;

		// Token: 0x04031B6A RID: 203626
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, FsmBlackboardNotify, CombatCommon> <55>__FsmBlackboardNotify;

		// Token: 0x04031B6B RID: 203627
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, FsmCustomBlackboardNotify, CombatCommon> <56>__FsmCustomBlackboardNotify;

		// Token: 0x04031B6C RID: 203628
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, FsmMontageDurationNotify, CombatCommon> <57>__FsmMontageDurationNotify;

		// Token: 0x04031B6D RID: 203629
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, VisionTriggerNotify, CombatCommon> <58>__VisionTriggerNotify;

		// Token: 0x04031B6E RID: 203630
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, DrownNotify, CombatCommon> <59>__DrownNotify;

		// Token: 0x04031B6F RID: 203631
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ExecuteQteNotify, CombatCommon> <60>__ExecuteQteNotify;

		// Token: 0x04031B70 RID: 203632
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, MotorSummonAndRideNotify, CombatCommon> <61>__MotorSummonAndRideNotify;

		// Token: 0x04031B71 RID: 203633
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, EntityLivingStatusNotify, CombatCommon> <62>__ExecuteEntityLivingStatus;

		// Token: 0x04031B72 RID: 203634
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Action<Entity, ModifyEntityCampNotify, CombatCommon> <63>__OnModifyEntityCampNotify;

		// Token: 0x04031B73 RID: 203635
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Func<Entity, UseSkillNotify, CombatCommon, bool> <64>__PreUseSkillNotify;

		// Token: 0x04031B74 RID: 203636
		[Nullable(new byte[]
		{
			0,
			2,
			1,
			2
		})]
		public static Func<Entity, HitNotify, CombatCommon, bool> <65>__PreHitNotify;
	}
}
