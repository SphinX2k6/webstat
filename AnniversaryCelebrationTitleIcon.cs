using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200119F RID: 4511
public class AnniversaryCelebrationTitleIcon : ActivityCaptionDecorationTagBase
{
	// Token: 0x060076AB RID: 30379 RVA: 0x001F1119 File Offset: 0x001EF319
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x060076AC RID: 30380 RVA: 0x001F113C File Offset: 0x001EF33C
	public override UniTask OnCaptionTagRefresh(int activityId)
	{
		string resourceId = (Singleton<LanguageSystem>.Instance.PackageLanguage == "zh-Hans") ? "T_AnniversaryCelebrationLogo_CN" : "T_AnniversaryCelebrationLogo_EN";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.TrySetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		return UniTask.CompletedTask;
	}

	// Token: 0x020074FA RID: 29946
	private class EComponents
	{
		// Token: 0x04028631 RID: 165425
		public const int TexIcon = 0;
	}
}
