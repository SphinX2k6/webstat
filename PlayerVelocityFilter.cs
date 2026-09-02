using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x0200345A RID: 13402
[NullableContext(1)]
[Nullable(0)]
public class PlayerVelocityFilter : EntityToLoadFilter
{
	// Token: 0x17002660 RID: 9824
	// (get) Token: 0x0601C1C2 RID: 115138 RVA: 0x00862C62 File Offset: 0x00860E62
	public override string DebugName
	{
		get
		{
			return "PlayerVelocityFilter";
		}
	}

	// Token: 0x0601C1C3 RID: 115139 RVA: 0x00862C69 File Offset: 0x00860E69
	public override void Init()
	{
		base.Init();
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnHighSpeedModeChanged, new Action<bool>(this.OnHighSpeedModeChanged));
	}

	// Token: 0x0601C1C4 RID: 115140 RVA: 0x00862C8D File Offset: 0x00860E8D
	public override void Cleanup()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnHighSpeedModeChanged, new Action<bool>(this.OnHighSpeedModeChanged));
		base.Cleanup();
	}

	// Token: 0x0601C1C5 RID: 115141 RVA: 0x00862CB1 File Offset: 0x00860EB1
	private void OnHighSpeedModeChanged(bool isHighSpeed)
	{
		base.MaxLoadingCount = (isHighSpeed ? 1L : 4L);
		base.LoadingInterval = (isHighSpeed ? 10L : 0L);
	}

	// Token: 0x0400E300 RID: 58112
	private const long HIGH_SPEED_MAX_LOADING_ENTITY_COUNT = 1L;

	// Token: 0x0400E301 RID: 58113
	private const long HIGH_SPEED_LOADING_INTERVAL = 10L;
}
