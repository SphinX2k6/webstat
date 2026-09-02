using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.Misc
{
	// Token: 0x0200580C RID: 22540
	[NullableContext(1)]
	[Nullable(0)]
	public static class MapLogger
	{
		// Token: 0x0603956C RID: 234860 RVA: 0x00E8DF5C File Offset: 0x00E8C15C
		public static void Clear()
		{
			MapLogger.LogCounterMap.Clear();
		}

		// Token: 0x0603956D RID: 234861 RVA: 0x00E8DF68 File Offset: 0x00E8C168
		public static void Debug(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
		}

		// Token: 0x0603956E RID: 234862 RVA: 0x00E8DF6A File Offset: 0x00E8C16A
		public static void DebugOnce(object key, ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (MapLogger.IsLogExceedsLimit(key, 1))
			{
				return;
			}
			MapLogger.Debug(author, message, pairs);
			MapLogger.CountLog(key);
		}

		// Token: 0x0603956F RID: 234863 RVA: 0x00E8DF84 File Offset: 0x00E8C184
		public static void Info(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			Singleton<Log>.Instance.Info(ELogModule.Map, author, message, pairs);
		}

		// Token: 0x06039570 RID: 234864 RVA: 0x00E8DF95 File Offset: 0x00E8C195
		public static void InfoOnce(object key, ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (MapLogger.IsLogExceedsLimit(key, 1))
			{
				return;
			}
			MapLogger.Info(author, message, pairs);
			MapLogger.CountLog(key);
		}

		// Token: 0x06039571 RID: 234865 RVA: 0x00E8DFAF File Offset: 0x00E8C1AF
		public static void Warn(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Map, author, message, pairs);
		}

		// Token: 0x06039572 RID: 234866 RVA: 0x00E8DFC0 File Offset: 0x00E8C1C0
		public static void WarnOnce(object key, ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (MapLogger.IsLogExceedsLimit(key, 1))
			{
				return;
			}
			MapLogger.Warn(author, message, pairs);
			MapLogger.CountLog(key);
		}

		// Token: 0x06039573 RID: 234867 RVA: 0x00E8DFDA File Offset: 0x00E8C1DA
		public static void Error(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			Singleton<Log>.Instance.Error(ELogModule.Map, author, message, pairs);
		}

		// Token: 0x06039574 RID: 234868 RVA: 0x00E8DFEB File Offset: 0x00E8C1EB
		public static void ErrorOnce(object key, ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (MapLogger.IsLogExceedsLimit(key, 1))
			{
				return;
			}
			MapLogger.Error(author, message, pairs);
			MapLogger.CountLog(key);
		}

		// Token: 0x06039575 RID: 234869 RVA: 0x00E8E008 File Offset: 0x00E8C208
		private static bool IsLogExceedsLimit(object key, int limit = 1)
		{
			int num;
			return MapLogger.LogCounterMap.TryGetValue(key, out num) && num >= limit;
		}

		// Token: 0x06039576 RID: 234870 RVA: 0x00E8E030 File Offset: 0x00E8C230
		private static void CountLog(object key)
		{
			int valueOrDefault = MapLogger.LogCounterMap.GetValueOrDefault(key, 0);
			MapLogger.LogCounterMap[key] = valueOrDefault + 1;
		}

		// Token: 0x04020976 RID: 133494
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<object, int> LogCounterMap = new Dictionary<object, int>();
	}
}
