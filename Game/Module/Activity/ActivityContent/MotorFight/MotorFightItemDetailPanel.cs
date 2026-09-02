using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D7 RID: 26327
	public class MotorFightItemDetailPanel : UiPanelBase
	{
		// Token: 0x06041BCC RID: 269260 RVA: 0x010DB744 File Offset: 0x010D9944
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041BCD RID: 269261 RVA: 0x010DB874 File Offset: 0x010D9A74
		[NullableContext(1)]
		public void Refresh(MotorFightItemData data)
		{
			base.SetTextureByPath(ConfigBase<MotorFightConfig>.Instance.GetMotorFightQuality(data.Quality).Value.DetailCardBg, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
			base.SetTextureByPath(data.BigIcon, base.GetTexture(3), null, null);
			MotorFightItemType? motorFightItemType = ConfigBase<MotorFightConfig>.Instance.GetMotorFightItemType(data.Type);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), motorFightItemType.Value.Name, Array.Empty<object>());
			this.SetSpriteByPath(motorFightItemType.Value.Icon, base.GetSprite(5), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), data.Desc, data.DescParams);
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(!data.IsUnLock);
			}
			if (!data.IsUnLock)
			{
				string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(data.ConditionId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), conditionGroupHintText, Array.Empty<object>());
			}
		}

		// Token: 0x0200C706 RID: 50950
		private class EComponents
		{
			// Token: 0x0403D455 RID: 250965
			public const int ToggleRoot = 0;

			// Token: 0x0403D456 RID: 250966
			public const int TextureQuality = 1;

			// Token: 0x0403D457 RID: 250967
			public const int TextName = 2;

			// Token: 0x0403D458 RID: 250968
			public const int TextureIcon = 3;

			// Token: 0x0403D459 RID: 250969
			public const int TextTypeName = 4;

			// Token: 0x0403D45A RID: 250970
			public const int SpriteTypeIcon = 5;

			// Token: 0x0403D45B RID: 250971
			public const int TextDesc = 6;

			// Token: 0x0403D45C RID: 250972
			public const int ItemUnlockPanel = 7;

			// Token: 0x0403D45D RID: 250973
			public const int TextLockTip = 8;
		}
	}
}
