using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.FilterSetting
{
	// Token: 0x020057A9 RID: 22441
	[NullableContext(2)]
	[Nullable(0)]
	public class FilterSettingPixListItem : AutoAttachItem<FilterSetting>
	{
		// Token: 0x060390EF RID: 233711 RVA: 0x00E76192 File Offset: 0x00E74392
		public FilterSettingPixListItem(AActor uiItem = null) : base(uiItem)
		{
		}

		// Token: 0x060390F0 RID: 233712 RVA: 0x00E7619C File Offset: 0x00E7439C
		public override void OnSelect()
		{
			FilterSettingViewModel parentViewModel = this.ParentViewModel;
			if (parentViewModel != null)
			{
				Action<int> onIndexChanged = parentViewModel.OnIndexChanged;
				if (onIndexChanged != null)
				{
					onIndexChanged(base.GetCurrentShowItemIndex());
				}
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x060390F1 RID: 233713 RVA: 0x00E761EC File Offset: 0x00E743EC
		protected override void OnUnSelect()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x060390F2 RID: 233714 RVA: 0x00E76218 File Offset: 0x00E74418
		protected override void OnMoveItem()
		{
			float currentMovePercentage = base.GetCurrentMovePercentage();
			this.RefreshScaleByCurve(currentMovePercentage);
			this.RefreshAlphaByCurve(currentMovePercentage);
			this.RefreshHierarchyIndex(currentMovePercentage);
		}

		// Token: 0x060390F3 RID: 233715 RVA: 0x00E76241 File Offset: 0x00E74441
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle))
			};
		}

		// Token: 0x060390F4 RID: 233716 RVA: 0x00E7627C File Offset: 0x00E7447C
		protected override void OnRefreshItem(FilterSetting data)
		{
			base.TrySetTextureByPath(data.SpritePath, base.GetTexture(0), null, null);
			EToggleState state = (LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.FilterSettingId, 1) == data.Id) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x060390F5 RID: 233717 RVA: 0x00E762D8 File Offset: 0x00E744D8
		private void RefreshScaleByCurve(float percentage)
		{
			if (this.ScaleCurve != null)
			{
				float floatValue = this.ScaleCurve.GetFloatValue(percentage);
				FVector uiitemScale = new FVector(floatValue, floatValue, floatValue);
				this.RootItem.SetUIItemScale(uiitemScale);
			}
		}

		// Token: 0x060390F6 RID: 233718 RVA: 0x00E76310 File Offset: 0x00E74510
		private void RefreshAlphaByCurve(float percentage)
		{
			if (this.AlphaCurve != null)
			{
				float floatValue = this.AlphaCurve.GetFloatValue(percentage);
				this.RootItem.SetUIItemAlpha(floatValue);
			}
		}

		// Token: 0x060390F7 RID: 233719 RVA: 0x00E76340 File Offset: 0x00E74540
		private void RefreshHierarchyIndex(float percentage)
		{
			int num = 2;
			if (percentage <= 0.25f)
			{
				num = 1;
			}
			else if (percentage >= 0.75f)
			{
				num = 1;
			}
			if (this.RootItem.GetHierarchyIndex() != num)
			{
				this.RootItem.SetHierarchyIndex(num);
			}
		}

		// Token: 0x040207B6 RID: 133046
		private const float INDEXQUARTER = 0.25f;

		// Token: 0x040207B7 RID: 133047
		private const float INDEXTHREEQUARTER = 0.75f;

		// Token: 0x040207B8 RID: 133048
		private const int MAXHIERARCHYINDEX = 2;

		// Token: 0x040207B9 RID: 133049
		private const int MINHIERARCHYINDEX = 1;

		// Token: 0x040207BA RID: 133050
		public FilterSettingViewModel ParentViewModel;

		// Token: 0x040207BB RID: 133051
		public UCurveFloat OffsetCurve;

		// Token: 0x040207BC RID: 133052
		public UCurveFloat ScaleCurve;

		// Token: 0x040207BD RID: 133053
		public UCurveFloat AlphaCurve;
	}
}
