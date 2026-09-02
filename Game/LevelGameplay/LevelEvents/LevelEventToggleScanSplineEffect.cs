using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C0D RID: 27661
	public class LevelEventToggleScanSplineEffect : LevelEventBase
	{
		// Token: 0x06044172 RID: 278898 RVA: 0x011ADD76 File Offset: 0x011ABF76
		public LevelEventToggleScanSplineEffect(int id) : base(id)
		{
		}

		// Token: 0x06044173 RID: 278899 RVA: 0x011ADD80 File Offset: 0x011ABF80
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CH, "参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (context.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree)
			{
				GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext != null && generalLogicTreeContext.BtType == BtType.Quest)
				{
					goto IL_7E;
				}
				GeneralLogicTreeContext generalLogicTreeContext2 = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext2 != null && generalLogicTreeContext2.BtType == BtType.Recall)
				{
					goto IL_7E;
				}
			}
			Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CH, "该事件仅用于任务/回顾任务行为树内配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			IL_7E:
			GeneralLogicTreeContext generalLogicTreeContext3 = context as GeneralLogicTreeContext;
			ToggleScanSplineEffect toggleScanSplineEffect = inParams as ToggleScanSplineEffect;
			ETraceSplineOptionType type = toggleScanSplineEffect.Type;
			if (type == ETraceSplineOptionType.Open)
			{
				IOpenTraceSpline openTraceSpline = toggleScanSplineEffect as IOpenTraceSpline;
				ControllerBase<QuestNewController>.Instance.AddQuestTraceEffect(generalLogicTreeContext3.TreeConfigId, openTraceSpline.Duration, openTraceSpline.SplineEntityId);
				return;
			}
			if (type != ETraceSplineOptionType.Close)
			{
				return;
			}
			ICloseTraceSpline closeTraceSpline = toggleScanSplineEffect as ICloseTraceSpline;
			ControllerBase<QuestNewController>.Instance.RemoveQuestTraceEffect(generalLogicTreeContext3.TreeConfigId, closeTraceSpline.SplineEntityId);
		}
	}
}
