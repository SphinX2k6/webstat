using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Typing;

// Token: 0x02001B5B RID: 7003
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ErrorCodeConfig : ConfigBase<ErrorCodeConfig>
{
	// Token: 0x0600CAC6 RID: 51910 RVA: 0x00360EA1 File Offset: 0x0035F0A1
	public void SetForceShowDebugErrorType(int isShipping)
	{
		this.ForceShowDebugTextType = isShipping;
	}

	// Token: 0x0600CAC7 RID: 51911 RVA: 0x00360EAC File Offset: 0x0035F0AC
	public Aki.Config.ErrorCode? GetConfigByCode(Aki.Protocol.ErrorCode code)
	{
		Aki.Config.ErrorCode? config = ConfigErrorCodeById.GetConfig((int)code, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ErrorCode;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "没有错误码配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("code", code);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0600CAC8 RID: 51912 RVA: 0x00360EF8 File Offset: 0x0035F0F8
	public string GetTextByErrorId(Aki.Protocol.ErrorCode code)
	{
		Aki.Config.ErrorCode? configByCode = this.GetConfigByCode(code);
		if (configByCode == null)
		{
			return string.Empty;
		}
		if (!KuroApplication.IsBuildShipping() && Singleton<Info>.Instance.IsBuildDevelopmentOrDebug && this.ForceShowDebugTextType == 0)
		{
			return configByCode.Value.DebugText;
		}
		if (string.IsNullOrEmpty(configByCode.Value.Text))
		{
			return ConfigBase<TextConfig>.Instance.GetTextById("UnknownErrorCodeText");
		}
		return ConfigMultiTextLang.GetLocalTextNew(configByCode.Value.Text, null) ?? string.Empty;
	}

	// Token: 0x0600CAC9 RID: 51913 RVA: 0x00360F8C File Offset: 0x0035F18C
	public string GetTextKeyByErrorId(Aki.Protocol.ErrorCode code)
	{
		Aki.Config.ErrorCode? configByCode = this.GetConfigByCode(code);
		if (configByCode == null)
		{
			return string.Empty;
		}
		if (string.IsNullOrEmpty(configByCode.Value.Text))
		{
			return ConfigBase<TextConfig>.Instance.GetTextContentIdById("UnknownErrorCodeText");
		}
		return configByCode.Value.Text;
	}

	// Token: 0x0600CACA RID: 51914 RVA: 0x00360FE8 File Offset: 0x0035F1E8
	public bool IsTipsOnly(Aki.Protocol.ErrorCode code)
	{
		Aki.Config.ErrorCode? configByCode = this.GetConfigByCode(code);
		return configByCode != null && configByCode.GetValueOrDefault().IsTip;
	}

	// Token: 0x04006103 RID: 24835
	private int ForceShowDebugTextType = 1;
}
