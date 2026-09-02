using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D45 RID: 7493
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleArrowMainViewProxy : GameMainViewProxy
{
	// Token: 0x17001169 RID: 4457
	// (get) Token: 0x0600DCE4 RID: 56548 RVA: 0x003B5C95 File Offset: 0x003B3E95
	protected override EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason
	{
		get
		{
			return new EBattleUiCommonChildVisibleReason?(EBattleUiCommonChildVisibleReason.MotorcycleArrowBattle);
		}
	}

	// Token: 0x0600DCE5 RID: 56549 RVA: 0x003B5CA0 File Offset: 0x003B3EA0
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleArrowMainViewProxy.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleArrowMainViewProxy.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCE6 RID: 56550 RVA: 0x003B5CE3 File Offset: 0x003B3EE3
	protected override void OnBeforeDestroy()
	{
		this.RemoveScreenEffectFightRoot();
	}

	// Token: 0x0600DCE7 RID: 56551 RVA: 0x003B5CEC File Offset: 0x003B3EEC
	private UniTask CreateFightInfoPanel()
	{
		MotorcycleArrowMainViewProxy.<CreateFightInfoPanel>d__8 <CreateFightInfoPanel>d__;
		<CreateFightInfoPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateFightInfoPanel>d__.<>4__this = this;
		<CreateFightInfoPanel>d__.<>1__state = -1;
		<CreateFightInfoPanel>d__.<>t__builder.Start<MotorcycleArrowMainViewProxy.<CreateFightInfoPanel>d__8>(ref <CreateFightInfoPanel>d__);
		return <CreateFightInfoPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCE8 RID: 56552 RVA: 0x003B5D30 File Offset: 0x003B3F30
	private UniTask CreateDesktopSkillPanel()
	{
		MotorcycleArrowMainViewProxy.<CreateDesktopSkillPanel>d__9 <CreateDesktopSkillPanel>d__;
		<CreateDesktopSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanel>d__.<>4__this = this;
		<CreateDesktopSkillPanel>d__.<>1__state = -1;
		<CreateDesktopSkillPanel>d__.<>t__builder.Start<MotorcycleArrowMainViewProxy.<CreateDesktopSkillPanel>d__9>(ref <CreateDesktopSkillPanel>d__);
		return <CreateDesktopSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCE9 RID: 56553 RVA: 0x003B5D74 File Offset: 0x003B3F74
	private UniTask CreateMobileSkillPanel()
	{
		MotorcycleArrowMainViewProxy.<CreateMobileSkillPanel>d__10 <CreateMobileSkillPanel>d__;
		<CreateMobileSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanel>d__.<>4__this = this;
		<CreateMobileSkillPanel>d__.<>1__state = -1;
		<CreateMobileSkillPanel>d__.<>t__builder.Start<MotorcycleArrowMainViewProxy.<CreateMobileSkillPanel>d__10>(ref <CreateMobileSkillPanel>d__);
		return <CreateMobileSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCEA RID: 56554 RVA: 0x003B5DB8 File Offset: 0x003B3FB8
	private UniTask CreateMobileSkillPanelInner()
	{
		MotorcycleArrowMainViewProxy.<CreateMobileSkillPanelInner>d__11 <CreateMobileSkillPanelInner>d__;
		<CreateMobileSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanelInner>d__.<>4__this = this;
		<CreateMobileSkillPanelInner>d__.<>1__state = -1;
		<CreateMobileSkillPanelInner>d__.<>t__builder.Start<MotorcycleArrowMainViewProxy.<CreateMobileSkillPanelInner>d__11>(ref <CreateMobileSkillPanelInner>d__);
		return <CreateMobileSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCEB RID: 56555 RVA: 0x003B5DFC File Offset: 0x003B3FFC
	private UniTask CreateDesktopSkillPanelInner()
	{
		MotorcycleArrowMainViewProxy.<CreateDesktopSkillPanelInner>d__12 <CreateDesktopSkillPanelInner>d__;
		<CreateDesktopSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanelInner>d__.<>4__this = this;
		<CreateDesktopSkillPanelInner>d__.<>1__state = -1;
		<CreateDesktopSkillPanelInner>d__.<>t__builder.Start<MotorcycleArrowMainViewProxy.<CreateDesktopSkillPanelInner>d__12>(ref <CreateDesktopSkillPanelInner>d__);
		return <CreateDesktopSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DCEC RID: 56556 RVA: 0x003B5E40 File Offset: 0x003B4040
	protected override void OnAfterShow()
	{
		this.FightInfoPanel.Show(null);
		MotorcycleArrowSkillPanel mobileSkillPanel = this.MobileSkillPanel;
		if (mobileSkillPanel != null)
		{
			mobileSkillPanel.Show(null);
		}
		MotorcycleArrowSkillPanel desktopSkillPanel = this.DesktopSkillPanel;
		if (desktopSkillPanel != null)
		{
			desktopSkillPanel.Show(null);
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Default, EBattleUiChild.MotorcycleMobileSkillButton, false, true, 0);
	}

	// Token: 0x0600DCED RID: 56557 RVA: 0x003B5E94 File Offset: 0x003B4094
	protected override void OnAfterHide()
	{
		this.FightInfoPanel.Hide(null);
		MotorcycleArrowSkillPanel mobileSkillPanel = this.MobileSkillPanel;
		if (mobileSkillPanel != null)
		{
			mobileSkillPanel.Hide(null);
		}
		MotorcycleArrowSkillPanel desktopSkillPanel = this.DesktopSkillPanel;
		if (desktopSkillPanel != null)
		{
			desktopSkillPanel.Hide(null);
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Default, EBattleUiChild.MotorcycleMobileSkillButton, true, true, 0);
	}

	// Token: 0x0600DCEE RID: 56558 RVA: 0x003B5EE8 File Offset: 0x003B40E8
	private void AddScreenEffectFightRoot()
	{
		BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
		if (!instance.IsValid())
		{
			return;
		}
		AUIContainerActor screenEffectFightRoot = null;
		instance.GetScreenEffectFightRoot(ref screenEffectFightRoot);
		this.ScreenEffectFightRoot = screenEffectFightRoot;
		AUIContainerActor screenEffectFightRoot2 = this.ScreenEffectFightRoot;
		if (screenEffectFightRoot2 != null)
		{
			screenEffectFightRoot2.K2_AttachRootComponentTo(this.View.GetContentPanel(), default(FName), EAttachLocation.KeepRelativeOffset, true);
		}
		ModelBase<ScreenEffectModel>.Instance.SetFightRootInited(true);
	}

	// Token: 0x0600DCEF RID: 56559 RVA: 0x003B5F47 File Offset: 0x003B4147
	private void RemoveScreenEffectFightRoot()
	{
		AUIContainerActor screenEffectFightRoot = this.ScreenEffectFightRoot;
		if (screenEffectFightRoot != null && screenEffectFightRoot.IsValid())
		{
			this.ScreenEffectFightRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
		}
		this.ScreenEffectFightRoot = null;
		ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SetFightRootInited(false);
	}

	// Token: 0x0600DCF0 RID: 56560 RVA: 0x003B5F84 File Offset: 0x003B4184
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "sword_skill"))
		{
			return null;
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			MotorcycleArrowSkillPanel mobileSkillPanel = this.MobileSkillPanel;
			if (mobileSkillPanel == null)
			{
				return null;
			}
			return mobileSkillPanel.GetSkillGuideItem();
		}
		else
		{
			MotorcycleArrowSkillPanel desktopSkillPanel = this.DesktopSkillPanel;
			if (desktopSkillPanel == null)
			{
				return null;
			}
			return desktopSkillPanel.GetSkillGuideItem();
		}
	}

	// Token: 0x040069C1 RID: 27073
	[Nullable(1)]
	public MotorcycleArrowBattleMain FightInfoPanel;

	// Token: 0x040069C2 RID: 27074
	public MotorcycleArrowSkillPanel MobileSkillPanel;

	// Token: 0x040069C3 RID: 27075
	public MotorcycleArrowSkillPanel DesktopSkillPanel;

	// Token: 0x040069C4 RID: 27076
	private AUIContainerActor ScreenEffectFightRoot;
}
