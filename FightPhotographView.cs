using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025BB RID: 9659
public class FightPhotographView : PhotographView
{
	// Token: 0x06012E00 RID: 77312 RVA: 0x0053854C File Offset: 0x0053674C
	[NullableContext(1)]
	public FightPhotographView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012E01 RID: 77313 RVA: 0x00538558 File Offset: 0x00536758
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotographView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotographView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012E02 RID: 77314 RVA: 0x0053859B File Offset: 0x0053679B
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		ModelBase<FightPhotoModel>.Instance.RefreshTabList();
		base.RefreshFightPhotoOptionTab();
	}

	// Token: 0x06012E03 RID: 77315 RVA: 0x005385B4 File Offset: 0x005367B4
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.ColorAdjustOpenMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
		RenderModuleModel instance = ModelBase<RenderModuleModel>.Instance;
		if (instance != null)
		{
			instance.EnableForceTickCharRenderShell("FightPhotographView OnAfterShow");
		}
		Singleton<AudioSystem>.Instance.SetState("game_sys_fightphoto", "pause", true);
		this.TryAddTag();
	}

	// Token: 0x06012E04 RID: 77316 RVA: 0x0053860A File Offset: 0x0053680A
	protected override void OnAfterHide()
	{
		base.OnAfterHide();
		this.AccumulateColorAdjustDuration();
	}

	// Token: 0x06012E05 RID: 77317 RVA: 0x00538618 File Offset: 0x00536818
	private void AccumulateColorAdjustDuration()
	{
		if (this.ColorAdjustOpenMs > 0L)
		{
			FightPhotoController instance = ControllerBase<FightPhotoController>.Instance;
			if (instance != null)
			{
				instance.AddColorAdjustDuration(DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.ColorAdjustOpenMs);
			}
			this.ColorAdjustOpenMs = 0L;
		}
	}

	// Token: 0x06012E06 RID: 77318 RVA: 0x0053865B File Offset: 0x0053685B
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add(EEventName.NotifyBtFightPhotoTaskFinish, new Action(this.OnFightPhotoTaskFinish));
	}

	// Token: 0x06012E07 RID: 77319 RVA: 0x00538680 File Offset: 0x00536880
	protected override void OnAfterTick(float delta)
	{
		base.RefreshFightPhotoMissionState();
		if (ControllerBase<PhotographController>.Instance.CurrentBtNode == null || this.IsFinishTask)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null && uiViewSequence.HasSequenceNameInPlaying("Loop"))
			{
				this.UiViewSequence.StopSequenceByKey("Loop", false, true);
			}
			return;
		}
		bool flag = ControllerBase<PhotographController>.Instance.IsSatisfyAllConditions();
		if (this.LastStatus == flag)
		{
			return;
		}
		this.LastStatus = flag;
		if (flag)
		{
			this.UiViewSequence.PlaySequence("ShowChanging", false, null);
			this.UiViewSequence.PlaySequence("Loop", false, null);
			return;
		}
		this.UiViewSequence.StopSequenceByKey("Loop", false, true);
	}

	// Token: 0x06012E08 RID: 77320 RVA: 0x00538739 File Offset: 0x00536939
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.NotifyBtFightPhotoTaskFinish, new Action(this.OnFightPhotoTaskFinish));
	}

	// Token: 0x06012E09 RID: 77321 RVA: 0x00538760 File Offset: 0x00536960
	protected override void OnBeforeDestroy()
	{
		this.AccumulateColorAdjustDuration();
		RenderModuleModel instance = ModelBase<RenderModuleModel>.Instance;
		if (instance != null)
		{
			instance.DisableForceTickCharRenderShell("FightPhotographView OnBeforeDestroy");
		}
		Singleton<AudioSystem>.Instance.SetState("game_sys_fightphoto", "none", true);
		this.TryRemoveTag();
		PhotographController.SetFightPhotographSetupOption(EFightPhotoSetupOptionType.TiltAngle, 0, true);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.DLSS.EnableFixDof 0", null);
		base.OnBeforeDestroy();
	}

	// Token: 0x06012E0A RID: 77322 RVA: 0x005387C4 File Offset: 0x005369C4
	private void TryAddTag()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid || getCurrentEntity.Entity == null || !getCurrentEntity.Entity.Valid)
		{
			return;
		}
		BaseTagComponent component = getCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component != null && !component.HasTag(GameplayTagDefine.EGameplayTagId["系统.活动.拍照活动.虚化调整子镜头"]))
		{
			component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["系统.活动.拍照活动.虚化调整子镜头"]));
		}
	}

	// Token: 0x06012E0B RID: 77323 RVA: 0x00538840 File Offset: 0x00536A40
	private void TryRemoveTag()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid || getCurrentEntity.Entity == null || !getCurrentEntity.Entity.Valid)
		{
			return;
		}
		BaseTagComponent component = getCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["系统.活动.拍照活动.虚化调整子镜头"]))
		{
			component.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["系统.活动.拍照活动.虚化调整子镜头"]));
		}
	}

	// Token: 0x06012E0C RID: 77324 RVA: 0x005388BA File Offset: 0x00536ABA
	private void OnFightPhotoTaskFinish()
	{
		this.IsFinishTask = true;
	}

	// Token: 0x06012E0D RID: 77325 RVA: 0x005388C3 File Offset: 0x00536AC3
	protected override void OnBackButtonClicked()
	{
		if (ControllerBase<PhotographController>.Instance.IsFightPhotoCanSettle())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoResultView, null, null);
			return;
		}
		ControllerBase<PhotographController>.Instance.CloseFightPhotographMode();
		ControllerBase<FilterSettingController>.Instance.ApplyFilterSetting();
	}

	// Token: 0x04009398 RID: 37784
	private bool IsFinishTask;

	// Token: 0x04009399 RID: 37785
	private bool LastStatus;

	// Token: 0x0400939A RID: 37786
	private long ColorAdjustOpenMs;
}
