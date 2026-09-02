using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x0200472D RID: 18221
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ServerStorageContainerEntry<[Nullable(2)] T> : ServerStorageEntryBase
	{
		// Token: 0x0602F4F6 RID: 193782
		protected abstract T CreateContainer();

		// Token: 0x0602F4F7 RID: 193783 RVA: 0x00B38165 File Offset: 0x00B36365
		public T GetContainer()
		{
			if (this.Data == null)
			{
				this.Data = this.CreateContainer();
			}
			return this.Data;
		}

		// Token: 0x0602F4F8 RID: 193784 RVA: 0x00B38186 File Offset: 0x00B36386
		public ServerStorageContainerEntry(EClientStorageSystemIdType key) : base(key)
		{
		}

		// Token: 0x0401AF1A RID: 110362
		[Nullable(2)]
		private T Data;
	}
}
