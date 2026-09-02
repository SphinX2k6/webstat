using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ECA RID: 24266
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalChapterEntryItem : GridProxyAbstract<CiacconaGalChapterSlotData>
	{
		// Token: 0x0603CFD0 RID: 249808 RVA: 0x00F7D5F8 File Offset: 0x00F7B7F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CFD1 RID: 249809 RVA: 0x00F7D764 File Offset: 0x00F7B964
		protected override void OnStart()
		{
			this.LayoutIcon = new GenericLayout<CiacconaSubEndingIcon, CiacconaGalSubEndingData>(base.GetHorizontalLayout(5), new Func<CiacconaSubEndingIcon>(this.GetEndingItem), null, false, true);
		}

		// Token: 0x0603CFD2 RID: 249810 RVA: 0x00F7D788 File Offset: 0x00F7B988
		public override void Refresh(CiacconaGalChapterSlotData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			CiacconaGalChapterData chapterDataById = ModelBase<CiacconaGalModel>.Instance.GetChapterDataById(data.ChapterId);
			base.GetSprite(1).SetUIActive(!chapterDataById.IsUnlocked);
			string path = chapterDataById.IsUnlocked ? data.SlotImagePath : data.SlotLockImagePath;
			base.SetTextureByPath(path, base.GetTexture(0), null, null);
			this.SetSpriteByPath(data.RomanNumberIconPath, base.GetSprite(3), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), chapterDataById.Title, Array.Empty<object>());
			List<CiacconaGalSubEndingData> data2 = (from subEndingId in chapterDataById.SubEndingIds
			select ModelBase<CiacconaGalModel>.Instance.GetSubEndingDataById(subEndingId)).ToList<CiacconaGalSubEndingData>();
			this.LayoutIcon.RefreshByData(data2, null, false);
			base.GetItem(7).SetUIActive(ModelBase<CiacconaGalModel>.Instance.HasAnySubEndingRewardByChapterId(data.ChapterId));
		}

		// Token: 0x0603CFD3 RID: 249811 RVA: 0x00F7D888 File Offset: 0x00F7BA88
		private void OnClick(EToggleState toggleState)
		{
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			if (!ModelBase<CiacconaGalModel>.Instance.GetChapterDataById(this.Data.ChapterId).IsUnlocked)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RequirePreChapter", Array.Empty<object>());
				return;
			}
			ControllerBase<CiacconaGalController>.Instance.OpenChapterViewById(this.Data.ChapterId, null);
		}

		// Token: 0x0603CFD4 RID: 249812 RVA: 0x00F7D8F5 File Offset: 0x00F7BAF5
		private CiacconaSubEndingIcon GetEndingItem()
		{
			return new CiacconaSubEndingIcon();
		}

		// Token: 0x040223AB RID: 140203
		[Nullable(2)]
		private CiacconaGalChapterSlotData Data;

		// Token: 0x040223AC RID: 140204
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CiacconaSubEndingIcon, CiacconaGalSubEndingData> LayoutIcon;

		// Token: 0x0200BEC4 RID: 48836
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB73 RID: 240499
			public const int TextureChapterImage = 0;

			// Token: 0x0403AB74 RID: 240500
			public const int SpriteLock = 1;

			// Token: 0x0403AB75 RID: 240501
			public const int TextName = 2;

			// Token: 0x0403AB76 RID: 240502
			public const int SpriteRomanNumber = 3;

			// Token: 0x0403AB77 RID: 240503
			public const int TogSelf = 4;

			// Token: 0x0403AB78 RID: 240504
			public const int LayoutIcon = 5;

			// Token: 0x0403AB79 RID: 240505
			public const int ItemIcon = 6;

			// Token: 0x0403AB7A RID: 240506
			public const int ItemRedDot = 7;
		}
	}
}
