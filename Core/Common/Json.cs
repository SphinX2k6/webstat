using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CSharpScript.Core.Common
{
	// Token: 0x0200714E RID: 29006
	[NullableContext(2)]
	[Nullable(0)]
	public static class Json
	{
		// Token: 0x060463A7 RID: 287655 RVA: 0x01271B7C File Offset: 0x0126FD7C
		public static string Encode([Nullable(1)] object value, JsonSerializerOptions options = null)
		{
			string result;
			try
			{
				if (options == null)
				{
					options = JsonSettings.EncodeOptions;
				}
				result = JsonSerializer.Serialize<object>(value, options);
			}
			catch (Exception error)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Json, ELogAuthor.LCC, "序列化异常", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = null;
			}
			return result;
		}

		// Token: 0x060463A8 RID: 287656 RVA: 0x01271BD0 File Offset: 0x0126FDD0
		public static string Stringify<T>([Nullable(1)] T value, JsonSerializerOptions options = null)
		{
			string result;
			try
			{
				if (options == null)
				{
					options = JsonSettings.EncodeOptions;
				}
				result = JsonSerializer.Serialize<T>(value, options);
			}
			catch (Exception error)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Json, ELogAuthor.LCC, "序列化异常", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = null;
			}
			return result;
		}

		// Token: 0x060463A9 RID: 287657 RVA: 0x01271C24 File Offset: 0x0126FE24
		public static T Parse<T>([Nullable(1)] string text, JsonSerializerOptions options = null)
		{
			T result;
			try
			{
				if (options == null)
				{
					options = JsonSettings.DecodeOptions;
				}
				result = JsonSerializer.Deserialize<T>(text, options);
			}
			catch (Exception error)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Json, ELogAuthor.LCC, "反序列化异常", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = default(T);
			}
			return result;
		}

		// Token: 0x060463AA RID: 287658 RVA: 0x01271C80 File Offset: 0x0126FE80
		public static T Parse<T>([Nullable(0)] ReadOnlySpan<byte> utf8Json, JsonSerializerOptions options = null)
		{
			T result;
			try
			{
				if (options == null)
				{
					options = JsonSettings.DecodeOptions;
				}
				result = JsonSerializer.Deserialize<T>(utf8Json, options);
			}
			catch (Exception error)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Json, ELogAuthor.LCC, "反序列化异常", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = default(T);
			}
			return result;
		}

		// Token: 0x060463AB RID: 287659 RVA: 0x01271CDC File Offset: 0x0126FEDC
		public static T Decode<T>([Nullable(1)] string text, JsonSerializerOptions options = null)
		{
			T result;
			try
			{
				if (options == null)
				{
					options = JsonSettings.DecodeOptions;
				}
				result = JsonSerializer.Deserialize<T>(text, options);
			}
			catch (Exception error)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.Json, ELogAuthor.LCC, "反序列化异常", error, default(ReadOnlySpan<ValueTuple<string, object>>));
				result = default(T);
			}
			return result;
		}
	}
}
