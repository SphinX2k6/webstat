using System;
using Aki.Config;

// Token: 0x02002789 RID: 10121
public class RoleHandBookPreviewView : RolePreviewDescribeTabView
{
	// Token: 0x06013FA4 RID: 81828 RVA: 0x005917C4 File Offset: 0x0058F9C4
	protected override void SetCharacterVoiceInfo()
	{
		RoleInfo roleConfig = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance().GetRoleConfig();
		this.CharacterVoiceTitleText.SetUIActive(true);
		this.CharacterVoiceNameText.SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(this.CharacterVoiceTitleText, "CharacterVoice", Array.Empty<object>());
		this.CharacterVoiceNameText.ShowTextNew(roleConfig.CharacterVoice);
	}

	// Token: 0x06013FA5 RID: 81829 RVA: 0x00591828 File Offset: 0x0058FA28
	protected override void SetAttributeInfo()
	{
		int elementId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance().GetRoleConfig().ElementId;
		ElementInfo value = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId).Value;
		this.AttributeIconTexture.SetUIActive(true);
		this.AttributeText.SetUIActive(true);
		base.SetTextureByPath(value.Icon, this.AttributeIconTexture, null, null);
		this.AttributeText.ShowTextNew(value.Name);
	}
}
