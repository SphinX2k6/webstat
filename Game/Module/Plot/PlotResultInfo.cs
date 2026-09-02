using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005359 RID: 21337
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotResultInfo
	{
		// Token: 0x060366F6 RID: 222966 RVA: 0x00DBB892 File Offset: 0x00DB9A92
		public PlotResultInfo()
		{
			this.FlowListName = "";
			this.FlowId = new int?(0);
			this.StateId = new int?(0);
			this.FlowIncId = new long?(0L);
			this.ResultCode = EPlotResultCode.Success;
		}

		// Token: 0x060366F7 RID: 222967 RVA: 0x00DBB8D1 File Offset: 0x00DB9AD1
		public void Reset()
		{
			this.ResultCode = EPlotResultCode.Success;
		}

		// Token: 0x17008D6A RID: 36202
		// (get) Token: 0x060366F8 RID: 222968 RVA: 0x00DBB8DC File Offset: 0x00DB9ADC
		public string FormatId
		{
			get
			{
				if (this.FormatIdInner == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
					defaultInterpolatedStringHandler.AppendFormatted(this.FlowListName);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int?>(this.FlowId);
					defaultInterpolatedStringHandler.AppendLiteral(",");
					defaultInterpolatedStringHandler.AppendFormatted<int?>(this.StateId);
					this.FormatIdInner = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				return this.FormatIdInner;
			}
		}

		// Token: 0x0401F4D6 RID: 128214
		[Nullable(2)]
		public string FlowListName;

		// Token: 0x0401F4D7 RID: 128215
		public int? FlowId;

		// Token: 0x0401F4D8 RID: 128216
		public int? StateId;

		// Token: 0x0401F4D9 RID: 128217
		public long? FlowIncId;

		// Token: 0x0401F4DA RID: 128218
		public EPlotResultCode ResultCode;

		// Token: 0x0401F4DB RID: 128219
		[Nullable(2)]
		private string FormatIdInner;
	}
}
