using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x020031A7 RID: 12711
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FaceExpressionConfig : ConfigBase<FaceExpressionConfig>
{
	// Token: 0x0601A5E3 RID: 108003 RVA: 0x007C5B22 File Offset: 0x007C3D22
	protected override bool OnInit()
	{
		this.CacheFaceExpressionMap = new Dictionary<int, IFaceExpressionConfigData>();
		return true;
	}

	// Token: 0x0601A5E4 RID: 108004 RVA: 0x007C5B30 File Offset: 0x007C3D30
	protected override bool OnClear()
	{
		this.CacheFaceExpressionMap = null;
		return true;
	}

	// Token: 0x0601A5E5 RID: 108005 RVA: 0x007C5B3C File Offset: 0x007C3D3C
	public IFaceExpressionConfigData GetFaceExpressionConfig(int id)
	{
		if (!Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			this.ParseConfigFromJsonFile();
			IFaceExpressionConfigData result;
			this.CacheFaceExpressionMap.TryGetValue(id, out result);
			return result;
		}
		FaceExpressionData? config = ConfigFaceExpressionDataById.GetConfig(id, false);
		if (config == null || string.IsNullOrEmpty(config.Value.FaceExpression))
		{
			return null;
		}
		IFaceExpressionConfig maleVariant = null;
		if (!string.IsNullOrEmpty(config.Value.MaleVariant))
		{
			maleVariant = Json.Parse<IFaceExpressionConfig>(config.Value.MaleVariant, null);
		}
		return new IFaceExpressionConfigData
		{
			Id = config.Value.Id,
			FaceExpression = Json.Parse<IFaceExpressionConfig>(config.Value.FaceExpression, null),
			MaleVariant = maleVariant,
			CloseAutoBlink = new bool?(config.Value.CloseAutoBlink)
		};
	}

	// Token: 0x0601A5E6 RID: 108006 RVA: 0x007C5C1C File Offset: 0x007C3E1C
	private void ParseConfigFromJsonFile()
	{
		if (this.InitFromJson)
		{
			return;
		}
		this.InitFromJson = true;
		string configPath = Singleton<PublicUtil>.Instance.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/FaceExpressionConfig.json");
		if (!Singleton<PublicUtil>.Instance.IsUseTempData())
		{
			configPath = Singleton<PublicUtil>.Instance.GetConfigPath("Content/Aki/UniverseEditorConfig/Json/FaceExpressionConfig.json");
		}
		if (!UBlueprintPathsLibrary.FileExists(configPath))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.NPC;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[FaceExpressionConfig] 不存在FaceExpressionConfig.json文件。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = "";
		UKuroStaticLibrary.LoadFileToString(ref text, configPath);
		foreach (IFaceExpressionConfigData faceExpressionConfigData in Json.Parse<List<IFaceExpressionConfigData>>(text, null))
		{
			if (faceExpressionConfigData != null && !this.CacheFaceExpressionMap.ContainsKey(faceExpressionConfigData.Id))
			{
				this.CacheFaceExpressionMap[faceExpressionConfigData.Id] = faceExpressionConfigData;
			}
		}
	}

	// Token: 0x0400D4BA RID: 54458
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, IFaceExpressionConfigData> CacheFaceExpressionMap;

	// Token: 0x0400D4BB RID: 54459
	private bool InitFromJson;
}
