using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006767 RID: 26471
	internal class DifficultLineCrossItem : UiPanelBase
	{
		// Token: 0x06041FC2 RID: 270274 RVA: 0x010EE1D0 File Offset: 0x010EC3D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
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
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041FC3 RID: 270275 RVA: 0x010EE2B8 File Offset: 0x010EC4B8
		protected override void OnStart()
		{
		}

		// Token: 0x06041FC4 RID: 270276 RVA: 0x010EE2BC File Offset: 0x010EC4BC
		private bool OnCanExecuteChange()
		{
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			bool? flag = (lineCrossDetailViewModel != null) ? new bool?(lineCrossDetailViewModel.GetChallengeLockState(this.Data.Value)) : null;
			if (flag != null && flag.Value)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("LineCross_Locked", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x06041FC5 RID: 270277 RVA: 0x010EE31D File Offset: 0x010EC51D
		[NullableContext(1)]
		public void SetModel(LineCrossDetailViewModel vm)
		{
			this.LineCrossDetailViewModel = vm;
		}

		// Token: 0x06041FC6 RID: 270278 RVA: 0x010EE326 File Offset: 0x010EC526
		private void OnClickToggle(EToggleState toggleState)
		{
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			if (lineCrossDetailViewModel == null)
			{
				return;
			}
			lineCrossDetailViewModel.OnSelectChallenge(this.Data.Value);
		}

		// Token: 0x06041FC7 RID: 270279 RVA: 0x010EE344 File Offset: 0x010EC544
		public void Refresh(int data, int selectData)
		{
			this.Data = new int?(data);
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			string text = (lineCrossDetailViewModel != null) ? lineCrossDetailViewModel.GetChallengeTitleId(data) : null;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), text ?? string.Empty, Array.Empty<object>());
			this.RefreshToggle(selectData);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.LineCrossChallengeRedDot, base.GetItem(3), data);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.LineCrossChallengeRedDot, base.GetItem(3), null, data);
			LineCrossDetailViewModel lineCrossDetailViewModel2 = this.LineCrossDetailViewModel;
			bool? flag = (lineCrossDetailViewModel2 != null) ? new bool?(lineCrossDetailViewModel2.GetChallengeFinishState(data)) : null;
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag != null && flag.Value);
		}

		// Token: 0x06041FC8 RID: 270280 RVA: 0x010EE40C File Offset: 0x010EC60C
		public void RefreshToggle(int data)
		{
			LineCrossDetailViewModel lineCrossDetailViewModel = this.LineCrossDetailViewModel;
			bool? flag = (lineCrossDetailViewModel != null) ? new bool?(lineCrossDetailViewModel.GetChallengeLockState(this.Data.Value)) : null;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.CanExecuteChange.Unbind();
			}
			int? data2 = this.Data;
			EToggleState etoggleState = (data2.GetValueOrDefault() == data & data2 != null) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			EToggleState state = (flag != null && flag.Value) ? EToggleState.ETT_UnDetermined : etoggleState;
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
			if (extendToggle2 != null)
			{
				extendToggle2.SetToggleState(state, false, false, false);
			}
			UUIExtendToggle extendToggle3 = base.GetExtendToggle(0);
			if (extendToggle3 == null)
			{
				return;
			}
			extendToggle3.CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
		}

		// Token: 0x04024CEA RID: 150762
		[Nullable(2)]
		private LineCrossDetailViewModel LineCrossDetailViewModel;

		// Token: 0x04024CEB RID: 150763
		private int? Data;

		// Token: 0x0200C784 RID: 51076
		private class EDifficultItem
		{
			// Token: 0x0403D6CD RID: 251597
			public const int Toggle = 0;

			// Token: 0x0403D6CE RID: 251598
			public const int Text = 1;

			// Token: 0x0403D6CF RID: 251599
			public const int FinishItem = 2;

			// Token: 0x0403D6D0 RID: 251600
			public const int RedDot = 3;
		}
	}
}
