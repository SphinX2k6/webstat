using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x0200472E RID: 18222
	public abstract class ServerStorageEntryBase
	{
		// Token: 0x0602F4F9 RID: 193785 RVA: 0x00B3818F File Offset: 0x00B3638F
		public ServerStorageEntryBase(EClientStorageSystemIdType key)
		{
			this.Key = key;
		}

		// Token: 0x0602F4FA RID: 193786
		[NullableContext(1)]
		public abstract void Serialize(ClientStorageInfo info);

		// Token: 0x0602F4FB RID: 193787
		[NullableContext(2)]
		public abstract ClientStorageInfo Deserialize();

		// Token: 0x0602F4FC RID: 193788 RVA: 0x00B3819E File Offset: 0x00B3639E
		public void MarkDirty()
		{
			ModelBase<ServerStorageModel>.Instance.MarkDirty(this.Key);
		}

		// Token: 0x0401AF1B RID: 110363
		protected EClientStorageSystemIdType Key;
	}
}
