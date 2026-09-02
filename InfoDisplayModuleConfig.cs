using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001FF5 RID: 8181
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class InfoDisplayModuleConfig : ConfigBase<InfoDisplayModuleConfig>
{
	// Token: 0x0600F719 RID: 63257 RVA: 0x0043A404 File Offset: 0x00438604
	private InfoDisplay? GetInfoDisplayConfig(int id)
	{
		InfoDisplay? config = ConfigInfoDisplayById.GetConfig(id, true);
		if (config != null)
		{
			return config;
		}
		return null;
	}

	// Token: 0x0600F71A RID: 63258 RVA: 0x0043A430 File Offset: 0x00438630
	public int GetInfoDisplayType(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return infoDisplayConfig.Value.Type;
		}
		return 0;
	}

	// Token: 0x0600F71B RID: 63259 RVA: 0x0043A460 File Offset: 0x00438660
	public string GetInfoDisplayTitle(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(infoDisplayConfig.Value.Title, null) ?? "";
		}
		return "";
	}

	// Token: 0x0600F71C RID: 63260 RVA: 0x0043A4A4 File Offset: 0x004386A4
	public string GetInfoDisplayDesc(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(infoDisplayConfig.Value.Text, null) ?? "";
		}
		return "";
	}

	// Token: 0x0600F71D RID: 63261 RVA: 0x0043A4E8 File Offset: 0x004386E8
	public string GetInfoDisplayAudio(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return infoDisplayConfig.Value.Audio;
		}
		return "";
	}

	// Token: 0x0600F71E RID: 63262 RVA: 0x0043A51C File Offset: 0x0043871C
	public string GetInfoDisplayBgStamp(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return infoDisplayConfig.Value.Background;
		}
		return "";
	}

	// Token: 0x0600F71F RID: 63263 RVA: 0x0043A550 File Offset: 0x00438750
	public string[] GetInfoDisplayPictures(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		string[] result = new string[0];
		if (infoDisplayConfig != null && infoDisplayConfig.Value.Picture != "")
		{
			return infoDisplayConfig.Value.Picture.Split(',', StringSplitOptions.None);
		}
		return result;
	}

	// Token: 0x0600F720 RID: 63264 RVA: 0x0043A5AC File Offset: 0x004387AC
	public string GetInfoDisplayEntryAudio(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return infoDisplayConfig.Value.EntryAudio;
		}
		return "";
	}

	// Token: 0x0600F721 RID: 63265 RVA: 0x0043A5E0 File Offset: 0x004387E0
	public string GetInfoDisplayExitAudio(int id)
	{
		InfoDisplay? infoDisplayConfig = this.GetInfoDisplayConfig(id);
		if (infoDisplayConfig != null)
		{
			return infoDisplayConfig.Value.ExitAudio;
		}
		return "";
	}
}
