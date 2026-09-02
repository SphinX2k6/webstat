using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200603D RID: 24637
	public class BattleHonamiStoryRoleSuitItem : UiPanelBase
	{
		// Token: 0x0603E25A RID: 254554 RVA: 0x00FDD1B0 File Offset: 0x00FDB3B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E25B RID: 254555 RVA: 0x00FDD1F8 File Offset: 0x00FDB3F8
		protected override void OnBeforeCreateImplement()
		{
			this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.LevelPlaySequence);
		}

		// Token: 0x0603E25C RID: 254556 RVA: 0x00FDD214 File Offset: 0x00FDB414
		[NullableContext(2)]
		public void Refresh(HonamiStoryWeaponSuitActiveData suitData, int suitPluginType)
		{
			HonamiStoryPluginSubType value = ConfigBase<HonamiStoryConfig>.Instance.GetPluginSubType(suitPluginType).Value;
			string path = value.ActiveSpritePath;
			if (suitData != null)
			{
				int num = suitData.CurCount - suitData.NeedCount;
				if (num >= 0)
				{
					path = value.ActiveAllSpritePath;
				}
				else if (num == -1)
				{
					path = value.ActiveOneSpritePath;
				}
			}
			this.SetSpriteByPath(path, base.GetSprite(0), true, null, null);
		}

		// Token: 0x0603E25D RID: 254557 RVA: 0x00FDD284 File Offset: 0x00FDB484
		public void PlayBurst()
		{
			UiBehaviorLevelSequence levelPlaySequence = this.LevelPlaySequence;
			if (levelPlaySequence != null)
			{
				levelPlaySequence.StopPrevSequence(false, true);
			}
			UiBehaviorLevelSequence levelPlaySequence2 = this.LevelPlaySequence;
			if (levelPlaySequence2 == null)
			{
				return;
			}
			levelPlaySequence2.PlaySequence("Burst", false, null);
		}

		// Token: 0x04022D6B RID: 142699
		[Nullable(2)]
		private UiBehaviorLevelSequence LevelPlaySequence;

		// Token: 0x0200C0FF RID: 49407
		private enum EComponentType
		{
			// Token: 0x0403B6E7 RID: 243431
			Sprite
		}
	}
}
