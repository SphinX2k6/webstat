using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02003459 RID: 13401
[NullableContext(1)]
[Nullable(0)]
public class PlayerSoarMonitorFilter : EntityToLoadFilter
{
	// Token: 0x0601C1BB RID: 115131 RVA: 0x00862B3C File Offset: 0x00860D3C
	private static bool PlayerSoarMonitorCriteria(EntityHandle entityHandle)
	{
		EEntityType entityType = (EEntityType)entityHandle.EntityType;
		return entityType == EEntityType.Player || entityType == EEntityType.SceneItem || entityType == EEntityType.PlayerEntity || entityType == EEntityType.SceneEntity;
	}

	// Token: 0x1700265F RID: 9823
	// (get) Token: 0x0601C1BC RID: 115132 RVA: 0x00862B63 File Offset: 0x00860D63
	public override string DebugName
	{
		get
		{
			return "PlayerSoarMonitorFilter";
		}
	}

	// Token: 0x0601C1BD RID: 115133 RVA: 0x00862B6A File Offset: 0x00860D6A
	public override void Init()
	{
		base.Init();
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.PlayerSoarChanged, new Action<bool>(this.OnPlayerSoarChanged));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.SlowStreamingBySoar, new Action<bool>(this.OnSlowStreamingBySoar));
	}

	// Token: 0x0601C1BE RID: 115134 RVA: 0x00862BAA File Offset: 0x00860DAA
	public override void Cleanup()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.PlayerSoarChanged, new Action<bool>(this.OnPlayerSoarChanged));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.SlowStreamingBySoar, new Action<bool>(this.OnSlowStreamingBySoar));
		base.Cleanup();
	}

	// Token: 0x0601C1BF RID: 115135 RVA: 0x00862BEA File Offset: 0x00860DEA
	private void OnPlayerSoarChanged(bool isPlayerSoar)
	{
		base.MaxLoadingCount = (isPlayerSoar ? 1L : 4L);
		base.LoadingInterval = (isPlayerSoar ? 10L : 0L);
	}

	// Token: 0x0601C1C0 RID: 115136 RVA: 0x00862C0C File Offset: 0x00860E0C
	private void OnSlowStreamingBySoar(bool enableSlowStreaming)
	{
		Func<EntityHandle, bool> criteria;
		if (!enableSlowStreaming)
		{
			if ((criteria = PlayerSoarMonitorFilter.<>O.<1>__AlwaysTrueCriteria) == null)
			{
				criteria = (PlayerSoarMonitorFilter.<>O.<1>__AlwaysTrueCriteria = new Func<EntityHandle, bool>(CriteriaDefine.AlwaysTrueCriteria<EntityHandle>));
			}
		}
		else if ((criteria = PlayerSoarMonitorFilter.<>O.<0>__PlayerSoarMonitorCriteria) == null)
		{
			criteria = (PlayerSoarMonitorFilter.<>O.<0>__PlayerSoarMonitorCriteria = new Func<EntityHandle, bool>(PlayerSoarMonitorFilter.PlayerSoarMonitorCriteria));
		}
		base.Criteria = criteria;
	}

	// Token: 0x0400E2FE RID: 58110
	private const long SOAR_MAX_LOADING_ENTITY_COUNT = 1L;

	// Token: 0x0400E2FF RID: 58111
	private const long SOAR_LOADING_INTERVAL = 10L;

	// Token: 0x02009547 RID: 38215
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x040315F1 RID: 202225
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<EntityHandle, bool> <0>__PlayerSoarMonitorCriteria;

		// Token: 0x040315F2 RID: 202226
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<EntityHandle, bool> <1>__AlwaysTrueCriteria;
	}
}
