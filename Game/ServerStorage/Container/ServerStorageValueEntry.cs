using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x02004736 RID: 18230
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class ServerStorageValueEntry<T> : ServerStorageEntryBase
	{
		// Token: 0x0602F529 RID: 193833 RVA: 0x00B38FA1 File Offset: 0x00B371A1
		[NullableContext(1)]
		public void Set(T value)
		{
			if (this.Data != null && this.Data.Equals(value))
			{
				return;
			}
			this.Data = value;
			base.MarkDirty();
		}

		// Token: 0x0602F52A RID: 193834 RVA: 0x00B38FD7 File Offset: 0x00B371D7
		public T Get()
		{
			return this.Data;
		}

		// Token: 0x0602F52B RID: 193835 RVA: 0x00B38FDF File Offset: 0x00B371DF
		public ServerStorageValueEntry(EClientStorageSystemIdType key) : base(key)
		{
		}

		// Token: 0x0401AF1C RID: 110364
		protected T Data;
	}
}
