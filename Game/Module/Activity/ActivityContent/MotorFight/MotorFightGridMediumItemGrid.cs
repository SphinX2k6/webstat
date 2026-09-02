using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D6 RID: 26326
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightGridMediumItemGrid : MediumItemGrid
	{
		// Token: 0x1700A093 RID: 41107
		// (get) Token: 0x06041BC6 RID: 269254 RVA: 0x010DB5F0 File Offset: 0x010D97F0
		public new MotorFightItemData Data
		{
			get
			{
				return this.Data as MotorFightItemData;
			}
		}

		// Token: 0x06041BC7 RID: 269255 RVA: 0x010DB5FD File Offset: 0x010D97FD
		protected override void OnStart()
		{
			this.GetItemGridExtendToggle().bLockStateOnSelect = true;
			base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickToggle));
			base.SetUseFixedAsync(true);
		}

		// Token: 0x06041BC8 RID: 269256 RVA: 0x010DB624 File Offset: 0x010D9824
		public void Refresh(MotorFightItemData data)
		{
			this.Data = data;
			MotorFightQuality? motorFightQuality = ConfigBase<MotorFightConfig>.Instance.GetMotorFightQuality(data.Quality);
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				QualityIcon = motorFightQuality.Value.SmallGridBg,
				IconPath = data.Icon,
				BottomTextId = data.Name,
				IsLockVisible = new bool?(!data.IsUnLock),
				IsDisable = new bool?(!data.IsUnLock),
				IsNewVisible = new bool?(data.HasItemRedDot)
			};
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x06041BC9 RID: 269257 RVA: 0x010DB6C3 File Offset: 0x010D98C3
		private void OnClickToggle(MediumItemGridExtendCallback _)
		{
			this.Data.ReadItemRedDot();
			base.SetNewVisible(new bool?(false));
			this.OnClickCallBack(this.Data);
		}

		// Token: 0x06041BCA RID: 269258 RVA: 0x010DB6F0 File Offset: 0x010D98F0
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			this.GetItemGridExtendToggle().SetToggleState(state2, false, false, false);
		}

		// Token: 0x04024AE1 RID: 150241
		public Action<MotorFightItemData> OnClickCallBack = delegate(MotorFightItemData <p0>)
		{
		};
	}
}
