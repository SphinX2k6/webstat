using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052CD RID: 21197
	[NullableContext(1)]
	[Nullable(0)]
	public class CfgLazyConditionForInput : CfgLazyConditionBase
	{
		// Token: 0x060362B3 RID: 221875 RVA: 0x00DA4C41 File Offset: 0x00DA2E41
		public CfgLazyConditionForInput()
		{
			this.ConditionType = new ELazyConditionType?(ELazyConditionType.输入检测);
		}

		// Token: 0x060362B4 RID: 221876 RVA: 0x00DA4C67 File Offset: 0x00DA2E67
		public void InitForQta(string actionName, SQtaCondition_Content ueCondition)
		{
			this.ActionName = actionName;
			this.KeyMatchType = (ELazyConditionKeyMatchType)ueCondition.InputMatchType;
			this.Reverse = ueCondition.Reverse;
		}

		// Token: 0x0401F207 RID: 127495
		public string ActionName = string.Empty;

		// Token: 0x0401F208 RID: 127496
		public ELazyConditionKeyMatchType KeyMatchType = ELazyConditionKeyMatchType.没按键;

		// Token: 0x0401F209 RID: 127497
		public bool Reverse;
	}
}
