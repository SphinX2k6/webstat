using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200321C RID: 12828
[NullableContext(1)]
[Nullable(0)]
public class DisableEntityHandle
{
	// Token: 0x0601AA75 RID: 109173 RVA: 0x007ED789 File Offset: 0x007EB989
	public DisableEntityHandle(string type)
	{
		this.Type = type;
	}

	// Token: 0x17002408 RID: 9224
	// (get) Token: 0x0601AA76 RID: 109174 RVA: 0x007ED7A3 File Offset: 0x007EB9A3
	public bool Empty
	{
		get
		{
			return this.DisableMap.Count == 0;
		}
	}

	// Token: 0x0601AA77 RID: 109175 RVA: 0x007ED7B4 File Offset: 0x007EB9B4
	public unsafe int Disable(string reason, string constructorName)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "Disable的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConstructorName", constructorName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		else if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "Disable的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ConstructorName", constructorName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		int num = this.DisableCount + 1;
		this.DisableCount = num;
		int num2 = num;
		this.DisableMap[num2] = reason;
		return num2;
	}

	// Token: 0x0601AA78 RID: 109176 RVA: 0x007ED88C File Offset: 0x007EBA8C
	public unsafe bool Enable(int handle, string constructorName)
	{
		string text;
		if (!this.DisableMap.TryGetValue(handle, out text))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "激活句柄不存在";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", this.Type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConstructorName", constructorName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("handle", handle);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		return this.DisableMap.Remove(handle);
	}

	// Token: 0x0601AA79 RID: 109177 RVA: 0x007ED92B File Offset: 0x007EBB2B
	public void Clear()
	{
		this.DisableMap.Clear();
	}

	// Token: 0x0601AA7A RID: 109178 RVA: 0x007ED938 File Offset: 0x007EBB38
	public string DumpDisableInfo()
	{
		List<string> list = new List<string>();
		string value = "";
		foreach (KeyValuePair<int, string> keyValuePair in this.DisableMap)
		{
			List<string> list2 = list;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 4);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("{Type:");
			defaultInterpolatedStringHandler.AppendFormatted(this.Type);
			defaultInterpolatedStringHandler.AppendLiteral(",Handle:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Key);
			defaultInterpolatedStringHandler.AppendLiteral(",Reason:");
			defaultInterpolatedStringHandler.AppendFormatted(keyValuePair.Value);
			defaultInterpolatedStringHandler.AppendLiteral("}");
			list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			value = " ";
		}
		return string.Join("", list);
	}

	// Token: 0x0400D7DA RID: 55258
	private int DisableCount;

	// Token: 0x0400D7DB RID: 55259
	private readonly Dictionary<int, string> DisableMap = new Dictionary<int, string>();

	// Token: 0x0400D7DC RID: 55260
	private readonly string Type;
}
