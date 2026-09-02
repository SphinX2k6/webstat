using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Qte.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200263A RID: 9786
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteSingleClickView : CommonQteViewBase<CommonQteSingleClickContext>
{
	// Token: 0x06013434 RID: 78900 RVA: 0x00559FD5 File Offset: 0x005581D5
	[NullableContext(1)]
	public CommonQteSingleClickView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013435 RID: 78901 RVA: 0x00559FE0 File Offset: 0x005581E0
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
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
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			return;
		}
		num2 = 7;
		List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
		span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
		num = 0;
		*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num++;
		*span[num] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num++;
		*span[num] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		this.ComponentRegisterInfos = list2;
	}

	// Token: 0x06013436 RID: 78902 RVA: 0x0055A1C0 File Offset: 0x005583C0
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteSingleClickView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteSingleClickView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013437 RID: 78903 RVA: 0x0055A204 File Offset: 0x00558404
	protected override void OnStart()
	{
		base.OnStart();
		if (this.IsMobile)
		{
			this.AnimItem = base.GetItem(0);
			this.BtnClick = base.GetButton(1);
			this.IconItem = base.GetSprite(2);
			this.BorderItem = base.GetItem(3);
			this.ProgressBar = base.GetTexture(4);
		}
		else
		{
			this.AnimItem = base.GetItem(0);
			this.BtnClick = base.GetButton(4);
			this.IconItem = base.GetSprite(3);
			this.KeyItemContainer = base.GetItem(1);
			UUIItem keyItemContainer = this.KeyItemContainer;
			if (keyItemContainer != null)
			{
				keyItemContainer.SetUIActive(false);
			}
			this.BorderItem = base.GetItem(5);
			this.ProgressBar = base.GetTexture(6);
		}
		UUIButtonComponent btnClick = this.BtnClick;
		if (btnClick != null)
		{
			btnClick.OnPointDownCallBack.Bind(new Action(this.OnBtnClickPress));
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.AnimItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		this.LevelSequencePlayerBorder = new LevelSequencePlayer(this.BorderItem);
		UUIItem animItem = this.AnimItem;
		if (animItem == null)
		{
			return;
		}
		animItem.SetUIActive(false);
	}

	// Token: 0x06013438 RID: 78904 RVA: 0x0055A32F File Offset: 0x0055852F
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		UUIButtonComponent btnClick = this.BtnClick;
		if (btnClick != null)
		{
			btnClick.OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		LevelSequencePlayer levelSequencePlayerBorder = this.LevelSequencePlayerBorder;
		if (levelSequencePlayerBorder == null)
		{
			return;
		}
		levelSequencePlayerBorder.Clear();
	}

	// Token: 0x06013439 RID: 78905 RVA: 0x0055A36E File Offset: 0x0055856E
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSingleClickContext;
	}

	// Token: 0x0601343A RID: 78906 RVA: 0x0055A379 File Offset: 0x00558579
	[NullableContext(1)]
	protected override void OnRefreshActionUi(string action)
	{
		CombineKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.RefreshAction(action);
		}
		CombineKeyItem keyItem2 = this.KeyItem;
		if (keyItem2 == null)
		{
			return;
		}
		keyItem2.Show(null);
	}

	// Token: 0x0601343B RID: 78907 RVA: 0x0055A39E File Offset: 0x0055859E
	[NullableContext(1)]
	protected override void OnRefreshIcon(ULGUITexturePackerSpriteData sprite)
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

	// Token: 0x0601343C RID: 78908 RVA: 0x0055A3C4 File Offset: 0x005585C4
	protected override void OnPlayQteStart()
	{
		UUIItem animItem = this.AnimItem;
		if (animItem != null)
		{
			animItem.SetUIActive(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		if (this.IsShowBorder)
		{
			UUIItem borderItem = this.BorderItem;
			if (borderItem != null)
			{
				borderItem.SetUIActive(true);
			}
			LevelSequencePlayer levelSequencePlayerBorder = this.LevelSequencePlayerBorder;
			if (levelSequencePlayerBorder != null)
			{
				levelSequencePlayerBorder.PlayLevelSequenceByName("Start", false, null, false);
			}
		}
		if (!this.IsMobile && this.IsQteInteractive)
		{
			UUIItem keyItemContainer = this.KeyItemContainer;
			if (keyItemContainer == null)
			{
				return;
			}
			keyItemContainer.SetUIActive(true);
		}
	}

	// Token: 0x0601343D RID: 78909 RVA: 0x0055A460 File Offset: 0x00558660
	private void OnBtnClickPress()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
	}

	// Token: 0x0601343E RID: 78910 RVA: 0x0055A470 File Offset: 0x00558670
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (!(sequenceName == "Start"))
		{
			if (sequenceName == "Success" || sequenceName == "Fail")
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonQteView, null);
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
			levelSequencePlayer.PlayLevelSequenceByName("Loop2", false, null, false);
		}
		if (this.IsQtePause)
		{
			this.SetPlayRate("Loop2", 0f);
		}
		else if (this.LoopDuration > 0f)
		{
			this.SetPlayRate("Loop2", 1f / this.LoopDuration);
		}
		else
		{
			this.SetPlayRate("Loop2", 0f);
		}
		if (!this.IsMobile)
		{
			UUIItem keyItemContainer = this.KeyItemContainer;
			if (keyItemContainer != null)
			{
				keyItemContainer.SetUIActive(true);
			}
		}
		this.IsQteStart = true;
		this.IsQteInteractive = true;
	}

	// Token: 0x0601343F RID: 78911 RVA: 0x0055A55A File Offset: 0x0055875A
	protected override void OnInputPress()
	{
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x06013440 RID: 78912 RVA: 0x0055A57C File Offset: 0x0055877C
	protected override void OnHandleQteEnd()
	{
		if (!this.IsMobile)
		{
			UUIItem keyItemContainer = this.KeyItemContainer;
			if (keyItemContainer != null)
			{
				keyItemContainer.SetUIActive(false);
			}
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsSuccess())
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Success", false, null, false);
			}
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.PlayLevelSequenceByName("Fail", false, null, false);
			}
		}
		if (this.IsShowBorder)
		{
			LevelSequencePlayer levelSequencePlayerBorder = this.LevelSequencePlayerBorder;
			if (levelSequencePlayerBorder != null)
			{
				levelSequencePlayerBorder.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayerBorder2 = this.LevelSequencePlayerBorder;
			if (levelSequencePlayerBorder2 == null)
			{
				return;
			}
			levelSequencePlayerBorder2.PlayLevelSequenceByName("Close", false, null, false);
		}
	}

	// Token: 0x06013441 RID: 78913 RVA: 0x0055A649 File Offset: 0x00558849
	[NullableContext(1)]
	private void SetPlayRate(string sequenceName, float playRate)
	{
		UUIItem animItem = this.AnimItem;
		AUIBaseActor auibaseActor = ((animItem != null) ? animItem.GetOwner() : null) as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		ALevelSequenceActor sequencePlayerByKey = auibaseActor.GetSequencePlayerByKey(sequenceName);
		if (sequencePlayerByKey == null)
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.SetPlayRate(playRate);
	}

	// Token: 0x06013442 RID: 78914 RVA: 0x0055A684 File Offset: 0x00558884
	private void FixLoopProgress()
	{
		UUIItem animItem = this.AnimItem;
		AUIBaseActor auibaseActor = ((animItem != null) ? animItem.GetOwner() : null) as AUIBaseActor;
		if (this.LoopDuration > 0f)
		{
			CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
			float num = (float)((double)((commonQteContext != null) ? commonQteContext.GetRemainingTime() : 0f) * Singleton<TimeUtil>.Instance.Millisecond);
			if (auibaseActor != null)
			{
				ALevelSequenceActor sequencePlayerByKey = auibaseActor.GetSequencePlayerByKey("Loop2");
				if (sequencePlayerByKey == null)
				{
					return;
				}
				ULevelSequencePlayer sequencePlayer = sequencePlayerByKey.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.JumpToSeconds(2.167f - num / this.LoopDuration);
			}
		}
	}

	// Token: 0x06013443 RID: 78915 RVA: 0x0055A70C File Offset: 0x0055890C
	protected override void OnQtePause()
	{
		base.OnQtePause();
		if (this.IsQtePlayStart && !this.IsQteStart)
		{
			this.SetPlayRate("Start", 0f);
			return;
		}
		if (this.IsQteStart)
		{
			this.SetPlayRate("Loop2", 0f);
		}
	}

	// Token: 0x06013444 RID: 78916 RVA: 0x0055A758 File Offset: 0x00558958
	protected override void OnQteResume()
	{
		base.OnQteResume();
		if (this.IsQtePlayStart)
		{
			if (!this.IsQteStart)
			{
				this.SetPlayRate("Start", 1f);
				return;
			}
			if (this.LoopDuration > 0f)
			{
				this.FixLoopProgress();
				this.SetPlayRate("Loop2", 1f / this.LoopDuration);
				return;
			}
			this.SetPlayRate("Loop2", 0f);
		}
	}

	// Token: 0x06013445 RID: 78917 RVA: 0x0055A7C8 File Offset: 0x005589C8
	protected override void OnTickQteView(float delta)
	{
		float fillAmount = 1f;
		if (this.LoopDuration > 0f)
		{
			CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
			fillAmount = (float)((double)((commonQteContext != null) ? commonQteContext.GetRemainingTime() : 0f) * Singleton<TimeUtil>.Instance.Millisecond) / this.LoopDuration;
		}
		UUITexture progressBar = this.ProgressBar;
		if (progressBar == null)
		{
			return;
		}
		progressBar.SetFillAmount(fillAmount);
	}

	// Token: 0x06013446 RID: 78918 RVA: 0x0055A824 File Offset: 0x00558A24
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_SingleClick scommonQte_SingleClick = this.CommonQteContext.GetUiConfig() as SCommonQte_SingleClick;
			if (scommonQte_SingleClick != null)
			{
				SCommonQteButton uiconfig = scommonQte_SingleClick.UIConfig;
				UUIItem animItem = this.AnimItem;
				if (animItem != null)
				{
					animItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
				}
				UUIItem animItem2 = this.AnimItem;
				if (animItem2 == null)
				{
					return;
				}
				animItem2.SetAnchorOffset(uiconfig.AnchorOffset);
			}
		}
	}

	// Token: 0x0400966E RID: 38510
	private const float LOOP_ANIM_START_OFFSET = 1.167f;

	// Token: 0x0400966F RID: 38511
	[Nullable(1)]
	private const string LOOP_SEQUENCE = "Loop2";

	// Token: 0x04009670 RID: 38512
	private CombineKeyItem KeyItem;

	// Token: 0x04009671 RID: 38513
	private UUIItem KeyItemContainer;

	// Token: 0x04009672 RID: 38514
	private UUIItem AnimItem;

	// Token: 0x04009673 RID: 38515
	private UUIButtonComponent BtnClick;

	// Token: 0x04009674 RID: 38516
	private UUISprite IconItem;

	// Token: 0x04009675 RID: 38517
	private UUIItem BorderItem;

	// Token: 0x04009676 RID: 38518
	private UUITexture ProgressBar;

	// Token: 0x04009677 RID: 38519
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009678 RID: 38520
	private LevelSequencePlayer LevelSequencePlayerBorder;

	// Token: 0x020089E2 RID: 35298
	[NullableContext(0)]
	private enum EPadChildType
	{
		// Token: 0x0402E840 RID: 190528
		AnimItem,
		// Token: 0x0402E841 RID: 190529
		BtnClick,
		// Token: 0x0402E842 RID: 190530
		Icon,
		// Token: 0x0402E843 RID: 190531
		BorderItem,
		// Token: 0x0402E844 RID: 190532
		ProgressBar
	}

	// Token: 0x020089E3 RID: 35299
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402E846 RID: 190534
		AnimItem,
		// Token: 0x0402E847 RID: 190535
		KeyItemContainer,
		// Token: 0x0402E848 RID: 190536
		KeyItem,
		// Token: 0x0402E849 RID: 190537
		Icon,
		// Token: 0x0402E84A RID: 190538
		BtnClick,
		// Token: 0x0402E84B RID: 190539
		BorderItem,
		// Token: 0x0402E84C RID: 190540
		ProgressBar
	}
}
