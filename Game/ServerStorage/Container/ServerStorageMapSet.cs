using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x02004732 RID: 18226
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class ServerStorageMapSet : ServerStorageContainerEntry<Dictionary<int, HashSet<int>>>
	{
		// Token: 0x0602F512 RID: 193810 RVA: 0x00B388A1 File Offset: 0x00B36AA1
		public ServerStorageMapSet(EClientStorageSystemIdType key) : base(key)
		{
		}

		// Token: 0x0602F513 RID: 193811 RVA: 0x00B388AA File Offset: 0x00B36AAA
		protected override Dictionary<int, HashSet<int>> CreateContainer()
		{
			return new Dictionary<int, HashSet<int>>();
		}

		// Token: 0x0602F514 RID: 193812 RVA: 0x00B388B4 File Offset: 0x00B36AB4
		public unsafe override void Serialize(ClientStorageInfo info)
		{
			if (info.MapListData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorageMapSet Serialize error, Proto_MapListData is null";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", this.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("info", info);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			Dictionary<int, HashSet<int>> container = base.GetContainer();
			container.Clear();
			foreach (KeyValuePair<int, ClientStorageListData> keyValuePair in info.MapListData.Data)
			{
				ClientStorageListData value = keyValuePair.Value;
				if (((value != null) ? value.Data : null) != null)
				{
					int key = keyValuePair.Key;
					container[key] = new HashSet<int>(keyValuePair.Value.Data);
				}
			}
		}

		// Token: 0x0602F515 RID: 193813 RVA: 0x00B389AC File Offset: 0x00B36BAC
		[NullableContext(2)]
		public override ClientStorageInfo Deserialize()
		{
			Dictionary<int, HashSet<int>> container = base.GetContainer();
			ClientStorageInfo clientStorageInfo = ServerStorageUtil.CreateDefaultStorageInfo((int)this.Key);
			clientStorageInfo.MapListData = new ClientStorageMapListData();
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in container)
			{
				int key = keyValuePair.Key;
				ClientStorageListData clientStorageListData = new ClientStorageListData();
				clientStorageInfo.MapListData.Data[key] = clientStorageListData;
				foreach (int item in keyValuePair.Value)
				{
					clientStorageListData.Data.Add(item);
				}
			}
			return clientStorageInfo;
		}

		// Token: 0x0602F516 RID: 193814 RVA: 0x00B38A80 File Offset: 0x00B36C80
		public void Add(int key, int value1)
		{
			Dictionary<int, HashSet<int>> container = base.GetContainer();
			HashSet<int> hashSet;
			if (!container.TryGetValue(key, out hashSet))
			{
				container[key] = new HashSet<int>
				{
					value1
				};
				base.MarkDirty();
				return;
			}
			if (hashSet.Contains(value1))
			{
				return;
			}
			hashSet.Add(value1);
			base.MarkDirty();
		}

		// Token: 0x0602F517 RID: 193815 RVA: 0x00B38AD4 File Offset: 0x00B36CD4
		public void Remove(int key, int value1)
		{
			Dictionary<int, HashSet<int>> container = base.GetContainer();
			HashSet<int> hashSet;
			if (!container.TryGetValue(key, out hashSet))
			{
				return;
			}
			hashSet.Remove(value1);
			if (hashSet.Count == 0)
			{
				container.Remove(key);
			}
			base.MarkDirty();
		}

		// Token: 0x0602F518 RID: 193816 RVA: 0x00B38B14 File Offset: 0x00B36D14
		public bool Has(int key, int value1)
		{
			HashSet<int> hashSet;
			return base.GetContainer().TryGetValue(key, out hashSet) && hashSet.Contains(value1);
		}

		// Token: 0x0602F519 RID: 193817 RVA: 0x00B38B3A File Offset: 0x00B36D3A
		public int Size()
		{
			return base.GetContainer().Count;
		}
	}
}
