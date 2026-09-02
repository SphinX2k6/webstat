using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002618 RID: 9752
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteContinuousClickItem : CommonQteItemBase<CommonQteContinuousClickContext>
{
	// Token: 0x0601326A RID: 78442 RVA: 0x005507D0 File Offset: 0x0054E9D0
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

	// Token: 0x0601326B RID: 78443 RVA: 0x005508A0 File Offset: 0x0054EAA0
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteContinuousClickItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteContinuousClickItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601326C RID: 78444 RVA: 0x005508E4 File Offset: 0x0054EAE4
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

	// Token: 0x0601326D RID: 78445 RVA: 0x00550A17 File Offset: 0x0054EC17
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain != null)
		{
			btnMain.OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x0601326E RID: 78446 RVA: 0x00550A45 File Offset: 0x0054EC45
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteContinuousClickContext;
	}

	// Token: 0x0601326F RID: 78447 RVA: 0x00550A50 File Offset: 0x0054EC50
	[NullableContext(1)]
	protected override void OnRefreshActionUi(string action)
	{
		if (!this.IsMobile)
		{
			InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = action
			};
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
			}
			InputMultiKeyItem keyItem2 = this.KeyItem;
			if (keyItem2 == null)
			{
				return;
			}
			keyItem2.Show(null);
		}
	}

	// Token: 0x06013270 RID: 78448 RVA: 0x00550A98 File Offset: 0x0054EC98
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_ContinuousClick scommonQte_ContinuousClick = uiConfig as SCommonQte_ContinuousClick;
		if (scommonQte_ContinuousClick != null && scommonQte_ContinuousClick.HideProgressBar)
		{
			base.GetItem(1).SetUIActive(false);
		}
		string text = (scommonQte_ContinuousClick != null) ? scommonQte_ContinuousClick.UIConfig.TextId : null;
		UUIText text2 = base.GetText(2);
		if (!StringUtils.IsEmpty(text))
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

	// Token: 0x06013271 RID: 78449 RVA: 0x00550B30 File Offset: 0x0054ED30
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

	// Token: 0x06013272 RID: 78450 RVA: 0x00550B88 File Offset: 0x0054ED88
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
			levelSequencePlayer.PlayLevelSequenceByName("Tips", false, null, false);
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

	// Token: 0x06013273 RID: 78451 RVA: 0x00550C09 File Offset: 0x0054EE09
	protected override void OnInputPress()
	{
		CommonQteContinuousClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
			this.RefreshProgress();
		}
	}

	// Token: 0x06013274 RID: 78452 RVA: 0x00550C30 File Offset: 0x0054EE30
	protected override void OnHandleQteEnd()
	{
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

	// Token: 0x06013275 RID: 78453 RVA: 0x00550C70 File Offset: 0x0054EE70
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
		this.RefreshProgress();
	}

	// Token: 0x06013276 RID: 78454 RVA: 0x00550CA4 File Offset: 0x0054EEA4
	private void RefreshProgress()
	{
		if (this.CommonQteContext != null)
		{
			this.CurrentProgress = this.CommonQteContext.CurrentEnergyPercent * 0.01f;
		}
		UUITexture progressBar = this.ProgressBar;
		if (progressBar == null)
		{
			return;
		}
		progressBar.SetFillAmount(this.CurrentProgress);
	}

	// Token: 0x06013277 RID: 78455 RVA: 0x00550CF4 File Offset: 0x0054EEF4
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_ContinuousClick scommonQte_ContinuousClick = this.CommonQteContext.GetUiConfig() as SCommonQte_ContinuousClick;
			if (scommonQte_ContinuousClick != null)
			{
				SCommonQteButton uiconfig = scommonQte_ContinuousClick.UIConfig;
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

	// Token: 0x04009578 RID: 38264
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009579 RID: 38265
	private Number CurrentProgress = 0;

	// Token: 0x0400957A RID: 38266
	private UUIButtonComponent BtnMain;

	// Token: 0x0400957B RID: 38267
	private UUITexture ProgressBar;

	// Token: 0x0400957C RID: 38268
	private UUISliderComponent DurationBar;

	// Token: 0x0400957D RID: 38269
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089AF RID: 35247
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E738 RID: 190264
		BtnMain,
		// Token: 0x0402E739 RID: 190265
		ProgressBar,
		// Token: 0x0402E73A RID: 190266
		DescText,
		// Token: 0x0402E73B RID: 190267
		DurationPanel,
		// Token: 0x0402E73C RID: 190268
		DurationBar,
		// Token: 0x0402E73D RID: 190269
		AnimItem,
		// Token: 0x0402E73E RID: 190270
		KeyItem
	}
}
