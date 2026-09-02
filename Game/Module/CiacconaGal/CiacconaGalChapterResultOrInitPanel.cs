using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED2 RID: 24274
	[NullableContext(1)]
	[Nullable(0)]
	public class CiacconaGalChapterResultOrInitPanel : UiPanelBase
	{
		// Token: 0x0603CFFD RID: 249853 RVA: 0x00F7E34B File Offset: 0x00F7C54B
		public CiacconaGalChapterResultOrInitPanel(CiacconaGalChapterData chapterData, Action onConfirm)
		{
			this.ChapterData = chapterData;
			this.OnConfirm = onConfirm;
		}

		// Token: 0x0603CFFE RID: 249854 RVA: 0x00F7E364 File Offset: 0x00F7C564
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CFFF RID: 249855 RVA: 0x00F7E430 File Offset: 0x00F7C630
		protected override void OnStart()
		{
			this.LayoutResults = new GenericLayout<CiacconaGalChapterSubEndingItem, CiacconaGalSubEndingData>(base.GetVerticalLayout(2), new Func<CiacconaGalChapterSubEndingItem>(this.GetResultItem), null, false, true);
			this.RefreshCommon();
			this.RefreshResults();
			this.RefreshBtn();
			if (this.ChapterData.IsFinished)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaChapterRestart);
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaChapterFirstStart);
		}

		// Token: 0x0603D000 RID: 249856 RVA: 0x00F7E49E File Offset: 0x00F7C69E
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaChapterDataUpdate, new Action(this.OnChapterDataUpdate));
		}

		// Token: 0x0603D001 RID: 249857 RVA: 0x00F7E4BC File Offset: 0x00F7C6BC
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaChapterDataUpdate, new Action(this.OnChapterDataUpdate));
		}

		// Token: 0x0603D002 RID: 249858 RVA: 0x00F7E4DC File Offset: 0x00F7C6DC
		private void RefreshCommon()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.ChapterData.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), this.ChapterData.Desc, Array.Empty<object>());
		}

		// Token: 0x0603D003 RID: 249859 RVA: 0x00F7E52C File Offset: 0x00F7C72C
		private void RefreshResults()
		{
			base.GetVerticalLayout(2).SetActive(this.ChapterData.IsFinished, false);
			if (this.ChapterData.IsFinished)
			{
				List<CiacconaGalSubEndingData> list = new List<CiacconaGalSubEndingData>();
				foreach (int id in this.ChapterData.SubEndingIds)
				{
					CiacconaGalSubEndingData subEndingDataById = ModelBase<CiacconaGalModel>.Instance.GetSubEndingDataById(id);
					if (subEndingDataById != null)
					{
						list.Add(subEndingDataById);
					}
				}
				this.LayoutResults.RefreshByData(list, null, false);
			}
		}

		// Token: 0x0603D004 RID: 249860 RVA: 0x00F7E5AC File Offset: 0x00F7C7AC
		private void RefreshBtn()
		{
			this.ConfirmBtn = new ButtonAndTextItem(base.GetItem(4));
			if (this.ChapterData.IsFinished)
			{
				this.ConfirmBtn.RefreshTextNew("Xkjsx_Chapter_Replay", Array.Empty<object>());
			}
			else
			{
				this.ConfirmBtn.RefreshTextNew("Xkjsx_Chapter_First", Array.Empty<object>());
			}
			this.ConfirmBtn.BindCallback(this.OnConfirm);
		}

		// Token: 0x0603D005 RID: 249861 RVA: 0x00F7E615 File Offset: 0x00F7C815
		private CiacconaGalChapterSubEndingItem GetResultItem()
		{
			return new CiacconaGalChapterSubEndingItem();
		}

		// Token: 0x0603D006 RID: 249862 RVA: 0x00F7E61C File Offset: 0x00F7C81C
		private void OnChapterDataUpdate()
		{
			this.RefreshResults();
		}

		// Token: 0x040223BB RID: 140219
		[Nullable(2)]
		private ButtonAndTextItem ConfirmBtn;

		// Token: 0x040223BC RID: 140220
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CiacconaGalChapterSubEndingItem, CiacconaGalSubEndingData> LayoutResults;

		// Token: 0x040223BD RID: 140221
		private CiacconaGalChapterData ChapterData;

		// Token: 0x040223BE RID: 140222
		private Action OnConfirm;

		// Token: 0x0200BECD RID: 48845
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB98 RID: 240536
			public const int TextTitle = 0;

			// Token: 0x0403AB99 RID: 240537
			public const int TextDesc = 1;

			// Token: 0x0403AB9A RID: 240538
			public const int LayoutResults = 2;

			// Token: 0x0403AB9B RID: 240539
			public const int ItemResult = 3;

			// Token: 0x0403AB9C RID: 240540
			public const int BtnConfirm = 4;
		}
	}
}
