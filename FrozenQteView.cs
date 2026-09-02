using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200235B RID: 9051
[NullableContext(1)]
[Nullable(0)]
public class FrozenQteView : PanelQteView
{
	// Token: 0x060114CE RID: 70862 RVA: 0x004C2796 File Offset: 0x004C0996
	public FrozenQteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060114CF RID: 70863 RVA: 0x004C27B8 File Offset: 0x004C09B8
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num;
		Span<ValueTuple<int, Type>> span;
		int num2;
		if (this.IsMobile)
		{
			num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
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

	// Token: 0x060114D0 RID: 70864 RVA: 0x004C28F4 File Offset: 0x004C0AF4
	protected override void OnStart()
	{
		base.OnStart();
		if (this.IsMobile)
		{
			UUIButtonComponent button = base.GetButton(0);
			UUIButtonComponent button2 = base.GetButton(1);
			button.OnPointDownCallBack.Bind(delegate()
			{
				this.OnPress(0);
			});
			button2.OnPointDownCallBack.Bind(delegate()
			{
				this.OnPress(1);
			});
			QteAnimItem qteAnimItem = new QteAnimItem();
			qteAnimItem.Init(base.GetItem(2));
			qteAnimItem.StartAnim(0f);
			QteAnimItem qteAnimItem2 = new QteAnimItem();
			qteAnimItem2.Init(base.GetItem(3));
			qteAnimItem2.StartAnim(230f);
			this.AnimItemList.Add(qteAnimItem);
			this.AnimItemList.Add(qteAnimItem2);
		}
		else
		{
			QteAnimItem qteAnimItem3 = new QteAnimItem();
			qteAnimItem3.Init(base.GetItem(2));
			qteAnimItem3.StartAnim(0f);
			this.AnimItemList.Add(qteAnimItem3);
			this.InputControllerChangeInner();
		}
		this.TipItem = new QteTipItem();
		this.TipItem.Init(this.RootItem);
		this.TipItem.Refresh("Text_FrozenQteTip_Text");
		this.InitQteData();
	}

	// Token: 0x060114D1 RID: 70865 RVA: 0x004C2A08 File Offset: 0x004C0C08
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.CFT, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
		}
	}

	// Token: 0x060114D2 RID: 70866 RVA: 0x004C2A54 File Offset: 0x004C0C54
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		if (this.IsMobile)
		{
			UUIButtonComponent button = base.GetButton(0);
			UUIButtonComponent button2 = base.GetButton(1);
			button.OnPointDownCallBack.Unbind();
			button2.OnPointDownCallBack.Unbind();
		}
		foreach (QteAnimItem qteAnimItem in this.AnimItemList)
		{
			qteAnimItem.Clear();
		}
		this.StopDelayTimer();
		this.TipItem.Destroy(null);
		this.TipItem = null;
	}

	// Token: 0x060114D3 RID: 70867 RVA: 0x004C2AF0 File Offset: 0x004C0CF0
	private void StopDelayTimer()
	{
		if (this.DelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.DelayTimer);
			this.DelayTimer = null;
		}
	}

	// Token: 0x060114D4 RID: 70868 RVA: 0x004C2B14 File Offset: 0x004C0D14
	private void InitQteData()
	{
		this.InputCount = 0;
		int num = (int)(this.OpenParam ?? 0);
		if (!ModelBase<PanelQteModel>.Instance.IsInQte.GetValueOrDefault())
		{
			Singleton<Log>.Instance.Info(ELogModule.PanelQte, ELogAuthor.CFT, "界面打开时qte已经结束了", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
			return;
		}
		PanelQteContext context = ModelBase<PanelQteModel>.Instance.GetContext();
		if (num != context.QteHandleId)
		{
			Singleton<Log>.Instance.Error(ELogModule.PanelQte, ELogAuthor.CFT, "qte handleId 不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			base.CloseMe(null);
			return;
		}
		int maxSuccessCount = context.Config.MaxSuccessCount;
		int minSuccessCount = context.Config.MinSuccessCount;
		this.MaxCount = (int)Math.Floor((double)Singleton<MathUtils>.Instance.GetRandomFloatNumber((float)minSuccessCount, (float)(maxSuccessCount + 1)));
		base.InitCameraShake(context.Config);
		base.InitBuff(context.Config);
	}

	// Token: 0x060114D5 RID: 70869 RVA: 0x004C2C00 File Offset: 0x004C0E00
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputCallback));
		}
	}

	// Token: 0x060114D6 RID: 70870 RVA: 0x004C2C2B File Offset: 0x004C0E2B
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		if (!this.IsMobile)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnInputCallback));
		}
	}

	// Token: 0x060114D7 RID: 70871 RVA: 0x004C2C58 File Offset: 0x004C0E58
	protected override void InputControllerChangeInner()
	{
		bool flag = Singleton<Info>.Instance.IsInGamepad();
		UUIItem item = base.GetItem(0);
		UUIItem item2 = base.GetItem(1);
		item.SetUIActive(!flag);
		item2.SetUIActive(flag);
	}

	// Token: 0x060114D8 RID: 70872 RVA: 0x004C2C90 File Offset: 0x004C0E90
	private void OnInputCallback(string axisName, float value, InputIdentification identification)
	{
		if (this.IsQteEnd)
		{
			return;
		}
		if (value > 0f)
		{
			this.AnimItemList[0].PressAnim();
			this.OnInput(1);
			return;
		}
		if (value < 0f)
		{
			this.AnimItemList[0].PressAnim();
			this.OnInput(0);
		}
	}

	// Token: 0x060114D9 RID: 70873 RVA: 0x004C2CE7 File Offset: 0x004C0EE7
	private void OnPress(int index)
	{
		if (this.IsQteEnd)
		{
			return;
		}
		this.AnimItemList[index].PressAnim();
		this.OnInput(index);
	}

	// Token: 0x060114DA RID: 70874 RVA: 0x004C2D0C File Offset: 0x004C0F0C
	private void OnInput(int index)
	{
		this.Input[index] = true;
		if (this.Input[0] && this.Input[1])
		{
			this.Input[0] = false;
			this.Input[1] = false;
			this.InputCount++;
			if (this.InputCount == this.MaxCount)
			{
				int handleId = (int)(this.OpenParam ?? 0);
				ModelBase<PanelQteModel>.Instance.SetQteResult(handleId, true);
				ControllerBase<PanelQteController>.Instance.StopQte(handleId, false);
			}
		}
		base.PlayCameraShake();
		base.AddBuff();
	}

	// Token: 0x060114DB RID: 70875 RVA: 0x004C2DA0 File Offset: 0x004C0FA0
	protected override void HandleQteEnd()
	{
		if (this.DelayTimer != null)
		{
			return;
		}
		foreach (QteAnimItem qteAnimItem in this.AnimItemList)
		{
			qteAnimItem.StopAnim();
		}
		this.DelayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.DelayTimer = null;
			base.CloseMe(null);
		}, 100f, null, null, true, 1f);
	}

	// Token: 0x040087EB RID: 34795
	private int InputCount;

	// Token: 0x040087EC RID: 34796
	private int MaxCount;

	// Token: 0x040087ED RID: 34797
	private readonly bool[] Input = new bool[2];

	// Token: 0x040087EE RID: 34798
	private readonly List<QteAnimItem> AnimItemList = new List<QteAnimItem>();

	// Token: 0x040087EF RID: 34799
	[Nullable(2)]
	private TimerHandle DelayTimer;

	// Token: 0x040087F0 RID: 34800
	[Nullable(2)]
	private QteTipItem TipItem;

	// Token: 0x040087F1 RID: 34801
	private const int STOP_ANIM_TIME = 100;

	// Token: 0x040087F2 RID: 34802
	private const int LOOP_ANIM_TIME = 230;

	// Token: 0x0200866F RID: 34415
	[NullableContext(0)]
	private enum EPadChildType
	{
		// Token: 0x0402D7A5 RID: 186277
		BtnClickLeft,
		// Token: 0x0402D7A6 RID: 186278
		BtnClickRight,
		// Token: 0x0402D7A7 RID: 186279
		ItemLeft,
		// Token: 0x0402D7A8 RID: 186280
		ItemRight
	}

	// Token: 0x02008670 RID: 34416
	[NullableContext(0)]
	private enum EDesktopChildType
	{
		// Token: 0x0402D7AA RID: 186282
		KeyboardItem,
		// Token: 0x0402D7AB RID: 186283
		GamepadItem,
		// Token: 0x0402D7AC RID: 186284
		AnimItem
	}
}
