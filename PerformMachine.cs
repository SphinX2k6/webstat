using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003102 RID: 12546
[NullableContext(1)]
[Nullable(0)]
public class PerformMachine
{
	// Token: 0x06019F07 RID: 106247 RVA: 0x00795B98 File Offset: 0x00793D98
	public PerformMachine(BasePerformComponent performComp, EPerformGroup group = EPerformGroup.DefaultGroup)
	{
		this.PerformComp = performComp;
		this.Group = group;
	}

	// Token: 0x06019F08 RID: 106248 RVA: 0x00795BE4 File Offset: 0x00793DE4
	public void Init()
	{
		this.Modes[EPerformMode.Plot] = new PlotMode(EPerformMode.Plot, this.PerformComp, this);
		this.Modes[EPerformMode.Action] = new ActionMode(EPerformMode.Action, this.PerformComp, this);
		this.Modes[EPerformMode.Ecology] = new EcologyMode(EPerformMode.Ecology, this.PerformComp, this);
		this.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityById(this.PerformComp.Entity.Id);
		Singleton<EventSystem>.Instance.AddWithTarget(this.PerformComp.Entity, EEventName.AnimCompActiveStateChange, new Action<bool>(this.OnAnimCompActiveStateChange));
	}

	// Token: 0x06019F09 RID: 106249 RVA: 0x00795C84 File Offset: 0x00793E84
	public void Clear()
	{
		foreach (PerformModeBase performModeBase in this.Modes.Values)
		{
			performModeBase.Clear();
		}
		this.Modes.Clear();
		if (this.CurrentAction != null)
		{
			PerformActionPool.ReturnAction(this.CurrentAction);
		}
		this.CurrentAction = null;
		this.PendingActionCache.Clear();
		this.EntityHandle = null;
		this.CurrentVolatileLoadId = -1;
		this.CurrentVolatileActionId = -1;
		this.CurrentVolatileMontageId = -1;
		Singleton<EventSystem>.Instance.RemoveWithTarget(this.PerformComp.Entity, EEventName.AnimCompActiveStateChange, new Action<bool>(this.OnAnimCompActiveStateChange));
	}

	// Token: 0x06019F0A RID: 106250 RVA: 0x00795D4C File Offset: 0x00793F4C
	public void CleanAction()
	{
		if (this.CurrentAction != null)
		{
			PerformActionPool.ReturnAction(this.CurrentAction);
			this.CurrentAction = null;
		}
		foreach (PerformModeBase performModeBase in this.Modes.Values)
		{
			performModeBase.Clear();
		}
	}

	// Token: 0x06019F0B RID: 106251 RVA: 0x00795DBC File Offset: 0x00793FBC
	public EPerformMode GetCurrentMode()
	{
		return this.CurrentMode;
	}

	// Token: 0x06019F0C RID: 106252 RVA: 0x00795DC4 File Offset: 0x00793FC4
	[NullableContext(2)]
	public int DoAction(EPerformMode mode, EPerformAction actionType, [Nullable(1)] IActionParamMap param, Action<int> onBeforeExecute = null, Action<int> onAfterExecute = null, bool bPersistent = false)
	{
		this.InstanceId++;
		int instanceId = this.InstanceId;
		IPerformActionBase action = PerformActionPool.GetAction(actionType, instanceId, param, this.PerformComp, this.Group, new Action(this.OnActionFinish), onBeforeExecute, onAfterExecute);
		action.IsValid = true;
		action.Mode = mode;
		action.IsPersistent = bPersistent;
		this.PendingActionCache[instanceId] = action;
		this.Modes[mode].PushAction(action, false);
		this.Refresh();
		return instanceId;
	}

	// Token: 0x06019F0D RID: 106253 RVA: 0x00795E48 File Offset: 0x00794048
	public bool EnableAction(int id, bool bEnable)
	{
		if (!this.PendingActionCache.ContainsKey(id))
		{
			return false;
		}
		this.PendingActionCache[id].IsValid = bEnable;
		return true;
	}

	// Token: 0x06019F0E RID: 106254 RVA: 0x00795E6D File Offset: 0x0079406D
	public void Update()
	{
		if (this.PendingActionCache.Count > 0)
		{
			this.Refresh();
		}
	}

