using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Launcher.Util.Json;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A1 RID: 17569
	[NullableContext(2)]
	[Nullable(0)]
	public static class LauncherJson
	{
		// Token: 0x0602E53D RID: 189757 RVA: 0x00AE026C File Offset: 0x00ADE46C
		public static string Stringify<T>([Nullable(1)] T value, JsonSerializerOptions options = null)
		{
			string result;
			try
			{
				if (options == null)
				{
					options = LauncherJsonSettings.GetSerializerOptions<T>();
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

		// Token: 0x0602E53E RID: 189758 RVA: 0x00AE02C0 File Offset: 0x00ADE4C0
		public static T Parse<T>([Nullable(1)] string text, JsonSerializerOptions options = null)
		{
			T result;
			try
			{
				if (options == null)
				{
					options = LauncherJsonSettings.GetSerializerOptions<T>();
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

		// Token: 0x0602E53F RID: 189759 RVA: 0x00AE031C File Offset: 0x00ADE51C
		public static T Parse<T>(JsonElement jsonElement, JsonSerializerOptions options = null)
		{
			T result;
			try
			{
				if (options == null)
				{
					options = LauncherJsonSettings.GetSerializerOptions<T>();
				}
				result = jsonElement.Deserialize(options);
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
