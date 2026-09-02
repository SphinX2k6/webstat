using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057DF RID: 22495
	[NullableContext(1)]
	[Nullable(0)]
	public class MechanismUtils
	{
		// Token: 0x0603928C RID: 234124 RVA: 0x00E7DB11 File Offset: 0x00E7BD11
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public static List<IEventData> GetAllAnimNotifyEvents(ULevelSequence sequence)
		{
			return MechanismUtils.GetAllEvents(sequence, false);
		}

		// Token: 0x0603928D RID: 234125 RVA: 0x00E7DB1A File Offset: 0x00E7BD1A
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public static List<IEventData> GetAllAnimNotifyStateEvents(ULevelSequence sequence)
		{
			return MechanismUtils.GetAllEvents(sequence, true);
		}

		// Token: 0x0603928E RID: 234126 RVA: 0x00E7DB24 File Offset: 0x00E7BD24
		public static void GetAllAnimNotifyEventsByPath(string sequencePath, [Nullable(new byte[]
		{
			1,
			2,
			1
		})] Action<List<IEventData>> callback)
		{
			MechanismUtils.LoadSequenceAsset(sequencePath).ContinueWith(delegate(ULevelSequence sequence)
			{
				if (sequence != null)
				{
					List<IEventData> allAnimNotifyEvents = MechanismUtils.GetAllAnimNotifyEvents(sequence);
					callback(allAnimNotifyEvents);
				}
			});
		}

		// Token: 0x0603928F RID: 234127 RVA: 0x00E7DB58 File Offset: 0x00E7BD58
		public static void GetAllAnimNotifyStateEventsByPath(string sequencePath, [Nullable(new byte[]
		{
			1,
			2,
			1
		})] Action<List<IEventData>> callback)
		{
			MechanismUtils.LoadSequenceAsset(sequencePath).ContinueWith(delegate(ULevelSequence sequence)
			{
				if (sequence != null)
				{
					List<IEventData> allAnimNotifyStateEvents = MechanismUtils.GetAllAnimNotifyStateEvents(sequence);
					callback(allAnimNotifyStateEvents);
				}
			});
		}

		// Token: 0x06039290 RID: 234128 RVA: 0x00E7DB8C File Offset: 0x00E7BD8C
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<ULevelSequence> LoadSequenceAsset(string sequencePath)
		{
			MechanismUtils.<LoadSequenceAsset>d__4 <LoadSequenceAsset>d__;
			<LoadSequenceAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder<ULevelSequence>.Create();
			<LoadSequenceAsset>d__.sequencePath = sequencePath;
			<LoadSequenceAsset>d__.<>1__state = -1;
			<LoadSequenceAsset>d__.<>t__builder.Start<MechanismUtils.<LoadSequenceAsset>d__4>(ref <LoadSequenceAsset>d__);
			return <LoadSequenceAsset>d__.<>t__builder.Task;
		}

		// Token: 0x06039291 RID: 234129 RVA: 0x00E7DBCF File Offset: 0x00E7BDCF
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private static List<IEventData> GetAllEvents(ULevelSequence sequence, bool bAns)
		{
			return null;
		}
	}
}
