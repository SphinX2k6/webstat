using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E6C RID: 20076
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseResultInfoItem : GridProxyAbstract<ITrapDefensePauseInfo>
	{
		// Token: 0x06033E20 RID: 212512 RVA: 0x00CFAE18 File Offset: 0x00CF9018
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033E21 RID: 212513 RVA: 0x00CFAEC4 File Offset: 0x00CF90C4
		public override void Refresh(ITrapDefensePauseInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			ETrapDefensePauseInfoType type = data.Type;
			if (type == ETrapDefensePauseInfoType.Health)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("TrapDefenseResultHealth");
				this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
				UUISprite sprite = base.GetSprite(3);
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "TowerDefense_HomeHp_Text", Array.Empty<object>());
				int? num = data.Value;
				long value = (num != null) ? ((long)num.GetValueOrDefault()) : ModelBase<TrapDefenseModel>.Instance.BattleData.GetHealth();
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<long>(value);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
			else
			{
				string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("TrapDefenseResultBatch");
				this.SetSpriteByPath(resourcePath2, base.GetSprite(0), false, null, null);
				UUISprite sprite2 = base.GetSprite(3);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
				int num2 = data.Value ?? ModelBase<TrapDefenseModel>.Instance.BattleData.GetBatch();
				string textStringId = (type == ETrapDefensePauseInfoType.BatchCur) ? "TowerDefense_WaveCurCount_Text" : "TowerDefense_WaveCount_Text";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
				if (ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData().Config.ModeType != 3)
				{
					int? num = data.MaxBatch;
					long num3 = (num != null) ? ((long)num.GetValueOrDefault()) : ModelBase<TrapDefenseModel>.Instance.BattleData.GetMaxBatch();
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "TowerDefense_ESC_WaveCountNum_Text", new <>z__ReadOnlyArray<object>(new object[]
					{
						num2,
						num3
					}));
					return;
				}
				UUIText text2 = base.GetText(2);
				if (text2 == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
		}

		// Token: 0x0401E020 RID: 122912
		protected ITrapDefensePauseInfo Data;

		// Token: 0x0200AE22 RID: 44578
		[NullableContext(0)]
		internal class EItem
		{
			// Token: 0x0403613A RID: 221498
			public const int Icon = 0;

			// Token: 0x0403613B RID: 221499
			public const int Title = 1;

			// Token: 0x0403613C RID: 221500
			public const int Value = 2;

			// Token: 0x0403613D RID: 221501
			public const int Split = 3;
		}
	}
}
