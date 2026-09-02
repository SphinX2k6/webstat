using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002628 RID: 9768
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteFullScreenLongPress : CommonQteItemBase<CommonQteLongPressContext>
{
	// Token: 0x060133A9 RID: 78761 RVA: 0x00557A30 File Offset: 0x00555C30
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
		}
	}

	// Token: 0x060133AA RID: 78762 RVA: 0x00557AD0 File Offset: 0x00555CD0
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteFullScreenLongPress.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteFullScreenLongPress.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060133AB RID: 78763 RVA: 0x00557B14 File Offset: 0x00555D14
	protected override void OnStart()
	{
		base.OnStart();
		this.BtnMain = base.GetButton(1);
		this.ProgressBar = base.GetTexture(3);
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
			UUIItem item = base.GetItem(4);
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

	// Token: 0x060133AC RID: 78764 RVA: 0x00557C10 File Offset: 0x00555E10
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

	// Token: 0x060133AD RID: 78765 RVA: 0x00557C75 File Offset: 0x00555E75
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteLongPressContext;
	}

	// Token: 0x060133AE RID: 78766 RVA: 0x00557C80 File Offset: 0x00555E80
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

	// Token: 0x060133AF RID: 78767 RVA: 0x00557CB8 File Offset: 0x00555EB8
	protected override void OnPlayQteStart()
	{
		base.SetUiActive(true);
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

	// Token: 0x060133B0 RID: 78768 RVA: 0x00557D18 File Offset: 0x00555F18
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Close2")
		{
			base.Destroy(null);
			return;
		}
		if (sequenceName == "Close")
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
		}
	}

	// Token: 0x060133B1 RID: 78769 RVA: 0x00557D68 File Offset: 0x00555F68
	protected override void OnInputPress()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
			this.CommonQteContext.Response();
		}
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain == null)
		{
			return;
		}
		btnMain.SetSelectionState(EUISelectableSelectionState.Pressed);
	}

	// Token: 0x060133B2 RID: 78770 RVA: 0x00557DC8 File Offset: 0x00555FC8
	protected override void OnInputRelease()
	{
		CommonQteLongPressContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
			}
			this.CommonQteContext.ResponseEnd();
		}
		UUIButtonComponent btnMain = this.BtnMain;
		if (btnMain == null)
		{
			return;
		}
		btnMain.SetSelectionState(EUISelectableSelectionState.Normal);
	}

	// Token: 0x060133B3 RID: 78771 RVA: 0x00557E28 File Offset: 0x00556028
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
		levelSequencePlayer2.PlayLevelSequenceByName("Close2", false, null, false);
	}

	// Token: 0x060133B4 RID: 78772 RVA: 0x00557E7A File Offset: 0x0055607A
	protected override void OnTickQteItem(float delta)
	{
		if (this.CommonQteContext != null)
		{
			this.CurrentProgress = this.CommonQteContext.GetProgress();
		}
		UUITexture progressBar = this.ProgressBar;
		if (progressBar == null)
		{
			return;
		}
		progressBar.SetFillAmount(this.CurrentProgress);
	}

	// Token: 0x060133B5 RID: 78773 RVA: 0x00557EAC File Offset: 0x005560AC
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

	// Token: 0x0400960F RID: 38415
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009610 RID: 38416
	private float CurrentProgress;

	// Token: 0x04009611 RID: 38417
	private UUIButtonComponent BtnMain;

	// Token: 0x04009612 RID: 38418
	private UUITexture ProgressBar;

	// Token: 0x04009613 RID: 38419
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089CF RID: 35279
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E7DB RID: 190427
		Prefab,
		// Token: 0x0402E7DC RID: 190428
		Button,
		// Token: 0x0402E7DD RID: 190429
		Offset,
		// Token: 0x0402E7DE RID: 190430
		Bar,
		// Token: 0x0402E7DF RID: 190431
		KeyItem
	}
}
