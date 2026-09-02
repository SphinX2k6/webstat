using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004514 RID: 17684
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixSequencePlayer
	{
		// Token: 0x0602E97D RID: 190845 RVA: 0x00B0A362 File Offset: 0x00B08562
		public HotFixSequencePlayer(UUIItem uiItem)
		{
			this.UiItem = uiItem;
			this.UiBaseActor = (uiItem.GetOwner() as AUIBaseActor);
		}

		// Token: 0x0602E97E RID: 190846 RVA: 0x00B0A390 File Offset: 0x00B08590
		[return: Nullable(2)]
		private USequencePlayContext GetSequencePlayContext(string sequenceName)
		{
			USequencePlayContext sequencePlayContextOfKey;
			if (!this.PlayContextMap.TryGetValue(sequenceName, out sequencePlayContextOfKey))
			{
				sequencePlayContextOfKey = this.UiBaseActor.GetSequencePlayContextOfKey(sequenceName);
				if (sequencePlayContextOfKey == null)
				{
					return null;
				}
				sequencePlayContextOfKey.bIsAsync = false;
				this.PlayContextMap[sequenceName] = sequencePlayContextOfKey;
			}
			return sequencePlayContextOfKey;
		}

		// Token: 0x0602E97F RID: 190847 RVA: 0x00B0A3D4 File Offset: 0x00B085D4
		public bool PlaySequence(string sequenceName, [Nullable(2)] Action finishCallback = null)
		{
			USequencePlayContext playContext = this.GetSequencePlayContext(sequenceName);
			if (playContext == null)
			{
				Singleton<LauncherLog>.Instance.Warn("关卡序列不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action finishCallback2 = finishCallback;
				if (finishCallback2 != null)
				{
					finishCallback2();
				}
				return false;
			}
			playContext.OnFinish.Bind(delegate()
			{
				playContext.OnFinish.Unbind();
				Action finishCallback3 = finishCallback;
				if (finishCallback3 == null)
				{
					return;
				}
				finishCallback3();
			});
			playContext.ExecutePlay();
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "播放关卡序列";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SequenceName", sequenceName);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}

		// Token: 0x0602E980 RID: 190848 RVA: 0x00B0A47C File Offset: 0x00B0867C
		public bool StopSequence(string sequenceName, bool toLastFrame = false, [Nullable(2)] Action stopCallback = null)
		{
			if (this.UiItem.LevelSequences.GetValueOrDefault(sequenceName) == null)
			{
				return false;
			}
			ALevelSequenceActor sequencePlayerByKey = this.UiBaseActor.GetSequencePlayerByKey(sequenceName);
			if (sequencePlayerByKey == null)
			{
				return false;
			}
			USequencePlayContext usequencePlayContext;
			if (!this.PlayContextMap.TryGetValue(sequenceName, out usequencePlayContext))
			{
				return false;
			}
			if (toLastFrame)
			{
				AUIBaseActor uiBaseActor = this.UiBaseActor;
				FFrameTime time = sequencePlayerByKey.SequencePlayer.GetDuration().Time;
				uiBaseActor.SequenceJumpToSecondByKey(sequenceName, time);
			}
			usequencePlayContext.TryStop();
			if (stopCallback != null)
			{
				stopCallback();
			}
			return true;
		}

		// Token: 0x0602E981 RID: 190849 RVA: 0x00B0A4FA File Offset: 0x00B086FA
		public void ClearSequence()
		{
			this.PlayContextMap.Clear();
			this.UiBaseActor.ClearAllSequence();
			this.UiBaseActor = null;
			this.UiItem = null;
		}

		// Token: 0x0401A77C RID: 108412
		[Nullable(2)]
		private AUIBaseActor UiBaseActor;

		// Token: 0x0401A77D RID: 108413
		[Nullable(2)]
		private UUIItem UiItem;

		// Token: 0x0401A77E RID: 108414
		private readonly Dictionary<string, USequencePlayContext> PlayContextMap = new Dictionary<string, USequencePlayContext>();
	}
}
