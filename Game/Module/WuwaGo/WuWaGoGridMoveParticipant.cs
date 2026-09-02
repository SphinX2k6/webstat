using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA2 RID: 19106
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WuWaGoGridMoveParticipant : IWuWaGoGridMoveParticipant
	{
		// Token: 0x170084CD RID: 33997
		// (get) Token: 0x06031D26 RID: 204070 RVA: 0x00C798EE File Offset: 0x00C77AEE
		// (set) Token: 0x06031D27 RID: 204071 RVA: 0x00C798F6 File Offset: 0x00C77AF6
		[RequiredMember]
		public string ParticipantKey { get; set; }

		// Token: 0x170084CE RID: 33998
		// (get) Token: 0x06031D28 RID: 204072 RVA: 0x00C798FF File Offset: 0x00C77AFF
		// (set) Token: 0x06031D29 RID: 204073 RVA: 0x00C79907 File Offset: 0x00C77B07
		public int? MovedRoleId { get; set; }

		// Token: 0x170084CF RID: 33999
		// (get) Token: 0x06031D2A RID: 204074 RVA: 0x00C79910 File Offset: 0x00C77B10
		// (set) Token: 0x06031D2B RID: 204075 RVA: 0x00C79918 File Offset: 0x00C77B18
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		public Func<IWuWaGoGridRelocationContext, IWuWaGoWorldMoveTarget> CreateWorldMoveTarget { [return: Nullable(new byte[]
		{
			2,
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			2
		})] set; }

		// Token: 0x170084D0 RID: 34000
		// (get) Token: 0x06031D2C RID: 204076 RVA: 0x00C79921 File Offset: 0x00C77B21
		// (set) Token: 0x06031D2D RID: 204077 RVA: 0x00C79929 File Offset: 0x00C77B29
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IWuWaGoGridRelocationContext> BeforeGridMove { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170084D1 RID: 34001
		// (get) Token: 0x06031D2E RID: 204078 RVA: 0x00C79932 File Offset: 0x00C77B32
		// (set) Token: 0x06031D2F RID: 204079 RVA: 0x00C7993A File Offset: 0x00C77B3A
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IWuWaGoGridRelocationContext> CommitGridMove { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170084D2 RID: 34002
		// (get) Token: 0x06031D30 RID: 204080 RVA: 0x00C79943 File Offset: 0x00C77B43
		// (set) Token: 0x06031D31 RID: 204081 RVA: 0x00C7994B File Offset: 0x00C77B4B
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<IWuWaGoGridRelocationContext, UniTask> AfterGridMove { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x06031D32 RID: 204082 RVA: 0x00C79954 File Offset: 0x00C77B54
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WuWaGoGridMoveParticipant()
		{
		}
	}
}
