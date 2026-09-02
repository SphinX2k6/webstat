using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B83 RID: 27523
	public class LevelEventCompleteGuide : LevelEventBase
	{
		// Token: 0x06043F24 RID: 278308 RVA: 0x01199CA0 File Offset: 0x01197EA0
		public LevelEventCompleteGuide(int id) : base(id)
		{
		}

		// Token: 0x06043F25 RID: 278309 RVA: 0x01199CAC File Offset: 0x01197EAC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, [Nullable(2)] GeneralContext context = null, int? actionId = null)
		{
			CompleteGuide completeGuide = inParams as CompleteGuide;
			if (completeGuide == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "行为缺少参数";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionIndex", this.ActionIndex);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			this.FinishGuide(completeGuide.GuideId);
		}

		// Token: 0x06043F26 RID: 278310 RVA: 0x01199D0C File Offset: 0x01197F0C
		private void FinishGuide(int groupId)
		{
			if (!ControllerBase<GuideController>.Instance.TryFinishGuide(groupId))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "行为完成的引导组执行完毕 [执行前已经完成]";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", groupId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(true, false, true);
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TZJ;
			string message2 = "行为完成的引导组执行完毕 [成功完成]";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("组Id", groupId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.GuideGroupId = groupId;
			Singleton<EventSystem>.Instance.Add(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideFinish));
			Singleton<EventSystem>.Instance.Add(EEventName.GuideGroupBreak, new Action<int>(this.OnGuideFinish));
			Singleton<EventSystem>.Instance.Add(EEventName.GuideGroupRest, new Action<int>(this.OnGuideFinish));
		}

		// Token: 0x06043F27 RID: 278311 RVA: 0x01199DE4 File Offset: 0x01197FE4
		private void OnGuideFinish(int groupId)
		{
			if (groupId != this.GuideGroupId)
			{
				return;
			}
			this.GuideGroupId = 0;
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideFinish));
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupBreak, new Action<int>(this.OnGuideFinish));
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupRest, new Action<int>(this.OnGuideFinish));
			base.FinishExecute(true, false, true);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "行为完成的引导组执行完毕[成功完成]";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", groupId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x04025FF8 RID: 155640
		private int GuideGroupId;
	}
}
