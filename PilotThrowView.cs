using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025EF RID: 9711
[NullableContext(1)]
[Nullable(0)]
public class PilotThrowView : UiTickViewBase, IUiProhibitRefreshData
{
	// Token: 0x06013071 RID: 77937 RVA: 0x00546598 File Offset: 0x00544798
	public PilotThrowView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06013072 RID: 77938 RVA: 0x005465AC File Offset: 0x005447AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBackBtnClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnLaunchBtnClick))
		};
	}

	// Token: 0x06013073 RID: 77939 RVA: 0x00546670 File Offset: 0x00544870
	protected override UniTask OnBeforeStartAsync()
	{
		PilotThrowView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PilotThrowView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013074 RID: 77940 RVA: 0x005466B4 File Offset: 0x005448B4
	protected override void OnStart()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayLevelSequenceByName("Number_In", false, null, false);
		}
		this.RegisterExtraUiProhibitRefresh();
	}

	// Token: 0x06013075 RID: 77941 RVA: 0x005466E8 File Offset: 0x005448E8
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		ControllerBase<PilotThrowController>.Instance.GenerateProjectilePoints();
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
	}

	// Token: 0x06013076 RID: 77942 RVA: 0x00546718 File Offset: 0x00544918
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		ControllerBase<PilotThrowController>.Instance.ClearProjectilePoints();
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitSpecialGameplayCamera();
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
	}

	// Token: 0x06013077 RID: 77943 RVA: 0x0054676A File Offset: 0x0054496A
	protected override void OnBeforeDestroy()
	{
		this.UnRegisterExtraUiProhibitRefresh();
	}

	// Token: 0x06013078 RID: 77944 RVA: 0x00546772 File Offset: 0x00544972
	private void InitSequencePlayer()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06013079 RID: 77945 RVA: 0x00546788 File Offset: 0x00544988
	private UniTask InitTargetItems(IReadOnlyList<IPilotThrowTarget> targetConfigs)
	{
		PilotThrowView.<InitTargetItems>d__10 <InitTargetItems>d__;
		<InitTargetItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTargetItems>d__.<>4__this = this;
		<InitTargetItems>d__.targetConfigs = targetConfigs;
		<InitTargetItems>d__.<>1__state = -1;
		<InitTargetItems>d__.<>t__builder.Start<PilotThrowView.<InitTargetItems>d__10>(ref <InitTargetItems>d__);
		return <InitTargetItems>d__.<>t__builder.Task;
	}

	// Token: 0x0601307A RID: 77946 RVA: 0x005467D4 File Offset: 0x005449D4
	protected override void OnTick(float delta)
	{
		foreach (PilotThrowTargetItem pilotThrowTargetItem in this.TargetItem)
		{
			pilotThrowTargetItem.OnTick(delta);
		}
	}

	// Token: 0x0601307B RID: 77947 RVA: 0x00546828 File Offset: 0x00544A28
	private void OnBackBtnClick()
	{
		ControllerBase<PilotThrowController>.Instance.RequestChangePilotState(false);
		ControllerBase<LevelPlayController>.Instance.LogReportMotorcycleLevelPlay(ModelBase<PilotThrowModel>.Instance.GetCurrentInteractHookPoint(), EMotorcycleLevelPlayType.PilotThrow, null, 1, 1);
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null && getCurrentEntity.Entity != null)
		{
			CharacterSkillComponent component = getCurrentEntity.Entity.GetComponent<CharacterSkillComponent>();
			if (component != null)
			{
				component.StopAllSkills("铁驭中断,停止技能");
			}
		}
		foreach (PilotThrowTargetItem pilotThrowTargetItem in this.TargetItem)
		{
			pilotThrowTargetItem.Close();
		}
		this.TargetItem.Clear();
		base.CloseMe(null);
	}

	// Token: 0x0601307C RID: 77948 RVA: 0x005468E8 File Offset: 0x00544AE8
	private void OnLaunchBtnClick()
	{
		ControllerBase<PilotThrowController>.Instance.RequestChangePilotState(true);
		ControllerBase<LevelPlayController>.Instance.LogReportMotorcycleLevelPlay(ModelBase<PilotThrowModel>.Instance.GetCurrentInteractHookPoint(), EMotorcycleLevelPlayType.PilotThrow, null, 2, 1);
		foreach (PilotThrowTargetItem pilotThrowTargetItem in this.TargetItem)
		{
			pilotThrowTargetItem.Close();
		}
		this.TargetItem.Clear();
		this.CloseMeAsync().Forget<bool>();
	}

	// Token: 0x0601307D RID: 77949 RVA: 0x0054697C File Offset: 0x00544B7C
	private void OnTeleportStart(bool loading)
	{
		foreach (PilotThrowTargetItem pilotThrowTargetItem in this.TargetItem)
		{
			pilotThrowTargetItem.Close();
		}
		this.TargetItem.Clear();
		this.CloseMeAsync().Forget<bool>();
	}

	// Token: 0x0601307E RID: 77950 RVA: 0x005469E4 File Offset: 0x00544BE4
	public bool CheckCondition()
	{
		return true;
	}

	// Token: 0x0601307F RID: 77951 RVA: 0x005469E7 File Offset: 0x00544BE7
	public string[] GetDistributeTags()
	{
		return new string[]
		{
			"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
			"UiInputRoot"
		};
	}

	// Token: 0x06013080 RID: 77952 RVA: 0x005469FF File Offset: 0x00544BFF
	private void RegisterExtraUiProhibitRefresh()
	{
		Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
	}

	// Token: 0x06013081 RID: 77953 RVA: 0x00546A1C File Offset: 0x00544C1C
	private void UnRegisterExtraUiProhibitRefresh()
	{
		Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
	}

	// Token: 0x06013082 RID: 77954 RVA: 0x00546A38 File Offset: 0x00544C38
	private void OnTargetInOutRange(bool inRange)
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopSequenceByKey("Ready_In", false, false);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 != null)
		{
			sequencePlayer2.StopSequenceByKey("Ready_Out", false, false);
		}
		LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
		if (sequencePlayer3 == null)
		{
			return;
		}
		sequencePlayer3.PlayLevelSequenceByName(inRange ? "Ready_In" : "Ready_Out", false, null, false);
	}

	// Token: 0x04009474 RID: 38004
	private readonly List<PilotThrowTargetItem> TargetItem = new List<PilotThrowTargetItem>();

	// Token: 0x04009475 RID: 38005
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04009476 RID: 38006
	private const string NUMBERIN_ANIM = "Number_In";

	// Token: 0x02008981 RID: 35201
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402E656 RID: 190038
		public const int BackBtn = 0;

		// Token: 0x0402E657 RID: 190039
		public const int FallPointCountText = 1;

		// Token: 0x0402E658 RID: 190040
		public const int BtnLaunch = 2;

		// Token: 0x0402E659 RID: 190041
		public const int MarkRoot = 3;

		// Token: 0x0402E65A RID: 190042
		public const int AimItem = 4;
	}
}
