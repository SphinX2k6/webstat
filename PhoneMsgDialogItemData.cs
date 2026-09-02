using System;
using Aki.Config;
using CSharpScript.Game.Module.PhoneMessage;

// Token: 0x02002565 RID: 9573
public class PhoneMsgDialogItemData
{
	// Token: 0x060129F0 RID: 76272 RVA: 0x005221BC File Offset: 0x005203BC
	public ChatDialog GetConfig()
	{
		return ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(this.DialogId).Value;
	}

	// Token: 0x060129F1 RID: 76273 RVA: 0x005221E1 File Offset: 0x005203E1
	public bool IsHasRedDot()
	{
		return ModelBase<PhoneMsgModel>.Instance.IsChatShowHasRedDotById(this.DialogId);
	}

	// Token: 0x04009163 RID: 37219
	public int DialogId;

	// Token: 0x04009164 RID: 37220
	public bool IsSelected;

	// Token: 0x04009165 RID: 37221
	public bool IsUsing;

	// Token: 0x04009166 RID: 37222
	public bool IsUnlocked;
}
