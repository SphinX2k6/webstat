using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E2E RID: 24110
	[NullableContext(1)]
	[Nullable(0)]
	public class AmountItem : UiPanelBase
	{
		// Token: 0x0603CAC6 RID: 248518 RVA: 0x00F691D0 File Offset: 0x00F673D0
		public AmountItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CAC7 RID: 248519 RVA: 0x00F691EC File Offset: 0x00F673EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(delegate()
			{
				this.OnAdd();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(delegate()
			{
				this.OnDel();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(delegate()
			{
				this.OnShowBtnClick();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CAC8 RID: 248520 RVA: 0x00F6931A File Offset: 0x00F6751A
		protected override void OnStart()
		{
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603CAC9 RID: 248521 RVA: 0x00F69334 File Offset: 0x00F67534
		private UniTask InitCommonItemCountPanel()
		{
			AmountItem.<InitCommonItemCountPanel>d__7 <InitCommonItemCountPanel>d__;
			<InitCommonItemCountPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCommonItemCountPanel>d__.<>4__this = this;
			<InitCommonItemCountPanel>d__.<>1__state = -1;
			<InitCommonItemCountPanel>d__.<>t__builder.Start<AmountItem.<InitCommonItemCountPanel>d__7>(ref <InitCommonItemCountPanel>d__);
			return <InitCommonItemCountPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603CACA RID: 248522 RVA: 0x00F69378 File Offset: 0x00F67578
		private void SetSumText(int sum)
		{
			int maxCallback = this.GetMaxCallback();
			this.Sum = ((maxCallback < sum) ? maxCallback : sum);
			if (this.Sum < 1)
			{
				this.Sum = 1;
			}
			if (this.OnSetSumCallback != null)
			{
				this.OnSetSumCallback(this.Sum);
			}
			base.GetText(3).SetText(this.Sum.ToString(), true);
			this.RefreshAddAndDelButton();
		}

		// Token: 0x0603CACB RID: 248523 RVA: 0x00F693E1 File Offset: 0x00F675E1
		public void ResetSum()
		{
			this.Sum = 1;
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603CACC RID: 248524 RVA: 0x00F69404 File Offset: 0x00F67604
		public void RefreshAddAndDelButton()
		{
			((base.GetButton(1).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(this.Sum != 1);
			((base.GetButton(0).GetOwner() as AUIBaseActor).GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(this.Sum < this.GetMaxCallback());
		}

		// Token: 0x0603CACD RID: 248525 RVA: 0x00F6947F File Offset: 0x00F6767F
		public void BindGetMaxCallback(Func<int> onGetMaxCallback)
		{
			this.OnGetMaxCallback = onGetMaxCallback;
		}

		// Token: 0x0603CACE RID: 248526 RVA: 0x00F69488 File Offset: 0x00F67688
		public void BindSetSumCallback(Action<int> onSetSumCallback)
		{
			this.OnSetSumCallback = onSetSumCallback;
		}

		// Token: 0x0603CACF RID: 248527 RVA: 0x00F69494 File Offset: 0x00F67694
		private int GetMaxCallback()
		{
			if (this.OnGetMaxCallback != null)
			{
				int num = this.OnGetMaxCallback();
				if (num != 0)
				{
					return num;
				}
			}
			return 1;
		}

		// Token: 0x0603CAD0 RID: 248528 RVA: 0x00F694BC File Offset: 0x00F676BC
		private void OnAdd()
		{
			this.Sum++;
			if (this.OnSetSumCallback != null)
			{
				this.OnSetSumCallback(this.Sum);
			}
			this.RefreshAddAndDelButton();
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603CAD1 RID: 248529 RVA: 0x00F69510 File Offset: 0x00F67710
		private void OnDel()
		{
			this.Sum--;
			if (this.OnSetSumCallback != null)
			{
				this.OnSetSumCallback(this.Sum);
			}
			this.RefreshAddAndDelButton();
			base.GetText(3).SetText(this.Sum.ToString(), true);
		}

		// Token: 0x0603CAD2 RID: 248530 RVA: 0x00F69562 File Offset: 0x00F67762
		private void OnShowBtnClick()
		{
			this.OnShowCommonItemCountPanel().Forget();
		}

		// Token: 0x0603CAD3 RID: 248531 RVA: 0x00F69570 File Offset: 0x00F67770
		private UniTask OnShowCommonItemCountPanel()
		{
			AmountItem.<OnShowCommonItemCountPanel>d__17 <OnShowCommonItemCountPanel>d__;
			<OnShowCommonItemCountPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowCommonItemCountPanel>d__.<>4__this = this;
			<OnShowCommonItemCountPanel>d__.<>1__state = -1;
			<OnShowCommonItemCountPanel>d__.<>t__builder.Start<AmountItem.<OnShowCommonItemCountPanel>d__17>(ref <OnShowCommonItemCountPanel>d__);
			return <OnShowCommonItemCountPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0402213E RID: 139582
		private int Sum = 1;

		// Token: 0x0402213F RID: 139583
		[Nullable(2)]
		private Func<int> OnGetMaxCallback;

		// Token: 0x04022140 RID: 139584
		[Nullable(2)]
		private Action<int> OnSetSumCallback;

		// Token: 0x04022141 RID: 139585
		[Nullable(2)]
		private CommonItemCountPanel CommonItemCountPanel;
	}
}
