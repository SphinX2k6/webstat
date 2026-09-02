using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028A7 RID: 10407
[NullableContext(1)]
[Nullable(0)]
public abstract class CommonRoleSkillBranchSwitchItem : UiPanelBase
{
	// Token: 0x06014A9C RID: 84636
	protected abstract SkillBranchSwitchItemGroup[] CollectBranchItems();

	// Token: 0x06014A9D RID: 84637
	protected abstract UUIExtendToggle GetBranchToggle();

	// Token: 0x06014A9E RID: 84638 RVA: 0x005B95BC File Offset: 0x005B77BC
	protected CommonRoleSkillBranchSwitchFunction CreateCommonRoleSkillBranchSwitchFunction()
	{
		return new CommonRoleSkillBranchSwitchFunction
		{
			Toggle = this.GetBranchToggle(),
			SkillItemGroups = this.CollectBranchItems(),
			SetSpriteByPath = delegate(string path, UUISprite uiSprite, bool setSize)
			{
				this.SetSpriteByPath(path, uiSprite, setSize, null, null);
			},
			SwitchBranchHandler = this.SwitchBranchHandler
		};
	}

	// Token: 0x06014A9F RID: 84639 RVA: 0x005B95F9 File Offset: 0x005B77F9
	protected override void OnStart()
	{
		this.CommonRoleSkillBranchSwitchFunction = this.CreateCommonRoleSkillBranchSwitchFunction();
	}

	// Token: 0x06014AA0 RID: 84640 RVA: 0x005B9607 File Offset: 0x005B7807
	protected void OnToggleStateChange(EToggleState state)
	{
		CommonRoleSkillBranchSwitchFunction commonRoleSkillBranchSwitchFunction = this.CommonRoleSkillBranchSwitchFunction;
		if (commonRoleSkillBranchSwitchFunction == null)
		{
			return;
		}
		commonRoleSkillBranchSwitchFunction.OnToggleStateChange(state);
	}

	// Token: 0x06014AA1 RID: 84641 RVA: 0x005B961A File Offset: 0x005B781A
	public void SetActiveBranchIndex(int index)
	{
		CommonRoleSkillBranchSwitchFunction commonRoleSkillBranchSwitchFunction = this.CommonRoleSkillBranchSwitchFunction;
		if (commonRoleSkillBranchSwitchFunction == null)
		{
			return;
		}
		commonRoleSkillBranchSwitchFunction.SetActiveBranchIndex(index);
	}

	// Token: 0x06014AA2 RID: 84642 RVA: 0x005B962D File Offset: 0x005B782D
	public void RefreshIcon(Func<int, string> handler)
	{
		CommonRoleSkillBranchSwitchFunction commonRoleSkillBranchSwitchFunction = this.CommonRoleSkillBranchSwitchFunction;
		if (commonRoleSkillBranchSwitchFunction == null)
		{
			return;
		}
		commonRoleSkillBranchSwitchFunction.RefreshIcon(handler);
	}

	// Token: 0x06014AA3 RID: 84643 RVA: 0x005B9640 File Offset: 0x005B7840
	public void SetToggleInteractive(bool interactive)
	{
		UUIExtendToggle branchToggle = this.GetBranchToggle();
		if (branchToggle == null)
		{
			return;
		}
		branchToggle.SetSelfInteractive(interactive);
	}

	// Token: 0x04009F60 RID: 40800
	[Nullable(2)]
	protected CommonRoleSkillBranchSwitchFunction CommonRoleSkillBranchSwitchFunction;

	// Token: 0x04009F61 RID: 40801
	[Nullable(2)]
	public Action<int> SwitchBranchHandler;
}
