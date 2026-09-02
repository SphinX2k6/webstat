using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x0200462B RID: 17963
	[NullableContext(1)]
	[Nullable(0)]
	public class UpdateReportEvent : IDiffUpdateReportEvent
	{
		// Token: 0x0602EED7 RID: 192215 RVA: 0x00B1DD68 File Offset: 0x00B1BF68
		public UpdateReportEvent(string eventPrefix)
		{
			this.EventPrefix = eventPrefix;
		}

		// Token: 0x0602EED8 RID: 192216 RVA: 0x00B1DD78 File Offset: 0x00B1BF78
		public void Start(HotPatchLog log, [Nullable(2)] string suffixTag = null)
		{
			string text;
			if (suffixTag == null)
			{
				text = this.EventPrefix + "_" + log.s_step_id + "_start";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 3);
				defaultInterpolatedStringHandler.AppendFormatted(this.EventPrefix);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted(suffixTag);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted(log.s_step_id);
				defaultInterpolatedStringHandler.AppendLiteral("_start");
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string s_step_id = text;
			log.s_step_id = s_step_id;
			Singleton<HotPatchLogReport>.Instance.Report(log);
		}

		// Token: 0x0602EED9 RID: 192217 RVA: 0x00B1DE10 File Offset: 0x00B1C010
		public void End(HotPatchLog log, [Nullable(2)] string suffixTag = null)
		{
			string text;
			if (suffixTag == null)
			{
				text = this.EventPrefix + "_" + log.s_step_id + "_end";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
				defaultInterpolatedStringHandler.AppendFormatted(this.EventPrefix);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted(suffixTag);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted(log.s_step_id);
				defaultInterpolatedStringHandler.AppendLiteral("_end");
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string s_step_id = text;
			log.s_step_id = s_step_id;
			Singleton<HotPatchLogReport>.Instance.Report(log);
		}

		// Token: 0x0602EEDA RID: 192218 RVA: 0x00B1DEA8 File Offset: 0x00B1C0A8
		public void Event(HotPatchLog log, [Nullable(2)] string suffixTag = null)
		{
			string text;
			if (suffixTag == null)
			{
				text = this.EventPrefix + "_" + log.s_step_id + "_event";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 3);
				defaultInterpolatedStringHandler.AppendFormatted(this.EventPrefix);
				defaultInterpolatedStringHandler.AppendLiteral("-");
				defaultInterpolatedStringHandler.AppendFormatted(suffixTag);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted(log.s_step_id);
				defaultInterpolatedStringHandler.AppendLiteral("_event");
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string s_step_id = text;
			log.s_step_id = s_step_id;
			Singleton<HotPatchLogReport>.Instance.Report(log);
		}

		// Token: 0x0401AB40 RID: 109376
		private readonly string EventPrefix;
	}
}
