using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052CC RID: 21196
	public class CfgLazyConditionForTag : CfgLazyConditionBase
	{
		// Token: 0x060362B1 RID: 221873 RVA: 0x00DA4C02 File Offset: 0x00DA2E02
		public CfgLazyConditionForTag()
		{
			this.ConditionType = new ELazyConditionType?(ELazyConditionType.标签检测);
		}

		// Token: 0x060362B2 RID: 221874 RVA: 0x00DA4C16 File Offset: 0x00DA2E16
		[NullableContext(1)]
		public void InitForQta(SQtaCondition_Content ueCondition)
		{
			this.TagToCheck = GameplayTagUtils.ConvertFromUeContainer(ueCondition.Tags);
			this.AnyTag = ueCondition.AnyTag;
			this.Reverse = ueCondition.Reverse;
		}

		// Token: 0x0401F204 RID: 127492
		[Nullable(2)]
		public IEnumerable<int> TagToCheck;

		// Token: 0x0401F205 RID: 127493
		public bool AnyTag;

		// Token: 0x0401F206 RID: 127494
		public bool Reverse;
	}
}
