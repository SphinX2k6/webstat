using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002360 RID: 9056
[NullableContext(1)]
[Nullable(0)]
public class YouHuQteView : PanelQteView
{
	// Token: 0x06011518 RID: 70936 RVA: 0x004C3B50 File Offset: 0x004C1D50
	public YouHuQteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011519 RID: 70937 RVA: 0x004C3B9C File Offset: 0x004C1D9C
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num;
		Span<ValueTuple<int, Type>> span;
		int num2;
		if (this.IsMobile)
		{
			num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			return;
		}
		num2 = 19;
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
		*span[num] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num++;
		*span[num] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
		num++;
		*span[num] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num++;
		*span[num] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list2;
	}

	// Token: 0x0601151A RID: 70938 RVA: 0x004C3FDC File Offset: 0x004C21DC
	protected override UniTask OnBeforeStartAsync()
	{
		YouHuQteView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<YouHuQteView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601151B RID: 70939 RVA: 0x004C4020 File Offset: 0x004C2220
	protected override void OnStart()
	{
		base.OnStart();
		if (this.IsMobile)
		{
			this.ProgressTexture = base.GetTexture(5);
			this.ProgressEffect = base.GetUiNiagara(6);
			this.AnimItem = base.GetItem(0);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.AnimItem);
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(1)));
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(2)));
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(3)));
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(4)));
			base.GetButton(7).OnPointDownCallBack.Bind(delegate()
			{
				this.OnInput(0);
			});
			base.GetButton(8).OnPointDownCallBack.Bind(delegate()
			{
				this.OnInput(1);
			});
			base.GetButton(9).OnPointDownCallBack.Bind(delegate()
			{
				this.OnInput(2);
			});
			base.GetButton(10).OnPointDownCallBack.Bind(delegate()
			{
				this.OnInput(3);
			});
		}
		else
		{
			this.ProgressTexture = base.GetTexture(5);
			this.ProgressEffect = base.GetUiNiagara(6);
			this.AnimItem = base.GetItem(0);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.AnimItem);
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(1)));
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(2)));
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(3)));
			this.LevelSequencePlayerList.Add(new LevelSequencePlayer(base.GetItem(4)));
			this.RefreshEffectVisible();
		}
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		this.InitQteData();
	}

	// Token: 0x0601151C RID: 70940 RVA: 0x004C4208 File Offset: 0x004C2408
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.CFT, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.YouHuQteView, null);
		}
	}

	// Token: 0x0601151D RID: 70941 RVA: 0x004C425C File Offset: 0x004C245C
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		if (this.IsMobile)
		{
			base.GetButton(7).OnPointDownCallBack.Unbind();
			base.GetButton(8).OnPointDownCallBack.Unbind();
			base.GetButton(9).OnPointDownCallBack.Unbind();
			base.GetButton(10).OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		foreach (LevelSequencePlayer levelSequencePlayer2 in this.LevelSequencePlayerList)
		{
			levelSequencePlayer2.Clear();
		}
		this.LevelSequencePlayerList.Clear();
		this.StopDelayTimer();
	}

	// Token: 0x0601151E RID: 70942 RVA: 0x004C432C File Offset: 0x004C252C
	protected override void RefreshVisible()
	{
	}

	// Token: 0x0601151F RID: 70943 RVA: 0x004C432E File Offset: 0x004C252E
	private void StopDelayTimer()
	{
		if (this.DelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.DelayTimer);
			this.DelayTimer = null;
		}
	}

	// Token: 0x06011520 RID: 70944 RVA: 0x004C4350 File Offset: 0x004C2550
	private void InitQteData()
	{
		int num = (int)(this.OpenParam ?? 0);
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.CFT, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.YouHuQteView, null);
			return;
		}
		PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
		if (num != context.QteHandleId)
		{
			Singleton<Log>.Instance.Error(ELogModule.PanelQte, ELogAuthor.CFT, "qte handleId 不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiManager>.Instance.CloseView(EUiViewName.YouHuQteView, null);
			return;
		}
		this.DurationMs = context.Config.Duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start02", false, null, false);
	}

	// Token: 0x06011521 RID: 70945 RVA: 0x004C443C File Offset: 0x004C263C
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start02")
		{
			if (this.IsQteEnd)
			{
				return;
			}
			int handleId = (int)(this.OpenParam ?? 0);
			ModelBase<PanelQteModel>.Instance.ResetLeftTime(handleId);
			this.IsQteStart = true;
		}
	}

	// Token: 0x06011522 RID: 70946 RVA: 0x004C4488 File Offset: 0x004C2688
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (this.IsPause || this.IsQteEnd)
		{
			return;
		}
		float num = Math.Max(ModelBase<PanelQteModel>.Instance.GetLeftTimeNoScale() / this.DurationMs, 0f);
		UUITexture progressTexture = this.ProgressTexture;
		if (progressTexture != null)
		{
			progressTexture.SetFillAmount(num);
		}
		UUINiagara progressEffect = this.ProgressEffect;
		if (progressEffect == null)
		{
			return;
		}
		progressEffect.SetNiagaraVarFloat("Dissolve", num);
	}

	// Token: 0x06011523 RID: 70947 RVA: 0x004C44FB File Offset: 0x004C26FB
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.BindActions(YouHuQteView.ActionNames, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
		}
	}

	// Token: 0x06011524 RID: 70948 RVA: 0x004C4526 File Offset: 0x004C2726
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActions(YouHuQteView.ActionNames, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
		}
	}

	// Token: 0x06011525 RID: 70949 RVA: 0x004C4554 File Offset: 0x004C2754
	private void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
	{
		if (this.IsQteEnd || !this.IsQteStart)
		{
			return;
		}
		if (actionType == InputDistributeDefine.EActionType.Press)
		{
			int num = Array.IndexOf<string>(YouHuQteView.ActionNames, actionName);
			if (num == -1)
			{
				return;
			}
			this.OnInput(num);
		}
	}

	// Token: 0x06011526 RID: 70950 RVA: 0x004C4590 File Offset: 0x004C2790
	private void OnInput(int index)
	{
		this.LevelSequencePlayerList[index].PlayLevelSequenceByName("ButtonPre", false, null, false);
		int num = (int)(this.OpenParam ?? 0);
		PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
		if (num == context.QteHandleId)
		{
			context.BuffIndex = index;
		}
		ModelBase<PanelQteModel>.Instance.SetQteResult(num, true);
		ControllerBase<PanelQteController>.Instance.StopQte(num, false);
	}

	// Token: 0x06011527 RID: 70951 RVA: 0x004C4609 File Offset: 0x004C2809
	protected override void InputControllerChangeInner()
	{
		this.RefreshEffectVisible();
	}

	// Token: 0x06011528 RID: 70952 RVA: 0x004C4614 File Offset: 0x004C2814
	private void RefreshEffectVisible()
	{
		bool uiactive = Singleton<Info>.Instance.IsInGamepad();
		foreach (UUIItem uuiitem in this.GamepadEffectList)
		{
			uuiitem.SetUIActive(uiactive);
		}
		bool uiactive2 = Singleton<Info>.Instance.IsInKeyBoard();
		foreach (UUIItem uuiitem2 in this.KeyboardEffectList)
		{
			uuiitem2.SetUIActive(uiactive2);
		}
	}

	// Token: 0x06011529 RID: 70953 RVA: 0x004C46BC File Offset: 0x004C28BC
	protected override void HandleQteEnd()
	{
		if (this.DelayTimer != null)
		{
			return;
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}
		this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.DelayTimer = null;
			Singleton<UiManager>.Instance.CloseView(EUiViewName.YouHuQteView, null);
		}, 333f, null, null, true, 1f);
	}

	// Token: 0x0400880D RID: 34829
	private readonly List<InputMultiKeyItem> KeyItemList = new List<InputMultiKeyItem>();

	// Token: 0x0400880E RID: 34830
	[Nullable(2)]
	private UUITexture ProgressTexture;

	// Token: 0x0400880F RID: 34831
	[Nullable(2)]
	private UUINiagara ProgressEffect;

	// Token: 0x04008810 RID: 34832
	[Nullable(2)]
	private UUIItem AnimItem;

	// Token: 0x04008811 RID: 34833
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04008812 RID: 34834
	private readonly List<LevelSequencePlayer> LevelSequencePlayerList = new List<LevelSequencePlayer>();

	// Token: 0x04008813 RID: 34835
	private readonly List<UUIItem> KeyboardEffectList = new List<UUIItem>();

	// Token: 0x04008814 RID: 34836
	private readonly List<UUIItem> GamepadEffectList = new List<UUIItem>();

	// Token: 0x04008815 RID: 34837
	[Nullable(2)]
	private TimerHandle DelayTimer;

	// Token: 0x04008816 RID: 34838
	private Number DurationMs = 0;

	// Token: 0x04008817 RID: 34839
	private const int STOP_ANIM_TIME = 333;

	// Token: 0x04008818 RID: 34840
	[StaticVariableRuleIgnore]
	private static readonly string[] ActionNames = new string[]
	{
		"QTE数字1",
		"QTE数字2",
		"QTE数字3",
		"QTE数字4"
	};

	// Token: 0x02008675 RID: 34421
	[NullableContext(0)]
	private enum EPadChildType
	{
		// Token: 0x0402D7BB RID: 186299
		AnimItem,
		// Token: 0x0402D7BC RID: 186300
		AnimItem1,
		// Token: 0x0402D7BD RID: 186301
		AnimItem2,
		// Token: 0x0402D7BE RID: 186302
		AnimItem3,
		// Token: 0x0402D7BF RID: 186303
		AnimItem4,
		// Token: 0x0402D7C0 RID: 186304
		ProgressTexture,
		// Token: 0x0402D7C1 RID: 186305
		ProgressEffect,
		// Token: 0x0402D7C2 RID: 186306
		BtnItem1,
		// Token: 0x0402D7C3 RID: 186307
		BtnItem2,
		// Token: 0x0402D7C4 RID: 186308
		BtnItem3,
		// Token: 0x0402D7C5 RID: 186309
		BtnItem4
	}

	// Token: 0x02008676 RID: 34422
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402D7C7 RID: 186311
		AnimItem,
		// Token: 0x0402D7C8 RID: 186312
		AnimItem1,
		// Token: 0x0402D7C9 RID: 186313
		AnimItem2,
		// Token: 0x0402D7CA RID: 186314
		AnimItem3,
		// Token: 0x0402D7CB RID: 186315
		AnimItem4,
		// Token: 0x0402D7CC RID: 186316
		ProgressTexture,
		// Token: 0x0402D7CD RID: 186317
		ProgressEffect,
		// Token: 0x0402D7CE RID: 186318
		KeyItem1,
		// Token: 0x0402D7CF RID: 186319
		KeyItem2,
		// Token: 0x0402D7D0 RID: 186320
		KeyItem3,
		// Token: 0x0402D7D1 RID: 186321
		KeyItem4,
		// Token: 0x0402D7D2 RID: 186322
		KeyboardEffectItem1,
		// Token: 0x0402D7D3 RID: 186323
		KeyboardEffectItem2,
		// Token: 0x0402D7D4 RID: 186324
		KeyboardEffectItem3,
		// Token: 0x0402D7D5 RID: 186325
		KeyboardEffectItem4,
		// Token: 0x0402D7D6 RID: 186326
		GamepadEffectItem1,
		// Token: 0x0402D7D7 RID: 186327
		GamepadEffectItem2,
		// Token: 0x0402D7D8 RID: 186328
		GamepadEffectItem3,
		// Token: 0x0402D7D9 RID: 186329
		GamepadEffectItem4
	}
}
