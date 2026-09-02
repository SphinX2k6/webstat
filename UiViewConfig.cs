using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x020018B3 RID: 6323
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class UiViewConfig : ConfigBase<UiViewConfig>
{
	// Token: 0x0600B5BF RID: 46527 RVA: 0x00305DC5 File Offset: 0x00303FC5
	public UiShow? GetUiShowConfig(string name)
	{
		return ConfigUiShowByViewName.GetConfig(name, true);
	}

	// Token: 0x0600B5C0 RID: 46528 RVA: 0x00305DCE File Offset: 0x00303FCE
	public UiShow? GetUiShowConfig(EUiViewName name)
	{
		return ConfigUiShowByViewName.GetConfig(name, true);
	}

	// Token: 0x0600B5C1 RID: 46529 RVA: 0x00305DDC File Offset: 0x00303FDC
	public UiFloatConfig? GetUiFloatConfig(EUiViewName name)
	{
		return ConfigUiFloatConfigByViewNameIfNull.GetConfig(name, name, name, true);
	}

	// Token: 0x0600B5C2 RID: 46530 RVA: 0x00305DF6 File Offset: 0x00303FF6
	public UiNormalConfig? GetUiNormalConfig(EUiViewName name)
	{
		return ConfigUiNormalConfigByViewNameIfNull.GetConfig(name.ToString(), name.ToString(), name.ToString(), true);
	}

	// Token: 0x0600B5C3 RID: 46531 RVA: 0x00305E25 File Offset: 0x00304025
	public UiSceneCsv? GetSceneConfig(string sceneId)
	{
		return ConfigUiSceneCsvById.GetConfig(sceneId, true);
	}

	// Token: 0x0600B5C4 RID: 46532 RVA: 0x00305E30 File Offset: 0x00304030
	public string[] GetScenePathList(string sceneId)
	{
		UiSceneCsv? config = ConfigUiSceneCsvById.GetConfig(sceneId, true);
		if (config == null)
		{
			return Array.Empty<string>();
		}
		return config.Value.SceneList();
	}
}
