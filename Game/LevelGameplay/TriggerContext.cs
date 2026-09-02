using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A4C RID: 27212
	public class TriggerContext : GeneralContext
	{
		// Token: 0x0604350A RID: 275722 RVA: 0x0114DA01 File Offset: 0x0114BC01
		public TriggerContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Trigger);
		}

		// Token: 0x0604350B RID: 275723 RVA: 0x0114DA30 File Offset: 0x0114BC30
		[NullableContext(1)]
		public static TriggerContext Create(int triggerEntityId = 0, int otherEntityId = 0, GameCtxType? subType = null, ETriggerEventType? tiggerType = null, bool? isClientTrigger = null)
		{
			TriggerContext triggerContext = GeneralContext.GetObj(EGeneralContextType.Trigger, subType, () => new TriggerContext()) as TriggerContext;
			triggerContext.TriggerEntityId = new int?(triggerEntityId);
			triggerContext.OtherEntityId = new int?(otherEntityId);
			triggerContext.TriggerType = tiggerType.GetValueOrDefault();
			triggerContext.IsClientTrigger = isClientTrigger.GetValueOrDefault();
			return triggerContext;
		}

		// Token: 0x04025899 RID: 153753
		public int? TriggerEntityId = new int?(0);

		// Token: 0x0402589A RID: 153754
		public int? OtherEntityId = new int?(0);

		// Token: 0x0402589B RID: 153755
		public ETriggerEventType TriggerType;

		// Token: 0x0402589C RID: 153756
		public bool IsClientTrigger;
	}
}
