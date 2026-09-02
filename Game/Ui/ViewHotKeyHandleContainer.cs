using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A2F RID: 18991
	[NullableContext(1)]
	[Nullable(0)]
	public class ViewHotKeyHandleContainer
	{
		// Token: 0x06031A0E RID: 203278 RVA: 0x00C5D640 File Offset: 0x00C5B840
		public void Add(ViewHotKeyHandle viewHotKeyHandle)
		{
			EUiViewName? viewName = viewHotKeyHandle.ViewName;
			if (viewName == null)
			{
				return;
			}
			EUiViewName value = viewName.Value;
			List<ViewHotKeyHandle> list;
			if (this.ViewNameViewHotKeyHandleMapping.TryGetValue(value, out list))
			{
				list.Add(viewHotKeyHandle);
			}
			else
			{
				this.ViewNameViewHotKeyHandleMapping[value] = new List<ViewHotKeyHandle>
				{
					viewHotKeyHandle
				};
			}
			Action callback;
			if (this.ViewNameOpenFuncMapping.TryGetValue(value, out callback))
			{
				viewHotKeyHandle.BindOpenViewCallback(callback);
			}
			Action callback2;
			if (this.ViewNameCloseFuncMapping.TryGetValue(value, out callback2))
			{
				viewHotKeyHandle.BindCloseViewCallback(callback2);
			}
		}

		// Token: 0x06031A0F RID: 203279 RVA: 0x00C5D6C8 File Offset: 0x00C5B8C8
		public void Remove(ViewHotKeyHandle viewHotKeyHandle)
		{
			EUiViewName? viewName = viewHotKeyHandle.ViewName;
			if (viewName == null)
			{
				return;
			}
			EUiViewName value = viewName.Value;
			List<ViewHotKeyHandle> list;
			if (!this.ViewNameViewHotKeyHandleMapping.TryGetValue(value, out list))
			{
				return;
			}
			int num = list.IndexOf(viewHotKeyHandle);
			if (num < 0)
			{
				return;
			}
			viewHotKeyHandle.Destroy();
			list.RemoveAt(num);
			if (list.Count == 0)
			{
				this.ViewNameViewHotKeyHandleMapping.Remove(value);
			}
		}

		// Token: 0x06031A10 RID: 203280 RVA: 0x00C5D730 File Offset: 0x00C5B930
		public void Clear()
		{
			foreach (List<ViewHotKeyHandle> list in this.ViewNameViewHotKeyHandleMapping.Values)
			{
				foreach (ViewHotKeyHandle viewHotKeyHandle in list)
				{
					viewHotKeyHandle.Destroy();
				}
			}
			this.ViewNameViewHotKeyHandleMapping.Clear();
		}

		// Token: 0x06031A11 RID: 203281 RVA: 0x00C5D7C4 File Offset: 0x00C5B9C4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public ViewHotKeyHandle[] Get(EUiViewName viewName)
		{
			List<ViewHotKeyHandle> list;
			if (this.ViewNameViewHotKeyHandleMapping.TryGetValue(viewName, out list))
			{
				return list.ToArray();
			}
			return null;
		}

		// Token: 0x06031A12 RID: 203282 RVA: 0x00C5D7EC File Offset: 0x00C5B9EC
		public ViewHotKeyHandle[] GetAll()
		{
			List<ViewHotKeyHandle> list = new List<ViewHotKeyHandle>();
			foreach (List<ViewHotKeyHandle> list2 in this.ViewNameViewHotKeyHandleMapping.Values)
			{
				foreach (ViewHotKeyHandle item in list2)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06031A13 RID: 203283 RVA: 0x00C5D884 File Offset: 0x00C5BA84
		public void ForEach(Action<ViewHotKeyHandle> callback)
		{
			foreach (List<ViewHotKeyHandle> list in this.ViewNameViewHotKeyHandleMapping.Values)
			{
				foreach (ViewHotKeyHandle obj in list)
				{
					callback(obj);
				}
			}
		}

		// Token: 0x06031A14 RID: 203284 RVA: 0x00C5D910 File Offset: 0x00C5BB10
		public bool IsDataExist(int configId)
		{
			foreach (List<ViewHotKeyHandle> list in this.ViewNameViewHotKeyHandleMapping.Values)
			{
				foreach (ViewHotKeyHandle viewHotKeyHandle in list)
				{
					int? configId2 = viewHotKeyHandle.ConfigId;
					if (configId2.GetValueOrDefault() == configId & configId2 != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06031A15 RID: 203285 RVA: 0x00C5D9BC File Offset: 0x00C5BBBC
		public void RegisterOpenViewFunc(EUiViewName viewName, Action @delegate)
		{
			this.ViewNameOpenFuncMapping[viewName] = @delegate;
		}

		// Token: 0x06031A16 RID: 203286 RVA: 0x00C5D9CB File Offset: 0x00C5BBCB
		public void RegisterCloseViewFunc(EUiViewName viewName, Action @delegate)
		{
			this.ViewNameCloseFuncMapping[viewName] = @delegate;
		}

		// Token: 0x0401CE38 RID: 118328
		private readonly Dictionary<EUiViewName, List<ViewHotKeyHandle>> ViewNameViewHotKeyHandleMapping = new Dictionary<EUiViewName, List<ViewHotKeyHandle>>();

		// Token: 0x0401CE39 RID: 118329
		private readonly Dictionary<EUiViewName, Action> ViewNameOpenFuncMapping = new Dictionary<EUiViewName, Action>();

		// Token: 0x0401CE3A RID: 118330
		private readonly Dictionary<EUiViewName, Action> ViewNameCloseFuncMapping = new Dictionary<EUiViewName, Action>();
	}
}
