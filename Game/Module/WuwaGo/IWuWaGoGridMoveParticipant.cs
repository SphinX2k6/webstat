using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA1 RID: 19105
	[NullableContext(1)]
	public interface IWuWaGoGridMoveParticipant
	{
		// Token: 0x170084C7 RID: 33991
		// (get) Token: 0x06031D1C RID: 204060
		string ParticipantKey { get; }

		// Token: 0x170084C8 RID: 33992
		// (get) Token: 0x06031D1D RID: 204061
		int? MovedRoleId { get; }

		// Token: 0x170084C9 RID: 33993
		// (get) Token: 0x06031D1E RID: 204062
		// (set) Token: 0x06031D1F RID: 204063
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		Func<IWuWaGoGridRelocationContext, IWuWaGoWorldMoveTarget> CreateWorldMoveTarget { [return: Nullable(new byte[]
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

		// Token: 0x170084CA RID: 33994
		// (get) Token: 0x06031D20 RID: 204064
		// (set) Token: 0x06031D21 RID: 204065
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<IWuWaGoGridRelocationContext> BeforeGridMove { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170084CB RID: 33995
		// (get) Token: 0x06031D22 RID: 204066
		// (set) Token: 0x06031D23 RID: 204067
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<IWuWaGoGridRelocationContext> CommitGridMove { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170084CC RID: 33996
		// (get) Token: 0x06031D24 RID: 204068
		// (set) Token: 0x06031D25 RID: 204069
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Func<IWuWaGoGridRelocationContext, UniTask> AfterGridMove { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
