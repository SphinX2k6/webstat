using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007008 RID: 28680
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonTouchUiEditConfig : ConfigBase<CommonTouchUiEditConfig>
	{
		// Token: 0x060456D3 RID: 284371 RVA: 0x01226E41 File Offset: 0x01225041
		[NullableContext(2)]
		public IReadOnlyList<CommonTouchUiEdit> GetConfigListByEditGroup(int group)
		{
			return ConfigCommonTouchUiEditByEditGroup.GetConfigList(group, true);
		}

		// Token: 0x060456D4 RID: 284372 RVA: 0x01226E4A File Offset: 0x0122504A
		public CommonTouchUiEdit? GetConfigById(int id)
		{
			return ConfigCommonTouchUiEditById.GetConfig(id, true);
		}

		// Token: 0x060456D5 RID: 284373 RVA: 0x01226E53 File Offset: 0x01225053
		[return: Nullable(2)]
		public IReadOnlyList<CommonTouchUiEdit> GetConfigListByPanelResId(string resId)
		{
			return ConfigCommonTouchUiEditByPanelResId.GetConfigList(resId, true);
		}

		// Token: 0x060456D6 RID: 284374 RVA: 0x01226E5C File Offset: 0x0122505C
		public CommonTouchUiEditGroup? GetGroupConfigById(int id)
		{
			return ConfigCommonTouchUiEditGroupById.GetConfig(id, true);
		}
	}
}
