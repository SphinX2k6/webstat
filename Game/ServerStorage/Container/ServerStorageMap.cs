using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x02004730 RID: 18224
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ServerStorageMap : ServerStorageContainerEntry<Dictionary<int, int>>
	{
		// Token: 0x0602F500 RID: 193792 RVA: 0x00B382F5 File Offset: 0x00B364F5
		public ServerStorageMap(EClientStorageSystemIdType key) : base(key)
		{
		}

		// Token: 0x0602F501 RID: 193793 RVA: 0x00B382FE File Offset: 0x00B364FE
		protected override Dictionary<int, int> CreateContainer()
		{
			return new Dictionary<int, int>();
		}

		// Token: 0x0602F502 RID: 193794 RVA: 0x00B38308 File Offset: 0x00B36508
		public unsafe override void Serialize(ClientStorageInfo info)
		{
			if (info.MapData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorageMapData Serialize error, Proto_MapData is null";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", this.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("info", info);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			Dictionary<int, int> container = base.GetContainer();
			container.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in info.MapData.Data)
			{
				int key = keyValuePair.Key;
				container[key] = keyValuePair.Value;
			}
		}

		// Token: 0x0602F503 RID: 193795 RVA: 0x00B383E4 File Offset: 0x00B365E4
		[NullableContext(2)]
		public override ClientStorageInfo Deserialize()
		{
			Dictionary<int, int> container = base.GetContainer();
			ClientStorageInfo clientStorageInfo = ServerStorageUtil.CreateDefaultStorageInfo((int)this.Key);
			clientStorageInfo.MapData = new ClientStorageMapData();
			foreach (KeyValuePair<int, int> keyValuePair in container)
			{
				clientStorageInfo.MapData.Data.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return clientStorageInfo;
		}

		// Token: 0x0602F504 RID: 193796 RVA: 0x00B38468 File Offset: 0x00B36668
		public void Set(int key, int value)
		{
			Dictionary<int, int> container = base.GetContainer();
			int num;
			if (container.TryGetValue(key, out num) && num == value)
			{
				return;
			}
			container[key] = value;
			base.MarkDirty();
		}

		// Token: 0x0602F505 RID: 193797 RVA: 0x00B3849A File Offset: 0x00B3669A
		public void Delete(int key)
		{
			if (!base.GetContainer().Remove(key))
			{
				return;
			}
			base.MarkDirty();
		}

		// Token: 0x0602F506 RID: 193798 RVA: 0x00B384B4 File Offset: 0x00B366B4
		public int? Get(int key)
		{
			int value;
			if (base.GetContainer().TryGetValue(key, out value))
			{
				return new int?(value);
			}
			return null;
		}

		// Token: 0x0602F507 RID: 193799 RVA: 0x00B384E1 File Offset: 0x00B366E1
		public bool Has(int key)
		{
			return base.GetContainer().ContainsKey(key);
		}

		// Token: 0x0602F508 RID: 193800 RVA: 0x00B384EF File Offset: 0x00B366EF
		public int Size()
		{
			return base.GetContainer().Count;
		}

		// Token: 0x0602F509 RID: 193801 RVA: 0x00B384FC File Offset: 0x00B366FC
		public void Overwrite(Dictionary<int, int> values)
		{
			Dictionary<int, int> container = base.GetContainer();
			container.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in values)
			{
				container[keyValuePair.Key] = keyValuePair.Value;
			}
			base.MarkDirty();
		}
	}
}
