using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052CE RID: 21198
	public class CfgLazyConditionForEntityEvent : CfgLazyConditionBase
	{
		// Token: 0x060362B5 RID: 221877 RVA: 0x00DA4C8D File Offset: 0x00DA2E8D
		public CfgLazyConditionForEntityEvent()
		{
			this.ConditionType = new ELazyConditionType?(ELazyConditionType.事件变化);
		}

		// Token: 0x060362B6 RID: 221878 RVA: 0x00DA4CA8 File Offset: 0x00DA2EA8
		[NullableContext(1)]
		public void InitForQta(SQtaCondition_Content ueCondition)
		{
			this.EventName = (ELazyConditionEventName)ueCondition.EventName;
		}

		// Token: 0x0401F20A RID: 127498
		public ELazyConditionEventName EventName = ELazyConditionEventName.当前技能结束;
	}
}
