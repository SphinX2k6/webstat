using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BCC RID: 19404
	[NullableContext(2)]
	[Nullable(0)]
	public class PopupCaption : UiPanelBase
	{
		// Token: 0x170086F6 RID: 34550
		// (get) Token: 0x06032A4D RID: 207437 RVA: 0x00CAFB4A File Offset: 0x00CADD4A
		// (set) Token: 0x06032A4E RID: 207438 RVA: 0x00CAFB52 File Offset: 0x00CADD52
		public Action OnCloseCall { get; set; }

		// Token: 0x06032A4F RID: 207439 RVA: 0x00CAFB5C File Offset: 0x00CADD5C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032A50 RID: 207440 RVA: 0x00CAFC86 File Offset: 0x00CADE86
		private void OnClickCloseBtn()
		{
			Action onCloseCall = this.OnCloseCall;
			if (onCloseCall == null)
			{
				return;
			}
			onCloseCall();
		}

		// Token: 0x06032A51 RID: 207441 RVA: 0x00CAFC98 File Offset: 0x00CADE98
		[NullableContext(1)]
		public void SetTitleIcon(string resourceId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x06032A52 RID: 207442 RVA: 0x00CAFCCA File Offset: 0x00CADECA
		[NullableContext(1)]
		public void SetTitleLocalTxt(string txtId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), txtId, Array.Empty<object>());
		}

		// Token: 0x0200ACB5 RID: 44213
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A6C RID: 219756
			public const int SprTitleIcon = 0;

			// Token: 0x04035A6D RID: 219757
			public const int TxtTitle = 1;

			// Token: 0x04035A6E RID: 219758
			public const int BtnHelpInfo = 2;

			// Token: 0x04035A6F RID: 219759
			public const int BtnBack = 3;

			// Token: 0x04035A70 RID: 219760
			public const int PnlCost = 4;

			// Token: 0x04035A71 RID: 219761
			public const int PnlTabInfo = 5;
		}
	}
}
