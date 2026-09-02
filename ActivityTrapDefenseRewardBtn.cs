using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015E4 RID: 5604
[NullableContext(1)]
[Nullable(0)]
public class ActivityTrapDefenseRewardBtn : UiPanelBase
{
	// Token: 0x06009DBB RID: 40379 RVA: 0x002946A4 File Offset: 0x002928A4
	public UniTask Init(UUIItem item)
	{
		ActivityTrapDefenseRewardBtn.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ActivityTrapDefenseRewardBtn.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06009DBC RID: 40380 RVA: 0x002946EF File Offset: 0x002928EF
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x06009DBD RID: 40381 RVA: 0x002946F4 File Offset: 0x002928F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnSelf))
		};
	}

	// Token: 0x06009DBE RID: 40382 RVA: 0x00294787 File Offset: 0x00292987
	protected override void OnStart()
	{
		this.SetRedDotVisible(false);
	}

	// Token: 0x06009DBF RID: 40383 RVA: 0x00294790 File Offset: 0x00292990
	protected override void OnBeforeShow()
	{
	}

	// Token: 0x06009DC0 RID: 40384 RVA: 0x00294792 File Offset: 0x00292992
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06009DC1 RID: 40385 RVA: 0x0029479A File Offset: 0x0029299A
	public void SetEnableClick(bool state)
	{
		this.GetBtn().SetSelfInteractive(state);
	}

	// Token: 0x06009DC2 RID: 40386 RVA: 0x002947A8 File Offset: 0x002929A8
	public void SetRedDotVisible(bool visible)
	{
		this.GetRedDotItem().SetUIActive(visible);
	}

	// Token: 0x06009DC3 RID: 40387 RVA: 0x002947B6 File Offset: 0x002929B6
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, this.GetRedDotItem(), null, uId);
		}
	}

	// Token: 0x06009DC4 RID: 40388 RVA: 0x002947EA File Offset: 0x002929EA
	public void BindGivenUid(ERedDotName redDotName, int uId)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, this.GetRedDotItem(), null, uId);
		}
	}

	// Token: 0x06009DC5 RID: 40389 RVA: 0x00294818 File Offset: 0x00292A18
	public void UnBindGivenUid(int uId)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, this.GetRedDotItem(), uId);
		}
	}

	// Token: 0x06009DC6 RID: 40390 RVA: 0x00294843 File Offset: 0x00292A43
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x06009DC7 RID: 40391 RVA: 0x00294873 File Offset: 0x00292A73
	public UUIButtonComponent GetBtn()
	{
		return base.GetButton(0);
	}

	// Token: 0x06009DC8 RID: 40392 RVA: 0x0029487C File Offset: 0x00292A7C
	public UUIItem GetRedDotItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x06009DC9 RID: 40393 RVA: 0x00294885 File Offset: 0x00292A85
	public UUIText GetTitleText()
	{
		return base.GetText(1);
	}

	// Token: 0x06009DCA RID: 40394 RVA: 0x0029488E File Offset: 0x00292A8E
	public UUIText GetProgressText()
	{
		return base.GetText(2);
	}

	// Token: 0x06009DCB RID: 40395 RVA: 0x00294897 File Offset: 0x00292A97
	private void OnClickBtnSelf()
	{
		Action onClickBtnCallback = this.OnClickBtnCallback;
		if (onClickBtnCallback == null)
		{
			return;
		}
		onClickBtnCallback();
	}

	// Token: 0x0400489A RID: 18586
	public ERedDotName? RedDotName;

	// Token: 0x0400489B RID: 18587
	[Nullable(2)]
	public Action OnClickBtnCallback;

	// Token: 0x02007998 RID: 31128
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x04029C2C RID: 171052
		public const int BtnSelf = 0;

		// Token: 0x04029C2D RID: 171053
		public const int TextTitle = 1;

		// Token: 0x04029C2E RID: 171054
		public const int TextProgress = 2;

		// Token: 0x04029C2F RID: 171055
		public const int ItemRedDot = 3;
	}
}
