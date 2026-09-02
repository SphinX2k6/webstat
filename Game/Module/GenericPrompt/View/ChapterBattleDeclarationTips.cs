using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CB0 RID: 23728
	public class ChapterBattleDeclarationTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE1B RID: 245275 RVA: 0x00F2D01C File Offset: 0x00F2B21C
		[NullableContext(1)]
		public ChapterBattleDeclarationTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE1C RID: 245276 RVA: 0x00F2D025 File Offset: 0x00F2B225
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUITexture)));
		}

		// Token: 0x0603BE1D RID: 245277 RVA: 0x00F2D048 File Offset: 0x00F2B248
		private void FetchCurrentChapterConf(int chapterId)
		{
			this.CurrentChapterConf = ConfigQuestChapterById.GetConfig(chapterId, true);
			if (this.CurrentChapterConf == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.JLY;
				string message = "策划的章节Id配错了！！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("错误的章节Id", chapterId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603BE1E RID: 245278 RVA: 0x00F2D09C File Offset: 0x00F2B29C
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			int chapterId = 0;
			if (param.Count > 0)
			{
				string text = param[0] as string;
				if (text != null)
				{
					int.TryParse(text, out chapterId);
				}
				object obj = param[0];
				if (obj is int)
				{
					int num = (int)obj;
					chapterId = num;
				}
			}
			this.FetchCurrentChapterConf(chapterId);
			if (this.CurrentChapterConf != null)
			{
				base.SetTextureByPath(this.CurrentChapterConf.Value.ChapterIcon, base.GetTexture(2), null, null);
			}
		}

		// Token: 0x04021AA7 RID: 137895
		private QuestChapter? CurrentChapterConf;

		// Token: 0x0200BD40 RID: 48448
		private class EChapterBattleDeclarationTips
		{
			// Token: 0x0403A518 RID: 238872
			public const int ChapterIcon = 2;
		}
	}
}
