using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002626 RID: 9766
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteSingleClickItem : CommonQteItemBase<CommonQteSingleClickContext>
{
	// Token: 0x0601337D RID: 78717 RVA: 0x00556A00 File Offset: 0x00554C00
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISliderComponent))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIItem)));
		}
	}

	// Token: 0x0601337E RID: 78718 RVA: 0x00556AB8 File Offset: 0x00554CB8
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteSingleClickItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteSingleClickItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601337F RID: 78719 RVA: 0x00556AFC File Offset: 0x00554CFC
	protected override void OnStart()
	{
		base.OnStart();
		this.BtnMain = base.GetButton(0);
		this.DurationBar = base.GetSlider(3);
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
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(1);
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
			UUIItem item2 = base.GetItem(5);
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
			UUIItem item3 = base.GetItem(4);
			this.LevelSequencePlayer = new LevelSequencePlayer(item3);
			base.SetAttachRootItem(item3);
		}
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x06013380 RID: 78720 RVA: 0x00556C22 File Offset: 0x00554E22
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

	// Token: 0x06013381 RID: 78721 RVA: 0x00556C50 File Offset: 0x00554E50
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSingleClickContext;
	}

	// Token: 0x06013382 RID: 78722 RVA: 0x00556C5C File Offset: 0x00554E5C
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

	// Token: 0x06013383 RID: 78723 RVA: 0x00556C94 File Offset: 0x00554E94
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_SingleClick scommonQte_SingleClick = uiConfig as SCommonQte_SingleClick;
		string text = (scommonQte_SingleClick != null) ? scommonQte_SingleClick.UIConfig.TextId : null;
		UUIText text2 = base.GetText(1);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, text, Array.Empty<object>());
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
		}
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.CommonQteContext != null && !this.CommonQteContext.IsPermanent);
	}

	// Token: 0x06013384 RID: 78724 RVA: 0x00556D10 File Offset: 0x00554F10
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

	// Token: 0x06013385 RID: 78725 RVA: 0x00556D68 File Offset: 0x00554F68
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

	// Token: 0x06013386 RID: 78726 RVA: 0x00556DE9 File Offset: 0x00554FE9
	protected override void OnInputPress()
	{
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x06013387 RID: 78727 RVA: 0x00556E0C File Offset: 0x0055500C
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

	// Token: 0x06013388 RID: 78728 RVA: 0x00556E5E File Offset: 0x0055505E
	protected override void OnTickQteItem(float delta)
	{
		if (!this.CommonQteContext.IsPermanent)
		{
			UUISliderComponent durationBar = this.DurationBar;
			if (durationBar == null)
			{
				return;
			}
			CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
			durationBar.SetValue((commonQteContext != null) ? commonQteContext.GetRemainingTimeProgress() : 1f, true);
		}
	}

	// Token: 0x06013389 RID: 78729 RVA: 0x00556E94 File Offset: 0x00555094
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_SingleClick scommonQte_SingleClick = this.CommonQteContext.GetUiConfig() as SCommonQte_SingleClick;
			if (scommonQte_SingleClick != null)
			{
				SCommonQteButton uiconfig = scommonQte_SingleClick.UIConfig;
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

	// Token: 0x040095FB RID: 38395
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040095FC RID: 38396
	private UUIButtonComponent BtnMain;

	// Token: 0x040095FD RID: 38397
	private UUISliderComponent DurationBar;

	// Token: 0x040095FE RID: 38398
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089CB RID: 35275
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E7C8 RID: 190408
		BtnMain,
		// Token: 0x0402E7C9 RID: 190409
		DescText,
		// Token: 0x0402E7CA RID: 190410
		DurationPanel,
		// Token: 0x0402E7CB RID: 190411
		DurationBar,
		// Token: 0x0402E7CC RID: 190412
		AnimItem,
		// Token: 0x0402E7CD RID: 190413
		KeyItem
	}
}
