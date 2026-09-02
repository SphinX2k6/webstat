using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DataLayerSwitch
{
	// Token: 0x02005DD2 RID: 24018
	[NullableContext(2)]
	[Nullable(0)]
	public class DataLayerSwitchContext
	{
		// Token: 0x170098C9 RID: 39113
		// (get) Token: 0x0603C75D RID: 247645 RVA: 0x00F5AE81 File Offset: 0x00F59081
		public bool DataLayerSwitching
		{
			get
			{
				return this.DataLayerSwitchingInternal;
			}
		}

		// Token: 0x170098CA RID: 39114
		// (get) Token: 0x0603C75E RID: 247646 RVA: 0x00F5AE89 File Offset: 0x00F59089
		public bool DataLayerStreaming
		{
			get
			{
				return this.DataLayerStreamingInternal;
			}
		}

		// Token: 0x170098CB RID: 39115
		// (get) Token: 0x0603C75F RID: 247647 RVA: 0x00F5AE91 File Offset: 0x00F59091
		public int CurrentSwitchInstId
		{
			get
			{
				return this.CurrentSwitchInstIdInternal;
			}
		}

		// Token: 0x170098CC RID: 39116
		// (get) Token: 0x0603C760 RID: 247648 RVA: 0x00F5AE99 File Offset: 0x00F59099
		public bool DataLayerSwitchAborted
		{
			get
			{
				return this.DataLayerSwitchAbortedInternal;
			}
		}

		// Token: 0x170098CD RID: 39117
		// (get) Token: 0x0603C761 RID: 247649 RVA: 0x00F5AEA1 File Offset: 0x00F590A1
		public CustomPromise<bool> DataLayerSwitchAbortPromise
		{
			get
			{
				return this.DataLayerSwitchAbortPromiseInternal;
			}
		}

		// Token: 0x0603C762 RID: 247650 RVA: 0x00F5AEAC File Offset: 0x00F590AC
		public void ResetDataLayerSwitchAbort()
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZYL, "DataLayerSwitchContext:重置打断标志并新建打断信号", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.DataLayerSwitchAbortedInternal = false;
			this.DataLayerSwitchAbortPromiseInternal = new CustomPromise<bool>();
		}

		// Token: 0x0603C763 RID: 247651 RVA: 0x00F5AEE8 File Offset: 0x00F590E8
		public unsafe void AbortDataLayerSwitch()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DataLayerSwitchContext:打断DataLayer切换";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("InstId", this.CurrentSwitchInstIdInternal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("已打断", this.DataLayerSwitchAbortedInternal);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.DataLayerSwitchAbortedInternal = true;
			CustomPromise<bool> dataLayerSwitchAbortPromiseInternal = this.DataLayerSwitchAbortPromiseInternal;
			if (dataLayerSwitchAbortPromiseInternal == null)
			{
				return;
			}
			dataLayerSwitchAbortPromiseInternal.SetResult(true);
		}

		// Token: 0x0603C764 RID: 247652 RVA: 0x00F5AF74 File Offset: 0x00F59174
		public void InitDataLayerStreamingData()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DataLayerSwitchContext:初始化流送数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", this.CurrentSwitchInstIdInternal);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DataLayerStreamingInternal = true;
			this.DataLayerChangeVoxelPromiseInternal = new CustomPromise<bool>();
			this.DataLayerChangeStreamingPromiseInternal = new CustomPromise<bool>();
		}

		// Token: 0x170098CE RID: 39118
		// (get) Token: 0x0603C765 RID: 247653 RVA: 0x00F5AFCF File Offset: 0x00F591CF
		public CustomPromise<bool> DataLayerChangeVoxelPromise
		{
			get
			{
				return this.DataLayerChangeVoxelPromiseInternal;
			}
		}

		// Token: 0x170098CF RID: 39119
		// (get) Token: 0x0603C766 RID: 247654 RVA: 0x00F5AFD7 File Offset: 0x00F591D7
		public CustomPromise<bool> DataLayerChangeStreamingPromise
		{
			get
			{
				return this.DataLayerChangeStreamingPromiseInternal;
			}
		}

		// Token: 0x0603C767 RID: 247655 RVA: 0x00F5AFE0 File Offset: 0x00F591E0
		public void ClearDataLayerStreamingData()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DataLayerSwitchContext:清理流送数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", this.CurrentSwitchInstIdInternal);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DataLayerStreamingInternal = false;
			CustomPromise<bool> dataLayerChangeVoxelPromiseInternal = this.DataLayerChangeVoxelPromiseInternal;
			if (dataLayerChangeVoxelPromiseInternal != null)
			{
				dataLayerChangeVoxelPromiseInternal.SetResult(true);
			}
			CustomPromise<bool> dataLayerChangeStreamingPromiseInternal = this.DataLayerChangeStreamingPromiseInternal;
			if (dataLayerChangeStreamingPromiseInternal == null)
			{
				return;
			}
			dataLayerChangeStreamingPromiseInternal.SetResult(true);
		}

		// Token: 0x0603C768 RID: 247656 RVA: 0x00F5B048 File Offset: 0x00F59248
		public void BeginDataLayerSwitch(int currentSwitchInstId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DataLayerSwitchContext:开始DataLayer切换";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", currentSwitchInstId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DataLayerSwitchingInternal = true;
			this.CurrentSwitchInstIdInternal = currentSwitchInstId;
		}

		// Token: 0x0603C769 RID: 247657 RVA: 0x00F5B090 File Offset: 0x00F59290
		public void FinishDataLayerSwitch()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DataLayerSwitchContext:结束DataLayer切换";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", this.CurrentSwitchInstIdInternal);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DataLayerSwitchingInternal = false;
			this.CurrentSwitchInstIdInternal = 0;
		}

		// Token: 0x04021FDC RID: 139228
		private bool DataLayerSwitchingInternal;

		// Token: 0x04021FDD RID: 139229
		private bool DataLayerStreamingInternal;

		// Token: 0x04021FDE RID: 139230
		private int CurrentSwitchInstIdInternal;

		// Token: 0x04021FDF RID: 139231
		private bool DataLayerSwitchAbortedInternal;

		// Token: 0x04021FE0 RID: 139232
		private CustomPromise<bool> DataLayerSwitchAbortPromiseInternal;

		// Token: 0x04021FE1 RID: 139233
		private CustomPromise<bool> DataLayerChangeVoxelPromiseInternal;

		// Token: 0x04021FE2 RID: 139234
		private CustomPromise<bool> DataLayerChangeStreamingPromiseInternal;
	}
}
