using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005ED1 RID: 24273
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CiacconaGalChapterSubEndingItem : GridProxyAbstract<CiacconaGalSubEndingData>
	{
		// Token: 0x0603CFF8 RID: 249848 RVA: 0x00F7E004 File Offset: 0x00F7C204
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CFF9 RID: 249849 RVA: 0x00F7E0F4 File Offset: 0x00F7C2F4
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalChapterSubEndingItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalChapterSubEndingItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CFFA RID: 249850 RVA: 0x00F7E138 File Offset: 0x00F7C338
		[NullableContext(1)]
		public override void Refresh(CiacconaGalSubEndingData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetSprite(1).SetUIActive(this.Data.IsFinished);
			base.GetSprite(5).SetUIActive(this.Data.IsRewarded);
			this.BtnReward.SetActive(this.Data.IsFinished && !this.Data.IsRewarded);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningLockBg");
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_PlotReasoningFinishMain");
			if (!this.Data.IsFinished)
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningLockBg");
			}
			else if (this.Data.Type == ECiacconaGalSubEndingType.Main)
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningFinishMainBg");
				resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_PlotReasoningFinishMain");
			}
			else if (this.Data.Type == ECiacconaGalSubEndingType.Side)
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_PlotReasoningFinishBranchBg");
				resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_PlotReasoningFinishBranch");
			}
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			this.SetSpriteByPath(resourcePath2, base.GetSprite(1), false, null, null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(this.Data.IsFinished);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetUIActive(this.Data.IsFinished);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.Data.Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.Desc, Array.Empty<object>());
		}

		// Token: 0x0603CFFB RID: 249851 RVA: 0x00F7E2F0 File Offset: 0x00F7C4F0
		private void OnBtnRewardClick()
		{
			CiacconaGalChapterData chapterDataBySubEndingId = ModelBase<CiacconaGalModel>.Instance.GetChapterDataBySubEndingId(this.Data.Id);
			if (chapterDataBySubEndingId != null)
			{
				int id = ModelBase<CiacconaGalModel>.Instance.ActivityData.Id;
				ControllerBase<CiacconaGalController>.Instance.RequestGetSubEndingReward(id, chapterDataBySubEndingId.Id, this.Data.Id);
			}
		}

		// Token: 0x040223B9 RID: 140217
		private CiacconaGalSubEndingData Data;

		// Token: 0x040223BA RID: 140218
		private ButtonSpriteItem BtnReward;

		// Token: 0x0200BECB RID: 48843
		[NullableContext(0)]
		private class ESubEndingItemComponentDefine
		{
			// Token: 0x0403AB8E RID: 240526
			public const int TextureBg = 0;

			// Token: 0x0403AB8F RID: 240527
			public const int SpriteIcon = 1;

			// Token: 0x0403AB90 RID: 240528
			public const int TextTitle = 2;

			// Token: 0x0403AB91 RID: 240529
			public const int TextDesc = 3;

			// Token: 0x0403AB92 RID: 240530
			public const int ItemBtnReward = 4;

			// Token: 0x0403AB93 RID: 240531
			public const int SpriteFinished = 5;
		}
	}
}
