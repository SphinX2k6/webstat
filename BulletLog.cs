using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;

// Token: 0x02002DD5 RID: 11733
[NullableContext(2)]
[Nullable(0)]
public class BulletLog
{
	// Token: 0x06017A56 RID: 96854 RVA: 0x0069857B File Offset: 0x0069677B
	public static void Debug(bool gasDebug, ELogAuthor author, Entity owner, [Nullable(1)] string message, BulletInfo bulletInfo, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		BulletLog.LogImpl(gasDebug, ELogLevel.Debug, author, owner, message, bulletInfo, pairs);
	}

	// Token: 0x06017A57 RID: 96855 RVA: 0x0069858B File Offset: 0x0069678B
	public static void Info(bool gasDebug, ELogAuthor author, Entity owner, [Nullable(1)] string message, BulletInfo bulletInfo, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		BulletLog.LogImpl(gasDebug, ELogLevel.Info, author, owner, message, bulletInfo, pairs);
	}

	// Token: 0x06017A58 RID: 96856 RVA: 0x0069859B File Offset: 0x0069679B
	public static void Warn(bool gasDebug, ELogAuthor author, Entity owner, [Nullable(1)] string message, BulletInfo bulletInfo, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		BulletLog.LogImpl(gasDebug, ELogLevel.Warn, author, owner, message, bulletInfo, pairs);
	}

	// Token: 0x06017A59 RID: 96857 RVA: 0x006985AB File Offset: 0x006967AB
	public static void Error(bool gasDebug, ELogAuthor author, Entity owner, [Nullable(1)] string message, BulletInfo bulletInfo, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		BulletLog.LogImpl(gasDebug, ELogLevel.Error, author, owner, message, bulletInfo, pairs);
	}

	// Token: 0x06017A5A RID: 96858 RVA: 0x006985BC File Offset: 0x006967BC
	private static void LogImpl(bool gasDebug, ELogLevel logLevel, ELogAuthor author, Entity owner, [Nullable(1)] string message, BulletInfo bulletInfo, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		if (bulletInfo != null)
		{
			int bulletEntityId = bulletInfo.BulletEntityId;
			ActiveBulletHandle bulletHandleById = ModelBase<BulletModel>.Instance.GetBulletHandleById(bulletEntityId);
			ReadOnlySpan<ValueTuple<string, object>> readOnlySpan = pairs;
			int num = 0;
			ValueTuple<string, object>[] array = new ValueTuple<string, object>[5 + readOnlySpan.Length];
			readOnlySpan.CopyTo(new Span<ValueTuple<string, object>>(array).Slice(num, readOnlySpan.Length));
			num += readOnlySpan.Length;
			array[num] = new ValueTuple<string, object>("子弹表ID", bulletInfo.BulletRowName);
			num++;
			array[num] = new ValueTuple<string, object>("子弹实体ID", bulletEntityId);
			num++;
			ValueTuple<string, object>[] array2 = array;
			int num2 = num;
			string item = "发射者实体ID";
			CreatureDataComponent attackerCreatureDataComp = bulletInfo.AttackerCreatureDataComp;
			array2[num2] = new ValueTuple<string, object>(item, (attackerCreatureDataComp != null) ? new long?(attackerCreatureDataComp.GetCreatureDataId()) : null);
			num++;
			ValueTuple<string, object>[] array3 = array;
			int num3 = num;
			string item2 = "发射者名称";
			BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
			array3[num3] = new ValueTuple<string, object>(item2, (attackerActorComp != null) ? attackerActorComp.Owner : null);
			num++;
			ValueTuple<string, object>[] array4 = array;
			int num4 = num;
			string item3 = "子弹服务器ID";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int?>((bulletHandleById != null) ? new int?(bulletHandleById.PlayerId) : null);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<int?>((bulletHandleById != null) ? new int?(bulletHandleById.HandleId) : null);
			array4[num4] = new ValueTuple<string, object>(item3, defaultInterpolatedStringHandler.ToStringAndClear());
			ReadOnlySpan<ValueTuple<string, object>> pairs2 = new ReadOnlySpan<ValueTuple<string, object>>(array);
			if (gasDebug && owner != null && Singleton<CSharpScript.Core.Common.Info>.Instance.IsPlayInEditor)
			{
				CharacterGasDebugComponent component = owner.GetComponent<CharacterGasDebugComponent>();
				if (component != null && component.Valid)
				{
					component.AddBulletDebugLogString(message, pairs2);
				}
			}
			Singleton<Log>.Instance.LogWithLevel(logLevel, ELogModule.Bullet, author, message, pairs2);
			return;
		}
		if (gasDebug && owner != null && Singleton<CSharpScript.Core.Common.Info>.Instance.IsPlayInEditor)
		{
			CharacterGasDebugComponent component2 = owner.GetComponent<CharacterGasDebugComponent>();
			if (component2 != null && component2.Valid)
			{
				component2.AddBulletDebugLogString(message, pairs);
			}
		}
		Singleton<Log>.Instance.LogWithLevel(logLevel, ELogModule.Bullet, author, message, pairs);
	}
}
