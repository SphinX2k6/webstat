using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002325 RID: 8997
public class MotorMusicNewMusicTips : UiViewBase
{
	// Token: 0x060111DF RID: 70111 RVA: 0x004B3DCA File Offset: 0x004B1FCA
	[NullableContext(1)]
	public MotorMusicNewMusicTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060111E0 RID: 70112 RVA: 0x004B3DE0 File Offset: 0x004B1FE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
		};
	}

	// Token: 0x060111E1 RID: 70113 RVA: 0x004B3E48 File Offset: 0x004B2048
	protected override UniTask OnBeforeStartAsync()
	{
		MotorMusicNewMusicTips.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorMusicNewMusicTips.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060111E2 RID: 70114 RVA: 0x004B3E8B File Offset: 0x004B208B
	protected override void OnBeforeDestroy()
	{
		this.ClearTimer();
	}

	// Token: 0x060111E3 RID: 70115 RVA: 0x004B3E93 File Offset: 0x004B2093
	private void ClearTimer()
	{
		if (this.CloseTimer != null)
		{
			TimerSystem.Instance.Remove(this.CloseTimer);
			this.CloseTimer = null;
		}
	}

	// Token: 0x060111E4 RID: 70116 RVA: 0x004B3EB5 File Offset: 0x004B20B5
	private void OnCloseTimer(float delta)
	{
		base.CloseMe(null);
		this.CloseTimer = null;
	}

	// Token: 0x060111E5 RID: 70117 RVA: 0x004B3EC5 File Offset: 0x004B20C5
	private void OnClick()
	{
		base.CloseMe(null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhonographNewMusicView, new PhonographNewMusicViewOpenParam
		{
			UnlockMusicList = this.MusicIds
		}, null);
	}

	// Token: 0x04008692 RID: 34450
	[Nullable(1)]
	private List<int> MusicIds = new List<int>();

	// Token: 0x04008693 RID: 34451
	[Nullable(2)]
	private TimerHandle CloseTimer;

	// Token: 0x02008637 RID: 34359
	private class EComponents
	{
		// Token: 0x0402D645 RID: 185925
		public const int Btn = 0;

		// Token: 0x0402D646 RID: 185926
		public const int Txt = 1;
	}
}
