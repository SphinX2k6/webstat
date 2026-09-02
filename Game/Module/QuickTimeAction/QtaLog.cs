using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.QuickTimeAction.Context;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052B5 RID: 21173
	[NullableContext(1)]
	[Nullable(0)]
	public class QtaLog
	{
		// Token: 0x060361E6 RID: 221670 RVA: 0x00DA0CB0 File Offset: 0x00D9EEB0
		[NullableContext(2)]
		private static void LogInternal(CombatLog.ELogType logType, QtaContextBase qtaContext, [Nullable(1)] string message, [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs, Exception stack = null)
		{
			int value = (qtaContext != null) ? qtaContext.QtaId : 0;
			int value2 = (qtaContext != null) ? qtaContext.HandleId : 0;
			EQtaSource? value3 = (qtaContext != null) ? qtaContext.Source : null;
			EQtaState? value4 = (qtaContext != null) ? new EQtaState?(qtaContext.State) : null;
			EQtaResult? value5 = (qtaContext != null) ? new EQtaResult?(qtaContext.PendingResultType) : null;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 6);
			defaultInterpolatedStringHandler.AppendLiteral("[qta:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("|hd:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("|src:");
			defaultInterpolatedStringHandler.AppendFormatted<EQtaSource?>(value3);
			defaultInterpolatedStringHandler.AppendLiteral("|ste:");
			defaultInterpolatedStringHandler.AppendFormatted<EQtaState?>(value4);
			defaultInterpolatedStringHandler.AppendLiteral("|ret:");
			defaultInterpolatedStringHandler.AppendFormatted<EQtaResult?>(value5);
			defaultInterpolatedStringHandler.AppendLiteral("] ");
			defaultInterpolatedStringHandler.AppendFormatted(message);
			string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
			switch (logType)
			{
			case CombatLog.ELogType.Info:
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HWR, message2, pairs);
				return;
			case CombatLog.ELogType.Debug:
				break;
			case CombatLog.ELogType.Warn:
				Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.HWR, message2, pairs);
				return;
			case CombatLog.ELogType.Error:
				if (stack != null)
				{
					Singleton<Log>.Instance.ErrorWithStack(ELogModule.Battle, ELogAuthor.HWR, message2, stack, pairs);
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, message2, pairs);
				break;
			default:
				return;
			}
		}

		// Token: 0x060361E7 RID: 221671 RVA: 0x00DA0E14 File Offset: 0x00D9F014
		[Conditional("DEBUG")]
		public static void Debug([Nullable(2)] QtaContextBase qtaContext, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (!Singleton<CSharpScript.Core.Common.Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			QtaLog.LogInternal(CombatLog.ELogType.Debug, qtaContext, message, pairs, null);
		}

		// Token: 0x060361E8 RID: 221672 RVA: 0x00DA0E2D File Offset: 0x00D9F02D
		public static void Info([Nullable(2)] QtaContextBase qtaContext, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			QtaLog.LogInternal(CombatLog.ELogType.Info, qtaContext, message, pairs, null);
		}

		// Token: 0x060361E9 RID: 221673 RVA: 0x00DA0E39 File Offset: 0x00D9F039
		public static void Error([Nullable(2)] QtaContextBase qtaContext, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			QtaLog.LogInternal(CombatLog.ELogType.Error, qtaContext, message, pairs, null);
		}
	}
}
