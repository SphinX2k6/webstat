using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA3 RID: 28323
	public class FishingRoundItem : GridProxyAbstract<int>
	{
		// Token: 0x06044AE4 RID: 281316 RVA: 0x011DA0F4 File Offset: 0x011D82F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AE5 RID: 281317 RVA: 0x011DA15D File Offset: 0x011D835D
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x06044AE6 RID: 281318 RVA: 0x011DA17D File Offset: 0x011D837D
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
		}

		// Token: 0x06044AE7 RID: 281319 RVA: 0x011DA180 File Offset: 0x011D8380
		public void ShowIcon(int type)
		{
			UUISprite sprite = base.GetSprite(1);
			string resourceId = this.fishingIconPath[type];
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, sprite, false, null, delegate(bool _)
			{
				sprite.SetUIActive(true);
				this.LevelSequencePlayer.PlayLevelSequenceByName("Fish", false, null, false);
			});
		}

		// Token: 0x06044AE8 RID: 281320 RVA: 0x011DA1E3 File Offset: 0x011D83E3
		public FishingRoundItem()
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary[1] = "SP_Fishing_IconMaterial";
			dictionary[0] = "SP_Fishing_IconFish";
			this.fishingIconPath = dictionary;
			base..ctor();
		}

		// Token: 0x040263C5 RID: 156613
		[Nullable(1)]
		private Dictionary<int, string> fishingIconPath;

		// Token: 0x040263C6 RID: 156614
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200CB72 RID: 52082
		public class EComponents
		{
			// Token: 0x0403E6EC RID: 255724
			public const int PanelFish = 0;

			// Token: 0x0403E6ED RID: 255725
			public const int SpriteIcon = 1;
		}
	}
}
