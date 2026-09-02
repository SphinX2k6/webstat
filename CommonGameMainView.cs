using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D15 RID: 7445
[NullableContext(1)]
[Nullable(0)]
public class CommonGameMainView : UiTickViewBase
{
	// Token: 0x0600DA9F RID: 55967 RVA: 0x003ABCAA File Offset: 0x003A9EAA
	public CommonGameMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DAA0 RID: 55968 RVA: 0x003ABCB3 File Offset: 0x003A9EB3
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600DAA1 RID: 55969 RVA: 0x003ABCEC File Offset: 0x003A9EEC
	protected override UniTask OnBeforeStartAsync()
	{
		CommonGameMainView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonGameMainView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAA2 RID: 55970 RVA: 0x003ABD2F File Offset: 0x003A9F2F
	protected override void OnStartImplementImplement()
	{
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.Start();
	}

	// Token: 0x0600DAA3 RID: 55971 RVA: 0x003ABD41 File Offset: 0x003A9F41
	protected override void OnBeforeShowImplementImplement()
	{
		base.OnBeforeShowImplementImplement();
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.BeforeShow();
	}

	// Token: 0x0600DAA4 RID: 55972 RVA: 0x003ABD59 File Offset: 0x003A9F59
	protected override void OnAfterShowImplement()
	{
		base.OnAfterShowImplement();
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.AfterShow();
	}

	// Token: 0x0600DAA5 RID: 55973 RVA: 0x003ABD71 File Offset: 0x003A9F71
	protected override void OnBeforeHide()
	{
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.BeforeHide();
	}

	// Token: 0x0600DAA6 RID: 55974 RVA: 0x003ABD83 File Offset: 0x003A9F83
	protected override void OnAfterHideImplementImplement()
	{
		base.OnAfterHideImplementImplement();
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.AfterHide();
	}

	// Token: 0x0600DAA7 RID: 55975 RVA: 0x003ABD9B File Offset: 0x003A9F9B
	protected override void OnAddEventListener()
	{
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.AddEventListener();
	}

	// Token: 0x0600DAA8 RID: 55976 RVA: 0x003ABDAD File Offset: 0x003A9FAD
	protected override void OnRemoveEventListener()
	{
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.RemoveEventListener();
	}

	// Token: 0x0600DAA9 RID: 55977 RVA: 0x003ABDC0 File Offset: 0x003A9FC0
	protected override void OnTick(float delta)
	{
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		float delta2 = delta * ((instance != null) ? instance.InverseSelfCenteredTimeDilation : 1f);
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.Tick(delta2);
	}

	// Token: 0x0600DAAA RID: 55978 RVA: 0x003ABDF8 File Offset: 0x003A9FF8
	protected override void OnAfterTick(float delta)
	{
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		float delta2 = delta * ((instance != null) ? instance.InverseSelfCenteredTimeDilation : 1f);
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.AfterTick(delta2);
	}

	// Token: 0x0600DAAB RID: 55979 RVA: 0x003ABE2E File Offset: 0x003AA02E
	protected override void OnBeforeDestroy()
	{
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.BeforeDestroy();
	}

	// Token: 0x0600DAAC RID: 55980 RVA: 0x003ABE40 File Offset: 0x003AA040
	public UUIItem GetContentPanel()
	{
		return base.GetItem(0);
	}

	// Token: 0x0600DAAD RID: 55981 RVA: 0x003ABE49 File Offset: 0x003AA049
	public void SetMaskItemActive(bool active)
	{
		base.GetItem(1).SetUIActive(active);
	}

	// Token: 0x0600DAAE RID: 55982 RVA: 0x003ABE58 File Offset: 0x003AA058
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		GameMainViewProxy viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return null;
		}
		return viewProxy.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x0600DAAF RID: 55983 RVA: 0x003ABE6C File Offset: 0x003AA06C
	protected override UniTask OnPlayingHideSequenceAsync()
	{
		CommonGameMainView.<OnPlayingHideSequenceAsync>d__18 <OnPlayingHideSequenceAsync>d__;
		<OnPlayingHideSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingHideSequenceAsync>d__.<>4__this = this;
		<OnPlayingHideSequenceAsync>d__.<>1__state = -1;
		<OnPlayingHideSequenceAsync>d__.<>t__builder.Start<CommonGameMainView.<OnPlayingHideSequenceAsync>d__18>(ref <OnPlayingHideSequenceAsync>d__);
		return <OnPlayingHideSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400686A RID: 26730
	[Nullable(2)]
	private GameMainViewProxy ViewProxy;

	// Token: 0x02008085 RID: 32901
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BB70 RID: 179056
		public const int ContentPanel = 0;

		// Token: 0x0402BB71 RID: 179057
		public const int MaskItem = 1;
	}
}
