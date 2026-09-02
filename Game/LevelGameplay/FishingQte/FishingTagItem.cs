using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA4 RID: 28324
	public class FishingTagItem : UiPanelBase
	{
		// Token: 0x06044AE9 RID: 281321 RVA: 0x011DA210 File Offset: 0x011D8410
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AEA RID: 281322 RVA: 0x011DA27C File Offset: 0x011D847C
		public void Refresh(int id)
		{
			if (id == 0)
			{
				this.SetActive(false);
				return;
			}
			FishingPoint? fishingPointConfigById = ConfigBase<FishingConfig>.Instance.GetFishingPointConfigById(id);
			FishingTag? fishingTagConfig = ConfigBase<FishingConfig>.Instance.GetFishingTagConfig(fishingPointConfigById.Value.UnlockTech);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), fishingTagConfig.Value.Name, Array.Empty<object>());
			FColor color = FColor.FromHex(fishingTagConfig.Value.Color);
			base.GetSprite(1).SetColor(color);
			this.SetActive(true);
		}

		// Token: 0x0200CB74 RID: 52084
		private class EComponents
		{
			// Token: 0x0403E6F0 RID: 255728
			public const int TxtTag = 0;

			// Token: 0x0403E6F1 RID: 255729
			public const int SpriteBg = 1;
		}
	}
}
