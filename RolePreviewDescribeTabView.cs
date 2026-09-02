using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D0B RID: 7435
[NullableContext(2)]
[Nullable(0)]
public class RolePreviewDescribeTabView : UiTabViewBase
{
	// Token: 0x0600DA6C RID: 55916 RVA: 0x003AB034 File Offset: 0x003A9234
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DA6D RID: 55917 RVA: 0x003AB163 File Offset: 0x003A9363
	protected override void OnStart()
	{
		this.InitText();
		this.PlayMontageStart();
	}

	// Token: 0x0600DA6E RID: 55918 RVA: 0x003AB171 File Offset: 0x003A9371
	protected override void OnBeforeDestroy()
	{
		this.CharacterVoiceTitleText = null;
		this.CharacterVoiceNameText = null;
		this.AttributeIconTexture = null;
		this.AttributeText = null;
	}

	// Token: 0x0600DA6F RID: 55919 RVA: 0x003AB190 File Offset: 0x003A9390
	private void InitText()
	{
		RoleInstance curSelectMainRoleInstance = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(curSelectMainRoleInstance.GetRoleId());
		if (roleConfig != null)
		{
			base.GetText(0).ShowTextNew(roleConfig.Value.Name);
			string weaponTypeName = ConfigBase<WeaponConfig>.Instance.GetWeaponTypeName(roleConfig.Value.WeaponType);
			base.GetText(1).SetText(weaponTypeName, true);
			base.GetText(2).ShowTextNew(roleConfig.Value.Introduction);
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "RoleFilterWeapon", Array.Empty<object>());
		this.CharacterVoiceTitleText = base.GetText(4);
		this.CharacterVoiceNameText = base.GetText(5);
		this.AttributeIconTexture = base.GetTexture(6);
		this.AttributeText = base.GetText(7);
		this.SetCharacterVoiceInfo();
		this.SetAttributeInfo();
	}

	// Token: 0x0600DA70 RID: 55920 RVA: 0x003AB27B File Offset: 0x003A947B
	protected virtual void SetCharacterVoiceInfo()
	{
		this.CharacterVoiceTitleText.SetUIActive(false);
		this.CharacterVoiceNameText.SetUIActive(false);
	}

	// Token: 0x0600DA71 RID: 55921 RVA: 0x003AB295 File Offset: 0x003A9495
	protected virtual void SetAttributeInfo()
	{
		this.AttributeIconTexture.SetUIActive(false);
		this.AttributeText.SetUIActive(false);
	}

	// Token: 0x0600DA72 RID: 55922 RVA: 0x003AB2AF File Offset: 0x003A94AF
	protected void PlayMontageStart()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
	}

	// Token: 0x0600DA73 RID: 55923 RVA: 0x003AB2BF File Offset: 0x003A94BF
	protected override void OnBeforeShow()
	{
		this.PlayMontageStart();
	}

	// Token: 0x04006845 RID: 26693
	protected UUIText CharacterVoiceTitleText;

	// Token: 0x04006846 RID: 26694
	protected UUIText CharacterVoiceNameText;

	// Token: 0x04006847 RID: 26695
	protected UUITexture AttributeIconTexture;

	// Token: 0x04006848 RID: 26696
	protected UUIText AttributeText;

	// Token: 0x02008083 RID: 32899
	[NullableContext(0)]
	private enum ERolePreviewDescribeTabViewCom
	{
		// Token: 0x0402BB66 RID: 179046
		NameText,
		// Token: 0x0402BB67 RID: 179047
		WeaponTypeText,
		// Token: 0x0402BB68 RID: 179048
		IntroductionText,
		// Token: 0x0402BB69 RID: 179049
		WeaponTitleText,
		// Token: 0x0402BB6A RID: 179050
		CharacterVoiceTitleText,
		// Token: 0x0402BB6B RID: 179051
		CharacterVoiceNameText,
		// Token: 0x0402BB6C RID: 179052
		AttributeIconTexture,
		// Token: 0x0402BB6D RID: 179053
		AttributeText
	}
}
