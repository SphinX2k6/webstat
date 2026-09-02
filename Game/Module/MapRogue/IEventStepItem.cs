using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005957 RID: 22871
	[NullableContext(2)]
	public interface IEventStepItem
	{
		// Token: 0x1700945E RID: 37982
		// (get) Token: 0x06039FA0 RID: 237472
		int StepId { get; }

		// Token: 0x1700945F RID: 37983
		// (get) Token: 0x06039FA1 RID: 237473
		EStepType StepType { get; }

		// Token: 0x17009460 RID: 37984
		// (get) Token: 0x06039FA2 RID: 237474
		// (set) Token: 0x06039FA3 RID: 237475
		Action<int, EStepType> CanInteractCallback { get; set; }

		// Token: 0x17009461 RID: 37985
		// (get) Token: 0x06039FA4 RID: 237476
		// (set) Token: 0x06039FA5 RID: 237477
		Action<int, int> ExecuteStep { get; set; }

		// Token: 0x06039FA6 RID: 237478
		void MaskClick();

		// Token: 0x06039FA7 RID: 237479
		UUIItem GetOriginalItem();
	}
}
