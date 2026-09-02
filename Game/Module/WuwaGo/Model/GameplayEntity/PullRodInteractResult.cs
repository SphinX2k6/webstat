using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AEC RID: 19180
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class PullRodInteractResult : IPullRodInteractResult
	{
		// Token: 0x17008561 RID: 34145
		// (get) Token: 0x0603201A RID: 204826 RVA: 0x00C83B46 File Offset: 0x00C81D46
		// (set) Token: 0x0603201B RID: 204827 RVA: 0x00C83B4E File Offset: 0x00C81D4E
		[RequiredMember]
		public EGameplayEntityState PreviousState { get; set; }

		// Token: 0x17008562 RID: 34146
		// (get) Token: 0x0603201C RID: 204828 RVA: 0x00C83B57 File Offset: 0x00C81D57
		// (set) Token: 0x0603201D RID: 204829 RVA: 0x00C83B5F File Offset: 0x00C81D5F
		[RequiredMember]
		public EGameplayEntityState CurrentState { get; set; }

		// Token: 0x17008563 RID: 34147
		// (get) Token: 0x0603201E RID: 204830 RVA: 0x00C83B68 File Offset: 0x00C81D68
		// (set) Token: 0x0603201F RID: 204831 RVA: 0x00C83B70 File Offset: 0x00C81D70
		public IWuWaGoInteractStateAction StateAction { get; set; }

		// Token: 0x06032020 RID: 204832 RVA: 0x00C83B79 File Offset: 0x00C81D79
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PullRodInteractResult()
		{
		}
	}
}