	// Token: 0x06019F0F RID: 106255 RVA: 0x00795E84 File Offset: 0x00794084
	private void Refresh()
	{
		IPerformActionBase currentAction = this.CurrentAction;
		if (currentAction != null && currentAction.IsAtomic)
		{
			return;
		}
		BaseAnimationComponent component = this.PerformComp.Entity.GetComponent<BaseAnimationComponent>();
		if (component == null || !component.Active)
		{
			return;
		}
		bool flag = true;
		if (this.CurrentMode != EPerformMode.Undetermined && this.Modes[this.CurrentMode].CheckExit())
		{
			this.CurrentMode = EPerformMode.Undetermined;
		}
		if (this.CurrentMode == EPerformMode.Undetermined)
		{
			flag = (this.CheckModeEnter(EPerformMode.Plot) || this.CheckModeEnter(EPerformMode.Action) || this.CheckModeEnter(EPerformMode.Ecology));
		}
		if (!flag)
		{
			return;
		}
		IPerformActionBase performActionBase = this.Modes[this.CurrentMode].PopAction();
		if (performActionBase == null)
		{
			return;
		}
		this.PendingActionCache.Remove(performActionBase.Id);
		if (this.CurrentAction != null)
		{
			if (!this.CurrentAction.IsPersistent || this.CurrentAction.Mode == this.CurrentMode)
			{
				PerformActionPool.ReturnAction(this.CurrentAction);
			}
			else
			{
				this.CurrentAction.Interrupt();
				this.PendingActionCache[performActionBase.Id] = performActionBase;
				this.Modes[this.CurrentAction.Mode].PushAction(this.CurrentAction, true);
			}
		}
		this.CurrentAction = null;
		this.ExecuteAction(performActionBase);
		this.Refresh();
	}

	// Token: 0x06019F10 RID: 106256 RVA: 0x00795FCF File Offset: 0x007941CF
	private bool CheckModeEnter(EPerformMode mode)
	{
		if (this.Modes[mode].CheckEnter())
		{
			this.CurrentMode = mode;
			return true;
		}
		return false;
	}

	// Token: 0x06019F11 RID: 106257 RVA: 0x00795FEE File Offset: 0x007941EE
	private void ExecuteAction(IPerformActionBase actionInfo)
	{
		this.CurrentAction = actionInfo;
		actionInfo.Execute();
	}

	// Token: 0x06019F12 RID: 106258 RVA: 0x00795FFD File Offset: 0x007941FD
	private void OnActionFinish()
	{
		PerformActionPool.ReturnAction(this.CurrentAction);
		this.CurrentAction = null;
		this.Refresh();
	}

	// Token: 0x06019F13 RID: 106259 RVA: 0x00796017 File Offset: 0x00794217
	private void OnAnimCompActiveStateChange(bool enable)
	{
		if (enable)
		{
			this.Refresh();
		}
	}

	// Token: 0x0400CFF6 RID: 53238
	private readonly BasePerformComponent PerformComp;

	// Token: 0x0400CFF7 RID: 53239
	public readonly EPerformGroup Group;

	// Token: 0x0400CFF8 RID: 53240
	private int InstanceId;

	// Token: 0x0400CFF9 RID: 53241
	public Dictionary<EPerformMode, PerformModeBase> Modes = new Dictionary<EPerformMode, PerformModeBase>();

	// Token: 0x0400CFFA RID: 53242
	private EPerformMode CurrentMode;

	// Token: 0x0400CFFB RID: 53243
	private readonly Dictionary<int, IPerformActionBase> PendingActionCache = new Dictionary<int, IPerformActionBase>();

	// Token: 0x0400CFFC RID: 53244
	[Nullable(2)]
	public IPerformActionBase CurrentAction;

	// Token: 0x0400CFFD RID: 53245
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x0400CFFE RID: 53246
	public int CurrentVolatileLoadId = -1;

	// Token: 0x0400CFFF RID: 53247
	public int CurrentVolatileActionId = -1;

	// Token: 0x0400D000 RID: 53248
	public int CurrentVolatileMontageId = -1;
}
