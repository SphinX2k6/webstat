using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F5 RID: 26101
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballMainButtonItem : UiPanelBase
	{
		// Token: 0x0604134A RID: 267082 RVA: 0x010B9E74 File Offset: 0x010B8074
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604134B RID: 267083 RVA: 0x010B9F3C File Offset: 0x010B813C
		[NullableContext(1)]
		public void SetConfigData(IPinballMainButtonConfig config)
		{
			if (config.FunctionId != null)
			{
				this.FunctionId = config.FunctionId.Value;
			}
			if (config.ShowRedDot != null)
			{
				this.ShowRedDotCallback = config.ShowRedDot;
			}
			if (config.SetTextCallback != null)
			{
				this.SetTextCallback = config.SetTextCallback;
			}
			if (config.OnClickCallback != null)
			{
				this.ClickCallBack = config.OnClickCallback;
			}
			if (config.ShowCallback != null)
			{
				this.ShowCallback = config.ShowCallback;
			}
			if (config.RedDotName != null)
			{
				this.RedDotName = config.RedDotName;
			}
		}

		// Token: 0x0604134C RID: 267084 RVA: 0x010B9FDC File Offset: 0x010B81DC
		public void SetButtonState()
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(this.FunctionId);
			bool flag2 = this.ShowCallback == null || this.ShowCallback();
			base.SetUiActive(flag && flag2);
		}

		// Token: 0x0604134D RID: 267085 RVA: 0x010BA01A File Offset: 0x010B821A
		public void SetProgressText()
		{
			if (this.SetTextCallback != null)
			{
				this.SetTextCallback(base.GetText(2));
				return;
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText("", true);
		}

		// Token: 0x0604134E RID: 267086 RVA: 0x010BA050 File Offset: 0x010B8250
		public void SetRedDot()
		{
			if (this.ShowRedDotCallback == null)
			{
				if (this.RedDotName == null)
				{
					UUIItem item = base.GetItem(1);
					if (item == null)
					{
						return;
					}
					item.SetUIActive(false);
				}
				return;
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(this.ShowRedDotCallback());
		}

		// Token: 0x0604134F RID: 267087 RVA: 0x010BA0A1 File Offset: 0x010B82A1
		public void BindRedDot()
		{
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, base.GetItem(1), null, 0);
			}
		}

		// Token: 0x06041350 RID: 267088 RVA: 0x010BA0CE File Offset: 0x010B82CE
		public void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(1), 0);
			}
		}

		// Token: 0x06041351 RID: 267089 RVA: 0x010BA0FA File Offset: 0x010B82FA
		public void Clear()
		{
			this.ClickCallBack = null;
			this.ShowRedDotCallback = null;
			this.SetTextCallback = null;
			this.ShowCallback = null;
			this.UnBindRedDot();
		}

		// Token: 0x06041352 RID: 267090 RVA: 0x010BA11E File Offset: 0x010B831E
		private void ButtonClick()
		{
			Action clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack();
		}

		// Token: 0x04024817 RID: 149527
		private int FunctionId;

		// Token: 0x04024818 RID: 149528
		private ERedDotName? RedDotName;

		// Token: 0x04024819 RID: 149529
		private Action ClickCallBack;

		// Token: 0x0402481A RID: 149530
		private Func<bool> ShowRedDotCallback;

		// Token: 0x0402481B RID: 149531
		private Action<UUIText> SetTextCallback;

		// Token: 0x0402481C RID: 149532
		private Func<bool> ShowCallback;

		// Token: 0x0200C5FA RID: 50682
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CF11 RID: 249617
			Button,
			// Token: 0x0403CF12 RID: 249618
			RedDotItem,
			// Token: 0x0403CF13 RID: 249619
			TxtProgress
		}
	}
}
