using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;

// Token: 0x020018AC RID: 6316
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class CommonConfig : ConfigBase<CommonConfig>
{
	// Token: 0x0600B56E RID: 46446 RVA: 0x00304A4B File Offset: 0x00302C4B
	public int? GetSelectablePropItemTickMaxTime()
	{
		return ConfigCommonParamById.GetIntConfig("additem_accumulate_initialtime");
	}

	// Token: 0x0600B56F RID: 46447 RVA: 0x00304A57 File Offset: 0x00302C57
	public int? GetSelectablePropItemTickMinTime()
	{
		return ConfigCommonParamById.GetIntConfig("additem_accumulate_mintime");
	}

	// Token: 0x0600B570 RID: 46448 RVA: 0x00304A63 File Offset: 0x00302C63
	public int? GetSelectablePropItemTickIntervalTime()
	{
		return ConfigCommonParamById.GetIntConfig("additem_accumulate_deltaspeed");
	}

	// Token: 0x0600B571 RID: 46449 RVA: 0x00304A6F File Offset: 0x00302C6F
	public float? GetAutoAttachVelocityTime()
	{
		return ConfigCommonParamById.GetFloatConfig("AutoAttachVelocityTime");
	}

	// Token: 0x0600B572 RID: 46450 RVA: 0x00304A7B File Offset: 0x00302C7B
	public float? GetAutoAttachInertiaTime()
	{
		return ConfigCommonParamById.GetFloatConfig("AutoAttachInertiaTime");
	}

	// Token: 0x0600B573 RID: 46451 RVA: 0x00304A87 File Offset: 0x00302C87
	public string GetNetGoodSprite()
	{
		return ConfigCommonParamById.GetStringConfig("NetGood");
	}

	// Token: 0x0600B574 RID: 46452 RVA: 0x00304A93 File Offset: 0x00302C93
	public string GetNetMiddleSprite()
	{
		return ConfigCommonParamById.GetStringConfig("NetMiddle");
	}

	// Token: 0x0600B575 RID: 46453 RVA: 0x00304A9F File Offset: 0x00302C9F
	public string GetNetBadSprite()
	{
		return ConfigCommonParamById.GetStringConfig("NetBad");
	}

	// Token: 0x0600B576 RID: 46454 RVA: 0x00304AAB File Offset: 0x00302CAB
	public string GetNetGoodSpriteMobile()
	{
		return ConfigCommonParamById.GetStringConfig("NetGoodMobile");
	}

	// Token: 0x0600B577 RID: 46455 RVA: 0x00304AB7 File Offset: 0x00302CB7
	public string GetNetMiddleSpriteMobile()
	{
		return ConfigCommonParamById.GetStringConfig("NetMiddleMobile");
	}

	// Token: 0x0600B578 RID: 46456 RVA: 0x00304AC3 File Offset: 0x00302CC3
	public string GetNetBadSpriteMobile()
	{
		return ConfigCommonParamById.GetStringConfig("NetBadMobile");
	}

	// Token: 0x0600B579 RID: 46457 RVA: 0x00304AD0 File Offset: 0x00302CD0
	public List<QualityInfo> GetItemQualityList()
	{
		List<QualityInfo> list = ConfigCommon.ToList<QualityInfo>(ConfigQualityInfoAll.GetConfigList(true));
		if (list != null)
		{
			list.Sort((QualityInfo a, QualityInfo b) => a.Id - b.Id);
		}
		return list;
	}

	// Token: 0x0600B57A RID: 46458 RVA: 0x00304B12 File Offset: 0x00302D12
	public QualityInfo? GetItemQualityById(int id)
	{
		return ConfigQualityInfoById.GetConfig(id, true);
	}

	// Token: 0x0600B57B RID: 46459 RVA: 0x00304B1C File Offset: 0x00302D1C
	public string GetItemQualityValueByParam(QualityInfo? config, CommonDefine.EQualityIconType? param)
	{
		if (config == null)
		{
			return null;
		}
		if (param != null)
		{
			switch (param.GetValueOrDefault())
			{
			case CommonDefine.EQualityIconType.BackgroundSprite:
				return config.Value.BackgroundSprite;
			case CommonDefine.EQualityIconType.VerticalGradientSprite:
				return config.Value.VerticalGradientSprite;
			case CommonDefine.EQualityIconType.TipsSprite:
				return config.Value.TipsSprite;
			case CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath:
				return config.Value.MediumItemGridQualitySpritePath;
			case CommonDefine.EQualityIconType.TypeAGridQualitySpritePath:
				return config.Value.TypeAGridQualitySpritePath;
			}
		}
		return null;
	}

	// Token: 0x0600B57C RID: 46460 RVA: 0x00304BB2 File Offset: 0x00302DB2
	public ElementInfo? GetElementConfig(int elementId)
	{
		return ConfigElementInfoById.GetConfig(elementId, true);
	}

	// Token: 0x0600B57D RID: 46461 RVA: 0x00304BBB File Offset: 0x00302DBB
	public LongPressConfig? GetLongPressConfig(int configId)
	{
		return ConfigLongPressConfigById.GetConfig(configId, true);
	}

	// Token: 0x0600B57E RID: 46462 RVA: 0x00304BC4 File Offset: 0x00302DC4
	public string GetDebugGmViewPath(EUiViewName name)
	{
		if (name == EUiViewName.GmView)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return ConfigCommonParamById.GetStringConfig("GmViewPath");
			}
			return ConfigCommonParamById.GetStringConfig("GmPcViewPath");
		}
		else
		{
			if (!(name == EUiViewName.LoginDebugView))
			{
				return null;
			}
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return ConfigCommonParamById.GetStringConfig("GmLoginViewPath");
			}
			return ConfigCommonParamById.GetStringConfig("GmPcLoginViewPath");
		}
	}

	// Token: 0x0600B57F RID: 46463 RVA: 0x00304C30 File Offset: 0x00302E30
	public int? GetNewMailGap()
	{
		return ConfigCommonParamById.GetIntConfig("NewMailGap");
	}

	// Token: 0x0600B580 RID: 46464 RVA: 0x00304C3C File Offset: 0x00302E3C
	public int? GetPingUnChangeValue()
	{
		return ConfigCommonParamById.GetIntConfig("PingUnChangeValue");
	}

	// Token: 0x0600B581 RID: 46465 RVA: 0x00304C48 File Offset: 0x00302E48
	public bool? GetBetaBlockRecharge()
	{
		return ConfigCommonParamById.GetBoolConfig("BlockPay");
	}

	// Token: 0x0600B582 RID: 46466 RVA: 0x00304C54 File Offset: 0x00302E54
	public bool? GetPioneerFlag()
	{
		return ConfigCommonParamById.GetBoolConfig("PioneerFlag");
	}

	// Token: 0x0600B583 RID: 46467 RVA: 0x00304C60 File Offset: 0x00302E60
	public int? GetShareGap()
	{
		return ConfigCommonParamById.GetIntConfig("ShareGap");
	}

	// Token: 0x0600B584 RID: 46468 RVA: 0x00304C6C File Offset: 0x00302E6C
	public IReadOnlyList<int> GetIosReviewShieldMenuArray()
	{
		return ConfigCommonParamById.GetIntArrayConfig("BlockOnIosCheckServer");
	}

	// Token: 0x0600B585 RID: 46469 RVA: 0x00304C78 File Offset: 0x00302E78
	public string GetKoShopRuleUrl()
	{
		return ConfigCommonParamById.GetStringConfig("KoShopRuleUrl");
	}

	// Token: 0x0600B586 RID: 46470 RVA: 0x00304C84 File Offset: 0x00302E84
	public string GetJaShopRuleUrl()
	{
		return ConfigCommonParamById.GetStringConfig("JaShopRuleUrl");
	}

	// Token: 0x0600B587 RID: 46471 RVA: 0x00304C90 File Offset: 0x00302E90
	public int? GetReviewCd()
	{
		return ConfigCommonParamById.GetIntConfig("ReviewCd");
	}

	// Token: 0x0600B588 RID: 46472 RVA: 0x00304C9C File Offset: 0x00302E9C
	public int? OpenReviewDelay()
	{
		return ConfigCommonParamById.GetIntConfig("OpenReviewDelay");
	}

	// Token: 0x0600B589 RID: 46473 RVA: 0x00304CA8 File Offset: 0x00302EA8
	public float GetPlayPointTrackRange()
	{
		return ConfigCommonParamById.GetFloatConfig("PlayPointTrackExtraRadius").GetValueOrDefault();
	}

	// Token: 0x0600B58A RID: 46474 RVA: 0x00304CC8 File Offset: 0x00302EC8
	public int GetDiceItemId()
	{
		return ConfigCommonParamById.GetIntConfig("DangoMonopolyDiceItemId").GetValueOrDefault();
	}

	// Token: 0x0600B58B RID: 46475 RVA: 0x00304CE7 File Offset: 0x00302EE7
	[NullableContext(1)]
	public IReadOnlyList<float> GetDangoMonopolyRangeSpeed()
	{
		IReadOnlyList<float> result;
		if ((result = ConfigCommonParamById.GetFloatArrayConfig("DangoMonopolySpeed")) == null)
		{
			result = new <>z__ReadOnlyArray<float>(new float[]
			{
				1f,
				2f
			});
		}
		return result;
	}

	// Token: 0x0600B58C RID: 46476 RVA: 0x00304D14 File Offset: 0x00302F14
	public int GetAutoOpenNoticePatchSize()
	{
		return ConfigCommonParamById.GetIntConfig("AutoOpenNotifyPatchSize").GetValueOrDefault();
	}

	// Token: 0x0600B58D RID: 46477 RVA: 0x00304D33 File Offset: 0x00302F33
	[NullableContext(1)]
	public string GetGameIntroductionUrl()
	{
		return ConfigCommonParamById.GetStringConfig("GameIntroductionUrl") ?? string.Empty;
	}

	// Token: 0x0600B58E RID: 46478 RVA: 0x00304D48 File Offset: 0x00302F48
	[NullableContext(1)]
	public string GetGameIntroductionGlobalUrl()
	{
		return ConfigCommonParamById.GetStringConfig("GameIntroductionGlobalUrl") ?? string.Empty;
	}

	// Token: 0x0600B58F RID: 46479 RVA: 0x00304D5D File Offset: 0x00302F5D
	[NullableContext(1)]
	public string GetGuideMainlandLinkUrl()
	{
		return ConfigCommonParamById.GetStringConfig("GuideMainlandLink") ?? string.Empty;
	}

	// Token: 0x0600B590 RID: 46480 RVA: 0x00304D72 File Offset: 0x00302F72
	[NullableContext(1)]
	public string GetGuideOverseaLinkUrl()
	{
		return ConfigCommonParamById.GetStringConfig("GuideOverseaLink") ?? string.Empty;
	}

	// Token: 0x0600B591 RID: 46481 RVA: 0x00304D87 File Offset: 0x00302F87
	[NullableContext(1)]
	public IReadOnlyList<float> GetPhantomArenaBattleSpeed()
	{
		IReadOnlyList<float> result;
		if ((result = ConfigCommonParamById.GetFloatArrayConfig("PhantomArenaBattleSpeed")) == null)
		{
			result = new <>z__ReadOnlyArray<float>(new float[]
			{
				1f,
				1.5f,
				2f
			});
		}
		return result;
	}

	// Token: 0x0600B592 RID: 46482 RVA: 0x00304DB0 File Offset: 0x00302FB0
	public int GetGiftMaxNineNineNine()
	{
		return ConfigCommonParamById.GetIntConfig("GiftMaxNineNineNine").GetValueOrDefault();
	}

	// Token: 0x0600B593 RID: 46483 RVA: 0x00304DCF File Offset: 0x00302FCF
	[NullableContext(1)]
	public IReadOnlyList<string> GetPioneerPkgIdList()
	{
		return ConfigCommonParamById.GetStringArrayConfig("PioneerPkgIdList");
	}

	// Token: 0x0600B594 RID: 46484 RVA: 0x00304DDC File Offset: 0x00302FDC
	public int GetGachaJumpShopTabId()
	{
		return ConfigCommonParamById.GetIntConfig("GachaJumpShopTabId").GetValueOrDefault();
	}

	// Token: 0x0600B595 RID: 46485 RVA: 0x00304DFB File Offset: 0x00302FFB
	[NullableContext(1)]
	public IReadOnlyList<string> GetPanoramicUiDeferWhiteList()
	{
		return ConfigCommonParamById.GetStringArrayConfig("PanoramicUiDeferWhiteList") ?? Array.Empty<string>();
	}
}
