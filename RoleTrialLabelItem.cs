using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028FF RID: 10495
public class RoleTrialLabelItem : UiPanelBase
{
	// Token: 0x06014D94 RID: 85396 RVA: 0x005C6A48 File Offset: 0x005C4C48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06014D95 RID: 85397 RVA: 0x005C6AA4 File Offset: 0x005C4CA4
	public void Refresh(int roleId)
	{
		if (!RoleUtils.IsTrialRole(roleId))
		{
			return;
		}
		ETrialRoleType trialRoleType = RoleUtils.GetTrialRoleType(roleId);
		if (trialRoleType == ETrialRoleType.None)
		{
			return;
		}
		string text;
		FColor color = FColor.FromHex(this.trialRoleHexColor.TryGetValue((int)trialRoleType, out text) ? text : this.trialRoleHexColor[1]);
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetColor(color);
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetColor(color);
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RoleUtils.GetTrialRoleLabelIconByType(trialRoleType));
		this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
	}

	// Token: 0x0400A069 RID: 41065
	[Nullable(1)]
	private readonly Dictionary<int, string> trialRoleHexColor = new Dictionary<int, string>
	{
		{
			1,
			"ffffff"
		},
		{
			2,
			"fffca0"
		},
		{
			3,
			"bcf3ff"
		}
	};

	// Token: 0x02008C4F RID: 35919
	private enum EComponentType
	{
		// Token: 0x0402F41F RID: 193567
		FrameImg,
		// Token: 0x0402F420 RID: 193568
		IconImg,
		// Token: 0x0402F421 RID: 193569
		TrialTxt
	}
}
