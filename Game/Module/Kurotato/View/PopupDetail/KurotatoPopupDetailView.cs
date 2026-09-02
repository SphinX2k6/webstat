using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.View.Overview;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.PopupDetail
{
	// Token: 0x02005A90 RID: 23184
	public class KurotatoPopupDetailView : UiViewBase
	{
		// Token: 0x0603AA92 RID: 240274 RVA: 0x00EDD15B File Offset: 0x00EDB35B
		[NullableContext(1)]
		public KurotatoPopupDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AA93 RID: 240275 RVA: 0x00EDD170 File Offset: 0x00EDB370
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AA94 RID: 240276 RVA: 0x00EDD218 File Offset: 0x00EDB418
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoPopupDetailView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoPopupDetailView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA95 RID: 240277 RVA: 0x00EDD25B File Offset: 0x00EDB45B
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x040212CD RID: 135885
		[Nullable(1)]
		private readonly KurotatoAttributePanel AttributePanel = new KurotatoAttributePanel();

		// Token: 0x0200BA7B RID: 47739
		private enum EComponents
		{
			// Token: 0x04039936 RID: 235830
			ItemAttrView,
			// Token: 0x04039937 RID: 235831
			BtnClose
		}
	}
}
