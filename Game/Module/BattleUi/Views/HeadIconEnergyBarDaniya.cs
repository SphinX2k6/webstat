using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200601C RID: 24604
	public class HeadIconEnergyBarDaniya : HeadIconEnergyBarBase
	{
		// Token: 0x0603E010 RID: 253968 RVA: 0x00FD26CC File Offset: 0x00FD08CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E011 RID: 253969 RVA: 0x00FD2840 File Offset: 0x00FD0A40
		protected override void OnStart()
		{
			base.OnStart();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.形态标识.白形态"], new BaseTagComponent.TTagSwitchedCallback(this.OnStyleChanged));
			BaseTagComponent tagComponent = this.TagComponent;
			bool tagExist = tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.形态标识.白形态"]);
			this.OnStyleChanged(0, tagExist);
		}

		// Token: 0x0603E012 RID: 253970 RVA: 0x00FD289E File Offset: 0x00FD0A9E
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E013 RID: 253971 RVA: 0x00FD28AD File Offset: 0x00FD0AAD
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E014 RID: 253972 RVA: 0x00FD28B6 File Offset: 0x00FD0AB6
		private void OnStyleChanged(int tagId, bool tagExist)
		{
			this.CurState = (tagExist ? HeadIconEnergyBarDaniya.EState.StateA : HeadIconEnergyBarDaniya.EState.StateB);
			base.GetItem(0).SetUIActive(tagExist);
			base.GetItem(5).SetUIActive(!tagExist);
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E015 RID: 253973 RVA: 0x00FD28EC File Offset: 0x00FD0AEC
		private void RefreshBarPercent(bool bForce = false)
		{
			float num = this.ImmediateMode ? this.PercentMachine.GetTargetPercent() : this.PercentMachine.GetCurPercent();
			HeadIconEnergyBarDaniya.EChildType name = (this.CurState == HeadIconEnergyBarDaniya.EState.StateA) ? HeadIconEnergyBarDaniya.EChildType.BarNorA : HeadIconEnergyBarDaniya.EChildType.BarNorB;
			base.GetSprite((int)name).SetFillAmount(num);
			bool flag = num > 0.5f;
			if (this.LightVisible != flag || bForce)
			{
				this.LightVisible = flag;
				HeadIconEnergyBarDaniya.EChildType name2 = (this.CurState == HeadIconEnergyBarDaniya.EState.StateA) ? HeadIconEnergyBarDaniya.EChildType.PnlBurstA : HeadIconEnergyBarDaniya.EChildType.PnlBurstB;
				base.GetItem((int)name2).SetUIActive(flag);
			}
			if (flag)
			{
				HeadIconEnergyBarDaniya.EChildType name3 = (this.CurState == HeadIconEnergyBarDaniya.EState.StateA) ? HeadIconEnergyBarDaniya.EChildType.BarNorLightA : HeadIconEnergyBarDaniya.EChildType.BarNorLightB;
				base.GetSprite((int)name3).SetFillAmount(num);
			}
		}

		// Token: 0x04022C4C RID: 142412
		private const float SHOW_LIGHT_VALUE = 0.5f;

		// Token: 0x04022C4D RID: 142413
		private HeadIconEnergyBarDaniya.EState CurState;

		// Token: 0x04022C4E RID: 142414
		private readonly bool ImmediateMode = true;

		// Token: 0x04022C4F RID: 142415
		private bool LightVisible;

		// Token: 0x0200C0C7 RID: 49351
		private enum EState
		{
			// Token: 0x0403B5A0 RID: 243104
			StateA,
			// Token: 0x0403B5A1 RID: 243105
			StateB
		}

		// Token: 0x0200C0C8 RID: 49352
		private enum EChildType
		{
			// Token: 0x0403B5A3 RID: 243107
			PnBarA,
			// Token: 0x0403B5A4 RID: 243108
			PnlNorA,
			// Token: 0x0403B5A5 RID: 243109
			BarNorA,
			// Token: 0x0403B5A6 RID: 243110
			PnlBurstA,
			// Token: 0x0403B5A7 RID: 243111
			BarNorLightA,
			// Token: 0x0403B5A8 RID: 243112
			PnBarB,
			// Token: 0x0403B5A9 RID: 243113
			PnlNorB,
			// Token: 0x0403B5AA RID: 243114
			BarNorB,
			// Token: 0x0403B5AB RID: 243115
			PnlBurstB,
			// Token: 0x0403B5AC RID: 243116
			BarNorLightB
		}
	}
}
