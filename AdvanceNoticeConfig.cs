using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001180 RID: 4480
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class AdvanceNoticeConfig : ConfigBase<AdvanceNoticeConfig>
{
	// Token: 0x06007607 RID: 30215 RVA: 0x001EE234 File Offset: 0x001EC434
	public AdvertisingPageInfo GetAdvertisingPageInfoById(int id)
	{
		return ConfigAdvertisingPageInfoById.GetConfig(id, true).Value;
	}

	// Token: 0x06007608 RID: 30216 RVA: 0x001EE250 File Offset: 0x001EC450
	public AdvertisingPageInfo GetAdvertisingPageInfoByActivityId(int activityId)
	{
		return ConfigAdvertisingPageInfoByActivityId.GetConfig(activityId, true).Value;
	}

	// Token: 0x06007609 RID: 30217 RVA: 0x001EE26C File Offset: 0x001EC46C
	public AdvertisingTabInfo GetAdvertisingTabInfoById(int id)
	{
		return ConfigAdvertisingTabInfoById.GetConfig(id, true).Value;
	}

	// Token: 0x0600760A RID: 30218 RVA: 0x001EE288 File Offset: 0x001EC488
	public AdvertisingTabCharacter GetAdvertisingTabCharacterById(int childTabId)
	{
		return ConfigAdvertisingTabCharacterById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x0600760B RID: 30219 RVA: 0x001EE2A4 File Offset: 0x001EC4A4
	public AdvertisingTabEnemy GetAdvertisingTabEnemyById(int childTabId)
	{
		return ConfigAdvertisingTabEnemyById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x0600760C RID: 30220 RVA: 0x001EE2C0 File Offset: 0x001EC4C0
	public AdvertisingTabStory GetAdvertisingTabStoryById(int childTabId)
	{
		return ConfigAdvertisingTabStoryById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x0600760D RID: 30221 RVA: 0x001EE2DC File Offset: 0x001EC4DC
	public AdvertisingTabRegion GetAdvertisingTabRegionById(int childTabId)
	{
		return ConfigAdvertisingTabRegionById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x0600760E RID: 30222 RVA: 0x001EE2F8 File Offset: 0x001EC4F8
	public AdvertisingTabCostume GetAdvertisingTabCostumeById(int childTabId)
	{
		return ConfigAdvertisingTabCostumeById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x0600760F RID: 30223 RVA: 0x001EE314 File Offset: 0x001EC514
	public AdvertisingTabActivity GetAdvertisingTabActivityById(int childTabId)
	{
		return ConfigAdvertisingTabActivityById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x06007610 RID: 30224 RVA: 0x001EE330 File Offset: 0x001EC530
	public AdvertisingTabSystem GetAdvertisingTabSystemById(int childTabId)
	{
		return ConfigAdvertisingTabSystemById.GetConfig(childTabId, true).Value;
	}

	// Token: 0x06007611 RID: 30225 RVA: 0x001EE34C File Offset: 0x001EC54C
	public AdvertisingUrlConfig GetAdvertisingUrlConfigById(int id)
	{
		return ConfigAdvertisingUrlConfigById.GetConfig(id, true).Value;
	}
}
