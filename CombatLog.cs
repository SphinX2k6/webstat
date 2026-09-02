using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using CSharpScript.Core.Common;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x0200344E RID: 13390
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CombatLog : Singleton<CombatLog>
{
	// Token: 0x0601C157 RID: 115031 RVA: 0x00860EEC File Offset: 0x0085F0EC
	private void GetEntityLogInfo([Nullable(2)] Entity entity, out long entityId, out string entityTypeName, out string actorName)
	{
		entityId = 0L;
		entityTypeName = string.Empty;
		actorName = string.Empty;
		if (entity == null)
		{
			return;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component != null)
		{
			entityId = component.GetCreatureDataId();
			entityTypeName = (Enum.GetName<EEntityType>(component.GetEntityType()) ?? string.Empty);
		}
		CharacterActorComponent component2 = entity.GetComponent<CharacterActorComponent>();
		if (component2 != null)
		{
			TsBaseCharacter actor = component2.Actor;
			if (((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault())
			{
				actorName = component2.Actor.GetName();
			}
		}
	}

	// Token: 0x0601C158 RID: 115032 RVA: 0x00860F7C File Offset: 0x0085F17C
	private void LogInternal(int logType, CombatLog.EDebugModule flag, long entityId, string entityTypeName, string actorName, string message, [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs, [Nullable(2)] Exception stack = null)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 5);
		defaultInterpolatedStringHandler.AppendLiteral("[");
		defaultInterpolatedStringHandler.AppendFormatted<CombatLog.EDebugModule>(flag);
		defaultInterpolatedStringHandler.AppendLiteral("][EntityId:");
		defaultInterpolatedStringHandler.AppendFormatted<long>(entityId);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(entityTypeName);
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(actorName);
		defaultInterpolatedStringHandler.AppendLiteral("] ");
		defaultInterpolatedStringHandler.AppendFormatted(message);
		string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
		switch (logType)
		{
		case 0:
			Singleton<Log>.Instance.Info(ELogModule.CombatInfo, ELogAuthor.WCL, message2, pairs);
			return;
		case 1:
			break;
		case 2:
			Singleton<Log>.Instance.Warn(ELogModule.CombatInfo, ELogAuthor.WCL, message2, pairs);
			return;
		case 3:
			if (stack != null)
			{
				Singleton<Log>.Instance.ErrorWithStack(ELogModule.CombatInfo, ELogAuthor.WCL, message2, stack, pairs);
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.CombatInfo, ELogAuthor.WCL, message2, pairs);
			break;
		default:
			return;
		}
	}

	// Token: 0x0601C159 RID: 115033 RVA: 0x00861074 File Offset: 0x0085F274
	public void Info(CombatLog.EDebugModule flag, [Nullable(2)] Entity entity, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		long entityId;
		string entityTypeName;
		string actorName;
		this.GetEntityLogInfo(entity, out entityId, out entityTypeName, out actorName);
		this.LogInternal(0, flag, entityId, entityTypeName, actorName, message, pairs, null);
	}

	// Token: 0x0601C15A RID: 115034 RVA: 0x008610A0 File Offset: 0x0085F2A0
	public void Info(CombatLog.EDebugModule flag, long entityId, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.LogInternal(0, flag, entityId, string.Empty, string.Empty, message, pairs, null);
	}

	// Token: 0x0601C15B RID: 115035 RVA: 0x008610C4 File Offset: 0x0085F2C4
	[Conditional("DEBUG")]
	public void Debug(CombatLog.EDebugModule flag, [Nullable(2)] Entity entity, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		long entityId;
		string entityTypeName;
		string actorName;
		this.GetEntityLogInfo(entity, out entityId, out entityTypeName, out actorName);
		this.LogInternal(1, flag, entityId, entityTypeName, actorName, message, pairs, null);
	}

	// Token: 0x0601C15C RID: 115036 RVA: 0x008610F0 File Offset: 0x0085F2F0
	[Conditional("DEBUG")]
	public void Debug(CombatLog.EDebugModule flag, long entityId, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
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
		this.LogInternal(1, flag, entityId, string.Empty, string.Empty, message, pairs, null);
	}

	// Token: 0x0601C15D RID: 115037 RVA: 0x00861124 File Offset: 0x0085F324
	[Conditional("DEBUG")]
	public void DebugEx(CombatLog.EDebugModule flag, [Nullable(2)] Entity entity, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		long entityId;
		string entityTypeName;
		string actorName;
		this.GetEntityLogInfo(entity, out entityId, out entityTypeName, out actorName);
		this.LogInternal(1, flag, entityId, entityTypeName, actorName, message, pairs, null);
	}

	// Token: 0x0601C15E RID: 115038 RVA: 0x00861150 File Offset: 0x0085F350
	[Conditional("DEBUG")]
	public void DebugEx(CombatLog.EDebugModule flag, long entityId, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (!this.DebugCombatInfo.Contains(flag))
		{
			return;
		}
		this.LogInternal(1, flag, entityId, string.Empty, string.Empty, message, pairs, null);
	}

	// Token: 0x0601C15F RID: 115039 RVA: 0x00861184 File Offset: 0x0085F384
	public void Warn(CombatLog.EDebugModule flag, [Nullable(2)] Entity entity, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		long entityId;
		string entityTypeName;
		string actorName;
		this.GetEntityLogInfo(entity, out entityId, out entityTypeName, out actorName);
		this.LogInternal(2, flag, entityId, entityTypeName, actorName, message, pairs, null);
	}

	// Token: 0x0601C160 RID: 115040 RVA: 0x008611B0 File Offset: 0x0085F3B0
	public void Warn(CombatLog.EDebugModule flag, long entityId, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.LogInternal(2, flag, entityId, string.Empty, string.Empty, message, pairs, null);
	}

	// Token: 0x0601C161 RID: 115041 RVA: 0x008611D4 File Offset: 0x0085F3D4
	public unsafe void Error(CombatLog.EDebugModule flag, [Nullable(2)] Entity entity, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		long entityId;
		string entityTypeName;
		string actorName;
		this.GetEntityLogInfo(entity, out entityId, out entityTypeName, out actorName);
		StringBuilder sb = CombatLog.Sb;
		sb.Clear();
		sb.Append(message);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ValueTuple<string, object> valueTuple = *readOnlySpan[i];
			string item = valueTuple.Item1;
			object item2 = valueTuple.Item2;
			StringBuilder stringBuilder = sb;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder);
			appendInterpolatedStringHandler.AppendLiteral("[");
			appendInterpolatedStringHandler.AppendFormatted(item);
			appendInterpolatedStringHandler.AppendLiteral(":");
			appendInterpolatedStringHandler.AppendFormatted((item2 != null) ? item2.ToString() : "null");
			appendInterpolatedStringHandler.AppendLiteral("]");
			stringBuilder2.Append(ref appendInterpolatedStringHandler);
		}
		sb.ToString();
		this.LogInternal(3, flag, entityId, entityTypeName, actorName, message, pairs, null);
	}

	// Token: 0x0601C162 RID: 115042 RVA: 0x008612B4 File Offset: 0x0085F4B4
	public unsafe void Error(CombatLog.EDebugModule flag, long entityId, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		StringBuilder sb = CombatLog.Sb;
		sb.Clear();
		sb.Append(message);
		ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			ValueTuple<string, object> valueTuple = *readOnlySpan[i];
			string item = valueTuple.Item1;
			object item2 = valueTuple.Item2;
			StringBuilder stringBuilder = sb;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder);
			appendInterpolatedStringHandler.AppendLiteral("[");
			appendInterpolatedStringHandler.AppendFormatted(item);
			appendInterpolatedStringHandler.AppendLiteral(":");
			appendInterpolatedStringHandler.AppendFormatted((item2 != null) ? item2.ToString() : "null");
			appendInterpolatedStringHandler.AppendLiteral("]");
			stringBuilder2.Append(ref appendInterpolatedStringHandler);
		}
		this.LogInternal(3, flag, entityId, string.Empty, string.Empty, message, pairs, null);
	}

	// Token: 0x0601C163 RID: 115043 RVA: 0x00861380 File Offset: 0x0085F580
	[Conditional("DEBUG")]
	private void PrintOnScreen(string message, FLinearColor color)
	{
		if (!UKuroStaticLibrary.IsEditor(GlobalData.World))
		{
			return;
		}
		UWorld world = GlobalData.World.GetWorld();
		if (world == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.CombatInfo, ELogAuthor.ZQR, "PrintOnScreen world is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKismetSystemLibrary.PrintString(world, message, true, false, new FLinearColor?(color), 10f);
	}

	// Token: 0x0601C164 RID: 115044 RVA: 0x008613DC File Offset: 0x0085F5DC
	public void ErrorWithStack(CombatLog.EDebugModule flag, [Nullable(2)] Entity entity, string message, Exception e, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		long entityId;
		string entityTypeName;
		string actorName;
		this.GetEntityLogInfo(entity, out entityId, out entityTypeName, out actorName);
		this.LogInternal(3, flag, entityId, entityTypeName, actorName, message, pairs, e);
	}

	// Token: 0x0601C165 RID: 115045 RVA: 0x00861408 File Offset: 0x0085F608
	public void ErrorWithStack(CombatLog.EDebugModule flag, long entityId, string message, Exception e, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		this.LogInternal(3, flag, entityId, string.Empty, string.Empty, message, pairs, e);
	}

	// Token: 0x0400E2DA RID: 58074
	public HashSet<CombatLog.EDebugModule> DebugCombatInfo = new HashSet<CombatLog.EDebugModule>();

	// Token: 0x0400E2DB RID: 58075
	[StaticVariableRuleIgnore]
	private static StringBuilder Sb = new StringBuilder(256);

	// Token: 0x02009542 RID: 38210
	[NullableContext(0)]
	public enum ELogType
	{
		// Token: 0x040315CA RID: 202186
		Info,
		// Token: 0x040315CB RID: 202187
		Debug,
		// Token: 0x040315CC RID: 202188
		Warn,
		// Token: 0x040315CD RID: 202189
		Error
	}

	// Token: 0x02009543 RID: 38211
	[NullableContext(0)]
	public enum EDebugModule
	{
		// Token: 0x040315CF RID: 202191
		Notify,
		// Token: 0x040315D0 RID: 202192
		Request,
		// Token: 0x040315D1 RID: 202193
		Ai,
		// Token: 0x040315D2 RID: 202194
		Buff,
		// Token: 0x040315D3 RID: 202195
		Cue,
		// Token: 0x040315D4 RID: 202196
		Skill,
		// Token: 0x040315D5 RID: 202197
		Hit,
		// Token: 0x040315D6 RID: 202198
		Control,
		// Token: 0x040315D7 RID: 202199
		Animation,
		// Token: 0x040315D8 RID: 202200
		Caught,
		// Token: 0x040315D9 RID: 202201
		Message,
		// Token: 0x040315DA RID: 202202
		LogicState,
		// Token: 0x040315DB RID: 202203
		Move,
		// Token: 0x040315DC RID: 202204
		StateMachine,
		// Token: 0x040315DD RID: 202205
		StateMachineNew,
		// Token: 0x040315DE RID: 202206
		Actor,
		// Token: 0x040315DF RID: 202207
		Material,
		// Token: 0x040315E0 RID: 202208
		Part,
		// Token: 0x040315E1 RID: 202209
		UnifiedState,
		// Token: 0x040315E2 RID: 202210
		BehaviorTree,
		// Token: 0x040315E3 RID: 202211
		FightState,
		// Token: 0x040315E4 RID: 202212
		Attribute,
		// Token: 0x040315E5 RID: 202213
		PassiveSkill,
		// Token: 0x040315E6 RID: 202214
		Bullet,
		// Token: 0x040315E7 RID: 202215
		BattleUi,
		// Token: 0x040315E8 RID: 202216
		Damage,
		// Token: 0x040315E9 RID: 202217
		Death,
		// Token: 0x040315EA RID: 202218
		LockOn,
		// Token: 0x040315EB RID: 202219
		Vehicle
	}
}
