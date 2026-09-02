using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D7 RID: 18903
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewSetContainer : UiViewContainer
	{
		// Token: 0x0603174D RID: 202573 RVA: 0x00C4E2C4 File Offset: 0x00C4C4C4
		public UiViewSetContainer(Dictionary<EUiViewName, UiViewBase> map)
		{
			this.Map = map;
		}

		// Token: 0x0603174E RID: 202574 RVA: 0x00C4E2D4 File Offset: 0x00C4C4D4
		[NullableContext(0)]
		public override UniTask<bool> OpenViewAsync([Nullable(1)] UiViewBase view)
		{
			UiViewSetContainer.<OpenViewAsync>d__2 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.view = view;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<UiViewSetContainer.<OpenViewAsync>d__2>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603174F RID: 202575 RVA: 0x00C4E320 File Offset: 0x00C4C520
		public override UniTask CloseViewAsync(UiViewBase view)
		{
			UiViewSetContainer.<CloseViewAsync>d__3 <CloseViewAsync>d__;
			<CloseViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewAsync>d__.<>4__this = this;
			<CloseViewAsync>d__.view = view;
			<CloseViewAsync>d__.<>1__state = -1;
			<CloseViewAsync>d__.<>t__builder.Start<UiViewSetContainer.<CloseViewAsync>d__3>(ref <CloseViewAsync>d__);
			return <CloseViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031750 RID: 202576 RVA: 0x00C4E36C File Offset: 0x00C4C56C
		public override void ClearContainer(bool isSeamlessTravel)
		{
			List<EUiViewName> list = new List<EUiViewName>();
			foreach (KeyValuePair<EUiViewName, UiViewBase> keyValuePair in this.Map)
			{
				UiViewBase value = keyValuePair.Value;
				value.IsExistInLeaveLevel = true;
				if (!value.ViewInfo.IsPermanent)
				{
					base.TryCatchViewDestroyCompatible(value);
					list.Add(keyValuePair.Key);
				}
			}
			foreach (EUiViewName key in list)
			{
				this.Map.Remove(key);
			}
		}

		// Token: 0x06031751 RID: 202577 RVA: 0x00C4E434 File Offset: 0x00C4C634
		public override UniTask PreOpenViewAsync(UiViewBase view)
		{
			UiViewSetContainer.<PreOpenViewAsync>d__5 <PreOpenViewAsync>d__;
			<PreOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreOpenViewAsync>d__.view = view;
			<PreOpenViewAsync>d__.<>1__state = -1;
			<PreOpenViewAsync>d__.<>t__builder.Start<UiViewSetContainer.<PreOpenViewAsync>d__5>(ref <PreOpenViewAsync>d__);
			return <PreOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031752 RID: 202578 RVA: 0x00C4E478 File Offset: 0x00C4C678
		public override UniTask OpenViewAfterPreOpenedAsync(UiViewBase view)
		{
			UiViewSetContainer.<OpenViewAfterPreOpenedAsync>d__6 <OpenViewAfterPreOpenedAsync>d__;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewAfterPreOpenedAsync>d__.view = view;
			<OpenViewAfterPreOpenedAsync>d__.<>1__state = -1;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder.Start<UiViewSetContainer.<OpenViewAfterPreOpenedAsync>d__6>(ref <OpenViewAfterPreOpenedAsync>d__);
			return <OpenViewAfterPreOpenedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401C60F RID: 116239
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Dictionary<EUiViewName, UiViewBase> Map;
	}
}
