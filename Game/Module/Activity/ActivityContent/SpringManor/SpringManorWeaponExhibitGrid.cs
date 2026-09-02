using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006316 RID: 25366
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpringManorWeaponExhibitGrid : LoopScrollMediumItemGrid<SpringManorWeaponExhibitItem>
	{
		// Token: 0x0603FC0C RID: 261132 RVA: 0x01058365 File Offset: 0x01056565
		public void BindOnWeaponSelected(Action<int, int> callback)
		{
			this.OnWeaponSelectedCallback = callback;
		}

		// Token: 0x0603FC0D RID: 261133 RVA: 0x0105836E File Offset: 0x0105656E
		public override void OnSelected(bool _)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603FC0E RID: 261134 RVA: 0x01058378 File Offset: 0x01056578
		public override void OnDeselected(bool _)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603FC0F RID: 261135 RVA: 0x01058384 File Offset: 0x01056584
		protected override void OnRefresh(SpringManorWeaponExhibitItem data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			WeaponConfig instance = ConfigBase<WeaponConfig>.Instance;
			WeaponConf? weaponConf;
			string bottomTextId = ((instance != null) ? ((instance.GetWeaponConfigByItemId(data.ConfigId) != null) ? weaponConf.GetValueOrDefault().WeaponName : null) : null) ?? "";
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				ItemConfigId = new int?(data.ConfigId),
				IsCheckTick = new bool?(data.IsSelected),
				BottomTextId = bottomTextId
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
		}

		// Token: 0x0603FC10 RID: 261136 RVA: 0x01058413 File Offset: 0x01056613
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (this.OnWeaponSelectedCallback != null && this.CurrentData != null)
			{
				this.OnWeaponSelectedCallback(this.CurrentData.ConfigId, base.GridIndex);
			}
		}

		// Token: 0x04023C90 RID: 146576
		[Nullable(2)]
		private Action<int, int> OnWeaponSelectedCallback;

		// Token: 0x04023C91 RID: 146577
		[Nullable(2)]
		private SpringManorWeaponExhibitItem CurrentData;
	}
}
