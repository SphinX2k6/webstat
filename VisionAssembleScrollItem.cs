using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024E5 RID: 9445
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionAssembleScrollItem : GridProxyAbstract<VisionAssembleScrollItemData>
{
	// Token: 0x06012569 RID: 75113 RVA: 0x0050A6D4 File Offset: 0x005088D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0601256A RID: 75114 RVA: 0x0050A7ED File Offset: 0x005089ED
	private bool CanToggleExecuteChange()
	{
		return !this.CurrentData.CurrentSelectState && this.CurrentData.CheckIfCanSelect();
	}

	// Token: 0x0601256B RID: 75115 RVA: 0x0050A810 File Offset: 0x00508A10
	[NullableContext(0)]
	private UniTask<bool> InitItem()
	{
		VisionAssembleScrollItem.<InitItem>d__6 <InitItem>d__;
		<InitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<InitItem>d__.<>4__this = this;
		<InitItem>d__.<>1__state = -1;
		<InitItem>d__.<>t__builder.Start<VisionAssembleScrollItem.<InitItem>d__6>(ref <InitItem>d__);
		return <InitItem>d__.<>t__builder.Task;
	}

	// Token: 0x0601256C RID: 75116 RVA: 0x0050A853 File Offset: 0x00508A53
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.CurrentData != null)
		{
			this.CurrentData.ClickCallback(this.CurrentData.VisionEquipGroupData);
		}
	}

	// Token: 0x0601256D RID: 75117 RVA: 0x0050A878 File Offset: 0x00508A78
	public override void Refresh(VisionAssembleScrollItemData data, bool isSelected, int gridIndex)
	{
		base.GetExtendToggle(9).CanExecuteChange.Unbind();
		this.CurrentData = data;
		VisionEquipGroupData visionEquipGroupData = data.VisionEquipGroupData;
		string text = (visionEquipGroupData != null) ? (visionEquipGroupData.GetIndex() + 1).ToString() : (gridIndex + 1).ToString();
		if (text.Length < 2)
		{
			text = "0" + text;
		}
		if (visionEquipGroupData == null)
		{
			base.GetItem(0).SetUIActive(true);
			base.GetExtendToggle(9).RootUIComp.Get().SetUIActive(false);
			base.GetText(1).SetText(text, true);
			return;
		}
		base.GetItem(0).SetUIActive(false);
		base.GetExtendToggle(9).RootUIComp.Get().SetUIActive(true);
		base.GetText(7).SetText(text, true);
		string name = visionEquipGroupData.GetName();
		base.GetText(8).SetText(name, true);
		EToggleState state = data.CurrentSelectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(9).SetToggleState(state, false, false, false);
		base.GetExtendToggle(9).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		this.RefreshAssembleItem(data);
	}

	// Token: 0x0601256E RID: 75118 RVA: 0x0050A9A9 File Offset: 0x00508BA9
	public override void Clear()
	{
		this.ResetToUnCheckedWithAnimSkipped();
	}

	// Token: 0x0601256F RID: 75119 RVA: 0x0050A9B4 File Offset: 0x00508BB4
	private UniTask RefreshAssembleItem(VisionAssembleScrollItemData data)
	{
		VisionAssembleScrollItem.<RefreshAssembleItem>d__10 <RefreshAssembleItem>d__;
		<RefreshAssembleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAssembleItem>d__.<>4__this = this;
		<RefreshAssembleItem>d__.data = data;
		<RefreshAssembleItem>d__.<>1__state = -1;
		<RefreshAssembleItem>d__.<>t__builder.Start<VisionAssembleScrollItem.<RefreshAssembleItem>d__10>(ref <RefreshAssembleItem>d__);
		return <RefreshAssembleItem>d__.<>t__builder.Task;
	}

	// Token: 0x06012570 RID: 75120 RVA: 0x0050AA00 File Offset: 0x00508C00
	private void ResetToUnCheckedWithAnimSkipped()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		FToggleAnimationPlayInfo ftoggleAnimationPlayInfo = extendToggle.StateSwitchAnimations.Get(EToggleStateSwitch.CheckedToUnChecked);
		if (ftoggleAnimationPlayInfo == null)
		{
			return;
		}
		FSoftObjectPath levelSequence = ftoggleAnimationPlayInfo.Animation.LevelSequence;
		(extendToggle.GetOwner() as AUIBaseActor).SequenceJumpToEnd(levelSequence);
	}

	// Token: 0x04008F01 RID: 36609
	private readonly List<VisionAssembleItem> AssembleItemList = new List<VisionAssembleItem>();

	// Token: 0x04008F02 RID: 36610
	[Nullable(2)]
	private VisionAssembleScrollItemData CurrentData;

	// Token: 0x04008F03 RID: 36611
	[Nullable(2)]
	private CustomPromise<bool> InitCustomPromise;

	// Token: 0x020087F5 RID: 34805
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DEE8 RID: 188136
		EmptyItem,
		// Token: 0x0402DEE9 RID: 188137
		EmptyItemText,
		// Token: 0x0402DEEA RID: 188138
		VisionAssembleItem1,
		// Token: 0x0402DEEB RID: 188139
		VisionAssembleItem2,
		// Token: 0x0402DEEC RID: 188140
		VisionAssembleItem3,
		// Token: 0x0402DEED RID: 188141
		VisionAssembleItem4,
		// Token: 0x0402DEEE RID: 188142
		VisionAssembleItem5,
		// Token: 0x0402DEEF RID: 188143
		NumText,
		// Token: 0x0402DEF0 RID: 188144
		NameText,
		// Token: 0x0402DEF1 RID: 188145
		Toggle
	}
}
