using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD7 RID: 19927
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseResultViewInfo : ITrapDefenseResultViewInfo
	{
		// Token: 0x17008858 RID: 34904
		// (get) Token: 0x06033914 RID: 211220 RVA: 0x00CE47CF File Offset: 0x00CE29CF
		// (set) Token: 0x06033915 RID: 211221 RVA: 0x00CE47D7 File Offset: 0x00CE29D7
		public TrapDefenseChallengeResultNotify Notify { get; set; }

		// Token: 0x17008859 RID: 34905
		// (get) Token: 0x06033916 RID: 211222 RVA: 0x00CE47E0 File Offset: 0x00CE29E0
		// (set) Token: 0x06033917 RID: 211223 RVA: 0x00CE47E8 File Offset: 0x00CE29E8
		public bool NeedShowViewAnim { get; set; }
	}
}
