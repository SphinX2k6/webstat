using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002C88 RID: 11400
[NullableContext(2)]
[Nullable(0)]
public class UiModelLoadingIconComponent : UiModelComponentBase
{
	// Token: 0x06016DF8 RID: 93688 RVA: 0x00658DBC File Offset: 0x00656FBC
	protected override void OnInit()
	{
		this.LoadingItem = new RoleModelLoadingItem();
		this.LoadingItem.CreateByResourceIdAsync("UiItem_Loading_Prefab", Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pop), false).Forget();
		this.UiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.UiModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016DF9 RID: 93689 RVA: 0x00658E18 File Offset: 0x00657018
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.BeforeModelLoadStart));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016DFA RID: 93690 RVA: 0x00658E69 File Offset: 0x00657069
	protected override void OnTick(float deltaTime)
	{
		this.FollowRootPosition();
	}

	// Token: 0x06016DFB RID: 93691 RVA: 0x00658E74 File Offset: 0x00657074
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.BeforeModelLoadStart));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
		this.LoadingItem.Destroy(null);
	}

	// Token: 0x06016DFC RID: 93692 RVA: 0x00658ED1 File Offset: 0x006570D1
	private void BeforeModelLoadStart()
	{
		this.NeedTick = true;
		this.FollowRootPosition();
		this.LoadingItem.SetLoadingActive(true);
	}

	// Token: 0x06016DFD RID: 93693 RVA: 0x00658EEC File Offset: 0x006570EC
	private void OnModelLoadComplete()
	{
		this.NeedTick = false;
		this.LoadingItem.SetLoadingActive(false);
	}

	// Token: 0x06016DFE RID: 93694 RVA: 0x00658F01 File Offset: 0x00657101
	public void SetLoadingOpen(bool isOpen)
	{
		this.LoadingItem.SetLoadingOpen(isOpen);
	}

	// Token: 0x06016DFF RID: 93695 RVA: 0x00658F0F File Offset: 0x0065710F
	public void SetLoadingActive(bool state)
	{
		this.LoadingItem.SetLoadingActive(state);
	}

	// Token: 0x06016E00 RID: 93696 RVA: 0x00658F20 File Offset: 0x00657120
	private void FollowRootPosition()
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (((uiModelDataComponent != null) ? new bool?(uiModelDataComponent.GetLoadingIconFollowState()) : null).GetValueOrDefault() && this.UiModelActorComponent != null)
		{
			FVector2D actorLguiPos = Singleton<UiModelUtil>.Instance.GetActorLguiPos(this.UiModelActorComponent.GetActor(), null);
			this.LoadingItem.SetIconPosition(actorLguiPos);
		}
	}

	// Token: 0x0400B07D RID: 45181
	protected UiModelActorComponent UiModelActorComponent;

	// Token: 0x0400B07E RID: 45182
	protected UiModelDataComponent UiModelDataComponent;

	// Token: 0x0400B07F RID: 45183
	protected RoleModelLoadingItem LoadingItem;
}
