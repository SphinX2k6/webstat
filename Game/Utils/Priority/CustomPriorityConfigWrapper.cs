using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004708 RID: 18184
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	internal class CustomPriorityConfigWrapper<[Nullable(0)] T> : ICustomPriorityConfigWrapper<T> where T : struct, Enum
	{
		// Token: 0x17008184 RID: 33156
		// (get) Token: 0x0602F46E RID: 193646 RVA: 0x00B350E7 File Offset: 0x00B332E7
		// (set) Token: 0x0602F46F RID: 193647 RVA: 0x00B350EF File Offset: 0x00B332EF
		public bool Enable { get; set; }

		// Token: 0x17008185 RID: 33157
		// (get) Token: 0x0602F470 RID: 193648 RVA: 0x00B350F8 File Offset: 0x00B332F8
		// (set) Token: 0x0602F471 RID: 193649 RVA: 0x00B35100 File Offset: 0x00B33300
		[Nullable(0)]
		[RequiredMember]
		public T Enum { [NullableContext(0)] get; [NullableContext(0)] set; }

		// Token: 0x17008186 RID: 33158
		// (get) Token: 0x0602F472 RID: 193650 RVA: 0x00B35109 File Offset: 0x00B33309
		// (set) Token: 0x0602F473 RID: 193651 RVA: 0x00B35111 File Offset: 0x00B33311
		[RequiredMember]
		public int Priority { get; set; }

		// Token: 0x17008187 RID: 33159
		// (get) Token: 0x0602F474 RID: 193652 RVA: 0x00B3511A File Offset: 0x00B3331A
		// (set) Token: 0x0602F475 RID: 193653 RVA: 0x00B35122 File Offset: 0x00B33322
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

		// Token: 0x17008188 RID: 33160
		// (get) Token: 0x0602F476 RID: 193654 RVA: 0x00B3512B File Offset: 0x00B3332B
		// (set) Token: 0x0602F477 RID: 193655 RVA: 0x00B35133 File Offset: 0x00B33333
		public bool? EnterReentrant { get; set; }

		// Token: 0x17008189 RID: 33161
		// (get) Token: 0x0602F478 RID: 193656 RVA: 0x00B3513C File Offset: 0x00B3333C
		// (set) Token: 0x0602F479 RID: 193657 RVA: 0x00B35144 File Offset: 0x00B33344
		public bool? ForceEnterCallback { get; set; }

		// Token: 0x1700818A RID: 33162
		// (get) Token: 0x0602F47A RID: 193658 RVA: 0x00B3514D File Offset: 0x00B3334D
		// (set) Token: 0x0602F47B RID: 193659 RVA: 0x00B35155 File Offset: 0x00B33355
		public bool? CheckEnterValid { get; set; }

		// Token: 0x1700818B RID: 33163
		// (get) Token: 0x0602F47C RID: 193660 RVA: 0x00B3515E File Offset: 0x00B3335E
		// (set) Token: 0x0602F47D RID: 193661 RVA: 0x00B35166 File Offset: 0x00B33366
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

		// Token: 0x1700818C RID: 33164
		// (get) Token: 0x0602F47E RID: 193662 RVA: 0x00B3516F File Offset: 0x00B3336F
		// (set) Token: 0x0602F47F RID: 193663 RVA: 0x00B35177 File Offset: 0x00B33377
		public bool? ForceExitCallback { get; set; }

		// Token: 0x1700818D RID: 33165
		// (get) Token: 0x0602F480 RID: 193664 RVA: 0x00B35180 File Offset: 0x00B33380
		// (set) Token: 0x0602F481 RID: 193665 RVA: 0x00B35188 File Offset: 0x00B33388
		public bool? CheckExitValid { get; set; }

		// Token: 0x1700818E RID: 33166
		// (get) Token: 0x0602F482 RID: 193666 RVA: 0x00B35191 File Offset: 0x00B33391
		// (set) Token: 0x0602F483 RID: 193667 RVA: 0x00B35199 File Offset: 0x00B33399
		[RequiredMember]
		public Func<bool, bool, string, bool> EnterWrapper { get; set; }

		// Token: 0x1700818F RID: 33167
		// (get) Token: 0x0602F484 RID: 193668 RVA: 0x00B351A2 File Offset: 0x00B333A2
		// (set) Token: 0x0602F485 RID: 193669 RVA: 0x00B351AA File Offset: 0x00B333AA
		[RequiredMember]
		public Func<bool, string, bool> ExitWrapper { get; set; }

		// Token: 0x0602F486 RID: 193670 RVA: 0x00B351B3 File Offset: 0x00B333B3
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CustomPriorityConfigWrapper()
		{
		}
	}
}
