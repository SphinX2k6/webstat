using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ECA RID: 20170
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TowerDefenseInBattleInfoItem : GridProxyAbstract<ITowerDefensePhantomSkillItemInBattleData>
	{
		// Token: 0x060341A8 RID: 213416 RVA: 0x00D0558C File Offset: 0x00D0378C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060341A9 RID: 213417 RVA: 0x00D0567C File Offset: 0x00D0387C
		[NullableContext(1)]
		public override void Refresh(ITowerDefensePhantomSkillItemInBattleData data, bool isSelected, int gridIndex)
		{
			string resourceId = data.IsCurrent ? "T_LordGymTitleBgB" : "T_LordGymTitleBgA";
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string path = ((instance != null) ? instance.GetResourcePath(resourceId) : null) ?? "";
			base.TrySetTextureByPath(path, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Skill, Array.Empty<object>());
			UUIText text = base.GetText(2);
			UUIItem uuiitem = text;
			bool bUseChangeColor = !data.IsUnlock;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.GetSprite(3).SetUIActive(data.IsUnlock);
			base.GetSprite(4).SetUIActive(!data.IsUnlock);
			UUIText text2 = base.GetText(5);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.Description, data.DescriptionArgs);
		}

		// Token: 0x0200AE6B RID: 44651
		private class EItemComponent
		{
			// Token: 0x0403625E RID: 221790
			public const int TitlePnl = 0;

			// Token: 0x0403625F RID: 221791
			public const int BgTex = 1;

			// Token: 0x04036260 RID: 221792
			public const int TitleTxt = 2;

			// Token: 0x04036261 RID: 221793
			public const int StateIconSprite = 3;

			// Token: 0x04036262 RID: 221794
			public const int LockStateSprite = 4;

			// Token: 0x04036263 RID: 221795
			public const int DescTxt = 5;
		}
	}
}
