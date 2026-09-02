using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Qte.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002638 RID: 9784
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteNoIconLongPressView : CommonQteViewBase<CommonQteLongPressContext>
{
	// Token: 0x0601340F RID: 78863 RVA: 0x00559398 File Offset: 0x00557598
	public CommonQteNoIconLongPressView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013410 RID: 78864 RVA: 0x005593A4 File Offset: 0x005575A4
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013411 RID: 78865 RVA: 0x005593F4 File Offset: 0x005575F4
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteNoIconLongPressView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteNoIconLongPressView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013412 RID: 78866 RVA: 0x00559438 File Offset: 0x00557638
	protected override void OnStart()
	{
		base.OnStart();
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem != null)
		{
			qteItem.SetUiActive(false);
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(0));
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x06013413 RID: 78867 RVA: 0x00559487 File Offset: 0x00557687
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.SetQteView(null);
	}

	// Token: 0x06013414 RID: 78868 RVA: 0x005594B1 File Offset: 0x005576B1
	protected override void OnRefreshActionUi(string action)
	{
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.RefreshAction(action);
	}

	// Token: 0x06013415 RID: 78869 RVA: 0x005594C4 File Offset: 0x005576C4
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteLongPressContext;
	}

	// Token: 0x06013416 RID: 78870 RVA: 0x005594CF File Offset: 0x005576CF
	protected override void TryApplyQteIcon(CommonQteContextBase context)
	{
	}

	// Token: 0x06013417 RID: 78871 RVA: 0x005594D4 File Offset: 0x005576D4
	[NullableContext(2)]
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_LongPress scommonQte_LongPress = uiConfig as SCommonQte_LongPress;
		string qteText = ((scommonQte_LongPress != null) ? scommonQte_LongPress.UIConfig.TextId : null) ?? "";
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.SetQteText(qteText);
	}

	// Token: 0x06013418 RID: 78872 RVA: 0x00559514 File Offset: 0x00557714
	protected override void OnPlayQteStart()
	{
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem != null)
		{
			qteItem.SetUiActive(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("StartHaste", false, null, false);
		}
		if (!this.IsMobile && this.IsQteInteractive)
		{
			CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem2 = this.QteItem;
			if (qteItem2 == null)
			{
				return;
			}
			qteItem2.ShowKeyItem();
		}
	}

	// Token: 0x06013419 RID: 78873 RVA: 0x00559574 File Offset: 0x00557774
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (!(sequenceName == "StartHaste"))
		{
			if (sequenceName == "Close")
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonQteNoIconLongPressView, null);
			}
			return;
		}
		if (this.IsQteEnd)
		{
			return;
		}
		if (!this.IsMobile)
		{
			CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
			if (qteItem != null)
			{
				qteItem.ShowKeyItem();
			}
		}
		this.IsQteStart = true;
		this.IsQteInteractive = true;
	}

	// Token: 0x0601341A RID: 78874 RVA: 0x005595DC File Offset: 0x005577DC
	public void OnPress()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
	}

	// Token: 0x0601341B RID: 78875 RVA: 0x005595EC File Offset: 0x005577EC
	public void OnRelease()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Release, null);
	}

	// Token: 0x0601341C RID: 78876 RVA: 0x005595FC File Offset: 0x005577FC
	protected override void OnInputPress()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x0601341D RID: 78877 RVA: 0x0055961D File Offset: 0x0055781D
	protected override void OnInputRelease()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.ResponseEnd();
		}
	}

	// Token: 0x0601341E RID: 78878 RVA: 0x00559640 File Offset: 0x00557840
	protected override void OnHandleQteEnd()
	{
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem != null)
		{
			qteItem.HideKeyItem();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x0601341F RID: 78879 RVA: 0x00559691 File Offset: 0x00557891
	protected override void OnTickQteView(float delta)
	{
		CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		qteItem.RefreshProgress((commonQteContext != null) ? commonQteContext.GetProgress() : 0f);
	}

	// Token: 0x06013420 RID: 78880 RVA: 0x005596BC File Offset: 0x005578BC
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_LongPress scommonQte_LongPress = this.CommonQteContext.GetUiConfig() as SCommonQte_LongPress;
			if (scommonQte_LongPress != null)
			{
				SCommonQteButton uiconfig = scommonQte_LongPress.UIConfig;
				CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem qteItem = this.QteItem;
				UUIItem uuiitem = (qteItem != null) ? qteItem.GetRootItem() : null;
				if (uuiitem != null)
				{
					uuiitem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
				}
				if (uuiitem == null)
				{
					return;
				}
				uuiitem.SetAnchorOffset(uiconfig.AnchorOffset);
			}
		}
	}

	// Token: 0x04009661 RID: 38497
	[Nullable(2)]
	private CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem QteItem;

	// Token: 0x04009662 RID: 38498
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020089DA RID: 35290
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E815 RID: 190485
		PanelItem
	}

	// Token: 0x020089DB RID: 35291
	[NullableContext(0)]
	private enum EItemChildType
	{
		// Token: 0x0402E817 RID: 190487
		BtnMain,
		// Token: 0x0402E818 RID: 190488
		ProgressBar,
		// Token: 0x0402E819 RID: 190489
		Icon,
		// Token: 0x0402E81A RID: 190490
		KeyItem,
		// Token: 0x0402E81B RID: 190491
		TextPanel,
		// Token: 0x0402E81C RID: 190492
		Text
	}

	// Token: 0x020089DC RID: 35292
	[NullableContext(0)]
	private enum EItemChildPadType
	{
		// Token: 0x0402E81E RID: 190494
		BtnMain,
		// Token: 0x0402E81F RID: 190495
		ProgressBar,
		// Token: 0x0402E820 RID: 190496
		Icon,
		// Token: 0x0402E821 RID: 190497
		TextPanel,
		// Token: 0x0402E822 RID: 190498
		Text
	}

	// Token: 0x020089DD RID: 35293
	[NullableContext(2)]
	[Nullable(0)]
	private class CommonQteNoIconLongPressPanelItem : UiPanelBase
	{
		// Token: 0x06049341 RID: 299841 RVA: 0x013C0068 File Offset: 0x013BE268
		protected unsafe override void OnRegisterComponent()
		{
			this.IsMobile = Singleton<Info>.Instance.IsInTouch();
			int num;
			Span<ValueTuple<int, Type>> span;
			int num2;
			if (this.IsMobile)
			{
				num = 5;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
				this.ComponentRegisterInfos = list;
				return;
			}
			num2 = 6;
			List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
			num = 0;
			*span[num] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num++;
			*span[num] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num++;
			*span[num] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list2;
		}

		// Token: 0x06049342 RID: 299842 RVA: 0x013C0230 File Offset: 0x013BE430
		protected override UniTask OnBeforeStartAsync()
		{
			CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteNoIconLongPressView.CommonQteNoIconLongPressPanelItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06049343 RID: 299843 RVA: 0x013C0274 File Offset: 0x013BE474
		protected override void OnStart()
		{
			if (this.IsMobile)
			{
				this.BtnMain = base.GetButton(0);
				this.ProgressBar = base.GetTexture(1);
				UUISprite sprite = base.GetSprite(2);
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
			}
			else
			{
				this.BtnMain = base.GetButton(0);
				this.ProgressBar = base.GetTexture(1);
				UUISprite sprite2 = base.GetSprite(2);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
			}
			UUITexture progressBar = this.ProgressBar;
			if (progressBar != null)
			{
				progressBar.SetFillAmount(0f);
			}
			UUIButtonComponent btnMain = this.BtnMain;
			if (btnMain != null)
			{
				btnMain.OnPointDownCallBack.Bind(new Action(this.OnPress));
			}
			UUIButtonComponent btnMain2 = this.BtnMain;
			if (btnMain2 != null)
			{
				btnMain2.OnPointUpCallBack.Bind(new Action(this.OnRelease));
			}
			UUIButtonComponent btnMain3 = this.BtnMain;
			if (btnMain3 != null)
			{
				btnMain3.OnPointCancelCallBack.Bind(new Action(this.OnRelease));
			}
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Hide(null);
		}

		// Token: 0x06049344 RID: 299844 RVA: 0x013C0374 File Offset: 0x013BE574
		protected override void OnBeforeDestroy()
		{
			UUIButtonComponent btnMain = this.BtnMain;
			if (btnMain != null)
			{
				btnMain.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent btnMain2 = this.BtnMain;
			if (btnMain2 != null)
			{
				btnMain2.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent btnMain3 = this.BtnMain;
			if (btnMain3 != null)
			{
				btnMain3.OnPointCancelCallBack.Unbind();
			}
			this.QteView = null;
		}

		// Token: 0x06049345 RID: 299845 RVA: 0x013C03CA File Offset: 0x013BE5CA
		public void SetQteView(UiViewBase view)
		{
			if (view != null)
			{
				this.QteView = (view as CommonQteNoIconLongPressView);
				return;
			}
			this.QteView = null;
		}

		// Token: 0x06049346 RID: 299846 RVA: 0x013C03E4 File Offset: 0x013BE5E4
		[NullableContext(1)]
		public void RefreshAction(string action)
		{
			if (!this.IsMobile)
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = action
				};
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
			}
		}

		// Token: 0x06049347 RID: 299847 RVA: 0x013C0418 File Offset: 0x013BE618
		public void RefreshProgress(float progress)
		{
			UUITexture progressBar = this.ProgressBar;
			if (progressBar == null)
			{
				return;
			}
			progressBar.SetFillAmount(progress);
		}

		// Token: 0x06049348 RID: 299848 RVA: 0x013C042B File Offset: 0x013BE62B
		public void ShowKeyItem()
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Show(null);
		}

		// Token: 0x06049349 RID: 299849 RVA: 0x013C043E File Offset: 0x013BE63E
		public void HideKeyItem()
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Hide(null);
		}

		// Token: 0x0604934A RID: 299850 RVA: 0x013C0454 File Offset: 0x013BE654
		[NullableContext(1)]
		public void SetQteText(string textId)
		{
			if (!string.IsNullOrEmpty(textId))
			{
				UUIText text = base.GetText(this.IsMobile ? 4 : 5);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
				if (text != null)
				{
					text.SetUIActive(true);
				}
				UUIItem item = base.GetItem(this.IsMobile ? 3 : 4);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(this.IsMobile ? 3 : 4);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0604934B RID: 299851 RVA: 0x013C04D2 File Offset: 0x013BE6D2
		private void OnPress()
		{
			CommonQteNoIconLongPressView qteView = this.QteView;
			if (qteView == null)
			{
				return;
			}
			qteView.OnPress();
		}

		// Token: 0x0604934C RID: 299852 RVA: 0x013C04E4 File Offset: 0x013BE6E4
		private void OnRelease()
		{
			CommonQteNoIconLongPressView qteView = this.QteView;
			if (qteView == null)
			{
				return;
			}
			qteView.OnRelease();
		}

		// Token: 0x0402E823 RID: 190499
		private UUIButtonComponent BtnMain;

		// Token: 0x0402E824 RID: 190500
		private UUITexture ProgressBar;

		// Token: 0x0402E825 RID: 190501
		private UUISprite IconItem;

		// Token: 0x0402E826 RID: 190502
		private InputMultiKeyItem KeyItem;

		// Token: 0x0402E827 RID: 190503
		private CommonQteNoIconLongPressView QteView;

		// Token: 0x0402E828 RID: 190504
		private bool IsMobile;
	}
}
