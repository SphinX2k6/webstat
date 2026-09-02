using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200134B RID: 4939
public class LifePointDrawDetailItem : GridProxyAbstract<int>
{
	// Token: 0x06008700 RID: 34560 RVA: 0x00238838 File Offset: 0x00236A38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008701 RID: 34561 RVA: 0x00238941 File Offset: 0x00236B41
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x06008702 RID: 34562 RVA: 0x0023897C File Offset: 0x00236B7C
	private bool OnCanExecuteChange()
	{
		LifePointDrawViewModel lifePointDrawDetailViewModel = this.LifePointDrawDetailViewModel;
		if (((lifePointDrawDetailViewModel != null) ? new bool?(lifePointDrawDetailViewModel.GetChallengeLockState(this.Data.GetValueOrDefault())) : null).GetValueOrDefault())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Colorful_Locked", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x06008703 RID: 34563 RVA: 0x002389D4 File Offset: 0x00236BD4
	private void OnClickToggle(EToggleState toggleState)
	{
		LifePointDrawViewModel lifePointDrawDetailViewModel = this.LifePointDrawDetailViewModel;
		if (lifePointDrawDetailViewModel == null)
		{
			return;
		}
		lifePointDrawDetailViewModel.OnSelectChallenge(this.Data.GetValueOrDefault());
	}

	// Token: 0x06008704 RID: 34564 RVA: 0x002389F1 File Offset: 0x00236BF1
	[NullableContext(1)]
	public void SetModel(LifePointDrawViewModel vm)
	{
		this.LifePointDrawDetailViewModel = vm;
	}

	// Token: 0x06008705 RID: 34565 RVA: 0x002389FC File Offset: 0x00236BFC
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.Data = new int?(data);
		LifePointDrawViewModel lifePointDrawDetailViewModel = this.LifePointDrawDetailViewModel;
		EToggleState state = ((lifePointDrawDetailViewModel != null) ? new bool?(lifePointDrawDetailViewModel.CheckChallengeIfSelect(data)) : null).GetValueOrDefault() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		LifePointDrawViewModel lifePointDrawDetailViewModel2 = this.LifePointDrawDetailViewModel;
		bool? flag = (lifePointDrawDetailViewModel2 != null) ? new bool?(lifePointDrawDetailViewModel2.GetChallengeLockState(this.Data.GetValueOrDefault())) : null;
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(flag.GetValueOrDefault());
		}
		LifePointDrawViewModel lifePointDrawDetailViewModel3 = this.LifePointDrawDetailViewModel;
		bool? flag2 = (lifePointDrawDetailViewModel3 != null) ? new bool?(lifePointDrawDetailViewModel3.GetChallengeFinishState(data)) : null;
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(flag2.GetValueOrDefault());
		}
		LifePointDrawViewModel lifePointDrawDetailViewModel4 = this.LifePointDrawDetailViewModel;
		string textStringId = (lifePointDrawDetailViewModel4 != null) ? lifePointDrawDetailViewModel4.GetChallengeTitleId(data) : null;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.LifePointDrawChallengeRedDot, base.GetItem(4), data);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.LifePointDrawChallengeRedDot, base.GetItem(4), null, data);
	}

	// Token: 0x06008706 RID: 34566 RVA: 0x00238B38 File Offset: 0x00236D38
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.LifePointDrawChallengeRedDot, base.GetItem(4), this.Data.Value);
	}

	// Token: 0x04003FB1 RID: 16305
	[Nullable(2)]
	private LifePointDrawViewModel LifePointDrawDetailViewModel;

	// Token: 0x04003FB2 RID: 16306
	private int? Data;

	// Token: 0x020076ED RID: 30445
	private class EItemComponent
	{
		// Token: 0x04028F4E RID: 167758
		public const int Toggle = 0;

		// Token: 0x04028F4F RID: 167759
		public const int TitleText = 1;

		// Token: 0x04028F50 RID: 167760
		public const int LockItem = 2;

		// Token: 0x04028F51 RID: 167761
		public const int FinishItem = 3;

		// Token: 0x04028F52 RID: 167762
		public const int RedDotItem = 4;
	}
}
