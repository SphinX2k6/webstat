using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004AFD RID: 19197
	[RequiredMember]
	public class AttackSession : IAttackSession
	{
		// Token: 0x17008575 RID: 34165
		// (get) Token: 0x0603210E RID: 205070 RVA: 0x00C8704B File Offset: 0x00C8524B
		// (set) Token: 0x0603210F RID: 205071 RVA: 0x00C87053 File Offset: 0x00C85253
		[RequiredMember]
		public UniTask HitOrFinished { get; set; }

		// Token: 0x17008576 RID: 34166
		// (get) Token: 0x06032110 RID: 205072 RVA: 0x00C8705C File Offset: 0x00C8525C
		// (set) Token: 0x06032111 RID: 205073 RVA: 0x00C87064 File Offset: 0x00C85264
		[RequiredMember]
		public UniTask Finished { get; set; }

		// Token: 0x06032112 RID: 205074 RVA: 0x00C8706D File Offset: 0x00C8526D
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public AttackSession()
		{
		}
	}
}
