using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E2E RID: 20014
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelNamePanel : UiPanelBase
	{
		// Token: 0x06033BCD RID: 211917 RVA: 0x00CEEFB8 File Offset: 0x00CED1B8
		public UniTask Init(UUIItem item)
		{
			TrapDefenseLevelNamePanel.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseLevelNamePanel.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033BCE RID: 211918 RVA: 0x00CEF003 File Offset: 0x00CED203
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033BCF RID: 211919 RVA: 0x00CEF008 File Offset: 0x00CED208
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033BD0 RID: 211920 RVA: 0x00CEF118 File Offset: 0x00CED318
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelNamePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelNamePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BD1 RID: 211921 RVA: 0x00CEF15B File Offset: 0x00CED35B
		protected override void OnStart()
		{
		}

		// Token: 0x06033BD2 RID: 211922 RVA: 0x00CEF15D File Offset: 0x00CED35D
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033BD3 RID: 211923 RVA: 0x00CEF15F File Offset: 0x00CED35F
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033BD4 RID: 211924 RVA: 0x00CEF164 File Offset: 0x00CED364
		public void UpdateData(TrapDefenseLevelData data)
		{
			this.LevelData = data;
			string positionFormat = data.GetPositionFormat(2);
			UUIArtText artText = base.GetArtText(3);
			if (artText != null)
			{
				artText.SetText(positionFormat);
			}
			UUIArtText artText2 = base.GetArtText(5);
			if (artText2 != null)
			{
				artText2.SetText(positionFormat);
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(data.Config.Name);
			}
			this.UpdateBg();
		}

		// Token: 0x06033BD5 RID: 211925 RVA: 0x00CEF1CC File Offset: 0x00CED3CC
		private void UpdateBg()
		{
			ITrapDefenseDifficultyLevelInfo difficultyUiInfo = this.LevelData.GetDifficultyUiInfo();
			UUITexture texture = base.GetTexture(0);
			UUITexture texture2 = base.GetTexture(1);
			UUISprite sprite = base.GetSprite(2);
			UUIItem artText = base.GetArtText(5);
			UUITexture texture3 = base.GetTexture(6);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(difficultyUiInfo.BgKey);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(difficultyUiInfo.BgLightKey);
			string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(difficultyUiInfo.BgTitleKey);
			artText.SetColor(FColor.FromHex(difficultyUiInfo.ArtTextShadowColor));
			texture3.SetColor(FColor.FromHex(difficultyUiInfo.BgFlowerColor));
			base.SetTextureByPath(resourcePath, texture, null, null);
			base.SetTextureByPath(resourcePath2, texture2, null, null);
			this.SetSpriteByPath(resourcePath3, sprite, false, null, null);
		}

		// Token: 0x0401DF34 RID: 122676
		public TrapDefenseLevelData LevelData;

		// Token: 0x0200ADAC RID: 44460
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035EEB RID: 220907
			public const int TextureBg = 0;

			// Token: 0x04035EEC RID: 220908
			public const int TextureBgLight = 1;

			// Token: 0x04035EED RID: 220909
			public const int SpriteBgTitle = 2;

			// Token: 0x04035EEE RID: 220910
			public const int ArtTextPosition = 3;

			// Token: 0x04035EEF RID: 220911
			public const int TextTitle = 4;

			// Token: 0x04035EF0 RID: 220912
			public const int ArtTextPositionShadow = 5;

			// Token: 0x04035EF1 RID: 220913
			public const int TextureBgFlower = 6;
		}
	}
}
