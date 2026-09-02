using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED4 RID: 24276
	public class CiacconaGalEndingDetailView : UiViewBase
	{
		// Token: 0x0603D00C RID: 249868 RVA: 0x00F7E7A3 File Offset: 0x00F7C9A3
		[NullableContext(1)]
		public CiacconaGalEndingDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D00D RID: 249869 RVA: 0x00F7E7AC File Offset: 0x00F7C9AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D00E RID: 249870 RVA: 0x00F7E878 File Offset: 0x00F7CA78
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalEndingDetailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalEndingDetailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D00F RID: 249871 RVA: 0x00F7E8BC File Offset: 0x00F7CABC
		protected override void OnStart()
		{
			ICiacconaEndingViewParam ciacconaEndingViewParam = this.OpenParam as ICiacconaEndingViewParam;
			this.EndingData = ciacconaEndingViewParam.EndingData;
			if (this.EndingData == null)
			{
				return;
			}
			base.SetTextureByPath(this.EndingData.DetailImagePath, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.EndingData.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.EndingData.Desc, Array.Empty<object>());
			base.GetText(3).SetUIActive(!string.IsNullOrEmpty(ciacconaEndingViewParam.LabelTextId));
			if (!string.IsNullOrEmpty(ciacconaEndingViewParam.LabelTextId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), ciacconaEndingViewParam.LabelTextId, Array.Empty<object>());
			}
		}

		// Token: 0x040223C5 RID: 140229
		[Nullable(2)]
		private PopupCaptionItem ItemCaption;

		// Token: 0x040223C6 RID: 140230
		[Nullable(2)]
		private CiacconaGalEndingData EndingData;

		// Token: 0x0200BED0 RID: 48848
		private class EComponentDefine
		{
			// Token: 0x0403ABA6 RID: 240550
			public const int ItemCaption = 0;

			// Token: 0x0403ABA7 RID: 240551
			public const int TextureBg = 1;

			// Token: 0x0403ABA8 RID: 240552
			public const int TextTitle = 2;

			// Token: 0x0403ABA9 RID: 240553
			public const int TextLabel = 3;

			// Token: 0x0403ABAA RID: 240554
			public const int TextInfo = 4;
		}
	}
}
