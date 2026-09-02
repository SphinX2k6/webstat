using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D1A RID: 23834
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FunctionAttachItemGrid : AutoAttachItem<int[]>
	{
		// Token: 0x0603C1A0 RID: 246176 RVA: 0x00F3DA3D File Offset: 0x00F3BC3D
		public FunctionAttachItemGrid(AActor uiItem = null) : base(uiItem)
		{
		}

		// Token: 0x0603C1A1 RID: 246177 RVA: 0x00F3DA48 File Offset: 0x00F3BC48
		protected override void OnRefreshItem(int[] data)
		{
			if (data == null)
			{
				return;
			}
			GenericLayoutNew<FunctionItem> layout = this.Layout;
			if (layout != null)
			{
				layout.SetNeedAnim(this.NeedAnim);
			}
			GenericLayoutNew<FunctionItem> layout2 = this.Layout;
			if (layout2 != null)
			{
				layout2.RebuildLayoutByDataNew<int>(data, null);
			}
			this.NeedAnim = false;
		}

		// Token: 0x0603C1A2 RID: 246178 RVA: 0x00F3DA92 File Offset: 0x00F3BC92
		public override void OnSelect()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.FunctionGridSelected, base.GetCurrentShowItemIndex());
		}

		// Token: 0x0603C1A3 RID: 246179 RVA: 0x00F3DAAA File Offset: 0x00F3BCAA
		protected override void OnUnSelect()
		{
		}

		// Token: 0x0603C1A4 RID: 246180 RVA: 0x00F3DAAC File Offset: 0x00F3BCAC
		protected override void OnMoveItem()
		{
		}

		// Token: 0x0603C1A5 RID: 246181 RVA: 0x00F3DAB0 File Offset: 0x00F3BCB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C1A6 RID: 246182 RVA: 0x00F3DB19 File Offset: 0x00F3BD19
		protected override void OnStart()
		{
			this.Layout = new GenericLayoutNew<FunctionItem>(base.GetLayoutBase(0), (object functionId, UUIItem uiItem, int index) => this.InitSubItem((int?)functionId, uiItem, index), base.GetItem(1));
		}

		// Token: 0x0603C1A7 RID: 246183 RVA: 0x00F3DB40 File Offset: 0x00F3BD40
		[NullableContext(1)]
		private ILayoutItem<FunctionItem> InitSubItem(int? functionId, UUIItem uiItem, int index)
		{
			FunctionItem functionItem = new FunctionItem(uiItem);
			functionItem.UpdateItem(functionId.Value);
			return new LayoutItem<FunctionItem>
			{
				Key = functionId,
				Value = functionItem
			};
		}

		// Token: 0x0603C1A8 RID: 246184 RVA: 0x00F3DB79 File Offset: 0x00F3BD79
		public void SetNeedAnim(bool value)
		{
			this.NeedAnim = value;
		}

		// Token: 0x0603C1A9 RID: 246185 RVA: 0x00F3DB84 File Offset: 0x00F3BD84
		protected override void OnBeforeDestroy()
		{
			this.Layout.ClearGridController();
			foreach (FunctionItem child in this.Layout.GetLayoutItemList())
			{
				base.AddChild(child);
			}
		}

		// Token: 0x0603C1AA RID: 246186 RVA: 0x00F3DBE8 File Offset: 0x00F3BDE8
		public FunctionItem GetFunctionItem(int functionId)
		{
			return this.Layout.GetLayoutItemByKey(functionId);
		}

		// Token: 0x04021BE6 RID: 138214
		[Nullable(1)]
		protected GenericLayoutNew<FunctionItem> Layout;

		// Token: 0x04021BE7 RID: 138215
		private bool NeedAnim;

		// Token: 0x0200BD8B RID: 48523
		[NullableContext(0)]
		private class ECompDefine
		{
			// Token: 0x0403A60B RID: 239115
			public const int LayoutItem = 0;

			// Token: 0x0403A60C RID: 239116
			public const int GridItem = 1;
		}
	}
}
