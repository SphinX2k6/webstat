using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D5 RID: 18901
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewListContainer : UiViewContainer
	{
		// Token: 0x06031734 RID: 202548 RVA: 0x00C4D956 File Offset: 0x00C4BB56
		public UiViewListContainer(List<UiViewBase> viewBaseList)
		{
			this.ViewBaseList = viewBaseList;
		}

		// Token: 0x06031735 RID: 202549 RVA: 0x00C4D970 File Offset: 0x00C4BB70
		[NullableContext(0)]
		public override UniTask<bool> OpenViewAsync([Nullable(1)] UiViewBase view)
		{
			UiViewListContainer.<OpenViewAsync>d__3 <OpenViewAsync>d__;
			<OpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenViewAsync>d__.<>4__this = this;
			<OpenViewAsync>d__.view = view;
			<OpenViewAsync>d__.<>1__state = -1;
			<OpenViewAsync>d__.<>t__builder.Start<UiViewListContainer.<OpenViewAsync>d__3>(ref <OpenViewAsync>d__);
			return <OpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031736 RID: 202550 RVA: 0x00C4D9BC File Offset: 0x00C4BBBC
		public override UniTask CloseViewAsync(UiViewBase view)
		{
			UiViewListContainer.<CloseViewAsync>d__4 <CloseViewAsync>d__;
			<CloseViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewAsync>d__.<>4__this = this;
			<CloseViewAsync>d__.view = view;
			<CloseViewAsync>d__.<>1__state = -1;
			<CloseViewAsync>d__.<>t__builder.Start<UiViewListContainer.<CloseViewAsync>d__4>(ref <CloseViewAsync>d__);
			return <CloseViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031737 RID: 202551 RVA: 0x00C4DA08 File Offset: 0x00C4BC08
		public override void ClearContainer(bool isSeamlessTravel)
		{
			List<UiViewBase> list = new List<UiViewBase>();
			for (int i = this.ViewBaseList.Count - 1; i >= 0; i--)
			{
				UiViewBase uiViewBase = this.ViewBaseList[i];
				uiViewBase.IsExistInLeaveLevel = true;
				if (!uiViewBase.ViewInfo.IsPermanent)
				{
					if (!uiViewBase.IsDestroyOrDestroying)
					{
						base.TryCatchViewDestroyCompatible(uiViewBase);
					}
					list.Add(uiViewBase);
				}
			}
			foreach (UiViewBase item in list)
			{
				int index = this.ViewBaseList.IndexOf(item);
				this.ViewBaseList.RemoveAt(index);
			}
		}

		// Token: 0x06031738 RID: 202552 RVA: 0x00C4DAC4 File Offset: 0x00C4BCC4
		public void CloseAllView()
		{
			for (int i = this.ViewBaseList.Count - 1; i >= 0; i--)
			{
				this.ViewBaseList[i].Destroy(null);
				this.ViewBaseList.RemoveAt(i);
			}
		}

		// Token: 0x06031739 RID: 202553 RVA: 0x00C4DB08 File Offset: 0x00C4BD08
		public override UniTask PreOpenViewAsync(UiViewBase view)
		{
			UiViewListContainer.<PreOpenViewAsync>d__7 <PreOpenViewAsync>d__;
			<PreOpenViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreOpenViewAsync>d__.view = view;
			<PreOpenViewAsync>d__.<>1__state = -1;
			<PreOpenViewAsync>d__.<>t__builder.Start<UiViewListContainer.<PreOpenViewAsync>d__7>(ref <PreOpenViewAsync>d__);
			return <PreOpenViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603173A RID: 202554 RVA: 0x00C4DB4C File Offset: 0x00C4BD4C
		public override UniTask OpenViewAfterPreOpenedAsync(UiViewBase view)
		{
			UiViewListContainer.<OpenViewAfterPreOpenedAsync>d__8 <OpenViewAfterPreOpenedAsync>d__;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenViewAfterPreOpenedAsync>d__.view = view;
			<OpenViewAfterPreOpenedAsync>d__.<>1__state = -1;
			<OpenViewAfterPreOpenedAsync>d__.<>t__builder.Start<UiViewListContainer.<OpenViewAfterPreOpenedAsync>d__8>(ref <OpenViewAfterPreOpenedAsync>d__);
			return <OpenViewAfterPreOpenedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603173B RID: 202555 RVA: 0x00C4DB90 File Offset: 0x00C4BD90
		public UniTask HideView()
		{
			UiViewListContainer.<HideView>d__9 <HideView>d__;
			<HideView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HideView>d__.<>4__this = this;
			<HideView>d__.<>1__state = -1;
			<HideView>d__.<>t__builder.Start<UiViewListContainer.<HideView>d__9>(ref <HideView>d__);
			return <HideView>d__.<>t__builder.Task;
		}

		// Token: 0x0603173C RID: 202556 RVA: 0x00C4DBD4 File Offset: 0x00C4BDD4
		public void ShowView()
		{
			foreach (UiViewBase uiViewBase in this.HideViewList)
			{
				if (!uiViewBase.IsDestroyOrDestroying)
				{
					uiViewBase.SetActive(true);
				}
			}
			this.HideViewList.Clear();
		}

		// Token: 0x0401C609 RID: 116233
		private readonly List<UiViewBase> ViewBaseList;

		// Token: 0x0401C60A RID: 116234
		private readonly List<UiViewBase> HideViewList = new List<UiViewBase>();
	}
}
