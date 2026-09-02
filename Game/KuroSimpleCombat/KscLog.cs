using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Core.Common;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.KuroSimpleCombat
{
	// Token: 0x02006FBD RID: 28605
	[NullableContext(1)]
	[Nullable(0)]
	public class KscLog
	{
		// Token: 0x0604528A RID: 283274 RVA: 0x0120C134 File Offset: 0x0120A334
		private static void Log(KscLog.ELogType logType, ELogAuthor logAuthor, KscLog.EModule flag, [Nullable(2)] UObject obj, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
			defaultInterpolatedStringHandler.AppendLiteral("[KSC][");
			defaultInterpolatedStringHandler.AppendFormatted<KscLog.EModule>(flag);
			defaultInterpolatedStringHandler.AppendLiteral("][Object:");
			defaultInterpolatedStringHandler.AppendFormatted((obj != null) ? obj.GetName() : null);
			defaultInterpolatedStringHandler.AppendLiteral("] ");
			defaultInterpolatedStringHandler.AppendFormatted(log);
			string message = defaultInterpolatedStringHandler.ToStringAndClear();
			switch (logType)
			{
			case KscLog.ELogType.Debug:
				break;
			case KscLog.ELogType.Info:
				Singleton<global::Log>.Instance.Info(ELogModule.CombatInfo, logAuthor, message, pairs);
				return;
			case KscLog.ELogType.Warn:
				Singleton<global::Log>.Instance.Warn(ELogModule.CombatInfo, logAuthor, message, pairs);
				return;
			case KscLog.ELogType.Error:
				Singleton<global::Log>.Instance.Error(ELogModule.CombatInfo, logAuthor, message, pairs);
				KscLog.PrintOnScreen(message, pairs);
				break;
			default:
				return;
			}
		}

		// Token: 0x0604528B RID: 283275 RVA: 0x0120C1F5 File Offset: 0x0120A3F5
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void Debug(KscLog.EModule flag, ELogAuthor author, [Nullable(2)] UObject obj, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
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
			KscLog.Log(KscLog.ELogType.Debug, author, flag, obj, log, pairs);
		}

		// Token: 0x0604528C RID: 283276 RVA: 0x0120C210 File Offset: 0x0120A410
		public static void Info(KscLog.EModule flag, ELogAuthor author, [Nullable(2)] UObject obj, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Log(KscLog.ELogType.Info, author, flag, obj, log, pairs);
		}

		// Token: 0x0604528D RID: 283277 RVA: 0x0120C21E File Offset: 0x0120A41E
		public static void Warn(KscLog.EModule flag, ELogAuthor author, [Nullable(2)] UObject obj, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Log(KscLog.ELogType.Warn, author, flag, obj, log, pairs);
		}

		// Token: 0x0604528E RID: 283278 RVA: 0x0120C22C File Offset: 0x0120A42C
		public static void Error(KscLog.EModule flag, ELogAuthor author, [Nullable(2)] UObject obj, string log, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			KscLog.Log(KscLog.ELogType.Error, author, flag, obj, log, pairs);
		}

		// Token: 0x0604528F RID: 283279 RVA: 0x0120C23C File Offset: 0x0120A43C
		private unsafe static void PrintOnScreen(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (!UKuroStaticLibrary.IsEditor(GlobalData.World))
			{
				return;
			}
			UWorld world = GlobalData.World.GetWorld();
			if (world == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.CombatInfo, ELogAuthor.CFT, "PrintOnScreen world is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			StringBuilder sb = KscLog.Sb;
			sb.Clear();
			sb.Append(message);
			ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				ValueTuple<string, object> valueTuple = *readOnlySpan[i];
				string item = valueTuple.Item1;
				object item2 = valueTuple.Item2;
				sb.Append('[');
				StringBuilder stringBuilder = sb;
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder);
				appendInterpolatedStringHandler.AppendFormatted(item);
				appendInterpolatedStringHandler.AppendLiteral(":");
				appendInterpolatedStringHandler.AppendFormatted(((item2 != null) ? item2.ToString() : null) ?? "null");
				stringBuilder2.Append(ref appendInterpolatedStringHandler);
				sb.Append(']');
			}
			UKismetSystemLibrary.PrintString(world, sb.ToString(), true, false, new FLinearColor?(new FLinearColor(1f, 0f, 0f, 1f)), 10f);
		}

		// Token: 0x04026956 RID: 158038
		[StaticVariableRuleIgnore]
		private static readonly StringBuilder Sb = new StringBuilder(256);

		// Token: 0x0200CC1E RID: 52254
		[NullableContext(0)]
		private enum ELogType
		{
			// Token: 0x0403E938 RID: 256312
			Debug,
			// Token: 0x0403E939 RID: 256313
			Info,
			// Token: 0x0403E93A RID: 256314
			Warn,
			// Token: 0x0403E93B RID: 256315
			Error
		}

		// Token: 0x0200CC1F RID: 52255
		[NullableContext(0)]
		public enum EModule
		{
			// Token: 0x0403E93D RID: 256317
			Common,
			// Token: 0x0403E93E RID: 256318
			Load,
			// Token: 0x0403E93F RID: 256319
			Attr,
			// Token: 0x0403E940 RID: 256320
			Input,
			// Token: 0x0403E941 RID: 256321
			Skill
		}
	}
}
