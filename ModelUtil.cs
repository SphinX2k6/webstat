using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.UiModel.Struct;
using UnrealEngine;

// Token: 0x02000C1E RID: 3102
public static class ModelUtil
{
	// Token: 0x0600357B RID: 13691 RVA: 0x000314F9 File Offset: 0x0002F6F9
	[NullableContext(2)]
	public static SModelConfig GetModelConfig(int modelId)
	{
		return DataTableUtil.GetDataTableRowFromName<SModelConfig>(EDataTable.ModelConfig, modelId.ToString());
	}

	// Token: 0x0600357C RID: 13692 RVA: 0x00031508 File Offset: 0x0002F708
	[NullableContext(1)]
	[return: Nullable(2)]
	public static SUiModelRotateSetting GetUiModelRotateSettings(string rowName)
	{
		return DataTableUtil.GetDataTableRowFromName<SUiModelRotateSetting>(EDataTable.UiModelRotateSettings, rowName);
	}

	// Token: 0x0600357D RID: 13693 RVA: 0x00031514 File Offset: 0x0002F714
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public static TSoftObjectPtr<USkeletalMesh> GetSoftSkeletalMesh(int modelId)
	{
		SModelConfig modelConfig = ModelUtil.GetModelConfig(modelId);
		if (modelConfig != null)
		{
			return modelConfig.网格体;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ModelUtil;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "加载模型配置数据失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ModelId", modelId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}
}
