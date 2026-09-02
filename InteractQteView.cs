using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200235C RID: 9052
[NullableContext(1)]
[Nullable(0)]
public class InteractQteView : PanelQteView
{
	// Token: 0x060114DF RID: 70879 RVA: 0x004C2E46 File Offset: 0x004C1046
	public InteractQteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060114E0 RID: 70880 RVA: 0x004C2E5C File Offset: 0x004C105C
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num;
		Span<ValueTuple<int, Type>> span;
		int num2;
		if (this.IsMobile)
		{
			num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			return;
		}
		num2 = 3;
		List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
		span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
		num = 0;
		*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list2;
	}

	// Token: 0x060114E1 RID: 70881 RVA: 0x004C2F54 File Offset: 0x004C1154
	protected override UniTask OnBeforeStartAsync()
	{
		InteractQteView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InteractQteView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060114E2 RID: 70882 RVA: 0x004C2F98 File Offset: 0x004C1198
	protected override void OnStart()
	{
		if (this.IsMobile)
		{
			this.AnimItem = base.GetItem(0);
			base.GetButton(1).OnPointDownCallBack.Bind(new Action(this.OnPress));
		}
		else
		{
			this.AnimItem = base.GetItem(0);
			base.GetItem(1).SetUIActive(false);
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.AnimItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		this.InitQteData();
		UUIItem animItem = this.AnimItem;
		if (animItem != null)
		{
			animItem.SetUIActive(false);
		}
		this.UiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnViewSequenceEndEvent), false);
	}

	// Token: 0x060114E3 RID: 70883 RVA: 0x004C3051 File Offset: 0x004C1251
	protected override void OnBeforeDestroyImplement()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x060114E4 RID: 70884 RVA: 0x004C3064 File Offset: 0x004C1264
	private void OnViewSequenceEndEvent(string name)
	{
		if (this.IsQteEnd)
		{
			return;
		}
		UUIItem animItem = this.AnimItem;
		if (animItem != null)
		{
			animItem.SetUIActive(true);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x060114E5 RID: 70885 RVA: 0x004C30AC File Offset: 0x004C12AC
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			if (this.IsQteEnd)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
			if (this.LoopDuration > 0)
			{
				this.SetPlayRate("Loop", 1f / this.LoopDuration);
			}
			int handleId = (int)(this.OpenParam ?? 0);
			ModelBase<PanelQteModel>.Instance.ResetLeftTime(handleId);
			if (!this.IsMobile)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				CombineKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.Show(null);
				}
			}
			this.IsQteStart = true;
		}
	}

	// Token: 0x060114E6 RID: 70886 RVA: 0x004C3178 File Offset: 0x004C1378
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.CFT, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.InteractQteView, null);
		}
	}

	// Token: 0x060114E7 RID: 70887 RVA: 0x004C31CB File Offset: 0x004C13CB
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		if (this.IsMobile)
		{
			base.GetButton(1).OnPointDownCallBack.Unbind();
		}
		this.StopDelayTimer();
	}

	// Token: 0x060114E8 RID: 70888 RVA: 0x004C31F2 File Offset: 0x004C13F2
	protected override void RefreshVisible()
	{
	}

	// Token: 0x060114E9 RID: 70889 RVA: 0x004C31F4 File Offset: 0x004C13F4
	private void StopDelayTimer()
	{
		if (this.DelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.DelayTimer);
			this.DelayTimer = null;
		}
	}

	// Token: 0x060114EA RID: 70890 RVA: 0x004C3218 File Offset: 0x004C1418
	private void InitQteData()
	{
		int num = (int)(this.OpenParam ?? 0);
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.CFT, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.InteractQteView, null);
			return;
		}
		PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
		if (num != context.QteHandleId)
		{
			Singleton<Log>.Instance.Error(ELogModule.PanelQte, ELogAuthor.CFT, "qte handleId 不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.InteractQteView, null);
			return;
		}
		this.LoopDuration = context.Config.Duration;
		this.IsQteStart = false;
	}

	// Token: 0x060114EB RID: 70891 RVA: 0x004C32DD File Offset: 0x004C14DD
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("QTE交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
		}
	}

	// Token: 0x060114EC RID: 70892 RVA: 0x004C3308 File Offset: 0x004C1508
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("QTE交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
		}
	}

	// Token: 0x060114ED RID: 70893 RVA: 0x004C3333 File Offset: 0x004C1533
	private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
	{
		if (this.IsQteEnd || !this.IsQteStart)
		{
			return;
		}
		if (actionType == InputDistributeDefine.EActionType.Press)
		{
			this.OnInput();
		}
	}

	// Token: 0x060114EE RID: 70894 RVA: 0x004C334F File Offset: 0x004C154F
	private void OnPress()
	{
		if (this.IsQteEnd || !this.IsQteStart)
		{
			return;
		}
		this.OnInput();
	}

	// Token: 0x060114EF RID: 70895 RVA: 0x004C3368 File Offset: 0x004C1568
	private void OnInput()
	{
		int handleId = (int)(this.OpenParam ?? 0);
		ModelBase<PanelQteModel>.Instance.SetQteResult(handleId, true);
		ControllerBase<PanelQteController>.Instance.StopQte(handleId, false);
	}

	// Token: 0x060114F0 RID: 70896 RVA: 0x004C33A8 File Offset: 0x004C15A8
	protected override void HandleQteEnd()
	{
		if (this.DelayTimer != null)
		{
			return;
		}
		if (!this.IsMobile)
		{
			base.GetItem(1).SetUIActive(false);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		if (ModelBase<PanelQteModel>.Instance.IsQteSuccess())
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
		this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.DelayTimer = null;
			Singleton<UiManager>.Instance.CloseView(EUiViewName.InteractQteView, null);
		}, 500f, null, null, true, 1f);
	}

	// Token: 0x060114F1 RID: 70897 RVA: 0x004C345F File Offset: 0x004C165F
	private void SetPlayRate(string sequenceName, float playRate)
	{
		AUIBaseActor auibaseActor = this.AnimItem.GetOwner() as AUIBaseActor;
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

	// Token: 0x040087F3 RID: 34803
	[Nullable(2)]
	private CombineKeyItem KeyItem;

	// Token: 0x040087F4 RID: 34804
	[Nullable(2)]
	private TimerHandle DelayTimer;

	// Token: 0x040087F5 RID: 34805
	[Nullable(2)]
	private UUIItem AnimItem;

	// Token: 0x040087F6 RID: 34806
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040087F7 RID: 34807
	private Number LoopDuration = 0;

	// Token: 0x040087F8 RID: 34808
	private const int STOP_ANIM_TIME = 500;

	// Token: 0x02008671 RID: 34417
	[NullableContext(0)]
	private enum EPadChildType
	{
		// Token: 0x0402D7AE RID: 186286
		AnimItem,
		// Token: 0x0402D7AF RID: 186287
		BtnClick
	}

	// Token: 0x02008672 RID: 34418
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402D7B1 RID: 186289
		AnimItem,
		// Token: 0x0402D7B2 RID: 186290
		KeyItemContainer,
		// Token: 0x0402D7B3 RID: 186291
		KeyItem
	}
}
