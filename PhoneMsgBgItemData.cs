using System;
using Aki.Config;
using CSharpScript.Game.Module.PhoneMessage;

// Token: 0x02002566 RID: 9574
public class PhoneMsgBgItemData
{
	// Token: 0x060129F4 RID: 76276 RVA: 0x00522204 File Offset: 0x00520404
	public ChatBg GetConfig()
	{
		return ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(this.BgId).Value;
	}

	// Token: 0x060129F5 RID: 76277 RVA: 0x00522229 File Offset: 0x00520429
	public bool IsHasRedDot()
	{
		return ModelBase<PhoneMsgModel>.Instance.IsChatShowHasRedDotById(this.BgId);
	}

	// Token: 0x04009167 RID: 37223
	public int BgId;

	// Token: 0x04009168 RID: 37224
	public bool IsSelected;

	// Token: 0x04009169 RID: 37225
	public bool IsUsing;

	// Token: 0x0400916A RID: 37226
	public bool IsUnlocked;
}
