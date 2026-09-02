using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000E5E RID: 3678
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TextConfig : ConfigBase<TextConfig>
{
	// Token: 0x0600588E RID: 22670 RVA: 0x001070A4 File Offset: 0x001052A4
	[return: Nullable(2)]
	public string GetTextById(string id)
	{
		string textContentIdById = this.GetTextContentIdById(id);
		if (string.IsNullOrEmpty(textContentIdById))
		{
			return null;
		}
		return this.GetMultiTextByKey(textContentIdById);
	}

	// Token: 0x0600588F RID: 22671 RVA: 0x001070CC File Offset: 0x001052CC
	[return: Nullable(2)]
	public string GetTextContentIdById(string id)
	{
		Text? config = ConfigTextById.GetConfig(id, true);
		string text = (config != null) ? config.GetValueOrDefault().TextContent : null;
		if (text == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TextUtil;
			ELogAuthor author = ELogAuthor.TL;
			string message = "Text表查找不到Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return text;
	}

	// Token: 0x06005890 RID: 22672 RVA: 0x00107128 File Offset: 0x00105328
	[return: Nullable(2)]
	public string GetGenderTextById(string id, bool isMale)
	{
		GenderText? config = ConfigGenderTextByMaleText.GetConfig(id, true);
		if (config != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TextUtil;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "GenderText表查找不到Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (!isMale)
		{
			return config.Value.FemaleText;
		}
		return config.Value.MaleText;
	}

	// Token: 0x06005891 RID: 22673 RVA: 0x00107191 File Offset: 0x00105391
	[NullableContext(2)]
	public string GetMultiTextByKey([Nullable(1)] string key, string def)
	{
		return ConfigMultiTextLang.GetLocalTextNew(key, null) ?? def;
	}

	// Token: 0x06005892 RID: 22674 RVA: 0x0010719F File Offset: 0x0010539F
	[return: Nullable(2)]
	public string GetMultiTextByKey(string key)
	{
		return this.GetMultiTextByKey(key, string.Empty);
	}

	// Token: 0x06005893 RID: 22675 RVA: 0x001071B0 File Offset: 0x001053B0
	public string GetMultiText(string key, params string[] args)
	{
		string multiTextByKey = this.GetMultiTextByKey(key);
		if (string.IsNullOrEmpty(multiTextByKey))
		{
			return string.Empty;
		}
		return StringUtils.Format(multiTextByKey, args);
	}
}
