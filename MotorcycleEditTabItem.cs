using System;
using Aki.Config;

// Token: 0x020022BE RID: 8894
public class MotorcycleEditTabItem : MotorcycleTabItem
{
	// Token: 0x06010D08 RID: 68872 RVA: 0x00499FAC File Offset: 0x004981AC
	protected override void OnStart()
	{
		base.OnStart();
		string stringConfig = ConfigCommonParamById.GetStringConfig("MotorEditRedDotIcon");
		if (!string.IsNullOrEmpty(stringConfig))
		{
			this.SetSpriteByPath(stringConfig, base.GetSprite(4), true, null, null);
		}
	}
}
