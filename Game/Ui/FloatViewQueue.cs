using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D2 RID: 18898
	[NullableContext(1)]
	[Nullable(0)]
	public class FloatViewQueue
	{
		// Token: 0x06031707 RID: 202503 RVA: 0x00C4C75C File Offset: 0x00C4A95C
		public void Push(UiViewBase view, int priority, bool onlyShowInMain)
		{
			this.WaitViewList.Add(new FloatViewQueue.UiViewBaseWrapper
			{
				ViewBase = view,
				Priority = priority,
				OnlyShowInMain = onlyShowInMain
			});
			this.WaitViewList = (from v in this.WaitViewList
			orderby v.Priority descending
			select v).ToList<IUiViewBase>();
		}

		// Token: 0x06031708 RID: 202504 RVA: 0x00C4C7C4 File Offset: 0x00C4A9C4
		public IUiViewBase Pop(bool inMainView)
		{
			for (int i = 0; i < this.WaitViewList.Count; i++)
			{
				IUiViewBase uiViewBase = this.WaitViewList[i];
				if (!uiViewBase.OnlyShowInMain || inMainView)
				{
					this.DeleteView(uiViewBase);
					return uiViewBase;
				}
			}
			return null;
		}

		// Token: 0x06031709 RID: 202505 RVA: 0x00C4C80C File Offset: 0x00C4AA0C
		private bool DeleteView(IUiViewBase view)
		{
			int num = this.WaitViewList.IndexOf(view);
			if (num < 0)
			{
				return false;
			}
			this.WaitViewList.RemoveAt(num);
			return true;
		}

		// Token: 0x0603170A RID: 202506 RVA: 0x00C4C83C File Offset: 0x00C4AA3C
		public bool Delete(EUiViewName name, int? viewId = null)
		{
			for (int i = 0; i < this.WaitViewList.Count; i++)
			{
				IUiViewBase uiViewBase = this.WaitViewList[i];
				if (!(uiViewBase.ViewBase.ViewInfo.Name != name) && (viewId == null || uiViewBase.ViewBase.GetViewId() == viewId.Value))
				{
					this.DeleteView(uiViewBase);
					Singleton<UiManager>.Instance.RemoveView(uiViewBase.ViewBase.GetViewId());
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603170B RID: 202507 RVA: 0x00C4C8C4 File Offset: 0x00C4AAC4
		public bool Has(EUiViewName name)
		{
			for (int i = 0; i < this.WaitViewList.Count; i++)
			{
				if (this.WaitViewList[i].ViewBase.ViewInfo.Name == name)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603170C RID: 202508 RVA: 0x00C4C910 File Offset: 0x00C4AB10
		public void Clear()
		{
			for (int i = this.WaitViewList.Count - 1; i >= 0; i--)
			{
				UiViewBase viewBase = this.WaitViewList[i].ViewBase;
				if (!viewBase.ViewInfo.IsPermanent)
				{
					this.WaitViewList.RemoveAt(i);
					Singleton<UiManager>.Instance.RemoveView(viewBase.GetViewId());
				}
			}
		}

		// Token: 0x17008423 RID: 33827
		// (get) Token: 0x0603170D RID: 202509 RVA: 0x00C4C970 File Offset: 0x00C4AB70
		public int Size
		{
			get
			{
				return this.WaitViewList.Count;
			}
		}

		// Token: 0x0401C604 RID: 116228
		private List<IUiViewBase> WaitViewList = new List<IUiViewBase>();

		// Token: 0x0200AA5A RID: 43610
		[Nullable(0)]
		private class UiViewBaseWrapper : IUiViewBase
		{
			// Token: 0x1700A93F RID: 43327
			// (get) Token: 0x0604B363 RID: 308067 RVA: 0x0147C10E File Offset: 0x0147A30E
			// (set) Token: 0x0604B364 RID: 308068 RVA: 0x0147C116 File Offset: 0x0147A316
			public UiViewBase ViewBase { get; set; }

			// Token: 0x1700A940 RID: 43328
			// (get) Token: 0x0604B365 RID: 308069 RVA: 0x0147C11F File Offset: 0x0147A31F
			// (set) Token: 0x0604B366 RID: 308070 RVA: 0x0147C127 File Offset: 0x0147A327
			public int Priority { get; set; }

			// Token: 0x1700A941 RID: 43329
			// (get) Token: 0x0604B367 RID: 308071 RVA: 0x0147C130 File Offset: 0x0147A330
			// (set) Token: 0x0604B368 RID: 308072 RVA: 0x0147C138 File Offset: 0x0147A338
			public bool OnlyShowInMain { get; set; }
		}
	}
}
