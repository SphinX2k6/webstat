using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.OperationRestrict;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F9C RID: 28572
	public class LevelFlowOperationRestrictionAction : LevelFlowActionBase
	{
		// Token: 0x060451E9 RID: 283113 RVA: 0x01208948 File Offset: 0x01206B48
		[NullableContext(1)]
		public LevelFlowOperationRestrictionAction Init([Nullable(2)] SetPlayerOperationRestriction param)
		{
			this.RestrictionParam = param;
			return this;
		}

		// Token: 0x060451EA RID: 283114 RVA: 0x01208954 File Offset: 0x01206B54
		protected override void OnExecute()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, "Set Player Operation Action");
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "关卡事件-设置玩家操作限制";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置param:", this.RestrictionParam);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<OperationRestrictUtils>.Instance.SetOperationRestrictByOption(this.RestrictionParam);
			base.FinishExecute(true);
		}

		// Token: 0x04026908 RID: 157960
		[Nullable(2)]
		private SetPlayerOperationRestriction RestrictionParam;
	}
}
