using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001D7E RID: 7550
[NullableContext(2)]
[Nullable(0)]
public class SpringManorMainViewProxy : GameMainViewProxy
{
	// Token: 0x17001177 RID: 4471
	// (get) Token: 0x0600DE27 RID: 56871 RVA: 0x003BBEC4 File Offset: 0x003BA0C4
	protected override EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason
	{
		get
		{
			return null;
		}
	}

	// Token: 0x0600DE28 RID: 56872 RVA: 0x003BBEDC File Offset: 0x003BA0DC
	protected override UniTask OnBeforeStartAsync()
	{
		SpringManorMainViewProxy.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorMainViewProxy.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE29 RID: 56873 RVA: 0x003BBF20 File Offset: 0x003BA120
	private UniTask CreateMainHudPanel()
	{
		SpringManorMainViewProxy.<CreateMainHudPanel>d__6 <CreateMainHudPanel>d__;
		<CreateMainHudPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMainHudPanel>d__.<>4__this = this;
		<CreateMainHudPanel>d__.<>1__state = -1;
		<CreateMainHudPanel>d__.<>t__builder.Start<SpringManorMainViewProxy.<CreateMainHudPanel>d__6>(ref <CreateMainHudPanel>d__);
		return <CreateMainHudPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE2A RID: 56874 RVA: 0x003BBF64 File Offset: 0x003BA164
	private UniTask CreateMobileBtnPanel()
	{
		SpringManorMainViewProxy.<CreateMobileBtnPanel>d__7 <CreateMobileBtnPanel>d__;
		<CreateMobileBtnPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileBtnPanel>d__.<>4__this = this;
		<CreateMobileBtnPanel>d__.<>1__state = -1;
		<CreateMobileBtnPanel>d__.<>t__builder.Start<SpringManorMainViewProxy.<CreateMobileBtnPanel>d__7>(ref <CreateMobileBtnPanel>d__);
		return <CreateMobileBtnPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE2B RID: 56875 RVA: 0x003BBFA8 File Offset: 0x003BA1A8
	private UniTask CreateDesktopBtnPanel()
	{
		SpringManorMainViewProxy.<CreateDesktopBtnPanel>d__8 <CreateDesktopBtnPanel>d__;
		<CreateDesktopBtnPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopBtnPanel>d__.<>4__this = this;
		<CreateDesktopBtnPanel>d__.<>1__state = -1;
		<CreateDesktopBtnPanel>d__.<>t__builder.Start<SpringManorMainViewProxy.<CreateDesktopBtnPanel>d__8>(ref <CreateDesktopBtnPanel>d__);
		return <CreateDesktopBtnPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE2C RID: 56876 RVA: 0x003BBFEC File Offset: 0x003BA1EC
	private UniTask CreateMobileSkillPanelInner()
	{
		SpringManorMainViewProxy.<CreateMobileSkillPanelInner>d__9 <CreateMobileSkillPanelInner>d__;
		<CreateMobileSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanelInner>d__.<>4__this = this;
		<CreateMobileSkillPanelInner>d__.<>1__state = -1;
		<CreateMobileSkillPanelInner>d__.<>t__builder.Start<SpringManorMainViewProxy.<CreateMobileSkillPanelInner>d__9>(ref <CreateMobileSkillPanelInner>d__);
		return <CreateMobileSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE2D RID: 56877 RVA: 0x003BC030 File Offset: 0x003BA230
	private UniTask CreateDesktopSkillPanelInner()
	{
		SpringManorMainViewProxy.<CreateDesktopSkillPanelInner>d__10 <CreateDesktopSkillPanelInner>d__;
		<CreateDesktopSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanelInner>d__.<>4__this = this;
		<CreateDesktopSkillPanelInner>d__.<>1__state = -1;
		<CreateDesktopSkillPanelInner>d__.<>t__builder.Start<SpringManorMainViewProxy.<CreateDesktopSkillPanelInner>d__10>(ref <CreateDesktopSkillPanelInner>d__);
		return <CreateDesktopSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x04006AA9 RID: 27305
	[Nullable(1)]
	public SpringManorMainHudPanel MainHudPanel;

	// Token: 0x04006AAA RID: 27306
	public SpringManorSkillPanel MobileSkillPanel;

	// Token: 0x04006AAB RID: 27307
	public SpringManorSkillPanel DesktopSkillPanel;
}
