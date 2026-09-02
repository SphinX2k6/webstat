using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

// Token: 0x02003237 RID: 12855
[NullableContext(2)]
[Nullable(0)]
public class PawnPerceptionComponent : EntityComponent
{
	// Token: 0x17002454 RID: 9300
	// (get) Token: 0x0601AC08 RID: 109576 RVA: 0x007F8CD8 File Offset: 0x007F6ED8
	public bool IsInInteractRange
	{
		get
		{
			return this.IsInInteractRangeInternal;
		}
	}

	// Token: 0x17002455 RID: 9301
	// (get) Token: 0x0601AC09 RID: 109577 RVA: 0x007F8CE0 File Offset: 0x007F6EE0
	public bool InAnyOptionWithOffsetRange
	{
		get
		{
			return this.OptionWithOffsetInRange.Count > 0;
		}
	}

	// Token: 0x17002456 RID: 9302
	// (get) Token: 0x0601AC0A RID: 109578 RVA: 0x007F8CF0 File Offset: 0x007F6EF0
	public bool IsInAdsorbRange
	{
		get
		{
			return this.IsInAdsorbRangeInternal;
		}
	}

	// Token: 0x17002457 RID: 9303
	// (get) Token: 0x0601AC0B RID: 109579 RVA: 0x007F8CF8 File Offset: 0x007F6EF8
	public bool IsInSightRange
	{
		get
		{
			return this.IsInSightRangeInternal;
		}
	}

