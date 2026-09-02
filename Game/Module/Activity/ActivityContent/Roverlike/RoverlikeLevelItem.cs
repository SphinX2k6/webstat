using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006426 RID: 25638
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeLevelItem : GridProxyAbstract<RoverlikeLevelSelectItemData>
	{
		// Token: 0x060405AD RID: 263597 RVA: 0x0107EC94 File Offset: 0x0107CE94
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060405AE RID: 263598 RVA: 0x0107EE00 File Offset: 0x0107D000
		public override void Refresh(RoverlikeLevelSelectItemData data, bool isSelected, int gridIndex)
		{
			this.InstId = data.InstId;
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(this.InstId);
			int num = (insConfig != null) ? insConfig.GetValueOrDefault().SortId : 0;
			string text;
			if (num >= 10)
			{
				text = num.ToString();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string newText = text;
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(newText, true);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(!data.Unlocked);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(data.Passed);
			}
			int num2 = (insConfig != null) ? insConfig.GetValueOrDefault().Difficulty : 0;
			if (num2 == 0)
			{
				num2 = 1;
			}
			int index = Math.Min(Math.Max(num2 - 1, 0), 2);
			base.TrySetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RoverlikeLevelItem.DifficultySpriteNames[index]), base.GetSprite(4), false, null, null);
			base.TrySetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RoverlikeLevelItem.DifficultySeleSpriteNames[index]), base.GetSprite(7), false, null, null);
			UUISprite sprite = base.GetSprite(5);
			if (sprite != null)
			{
				sprite.SetColor(RoverlikeLevelItem.DifficultyLightColors[index]);
			}
			UUISprite sprite2 = base.GetSprite(6);
			if (sprite2 != null)
			{
				sprite2.SetColor(RoverlikeLevelItem.DifficultyLineColors[index]);
			}
			this.SetToggleChecked(isSelected, false);
		}

		// Token: 0x060405AF RID: 263599 RVA: 0x0107EF96 File Offset: 0x0107D196
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleChecked(true, false);
		}

		// Token: 0x060405B0 RID: 263600 RVA: 0x0107EFA0 File Offset: 0x0107D1A0
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleChecked(false, false);
		}

		// Token: 0x060405B1 RID: 263601 RVA: 0x0107EFAA File Offset: 0x0107D1AA
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.CanExecuteChange.Bind(() => !this.IsSelected);
		}

		// Token: 0x060405B2 RID: 263602 RVA: 0x0107EFCE File Offset: 0x0107D1CE
		public override object GetKey(RoverlikeLevelSelectItemData data, int gridIndex)
		{
			return data.InstId;
		}

		// Token: 0x060405B3 RID: 263603 RVA: 0x0107EFDB File Offset: 0x0107D1DB
		public void SetToggleChecked(bool isChecked, bool fireEvent)
		{
			this.IsSelected = isChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isChecked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x060405B4 RID: 263604 RVA: 0x0107EFFF File Offset: 0x0107D1FF
		public int GetInstId()
		{
			return this.InstId;
		}

		// Token: 0x060405B5 RID: 263605 RVA: 0x0107F007 File Offset: 0x0107D207
		private void OnToggleStateChange(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			Action<int> onSelectCallback = this.OnSelectCallback;
			if (onSelectCallback == null)
			{
				return;
			}
			onSelectCallback(this.InstId);
		}

		// Token: 0x040240EB RID: 147691
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<string> DifficultySpriteNames = new List<string>
		{
			"SP_SeleLevelTabNorLineEasy",
			"SP_SeleLevelTabNorLineMedium",
			"SP_SeleLevelTabNorLineHard"
		};

		// Token: 0x040240EC RID: 147692
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<string> DifficultySeleSpriteNames = new List<string>
		{
			"SP_SeleLevelTabSleLightEasy",
			"SP_SeleLevelTabSleLightMedium",
			"SP_SeleLevelTabSleLightHard"
		};

		// Token: 0x040240ED RID: 147693
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<FColor> DifficultyLightColors = new List<FColor>
		{
			FColor.FromHex("#80B3FFFF"),
			FColor.FromHex("#5046D2FF"),
			FColor.FromHex("#B0233AFF")
		};

		// Token: 0x040240EE RID: 147694
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<FColor> DifficultyLineColors = new List<FColor>
		{
			FColor.FromHex("#4D9EF2FF"),
			FColor.FromHex("#AD9CFFFF"),
			FColor.FromHex("#FF7484FF")
		};

		// Token: 0x040240EF RID: 147695
		[Nullable(2)]
		public Action<int> OnSelectCallback;

		// Token: 0x040240F0 RID: 147696
		private int InstId;

		// Token: 0x040240F1 RID: 147697
		private bool IsSelected;

		// Token: 0x0200C491 RID: 50321
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C800 RID: 247808
			public const int TogTabLevel = 0;

			// Token: 0x0403C801 RID: 247809
			public const int TxtLevel = 1;

			// Token: 0x0403C802 RID: 247810
			public const int PnlLock = 2;

			// Token: 0x0403C803 RID: 247811
			public const int PnlDone = 3;

			// Token: 0x0403C804 RID: 247812
			public const int SprDifficulty = 4;

			// Token: 0x0403C805 RID: 247813
			public const int SprDifficultyLight = 5;

			// Token: 0x0403C806 RID: 247814
			public const int SprDifficultyLine = 6;

			// Token: 0x0403C807 RID: 247815
			public const int SprSeleColor = 7;
		}
	}
}
