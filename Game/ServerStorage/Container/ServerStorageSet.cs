using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x02004734 RID: 18228
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ServerStorageSet : ServerStorageContainerEntry<HashSet<int>>
	{
		// Token: 0x0602F51D RID: 193821 RVA: 0x00B38C89 File Offset: 0x00B36E89
		public ServerStorageSet(EClientStorageSystemIdType key) : base(key)
		{
		}

		// Token: 0x0602F51E RID: 193822 RVA: 0x00B38C92 File Offset: 0x00B36E92
		protected override HashSet<int> CreateContainer()
		{
			return new HashSet<int>();
		}

		// Token: 0x0602F51F RID: 193823 RVA: 0x00B38C9C File Offset: 0x00B36E9C
		public unsafe override void Serialize(ClientStorageInfo info)
		{
			if (info.SetData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorageSet Serialize error, Proto_SetData is null";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", this.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("info", info);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			HashSet<int> container = base.GetContainer();
			container.Clear();
			foreach (int item in info.SetData.Data)
			{
				container.Add(item);
			}
		}

		// Token: 0x0602F520 RID: 193824 RVA: 0x00B38D68 File Offset: 0x00B36F68
		[NullableContext(2)]
		public override ClientStorageInfo Deserialize()
		{
			HashSet<int> container = base.GetContainer();
			ClientStorageInfo clientStorageInfo = ServerStorageUtil.CreateDefaultStorageInfo((int)this.Key);
			clientStorageInfo.SetData = new ClientStorageSetData();
			foreach (int item in container)
			{
				clientStorageInfo.SetData.Data.Add(item);
			}
			return clientStorageInfo;
		}

		// Token: 0x0602F521 RID: 193825 RVA: 0x00B38DE0 File Offset: 0x00B36FE0
		public void Add(int value)
		{
			if (this.Has(value))
			{
				return;
			}
			base.GetContainer().Add(value);
			base.MarkDirty();
		}

		// Token: 0x0602F522 RID: 193826 RVA: 0x00B38DFF File Offset: 0x00B36FFF
		public void Remove(int value)
		{
			if (!this.Has(value))
			{
				return;
			}
			base.GetContainer().Remove(value);
			base.MarkDirty();
		}

		// Token: 0x0602F523 RID: 193827 RVA: 0x00B38E1E File Offset: 0x00B3701E
		public bool Has(int value)
		{
			return base.GetContainer().Contains(value);
		}

		// Token: 0x0602F524 RID: 193828 RVA: 0x00B38E2C File Offset: 0x00B3702C
		public int Size()
		{
			return base.GetContainer().Count;
		}

		// Token: 0x0602F525 RID: 193829 RVA: 0x00B38E3C File Offset: 0x00B3703C
		public void Overwrite(HashSet<int> values)
		{
			HashSet<int> container = base.GetContainer();
			container.Clear();
			foreach (int item in values)
			{
				container.Add(item);
			}
			base.MarkDirty();
		}
	}
}
