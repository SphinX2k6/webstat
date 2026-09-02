using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200220B RID: 8715
[NullableContext(1)]
[Nullable(0)]
public class LordGymThird5LittleLoadingView : UiViewBase, IUiCameraBehavior
{
	// Token: 0x0601073C RID: 67388 RVA: 0x0047E4A5 File Offset: 0x0047C6A5
	public LordGymThird5LittleLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601073D RID: 67389 RVA: 0x0047E4AE File Offset: 0x0047C6AE
	protected override void OnStartImplementImplement()
	{
		this.UiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnStartSequenceFinished), false);
	}

	// Token: 0x0601073E RID: 67390 RVA: 0x0047E4D0 File Offset: 0x0047C6D0
	protected override void OnHandleLoadScene()
	{
		if (!Singleton<UiSceneManager>.Instance.HasLordSkeletalHandle())
		{
			Singleton<UiSceneManager>.Instance.InitLordSkeletalHandle();
		}
		int initialLordEntranceId = this.GetInitialLordEntranceId();
		if (initialLordEntranceId > 0)
		{
			ControllerBase<LordGymController>.Instance.CreateLordModelByEntranceId();
			ControllerBase<LordGymController>.Instance.LoadLordModelByEntranceIdThird5(initialLordEntranceId, true, true);
			ModelBase<LordGymModel>.Instance.PreloadThird5SceneEffect(initialLordEntranceId);
		}
	}

	// Token: 0x0601073F RID: 67391 RVA: 0x0047E524 File Offset: 0x0047C724
	private int GetInitialLordEntranceId()
	{
		LordGymLordEntranceSelectViewParam lordGymLordEntranceSelectViewParam = this.OpenParam as LordGymLordEntranceSelectViewParam;
		LordGymEntranceSet? config = ConfigLordGymEntranceSetById.GetConfig((lordGymLordEntranceSelectViewParam != null) ? lordGymLordEntranceSelectViewParam.EntranceSetId : 0, true);
		if (config == null)
		{
			return 0;
		}
		int lordEntranceListLength = config.Value.LordEntranceListLength;
		if (lordEntranceListLength == 0)
		{
			return 0;
		}
		LordGymModel instance = ModelBase<LordGymModel>.Instance;
		int num = 0;
		if (instance.EntranceEntityId > 0 && Singleton<UiSceneManager>.Instance.HasLordSkeletalHandle())
		{
			int num2 = instance.EntranceEntityId;
			num = -1;
			for (int i = 0; i < lordEntranceListLength; i++)
			{
				if (config.Value.LordEntranceList(i) == num2)
				{
					num = i;
					break;
				}
			}
		}
		else
		{
			int num2 = instance.LastChallengeLordEntranceId;
			if (num2 > 0)
			{
				num = -1;
				for (int j = 0; j < lordEntranceListLength; j++)
				{
					if (config.Value.LordEntranceList(j) == num2)
					{
						num = j;
						break;
					}
				}
			}
		}
		num = ((num < 0) ? 0 : num);
		return config.Value.LordEntranceList(num);
	}

	// Token: 0x06010740 RID: 67392 RVA: 0x0047E61C File Offset: 0x0047C81C
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		LordGymThird5LittleLoadingView.<OnHandlePostLoadSceneAsync>d__7 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.<>4__this = this;
		<OnHandlePostLoadSceneAsync>d__.isSceneLoad = isSceneLoad;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<LordGymThird5LittleLoadingView.<OnHandlePostLoadSceneAsync>d__7>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010741 RID: 67393 RVA: 0x0047E668 File Offset: 0x0047C868
	private void OnStartSequenceFinished(string _)
	{
		if (this.IsAdvancing || string.IsNullOrEmpty(this.BossSettingsName))
		{
			return;
		}
		this.IsAdvancing = true;
		ModelBase<LordGymModel>.Instance.PlayThird5SceneEffect(this.GetInitialLordEntranceId());
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(this.BossSettingsName, true, true, "10015", false, delegate(UiCameraAnimationDefine.IFinishData handleData)
		{
			this.CloseAndOpenBossSelectView();
		}, null);
		base.PlaySequence("Sync", null, false);
	}

	// Token: 0x06010742 RID: 67394 RVA: 0x0047E6DD File Offset: 0x0047C8DD
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
	}

	// Token: 0x06010743 RID: 67395 RVA: 0x0047E6DF File Offset: 0x0047C8DF
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		if (this.StartHandle != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.StartHandle, null);
			this.StartHandle = null;
		}
	}

	// Token: 0x06010744 RID: 67396 RVA: 0x0047E704 File Offset: 0x0047C904
	private void CloseAndOpenBossSelectView()
	{
		LordGymLordEntranceSelectViewParam param = this.OpenParam as LordGymLordEntranceSelectViewParam;
		Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.LordGymThird5LittleLoadingView, EUiViewName.LordGymThird5BossSelectView, param, null, true);
	}

	// Token: 0x04008185 RID: 33157
	[Nullable(2)]
	private UiCameraHandleData StartHandle;

	// Token: 0x04008186 RID: 33158
	[Nullable(2)]
	private string BossSettingsName;

	// Token: 0x04008187 RID: 33159
	private bool IsAdvancing;
}
