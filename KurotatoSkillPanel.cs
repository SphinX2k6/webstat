using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.SkillButtonUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D24 RID: 7460
public class KurotatoSkillPanel : BattleChildViewPanel
{
	// Token: 0x0600DB75 RID: 56181 RVA: 0x003AF9AA File Offset: 0x003ADBAA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DB76 RID: 56182 RVA: 0x003AF9D0 File Offset: 0x003ADBD0
	public override UniTask InitializeAsync()
	{
		KurotatoSkillPanel.<InitializeAsync>d__3 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<KurotatoSkillPanel.<InitializeAsync>d__3>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB77 RID: 56183 RVA: 0x003AFA13 File Offset: 0x003ADC13
	protected override void OnStart()
	{
		ModelBase<KurotatoModel>.Instance.BattleData.InitBattleSkillData();
		this.RefreshDodgeSkillItem();
	}

	// Token: 0x0600DB78 RID: 56184 RVA: 0x003AFA2A File Offset: 0x003ADC2A
	private void RefreshDodgeSkillItem()
	{
		this.DodgeSkillItem.Refresh(ModelBase<KurotatoModel>.Instance.BattleData.GetBattleSkillData("闪避"));
	}

	// Token: 0x0600DB79 RID: 56185 RVA: 0x003AFA4B File Offset: 0x003ADC4B
	protected override void OnHideBattleChildViewPanel()
	{
		this.DodgeSkillItem.TryReleaseButton();
	}

	// Token: 0x0600DB7A RID: 56186 RVA: 0x003AFA58 File Offset: 0x003ADC58
	public override void OnTickBattleChildViewPanel(float delta)
	{
		if (!this.Visible)
		{
			return;
		}
		this.DodgeSkillItem.Tick(delta);
	}

	// Token: 0x0600DB7B RID: 56187 RVA: 0x003AFA70 File Offset: 0x003ADC70
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
	}

	// Token: 0x0600DB7C RID: 56188 RVA: 0x003AFAD0 File Offset: 0x003ADCD0
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Remove<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
	}

	// Token: 0x0600DB7D RID: 56189 RVA: 0x003AFB2E File Offset: 0x003ADD2E
	private void OnChangedTimeScale()
	{
		this.DodgeSkillItem.RefreshTimeDilation();
	}

	// Token: 0x0600DB7E RID: 56190 RVA: 0x003AFB3B File Offset: 0x003ADD3B
	private void OnPauseGame(int flag)
	{
		this.DodgeSkillItem.PauseGame(flag);
	}

	// Token: 0x0600DB7F RID: 56191 RVA: 0x003AFB49 File Offset: 0x003ADD49
	private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
	{
		if (buttonType == ESkillButtonType.闪避)
		{
			this.DodgeSkillItem.RefreshSkillCoolDown();
		}
	}

	// Token: 0x040068E2 RID: 26850
	[Nullable(2)]
	protected BattleSkillItem DodgeSkillItem;

	// Token: 0x020080A3 RID: 32931
	private static class EComponentDefine
	{
		// Token: 0x0402BC0A RID: 179210
		public const int Dodge = 0;
	}
}
