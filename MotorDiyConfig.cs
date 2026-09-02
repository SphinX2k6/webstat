using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020022F2 RID: 8946
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MotorDiyConfig : ConfigBase<MotorDiyConfig>
{
	// Token: 0x06010EE0 RID: 69344 RVA: 0x004A32C8 File Offset: 0x004A14C8
	public IReadOnlyList<MotorSkin> GetAllMotorSkinList()
	{
		IReadOnlyList<MotorSkin> configList = ConfigMotorSkinAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorSkin表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<MotorSkin>();
		}
		return configList.ToList<MotorSkin>();
	}

	// Token: 0x06010EE1 RID: 69345 RVA: 0x004A330A File Offset: 0x004A150A
	public MotorSkin? GetMotorSkinConfig(int skinId)
	{
		return ConfigMotorSkinById.GetConfig(skinId, true);
	}

	// Token: 0x06010EE2 RID: 69346 RVA: 0x004A3314 File Offset: 0x004A1514
	public IReadOnlyList<MotorScene> GetAllMotorSceneList()
	{
		IReadOnlyList<MotorScene> configList = ConfigMotorSceneAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorScene表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<MotorScene>();
		}
		return configList.ToList<MotorScene>();
	}

	// Token: 0x06010EE3 RID: 69347 RVA: 0x004A3356 File Offset: 0x004A1556
	public MotorScene? GetMotorSceneConfig(int sceneId)
	{
		return ConfigMotorSceneById.GetConfig(sceneId, true);
	}

	// Token: 0x06010EE4 RID: 69348 RVA: 0x004A335F File Offset: 0x004A155F
	public MotorStickerPart? GetMotorStickerPartConfig(int id)
	{
		return ConfigMotorStickerPartById.GetConfig(id, true);
	}

	// Token: 0x06010EE5 RID: 69349 RVA: 0x004A3368 File Offset: 0x004A1568
	public MotorDecorationsPart? GetMotorDecorationPartConfig(int id)
	{
		return ConfigMotorDecorationsPartById.GetConfig(id, true);
	}

	// Token: 0x06010EE6 RID: 69350 RVA: 0x004A3371 File Offset: 0x004A1571
	public MotorFramePart? GetMotorFramePartConfig()
	{
		return ConfigMotorFramePartById.GetConfig(1, true);
	}

	// Token: 0x06010EE7 RID: 69351 RVA: 0x004A337A File Offset: 0x004A157A
	public MotorQuality? GetMotorQualityConfig(int qualityId)
	{
		return ConfigMotorQualityByQualityId.GetConfig(qualityId, true);
	}

	// Token: 0x06010EE8 RID: 69352 RVA: 0x004A3383 File Offset: 0x004A1583
	public MotorSticker? GetMotorStickerConfig(int id)
	{
		return ConfigMotorStickerById.GetConfig(id, true);
	}

	// Token: 0x06010EE9 RID: 69353 RVA: 0x004A338C File Offset: 0x004A158C
	public MotorFrame? GetMotorFrameConfig(int id)
	{
		return ConfigMotorFrameById.GetConfig(id, true);
	}

	// Token: 0x06010EEA RID: 69354 RVA: 0x004A3395 File Offset: 0x004A1595
	public MotorDecorations? GetMotorDecorationConfig(int id)
	{
		return ConfigMotorDecorationsById.GetConfig(id, true);
	}

	// Token: 0x06010EEB RID: 69355 RVA: 0x004A339E File Offset: 0x004A159E
	public MotorComponentGroup? GetMotorComponentGroupConfig(int id)
	{
		return ConfigMotorComponentGroupById.GetConfig(id, true);
	}

	// Token: 0x06010EEC RID: 69356 RVA: 0x004A33A8 File Offset: 0x004A15A8
	public IReadOnlyList<MotorLoadProject> GetAllMotorPresetList()
	{
		IReadOnlyList<MotorLoadProject> configList = ConfigMotorLoadProjectAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Motor, ELogAuthor.LZK, "MotorLoadProject表无效All", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<MotorLoadProject>();
		}
		return configList.ToList<MotorLoadProject>();
	}

	// Token: 0x06010EED RID: 69357 RVA: 0x004A33EA File Offset: 0x004A15EA
	public MotorLoadProject? GetMotorPresetConfig(int id)
	{
		return ConfigMotorLoadProjectById.GetConfig(id, true);
	}

	// Token: 0x06010EEE RID: 69358 RVA: 0x004A33F3 File Offset: 0x004A15F3
	public MotorGeneralPreview? GetMotorGeneralPreviewConfig(int id)
	{
		return ConfigMotorGeneralPreviewById.GetConfig(id, true);
	}
}
