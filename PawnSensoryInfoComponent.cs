using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003238 RID: 12856
[NullableContext(1)]
[Nullable(0)]
public class PawnSensoryInfoComponent : EntityComponent
{
	// Token: 0x0601AC23 RID: 109603 RVA: 0x007F9728 File Offset: 0x007F7928
	protected override void OnEnable()
	{
		base.OnEnable();
		if (this.PerceptionsEvents.Count > 0 && base.Entity.GameBudgetManagedToken != 0U)
		{
			UKuroPerceptionInterface.MarkElementDisable(base.Entity.GameBudgetManagedToken, false);
		}
	}

	// Token: 0x0601AC24 RID: 109604 RVA: 0x007F975C File Offset: 0x007F795C
	protected override void OnDisable(string reason)
	{
		base.OnDisable(reason);
		if (this.PerceptionsEvents.Count > 0 && base.Entity.GameBudgetManagedToken != 0U)
		{
			UKuroPerceptionInterface.MarkElementDisable(base.Entity.GameBudgetManagedToken, true);
		}
	}

	// Token: 0x0601AC25 RID: 109605 RVA: 0x007F9794 File Offset: 0x007F7994
	[NullableContext(2)]
	[return: Nullable(1)]
	public PlayerPerceptionEvent CreatePerceptionEvent(float enterDistance, uint entityToken = 0U, Action onEnter = null, Action onLeave = null, Action onDestroy = null, Func<bool> enterCondition = null, float leaveDistance = -1f, global::Vector locationOffset = null)
	{
		PlayerPerceptionEvent playerPerceptionEvent = ControllerBase<EnvironmentalPerceptionController>.Instance.CreatePlayerPerceptionEvent();
		this.PerceptionsEvents.Add(playerPerceptionEvent);
		playerPerceptionEvent.Init(enterDistance, entityToken, onEnter, onLeave, onDestroy, enterCondition, leaveDistance, locationOffset);
		if (entityToken != 0U)
		{
			UKuroPerceptionInterface.MarkElementDisable(entityToken, !base.Entity.Active);
		}
		return playerPerceptionEvent;
	}

	// Token: 0x0601AC26 RID: 109606 RVA: 0x007F97E4 File Offset: 0x007F79E4
	public void DeletePerceptionEvent(PlayerPerceptionEvent @event)
	{
		this.PerceptionsEvents.Remove(@event);
		ControllerBase<EnvironmentalPerceptionController>.Instance.DestroyPlayerPerceptionEvent(@event);
	}

	// Token: 0x0601AC27 RID: 109607 RVA: 0x007F9800 File Offset: 0x007F7A00
	private void ClearPerceptionEvent()
	{
		foreach (PlayerPerceptionEvent @event in this.PerceptionsEvents)
		{
			ControllerBase<EnvironmentalPerceptionController>.Instance.DestroyPlayerPerceptionEvent(@event);
		}
		this.PerceptionsEvents.Clear();
	}

	// Token: 0x0601AC28 RID: 109608 RVA: 0x007F9864 File Offset: 0x007F7A64
	public void RegisterPerceptionEvent()
	{
		uint gameBudgetManagedToken = base.Entity.GameBudgetManagedToken;
		if (gameBudgetManagedToken == 0U)
		{
			return;
		}
		foreach (PlayerPerceptionEvent playerPerceptionEvent in this.PerceptionsEvents)
		{
			if (!playerPerceptionEvent.IsValid())
			{
				playerPerceptionEvent.Register(gameBudgetManagedToken);
			}
		}
		UKuroPerceptionInterface.MarkElementDisable(gameBudgetManagedToken, !base.Entity.Active);
	}

