using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004707 RID: 18183
	[NullableContext(1)]
	internal interface ICustomPriorityConfigWrapper<[Nullable(0)] T> where T : struct, Enum
	{
		// Token: 0x17008178 RID: 33144
		// (get) Token: 0x0602F456 RID: 193622
		// (set) Token: 0x0602F457 RID: 193623
		bool Enable { get; set; }

		// Token: 0x17008179 RID: 33145
		// (get) Token: 0x0602F458 RID: 193624
		// (set) Token: 0x0602F459 RID: 193625
		[Nullable(0)]
		T Enum { [NullableContext(0)] get; [NullableContext(0)] set; }

		// Token: 0x1700817A RID: 33146
		// (get) Token: 0x0602F45A RID: 193626
		// (set) Token: 0x0602F45B RID: 193627
		int Priority { get; set; }

		// Token: 0x1700817B RID: 33147
		// (get) Token: 0x0602F45C RID: 193628
		// (set) Token: 0x0602F45D RID: 193629
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Func<ICustomPriorityCallbackParam, bool> EnterCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700817C RID: 33148
		// (get) Token: 0x0602F45E RID: 193630
		// (set) Token: 0x0602F45F RID: 193631
		bool? EnterReentrant { get; set; }

		// Token: 0x1700817D RID: 33149
		// (get) Token: 0x0602F460 RID: 193632
		// (set) Token: 0x0602F461 RID: 193633
		bool? ForceEnterCallback { get; set; }

		// Token: 0x1700817E RID: 33150
		// (get) Token: 0x0602F462 RID: 193634
		// (set) Token: 0x0602F463 RID: 193635
		bool? CheckEnterValid { get; set; }

		// Token: 0x1700817F RID: 33151
		// (get) Token: 0x0602F464 RID: 193636
		// (set) Token: 0x0602F465 RID: 193637
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Func<ICustomPriorityCallbackParam, bool> ExitCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008180 RID: 33152
		// (get) Token: 0x0602F466 RID: 193638
		// (set) Token: 0x0602F467 RID: 193639
		bool? ForceExitCallback { get; set; }

		// Token: 0x17008181 RID: 33153
		// (get) Token: 0x0602F468 RID: 193640
		// (set) Token: 0x0602F469 RID: 193641
		bool? CheckExitValid { get; set; }

		// Token: 0x17008182 RID: 33154
		// (get) Token: 0x0602F46A RID: 193642
		// (set) Token: 0x0602F46B RID: 193643
		Func<bool, bool, string, bool> EnterWrapper { get; set; }

		// Token: 0x17008183 RID: 33155
		// (get) Token: 0x0602F46C RID: 193644
		// (set) Token: 0x0602F46D RID: 193645
		Func<bool, string, bool> ExitWrapper { get; set; }
	}
}
