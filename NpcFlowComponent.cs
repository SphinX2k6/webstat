using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.Interaction;
using UnrealEngine;

// Token: 0x02003185 RID: 12677
[NullableContext(2)]
[Nullable(0)]
public class NpcFlowComponent : CharacterFlowComponent
{
	// Token: 0x0601A48A RID: 107658 RVA: 0x007BCEE8 File Offset: 0x007BB0E8
	protected override bool OnStart()
	{
		this.SensoryComp = base.Entity.GetComponent<PawnSensoryInfoComponent>();
		base.OnStart();
		return true;
	}

	// Token: 0x0601A48B RID: 107659 RVA: 0x007BCF04 File Offset: 0x007BB104
	protected override void InitFlowLogic(BubbleComponent flowData)
	{
		if (flowData == null)
		{
			return;
		}
		this.FlowLogic = new NpcFlowLogic(this.ActorComp, flowData);
		this.FlowRange.Init(this.ActorComp.ActorTransform);
		BubbleComponent flowData2 = this.FlowData;
		float? enterRange = (flowData2 != null) ? new float?(flowData2.EnterRange) : null;
		BubbleComponent flowData3 = this.FlowData;
		float? leaveRange = (flowData3 != null) ? new float?(flowData3.LeaveRange) : null;
		BubbleComponent flowData4 = this.FlowData;
		this.InitFlowLogicRange(enterRange, leaveRange, (flowData4 != null) ? flowData4.TriggerCylinderConfig : null);
		this.IsEnter = false;
		this.IsInit = true;
	}

	// Token: 0x0601A48C RID: 107660 RVA: 0x007BCFA2 File Offset: 0x007BB1A2
	protected override bool InitFlowLogicRange(float? enterRange, float? leaveRange, IBubbleRangeCylinderConfig config)
	{
		if (!base.InitFlowLogicRange(enterRange, leaveRange, config))
		{
			return false;
		}
		PawnSensoryInfoComponent sensoryComp = this.SensoryComp;
		if (sensoryComp != null)
		{
			sensoryComp.SetLogicRange(leaveRange.GetValueOrDefault(1500f));
		}
		return true;
	}

	// Token: 0x0601A48D RID: 107661 RVA: 0x007BCFD0 File Offset: 0x007BB1D0
	protected override bool CheckCondition()
	{
		if (!base.CheckCondition())
		{
			return false;
		}
		if (this.SensoryComp == null)
		{
			return false;
		}
		if (!this.SensoryComp.IsInLogicRange)
		{
			base.ForceStopFlow();
			return false;
		}
		int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
		int id = base.Entity.Id;
		if (currentInteractEntityId.GetValueOrDefault() == id & currentInteractEntityId != null)
		{
			base.ForceStopFlow();
			return false;
		}
		return true;
	}

	// Token: 0x0601A48E RID: 107662 RVA: 0x007BD03C File Offset: 0x007BB23C
	public bool TryPlayMontage(string montagePath)
	{
		this.ActionId = -1;
		this.MontageId = -1;
		BasePerformComponent component = base.Entity.GetComponent<BasePerformComponent>();
		if (component != null && montagePath != null && montagePath.Contains('/'))
		{
			IPlayMontageParam param = new IPlayMontageParam
			{
				MontagePath = montagePath,
				OnStartCallback = delegate(int id, EPerformGroup group)
				{
					this.MontageId = id;
				},
				OnEndCallback = delegate(UAnimMontage _, bool _)
				{
					this.MontageId = -1;
				}
			};
			this.ActionId = component.PlayPerformMontage(EPerformMode.Ecology, param, null, null, false);
		}
		return false;
	}

	// Token: 0x0601A48F RID: 107663 RVA: 0x007BD0B8 File Offset: 0x007BB2B8
	private void StopMontage()
	{
		if (this.ActorComp == null || this.ActorComp.SkeletalMesh == null)
		{
			return;
		}
		BasePerformComponent component = base.Entity.GetComponent<BasePerformComponent>();
		if (component == null)
		{
			return;
		}
		component.EnableAction(this.ActionId, false);
		IStopMontageParam param = new IStopMontageParam
		{
			Method = new EStopMethod?(EStopMethod.BlendOut),
			BlendOutTime = new float?(0.3f),
			HandleId = new int?(this.MontageId)
		};
		component.StopPerformMontage(EPerformMode.Ecology, param, null, null);
	}

	// Token: 0x0601A490 RID: 107664 RVA: 0x007BD137 File Offset: 0x007BB337
	public override void RemoveFlowActions()
	{
		NpcFlowLogic npcFlowLogic = this.FlowLogic as NpcFlowLogic;
		if (npcFlowLogic != null)
		{
			npcFlowLogic.HideDialogueText();
		}
		if (npcFlowLogic != null)
		{
			npcFlowLogic.ClearAudio();
		}
		this.StopMontage();
	}

	// Token: 0x0601A491 RID: 107665 RVA: 0x007BD164 File Offset: 0x007BB364
	public int? GetTimberId()
	{
		BubbleComponent flowData = this.FlowData;
		if (flowData == null)
		{
			return null;
		}
		return flowData.TimberId;
	}

	// Token: 0x0601A492 RID: 107666 RVA: 0x007BD18C File Offset: 0x007BB38C
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		NpcFlowComponent npcFlowComponent = (NpcFlowComponent)componentTemplate;
		if (base.CanResetComponentProperty("SensoryComp"))
		{
			if (npcFlowComponent.SensoryComp == null)
			{
				this.SensoryComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnSensoryInfoComponent>(this.SensoryComp), "SensoryComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MontageId"))
		{
			this.MontageId = npcFlowComponent.MontageId;
		}
		if (base.CanResetComponentProperty("ActionId"))
		{
			this.ActionId = npcFlowComponent.ActionId;
		}
		return true;
	}

	// Token: 0x0400D3BF RID: 54207
	private const float STOP_MONTAGE_BLEND_OUT_TIME = 0.3f;

	// Token: 0x0400D3C0 RID: 54208
	private PawnSensoryInfoComponent SensoryComp;

	// Token: 0x0400D3C1 RID: 54209
	private int MontageId = -1;

	// Token: 0x0400D3C2 RID: 54210
	private int ActionId = -1;
}
