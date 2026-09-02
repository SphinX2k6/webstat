using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002E21 RID: 11809
[NullableContext(1)]
[Nullable(0)]
public class AnimalPerformSystemUiState : AnimalPerformStateBase
{
	// Token: 0x06017E32 RID: 97842 RVA: 0x006B1351 File Offset: 0x006AF551
	public AnimalPerformSystemUiState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x1700205C RID: 8284
	// (get) Token: 0x06017E33 RID: 97843 RVA: 0x006B1367 File Offset: 0x006AF567
	// (set) Token: 0x06017E34 RID: 97844 RVA: 0x006B136F File Offset: 0x006AF56F
	public EUiViewName? SystemUiViewName
	{
		get
		{
			return this.UiViewName;
		}
		set
		{
			this.UiViewName = value;
		}
	}

	// Token: 0x06017E35 RID: 97845 RVA: 0x006B1378 File Offset: 0x006AF578
	protected override void OnEnter(EAnimalPerformState? lastState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		if (this.UiViewName == null)
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(this.UiViewName.Value))
		{
			this.OnOpenView(this.UiViewName.Value, 0);
		}
		else
		{
			this.IsViewOpening = false;
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		}
		EAnimalPerformState? eanimalPerformState = lastState;
		EAnimalPerformState eanimalPerformState2 = EAnimalPerformState.Born;
		if (eanimalPerformState.GetValueOrDefault() == eanimalPerformState2 & eanimalPerformState != null)
		{
			base.AnimalEcologicalInterface.StateMachineInitializationComplete();
		}
		BaseTagComponent component = this.Owner.GetComponent<BaseTagComponent>();
		if (component != null)
		{
			this.ProcessGameplayTag(component);
		}
		this.EcologicalInterface.SystemUiStart();
	}

	// Token: 0x06017E36 RID: 97846 RVA: 0x006B142C File Offset: 0x006AF62C
	protected override void OnExit(EAnimalPerformState nextState)
	{
		if (this.EcologicalInterface == null)
		{
			return;
		}
		PawnInteractNewComponent component = this.Owner.GetComponent<PawnInteractNewComponent>();
		if (component != null)
		{
			component.SetInteractionState(true, "AnimalPerformSystemUiState OnExit");
		}
		this.EcologicalInterface.SystemUiEnd();
		BaseTagComponent component2 = this.Owner.GetComponent<BaseTagComponent>();
		if (component2 != null)
		{
			component2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.系统UI"]));
		}
		this.IsViewOpening = false;
		this.UiViewName = null;
	}

	// Token: 0x06017E37 RID: 97847 RVA: 0x006B14A8 File Offset: 0x006AF6A8
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (this.UiViewName == null || this.UiViewName != viewName)
		{
			return;
		}
		if (!this.IsViewOpening)
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		}
		this.IsViewOpening = true;
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnDeliveryProps, new Action<int>(this.OnDeliveryProps));
	}

	// Token: 0x06017E38 RID: 97848 RVA: 0x006B1544 File Offset: 0x006AF744
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (this.UiViewName == null)
		{
			return;
		}
		if (this.UiViewName != viewName)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnDeliveryProps, new Action<int>(this.OnDeliveryProps));
		this.StateMachine.Switch(EAnimalPerformState.Stand);
	}

	// Token: 0x06017E39 RID: 97849 RVA: 0x006B15C8 File Offset: 0x006AF7C8
	public void InitFeedingAnimalConfig(int[] itemIds, string[] gameplayTags)
	{
		if (itemIds == null || gameplayTags == null)
		{
			return;
		}
		int num = itemIds.Length;
		for (int i = 0; i < num; i++)
		{
			int key = itemIds[i];
			string value = gameplayTags[i];
			if (!string.IsNullOrEmpty(value))
			{
				this.DeliveryPropsConfig[key] = value;
			}
		}
	}

	// Token: 0x06017E3A RID: 97850 RVA: 0x006B160C File Offset: 0x006AF80C
	private void OnDeliveryProps(int itemId)
	{
		if (itemId == 0)
		{
			return;
		}
		string tagName;
		if (this.DeliveryPropsConfig.TryGetValue(itemId, out tagName))
		{
			FGameplayTag? gameplayTagByName = GameplayTagUtils.GetGameplayTagByName(tagName);
			this.EcologicalInterface.FeedStart(gameplayTagByName.Value);
		}
	}

	// Token: 0x06017E3B RID: 97851 RVA: 0x006B1648 File Offset: 0x006AF848
	private void ProcessGameplayTag(BaseTagComponent gameplayTagComponent)
	{
		if (gameplayTagComponent == null || !gameplayTagComponent.Valid)
		{
			return;
		}
		if (gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.随机表演"]))
		{
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.随机表演"]));
			gameplayTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.站起"]));
		}
		if (gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.坐下"]))
		{
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.坐下"]));
			gameplayTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.站起"]));
		}
		if (gameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下"]))
		{
			gameplayTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下"]));
			gameplayTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.趴下起身"]));
		}
		gameplayTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.系统UI"]));
	}

	// Token: 0x0400B968 RID: 47464
	private readonly Dictionary<int, string> DeliveryPropsConfig = new Dictionary<int, string>();

	// Token: 0x0400B969 RID: 47465
	private bool IsViewOpening;

	// Token: 0x0400B96A RID: 47466
	private EUiViewName? UiViewName;
}
