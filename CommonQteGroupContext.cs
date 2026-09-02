using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;

// Token: 0x02002612 RID: 9746
[NullableContext(2)]
[Nullable(0)]
public class CommonQteGroupContext : CommonQteContextBase
{
	// Token: 0x0601320B RID: 78347 RVA: 0x0054E131 File Offset: 0x0054C331
	public CommonQteGroupContext()
	{
		this.Type = new ECommonQteContextType?(ECommonQteContextType.QteGroup);
	}

	// Token: 0x0601320C RID: 78348 RVA: 0x0054E148 File Offset: 0x0054C348
	protected override void OnClear()
	{
		if (this.ContextMap != null)
		{
			foreach (CommonQteContextBase commonQteContextBase in this.ContextMap.Values)
			{
				commonQteContextBase.Clear();
			}
			this.ContextMap = null;
		}
		this.MainQteContext = null;
	}

	// Token: 0x0601320D RID: 78349 RVA: 0x0054E1B4 File Offset: 0x0054C3B4
	public override SCommonQte GetConfig()
	{
		if (this.MainQteContext != null)
		{
			return this.MainQteContext.Config;
		}
		return this.Config;
	}

	// Token: 0x0601320E RID: 78350 RVA: 0x0054E1D0 File Offset: 0x0054C3D0
	protected override void OnQteSuccess()
	{
		if (this.ContextMap != null)
		{
			foreach (CommonQteContextBase commonQteContextBase in this.ContextMap.Values)
			{
				commonQteContextBase.QteSuccess();
			}
		}
	}

	// Token: 0x0601320F RID: 78351 RVA: 0x0054E230 File Offset: 0x0054C430
	protected override void OnQteFail()
	{
		if (this.ContextMap != null)
		{
			foreach (CommonQteContextBase commonQteContextBase in this.ContextMap.Values)
			{
				commonQteContextBase.QteFail();
			}
		}
	}

	// Token: 0x06013210 RID: 78352 RVA: 0x0054E290 File Offset: 0x0054C490
	public override bool CheckQteConditionMatch()
	{
		if (this.ContextMap == null)
		{
			return true;
		}
		bool result = true;
		SCommonQteGroup groupConfig = this.GroupConfig;
		float toleranceTime = ((groupConfig != null) ? groupConfig.ToleranceTime : 0f) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		foreach (CommonQteContextBase commonQteContextBase in this.ContextMap.Values)
		{
			if (!commonQteContextBase.CheckQteConditionMatch() || !commonQteContextBase.CheckQteSuccessInTime(toleranceTime))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	// Token: 0x06013211 RID: 78353 RVA: 0x0054E328 File Offset: 0x0054C528
	public override bool CheckQteConditionAndDoSuccess()
	{
		if (this.CheckQteConditionMatch())
		{
			base.QteSuccess();
			return true;
		}
		return false;
	}

	// Token: 0x06013212 RID: 78354 RVA: 0x0054E33B File Offset: 0x0054C53B
	[NullableContext(1)]
	public void AddContext(int qteId, CommonQteContextBase context, bool isMainQte)
	{
		if (this.ContextMap == null)
		{
			this.ContextMap = new Dictionary<int, CommonQteContextBase>();
		}
		this.ContextMap[qteId] = context;
		if (isMainQte)
		{
			this.MainQteContext = context;
		}
	}

	// Token: 0x06013213 RID: 78355 RVA: 0x0054E367 File Offset: 0x0054C567
	public void OnContextFail(CommonQteContextBase context)
	{
		if (base.IsPending() && context != null)
		{
			Dictionary<int, CommonQteContextBase> contextMap = this.ContextMap;
			if (contextMap != null && contextMap.ContainsKey(context.QteId))
			{
				base.QteFail();
			}
		}
	}

	// Token: 0x04009548 RID: 38216
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, CommonQteContextBase> ContextMap;

	// Token: 0x04009549 RID: 38217
	public CommonQteContextBase MainQteContext;
}
