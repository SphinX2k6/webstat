using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.AutoPilot
{
	// Token: 0x02004BDD RID: 19421
	[NullableContext(2)]
	[Nullable(0)]
	public class AutoPilotNavBtnView : UiPanelBase
	{
		// Token: 0x1700870F RID: 34575
		// (get) Token: 0x06032ACF RID: 207567 RVA: 0x00CB0FDF File Offset: 0x00CAF1DF
		// (set) Token: 0x06032AD0 RID: 207568 RVA: 0x00CB0FE7 File Offset: 0x00CAF1E7
		public Action OnBtnClickCallback { get; set; }

		// Token: 0x06032AD1 RID: 207569 RVA: 0x00CB0FF0 File Offset: 0x00CAF1F0
		[NullableContext(1)]
		public AutoPilotNavBtnView(WorldMapSecondaryUiAutoPilotContext context)
		{
			this.Context = context;
		}

		// Token: 0x06032AD2 RID: 207570 RVA: 0x00CB1000 File Offset: 0x00CAF200
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(AutoPilotNavBtnView.EComponents.Button, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(AutoPilotNavBtnView.EComponents.ButtonText, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(AutoPilotNavBtnView.EComponents.RedDot, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(AutoPilotNavBtnView.EComponents.Icon, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(AutoPilotNavBtnView.EComponents.Tips, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(AutoPilotNavBtnView.EComponents.TipsText, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(AutoPilotNavBtnView.EComponents.Button, new Action(this.OnBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032AD3 RID: 207571 RVA: 0x00CB1146 File Offset: 0x00CAF346
		private void OnBtnClick()
		{
			Action onBtnClickCallback = this.OnBtnClickCallback;
			if (onBtnClickCallback != null)
			{
				onBtnClickCallback();
			}
			this.RefreshUi(true, true);
		}

		// Token: 0x06032AD4 RID: 207572 RVA: 0x00CB1164 File Offset: 0x00CAF364
		public void RefreshUi(bool isAutoPilotTracked, bool isInteractive = true)
		{
			UUIButtonComponent button = base.GetButton(AutoPilotNavBtnView.EComponents.Button);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!isAutoPilotTracked);
			}
			UUIButtonComponent button2 = base.GetButton(AutoPilotNavBtnView.EComponents.Button);
			if (button2 != null)
			{
				button2.SetSelfInteractive(isInteractive);
			}
			UUIItem item = base.GetItem(AutoPilotNavBtnView.EComponents.Tips);
			if (item != null)
			{
				item.SetUIActive(isAutoPilotTracked);
			}
			if (!isAutoPilotTracked)
			{
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(AutoPilotNavBtnView.EComponents.ButtonText), this.Context.IsNeedCustomMarkCreate() ? AutoPilotDefine.EAutoPilotTextId.TextMarkToGuide : AutoPilotDefine.EAutoPilotTextId.TextAutoPilotTrack, Array.Empty<object>());
			}
		}

		// Token: 0x06032AD5 RID: 207573 RVA: 0x00CB11FC File Offset: 0x00CAF3FC
		public bool GetIsInteractive()
		{
			if (this.RootItem == null)
			{
				return false;
			}
			if (!this.RootItem.IsUIActiveSelf())
			{
				return false;
			}
			UUIButtonComponent button = base.GetButton(AutoPilotNavBtnView.EComponents.Button);
			return button != null && button.GetSelfInteractive();
		}

		// Token: 0x0401D827 RID: 120871
		[Nullable(1)]
		private readonly WorldMapSecondaryUiAutoPilotContext Context;

		// Token: 0x0200ACC6 RID: 44230
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035AAB RID: 219819
			public static readonly int Button = 0;

			// Token: 0x04035AAC RID: 219820
			public static readonly int ButtonText = 1;

			// Token: 0x04035AAD RID: 219821
			public static readonly int RedDot = 2;

			// Token: 0x04035AAE RID: 219822
			public static readonly int Icon = 3;

			// Token: 0x04035AAF RID: 219823
			public static readonly int Tips = 4;

			// Token: 0x04035AB0 RID: 219824
			public static readonly int TipsText = 5;
		}
	}
}
