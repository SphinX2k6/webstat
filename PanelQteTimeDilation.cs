using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x02002359 RID: 9049
public class PanelQteTimeDilation
{
	// Token: 0x060114A9 RID: 70825 RVA: 0x004C1C8D File Offset: 0x004BFE8D
	public void Init()
	{
		this.WorldTimeDilation = 1f;
		this.EntityTimeDilation = 1;
	}

	// Token: 0x060114AA RID: 70826 RVA: 0x004C1CA6 File Offset: 0x004BFEA6
	public void Clear()
	{
	}

	// Token: 0x060114AB RID: 70827 RVA: 0x004C1CA8 File Offset: 0x004BFEA8
	[NullableContext(1)]
	public void Start(PanelQteContext context)
	{
		this.WorldTimeDilation = context.Config.WorldTimeDilation;
		if (this.WorldTimeDilation >= 1f || this.WorldTimeDilation < 0f)
		{
			this.WorldTimeDilation = 1f;
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.EntityTimeDilation = this.WorldTimeDilation;
			this.WorldTimeDilation = 1f;
			this.EntityHandle = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.IsInit)
			{
				PawnTimeScaleComponent component = this.EntityHandle.Entity.GetComponent<PawnTimeScaleComponent>();
				if (component != null)
				{
					this.TimeScaleId = component.SetTimeScale(100, this.EntityTimeDilation, null, 20f, ETimeScaleSourceType.PanelQte, false, false);
					return;
				}
			}
		}
		else
		{
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.UpdatePanelQteWorldTimeDilation, this.WorldTimeDilation);
		}
	}

	// Token: 0x060114AC RID: 70828 RVA: 0x004C1D88 File Offset: 0x004BFF88
	public void Stop()
	{
		if (this.WorldTimeDilation != 1f)
		{
			this.WorldTimeDilation = 1f;
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.UpdatePanelQteWorldTimeDilation, this.WorldTimeDilation);
		}
		if (this.EntityTimeDilation != 1)
		{
			this.EntityTimeDilation = 1;
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle != null && entityHandle.IsInit && this.TimeScaleId > 0)
			{
				PawnTimeScaleComponent component = this.EntityHandle.Entity.GetComponent<PawnTimeScaleComponent>();
				if (component != null)
				{
					component.RemoveTimeScale(this.TimeScaleId);
				}
			}
			this.EntityHandle = null;
			this.TimeScaleId = 0;
		}
	}

	// Token: 0x060114AD RID: 70829 RVA: 0x004C1E2D File Offset: 0x004C002D
	public Number GetWorldTimeDilation()
	{
		return this.WorldTimeDilation;
	}

	// Token: 0x060114AE RID: 70830 RVA: 0x004C1E3A File Offset: 0x004C003A
	public Number GetEntityTimeDilation()
	{
		return this.EntityTimeDilation;
	}

	// Token: 0x040087DB RID: 34779
	private float WorldTimeDilation;

	// Token: 0x040087DC RID: 34780
	private Number EntityTimeDilation = 0;

	// Token: 0x040087DD RID: 34781
	[Nullable(2)]
	private EntityHandle EntityHandle;

	// Token: 0x040087DE RID: 34782
	private int TimeScaleId;

	// Token: 0x040087DF RID: 34783
	private const int MAX_TIME_SCALE_TIME = 20;

	// Token: 0x040087E0 RID: 34784
	private const int TIME_SCALE_PRIORITY = 100;
}
