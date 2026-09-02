using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002620 RID: 9760
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteLongPressItem : CommonQteItemBase<CommonQteLongPressContext>
{
	// Token: 0x06013313 RID: 78611 RVA: 0x005541DC File Offset: 0x005523DC
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUISliderComponent))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
		}
	}

	// Token: 0x06013314 RID: 78612 RVA: 0x005542AC File Offset: 0x005524AC
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteLongPressItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteLongPressItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013315 RID: 78613 RVA: 0x005542F0 File Offset: 0x005524F0
	protected override void OnStart()
	{
		base.OnStart();
		this.BtnMain = base.GetButton(0);
		this.ProgressBar = base.GetTexture(1);
		this.DurationBar = base.GetSlider(4);
		UUISliderComponent durationBar = this.DurationBar;
		if (durationBar != null)
		{
			durationBar.SetValue(1f, true);
		}
		UUISliderComponent durationBar2 = this.DurationBar;
		if (durationBar2 != null)
		{
			durationBar2.SetSelfInteractive(false);
		}
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain != null)
		{
			btnMain.OnPointDownCallBack.Bind(delegate()
			{
				base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
			});
		}
		UUIButtonComponent btnMain2 = this.BtnMain;
		if (btnMain2 != null)
		{
			btnMain2.OnPointUpCallBack.Bind(delegate()
			{
				base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Release, null);
			});
		}
		UUIButtonComponent btnMain3 = this.BtnMain;
		if (btnMain3 != null)
		{
			btnMain3.OnPointCancelCallBack.Bind(delegate()
			{
				base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Release, null);
			});
		}
		if (this.KeyItem != null)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.Hide(null);
			}
		}
		else
		{
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		base.SetUiActive(false);
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}
		else
		{
			UUIItem item3 = base.GetItem(5);
			this.LevelSequencePlayer = new LevelSequencePlayer(item3);
			base.SetAttachRootItem(item3);
		}
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x06013316 RID: 78614 RVA: 0x00554468 File Offset: 0x00552668
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
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
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x06013317 RID: 78615 RVA: 0x005544CD File Offset: 0x005526CD
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteLongPressContext;
	}

	// Token: 0x06013318 RID: 78616 RVA: 0x005544D8 File Offset: 0x005526D8
	[NullableContext(1)]
	protected override void OnRefreshActionUi(string action)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
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

	// Token: 0x06013319 RID: 78617 RVA: 0x00554510 File Offset: 0x00552710
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_LongPress scommonQte_LongPress = uiConfig as SCommonQte_LongPress;
		string text = (scommonQte_LongPress != null) ? scommonQte_LongPress.UIConfig.TextId : null;
		UUIText text2 = base.GetText(2);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, text, Array.Empty<object>());
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
		}
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.CommonQteContext != null && !this.CommonQteContext.IsPermanent);
	}

	// Token: 0x0601331A RID: 78618 RVA: 0x0055458C File Offset: 0x0055278C
	protected override void OnPlayQteStart()
	{
		base.SetUiActive(true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		if (this.IsQteInteractive && !this.IsMobile)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Show(null);
		}
	}

	// Token: 0x0601331B RID: 78619 RVA: 0x005545E4 File Offset: 0x005527E4
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (!(sequenceName == "Start"))
		{
			if (sequenceName == "Close")
			{
				base.Destroy(null);
			}
			return;
		}
		if (this.IsQteEnd)
		{
			return;
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
		}
		if (!this.IsMobile)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.Show(null);
			}
		}
		this.IsQteStart = true;
		this.IsQteInteractive = true;
	}

	// Token: 0x0601331C RID: 78620 RVA: 0x00554665 File Offset: 0x00552865
	protected override void OnInputPress()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain == null)
		{
			return;
		}
		btnMain.SetSelectionState(EUISelectableSelectionState.Pressed);
	}

	// Token: 0x0601331D RID: 78621 RVA: 0x00554697 File Offset: 0x00552897
	protected override void OnInputRelease()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.ResponseEnd();
		}
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain == null)
		{
			return;
		}
		btnMain.SetSelectionState(EUISelectableSelectionState.Normal);
	}

	// Token: 0x0601331E RID: 78622 RVA: 0x005546CC File Offset: 0x005528CC
	protected override void OnHandleQteEnd()
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.Hide(null);
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

	// Token: 0x0601331F RID: 78623 RVA: 0x00554720 File Offset: 0x00552920
	protected override void OnTickQteItem(float delta)
	{
		if (!this.CommonQteContext.IsPermanent)
		{
			UUISliderComponent durationBar = this.DurationBar;
			if (durationBar != null)
			{
				durationBar.SetValue(this.CommonQteContext.GetRemainingTimeProgress(), true);
			}
		}
		this.CurrentProgress = this.CommonQteContext.GetProgress();
		UUITexture progressBar = this.ProgressBar;
		if (progressBar == null)
		{
			return;
		}
		progressBar.SetFillAmount(this.CurrentProgress);
	}

	// Token: 0x06013320 RID: 78624 RVA: 0x00554780 File Offset: 0x00552980
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_LongPress scommonQte_LongPress = this.CommonQteContext.GetUiConfig() as SCommonQte_LongPress;
			if (scommonQte_LongPress != null)
			{
				SCommonQteButton uiconfig = scommonQte_LongPress.UIConfig;
				UUIItem rootItem = this.RootItem;
				if (rootItem != null)
				{
					rootItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
				}
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 != null)
				{
					rootItem2.SetAnchorOffset(uiconfig.AnchorOffset);
				}
				if (this.IsAttaching)
				{
					this.Reattach(this.CommonQteContext);
				}
			}
		}
	}

	// Token: 0x040095CA RID: 38346
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040095CB RID: 38347
	private float CurrentProgress;

	// Token: 0x040095CC RID: 38348
	private UUIButtonComponent BtnMain;

	// Token: 0x040095CD RID: 38349
	private UUITexture ProgressBar;

	// Token: 0x040095CE RID: 38350
	private UUISliderComponent DurationBar;

	// Token: 0x040095CF RID: 38351
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089BD RID: 35261
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E777 RID: 190327
		BtnMain,
		// Token: 0x0402E778 RID: 190328
		ProgressBar,
		// Token: 0x0402E779 RID: 190329
		DescText,
		// Token: 0x0402E77A RID: 190330
		DurationPanel,
		// Token: 0x0402E77B RID: 190331
		DurationBar,
		// Token: 0x0402E77C RID: 190332
		AnimItem,
		// Token: 0x0402E77D RID: 190333
		KeyItem
	}
}
