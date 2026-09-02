using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapNote
{
	// Token: 0x02004B7A RID: 19322
	public class WorldMapNotePanel : WorldMapSecondaryUi
	{
		// Token: 0x06032784 RID: 206724 RVA: 0x00CA072D File Offset: 0x00C9E92D
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiView_MapPopupTrack";
		}

		// Token: 0x06032785 RID: 206725 RVA: 0x00CA0734 File Offset: 0x00C9E934
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032786 RID: 206726 RVA: 0x00CA07C0 File Offset: 0x00C9E9C0
		protected override void OnStart()
		{
			this.PopupCaption = new PopupCaptionItem(base.GetItem(0));
			PopupCaptionItem popupCaption = this.PopupCaption;
			if (popupCaption != null)
			{
				popupCaption.SetCloseCallBack(new Action(base.Close));
			}
			this.NoteLayout = new GenericLayout<WorldMapNoteItemNew, WorldMapNoteItemData>(base.GetVerticalLayout(1), () => new WorldMapNoteItemNew(), null, false, true);
		}

		// Token: 0x06032787 RID: 206727 RVA: 0x00CA0830 File Offset: 0x00C9EA30
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				List<IMapNoteParams> list = param[0] as List<IMapNoteParams>;
				if (list != null)
				{
					List<WorldMapNoteItemData> list2 = new List<WorldMapNoteItemData>();
					foreach (IMapNoteParams mapNoteParams in list)
					{
						MapNote? config = ConfigMapNoteById.GetConfig((int)mapNoteParams.MapNoteId, true);
						if (config != null)
						{
							list2.Add(new WorldMapNoteItemData
							{
								Id = mapNoteParams.MapMarkId.GetValueOrDefault(),
								IconRes = (config.Value.Icon ?? ""),
								DescId = (config.Value.Desc ?? ""),
								NoteStyle = (EMapNoteStyle)config.Value.Style,
								ClickCallback = mapNoteParams.ClickCallBack,
								CustomDesc = mapNoteParams.CustomDesc
							});
						}
					}
					GenericLayout<WorldMapNoteItemNew, WorldMapNoteItemData> noteLayout = this.NoteLayout;
					if (noteLayout == null)
					{
						return;
					}
					noteLayout.RefreshByData(list2, null, true);
				}
			}
		}

		// Token: 0x06032788 RID: 206728 RVA: 0x00CA0954 File Offset: 0x00C9EB54
		protected override void OnCloseWorldMapSecondaryUi()
		{
		}

		// Token: 0x06032789 RID: 206729 RVA: 0x00CA0956 File Offset: 0x00C9EB56
		protected override void OnBeforeDestroy()
		{
			this.PopupCaption = null;
			this.NoteLayout = null;
		}

		// Token: 0x0603278A RID: 206730 RVA: 0x00CA0966 File Offset: 0x00C9EB66
		protected override bool GetNeedBgItem()
		{
			return false;
		}

		// Token: 0x0401D727 RID: 120615
		[Nullable(2)]
		private PopupCaptionItem PopupCaption;

		// Token: 0x0401D728 RID: 120616
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WorldMapNoteItemNew, WorldMapNoteItemData> NoteLayout;

		// Token: 0x0200AC40 RID: 44096
		public static class EChildType
		{
			// Token: 0x0403590E RID: 219406
			public const int ItemCaption = 0;

			// Token: 0x0403590F RID: 219407
			public const int VerticalLayoutNote = 1;

			// Token: 0x04035910 RID: 219408
			public const int ItemNote = 2;
		}
	}
}
