using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Comic.View
{
	// Token: 0x02005E8D RID: 24205
	public class ComicView : UiViewBase, IUiViewResource
	{
		// Token: 0x0603CDD0 RID: 249296 RVA: 0x00F728D0 File Offset: 0x00F70AD0
		[NullableContext(1)]
		public ComicView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CDD1 RID: 249297 RVA: 0x00F728DC File Offset: 0x00F70ADC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CDD2 RID: 249298 RVA: 0x00F72924 File Offset: 0x00F70B24
		[NullableContext(1)]
		public string GetExtraResourceId([Nullable(2)] object param)
		{
			int comicId = ((IComicViewOpenParam)param).ComicId;
			ComicDisplayConfig? comicDisplayConfig = ConfigBase<ComicConfig>.Instance.GetComicDisplayConfig(comicId);
			return ((comicDisplayConfig != null) ? comicDisplayConfig.GetValueOrDefault().ResourceId : null) ?? string.Empty;
		}

		// Token: 0x0603CDD3 RID: 249299 RVA: 0x00F72970 File Offset: 0x00F70B70
		protected override UniTask OnBeforeStartAsync()
		{
			ComicView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComicView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CDD4 RID: 249300 RVA: 0x00F729B3 File Offset: 0x00F70BB3
		private void NextPage()
		{
			if (this.SwitchPromise != null)
			{
				return;
			}
			this.NextPageAsync();
		}

		// Token: 0x0603CDD5 RID: 249301 RVA: 0x00F729C8 File Offset: 0x00F70BC8
		public UniTask NextPageAsync()
		{
			ComicView.<NextPageAsync>d__8 <NextPageAsync>d__;
			<NextPageAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NextPageAsync>d__.<>4__this = this;
			<NextPageAsync>d__.<>1__state = -1;
			<NextPageAsync>d__.<>t__builder.Start<ComicView.<NextPageAsync>d__8>(ref <NextPageAsync>d__);
			return <NextPageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CDD6 RID: 249302 RVA: 0x00F72A0B File Offset: 0x00F70C0B
		private void OnComicPanelSkip()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603CDD7 RID: 249303 RVA: 0x00F72A14 File Offset: 0x00F70C14
		private void OnComicPanelComplete()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603CDD8 RID: 249304 RVA: 0x00F72A1D File Offset: 0x00F70C1D
		[NullableContext(1)]
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Comic_Switch")
			{
				UniTaskCompletionSource switchPromise = this.SwitchPromise;
				if (switchPromise == null)
				{
					return;
				}
				switchPromise.TrySetResult();
			}
		}

		// Token: 0x0603CDD9 RID: 249305 RVA: 0x00F72A40 File Offset: 0x00F70C40
		protected override UniTask OnBeforeHideAsync()
		{
			ComicView.<OnBeforeHideAsync>d__12 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<ComicView.<OnBeforeHideAsync>d__12>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x040222AC RID: 139948
		[Nullable(2)]
		private ComicPanel ComicPanel;

		// Token: 0x040222AD RID: 139949
		[Nullable(2)]
		private UniTaskCompletionSource SwitchPromise;

		// Token: 0x0200BE92 RID: 48786
		private static class EComDefine
		{
			// Token: 0x0403AAB9 RID: 240313
			public const int ComicPanel = 0;
		}
	}
}
