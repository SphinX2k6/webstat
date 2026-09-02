using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiCameraAnimation
{
	// Token: 0x02004D8D RID: 19853
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiCameraAnimationConfig : ConfigBase<UiCameraAnimationConfig>
	{
		// Token: 0x06033667 RID: 210535 RVA: 0x00CDB2C8 File Offset: 0x00CD94C8
		public UiShow? GetViewConfig(EUiViewName viewName)
		{
			return ConfigUiShowByViewName.GetConfig(viewName, true);
		}

		// Token: 0x06033668 RID: 210536 RVA: 0x00CDB2D6 File Offset: 0x00CD94D6
		[return: Nullable(2)]
		public SUiCameraAnimationSettings GetUiCameraAnimationConfig(string handleName)
		{
			return DataTableUtil.GetDataTableRowFromName<SUiCameraAnimationSettings>(EDataTable.UiCameraAnimationSettings, handleName);
		}

		// Token: 0x06033669 RID: 210537 RVA: 0x00CDB2E0 File Offset: 0x00CD94E0
		[return: Nullable(2)]
		public SUiCameraAnimationBlendSettings GetUiCameraAnimationBlendData(string blendDataName)
		{
			return DataTableUtil.GetDataTableRowFromName<SUiCameraAnimationBlendSettings>(EDataTable.UiCameraAnimationBlendSettings, blendDataName);
		}

		// Token: 0x0603366A RID: 210538 RVA: 0x00CDB2EA File Offset: 0x00CD94EA
		public UiCameraMapping? GetUiCameraMappingConfig(string viewName)
		{
			return ConfigUiCameraMappingByViewName.GetConfig(viewName, true);
		}

		// Token: 0x0603366B RID: 210539 RVA: 0x00CDB2F3 File Offset: 0x00CD94F3
		public UiCameraMapping? GetUiCameraMappingConfigById(int cameraId)
		{
			return ConfigUiCameraMappingById.GetConfig(cameraId, true);
		}

		// Token: 0x0603366C RID: 210540 RVA: 0x00CDB2FC File Offset: 0x00CD94FC
		public ChildUiCameraMapping? GetChildUiCameraMappingConfig(string viewName)
		{
			return ConfigChildUiCameraMappingByViewName.GetConfig(viewName, true);
		}

		// Token: 0x0603366D RID: 210541 RVA: 0x00CDB305 File Offset: 0x00CD9505
		[NullableContext(2)]
		public IReadOnlyList<UiCameraMapping> GetAllUiCameraMappingConfig()
		{
			return ConfigUiCameraMappingAll.GetConfigList(true);
		}

		// Token: 0x0603366E RID: 210542 RVA: 0x00CDB30D File Offset: 0x00CD950D
		[NullableContext(2)]
		public IReadOnlyList<ChildUiCameraMapping> GetAllChildUiCameraMappingConfig()
		{
			return ConfigChildUiCameraMappingAll.GetConfigList(true);
		}
	}
}
