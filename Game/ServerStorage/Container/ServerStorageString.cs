using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.ServerStorage.Container
{
	// Token: 0x02004735 RID: 18229
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ServerStorageString : ServerStorageValueEntry<string>
	{
		// Token: 0x0602F526 RID: 193830 RVA: 0x00B38EA0 File Offset: 0x00B370A0
		public ServerStorageString(EClientStorageSystemIdType key) : base(key)
		{
		}

		// Token: 0x0602F527 RID: 193831 RVA: 0x00B38EAC File Offset: 0x00B370AC
		public unsafe override void Serialize(ClientStorageInfo info)
		{
			if (info.StringData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorageString Serialize error, Proto_StringData is null";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", this.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("info", info);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.Data = info.StringData.Data;
		}

		// Token: 0x0602F528 RID: 193832 RVA: 0x00B38F34 File Offset: 0x00B37134
		[NullableContext(2)]
		public override ClientStorageInfo Deserialize()
		{
			if (this.Data == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorageString Deserialize error, Data is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", this.Key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			ClientStorageInfo clientStorageInfo = ServerStorageUtil.CreateDefaultStorageInfo((int)this.Key);
			clientStorageInfo.StringData = new ClientStorageStringData
			{
				Data = this.Data
			};
			return clientStorageInfo;
		}
	}
}
