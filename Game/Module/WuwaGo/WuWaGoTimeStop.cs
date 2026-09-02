using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB8 RID: 19128
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoTimeStop : IStaticVariableResetter
	{
		// Token: 0x06031DDC RID: 204252 RVA: 0x00C7A6A6 File Offset: 0x00C788A6
		static WuWaGoTimeStop()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(WuWaGoTimeStop.CreateStaticDefaultValue), new Action(WuWaGoTimeStop.ResetStaticDefaultValue));
		}

		// Token: 0x17008516 RID: 34070
		// (get) Token: 0x06031DDD RID: 204253 RVA: 0x00C7A6C5 File Offset: 0x00C788C5
		public static bool IsPaused
		{
			get
			{
				return WuWaGoTimeStop.ActiveTokens.Count > 0;
			}
		}

		// Token: 0x06031DDE RID: 204254 RVA: 0x00C7A6D4 File Offset: 0x00C788D4
		public static void CreateStaticDefaultValue()
		{
			WuWaGoTimeStop.NextToken = 0;
			WuWaGoTimeStop.ActiveTokens = new Dictionary<int, string>();
			WuWaGoTimeStop.Participants = new HashSet<IWuWaGoTimeStopParticipant>();
		}

		// Token: 0x06031DDF RID: 204255 RVA: 0x00C7A6F0 File Offset: 0x00C788F0
		public static void ResetStaticDefaultValue()
		{
			WuWaGoTimeStop.NextToken = 0;
			WuWaGoTimeStop.ActiveTokens = null;
			WuWaGoTimeStop.Participants = null;
		}

		// Token: 0x06031DE0 RID: 204256 RVA: 0x00C7A704 File Offset: 0x00C78904
		public static int Begin(string reason)
		{
			int num = ++WuWaGoTimeStop.NextToken;
			WuWaGoTimeStop.ActiveTokens.Add(num, reason);
			if (WuWaGoTimeStop.ActiveTokens.Count == 1)
			{
				WuWaGoTimeStop.PauseAll();
			}
			return num;
		}

		// Token: 0x06031DE1 RID: 204257 RVA: 0x00C7A73E File Offset: 0x00C7893E
		public static void End(int token)
		{
			if (!WuWaGoTimeStop.ActiveTokens.Remove(token))
			{
				return;
			}
			if (!WuWaGoTimeStop.IsPaused)
			{
				WuWaGoTimeStop.ResumeAll();
			}
		}

		// Token: 0x06031DE2 RID: 204258 RVA: 0x00C7A75C File Offset: 0x00C7895C
		public static Action Register(IWuWaGoTimeStopParticipant participant, EWuWaGoTimeStopPolicy policy = EWuWaGoTimeStopPolicy.Pausable)
		{
			if (policy == EWuWaGoTimeStopPolicy.Ignore)
			{
				return delegate()
				{
				};
			}
			WuWaGoTimeStop.Participants.Add(participant);
			if (WuWaGoTimeStop.IsPaused)
			{
				WuWaGoTimeStop.PauseParticipant(participant);
			}
			bool registered = true;
			return delegate()
			{
				if (!registered)
				{
					return;
				}
				registered = false;
				WuWaGoTimeStop.Participants.Remove(participant);
			};
		}

		// Token: 0x06031DE3 RID: 204259 RVA: 0x00C7A7D0 File Offset: 0x00C789D0
		[NullableContext(0)]
		public static UniTask<EWuWaGoTimeStopWaitResult> Wait(int durationMs)
		{
			WuWaGoTimeStop.<Wait>d__11 <Wait>d__;
			<Wait>d__.<>t__builder = AsyncUniTaskMethodBuilder<EWuWaGoTimeStopWaitResult>.Create();
			<Wait>d__.durationMs = durationMs;
			<Wait>d__.<>1__state = -1;
			<Wait>d__.<>t__builder.Start<WuWaGoTimeStop.<Wait>d__11>(ref <Wait>d__);
			return <Wait>d__.<>t__builder.Task;
		}

		// Token: 0x06031DE4 RID: 204260 RVA: 0x00C7A814 File Offset: 0x00C78A14
		public static void CancelAll(string reason)
		{
			foreach (IWuWaGoTimeStopParticipant wuWaGoTimeStopParticipant in new List<IWuWaGoTimeStopParticipant>(WuWaGoTimeStop.Participants))
			{
				wuWaGoTimeStopParticipant.CancelByTimeStop(reason);
			}
			WuWaGoTimeStop.Participants.Clear();
			WuWaGoTimeStop.ActiveTokens.Clear();
		}

		// Token: 0x06031DE5 RID: 204261 RVA: 0x00C7A880 File Offset: 0x00C78A80
		public static void Clear()
		{
			WuWaGoTimeStop.CancelAll("WuWaGoTimeStop.Clear");
			WuWaGoTimeStop.NextToken = 0;
		}

		// Token: 0x06031DE6 RID: 204262 RVA: 0x00C7A892 File Offset: 0x00C78A92
		[NullableContext(2)]
		public static void PauseTimerHandle(TimerHandle handle)
		{
			if (handle == null || !handle.Valid() || handle.IsPause())
			{
				return;
			}
			handle.Pause();
		}

		// Token: 0x06031DE7 RID: 204263 RVA: 0x00C7A8B5 File Offset: 0x00C78AB5
		[NullableContext(2)]
		public static void ResumeTimerHandle(TimerHandle handle)
		{
			if (handle == null || !handle.Valid() || !handle.IsPause())
			{
				return;
			}
			handle.Resume();
		}

		// Token: 0x06031DE8 RID: 204264 RVA: 0x00C7A8D8 File Offset: 0x00C78AD8
		private static void PauseAll()
		{
			foreach (IWuWaGoTimeStopParticipant participant in WuWaGoTimeStop.Participants)
			{
				WuWaGoTimeStop.PauseParticipant(participant);
			}
		}

		// Token: 0x06031DE9 RID: 204265 RVA: 0x00C7A928 File Offset: 0x00C78B28
		private static void ResumeAll()
		{
			foreach (IWuWaGoTimeStopParticipant participant in WuWaGoTimeStop.Participants)
			{
				WuWaGoTimeStop.ResumeParticipant(participant);
			}
		}

		// Token: 0x06031DEA RID: 204266 RVA: 0x00C7A978 File Offset: 0x00C78B78
		private static void PauseParticipant(IWuWaGoTimeStopParticipant participant)
		{
			if (participant.PausedByTimeStop)
			{
				return;
			}
			participant.PausedByTimeStop = true;
			participant.PauseByTimeStop();
		}

		// Token: 0x06031DEB RID: 204267 RVA: 0x00C7A990 File Offset: 0x00C78B90
		private static void ResumeParticipant(IWuWaGoTimeStopParticipant participant)
		{
			if (!participant.PausedByTimeStop)
			{
				return;
			}
			participant.PausedByTimeStop = false;
			participant.ResumeByTimeStop();
		}

		// Token: 0x0401D30F RID: 119567
		private static int NextToken;

		// Token: 0x0401D310 RID: 119568
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<int, string> ActiveTokens;

		// Token: 0x0401D311 RID: 119569
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static HashSet<IWuWaGoTimeStopParticipant> Participants;
	}
}
