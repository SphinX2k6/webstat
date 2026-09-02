using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002207 RID: 8711
public class LordGymSecondBossSelectView : LordGymLordEntranceSelectView
{
	// Token: 0x0601070C RID: 67340 RVA: 0x0047D930 File Offset: 0x0047BB30
	[NullableContext(1)]
	public LordGymSecondBossSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601070D RID: 67341 RVA: 0x0047D939 File Offset: 0x0047BB39
	protected override void OnStart()
	{
		this.AddHomeBtnExitDungeonCallback();
	}

	// Token: 0x0601070E RID: 67342 RVA: 0x0047D941 File Offset: 0x0047BB41
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymSecondBossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__2_0>d <<AddHomeBtnExitDungeonCallback>b__2_0>d;
			<<AddHomeBtnExitDungeonCallback>b__2_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__2_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__2_0>d.<>t__builder.Start<LordGymSecondBossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__2_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__2_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__2_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x0601070F RID: 67343 RVA: 0x0047D974 File Offset: 0x0047BB74
	protected override void OpenSelectView()
	{
		ModelBase<LordGymModel>.Instance.EntranceEntityId = this.SelectedEntranceId;
		LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
		{
			LordEntranceSetId = this.EntranceSetId,
			LordEntranceId = this.SelectedEntranceId,
			IsPlaySpecialSequence = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymSecondDifficultySelectView, param, null);
	}

	// Token: 0x06010710 RID: 67344 RVA: 0x0047D9C8 File Offset: 0x0047BBC8
	protected override void InitSelect()
	{
		int index = 0;
		int entranceEntityId = ModelBase<LordGymModel>.Instance.EntranceEntityId;
		if (entranceEntityId > 0 && this.LordEntranceList != null)
		{
			int num = this.LordEntranceList.IndexOf(entranceEntityId);
			if (num >= 0)
			{
				index = num;
			}
		}
		this.SelectLordEntranceByIndex(index);
		base.ScrollEntranceIntoView(index);
		base.RefreshLordGymCurrency();
		LordGymModel instance = ModelBase<LordGymModel>.Instance;
		foreach (int entranceId in this.LordEntranceList)
		{
			instance.RecordNewLordGymEntrance(entranceId);
		}
	}

	// Token: 0x06010711 RID: 67345 RVA: 0x0047DA64 File Offset: 0x0047BC64
	protected override void OnCloseBtnClick()
	{
		if (!ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			base.CloseMe(null);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.GuideLordGymExitChallengeConfirm);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
			{
				base.CloseMe(null);
			}).Forget();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}
}
