using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.ServerStorage
{
	// Token: 0x0200472B RID: 18219
	public class ServerStorageUtil
	{
		// Token: 0x0602F4EB RID: 193771 RVA: 0x00B37B24 File Offset: 0x00B35D24
		[NullableContext(1)]
		public static ClientStorageInfo CreateDefaultStorageInfo(int key)
		{
			ClientStorageInfo clientStorageInfo = ClientStorageInfo.Create();
			clientStorageInfo.SystemId = key;
			clientStorageInfo.MapMapData = null;
			clientStorageInfo.MapListData = null;
			clientStorageInfo.MapData = null;
			clientStorageInfo.ListData = null;
			clientStorageInfo.SetData = null;
			clientStorageInfo.BoolData = null;
			clientStorageInfo.IntData = null;
			clientStorageInfo.LongData = null;
			clientStorageInfo.StringData = null;
			return clientStorageInfo;
		}

		// Token: 0x0602F4EC RID: 193772 RVA: 0x00B37B7C File Offset: 0x00B35D7C
		public unsafe static bool OverrideLocalNumberToServerNumber(ELocalStoragePlayerKey localKey, EClientStorageSystemIdType serverKey)
		{
			ServerStorageEntryBase serverStorageEntryBase = ModelBase<ServerStorageModel>.Instance.Get(serverKey);
			if (!(serverStorageEntryBase is ServerStorageNumber))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorage number type mismatch";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverKey", serverKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", serverStorageEntryBase);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ServerStorageNumber serverStorageNumber = (ServerStorageNumber)serverStorageEntryBase;
			if (serverStorageNumber.Get() != null)
			{
				return false;
			}
			int? value = new int?(LocalStorage.GetPlayer<int>(localKey, 0));
			if (value == null)
			{
				return false;
			}
			serverStorageNumber.Set(value);
			return true;
		}

		// Token: 0x0602F4ED RID: 193773 RVA: 0x00B37C34 File Offset: 0x00B35E34
		public unsafe static bool OverrideLocalNumberToServerLong(ELocalStoragePlayerKey localKey, EClientStorageSystemIdType serverKey)
		{
			ServerStorageEntryBase serverStorageEntryBase = ModelBase<ServerStorageModel>.Instance.Get(serverKey);
			if (!(serverStorageEntryBase is ServerStorageLong))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorage long type mismatch";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverKey", serverKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", serverStorageEntryBase);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ServerStorageLong serverStorageLong = (ServerStorageLong)serverStorageEntryBase;
			if (serverStorageLong.Get() != null)
			{
				return false;
			}
			long? value = new long?(LocalStorage.GetPlayer<long>(localKey, 0L));
			if (value == null)
			{
				return false;
			}
			serverStorageLong.Set(value);
			return true;
		}

		// Token: 0x0602F4EE RID: 193774 RVA: 0x00B37CF0 File Offset: 0x00B35EF0
		public unsafe static bool OverrideLocalStringToServerString(ELocalStoragePlayerKey localKey, EClientStorageSystemIdType serverKey)
		{
			ServerStorageEntryBase serverStorageEntryBase = ModelBase<ServerStorageModel>.Instance.Get(serverKey);
			if (!(serverStorageEntryBase is ServerStorageString))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorage string type mismatch";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverKey", serverKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", serverStorageEntryBase);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ServerStorageString serverStorageString = (ServerStorageString)serverStorageEntryBase;
			if (serverStorageString.Get() != null)
			{
				return false;
			}
			string player = LocalStorage.GetPlayer<string>(localKey, null);
			if (player == null)
			{
				return false;
			}
			serverStorageString.Set(player);
			return true;
		}

		// Token: 0x0602F4EF RID: 193775 RVA: 0x00B37D94 File Offset: 0x00B35F94
		public unsafe static bool OverrideLocalBooleanToServerBoolean(ELocalStoragePlayerKey localKey, EClientStorageSystemIdType serverKey)
		{
			ServerStorageEntryBase serverStorageEntryBase = ModelBase<ServerStorageModel>.Instance.Get(serverKey);
			if (!(serverStorageEntryBase is ServerStorageBoolean))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorage boolean type mismatch";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverKey", serverKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", serverStorageEntryBase);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ServerStorageBoolean serverStorageBoolean = (ServerStorageBoolean)serverStorageEntryBase;
			if (serverStorageBoolean.Get() != null)
			{
				return false;
			}
			bool? value = new bool?(LocalStorage.GetPlayer<bool>(localKey, false));
			if (value == null)
			{
				return false;
			}
			serverStorageBoolean.Set(value);
			return true;
		}

		// Token: 0x0602F4F0 RID: 193776 RVA: 0x00B37E50 File Offset: 0x00B36050
		public unsafe static bool OverrideLocalListToServerSet(ELocalStoragePlayerKey localKey, EClientStorageSystemIdType serverKey)
		{
			List<int> player = LocalStorage.GetPlayer<List<int>>(localKey, null);
			if (player == null)
			{
				return false;
			}
			ServerStorageEntryBase serverStorageEntryBase = ModelBase<ServerStorageModel>.Instance.Get(serverKey);
			if (!(serverStorageEntryBase is ServerStorageSet))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorage set type mismatch";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverKey", serverKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", serverStorageEntryBase);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ServerStorageSet serverStorageSet = (ServerStorageSet)serverStorageEntryBase;
			foreach (int value in player)
			{
				if (!serverStorageSet.Has(value))
				{
					serverStorageSet.Add(value);
				}
			}
			return true;
		}

		// Token: 0x0602F4F1 RID: 193777 RVA: 0x00B37F34 File Offset: 0x00B36134
		public unsafe static bool OverrideLocalSetToServerSet(ELocalStoragePlayerKey localKey, EClientStorageSystemIdType serverKey)
		{
			HashSet<int> player = LocalStorage.GetPlayer<HashSet<int>>(localKey, null);
			if (player == null)
			{
				return false;
			}
			ServerStorageEntryBase serverStorageEntryBase = ModelBase<ServerStorageModel>.Instance.Get(serverKey);
			if (!(serverStorageEntryBase is ServerStorageSet))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ServerStorage;
				ELogAuthor author = ELogAuthor.BB;
				string message = "ServerStorage set type mismatch";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverKey", serverKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", serverStorageEntryBase);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ServerStorageSet serverStorageSet = (ServerStorageSet)serverStorageEntryBase;
			foreach (int value in player)
			{
				if (!serverStorageSet.Has(value))
				{
					serverStorageSet.Add(value);
				}
			}
			return true;
		}
	}
}
