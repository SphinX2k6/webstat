using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ECD RID: 20173
	public class TowerDefenseLevelBossItem : GridProxyAbstract<int>
	{
		// Token: 0x060341C8 RID: 213448 RVA: 0x00D06720 File Offset: 0x00D04920
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060341C9 RID: 213449 RVA: 0x00D067AC File Offset: 0x00D049AC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(data);
			base.SetTextureByPath(monsterIcon, base.GetTexture(1), null, null);
			int num = gridIndex + 1;
			UUIArtText artText = base.GetArtText(2);
			if (artText == null)
			{
				return;
			}
			string text;
			if (num >= 10)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			artText.SetText(text);
		}

		// Token: 0x0200AE70 RID: 44656
		private class ELevelDetailBossItemComponent
		{
			// Token: 0x04036283 RID: 221827
			public const int ItemBtn = 0;

			// Token: 0x04036284 RID: 221828
			public const int BossTex = 1;

			// Token: 0x04036285 RID: 221829
			public const int NumArtTxt = 2;
		}
	}
}
