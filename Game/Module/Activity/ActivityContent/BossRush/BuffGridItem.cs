using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069BD RID: 27069
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class BuffGridItem : GridProxyAbstract<BuffGridItemData>
	{
		// Token: 0x060431CF RID: 274895 RVA: 0x0113D100 File Offset: 0x0113B300
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060431D0 RID: 274896 RVA: 0x0113D20C File Offset: 0x0113B40C
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Unbind();
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060431D1 RID: 274897 RVA: 0x0113D258 File Offset: 0x0113B458
		private bool CanClickLikeToggle()
		{
			return this.CurrentData != null && ((this.CurrentData.State == BossRushBuffSelectionStatus.BuffLocked && base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_UnChecked) || this.CurrentData.CheckClickAble(this.CurrentData));
		}

		// Token: 0x060431D2 RID: 274898 RVA: 0x0113D298 File Offset: 0x0113B498
		private void OnClickToggle(EToggleState state)
		{
			this.CurrentData.OnClickToggle(this.CurrentData);
		}

		// Token: 0x060431D3 RID: 274899 RVA: 0x0113D2B0 File Offset: 0x0113B4B0
		public void SetToggleActiveState(bool state)
		{
			base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(state);
		}

		// Token: 0x060431D4 RID: 274900 RVA: 0x0113D2D8 File Offset: 0x0113B4D8
		public override void Refresh(BuffGridItemData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data.BuffScrollItemData1;
			if (data.BuffScrollItemData1.State == BossRushBuffSelectionStatus.BuffInactive)
			{
				return;
			}
			BuffScrollItemData buffScrollItemData = data.BuffScrollItemData1;
			EToggleState state = (buffScrollItemData != null && buffScrollItemData.Selected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
			this.RefreshName();
			this.RefreshDesc();
			this.RefreshBuffTexture();
			this.RefreshSelectedTag();
		}

		// Token: 0x060431D5 RID: 274901 RVA: 0x0113D342 File Offset: 0x0113B542
		private void RefreshSelectedTag()
		{
			base.GetItem(4).SetUIActive(this.CurrentData.SelectedAtStart);
		}

		// Token: 0x060431D6 RID: 274902 RVA: 0x0113D35C File Offset: 0x0113B55C
		private void RefreshName()
		{
			BossRushBuff? bossRushBuffConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(this.CurrentData.BuffId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), bossRushBuffConfigById.Value.Name, Array.Empty<object>());
		}

		// Token: 0x060431D7 RID: 274903 RVA: 0x0113D3A4 File Offset: 0x0113B5A4
		private void RefreshDesc()
		{
			BossRushBuff? bossRushBuffConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(this.CurrentData.BuffId);
			List<string> list = new List<string>();
			foreach (string input in bossRushBuffConfigById.Value.DescriptionParamIter())
			{
				Match match = BuffGridItem.regex.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					list.AddRange(match.Groups[1].Value.Split(',', StringSplitOptions.None));
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), bossRushBuffConfigById.Value.Description, list.ToArray());
		}

		// Token: 0x060431D8 RID: 274904 RVA: 0x0113D47C File Offset: 0x0113B67C
		private void RefreshBuffTexture()
		{
			string texture = ConfigBase<BossRushConfig>.Instance.GetBossRushBuffConfigById(this.CurrentData.BuffId).Value.Texture;
			base.SetTextureByPath(texture, base.GetTexture(1), null, null);
		}

		// Token: 0x04025665 RID: 153189
		[Nullable(2)]
		private BuffScrollItemData CurrentData;

		// Token: 0x04025666 RID: 153190
		[StaticVariableRuleIgnore]
		private static Regex regex = new Regex("\\[(.*?)\\]");

		// Token: 0x0200C946 RID: 51526
		[NullableContext(0)]
		private class EBuffScrollItemComponent
		{
			// Token: 0x0403DE71 RID: 253553
			public const int Toggle = 0;

			// Token: 0x0403DE72 RID: 253554
			public const int BuffTexture = 1;

			// Token: 0x0403DE73 RID: 253555
			public const int BuffName = 2;

			// Token: 0x0403DE74 RID: 253556
			public const int BuffDesc = 3;

			// Token: 0x0403DE75 RID: 253557
			public const int SelectedTag = 4;
		}
	}
}
