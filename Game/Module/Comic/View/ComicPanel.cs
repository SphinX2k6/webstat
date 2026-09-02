using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Comic.View
{
	// Token: 0x02005E8C RID: 24204
	[NullableContext(2)]
	[Nullable(0)]
	public class ComicPanel : UiPanelBase
	{
		// Token: 0x0603CDC8 RID: 249288 RVA: 0x00F726B4 File Offset: 0x00F708B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnNextPageButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnSkipButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CDC9 RID: 249289 RVA: 0x00F727C0 File Offset: 0x00F709C0
		protected override UniTask OnBeforeStartAsync()
		{
			ComicPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComicPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CDCA RID: 249290 RVA: 0x00F72804 File Offset: 0x00F70A04
		public void NextPage()
		{
			if (this.CurPageIndex + 1 >= this.ItemList.Count)
			{
				return;
			}
			this.ItemList[this.CurPageIndex].SetUIActive(false);
			this.CurPageIndex++;
			this.ItemList[this.CurPageIndex].SetUIActive(true);
		}

		// Token: 0x0603CDCB RID: 249291 RVA: 0x00F72863 File Offset: 0x00F70A63
		public void Skip()
		{
			Action onSkip = this.OnSkip;
			if (onSkip == null)
			{
				return;
			}
			onSkip();
		}

		// Token: 0x0603CDCC RID: 249292 RVA: 0x00F72875 File Offset: 0x00F70A75
		public void Complete()
		{
			Action onComplete = this.OnComplete;
			if (onComplete == null)
			{
				return;
			}
			onComplete();
		}

		// Token: 0x0603CDCD RID: 249293 RVA: 0x00F72887 File Offset: 0x00F70A87
		private void OnNextPageButtonClick()
		{
			if (this.CurPageIndex + 1 >= this.ItemList.Count)
			{
				this.Complete();
				return;
			}
			Action nextPageDelegate = this.NextPageDelegate;
			if (nextPageDelegate == null)
			{
				return;
			}
			nextPageDelegate();
		}

		// Token: 0x0603CDCE RID: 249294 RVA: 0x00F728B5 File Offset: 0x00F70AB5
		private void OnSkipButtonClick()
		{
			this.Skip();
		}

		// Token: 0x040222A6 RID: 139942
		private int ComicConfigId;

		// Token: 0x040222A7 RID: 139943
		private int CurPageIndex;

		// Token: 0x040222A8 RID: 139944
		[Nullable(1)]
		private readonly List<UUIItem> ItemList = new List<UUIItem>();

		// Token: 0x040222A9 RID: 139945
		private Action OnSkip;

		// Token: 0x040222AA RID: 139946
		private Action OnComplete;

		// Token: 0x040222AB RID: 139947
		public Action NextPageDelegate;

		// Token: 0x0200BE90 RID: 48784
		[NullableContext(0)]
		private static class EComDefine
		{
			// Token: 0x0403AAB1 RID: 240305
			public const int ContentRootItem = 0;

			// Token: 0x0403AAB2 RID: 240306
			public const int NextPageButton = 1;

			// Token: 0x0403AAB3 RID: 240307
			public const int SkipButton = 2;

			// Token: 0x0403AAB4 RID: 240308
			public const int NextPageItem = 3;
		}
	}
}
