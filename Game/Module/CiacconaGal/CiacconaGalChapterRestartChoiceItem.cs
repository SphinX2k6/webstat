using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ECF RID: 24271
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalChapterRestartChoiceItem : GridProxyAbstract<ICiacconaGalChapterRestartChoiceParam>
	{
		// Token: 0x0603CFF0 RID: 249840 RVA: 0x00F7DCE8 File Offset: 0x00F7BEE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CFF1 RID: 249841 RVA: 0x00F7DDB0 File Offset: 0x00F7BFB0
		public override void Refresh(ICiacconaGalChapterRestartChoiceParam data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetSprite(1).SetUIActive(this.Data.Type == ECiacconaGalChapterRestartChoiceType.FromBranching);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.Data.Desc, Array.Empty<object>());
		}

		// Token: 0x0603CFF2 RID: 249842 RVA: 0x00F7DE00 File Offset: 0x00F7C000
		private void OnClick()
		{
			if (this.Data.Type == ECiacconaGalChapterRestartChoiceType.FromBranching)
			{
				ControllerBase<CiacconaGalController>.Instance.OpenGalViewByStepId(this.Data.ChapterData.BranchingStepId, new int?(this.Data.ChapterData.Id), new EUiViewName?(EUiViewName.CiacconaGalChapterView));
				return;
			}
			ControllerBase<CiacconaGalController>.Instance.OpenGalViewByChapterId(this.Data.ChapterData.Id, new EUiViewName?(EUiViewName.CiacconaGalChapterView));
		}

		// Token: 0x040223B6 RID: 140214
		private ICiacconaGalChapterRestartChoiceParam Data;

		// Token: 0x0200BEC9 RID: 48841
		[NullableContext(0)]
		private class EChoiceItemComponentDefine
		{
			// Token: 0x0403AB88 RID: 240520
			public const int BtnSelect = 0;

			// Token: 0x0403AB89 RID: 240521
			public const int SpriteRecommend = 1;

			// Token: 0x0403AB8A RID: 240522
			public const int TextDesc = 2;
		}
	}
}
