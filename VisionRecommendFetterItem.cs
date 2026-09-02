using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200251B RID: 9499
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class VisionRecommendFetterItem : GridProxyAbstract<VisionFetterRecommendInfo>
{
	// Token: 0x060126CB RID: 75467 RVA: 0x005110B8 File Offset: 0x0050F2B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
		};
	}

	// Token: 0x060126CC RID: 75468 RVA: 0x00511138 File Offset: 0x0050F338
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecommendFetterItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecommendFetterItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060126CD RID: 75469 RVA: 0x0051117B File Offset: 0x0050F37B
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		extendToggle.bLockStateOnSelect = true;
	}

	// Token: 0x060126CE RID: 75470 RVA: 0x0051119B File Offset: 0x0050F39B
	public override void Refresh(VisionFetterRecommendInfo data, bool isSelected, int gridIndex)
	{
		VisionEquipmentRecommendFetterGroupView fetterGroupView = this.FetterGroupView;
		if (fetterGroupView != null)
		{
			fetterGroupView.Refresh(data.BuildFetterList());
		}
		this.RefreshUsage(data.GetUsageText());
	}

	// Token: 0x060126CF RID: 75471 RVA: 0x005111C0 File Offset: 0x0050F3C0
	private void RefreshUsage(string txt)
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(txt, true);
	}

	// Token: 0x060126D0 RID: 75472 RVA: 0x005111D5 File Offset: 0x0050F3D5
	private void OnToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onSelectedCallback = this.OnSelectedCallback;
			if (onSelectedCallback == null)
			{
				return;
			}
			onSelectedCallback(base.GridIndex);
		}
	}

	// Token: 0x060126D1 RID: 75473 RVA: 0x005111F1 File Offset: 0x0050F3F1
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(true, fireEvent);
	}

	// Token: 0x060126D2 RID: 75474 RVA: 0x005111FB File Offset: 0x0050F3FB
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(false, fireEvent);
	}

	// Token: 0x060126D3 RID: 75475 RVA: 0x00511205 File Offset: 0x0050F405
	private void SetToggleState(bool isSelected, bool fireEvent = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x060126D4 RID: 75476 RVA: 0x00511222 File Offset: 0x0050F422
	public override object GetKey(VisionFetterRecommendInfo data, int displayIndex)
	{
		return data;
	}

	// Token: 0x04008FCC RID: 36812
	[Nullable(2)]
	private VisionEquipmentRecommendFetterGroupView FetterGroupView;

	// Token: 0x04008FCD RID: 36813
	[Nullable(2)]
	public Action<int> OnSelectedCallback;
}
