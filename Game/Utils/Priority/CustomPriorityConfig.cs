using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004706 RID: 18182
	public class CustomPriorityConfig<T> : ICustomPriorityConfig<T> where T : struct, Enum
	{
		// Token: 0x1700816E RID: 33134
		// (get) Token: 0x0602F441 RID: 193601 RVA: 0x00B35035 File Offset: 0x00B33235
		// (set) Token: 0x0602F442 RID: 193602 RVA: 0x00B3503D File Offset: 0x00B3323D
		public bool Enable { get; set; }

		// Token: 0x1700816F RID: 33135
		// (get) Token: 0x0602F443 RID: 193603 RVA: 0x00B35046 File Offset: 0x00B33246
		// (set) Token: 0x0602F444 RID: 193604 RVA: 0x00B3504E File Offset: 0x00B3324E
		public T? Enum { get; set; }

		// Token: 0x17008170 RID: 33136
		// (get) Token: 0x0602F445 RID: 193605 RVA: 0x00B35057 File Offset: 0x00B33257
		// (set) Token: 0x0602F446 RID: 193606 RVA: 0x00B3505F File Offset: 0x00B3325F
		public int? Priority { get; set; }

		// Token: 0x17008171 RID: 33137
		// (get) Token: 0x0602F447 RID: 193607 RVA: 0x00B35068 File Offset: 0x00B33268
		// (set) Token: 0x0602F448 RID: 193608 RVA: 0x00B35070 File Offset: 0x00B33270
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<ICustomPriorityCallbackParam, bool> EnterCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008172 RID: 33138
		// (get) Token: 0x0602F449 RID: 193609 RVA: 0x00B35079 File Offset: 0x00B33279
		// (set) Token: 0x0602F44A RID: 193610 RVA: 0x00B35081 File Offset: 0x00B33281
		public bool? EnterReentrant { get; set; }

		// Token: 0x17008173 RID: 33139
		// (get) Token: 0x0602F44B RID: 193611 RVA: 0x00B3508A File Offset: 0x00B3328A
		// (set) Token: 0x0602F44C RID: 193612 RVA: 0x00B35092 File Offset: 0x00B33292
		public bool? ForceEnterCallback { get; set; }

		// Token: 0x17008174 RID: 33140
		// (get) Token: 0x0602F44D RID: 193613 RVA: 0x00B3509B File Offset: 0x00B3329B
		// (set) Token: 0x0602F44E RID: 193614 RVA: 0x00B350A3 File Offset: 0x00B332A3
		public bool? CheckEnterValid { get; set; }

		// Token: 0x17008175 RID: 33141
		// (get) Token: 0x0602F44F RID: 193615 RVA: 0x00B350AC File Offset: 0x00B332AC
		// (set) Token: 0x0602F450 RID: 193616 RVA: 0x00B350B4 File Offset: 0x00B332B4
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<ICustomPriorityCallbackParam, bool> ExitCallback { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008176 RID: 33142
		// (get) Token: 0x0602F451 RID: 193617 RVA: 0x00B350BD File Offset: 0x00B332BD
		// (set) Token: 0x0602F452 RID: 193618 RVA: 0x00B350C5 File Offset: 0x00B332C5
		public bool? ForceExitCallback { get; set; }

		// Token: 0x17008177 RID: 33143
		// (get) Token: 0x0602F453 RID: 193619 RVA: 0x00B350CE File Offset: 0x00B332CE
		// (set) Token: 0x0602F454 RID: 193620 RVA: 0x00B350D6 File Offset: 0x00B332D6
		public bool? CheckExitValid { get; set; }
	}
}
