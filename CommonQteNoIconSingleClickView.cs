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

// Token: 0x02002639 RID: 9785
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteNoIconSingleClickView : CommonQteViewBase<CommonQteSingleClickContext>
{
	// Token: 0x06013421 RID: 78881 RVA: 0x0055972C File Offset: 0x0055792C
	[NullableContext(1)]
	public CommonQteNoIconSingleClickView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013422 RID: 78882 RVA: 0x00559738 File Offset: 0x00557938
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

	// Token: 0x06013423 RID: 78883 RVA: 0x00559918 File Offset: 0x00557B18
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteNoIconSingleClickView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteNoIconSingleClickView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013424 RID: 78884 RVA: 0x0055995C File Offset: 0x00557B5C
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
		if (animItem != null)
		{
			animItem.SetUIActive(false);
		}
		UUISprite iconItem = this.IconItem;
		if (iconItem == null)
		{
			return;
		}
		iconItem.SetUIActive(false);
	}

	// Token: 0x06013425 RID: 78885 RVA: 0x00559A99 File Offset: 0x00557C99
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

	// Token: 0x06013426 RID: 78886 RVA: 0x00559AD8 File Offset: 0x00557CD8
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSingleClickContext;
	}

	// Token: 0x06013427 RID: 78887 RVA: 0x00559AE3 File Offset: 0x00557CE3
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

	// Token: 0x06013428 RID: 78888 RVA: 0x00559B08 File Offset: 0x00557D08
	[NullableContext(1)]
	protected override void TryApplyQteIcon(CommonQteContextBase context)
	{
	}

	// Token: 0x06013429 RID: 78889 RVA: 0x00559B0C File Offset: 0x00557D0C
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
			levelSequencePlayer.PlayLevelSequenceByName("StartHaste", false, null, false);
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

	// Token: 0x0601342A RID: 78890 RVA: 0x00559BA8 File Offset: 0x00557DA8
	private void OnBtnClickPress()
	{
		base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
	}

	// Token: 0x0601342B RID: 78891 RVA: 0x00559BB8 File Offset: 0x00557DB8
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (!(sequenceName == "StartHaste"))
		{
			if (sequenceName == "Success" || sequenceName == "Fail")
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonQteNoIconView, null);
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

	// Token: 0x0601342C RID: 78892 RVA: 0x00559CA2 File Offset: 0x00557EA2
	protected override void OnInputPress()
	{
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsResponsible())
		{
			this.CommonQteContext.Response();
		}
	}

	// Token: 0x0601342D RID: 78893 RVA: 0x00559CC4 File Offset: 0x00557EC4
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

	// Token: 0x0601342E RID: 78894 RVA: 0x00559D91 File Offset: 0x00557F91
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

	// Token: 0x0601342F RID: 78895 RVA: 0x00559DCC File Offset: 0x00557FCC
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

	// Token: 0x06013430 RID: 78896 RVA: 0x00559E54 File Offset: 0x00558054
	protected override void OnQtePause()
	{
		base.OnQtePause();
		if (this.IsQtePlayStart && !this.IsQteStart)
		{
			this.SetPlayRate("StartHaste", 0f);
			return;
		}
		if (this.IsQteStart)
		{
			this.SetPlayRate("Loop2", 0f);
		}
	}

	// Token: 0x06013431 RID: 78897 RVA: 0x00559EA0 File Offset: 0x005580A0
	protected override void OnQteResume()
	{
		base.OnQteResume();
		if (this.IsQtePlayStart)
		{
			if (!this.IsQteStart)
			{
				this.SetPlayRate("StartHaste", 1f);
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

	// Token: 0x06013432 RID: 78898 RVA: 0x00559F10 File Offset: 0x00558110
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

	// Token: 0x06013433 RID: 78899 RVA: 0x00559F6C File Offset: 0x0055816C
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

	// Token: 0x04009663 RID: 38499
	private const float LOOP_ANIM_START_OFFSET = 1.167f;

	// Token: 0x04009664 RID: 38500
	[Nullable(1)]
	private const string LOOP_SEQUENCE = "Loop2";

	// Token: 0x04009665 RID: 38501
	private CombineKeyItem KeyItem;

	// Token: 0x04009666 RID: 38502
	private UUIItem KeyItemContainer;

	// Token: 0x04009667 RID: 38503
	private UUIItem AnimItem;

	// Token: 0x04009668 RID: 38504
	private UUIButtonComponent BtnClick;

	// Token: 0x04009669 RID: 38505
	private UUISprite IconItem;

	// Token: 0x0400966A RID: 38506
	private UUIItem BorderItem;

	// Token: 0x0400966B RID: 38507
	private UUITexture ProgressBar;

	// Token: 0x0400966C RID: 38508
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400966D RID: 38509
	private LevelSequencePlayer LevelSequencePlayerBorder;

	// Token: 0x020089DF RID: 35295
	[NullableContext(0)]
	private enum EPadChildType
	{
		// Token: 0x0402E82E RID: 190510
		AnimItem,
		// Token: 0x0402E82F RID: 190511
		BtnClick,
		// Token: 0x0402E830 RID: 190512
		Icon,
		// Token: 0x0402E831 RID: 190513
		BorderItem,
		// Token: 0x0402E832 RID: 190514
		ProgressBar
	}

	// Token: 0x020089E0 RID: 35296
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402E834 RID: 190516
		AnimItem,
		// Token: 0x0402E835 RID: 190517
		KeyItemContainer,
		// Token: 0x0402E836 RID: 190518
		KeyItem,
		// Token: 0x0402E837 RID: 190519
		Icon,
		// Token: 0x0402E838 RID: 190520
		BtnClick,
		// Token: 0x0402E839 RID: 190521
		BorderItem,
		// Token: 0x0402E83A RID: 190522
		ProgressBar
	}
}
