using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020021FC RID: 8700
[NullableContext(1)]
[Nullable(0)]
public class LordGymFirstBossSelectView : LordGymLordEntranceSelectView
{
	// Token: 0x17001448 RID: 5192
	// (get) Token: 0x060106A1 RID: 67233 RVA: 0x0047C962 File Offset: 0x0047AB62
	protected override string ConfirmTextId
	{
		get
		{
			return "PrefabTextItem_1.0LordChooseBoss_Text";
		}
	}

	// Token: 0x060106A2 RID: 67234 RVA: 0x0047C969 File Offset: 0x0047AB69
	public LordGymFirstBossSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060106A3 RID: 67235 RVA: 0x0047C974 File Offset: 0x0047AB74
	protected override UniTask OnBeforeStartAsync()
	{
		LordGymFirstBossSelectView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordGymFirstBossSelectView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106A4 RID: 67236 RVA: 0x0047C9B7 File Offset: 0x0047ABB7
	protected override void OnStart()
	{
		this.AddHomeBtnExitDungeonCallback();
	}

	// Token: 0x060106A5 RID: 67237 RVA: 0x0047C9BF File Offset: 0x0047ABBF
	protected override void OnHandleLoadScene()
	{
		if (!Singleton<UiSceneManager>.Instance.HasLordSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
			ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
			ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceId(this.SelectedEntranceId, true, false);
			return;
		}
		ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
	}

	// Token: 0x060106A6 RID: 67238 RVA: 0x0047CA00 File Offset: 0x0047AC00
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymFirstBossSelectView.<OnHandlePostLoadSceneAsync>d__6 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymFirstBossSelectView.<OnHandlePostLoadSceneAsync>d__6>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106A7 RID: 67239 RVA: 0x0047CA44 File Offset: 0x0047AC44
	protected override UniTask OnHandlePreReleaseSceneAsync(bool isSceneRelease)
	{
		LordGymFirstBossSelectView.<OnHandlePreReleaseSceneAsync>d__7 <OnHandlePreReleaseSceneAsync>d__;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePreReleaseSceneAsync>d__.isSceneRelease = isSceneRelease;
		<OnHandlePreReleaseSceneAsync>d__.<>1__state = -1;
		<OnHandlePreReleaseSceneAsync>d__.<>t__builder.Start<LordGymFirstBossSelectView.<OnHandlePreReleaseSceneAsync>d__7>(ref <OnHandlePreReleaseSceneAsync>d__);
		return <OnHandlePreReleaseSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106A8 RID: 67240 RVA: 0x0047CA87 File Offset: 0x0047AC87
	protected override void OnHandleReleaseScene()
	{
		Singleton<UiSceneManager>.Instance.DestroyLordSkeletalHandle();
	}

	// Token: 0x060106A9 RID: 67241 RVA: 0x0047CA94 File Offset: 0x0047AC94
	protected override void OpenSelectView()
	{
		ModelBase<LordGymModel>.Instance.EntranceEntityId = this.SelectedEntranceId;
		LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
		{
			LordEntranceSetId = this.EntranceSetId,
			LordEntranceId = this.SelectedEntranceId,
			IsPlaySpecialSequence = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymFirstDifficultySelectView, param, null);
	}

	// Token: 0x060106AA RID: 67242 RVA: 0x0047CAE7 File Offset: 0x0047ACE7
	protected override void InitSelect()
	{
	}

	// Token: 0x060106AB RID: 67243 RVA: 0x0047CAEC File Offset: 0x0047ACEC
	protected UniTask InitSelectAsync()
	{
		LordGymFirstBossSelectView.<InitSelectAsync>d__11 <InitSelectAsync>d__;
		<InitSelectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSelectAsync>d__.<>4__this = this;
		<InitSelectAsync>d__.<>1__state = -1;
		<InitSelectAsync>d__.<>t__builder.Start<LordGymFirstBossSelectView.<InitSelectAsync>d__11>(ref <InitSelectAsync>d__);
		return <InitSelectAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106AC RID: 67244 RVA: 0x0047CB30 File Offset: 0x0047AD30
	protected UniTask SelectLordEntranceByIndexAsync(int index)
	{
		LordGymFirstBossSelectView.<SelectLordEntranceByIndexAsync>d__12 <SelectLordEntranceByIndexAsync>d__;
		<SelectLordEntranceByIndexAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SelectLordEntranceByIndexAsync>d__.<>4__this = this;
		<SelectLordEntranceByIndexAsync>d__.index = index;
		<SelectLordEntranceByIndexAsync>d__.<>1__state = -1;
		<SelectLordEntranceByIndexAsync>d__.<>t__builder.Start<LordGymFirstBossSelectView.<SelectLordEntranceByIndexAsync>d__12>(ref <SelectLordEntranceByIndexAsync>d__);
		return <SelectLordEntranceByIndexAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060106AD RID: 67245 RVA: 0x0047CB7B File Offset: 0x0047AD7B
	private void AddHomeBtnExitDungeonCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			LordGymFirstBossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__13_0>d <<AddHomeBtnExitDungeonCallback>b__13_0>d;
			<<AddHomeBtnExitDungeonCallback>b__13_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExitDungeonCallback>b__13_0>d.<>1__state = -1;
			<<AddHomeBtnExitDungeonCallback>b__13_0>d.<>t__builder.Start<LordGymFirstBossSelectView.<>c.<<AddHomeBtnExitDungeonCallback>b__13_0>d>(ref <<AddHomeBtnExitDungeonCallback>b__13_0>d);
			return <<AddHomeBtnExitDungeonCallback>b__13_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x060106AE RID: 67246 RVA: 0x0047CBAC File Offset: 0x0047ADAC
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
			});
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}
}
