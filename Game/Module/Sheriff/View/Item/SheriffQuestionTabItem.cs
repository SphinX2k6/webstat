using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FEA RID: 20458
	public class SheriffQuestionTabItem : GridProxyAbstract<int>
	{
		// Token: 0x06034BE0 RID: 216032 RVA: 0x00D3B83C File Offset: 0x00D39A3C
		[NullableContext(1)]
		public SheriffQuestionTabItem(SheriffMainProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06034BE1 RID: 216033 RVA: 0x00D3B84C File Offset: 0x00D39A4C
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
		}

		// Token: 0x06034BE2 RID: 216034 RVA: 0x00D3B8F7 File Offset: 0x00D39AF7
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x06034BE3 RID: 216035 RVA: 0x00D3B916 File Offset: 0x00D39B16
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x06034BE4 RID: 216036 RVA: 0x00D3B93C File Offset: 0x00D39B3C
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			int curQuestionIndex = this.Proxy.GetCurQuestionIndex();
			base.GetItem(2).SetUIActive(gridIndex < curQuestionIndex);
			base.GetItem(3).SetUIActive(gridIndex > curQuestionIndex);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Inference_Desc_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(2 + gridIndex);
			instance.SetLocalTextNew(text, defaultInterpolatedStringHandler.ToStringAndClear(), Array.Empty<object>());
			if (this.CheckSelectCallback != null)
			{
				this.SetSelected(this.CheckSelectCallback(gridIndex), false);
			}
		}

		// Token: 0x06034BE5 RID: 216037 RVA: 0x00D3B9CD File Offset: 0x00D39BCD
		public void SetSelected(bool isSelected, bool fireEvent = false)
		{
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06034BE6 RID: 216038 RVA: 0x00D3B9E6 File Offset: 0x00D39BE6
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<int> onToggleStateChangedCallback = this.OnToggleStateChangedCallback;
			if (onToggleStateChangedCallback == null)
			{
				return;
			}
			onToggleStateChangedCallback(base.GridIndex);
		}

		// Token: 0x0401E63F RID: 124479
		protected int CurId;

		// Token: 0x0401E640 RID: 124480
		[Nullable(1)]
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E641 RID: 124481
		[Nullable(2)]
		public Action<int> OnToggleStateChangedCallback;

		// Token: 0x0401E642 RID: 124482
		[Nullable(2)]
		public Func<int, bool> CheckSelectCallback;

		// Token: 0x0200AFC5 RID: 44997
		private static class EQuestionTab
		{
			// Token: 0x040368A7 RID: 223399
			public const int TogClueTab = 0;

			// Token: 0x040368A8 RID: 223400
			public const int TxtName = 1;

			// Token: 0x040368A9 RID: 223401
			public const int PanelDone = 2;

			// Token: 0x040368AA RID: 223402
			public const int PanelLock = 3;
		}
	}
}
