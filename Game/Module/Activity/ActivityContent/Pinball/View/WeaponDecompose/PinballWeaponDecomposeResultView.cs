using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.WeaponDecompose
{
	// Token: 0x020065AD RID: 26029
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponDecomposeResultView : UiViewBase
	{
		// Token: 0x0604107D RID: 266365 RVA: 0x010AF8F6 File Offset: 0x010ADAF6
		public PinballWeaponDecomposeResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604107F RID: 266367 RVA: 0x010AF954 File Offset: 0x010ADB54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCloseClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041080 RID: 266368 RVA: 0x010AFA3C File Offset: 0x010ADC3C
		protected override UniTask OnBeforeStartAsync()
		{
			PinballWeaponDecomposeResultView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballWeaponDecomposeResultView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041081 RID: 266369 RVA: 0x010AFA7F File Offset: 0x010ADC7F
		protected override void OnBeforeShow()
		{
			this.RefreshItemsAsync().Forget();
		}

		// Token: 0x06041082 RID: 266370 RVA: 0x010AFA8C File Offset: 0x010ADC8C
		private UniTask RefreshItemsAsync()
		{
			PinballWeaponDecomposeResultView.<RefreshItemsAsync>d__10 <RefreshItemsAsync>d__;
			<RefreshItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshItemsAsync>d__.<>4__this = this;
			<RefreshItemsAsync>d__.<>1__state = -1;
			<RefreshItemsAsync>d__.<>t__builder.Start<PinballWeaponDecomposeResultView.<RefreshItemsAsync>d__10>(ref <RefreshItemsAsync>d__);
			return <RefreshItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041083 RID: 266371 RVA: 0x010AFACF File Offset: 0x010ADCCF
		private void OnBtnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06041084 RID: 266372 RVA: 0x010AFAD8 File Offset: 0x010ADCD8
		private void OnResultItemExtendToggleClicked(IPinballItemToggleCallback callbackParameter)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(89500002, true, null);
		}

		// Token: 0x06041085 RID: 266373 RVA: 0x010AFAEB File Offset: 0x010ADCEB
		private bool OnResultItemCanExecuteChange(IPinballItemToggleCallback callbackParameter)
		{
			return false;
		}

		// Token: 0x0402474B RID: 149323
		public new TItem OpenParam;

		// Token: 0x0402474C RID: 149324
		private PinballItemView ResultItemView;

		// Token: 0x0402474D RID: 149325
		private PinballItemView ReflectionResultItemView;

		// Token: 0x0402474E RID: 149326
		private static readonly Dictionary<InventoryDefine.EQuality, string> QualityColorMap = new Dictionary<InventoryDefine.EQuality, string>
		{
			{
				InventoryDefine.EQuality.White,
				"56D29BFF"
			},
			{
				InventoryDefine.EQuality.Green,
				"53D0FEFF"
			},
			{
				InventoryDefine.EQuality.Blue,
				"A651FEFF"
			},
			{
				InventoryDefine.EQuality.Purple,
				"E48C26FF"
			},
			{
				InventoryDefine.EQuality.Orange,
				"DD0D33FF"
			}
		};

		// Token: 0x0200C5A5 RID: 50597
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CD4D RID: 249165
			BtnClose,
			// Token: 0x0403CD4E RID: 249166
			Item,
			// Token: 0x0403CD4F RID: 249167
			ItemReflection,
			// Token: 0x0403CD50 RID: 249168
			TexLight
		}
	}
}
