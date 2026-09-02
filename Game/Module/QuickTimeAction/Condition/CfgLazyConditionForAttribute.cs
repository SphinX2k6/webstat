using System;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.Module.QuickTimeAction.Condition
{
	// Token: 0x020052CB RID: 21195
	public class CfgLazyConditionForAttribute : CfgLazyConditionBase
	{
		// Token: 0x060362B0 RID: 221872 RVA: 0x00DA4BEE File Offset: 0x00DA2DEE
		public CfgLazyConditionForAttribute()
		{
			this.ConditionType = new ELazyConditionType?(ELazyConditionType.属性检测);
		}

		// Token: 0x0401F1FC RID: 127484
		public ESkillBehaviorComparisonLogic ComparisonLogic;

		// Token: 0x0401F1FD RID: 127485
		public int Value;

		// Token: 0x0401F1FE RID: 127486
		public int RangeL;

		// Token: 0x0401F1FF RID: 127487
		public int RangeR;

		// Token: 0x0401F200 RID: 127488
		public int AttributeId1;

		// Token: 0x0401F201 RID: 127489
		public int AttributeId2;

		// Token: 0x0401F202 RID: 127490
		public int AttributeRate;

		// Token: 0x0401F203 RID: 127491
		public bool Reverse;
	}
}
