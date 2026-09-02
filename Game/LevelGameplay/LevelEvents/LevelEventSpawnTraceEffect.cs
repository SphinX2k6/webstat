using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C09 RID: 27657
	public class LevelEventSpawnTraceEffect : LevelEventBase
	{
		// Token: 0x06044161 RID: 278881 RVA: 0x011AD475 File Offset: 0x011AB675
		public LevelEventSpawnTraceEffect(int id) : base(id)
		{
		}

		// Token: 0x06044162 RID: 278882 RVA: 0x011AD480 File Offset: 0x011AB680
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.ZS, "参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (context.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree)
			{
				GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext != null && generalLogicTreeContext.BtType == BtType.Quest)
				{
					this.QuestId = generalLogicTreeContext.TreeConfigId;
					return;
				}
			}
			Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.YSQ, "该事件仅用于任务行为树内配置", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06044163 RID: 278883 RVA: 0x011AD4F7 File Offset: 0x011AB6F7
		protected override void OnReset()
		{
			ControllerBase<QuestNewController>.Instance.ClearQuestTraceEffect(this.QuestId);
		}

		// Token: 0x0402608F RID: 155791
		private int QuestId;
	}
}
