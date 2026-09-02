using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.QuestNew.Model;

namespace CSharpScript.Game.Module.RecallQuest.Model
{
	// Token: 0x02005298 RID: 21144
	[NullableContext(2)]
	[Nullable(0)]
	public class RecallQuestTrackProxy : IQuestTrackSlot
	{
		// Token: 0x060360E9 RID: 221417 RVA: 0x00D9BDFC File Offset: 0x00D99FFC
		public global::Quest GetTrack()
		{
			return this.RecallTrackQuest;
		}

		// Token: 0x060360EA RID: 221418 RVA: 0x00D9BE04 File Offset: 0x00D9A004
		public void SetTrack(global::Quest quest)
		{
			this.RecallTrackQuest = quest;
		}

		// Token: 0x060360EB RID: 221419 RVA: 0x00D9BE10 File Offset: 0x00D9A010
		[NullableContext(1)]
		public unsafe bool Accept(global::Quest quest)
		{
			if (quest.Type != EQuest.Recall)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "[Recall] 拒收非 Recall 任务的追踪请求";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("任务Id", quest.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Type", quest.Type);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			return true;
		}

		// Token: 0x0401F10E RID: 127246
		private global::Quest RecallTrackQuest;
	}
}
