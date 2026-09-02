using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

// Token: 0x020031D5 RID: 12757
[NullableContext(1)]
[Nullable(0)]
public class NpcPerformInteractState : NpcPerformBaseState
{
	// Token: 0x0601A71C RID: 108316 RVA: 0x007CD7DB File Offset: 0x007CB9DB
	public NpcPerformInteractState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x0601A71D RID: 108317 RVA: 0x007CD7FC File Offset: 0x007CB9FC
	public override bool CanChangeFrom(ENpcPerformState fromState)
	{
		CommonNpcPerformComponent component = this.Owner.Entity.GetComponent<CommonNpcPerformComponent>();
		return this.HaveInteractConfig && fromState == ENpcPerformState.Idle && !component.IsInPlot;
	}

	// Token: 0x0601A71E RID: 108318 RVA: 0x007CD834 File Offset: 0x007CBA34
	[NullableContext(2)]
	protected override void OnCreate(IEntityArgs args = null)
	{
		base.OnCreate(args);
		Aki.TDConfigMgr.Component.NpcPerformComponent p = args.GetP1<Aki.TDConfigMgr.Component.NpcPerformComponent>();
		string value;
		if (p == null)
		{
			value = null;
		}
		else
		{
			INpcPerformOnInteract showOnInteract = p.ShowOnInteract;
			value = ((showOnInteract != null) ? showOnInteract.Montage : null);
		}
		if (string.IsNullOrEmpty(value) && ((p != null) ? p.ConditionalShowOnInteracts : null) == null)
		{
			this.HaveInteractConfig = false;
			return;
		}
		this.HaveInteractConfig = true;
		string value2;
		if (p == null)
		{
			value2 = null;
		}
		else
		{
			INpcPerformOnInteract showOnInteract2 = p.ShowOnInteract;
			value2 = ((showOnInteract2 != null) ? showOnInteract2.Montage : null);
		}
		if (!string.IsNullOrEmpty(value2))
		{
			this.InteractMontage = p.ShowOnInteract.Montage;
			return;
		}
		if (((p != null) ? p.ConditionalShowOnInteracts : null) != null)
		{
			this.ConditionalInteractConfig = p.ConditionalShowOnInteracts;
		}
	}

	// Token: 0x0601A71F RID: 108319 RVA: 0x007CD8D8 File Offset: 0x007CBAD8
	protected override void OnEnter(ENpcPerformState? lastState)
	{
		if (!string.IsNullOrEmpty(this.InteractMontage))
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(this.InteractMontage, delegate([Nullable(2)] UAnimMontage asset, string path)
			{
				if (asset == null || !asset.IsValid())
				{
					return;
				}
				EntityHandle owner = this.Owner;
				if (owner == null || !owner.Valid)
				{
					return;
				}
				base.PlayMontage(new IPlayMontageParam
				{
					MontageAsset = asset
				});
				this.MontagePlaying = asset;
			}, 100, "js_undefined");
		}
		Singleton<EventSystem>.Instance.AddWithTarget(this.Owner, EEventName.OnInteractPlotEnd, new Action(this.OnInteractPlotEnd));
		this.ConditionalInteractMontage = "";
		this.NotInterrupMontageOnExit = false;
		if (this.ConditionalInteractConfig != null)
		{
			CharacterActorComponent component = this.Owner.Entity.GetComponent<CharacterActorComponent>();
			foreach (IConditionalNpcPerformOnInteract conditionalNpcPerformOnInteract in this.ConditionalInteractConfig)
			{
				if (ControllerBase<LevelGeneralController>.Instance.CheckConditionNew(conditionalNpcPerformOnInteract.Condition, component.Owner, EntityContext.Create(this.ActorComp.Entity.Id, null), null))
				{
					this.ConditionalInteractMontage = conditionalNpcPerformOnInteract.Perform.Montage;
					if (conditionalNpcPerformOnInteract.Perform.NotInterruptMontageWhenFinishedInteract != null)
					{
						this.NotInterrupMontageOnExit = conditionalNpcPerformOnInteract.Perform.NotInterruptMontageWhenFinishedInteract.Value;
						break;
					}
					break;
				}
			}
			if (!string.IsNullOrEmpty(this.ConditionalInteractMontage))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(this.ConditionalInteractMontage, delegate([Nullable(2)] UAnimMontage asset, string path)
				{
					if (asset == null || !asset.IsValid())
					{
						return;
					}
					base.PlayMontage(new IPlayMontageParam
					{
						MontageAsset = asset
					});
					this.MontagePlaying = asset;
				}, 100, "js_undefined");
			}
		}
	}

	// Token: 0x0601A720 RID: 108320 RVA: 0x007CDA5C File Offset: 0x007CBC5C
	protected override void OnUpdate(float delta)
	{
	}

	// Token: 0x0601A721 RID: 108321 RVA: 0x007CDA60 File Offset: 0x007CBC60
	protected override void OnExit(ENpcPerformState nextState)
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(this.Owner, EEventName.OnInteractPlotEnd, new Action(this.OnInteractPlotEnd));
		this.Owner.Entity.GetComponent<CharacterActorComponent>().ClearInput(false, true);
		if (!this.NotInterrupMontageOnExit)
		{
			base.StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				BlendOutTime = new float?(0.5f),
				Montage = this.MontagePlaying
			});
			this.MontagePlaying = null;
		}
	}

	// Token: 0x0601A722 RID: 108322 RVA: 0x007CDAE8 File Offset: 0x007CBCE8
	protected override void OnDestroy()
	{
	}

	// Token: 0x0601A723 RID: 108323 RVA: 0x007CDAEA File Offset: 0x007CBCEA
	private void OnInteractPlotEnd()
	{
		this.StateMachine.Switch(ENpcPerformState.Idle);
	}

	// Token: 0x0400D5A6 RID: 54694
	private string InteractMontage = "";

	// Token: 0x0400D5A7 RID: 54695
	[Nullable(2)]
	private UAnimMontage MontagePlaying;

	// Token: 0x0400D5A8 RID: 54696
	private bool HaveInteractConfig;

	// Token: 0x0400D5A9 RID: 54697
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IEnumerable<IConditionalNpcPerformOnInteract> ConditionalInteractConfig;

	// Token: 0x0400D5AA RID: 54698
	private string ConditionalInteractMontage = "";

	// Token: 0x0400D5AB RID: 54699
	private bool NotInterrupMontageOnExit;
}
