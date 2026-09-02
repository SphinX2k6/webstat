using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012DE RID: 4830
[NullableContext(2)]
[Nullable(0)]
public class DangoMonopolyBuffActiveView : DangoMonopolyViewBase
{
	// Token: 0x17000AF2 RID: 2802
	// (get) Token: 0x060082EB RID: 33515 RVA: 0x0022A65C File Offset: 0x0022885C
	public new DangoMonopolyBuffActiveViewParam OpenParam
	{
		get
		{
			return (DangoMonopolyBuffActiveViewParam)this.OpenParam;
		}
	}

	// Token: 0x060082EC RID: 33516 RVA: 0x0022A669 File Offset: 0x00228869
	[NullableContext(1)]
	public DangoMonopolyBuffActiveView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060082ED RID: 33517 RVA: 0x0022A680 File Offset: 0x00228880
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnEmpty))
		};
	}

	// Token: 0x060082EE RID: 33518 RVA: 0x0022A713 File Offset: 0x00228913
	private void InitDataParam()
	{
	}

	// Token: 0x060082EF RID: 33519 RVA: 0x0022A718 File Offset: 0x00228918
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyBuffActiveView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyBuffActiveView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060082F0 RID: 33520 RVA: 0x0022A75C File Offset: 0x0022895C
	public UniTask InitDangoActorList()
	{
		DangoMonopolyBuffActiveView.<InitDangoActorList>d__10 <InitDangoActorList>d__;
		<InitDangoActorList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDangoActorList>d__.<>4__this = this;
		<InitDangoActorList>d__.<>1__state = -1;
		<InitDangoActorList>d__.<>t__builder.Start<DangoMonopolyBuffActiveView.<InitDangoActorList>d__10>(ref <InitDangoActorList>d__);
		return <InitDangoActorList>d__.<>t__builder.Task;
	}

	// Token: 0x060082F1 RID: 33521 RVA: 0x0022A7A0 File Offset: 0x002289A0
	public void PlayDangoAni()
	{
		if (this.DangoActorList.Count == 0)
		{
			return;
		}
		TsUiSceneDangoActor tsUiSceneDangoActor = this.DangoActorList[0];
		int[] activeDangoAniInfo = ConfigBase<ActivityDangoMonopolyConfig>.Instance.GetActiveDangoAniInfo();
		if (activeDangoAniInfo != null && activeDangoAniInfo.Length >= 2)
		{
			int num = activeDangoAniInfo[0];
			int num2 = activeDangoAniInfo[1];
			tsUiSceneDangoActor.SetState((EDangoState)num, (float)num2, 0f);
		}
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(this.GetShowDangoId());
		if (dangoData != null && dangoData.DangoVoice != null)
		{
			Singleton<AudioSystem>.Instance.PostEvent(dangoData.DangoVoice);
		}
	}

	// Token: 0x060082F2 RID: 33522 RVA: 0x0022A822 File Offset: 0x00228A22
	private int GetShowDangoId()
	{
		DangoData dangoData = this.OpenParam.GridData.GetDangoData();
		if (dangoData == null)
		{
			return 0;
		}
		return dangoData.Id;
	}

	// Token: 0x060082F3 RID: 33523 RVA: 0x0022A840 File Offset: 0x00228A40
	private void DestroyDangoActor()
	{
		foreach (TsUiSceneDangoActor dango in this.DangoActorList)
		{
			Singleton<UiSceneManager>.Instance.DestroyDangoActor(dango);
		}
		this.DangoActorList.Clear();
	}

	// Token: 0x060082F4 RID: 33524 RVA: 0x0022A8A4 File Offset: 0x00228AA4
	protected override void OnStart()
	{
		this.ActivityData.UpdateBoardGridUiInfoShow(false).Forget();
	}

	// Token: 0x060082F5 RID: 33525 RVA: 0x0022A8B7 File Offset: 0x00228AB7
	protected override void OnBeforeShow()
	{
		this.UpdateData().Forget();
	}

	// Token: 0x060082F6 RID: 33526 RVA: 0x0022A8C4 File Offset: 0x00228AC4
	protected override void OnBeforeDestroy()
	{
		this.DestroyDangoActor();
		DangoMonopolyBuffActiveViewParam openParam = this.OpenParam;
		if (openParam != null)
		{
			CustomPromise promise = openParam.Promise;
			if (promise != null)
			{
				promise.SetResult();
			}
		}
		this.ActivityData.UpdateBoardGridUiInfoShow(true).Forget();
	}

	// Token: 0x060082F7 RID: 33527 RVA: 0x0022A8F9 File Offset: 0x00228AF9
	protected override void OnAfterDestroy()
	{
	}

	// Token: 0x060082F8 RID: 33528 RVA: 0x0022A8FC File Offset: 0x00228AFC
	public UniTask UpdateData()
	{
		DangoMonopolyBuffActiveView.<UpdateData>d__18 <UpdateData>d__;
		<UpdateData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateData>d__.<>4__this = this;
		<UpdateData>d__.<>1__state = -1;
		<UpdateData>d__.<>t__builder.Start<DangoMonopolyBuffActiveView.<UpdateData>d__18>(ref <UpdateData>d__);
		return <UpdateData>d__.<>t__builder.Task;
	}

	// Token: 0x060082F9 RID: 33529 RVA: 0x0022A93F File Offset: 0x00228B3F
	private void ShowDango()
	{
		this.SetBtnEmptyActive(true);
		this.PlayDangoAni();
	}

	// Token: 0x060082FA RID: 33530 RVA: 0x0022A94E File Offset: 0x00228B4E
	public void OnClickClose()
	{
		DangoMonopolyBuffActiveGetPanel getPanel = this.GetPanel;
		if (getPanel != null && getPanel.IsShow)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x060082FB RID: 33531 RVA: 0x0022A96B File Offset: 0x00228B6B
	protected override void OnHandleLoadScene()
	{
	}

	// Token: 0x060082FC RID: 33532 RVA: 0x0022A96D File Offset: 0x00228B6D
	private void OnClickBtnEmpty()
	{
		base.CloseMe(null);
	}

	// Token: 0x060082FD RID: 33533 RVA: 0x0022A978 File Offset: 0x00228B78
	public void SetBtnEmptyActive(bool active)
	{
		UUIButtonComponent button = base.GetButton(3);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(active);
	}

	// Token: 0x04003E17 RID: 15895
	public DangoMonopolyBuffActiveShowPanel ShowPanel;

	// Token: 0x04003E18 RID: 15896
	public DangoMonopolyBuffActiveGetPanel GetPanel;

	// Token: 0x04003E19 RID: 15897
	[Nullable(1)]
	public List<TsUiSceneDangoActor> DangoActorList = new List<TsUiSceneDangoActor>();

	// Token: 0x02007663 RID: 30307
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028CC0 RID: 167104
		ItemShow,
		// Token: 0x04028CC1 RID: 167105
		ItemGet,
		// Token: 0x04028CC2 RID: 167106
		ItemShowLayer,
		// Token: 0x04028CC3 RID: 167107
		BtnEmpty
	}
}
