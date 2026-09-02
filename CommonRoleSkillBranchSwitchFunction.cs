using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020028A6 RID: 10406
[NullableContext(2)]
[Nullable(0)]
public class CommonRoleSkillBranchSwitchFunction
{
	// Token: 0x06014A97 RID: 84631 RVA: 0x005B9468 File Offset: 0x005B7668
	public void OnToggleStateChange(EToggleState state)
	{
		int num = (state != EToggleState.ETT_Checked) ? 1 : 0;
		this.SetActiveBranchIndex(num);
		Action<int> switchBranchHandler = this.SwitchBranchHandler;
		if (switchBranchHandler == null)
		{
			return;
		}
		switchBranchHandler(num);
	}

	// Token: 0x06014A98 RID: 84632 RVA: 0x005B9498 File Offset: 0x005B7698
	private void SetSkillBranchState(int index, bool state)
	{
		SkillBranchSwitchItemGroup[] skillItemGroups = this.SkillItemGroups;
		SkillBranchSwitchItemGroup skillBranchSwitchItemGroup = (skillItemGroups != null) ? skillItemGroups[index] : null;
		if (skillBranchSwitchItemGroup == null)
		{
			return;
		}
		Action<bool> activeIndexHandler = skillBranchSwitchItemGroup.ActiveIndexHandler;
		if (activeIndexHandler == null)
		{
			return;
		}
		activeIndexHandler(state);
	}

	// Token: 0x06014A99 RID: 84633 RVA: 0x005B94CC File Offset: 0x005B76CC
	public void SetActiveBranchIndex(int index)
	{
		UUIExtendToggle toggle = this.Toggle;
		if (toggle != null)
		{
			toggle.SetToggleState((index == 1) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
		}
		int num = 0;
		for (;;)
		{
			int num2 = num;
			SkillBranchSwitchItemGroup[] skillItemGroups = this.SkillItemGroups;
			int? num3 = (skillItemGroups != null) ? new int?(skillItemGroups.Length) : null;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			this.SetSkillBranchState(num, num == index);
			num++;
		}
	}

	// Token: 0x06014A9A RID: 84634 RVA: 0x005B953C File Offset: 0x005B773C
	[NullableContext(1)]
	public void RefreshIcon(Func<int, string> handler)
	{
		int num = 0;
		for (;;)
		{
			int num2 = num;
			SkillBranchSwitchItemGroup[] skillItemGroups = this.SkillItemGroups;
			int? num3 = (skillItemGroups != null) ? new int?(skillItemGroups.Length) : null;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			SkillBranchSwitchItemGroup[] skillItemGroups2 = this.SkillItemGroups;
			UUISprite uuisprite = (skillItemGroups2 != null) ? skillItemGroups2[num].SpriteTagIcon : null;
			if (uuisprite != null)
			{
				Action<string, UUISprite, bool> setSpriteByPath = this.SetSpriteByPath;
				if (setSpriteByPath != null)
				{
					setSpriteByPath(handler(num), uuisprite, false);
				}
			}
			num++;
		}
	}

	// Token: 0x04009F5C RID: 40796
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public SkillBranchSwitchItemGroup[] SkillItemGroups;

	// Token: 0x04009F5D RID: 40797
	public Action<int> SwitchBranchHandler;

	// Token: 0x04009F5E RID: 40798
	public UUIExtendToggle Toggle;

	// Token: 0x04009F5F RID: 40799
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<string, UUISprite, bool> SetSpriteByPath;
}
