using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001A87 RID: 6791
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ConfirmBoxConfig : ConfigBase<ConfirmBoxConfig>
{
	// Token: 0x0600C248 RID: 49736 RVA: 0x00332E48 File Offset: 0x00331048
	public ConfirmBox? GetConfirmBoxConfig(int configId)
	{
		ConfirmBox? config = ConfigConfirmBoxById.GetConfig(configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ConfirmBox;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "原因:确认框.xlsx表格查找不到对应的配置id 解决:策划查看是否有配置对应的id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置id", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0600C249 RID: 49737 RVA: 0x00332E93 File Offset: 0x00331093
	public string GetTitle(string titleId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(titleId, null);
	}

	// Token: 0x0600C24A RID: 49738 RVA: 0x00332E9C File Offset: 0x0033109C
	public string GetContent(string contentId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(contentId, null);
	}

	// Token: 0x0600C24B RID: 49739 RVA: 0x00332EA5 File Offset: 0x003310A5
	public string GetSecondaryContent(string secondaryContentId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(secondaryContentId, null);
	}

	// Token: 0x0600C24C RID: 49740 RVA: 0x00332EAE File Offset: 0x003310AE
	public string GetButtonText(string textId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(textId, null);
	}

	// Token: 0x0600C24D RID: 49741 RVA: 0x00332EB8 File Offset: 0x003310B8
	public int? GetUiShowType(int configId)
	{
		ConfirmBox? confirmBoxConfig = this.GetConfirmBoxConfig(configId);
		if (confirmBoxConfig == null)
		{
			return null;
		}
		return new int?(confirmBoxConfig.GetValueOrDefault().UiShowType);
	}
}
