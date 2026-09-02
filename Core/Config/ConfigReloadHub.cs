using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Config
{
	// Token: 0x02007144 RID: 28996
	[NullableContext(1)]
	[Nullable(0)]
	public class ConfigReloadHub : IStaticVariableResetter
	{
		// Token: 0x0604634E RID: 287566 RVA: 0x01270CC8 File Offset: 0x0126EEC8
		static ConfigReloadHub()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ConfigReloadHub.CreateStaticDefaultValue), new Action(ConfigReloadHub.ResetStaticDefaultValue));
		}

		// Token: 0x0604634F RID: 287567 RVA: 0x01270CF1 File Offset: 0x0126EEF1
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06046350 RID: 287568 RVA: 0x01270CF3 File Offset: 0x0126EEF3
		public static void ResetStaticDefaultValue()
		{
			ConfigReloadHub.Callbacks.Clear();
		}

		// Token: 0x06046351 RID: 287569 RVA: 0x01270D00 File Offset: 0x0126EF00
		public unsafe static void RegisterReloadCallback(string dbName, Action callback)
		{
			if (string.IsNullOrWhiteSpace(dbName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.GHY;
				string message = "[ConfigReloadHub] RegisterReloadCallback dbName 无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbName", dbName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			HashSet<Action> hashSet;
			if (!ConfigReloadHub.Callbacks.TryGetValue(dbName, out hashSet))
			{
				hashSet = new HashSet<Action>();
				ConfigReloadHub.Callbacks[dbName] = hashSet;
			}
			hashSet.Add(callback);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Config;
			ELogAuthor author2 = ELogAuthor.GHY;
			string message2 = "[热更] 已注册热更回调";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("db", dbName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前回调数量", hashSet.Count);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06046352 RID: 287570 RVA: 0x01270DC4 File Offset: 0x0126EFC4
		public unsafe static void UnregisterReloadCallback(string dbName, Action callback)
		{
			HashSet<Action> hashSet;
			bool flag = ConfigReloadHub.Callbacks.TryGetValue(dbName, out hashSet);
			if (flag)
			{
				hashSet.Remove(callback);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "[热更] 已注销热更回调";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("db", dbName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("剩余回调数量", flag ? hashSet.Count : -1);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06046353 RID: 287571 RVA: 0x01270E50 File Offset: 0x0126F050
		public unsafe static void EmitReload(string dbName)
		{
			HashSet<Action> hashSet;
			bool flag = ConfigReloadHub.Callbacks.TryGetValue(dbName, out hashSet);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "[热更] 开始触发热更回调";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("db", dbName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("待执行回调数量", flag ? hashSet.Count : 0);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!flag || hashSet.Count == 0)
			{
				return;
			}
			foreach (Action action in hashSet)
			{
				try
				{
					action();
				}
				catch (Exception ex)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Config;
					ELogAuthor author2 = ELogAuthor.GHY;
					string message2 = "[ConfigReloadHub] 重载回调执行失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("dbName", dbName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("error", ex.ToString());
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Config;
			ELogAuthor author3 = ELogAuthor.GHY;
			string message3 = "[ConfigReloadHub] 已触发重载回调";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbName", dbName);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x040275B9 RID: 161209
		private static readonly Dictionary<string, HashSet<Action>> Callbacks = new Dictionary<string, HashSet<Action>>();
	}
}
