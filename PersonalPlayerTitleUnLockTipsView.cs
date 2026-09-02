using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002436 RID: 9270
public class PersonalPlayerTitleUnLockTipsView : UiTickViewBase
{
	// Token: 0x06011EE1 RID: 73441 RVA: 0x004EF01A File Offset: 0x004ED21A
	[NullableContext(1)]
	public PersonalPlayerTitleUnLockTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011EE2 RID: 73442 RVA: 0x004EF023 File Offset: 0x004ED223
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x06011EE3 RID: 73443 RVA: 0x004EF048 File Offset: 0x004ED248
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalPlayerTitleUnLockTipsView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalPlayerTitleUnLockTipsView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011EE4 RID: 73444 RVA: 0x004EF08C File Offset: 0x004ED28C
	protected override void OnStart()
	{
		PersonalPlayerTitleData personalPlayerTitleData = (PersonalPlayerTitleData)this.OpenParam;
		if (personalPlayerTitleData == null)
		{
			base.CloseMe(null);
			return;
		}
		int sex = ModelBase<PersonalModel>.Instance.GetSex();
		this.PlayerTitleItem.Refresh(new int?(personalPlayerTitleData.PlayerTitleId), personalPlayerTitleData.StarLevel, new int?(sex));
	}

	// Token: 0x06011EE5 RID: 73445 RVA: 0x004EF0DD File Offset: 0x004ED2DD
	protected override void OnTick(float delta)
	{
		if (this.HaveClosed)
		{
			return;
		}
		this.CloseTimerDown += delta;
		if (this.CloseTimerDown >= 4000f)
		{
			this.HaveClosed = true;
			base.CloseMe(null);
		}
	}

	// Token: 0x04008C79 RID: 35961
	private const int CLOSE_TIME = 4000;

	// Token: 0x04008C7A RID: 35962
	[Nullable(2)]
	private PlayerTitleItem PlayerTitleItem;

	// Token: 0x04008C7B RID: 35963
	private float CloseTimerDown;

	// Token: 0x04008C7C RID: 35964
	private bool HaveClosed;

	// Token: 0x02008773 RID: 34675
	private enum EComponent
	{
		// Token: 0x0402DCBF RID: 187583
		ItemTitle
	}
}
