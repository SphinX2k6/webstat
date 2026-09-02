using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x02001DAE RID: 7598
public class TrapDefenseInterfaceLogic : ITrapDefenseMachineSelectInterface
{
	// Token: 0x0600E030 RID: 57392 RVA: 0x003C4AA9 File Offset: 0x003C2CA9
	[NullableContext(1)]
	public TrapDefenseInterfaceLogic(TrapDefenseMainViewProxy viewProxy)
	{
		this.ViewProxy = viewProxy;
	}

	// Token: 0x0600E031 RID: 57393 RVA: 0x003C4AB8 File Offset: 0x003C2CB8
	[NullableContext(2)]
	public void SelectMachine(TrapDefenseBuildingDevelopItemData data)
	{
		bool flag = data != null && data.IsBuilding;
		TrapDefenseMobileSkillPanel mobileSkillPanel = this.ViewProxy.MobileSkillPanel;
		if (mobileSkillPanel != null)
		{
			mobileSkillPanel.SetIsInBuild(flag);
		}
		TrapDefenseDesktopSkillPanel desktopSkillPanel = this.ViewProxy.DesktopSkillPanel;
		if (desktopSkillPanel != null)
		{
			desktopSkillPanel.RefreshButtonByIsInBuild(flag);
		}
		this.ViewProxy.BuildTipsPanel.SetIsInSelectBuild(flag);
		this.ViewProxy.BuildTipsPanel.ResetCannotMode();
		this.ViewProxy.MachineTipsPanel.SetMachineItem(data);
		TrapDefensePsFeedbackManager.TryRefreshFeedback();
	}

	// Token: 0x0600E032 RID: 57394 RVA: 0x003C4B37 File Offset: 0x003C2D37
	public void SliderPointerDown()
	{
		TrapDefenseMobileSkillPanel mobileSkillPanel = this.ViewProxy.MobileSkillPanel;
		if (mobileSkillPanel == null)
		{
			return;
		}
		mobileSkillPanel.HideBattleChildViewPanel();
	}

	// Token: 0x0600E033 RID: 57395 RVA: 0x003C4B4E File Offset: 0x003C2D4E
	[NullableContext(2)]
	public void SliderValueChange(TrapDefenseBuildingDevelopItemData data)
	{
		this.ViewProxy.MachineTipsPanel.SetMachineItem(data);
	}

	// Token: 0x0600E034 RID: 57396 RVA: 0x003C4B61 File Offset: 0x003C2D61
	public void SliderDragEnd()
	{
		TrapDefenseMobileSkillPanel mobileSkillPanel = this.ViewProxy.MobileSkillPanel;
		if (mobileSkillPanel == null)
		{
			return;
		}
		mobileSkillPanel.ShowBattleChildViewPanel();
	}

	// Token: 0x04006B9B RID: 27547
	[Nullable(1)]
	protected TrapDefenseMainViewProxy ViewProxy;
}
