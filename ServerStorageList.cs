using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02003439 RID: 13369
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ServerStorageList : ServerStorageContainerEntry<List<int>>
{
	// Token: 0x0601C056 RID: 114774 RVA: 0x0085AC68 File Offset: 0x00858E68
	public ServerStorageList(EClientStorageSystemIdType key) : base(key)
	{
	}

	// Token: 0x0601C057 RID: 114775 RVA: 0x0085AC71 File Offset: 0x00858E71
	protected override List<int> CreateContainer()
	{
		return new List<int>();
	}

	// Token: 0x0601C058 RID: 114776 RVA: 0x0085AC78 File Offset: 0x00858E78
	public unsafe override void Serialize(ClientStorageInfo info)
	{
		if (info.ListData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ServerStorage;
			ELogAuthor author = ELogAuthor.BB;
			string message = "ServerStorageList Serialize error, Proto_ListData is null";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", this.Key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("info", info);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		List<int> container = base.GetContainer();
		container.Clear();
		container.AddRange(info.ListData.Data);
	}

	// Token: 0x0601C059 RID: 114777 RVA: 0x0085AD0C File Offset: 0x00858F0C
	[NullableContext(2)]
	public override ClientStorageInfo Deserialize()
	{
		List<int> container = base.GetContainer();
		ClientStorageInfo clientStorageInfo = ServerStorageUtil.CreateDefaultStorageInfo((int)this.Key);
		clientStorageInfo.ListData = new ClientStorageListData
		{
			Data = 
			{
				container
			}
		};
		return clientStorageInfo;
	}

	// Token: 0x0601C05A RID: 114778 RVA: 0x0085AD42 File Offset: 0x00858F42
	public void Add(int value)
	{
		if (this.Has(value))
		{
			return;
		}
		base.GetContainer().Add(value);
		base.MarkDirty();
	}

	// Token: 0x0601C05B RID: 114779 RVA: 0x0085AD60 File Offset: 0x00858F60
	public void Remove(int value)
	{
		List<int> container = base.GetContainer();
		int num = container.IndexOf(value);
		if (num == -1)
		{
			return;
		}
		container.RemoveAt(num);
		base.MarkDirty();
	}

	// Token: 0x0601C05C RID: 114780 RVA: 0x0085AD8E File Offset: 0x00858F8E
	public bool Has(int value)
	{
		return base.GetContainer().Contains(value);
	}

	// Token: 0x0601C05D RID: 114781 RVA: 0x0085AD9C File Offset: 0x00858F9C
	public int Size()
	{
		return base.GetContainer().Count;
	}
}
