using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C7B RID: 19579
	[NullableContext(1)]
	[Nullable(0)]
	public class ScrollViewDelegate<TProxy, [Nullable(2)] TData> : IScrollViewDelegate<TProxy, TData> where TProxy : class, IGridProxy<TData>
	{
		// Token: 0x0603305C RID: 208988 RVA: 0x00CC7546 File Offset: 0x00CC5746
		public ScrollViewDelegate(Func<TProxy> proxyCreateFunction)
		{
			this.ProxyCreateFunction = proxyCreateFunction;
		}

		// Token: 0x0603305D RID: 208989 RVA: 0x00CC757D File Offset: 0x00CC577D
		public void SetData(IReadOnlyList<TData> data)
		{
			this.ClearData();
			this.Data.AddRange(data);
			this.DataLength = this.Data.Count;
		}

		// Token: 0x0603305E RID: 208990 RVA: 0x00CC75A2 File Offset: 0x00CC57A2
		public IReadOnlyList<TData> GetDatas()
		{
			return this.Data.AsReadOnly();
		}

		// Token: 0x0603305F RID: 208991 RVA: 0x00CC75AF File Offset: 0x00CC57AF
		public void SetDataProxy(Func<int, TData> dataProxyFunction, int dataLength, bool cacheData = true)
		{
			this.ClearData();
			this.DataProxyFunction = dataProxyFunction;
			this.DataLength = dataLength;
			this.IsCacheProxyData = cacheData;
		}

		// Token: 0x06033060 RID: 208992 RVA: 0x00CC75CC File Offset: 0x00CC57CC
		public void OnGridsUpdate(int gridIndex, int displayIndex, int startGridIndex, int endGridIndex)
		{
			if (gridIndex >= this.DataLength || displayIndex >= this.Proxies.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ScrollViewGrid;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 4);
				defaultInterpolatedStringHandler.AppendLiteral("参数值非法 gridIndex: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(gridIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" displayIndex: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(displayIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" Data.length: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.DataLength);
				defaultInterpolatedStringHandler.AppendLiteral(" Proxies.length: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Proxies.Count);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.SelectedGridIndex != -1 && (this.SelectedGridIndex < startGridIndex || this.SelectedGridIndex > endGridIndex))
			{
				this.SelectedProxy = default(TProxy);
			}
			if (displayIndex < this.ProxyValidBits.Count)
			{
				this.ProxyValidBits[displayIndex] = true;
			}
			this.RefreshGridProxy(gridIndex, displayIndex);
		}

		// Token: 0x06033061 RID: 208993 RVA: 0x00CC76C8 File Offset: 0x00CC58C8
		public void RefreshGridProxy(int gridIndex, int displayIndex)
		{
			if (gridIndex >= this.DataLength || displayIndex >= this.Proxies.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ScrollViewGrid;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 4);
				defaultInterpolatedStringHandler.AppendLiteral("参数值非法 gridIndex: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(gridIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" displayIndex: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(displayIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" Data.length: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.DataLength);
				defaultInterpolatedStringHandler.AppendLiteral(" Proxies.length: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Proxies.Count);
				instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TProxy gridProxy = this.GetGridProxy(displayIndex);
			if (gridProxy == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.ScrollViewGrid;
				ELogAuthor author2 = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(67, 4);
				defaultInterpolatedStringHandler.AppendLiteral("Proxy获取异常 gridIndex: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(gridIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" displayIndex: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(displayIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" Data.length: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.DataLength);
				defaultInterpolatedStringHandler.AppendLiteral(" Proxies.length: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Proxies.Count);
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			bool flag = gridIndex != -1 && gridIndex == this.SelectedGridIndex;
			if (flag && this.SelectedProxy == null)
			{
				this.SelectedProxy = gridProxy;
			}
			TData data = this.GetData(gridIndex, displayIndex);
			gridProxy.GridIndex = gridIndex;
			gridProxy.DisplayIndex = displayIndex;
			gridProxy.Refresh(data, flag, gridIndex);
		}

		// Token: 0x06033062 RID: 208994 RVA: 0x00CC786C File Offset: 0x00CC5A6C
		public UniTask RefreshGridProxyAsync(int gridIndex, int displayIndex)
		{
			ScrollViewDelegate<TProxy, TData>.<RefreshGridProxyAsync>d__15 <RefreshGridProxyAsync>d__;
			<RefreshGridProxyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshGridProxyAsync>d__.<>4__this = this;
			<RefreshGridProxyAsync>d__.gridIndex = gridIndex;
			<RefreshGridProxyAsync>d__.displayIndex = displayIndex;
			<RefreshGridProxyAsync>d__.<>1__state = -1;
			<RefreshGridProxyAsync>d__.<>t__builder.Start<ScrollViewDelegate<TProxy, TData>.<RefreshGridProxyAsync>d__15>(ref <RefreshGridProxyAsync>d__);
			return <RefreshGridProxyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033063 RID: 208995 RVA: 0x00CC78C0 File Offset: 0x00CC5AC0
		private TData GetData(int gridIndex, int displayIndex)
		{
			TData tdata = default(TData);
			if (this.Data.Count > gridIndex)
			{
				tdata = this.Data[gridIndex];
			}
			if (tdata == null && this.DataProxyFunction != null)
			{
				tdata = this.DataProxyFunction(gridIndex);
				if (this.IsCacheProxyData && this.Data.Count > gridIndex)
				{
					this.Data[gridIndex] = tdata;
				}
			}
			return tdata;
		}

		// Token: 0x06033064 RID: 208996 RVA: 0x00CC7934 File Offset: 0x00CC5B34
		[NullableContext(2)]
		public TData TryGetCachedData(int gridIndex)
		{
			if (this.Data.Count > gridIndex)
			{
				return this.Data[gridIndex];
			}
			return default(TData);
		}

		// Token: 0x06033065 RID: 208997 RVA: 0x00CC7968 File Offset: 0x00CC5B68
		public TProxy CreateGridProxy(int displayIndex, AActor actor)
		{
			if (displayIndex < this.Proxies.Count && this.Proxies[displayIndex] != null)
			{
				Singleton<Log>.Instance.Error(ELogModule.ScrollViewGrid, ELogAuthor.LZK, "Proxy已经存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return this.Proxies[displayIndex];
			}
			TProxy tproxy = this.ProxyCreateFunction();
			tproxy.CreateThenShowByActor(actor, null);
			while (this.Proxies.Count <= displayIndex)
			{
				this.Proxies.Add(default(TProxy));
				this.ProxyValidBits.Add(false);
			}
			this.Proxies[displayIndex] = tproxy;
			this.ProxyValidBits[displayIndex] = false;
			tproxy.ScrollViewDelegate = this;
			return tproxy;
		}

		// Token: 0x06033066 RID: 208998 RVA: 0x00CC7A30 File Offset: 0x00CC5C30
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<TProxy> CreateGridProxyAsync(int displayIndex, AActor actor, bool bShow = true)
		{
			ScrollViewDelegate<TProxy, TData>.<CreateGridProxyAsync>d__19 <CreateGridProxyAsync>d__;
			<CreateGridProxyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<TProxy>.Create();
			<CreateGridProxyAsync>d__.<>4__this = this;
			<CreateGridProxyAsync>d__.displayIndex = displayIndex;
			<CreateGridProxyAsync>d__.actor = actor;
			<CreateGridProxyAsync>d__.bShow = bShow;
			<CreateGridProxyAsync>d__.<>1__state = -1;
			<CreateGridProxyAsync>d__.<>t__builder.Start<ScrollViewDelegate<TProxy, TData>.<CreateGridProxyAsync>d__19>(ref <CreateGridProxyAsync>d__);
			return <CreateGridProxyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033067 RID: 208999 RVA: 0x00CC7A8C File Offset: 0x00CC5C8C
		[NullableContext(2)]
		public TProxy GetGridProxy(int displayIndex)
		{
			if (displayIndex >= this.ProxyValidBits.Count || displayIndex < 0 || !this.ProxyValidBits[displayIndex])
			{
				return default(TProxy);
			}
			if (displayIndex < this.Proxies.Count)
			{
				return this.Proxies[displayIndex];
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScrollViewGrid;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "无法获取Proxy";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DisplayIndex", displayIndex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return default(TProxy);
		}

		// Token: 0x06033068 RID: 209000 RVA: 0x00CC7B13 File Offset: 0x00CC5D13
		public void ClearGridProxy(int gridIndex, int displayIndex)
		{
			TProxy tproxy = this.GetGridProxy(displayIndex);
			if (tproxy == null)
			{
				return;
			}
			tproxy.Clear();
		}

		// Token: 0x06033069 RID: 209001 RVA: 0x00CC7B2C File Offset: 0x00CC5D2C
		public void SelectGridProxy(int gridIndex, int displayIndex, bool fireEvent)
		{
			if (this.SelectedGridIndex == gridIndex)
			{
				return;
			}
			this.DeselectCurrentGridProxy(fireEvent);
			TProxy gridProxy = this.GetGridProxy(displayIndex);
			if (gridProxy != null)
			{
				gridProxy.OnSelected(fireEvent);
				this.SelectedProxy = gridProxy;
			}
			this.SelectedGridIndex = gridIndex;
		}

		// Token: 0x0603306A RID: 209002 RVA: 0x00CC7B74 File Offset: 0x00CC5D74
		public void DeselectCurrentGridProxy(bool fireEvent)
		{
			this.SelectedGridIndex = -1;
			if (this.SelectedProxy != null)
			{
				this.SelectedProxy.OnDeselected(fireEvent);
				this.SelectedProxy = default(TProxy);
			}
		}

		// Token: 0x0603306B RID: 209003 RVA: 0x00CC7BA7 File Offset: 0x00CC5DA7
		public void ClearSelectInfo()
		{
			this.SelectedGridIndex = -1;
			this.SelectedProxy = default(TProxy);
		}

		// Token: 0x0603306C RID: 209004 RVA: 0x00CC7BBC File Offset: 0x00CC5DBC
		[NullableContext(2)]
		public TProxy GetSelectedProxy()
		{
			return this.SelectedProxy;
		}

		// Token: 0x0603306D RID: 209005 RVA: 0x00CC7BC4 File Offset: 0x00CC5DC4
		public int GetSelectedGridIndex()
		{
			return this.SelectedGridIndex;
		}

		// Token: 0x0603306E RID: 209006 RVA: 0x00CC7BCC File Offset: 0x00CC5DCC
		public int GetDataLength()
		{
			return this.DataLength;
		}

		// Token: 0x0603306F RID: 209007 RVA: 0x00CC7BD4 File Offset: 0x00CC5DD4
		public bool IsProxyValid(int displayIndex)
		{
			return displayIndex < this.ProxyValidBits.Count && this.ProxyValidBits[displayIndex];
		}

		// Token: 0x06033070 RID: 209008 RVA: 0x00CC7BF2 File Offset: 0x00CC5DF2
		public void ClearData()
		{
			this.Data.Clear();
			this.DataLength = 0;
		}

		// Token: 0x06033071 RID: 209009 RVA: 0x00CC7C08 File Offset: 0x00CC5E08
		public void Destroy()
		{
			this.ClearData();
			foreach (TProxy tproxy in this.Proxies)
			{
				tproxy.ScrollViewDelegate = null;
			}
			this.Proxies.Clear();
			this.ProxyValidBits.Clear();
			this.ProxyCreateFunction = null;
			this.DataProxyFunction = null;
		}

		// Token: 0x0401DAC6 RID: 121542
		private List<TData> Data = new List<TData>();

		// Token: 0x0401DAC7 RID: 121543
		private int DataLength;

		// Token: 0x0401DAC8 RID: 121544
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly List<TProxy> Proxies = new List<TProxy>();

		// Token: 0x0401DAC9 RID: 121545
		private readonly List<bool> ProxyValidBits = new List<bool>();

		// Token: 0x0401DACA RID: 121546
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<TProxy> ProxyCreateFunction;

		// Token: 0x0401DACB RID: 121547
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Func<int, TData> DataProxyFunction;

		// Token: 0x0401DACC RID: 121548
		private bool IsCacheProxyData;

		// Token: 0x0401DACD RID: 121549
		private int SelectedGridIndex = -1;

		// Token: 0x0401DACE RID: 121550
		[Nullable(2)]
		private TProxy SelectedProxy;
	}
}
