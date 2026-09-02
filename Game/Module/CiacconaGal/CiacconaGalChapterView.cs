using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED3 RID: 24275
	[NullableContext(2)]
	[Nullable(0)]
	public class CiacconaGalChapterView : UiViewBase
	{
		// Token: 0x0603D007 RID: 249863 RVA: 0x00F7E624 File Offset: 0x00F7C824
		[NullableContext(1)]
		public CiacconaGalChapterView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D008 RID: 249864 RVA: 0x00F7E630 File Offset: 0x00F7C830
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D009 RID: 249865 RVA: 0x00F7E6FC File Offset: 0x00F7C8FC
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalChapterView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalChapterView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D00A RID: 249866 RVA: 0x00F7E740 File Offset: 0x00F7C940
		private void OnResultOrInitPanelBtnClick()
		{
			if (!this.ChapterData.IsFinished)
			{
				ControllerBase<CiacconaGalController>.Instance.OpenGalViewByChapterId(this.ChapterData.Id, new EUiViewName?(EUiViewName.CiacconaGalChapterView));
				return;
			}
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x040223BF RID: 140223
		private CiacconaGalChapterData ChapterData;

		// Token: 0x040223C0 RID: 140224
		private CiacconaGalChapterResultOrInitPanel ResultOrInitPanel;

		// Token: 0x040223C1 RID: 140225
		private CiacconaGalChapterRestartPanel RestartPanel;

		// Token: 0x040223C2 RID: 140226
		private PopupCaptionItem Caption;

		// Token: 0x040223C3 RID: 140227
		private CiacconaTitleInspirationItem CiacconaTitleItem;

		// Token: 0x040223C4 RID: 140228
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BECE RID: 48846
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB9D RID: 240541
			public const int BtnMask = 0;

			// Token: 0x0403AB9E RID: 240542
			public const int ItemCaption = 1;

			// Token: 0x0403AB9F RID: 240543
			public const int TextureChapterBg = 2;

			// Token: 0x0403ABA0 RID: 240544
			public const int ItemResultOrInitPanel = 3;

			// Token: 0x0403ABA1 RID: 240545
			public const int ItemRestartPanel = 4;
		}
	}
}