	// Token: 0x0601AC29 RID: 109609 RVA: 0x007F98E4 File Offset: 0x007F7AE4
	protected override void OnActivate()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		Entity entity = base.Entity;
		uint entityToken = (entity != null) ? entity.GameBudgetManagedToken : 0U;
		if (component.GetEntityType() == EEntityType.Player)
		{
			this.ExecuteInDefaultRange();
		}
		else
		{
			if (this.DefaultRangeEvent != null)
			{
				this.DeletePerceptionEvent(this.DefaultRangeEvent);
				this.DefaultRangeEvent = null;
			}
			this.DefaultRangeEvent = this.CreatePerceptionEvent(2000f, entityToken, new Action(this.ExecuteInDefaultRange), null, null, null, -1f, null);
		}
		if (this.LogicRangeEvent == null && this.LogicRangeInternal > 0f)
		{
			this.LogicRangeEvent = this.CreatePerceptionEvent(this.LogicRangeInternal, entityToken, new Action(this.OnRangeEnter), new Action(this.OnRangeLeave), null, null, -1f, null);
		}
	}

	// Token: 0x0601AC2A RID: 109610 RVA: 0x007F99A8 File Offset: 0x007F7BA8
	public void SetLogicRange(float range)
	{
		if (range > this.LogicRangeInternal)
		{
			this.LogicRangeInternal = range;
			if (this.LogicRangeEvent != null)
			{
				this.LogicRangeEvent.UpdateDistance(range, -1f);
				return;
			}
			uint gameBudgetManagedToken = base.Entity.GameBudgetManagedToken;
			if (gameBudgetManagedToken != 0U)
			{
				this.LogicRangeEvent = this.CreatePerceptionEvent(range, gameBudgetManagedToken, new Action(this.OnRangeEnter), new Action(this.OnRangeLeave), null, null, -1f, null);
			}
		}
	}

	// Token: 0x0601AC2B RID: 109611 RVA: 0x007F9A1C File Offset: 0x007F7C1C
	private void OnRangeEnter()
	{
		this.IsInRangeInternal = true;
		if (!this.IsAlreadyInitDefaultInternal)
		{
			this.ExecuteInDefaultRange();
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.EnterLogicRange);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.PlayerSenseTargetEnter, base.Entity.Id);
	}

	// Token: 0x0601AC2C RID: 109612 RVA: 0x007F9A6F File Offset: 0x007F7C6F
	private void OnRangeLeave()
	{
		this.IsInRangeInternal = false;
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.LeaveLogicRange);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.PlayerSenseTargetLeave, base.Entity.Id);
	}

	// Token: 0x0601AC2D RID: 109613 RVA: 0x007F9AAC File Offset: 0x007F7CAC
	protected override bool OnEnd()
	{
		this.LogicRangeEvent = null;
		this.DefaultRangeEvent = null;
		this.ClearPerceptionEvent();
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.LeaveLogicRange);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.PlayerSenseTargetLeave, base.Entity.Id);
		return true;
	}

	// Token: 0x0601AC2E RID: 109614 RVA: 0x007F9AFF File Offset: 0x007F7CFF
	private void ExecuteInDefaultRange()
	{
		if (!this.IsAlreadyInitDefaultInternal)
		{
			this.IsAlreadyInitDefaultInternal = true;
			if (this.DefaultRangeEvent != null)
			{
				this.DeletePerceptionEvent(this.DefaultRangeEvent);
				this.DefaultRangeEvent = null;
			}
		}
	}

	// Token: 0x17002458 RID: 9304
	// (get) Token: 0x0601AC2F RID: 109615 RVA: 0x007F9B2B File Offset: 0x007F7D2B
	public double PlayerDistSquared
	{
		get
		{
			return this.PlayerDistSquaredInternal;
		}
	}

	// Token: 0x17002459 RID: 9305
	// (get) Token: 0x0601AC30 RID: 109616 RVA: 0x007F9B33 File Offset: 0x007F7D33
	public double PlayerDist
	{
		get
		{
			return Math.Sqrt(this.PlayerDistSquaredInternal);
		}
	}

	// Token: 0x1700245A RID: 9306
	// (get) Token: 0x0601AC31 RID: 109617 RVA: 0x007F9B40 File Offset: 0x007F7D40
	public float LogicRange
	{
		get
		{
			return this.LogicRangeInternal;
		}
	}

	// Token: 0x1700245B RID: 9307
	// (get) Token: 0x0601AC32 RID: 109618 RVA: 0x007F9B48 File Offset: 0x007F7D48
	public bool IsInLogicRange
	{
		get
		{
			return this.IsInRangeInternal;
		}
	}

	// Token: 0x0601AC33 RID: 109619 RVA: 0x007F9B50 File Offset: 0x007F7D50
	public string GetDebugString()
	{
		string text = "";
		string str = text;
		string str2 = "DefaultRangeToken: ";
		PlayerPerceptionEvent defaultRangeEvent = this.DefaultRangeEvent;
		text = str + str2 + (((defaultRangeEvent != null) ? defaultRangeEvent.EventToken.ToString() : null) ?? "undefined") + "\n";
		string str3 = text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(69, 3);
		defaultInterpolatedStringHandler.AppendLiteral("LogicRangeToken: ");
		PlayerPerceptionEvent logicRangeEvent = this.LogicRangeEvent;
		defaultInterpolatedStringHandler.AppendFormatted(((logicRangeEvent != null) ? logicRangeEvent.EventToken.ToString() : null) ?? "undefined");
		defaultInterpolatedStringHandler.AppendLiteral("; LogicRange: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.LogicRangeInternal);
		defaultInterpolatedStringHandler.AppendLiteral("; IsInRangeInternal: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.IsInLogicRange);
		defaultInterpolatedStringHandler.AppendLiteral("\nLogicRangeInfo:\n");
		text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
		if (this.LogicRangeEvent != null)
		{
			text += UKuroPerceptionInterface.GetPlayerPerceptionDebugString(this.LogicRangeEvent.EventToken);
		}
		return text;
	}

	// Token: 0x0601AC34 RID: 109620 RVA: 0x007F9C44 File Offset: 0x007F7E44
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PawnSensoryInfoComponent pawnSensoryInfoComponent = (PawnSensoryInfoComponent)componentTemplate;
		if (base.CanResetComponentProperty("LogicRangeInternal"))
		{
			this.LogicRangeInternal = pawnSensoryInfoComponent.LogicRangeInternal;
		}
		if (base.CanResetComponentProperty("IsInRangeInternal"))
		{
			this.IsInRangeInternal = pawnSensoryInfoComponent.IsInRangeInternal;
		}
		if (base.CanResetComponentProperty("IsAlreadyInitDefaultInternal"))
		{
			this.IsAlreadyInitDefaultInternal = pawnSensoryInfoComponent.IsAlreadyInitDefaultInternal;
		}
		if (base.CanResetComponentProperty("DefaultRangeEvent"))
		{
			if (pawnSensoryInfoComponent.DefaultRangeEvent == null)
			{
				this.DefaultRangeEvent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.DefaultRangeEvent), "DefaultRangeEvent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PerceptionsEvents") && pawnSensoryInfoComponent.PerceptionsEvents != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.PerceptionsEvents), "PerceptionsEvents"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LogicRangeEvent"))
		{
			if (pawnSensoryInfoComponent.LogicRangeEvent == null)
			{
				this.LogicRangeEvent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.LogicRangeEvent), "LogicRangeEvent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D911 RID: 55569
	public const int PERCEPTION_SEARCH_RANGE = 2000;

	// Token: 0x0400D912 RID: 55570
	private float LogicRangeInternal;

	// Token: 0x0400D913 RID: 55571
	private bool IsInRangeInternal;

	// Token: 0x0400D914 RID: 55572
	private bool IsAlreadyInitDefaultInternal;

	// Token: 0x0400D915 RID: 55573
	private readonly double PlayerDistSquaredInternal = double.MaxValue;

	// Token: 0x0400D916 RID: 55574
	[Nullable(2)]
	private PlayerPerceptionEvent DefaultRangeEvent;

	// Token: 0x0400D917 RID: 55575
	private readonly HashSet<PlayerPerceptionEvent> PerceptionsEvents = new HashSet<PlayerPerceptionEvent>();

	// Token: 0x0400D918 RID: 55576
	[Nullable(2)]
	private PlayerPerceptionEvent LogicRangeEvent;
}
