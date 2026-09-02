using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200261C RID: 9756
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteFocusSingleButton : CommonQteItemBase<CommonQteSingleClickContext>
{
	// Token: 0x060132B3 RID: 78515 RVA: 0x0055229C File Offset: 0x0055049C
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
		}
	}

	// Token: 0x060132B4 RID: 78516 RVA: 0x00552310 File Offset: 0x00550510
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteFocusSingleButton.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteFocusSingleButton.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060132B5 RID: 78517 RVA: 0x00552354 File Offset: 0x00550554
	protected override void OnStart()
	{
		base.OnStart();
		this.BtnMain = base.GetButton(1);
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
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}
		base.SetUiActive(false);
		UUIItem item2 = base.GetItem(0);
		this.LevelSequencePlayer = new LevelSequencePlayer(item2);
		base.SetAttachRootItem(item2);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
	}

	// Token: 0x060132B6 RID: 78518 RVA: 0x005523FF File Offset: 0x005505FF
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

	// Token: 0x060132B7 RID: 78519 RVA: 0x0055242D File Offset: 0x0055062D
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSingleClickContext;
	}

	// Token: 0x060132B8 RID: 78520 RVA: 0x00552438 File Offset: 0x00550638
	protected override void OnRefreshActionUi(string action)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
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

	// Token: 0x060132B9 RID: 78521 RVA: 0x00552484 File Offset: 0x00550684
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

	// Token: 0x060132BA RID: 78522 RVA: 0x005524DC File Offset: 0x005506DC
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

	// Token: 0x060132BB RID: 78523 RVA: 0x0055255D File Offset: 0x0055075D
	protected override void OnInputPress()
	{
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x060132BC RID: 78524 RVA: 0x00552580 File Offset: 0x00550780
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

	// Token: 0x060132BD RID: 78525 RVA: 0x005525C0 File Offset: 0x005507C0
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
				UUIButtonComponent button = base.GetButton(1);
				UUIItem uuiitem = (button != null) ? button.RootUIComp.Get() : null;
				if (uuiitem != null)
				{
					uuiitem.SetAnchorAlign(scommonQte_SingleClick.ButtonAnchorHAlign, scommonQte_SingleClick.ButtonAnchorVAlign);
					uuiitem.SetAnchorOffset(scommonQte_SingleClick.ButtonOffset);
				}
			}
		}
	}

	// Token: 0x04009597 RID: 38295
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009598 RID: 38296
	[Nullable(2)]
	private UUIButtonComponent BtnMain;

	// Token: 0x04009599 RID: 38297
	[Nullable(2)]
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089B8 RID: 35256
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E764 RID: 190308
		Prefab,
		// Token: 0x0402E765 RID: 190309
		BtnMain,
		// Token: 0x0402E766 RID: 190310
		KeyItem
	}
}
