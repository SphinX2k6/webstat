using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED0 RID: 24272
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChapterRestartPanel : UiPanelBase
	{
		// Token: 0x0603CFF4 RID: 249844 RVA: 0x00F7DE81 File Offset: 0x00F7C081
		public CiacconaGalChapterRestartPanel(CiacconaGalChapterData chapterData)
		{
			this.ChapterData = chapterData;
		}

		// Token: 0x0603CFF5 RID: 249845 RVA: 0x00F7DE90 File Offset: 0x00F7C090
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CFF6 RID: 249846 RVA: 0x00F7DF1C File Offset: 0x00F7C11C
		protected unsafe override void OnStart()
		{
			this.Layout = new GenericLayout<CiacconaGalChapterRestartChoiceItem, ICiacconaGalChapterRestartChoiceParam>(base.GetVerticalLayout(1), new Func<CiacconaGalChapterRestartChoiceItem>(this.GetChoiceGrid), null, false, true);
			CiacconaGalChapterRestartChoiceParam ciacconaGalChapterRestartChoiceParam = new CiacconaGalChapterRestartChoiceParam
			{
				Type = ECiacconaGalChapterRestartChoiceType.FromBeginning,
				Desc = "Xkjsx_Chapter_Start",
				ChapterData = this.ChapterData
			};
			CiacconaGalChapterRestartChoiceParam ciacconaGalChapterRestartChoiceParam2 = new CiacconaGalChapterRestartChoiceParam
			{
				Type = ECiacconaGalChapterRestartChoiceType.FromBranching,
				Desc = "Xkjsx_Chapter_Begin",
				ChapterData = this.ChapterData
			};
			int num = 2;
			List<ICiacconaGalChapterRestartChoiceParam> list = new List<ICiacconaGalChapterRestartChoiceParam>(num);
			CollectionsMarshal.SetCount<ICiacconaGalChapterRestartChoiceParam>(list, num);
			Span<ICiacconaGalChapterRestartChoiceParam> span = CollectionsMarshal.AsSpan<ICiacconaGalChapterRestartChoiceParam>(list);
			int num2 = 0;
			*span[num2] = ciacconaGalChapterRestartChoiceParam2;
			num2++;
			*span[num2] = ciacconaGalChapterRestartChoiceParam;
			List<ICiacconaGalChapterRestartChoiceParam> data = list;
			this.Layout.RefreshByData(data, null, false);
			string textId = CiacconaGalTextConfig.GetTextId(1002);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x0603CFF7 RID: 249847 RVA: 0x00F7DFFC File Offset: 0x00F7C1FC
		private CiacconaGalChapterRestartChoiceItem GetChoiceGrid()
		{
			return new CiacconaGalChapterRestartChoiceItem();
		}

		// Token: 0x040223B7 RID: 140215
		private GenericLayout<CiacconaGalChapterRestartChoiceItem, ICiacconaGalChapterRestartChoiceParam> Layout;

		// Token: 0x040223B8 RID: 140216
		private CiacconaGalChapterData ChapterData;

		// Token: 0x0200BECA RID: 48842
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB8B RID: 240523
			public const int TextTitle = 0;

			// Token: 0x0403AB8C RID: 240524
			public const int LayoutChoices = 1;

			// Token: 0x0403AB8D RID: 240525
			public const int ItemChoice = 2;
		}
	}
}
