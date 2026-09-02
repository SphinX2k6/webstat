using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C9 RID: 18889
	public class PopupCaptionStateItem : UiPanelBase
	{
		// Token: 0x060316BF RID: 202431 RVA: 0x00C4BCE8 File Offset: 0x00C49EE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060316C0 RID: 202432 RVA: 0x00C4BDAF File Offset: 0x00C49FAF
		protected override void OnStart()
		{
			this.OldColor = base.GetSprite(1).GetColor();
			this.ChangeColor = FColor.FromHex("FFCC7B");
		}

		// Token: 0x060316C1 RID: 202433 RVA: 0x00C4BDD3 File Offset: 0x00C49FD3
		private void OnClickBtn()
		{
			Action onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack();
		}

		// Token: 0x060316C2 RID: 202434 RVA: 0x00C4BDE5 File Offset: 0x00C49FE5
		[NullableContext(1)]
		public void BindClick(Action callback)
		{
			this.OnClickCallBack = callback;
		}

		// Token: 0x060316C3 RID: 202435 RVA: 0x00C4BDEE File Offset: 0x00C49FEE
		[NullableContext(1)]
		public void SetTipsLocalText(string localKey)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), localKey, Array.Empty<object>());
		}

		// Token: 0x060316C4 RID: 202436 RVA: 0x00C4BE08 File Offset: 0x00C4A008
		public void SetCaptionChangeColor(bool useChangeColor)
		{
			FColor color = useChangeColor ? this.ChangeColor : this.OldColor;
			base.GetSprite(1).SetColor(color);
			base.GetText(2).SetColor(color);
		}

		// Token: 0x0401C5FF RID: 116223
		private FColor OldColor;

		// Token: 0x0401C600 RID: 116224
		private FColor ChangeColor;

		// Token: 0x0401C601 RID: 116225
		[Nullable(2)]
		protected Action OnClickCallBack;

		// Token: 0x0200AA53 RID: 43603
		private class EComponents
		{
			// Token: 0x04034B33 RID: 215859
			public const int BtnFunctionA = 0;

			// Token: 0x04034B34 RID: 215860
			public const int SprIcon = 1;

			// Token: 0x04034B35 RID: 215861
			public const int TxtBtnTips = 2;
		}
	}
}
