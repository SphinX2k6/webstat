using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A1D RID: 10781
[NullableContext(2)]
[Nullable(0)]
public class SignalMovePanel : UiComponentAction
{
	// Token: 0x0601584A RID: 88138 RVA: 0x005F73A8 File Offset: 0x005F55A8
	[NullableContext(1)]
	public UniTask Init(UUIItem uiItem, ESignalGameplayType gameplayType)
	{
		SignalMovePanel.<Init>d__8 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.uiItem = uiItem;
		<Init>d__.gameplayType = gameplayType;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<SignalMovePanel.<Init>d__8>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0601584B RID: 88139 RVA: 0x005F73FC File Offset: 0x005F55FC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout))
		};
	}

	// Token: 0x0601584C RID: 88140 RVA: 0x005F7484 File Offset: 0x005F5684
	protected override void OnStart()
	{
		this.LongNode = base.GetItem(0);
		this.ShortNode = base.GetItem(1);
		this.LineNode = base.GetItem(2);
		this.ShortLineNode = base.GetItem(3);
		this.MoveNode = base.GetHorizontalLayout(4);
		this.MoveNode.SetEnable(false);
		this.MoveNode.SetAlign(ELGUILayoutAlignmentType.MiddleLeft);
		this.CreateSignals();
		this.LongNode.SetUIActive(false);
		this.LineNode.SetUIActive(false);
		this.ShortNode.SetUIActive(false);
		this.ShortLineNode.SetUIActive(false);
	}

	// Token: 0x0601584D RID: 88141 RVA: 0x005F7520 File Offset: 0x005F5720
	private void CreateSignals()
	{
		SignalDecodeModel instance = ModelBase<SignalDecodeModel>.Instance;
		string currentMorseCode = instance.CurrentMorseCode;
		this.Speed = instance.Speed;
		int startDecisionSize = instance.StartDecisionSize;
		int endDecisionSize = instance.EndDecisionSize;
		bool flag = instance.CurrentGameplayType == ESignalGameplayType.DrawSword;
		List<SignalItemBase> list = new List<SignalItemBase>();
		float rootHalfWidth = this.RootItem.GetWidth() / 2f;
		float num = 0f;
		for (int i = 0; i < currentMorseCode.Length; i++)
		{
			char c = currentMorseCode[i];
			int num2 = (int)char.GetNumericValue(c);
			if (c < '0' || c > '9')
			{
				num2 = 0;
			}
			if (i != currentMorseCode.Length - 1 && num2 != 0)
			{
				UUIItem uiItem = Singleton<LguiUtil>.Instance.CopyItem(this.LineNode, this.MoveNode.RootUIComp.Get());
				SignalLineItem signalLineItem = new SignalLineItem(ESignalType.Line, rootHalfWidth, startDecisionSize, endDecisionSize);
				signalLineItem.Init(uiItem, num);
				list.Add(signalLineItem);
				num -= signalLineItem.Width;
			}
			SignalItemBase signalItemBase;
			if (num2 != 1)
			{
				if (num2 != 2)
				{
					UUIItem uiItem2 = Singleton<LguiUtil>.Instance.CopyItem(this.LineNode, this.MoveNode.RootUIComp.Get());
					signalItemBase = new SignalLineItem(ESignalType.Line, rootHalfWidth, startDecisionSize, endDecisionSize);
					((SignalLineItem)signalItemBase).Init(uiItem2, num);
				}
				else
				{
					UUIItem uiItem3 = Singleton<LguiUtil>.Instance.CopyItem(this.LongNode, this.MoveNode.RootUIComp.Get());
					signalItemBase = new SignalItem(ESignalType.Long, rootHalfWidth, startDecisionSize, endDecisionSize);
					((SignalItem)signalItemBase).Init(uiItem3, num);
				}
			}
			else
			{
				UUIItem uiItem4 = Singleton<LguiUtil>.Instance.CopyItem(this.ShortNode, this.MoveNode.RootUIComp.Get());
				signalItemBase = new SignalItem(ESignalType.Short, rootHalfWidth, startDecisionSize, endDecisionSize);
				((SignalItem)signalItemBase).Init(uiItem4, num);
			}
			if (num2 == 0 && flag)
			{
				((SignalLineItem)signalItemBase).AddWidth(this.ShortLineNode.GetWidth());
			}
			num -= signalItemBase.Width;
			list.Add(signalItemBase);
		}
		this.Signals = list.ToArray();
	}

	// Token: 0x0601584E RID: 88142 RVA: 0x005F7744 File Offset: 0x005F5944
	public void InitByGameplayType(ESignalGameplayType type)
	{
		if (this.Signals == null)
		{
			return;
		}
		SignalItemBase[] signals = this.Signals;
		for (int i = 0; i < signals.Length; i++)
		{
			signals[i].InitByGameplayType(type);
		}
	}

	// Token: 0x0601584F RID: 88143 RVA: 0x005F7778 File Offset: 0x005F5978
	public void InitMoveNode()
	{
		this.MoveNode.RootUIComp.Get().SetAnchorOffsetX(-1280f);
	}

	// Token: 0x06015850 RID: 88144 RVA: 0x005F77A4 File Offset: 0x005F59A4
	public void StartAgain()
	{
		if (this.Signals == null)
		{
			return;
		}
		SignalItemBase[] signals = this.Signals;
		for (int i = 0; i < signals.Length; i++)
		{
			signals[i].Reset();
		}
	}

	// Token: 0x06015851 RID: 88145 RVA: 0x005F77D7 File Offset: 0x005F59D7
	public void UpdateMove(float delta)
	{
		this.UpdatePanelMove(delta);
		this.UpdateSignals();
	}

	// Token: 0x06015852 RID: 88146 RVA: 0x005F77E8 File Offset: 0x005F59E8
	public float GetCompleteness()
	{
		float num = 0f;
		float num2 = 0f;
		SignalItemBase[] signals = this.Signals;
		for (int i = 0; i < signals.Length; i++)
		{
			SignalItem signalItem = signals[i] as SignalItem;
			if (signalItem != null)
			{
				num2 += signalItem.GetCompleteness();
				num += 1f;
			}
		}
		if (num == 0f)
		{
			return 1f;
		}
		return num2 / num;
	}

	// Token: 0x06015853 RID: 88147 RVA: 0x005F7848 File Offset: 0x005F5A48
	public float GetProgress()
	{
		float num = 0f;
		float num2 = 0f;
		foreach (SignalItemBase signalItemBase in this.Signals)
		{
			num2 += signalItemBase.GetProgress();
			num += 1f;
		}
		if (num == 0f)
		{
			return 1f;
		}
		return num2 / num;
	}

	// Token: 0x06015854 RID: 88148 RVA: 0x005F78A0 File Offset: 0x005F5AA0
	private void UpdatePanelMove(float delta)
	{
		float anchorOffsetX = this.MoveNode.RootUIComp.Get().GetAnchorOffsetX() + delta / 1000f * this.Speed;
		this.MoveNode.RootUIComp.Get().SetAnchorOffsetX(anchorOffsetX);
	}

	// Token: 0x06015855 RID: 88149 RVA: 0x005F78F0 File Offset: 0x005F5AF0
	private void UpdateSignals()
	{
		float anchorOffsetX = this.MoveNode.RootUIComp.Get().GetAnchorOffsetX();
		foreach (SignalItemBase signalItemBase in this.Signals)
		{
			float relativeX = anchorOffsetX + signalItemBase.GetRootItem().GetAnchorOffsetX();
			signalItemBase.Update(relativeX);
		}
	}

	// Token: 0x06015856 RID: 88150 RVA: 0x005F794C File Offset: 0x005F5B4C
	public void OnCatchBtnDown()
	{
		SignalItemBase[] signals = this.Signals;
		for (int i = 0; i < signals.Length; i++)
		{
			signals[i].OnCatchBtnDown();
		}
	}

	// Token: 0x06015857 RID: 88151 RVA: 0x005F7978 File Offset: 0x005F5B78
	public void OnCatchBtnUp()
	{
		SignalItemBase[] signals = this.Signals;
		for (int i = 0; i < signals.Length; i++)
		{
			signals[i].OnCatchBtnUp();
		}
	}

	// Token: 0x0400A5B4 RID: 42420
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SignalItemBase[] Signals;

	// Token: 0x0400A5B5 RID: 42421
	private UUIItem LongNode;

	// Token: 0x0400A5B6 RID: 42422
	private UUIItem ShortNode;

	// Token: 0x0400A5B7 RID: 42423
	private UUIItem LineNode;

	// Token: 0x0400A5B8 RID: 42424
	private UUIItem ShortLineNode;

	// Token: 0x0400A5B9 RID: 42425
	private UUIHorizontalLayout MoveNode;

	// Token: 0x0400A5BA RID: 42426
	private float Speed;

	// Token: 0x02008DA0 RID: 36256
	[NullableContext(0)]
	private static class EChildComponent
	{
		// Token: 0x0402F9F2 RID: 195058
		public const int LongNode = 0;

		// Token: 0x0402F9F3 RID: 195059
		public const int ShortNode = 1;

		// Token: 0x0402F9F4 RID: 195060
		public const int LineNode = 2;

		// Token: 0x0402F9F5 RID: 195061
		public const int ShortLineNode = 3;

		// Token: 0x0402F9F6 RID: 195062
		public const int MoveNode = 4;
	}
}
