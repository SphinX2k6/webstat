using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005546 RID: 21830
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardCheckComponent : CardComponentBase<ICardCheckComponentData>
	{
		// Token: 0x06037A65 RID: 227941 RVA: 0x00E1E14C File Offset: 0x00E1C34C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnCheckBtnClick))
			};
		}

		// Token: 0x06037A66 RID: 227942 RVA: 0x00E1E1B3 File Offset: 0x00E1C3B3
		public override void Refresh(ICardCheckComponentData data)
		{
			this.Data = data;
			this.RefreshLeftCount();
			this.OnCheckBtnClickInternal = data.OnCheckBtnClick;
		}

		// Token: 0x06037A67 RID: 227943 RVA: 0x00E1E1D0 File Offset: 0x00E1C3D0
		public void RefreshLeftCount()
		{
			UUIText text = base.GetText(0);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.LeftCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.MaxCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06037A68 RID: 227944 RVA: 0x00E1E22A File Offset: 0x00E1C42A
		protected void OnCheckBtnClick()
		{
			Action onCheckBtnClickInternal = this.OnCheckBtnClickInternal;
			if (onCheckBtnClickInternal == null)
			{
				return;
			}
			onCheckBtnClickInternal();
		}

		// Token: 0x06037A69 RID: 227945 RVA: 0x00E1E23C File Offset: 0x00E1C43C
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			UUIButtonComponent button = base.GetButton(1);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			UUIItem[] array = new UUIItem[2];
			int num = 0;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr2 = tweakObjectPtr;
			array[num] = ((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null);
			int num2 = 1;
			tweakObjectPtr2 = tweakObjectPtr;
			array[num2] = ((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null);
			return array;
		}

		// Token: 0x0401FE58 RID: 130648
		protected ICardCheckComponentData Data;

		// Token: 0x0401FE59 RID: 130649
		private Action OnCheckBtnClickInternal;

		// Token: 0x0200B4D4 RID: 46292
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037FA1 RID: 229281
			public const int CountText = 0;

			// Token: 0x04037FA2 RID: 229282
			public const int CheckBtn = 1;
		}
	}
}
