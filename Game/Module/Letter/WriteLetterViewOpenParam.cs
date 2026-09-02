using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Letter
{
	// Token: 0x02005A1C RID: 23068
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WriteLetterViewOpenParam : IWriteLetterViewOpenParam
	{
		// Token: 0x170094D2 RID: 38098
		// (get) Token: 0x0603A66F RID: 239215 RVA: 0x00ECF109 File Offset: 0x00ECD309
		// (set) Token: 0x0603A670 RID: 239216 RVA: 0x00ECF111 File Offset: 0x00ECD311
		[RequiredMember]
		public string FlowListName { get; set; }

		// Token: 0x170094D3 RID: 38099
		// (get) Token: 0x0603A671 RID: 239217 RVA: 0x00ECF11A File Offset: 0x00ECD31A
		// (set) Token: 0x0603A672 RID: 239218 RVA: 0x00ECF122 File Offset: 0x00ECD322
		[RequiredMember]
		public int FlowId { get; set; }

		// Token: 0x170094D4 RID: 38100
		// (get) Token: 0x0603A673 RID: 239219 RVA: 0x00ECF12B File Offset: 0x00ECD32B
		// (set) Token: 0x0603A674 RID: 239220 RVA: 0x00ECF133 File Offset: 0x00ECD333
		[RequiredMember]
		public int StateId { get; set; }

		// Token: 0x170094D5 RID: 38101
		// (get) Token: 0x0603A675 RID: 239221 RVA: 0x00ECF13C File Offset: 0x00ECD33C
		// (set) Token: 0x0603A676 RID: 239222 RVA: 0x00ECF144 File Offset: 0x00ECD344
		[RequiredMember]
		public ELetterStyle LetterStyle { get; set; }

		// Token: 0x170094D6 RID: 38102
		// (get) Token: 0x0603A677 RID: 239223 RVA: 0x00ECF14D File Offset: 0x00ECD34D
		// (set) Token: 0x0603A678 RID: 239224 RVA: 0x00ECF155 File Offset: 0x00ECD355
		[Nullable(2)]
		public string GameplayId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170094D7 RID: 38103
		// (get) Token: 0x0603A679 RID: 239225 RVA: 0x00ECF15E File Offset: 0x00ECD35E
		// (set) Token: 0x0603A67A RID: 239226 RVA: 0x00ECF166 File Offset: 0x00ECD366
		public int? LetterId { get; set; }

		// Token: 0x0603A67B RID: 239227 RVA: 0x00ECF16F File Offset: 0x00ECD36F
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WriteLetterViewOpenParam()
		{
		}
	}
}
