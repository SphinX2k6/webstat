using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015F5 RID: 5621
[NullableContext(2)]
[Nullable(0)]
public class ActivityTurntableToggleItem : UiPanelBase
{
	// Token: 0x06009E73 RID: 40563 RVA: 0x0029775C File Offset: 0x0029595C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleCallBackInternal));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009E74 RID: 40564 RVA: 0x00297824 File Offset: 0x00295A24
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(0);
		if (this.Toggle != null)
		{
			this.Toggle.CanExecuteChange.Unbind();
			this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChangeInternal));
		}
	}

	// Token: 0x06009E75 RID: 40565 RVA: 0x00297872 File Offset: 0x00295A72
	public void Refresh(int roundId)
	{
		this.RoundId = roundId;
		this.RefreshIndex();
	}

	// Token: 0x06009E76 RID: 40566 RVA: 0x00297884 File Offset: 0x00295A84
	private void RefreshIndex()
	{
		int value = this.RoundId + 1;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_TurntableSelect_Index0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(2), false, null, null);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_TurntableNormal_Index0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		string resourceId2 = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
		this.SetSpriteByPath(resourcePath2, base.GetSprite(1), false, null, null);
	}

	// Token: 0x06009E77 RID: 40567 RVA: 0x00297934 File Offset: 0x00295B34
	public EToggleState GetToggleState()
	{
		return this.Toggle.GetToggleState();
	}

	// Token: 0x06009E78 RID: 40568 RVA: 0x00297941 File Offset: 0x00295B41
	public void SetToggleState(bool bSelectOn, bool bFireEvent = false)
	{
		this.Toggle.SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x06009E79 RID: 40569 RVA: 0x00297959 File Offset: 0x00295B59
	private bool CanToggleExecuteChangeInternal()
	{
		return this.CanToggleExecuteChange == null || this.CanToggleExecuteChange(this.RoundId);
	}

	// Token: 0x06009E7A RID: 40570 RVA: 0x00297976 File Offset: 0x00295B76
	private void ToggleCallBackInternal(EToggleState toggleState)
	{
		Action<int, bool> toggleCallBack = this.ToggleCallBack;
		if (toggleCallBack == null)
		{
			return;
		}
		toggleCallBack(this.RoundId, this.Toggle.GetToggleState() == EToggleState.ETT_Checked);
	}

	// Token: 0x040048E3 RID: 18659
	public int RoundId;

	// Token: 0x040048E4 RID: 18660
	protected UUIExtendToggle Toggle;

	// Token: 0x040048E5 RID: 18661
	public Func<int, bool> CanToggleExecuteChange;

	// Token: 0x040048E6 RID: 18662
	public Action<int, bool> ToggleCallBack;

	// Token: 0x020079B6 RID: 31158
	[NullableContext(0)]
	internal class EToggleComponents
	{
		// Token: 0x04029CB9 RID: 171193
		public const int Toggle = 0;

		// Token: 0x04029CBA RID: 171194
		public const int SpriteNormal = 1;

		// Token: 0x04029CBB RID: 171195
		public const int SpriteSelect = 2;
	}
}