	// Token: 0x0601AC0C RID: 109580 RVA: 0x007F8D00 File Offset: 0x007F6F00
	public void SetInteractRange(float inRange, float exitRange = 0f, Vector offset = null)
	{
		this.PawnSensoryInfo.SetLogicRange((float)((double)Math.Max(inRange + 100f, exitRange) + ((offset != null) ? offset.Size() : 0.0)));
		if (this.InteractEvent != null)
		{
			this.InteractEvent.UpdateDistance(inRange, (exitRange == 0f) ? inRange : exitRange);
			return;
		}
		PawnSensoryInfoComponent pawnSensoryInfo = this.PawnSensoryInfo;
		Entity entity = base.Entity;
		this.InteractEvent = pawnSensoryInfo.CreatePerceptionEvent(inRange, (entity != null) ? entity.GameBudgetManagedToken : 0U, delegate
		{
			this.IsInInteractRangeInternal = true;
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.OnInEntityInteractRangeChange, true);
		}, delegate
		{
			this.IsInInteractRangeInternal = false;
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.OnInEntityInteractRangeChange, false);
		}, null, null, exitRange, offset);
	}

	// Token: 0x0601AC0D RID: 109581 RVA: 0x007F8DA0 File Offset: 0x007F6FA0
	public void SetInteractRangeWithTags(int tagId, float inRange, float exitRange = 0f, Vector offset = null, Action enterEvent = null, Action leaveEvent = null)
	{
		this.PawnSensoryInfo.SetLogicRange((float)((double)Math.Max(inRange + 100f, exitRange) + ((offset != null) ? offset.Size() : 0.0)));
		if (this.InteractEventWithTagsInternal.ContainsKey(tagId))
		{
			this.InteractEventWithTagsInternal[tagId].UpdateDistance(inRange, (exitRange == 0f) ? inRange : exitRange);
			return;
		}
		PawnSensoryInfoComponent pawnSensoryInfo = this.PawnSensoryInfo;
		Entity entity = base.Entity;
		PlayerPerceptionEvent value = pawnSensoryInfo.CreatePerceptionEvent(inRange, (entity != null) ? entity.GameBudgetManagedToken : 0U, delegate
		{
			if (enterEvent != null)
			{
				enterEvent();
			}
		}, delegate
		{
			if (leaveEvent != null)
			{
				leaveEvent();
			}
		}, null, null, exitRange, offset);
		this.InteractEventWithTagsInternal[tagId] = value;
	}

	// Token: 0x0601AC0E RID: 109582 RVA: 0x007F8E6C File Offset: 0x007F706C
	public void SetOffsetOptionInteractRange(int optionId, float inRange, float exitRange = 0f, Vector offset = null, Action enterEvent = null, Action leaveEvent = null)
	{
		this.PawnSensoryInfo.SetLogicRange((float)((double)Math.Max(inRange + 100f, exitRange) + ((offset != null) ? offset.Size() : 0.0)));
		if (this.OffsetOptionInteractEvent.ContainsKey(optionId))
		{
			this.OffsetOptionInteractEvent[optionId].UpdateDistance(inRange, (exitRange == 0f) ? inRange : exitRange);
		}
		PawnSensoryInfoComponent pawnSensoryInfo = this.PawnSensoryInfo;
		Entity entity = base.Entity;
		PlayerPerceptionEvent value = pawnSensoryInfo.CreatePerceptionEvent(inRange, (entity != null) ? entity.GameBudgetManagedToken : 0U, delegate
		{
			if (enterEvent != null)
			{
				enterEvent();
			}
			this.OptionWithOffsetInRange.Add(optionId);
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(this.Entity, EEventName.OnInEntityInteractRangeChange, true);
		}, delegate
		{
			if (leaveEvent != null)
			{
				leaveEvent();
			}
			this.OptionWithOffsetInRange.Remove(optionId);
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(this.Entity, EEventName.OnInEntityInteractRangeChange, false);
		}, null, null, exitRange, offset);
		this.OffsetOptionInteractEvent[optionId] = value;
	}

	// Token: 0x0601AC0F RID: 109583 RVA: 0x007F8F54 File Offset: 0x007F7154
	public void SetSightRange(float inRange)
	{
		this.PawnSensoryInfo.SetLogicRange(inRange);
		if (this.SightEvent != null)
		{
			this.SightEvent.UpdateDistance(inRange, -1f);
			return;
		}
		PawnSensoryInfoComponent pawnSensoryInfo = this.PawnSensoryInfo;
		Entity entity = base.Entity;
		this.SightEvent = pawnSensoryInfo.CreatePerceptionEvent(inRange, (entity != null) ? entity.GameBudgetManagedToken : 0U, delegate
		{
			this.IsInSightRangeInternal = true;
		}, delegate
		{
			this.IsInSightRangeInternal = false;
		}, null, null, -1f, null);
	}

	// Token: 0x0601AC10 RID: 109584 RVA: 0x007F8FCC File Offset: 0x007F71CC
	public void SetGuideRange(float inRange)
	{
		this.PawnSensoryInfo.SetLogicRange(inRange);
		if (this.GuideEvent != null)
		{
			this.GuideEvent.UpdateDistance(inRange, -1f);
			return;
		}
		PawnSensoryInfoComponent pawnSensoryInfo = this.PawnSensoryInfo;
		Entity entity = base.Entity;
		this.GuideEvent = pawnSensoryInfo.CreatePerceptionEvent(inRange, (entity != null) ? entity.GameBudgetManagedToken : 0U, delegate
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGuideRangeEnter, base.Entity.Id);
		}, null, null, null, -1f, null);
	}

	// Token: 0x0601AC11 RID: 109585 RVA: 0x007F9038 File Offset: 0x007F7238
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.MonitorConditionIds = new TMap<int, int>();
		this.ConfigId = base.Entity.GetComponent<CreatureDataComponent>().GetPbDataId();
		return true;
	}

	// Token: 0x0601AC12 RID: 109586 RVA: 0x007F905C File Offset: 0x007F725C
	protected override bool OnInit()
	{
		this.PawnSensoryInfo = base.Entity.GetComponent<PawnSensoryInfoComponent>();
		return true;
	}

	// Token: 0x0601AC13 RID: 109587 RVA: 0x007F9070 File Offset: 0x007F7270
	protected override bool OnStart()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.OwnActor = base.Entity.GetComponent<BaseActorComponent>();
		if (!UKismetSystemLibrary.IsValid(this.OwnActor.Owner))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Pawn;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[PawnPerceptionComponent.OnStart] 非法Actor";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.LeaveLogicRange, new Action(this.OnLeaveLogicRange));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnUpdateNearbyEnable, new Action<bool>(this.OnUpdateNearbyEnable));
		return true;
	}

	// Token: 0x0601AC14 RID: 109588 RVA: 0x007F9124 File Offset: 0x007F7324
	protected override void OnActivate()
	{
		SceneItemNearbyTrackingComponent component = base.Entity.GetComponent<SceneItemNearbyTrackingComponent>();
		if (component != null)
		{
			int value = component.ShowRange.Value;
			int value2 = component.HideRange.Value;
			this.NearbyEnable = component.EnableTracking;
			this.IsEnterNearby = false;
			PawnSensoryInfoComponent pawnSensoryInfo = this.PawnSensoryInfo;
			float enterDistance = (float)value;
			Entity entity = base.Entity;
			pawnSensoryInfo.CreatePerceptionEvent(enterDistance, (entity != null) ? entity.GameBudgetManagedToken : 0U, delegate
			{
				this.IsEnterNearby = true;
				Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.OnEnterNearbyTrackRange, base.Entity);
			}, delegate
			{
				this.IsEnterNearby = false;
				Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.OnLeaveNearbyTrackRange, base.Entity);
			}, null, () => this.NearbyEnable, (float)value2, null);
			this.PawnSensoryInfo.SetLogicRange((float)value);
			this.PawnSensoryInfo.SetLogicRange((float)(value2 + 100));
		}
	}

	// Token: 0x0601AC15 RID: 109589 RVA: 0x007F91DC File Offset: 0x007F73DC
	protected override bool OnEnd()
	{
		if (this.IsEnterNearby)
		{
			Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.RemoveNearbyTrack, base.Entity);
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.LeaveLogicRange, new Action(this.OnLeaveLogicRange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnUpdateNearbyEnable, new Action<bool>(this.OnUpdateNearbyEnable));
		this.InteractEvent = null;
		this.SightEvent = null;
		this.GuideEvent = null;
		this.InteractEventWithTagsInternal.Clear();
		this.MonitorConditionIds.Empty(0);
		return true;
	}

	// Token: 0x0601AC16 RID: 109590 RVA: 0x007F9278 File Offset: 0x007F7478
	private void OnLeaveLogicRange()
	{
		if (this.IsEnterNearby)
		{
			this.IsEnterNearby = false;
			Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.OnLeaveNearbyTrackRange, base.Entity);
		}
	}

	// Token: 0x0601AC17 RID: 109591 RVA: 0x007F929F File Offset: 0x007F749F
	private void OnUpdateNearbyEnable(bool enable)
	{
		this.NearbyEnable = enable;
		this.IsEnterNearby = false;
	}

	// Token: 0x0601AC18 RID: 109592 RVA: 0x007F92B0 File Offset: 0x007F74B0
	[NullableContext(1)]
	public string GetDebugString()
	{
		string text = "";
		string str = text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 2);
		defaultInterpolatedStringHandler.AppendLiteral("InteractRangeToken: ");
		PlayerPerceptionEvent interactEvent = this.InteractEvent;
		defaultInterpolatedStringHandler.AppendFormatted(((interactEvent != null) ? interactEvent.EventToken.ToString() : null) ?? "undefined");
		defaultInterpolatedStringHandler.AppendLiteral("; IsInRangeInternal: ");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.IsInInteractRangeInternal);
		defaultInterpolatedStringHandler.AppendLiteral("\nInteractRangeInfo:\n");
		text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		if (this.InteractEvent != null)
		{
			text += UKuroPerceptionInterface.GetPlayerPerceptionDebugString(this.InteractEvent.EventToken);
		}
		if (this.OffsetOptionInteractEvent.Count > 0)
		{
			text += "\nOptionInteractRangeInfo:\n";
			foreach (PlayerPerceptionEvent playerPerceptionEvent in this.OffsetOptionInteractEvent.Values)
			{
				text = text + UKuroPerceptionInterface.GetPlayerPerceptionDebugString(playerPerceptionEvent.EventToken) + "\n";
			}
		}
		return text;
	}

	// Token: 0x0601AC19 RID: 109593 RVA: 0x007F93D0 File Offset: 0x007F75D0
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PawnPerceptionComponent pawnPerceptionComponent = (PawnPerceptionComponent)componentTemplate;
		if (base.CanResetComponentProperty("OwnActor"))
		{
			if (pawnPerceptionComponent.OwnActor == null)
			{
				this.OwnActor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.OwnActor), "OwnActor"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInInteractRangeInternal"))
		{
			this.IsInInteractRangeInternal = pawnPerceptionComponent.IsInInteractRangeInternal;
		}
		if (base.CanResetComponentProperty("IsInSightRangeInternal"))
		{
			this.IsInSightRangeInternal = pawnPerceptionComponent.IsInSightRangeInternal;
		}
		if (base.CanResetComponentProperty("NearbyEnable"))
		{
			this.NearbyEnable = pawnPerceptionComponent.NearbyEnable;
		}
		if (base.CanResetComponentProperty("IsEnterNearby"))
		{
			this.IsEnterNearby = pawnPerceptionComponent.IsEnterNearby;
		}
		if (base.CanResetComponentProperty("MonitorConditionIds"))
		{
			if (pawnPerceptionComponent.MonitorConditionIds == null)
			{
				this.MonitorConditionIds = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int, int>(this.MonitorConditionIds), "MonitorConditionIds"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PawnSensoryInfo"))
		{
			if (pawnPerceptionComponent.PawnSensoryInfo == null)
			{
				this.PawnSensoryInfo = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnSensoryInfoComponent>(this.PawnSensoryInfo), "PawnSensoryInfo"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ConfigId"))
		{
			this.ConfigId = pawnPerceptionComponent.ConfigId;
		}
		if (base.CanResetComponentProperty("InteractEvent"))
		{
			if (pawnPerceptionComponent.InteractEvent == null)
			{
				this.InteractEvent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.InteractEvent), "InteractEvent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InteractEventWithTagsInternal") && pawnPerceptionComponent.InteractEventWithTagsInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, PlayerPerceptionEvent>>(this.InteractEventWithTagsInternal), "InteractEventWithTagsInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OffsetOptionInteractEvent") && pawnPerceptionComponent.OffsetOptionInteractEvent != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, PlayerPerceptionEvent>>(this.OffsetOptionInteractEvent), "OffsetOptionInteractEvent"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OptionWithOffsetInRange") && pawnPerceptionComponent.OptionWithOffsetInRange != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.OptionWithOffsetInRange), "OptionWithOffsetInRange"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SightEvent"))
		{
			if (pawnPerceptionComponent.SightEvent == null)
			{
				this.SightEvent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.SightEvent), "SightEvent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GuideEvent"))
		{
			if (pawnPerceptionComponent.GuideEvent == null)
			{
				this.GuideEvent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayerPerceptionEvent>(this.GuideEvent), "GuideEvent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D900 RID: 55552
	private const int DISTANCE_OFFSET = 100;

	// Token: 0x0400D901 RID: 55553
	private const int INTERACT_LOGIC_OFFSET = 100;

	// Token: 0x0400D902 RID: 55554
	private BaseActorComponent OwnActor;

	// Token: 0x0400D903 RID: 55555
	private bool IsInInteractRangeInternal;

	// Token: 0x0400D904 RID: 55556
	private readonly bool IsInAdsorbRangeInternal;

	// Token: 0x0400D905 RID: 55557
	private bool IsInSightRangeInternal;

	// Token: 0x0400D906 RID: 55558
	public bool NearbyEnable;

	// Token: 0x0400D907 RID: 55559
	private bool IsEnterNearby;

	// Token: 0x0400D908 RID: 55560
	private TMap<int, int> MonitorConditionIds;

	// Token: 0x0400D909 RID: 55561
	private PawnSensoryInfoComponent PawnSensoryInfo;

	// Token: 0x0400D90A RID: 55562
	protected int ConfigId;

	// Token: 0x0400D90B RID: 55563
	private PlayerPerceptionEvent InteractEvent;

	// Token: 0x0400D90C RID: 55564
	[Nullable(1)]
	private readonly Dictionary<int, PlayerPerceptionEvent> InteractEventWithTagsInternal = new Dictionary<int, PlayerPerceptionEvent>();

	// Token: 0x0400D90D RID: 55565
	[Nullable(1)]
	private readonly Dictionary<int, PlayerPerceptionEvent> OffsetOptionInteractEvent = new Dictionary<int, PlayerPerceptionEvent>();

	// Token: 0x0400D90E RID: 55566
	[Nullable(1)]
	private readonly HashSet<int> OptionWithOffsetInRange = new HashSet<int>();

	// Token: 0x0400D90F RID: 55567
	private PlayerPerceptionEvent SightEvent;

	// Token: 0x0400D910 RID: 55568
	private PlayerPerceptionEvent GuideEvent;
}
