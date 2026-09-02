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

// Token: 0x02002637 RID: 9783
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteLongPressView : CommonQteViewBase<CommonQteLongPressContext>
{
	// Token: 0x060133FD RID: 78845 RVA: 0x00558FF6 File Offset: 0x005571F6
	public CommonQteLongPressView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060133FE RID: 78846 RVA: 0x00559000 File Offset: 0x00557200
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

	// Token: 0x060133FF RID: 78847 RVA: 0x00559050 File Offset: 0x00557250
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteLongPressView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteLongPressView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013400 RID: 78848 RVA: 0x00559094 File Offset: 0x00557294
	protected override void OnStart()
	{
		base.OnStart();
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem != null)
		{
			qteItem.SetUiActive(false);
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(0));
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x06013401 RID: 78849 RVA: 0x005590E3 File Offset: 0x005572E3
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.SetQteView(null);
	}

	// Token: 0x06013402 RID: 78850 RVA: 0x0055910D File Offset: 0x0055730D
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteLongPressContext;
	}

	// Token: 0x06013403 RID: 78851 RVA: 0x00559118 File Offset: 0x00557318
	protected override void OnRefreshActionUi(string action)
	{
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.RefreshAction(action);
	}

	// Token: 0x06013404 RID: 78852 RVA: 0x0055912B File Offset: 0x0055732B
	protected override void OnRefreshIcon(ULGUITexturePackerSpriteData sprite)
	{
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.RefreshIcon(sprite);
	}

	// Token: 0x06013405 RID: 78853 RVA: 0x00559140 File Offset: 0x00557340
	[NullableContext(2)]
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_LongPress scommonQte_LongPress = uiConfig as SCommonQte_LongPress;
		string qteText = ((scommonQte_LongPress != null) ? scommonQte_LongPress.UIConfig.TextId : null) ?? "";
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		qteItem.SetQteText(qteText);
	}

	// Token: 0x06013406 RID: 78854 RVA: 0x00559180 File Offset: 0x00557380
	protected override void OnPlayQteStart()
	{
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem != null)
		{
			qteItem.SetUiActive(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		if (!this.IsMobile && this.IsQteInteractive)
		{
			CommonQteLongPressView.CommonQteLongPressPanelItem qteItem2 = this.QteItem;
			if (qteItem2 == null)
			{
				return;
			}
			qteItem2.ShowKeyItem();
		}
	}

	// Token: 0x06013407 RID: 78855 RVA: 0x005591E0 File Offset: 0x005573E0
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (!(sequenceName == "Start"))
		{
			if (sequenceName == "Close")
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonQteLongPressView, null);
			}
			return;
		}
		if (this.IsQteEnd)
		{
			return;
		}
		if (!this.IsMobile)
		{
			CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
			if (qteItem != null)
			{
				qteItem.ShowKeyItem();
			}
		}
		this.IsQteStart = true;
		this.IsQteInteractive = true;
	}

	// Token: 0x06013408 RID: 78856 RVA: 0x00559248 File Offset: 0x00557448
	public void OnPress()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
	}

	// Token: 0x06013409 RID: 78857 RVA: 0x00559258 File Offset: 0x00557458
	public void OnRelease()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Release, null);
	}

	// Token: 0x0601340A RID: 78858 RVA: 0x00559268 File Offset: 0x00557468
	protected override void OnInputPress()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x0601340B RID: 78859 RVA: 0x00559289 File Offset: 0x00557489
	protected override void OnInputRelease()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.ResponseEnd();
		}
	}

	// Token: 0x0601340C RID: 78860 RVA: 0x005592AC File Offset: 0x005574AC
	protected override void OnHandleQteEnd()
	{
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
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

	// Token: 0x0601340D RID: 78861 RVA: 0x005592FD File Offset: 0x005574FD
	protected override void OnTickQteView(float delta)
	{
		CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
		if (qteItem == null)
		{
			return;
		}
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		qteItem.RefreshProgress((commonQteContext != null) ? commonQteContext.GetProgress() : 0f);
	}

	// Token: 0x0601340E RID: 78862 RVA: 0x00559328 File Offset: 0x00557528
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_LongPress scommonQte_LongPress = this.CommonQteContext.GetUiConfig() as SCommonQte_LongPress;
			if (scommonQte_LongPress != null)
			{
				SCommonQteButton uiconfig = scommonQte_LongPress.UIConfig;
				CommonQteLongPressView.CommonQteLongPressPanelItem qteItem = this.QteItem;
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

	// Token: 0x0400965F RID: 38495
	[Nullable(2)]
	private CommonQteLongPressView.CommonQteLongPressPanelItem QteItem;

	// Token: 0x04009660 RID: 38496
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020089D5 RID: 35285
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E7FC RID: 190460
		PanelItem
	}

	// Token: 0x020089D6 RID: 35286
	[NullableContext(0)]
	private enum EItemChildType
	{
		// Token: 0x0402E7FE RID: 190462
		BtnMain,
		// Token: 0x0402E7FF RID: 190463
		ProgressBar,
		// Token: 0x0402E800 RID: 190464
		Icon,
		// Token: 0x0402E801 RID: 190465
		KeyItem,
		// Token: 0x0402E802 RID: 190466
		TextPanel,
		// Token: 0x0402E803 RID: 190467
		Text
	}

	// Token: 0x020089D7 RID: 35287
	[NullableContext(0)]
	private enum EItemChildPadType
	{
		// Token: 0x0402E805 RID: 190469
		BtnMain,
		// Token: 0x0402E806 RID: 190470
		ProgressBar,
		// Token: 0x0402E807 RID: 190471
		Icon,
		// Token: 0x0402E808 RID: 190472
		TextPanel,
		// Token: 0x0402E809 RID: 190473
		Text
	}

	// Token: 0x020089D8 RID: 35288
	[NullableContext(2)]
	[Nullable(0)]
	private class CommonQteLongPressPanelItem : UiPanelBase
	{
		// Token: 0x06049331 RID: 299825 RVA: 0x013BFAC0 File Offset: 0x013BDCC0
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

		// Token: 0x06049332 RID: 299826 RVA: 0x013BFC88 File Offset: 0x013BDE88
		protected override UniTask OnBeforeStartAsync()
		{
			CommonQteLongPressView.CommonQteLongPressPanelItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteLongPressView.CommonQteLongPressPanelItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06049333 RID: 299827 RVA: 0x013BFCCC File Offset: 0x013BDECC
		protected override void OnStart()
		{
			if (this.IsMobile)
			{
				this.BtnMain = base.GetButton(0);
				this.ProgressBar = base.GetTexture(1);
				this.IconItem = base.GetSprite(2);
			}
			else
			{
				this.BtnMain = base.GetButton(0);
				this.ProgressBar = base.GetTexture(1);
				this.IconItem = base.GetSprite(2);
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

		// Token: 0x06049334 RID: 299828 RVA: 0x013BFDC0 File Offset: 0x013BDFC0
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

		// Token: 0x06049335 RID: 299829 RVA: 0x013BFE16 File Offset: 0x013BE016
		public void SetQteView(UiViewBase view)
		{
			if (view != null)
			{
				this.QteView = (view as CommonQteLongPressView);
				return;
			}
			this.QteView = null;
		}

		// Token: 0x06049336 RID: 299830 RVA: 0x013BFE30 File Offset: 0x013BE030
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

		// Token: 0x06049337 RID: 299831 RVA: 0x013BFE64 File Offset: 0x013BE064
		[NullableContext(1)]
		public void RefreshIcon(ULGUITexturePackerSpriteData sprite)
		{
			UUISprite iconItem = this.IconItem;
			if (iconItem != null)
			{
				iconItem.SetSprite(sprite, false);
			}
			UUISprite iconItem2 = this.IconItem;
			if (iconItem2 == null)
			{
				return;
			}
			iconItem2.SetUIActive(true);
		}

		// Token: 0x06049338 RID: 299832 RVA: 0x013BFE8A File Offset: 0x013BE08A
		public void RefreshProgress(float progress)
		{
			UUITexture progressBar = this.ProgressBar;
			if (progressBar == null)
			{
				return;
			}
			progressBar.SetFillAmount(progress);
		}

		// Token: 0x06049339 RID: 299833 RVA: 0x013BFE9D File Offset: 0x013BE09D
		public void ShowKeyItem()
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Show(null);
		}

		// Token: 0x0604933A RID: 299834 RVA: 0x013BFEB0 File Offset: 0x013BE0B0
		public void HideKeyItem()
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Hide(null);
		}

		// Token: 0x0604933B RID: 299835 RVA: 0x013BFEC4 File Offset: 0x013BE0C4
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

		// Token: 0x0604933C RID: 299836 RVA: 0x013BFF42 File Offset: 0x013BE142
		private void OnPress()
		{
			CommonQteLongPressView qteView = this.QteView;
			if (qteView == null)
			{
				return;
			}
			qteView.OnPress();
		}

		// Token: 0x0604933D RID: 299837 RVA: 0x013BFF54 File Offset: 0x013BE154
		private void OnRelease()
		{
			CommonQteLongPressView qteView = this.QteView;
			if (qteView == null)
			{
				return;
			}
			qteView.OnRelease();
		}

		// Token: 0x0402E80A RID: 190474
		private UUIButtonComponent BtnMain;

		// Token: 0x0402E80B RID: 190475
		private UUITexture ProgressBar;

		// Token: 0x0402E80C RID: 190476
		private UUISprite IconItem;

		// Token: 0x0402E80D RID: 190477
		private InputMultiKeyItem KeyItem;

		// Token: 0x0402E80E RID: 190478
		private CommonQteLongPressView QteView;

		// Token: 0x0402E80F RID: 190479
		private bool IsMobile;
	}
}
