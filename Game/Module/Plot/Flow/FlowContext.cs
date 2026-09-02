using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x02005401 RID: 21505
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowContext : IStaticVariableResetter
	{
		// Token: 0x06036E87 RID: 224903 RVA: 0x00DEC910 File Offset: 0x00DEAB10
		static FlowContext()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FlowContext.CreateStaticDefaultValue), new Action(FlowContext.ResetStaticDefaultValue));
		}

		// Token: 0x17008E0E RID: 36366
		// (get) Token: 0x06036E88 RID: 224904 RVA: 0x00DEC92F File Offset: 0x00DEAB2F
		public static Pool<FlowContext> Pool
		{
			get
			{
				return FlowContext._pool;
			}
		}

		// Token: 0x06036E89 RID: 224905 RVA: 0x00DEC938 File Offset: 0x00DEAB38
		public FlowContext()
		{
			this.IsServerNotify = false;
			this.FlowListName = "";
			this.FlowId = 0;
			this.FlowStateId = 0;
			this.Context = null;
			this.CurActionId = 0;
			this.IsWaitRenderData = true;
			this.CurSubActionId = 0;
			this.CurShowTalk = null;
			this.CurShowTalkActionId = 0;
			this.CurTalkId = -1;
			this.CurOptionId = -1;
			this.IsBackground = false;
			this.IsSegmentSkipping = false;
			this.HasSkipped = false;
			this.IsFadeSkip = false;
			this.IsBreakdown = false;
			this.IsServerEnd = false;
			this.IsAsync = false;
			this.FlowIncId = 0L;
			this.HasAdjustCamera = false;
			this.CanSkip = false;
			this.TalkHistory = new List<TalkRecord>();
			this.OptionsHistory = new Dictionary<int, Dictionary<int, int>>();
			this.OptionsCollection = new List<ValueTuple<int, List<ValueTuple<int, int>>>>();
			this.UiParam = null;
			this.FormatIdInner = null;
			this.Pos = null;
			this.RollbackRecord = new List<ActionRecord>();
			this.KeepMainRolePose = false;
			this.SeamlessPlot = false;
			this.DeferredFinalizeFlags = ESeamlessFinalizeFlag.None;
			this.NeedPreloadUiSequenceData = null;
			this.PromptStyle = null;
			this.Callback = null;
		}

		// Token: 0x06036E8A RID: 224906 RVA: 0x00DECA5C File Offset: 0x00DEAC5C
		public void Init(PlotInfo p, bool isSkip)
		{
			this.Clear();
			this.IsServerNotify = p.IsServerNotify;
			this.FlowIncId = p.FlowIncId;
			this.FlowListName = p.FlowListName;
			this.FlowId = p.FlowId;
			this.IsBackground = isSkip;
			this.IsBreakdown = p.IsBreakdown;
			this.Context = p.Context;
			this.IsAsync = p.IsAsync;
			this.UiParam = p.UiParam;
			this.FlowStateId = p.StateId.GetValueOrDefault();
			this.Pos = p.Pos;
			this.KeepMainRolePose = p.KeepMainRolePose;
			this.SeamlessPlot = p.Seamless;
			this.IsServerEnd = p.IsServerEnd;
			if (p.PreloadSequenceUiData != null)
			{
				this.NeedPreloadUiSequenceData = new List<string>();
				this.NeedPreloadUiSequenceData.AddRange(p.PreloadSequenceUiData);
			}
			this.PromptStyle = p.PromptStyle;
			this.Callback = p.Callback;
		}

		// Token: 0x06036E8B RID: 224907 RVA: 0x00DECB54 File Offset: 0x00DEAD54
		private void Clear()
		{
			this.FlowIncId = -1L;
			this.Context = null;
			this.CurActionId = 0;
			this.CurSubActionId = 0;
			this.IsAsync = false;
			this.CurShowTalk = null;
			this.CurTalkId = -1;
			this.CurOptionId = -1;
			this.IsBackground = false;
			this.IsSegmentSkipping = false;
			this.HasSkipped = false;
			this.IsBreakdown = false;
			this.IsServerEnd = false;
			this.HasAdjustCamera = false;
			this.TalkHistory.Clear();
			this.OptionsHistory.Clear();
			this.OptionsCollection.Clear();
			this.UiParam = null;
			this.FlowListName = "";
			this.FlowId = 0;
			this.FlowStateId = 0;
			this.FormatIdInner = null;
			this.CanSkip = false;
			this.CurShowTalkActionId = 0;
			this.IsFadeSkip = false;
			this.Pos = null;
			this.RollbackRecord.Clear();
			this.KeepMainRolePose = false;
			this.SeamlessPlot = false;
			this.DeferredFinalizeFlags = ESeamlessFinalizeFlag.None;
			this.NeedPreloadUiSequenceData = null;
			this.PromptStyle = null;
			this.Callback = null;
		}

		// Token: 0x06036E8C RID: 224908 RVA: 0x00DECC62 File Offset: 0x00DEAE62
		public void AddDeferredFinalizeFlag(ESeamlessFinalizeFlag flag)
		{
			this.DeferredFinalizeFlags |= flag;
		}

		// Token: 0x06036E8D RID: 224909 RVA: 0x00DECC72 File Offset: 0x00DEAE72
		public ESeamlessFinalizeFlag ConsumeDeferredFinalizeFlags()
		{
			ESeamlessFinalizeFlag deferredFinalizeFlags = this.DeferredFinalizeFlags;
			this.DeferredFinalizeFlags = ESeamlessFinalizeFlag.None;
			return deferredFinalizeFlags;
		}

		// Token: 0x06036E8E RID: 224910 RVA: 0x00DECC81 File Offset: 0x00DEAE81
		public static FlowContext Create()
		{
			return FlowContext.Pool.Get() ?? FlowContext.Pool.Create();
		}

		// Token: 0x06036E8F RID: 224911 RVA: 0x00DECC9B File Offset: 0x00DEAE9B
		public void Recycle()
		{
			this.Clear();
			FlowContext.Pool.Put(this);
		}

		// Token: 0x17008E0F RID: 36367
		// (get) Token: 0x06036E90 RID: 224912 RVA: 0x00DECCB0 File Offset: 0x00DEAEB0
		public string FormatId
		{
			get
			{
				if (this.FormatIdInner == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
					defaultInterpolatedStringHandler.AppendFormatted(this.FlowListName);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.FlowId);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.FlowStateId);
					this.FormatIdInner = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				return this.FormatIdInner;
			}
		}

		// Token: 0x06036E91 RID: 224913 RVA: 0x00DECD20 File Offset: 0x00DEAF20
		public void LogError(string text, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[Flow] " + text;
			ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
			int num = 0;
			ValueTuple<string, object>[] array = new ValueTuple<string, object>[5 + readOnlySpan.Length];
			readOnlySpan.CopyTo(new Span<ValueTuple<string, object>>(array).Slice(num, readOnlySpan.Length));
			num += readOnlySpan.Length;
			array[num] = new ValueTuple<string, object>("IncId", this.FlowIncId);
			num++;
			array[num] = new ValueTuple<string, object>("Id", this.FormatId);
			num++;
			array[num] = new ValueTuple<string, object>("ActionId", this.CurActionId);
			num++;
			array[num] = new ValueTuple<string, object>("SubActionId", this.CurSubActionId);
			num++;
			array[num] = new ValueTuple<string, object>("TalkId", this.CurTalkId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(array));
		}

		// Token: 0x06036E92 RID: 224914 RVA: 0x00DECE1D File Offset: 0x00DEB01D
		public static void CreateStaticDefaultValue()
		{
			FlowContext._pool = new Pool<FlowContext>(20, () => new FlowContext(), null);
		}

		// Token: 0x06036E93 RID: 224915 RVA: 0x00DECE4B File Offset: 0x00DEB04B
		public static void ResetStaticDefaultValue()
		{
			FlowContext._pool = null;
		}

		// Token: 0x0401F993 RID: 129427
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Pool<FlowContext> _pool;

		// Token: 0x0401F994 RID: 129428
		public bool IsServerNotify;

		// Token: 0x0401F995 RID: 129429
		public string FlowListName;

		// Token: 0x0401F996 RID: 129430
		public int FlowId;

		// Token: 0x0401F997 RID: 129431
		public int FlowStateId;

		// Token: 0x0401F998 RID: 129432
		[Nullable(2)]
		public GeneralContext Context;

		// Token: 0x0401F999 RID: 129433
		public int CurActionId;

		// Token: 0x0401F99A RID: 129434
		public bool IsWaitRenderData;

		// Token: 0x0401F99B RID: 129435
		public int CurSubActionId;

		// Token: 0x0401F99C RID: 129436
		[Nullable(2)]
		public ShowTalk CurShowTalk;

		// Token: 0x0401F99D RID: 129437
		public int CurShowTalkActionId;

		// Token: 0x0401F99E RID: 129438
		public int CurTalkId;

		// Token: 0x0401F99F RID: 129439
		public int CurOptionId;

		// Token: 0x0401F9A0 RID: 129440
		public bool IsBackground;

		// Token: 0x0401F9A1 RID: 129441
		public bool IsSegmentSkipping;

		// Token: 0x0401F9A2 RID: 129442
		public bool HasSkipped;

		// Token: 0x0401F9A3 RID: 129443
		public bool IsFadeSkip;

		// Token: 0x0401F9A4 RID: 129444
		public bool IsBreakdown;

		// Token: 0x0401F9A5 RID: 129445
		public bool IsServerEnd;

		// Token: 0x0401F9A6 RID: 129446
		public bool IsAsync;

		// Token: 0x0401F9A7 RID: 129447
		public long FlowIncId;

		// Token: 0x0401F9A8 RID: 129448
		public bool HasAdjustCamera;

		// Token: 0x0401F9A9 RID: 129449
		public bool CanSkip;

		// Token: 0x0401F9AA RID: 129450
		public List<TalkRecord> TalkHistory;

		// Token: 0x0401F9AB RID: 129451
		public Dictionary<int, Dictionary<int, int>> OptionsHistory;

		// Token: 0x0401F9AC RID: 129452
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			0
		})]
		public List<ValueTuple<int, List<ValueTuple<int, int>>>> OptionsCollection;

		// Token: 0x0401F9AD RID: 129453
		[Nullable(2)]
		public UiParam UiParam;

		// Token: 0x0401F9AE RID: 129454
		[Nullable(2)]
		public string FormatIdInner;

		// Token: 0x0401F9AF RID: 129455
		[Nullable(2)]
		public Vector Pos;

		// Token: 0x0401F9B0 RID: 129456
		public List<ActionRecord> RollbackRecord;

		// Token: 0x0401F9B1 RID: 129457
		public bool KeepMainRolePose;

		// Token: 0x0401F9B2 RID: 129458
		public bool SeamlessPlot;

		// Token: 0x0401F9B3 RID: 129459
		public ESeamlessFinalizeFlag DeferredFinalizeFlags;

		// Token: 0x0401F9B4 RID: 129460
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> NeedPreloadUiSequenceData;

		// Token: 0x0401F9B5 RID: 129461
		public EPromptStyle? PromptStyle;

		// Token: 0x0401F9B6 RID: 129462
		[Nullable(2)]
		public Action Callback;
	}
}
