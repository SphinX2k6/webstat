using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DBA RID: 23994
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DreamLinkBossInstanceItem : GridProxyAbstract<DreamLinkBossInstanceData>
	{
		// Token: 0x0603C694 RID: 247444 RVA: 0x00F559C8 File Offset: 0x00F53BC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleFunctionInternal));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C695 RID: 247445 RVA: 0x00F55B78 File Offset: 0x00F53D78
		protected override void OnStart()
		{
			base.GetItem(3).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			this.ActivityDataBase = ControllerBase<DreamLinkController>.Instance.GetCurrentActivityData();
		}

		// Token: 0x0603C696 RID: 247446 RVA: 0x00F55BA4 File Offset: 0x00F53DA4
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603C697 RID: 247447 RVA: 0x00F55BA8 File Offset: 0x00F53DA8
		public override void Refresh(DreamLinkBossInstanceData data, bool isSelected, int gridIndex)
		{
			this.InstData = data;
			RogueBossInstance? rogueBossInstanceConfig = ConfigBase<DreamLinkConfig>.Instance.GetRogueBossInstanceConfig(data.TypeId);
			if (!StringUtils.IsEmpty(rogueBossInstanceConfig.Value.InstTitle))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueBossInstanceConfig.Value.InstTitle, Array.Empty<object>());
			}
			base.GetText(6).SetText(rogueBossInstanceConfig.Value.InstNumber, true);
			if (data.IsUnlock)
			{
				if (data.Score > 0)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "DaMaoScore_Normal", new <>z__ReadOnlySingleElementList<object>(data.Score));
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "DaMaoScore_Unfinish", Array.Empty<object>());
				}
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "DaMaoFushua_Level_Unlock", Array.Empty<object>());
			}
			base.GetItem(4).SetUIActive(!data.IsUnlock);
			base.GetItem(8).SetUIActive(!data.IsUnlock);
			this.RefreshRedDot();
		}

		// Token: 0x0603C698 RID: 247448 RVA: 0x00F55CC5 File Offset: 0x00F53EC5
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleSelected(true);
		}

		// Token: 0x0603C699 RID: 247449 RVA: 0x00F55CCE File Offset: 0x00F53ECE
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelected(false);
		}

		// Token: 0x0603C69A RID: 247450 RVA: 0x00F55CD8 File Offset: 0x00F53ED8
		private void RefreshRedDot()
		{
			bool bossInstRedDotState = this.ActivityDataBase.GetBossInstRedDotState(this.InstData.InstId);
			base.GetItem(5).SetUIActive(bossInstRedDotState);
			base.GetItem(9).SetUIActive(bossInstRedDotState);
		}

		// Token: 0x0603C69B RID: 247451 RVA: 0x00F55D17 File Offset: 0x00F53F17
		private void SetToggleSelected(bool bOn)
		{
			base.GetExtendToggle(0).SetToggleState(bOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x0603C69C RID: 247452 RVA: 0x00F55D30 File Offset: 0x00F53F30
		private void ToggleFunctionInternal(EToggleState toggleState)
		{
			if (toggleState == EToggleState.ETT_Checked)
			{
				this.ActivityDataBase.SaveBossInstRedDotState(this.InstData.InstId);
				this.RefreshRedDot();
				Action<DreamLinkBossInstanceData, int> toggleFunction = this.ToggleFunction;
				if (toggleFunction == null)
				{
					return;
				}
				toggleFunction(this.InstData, base.GridIndex);
			}
		}

		// Token: 0x0603C69D RID: 247453 RVA: 0x00F55D6E File Offset: 0x00F53F6E
		public override object GetKey(DreamLinkBossInstanceData data, int displayIndex)
		{
			return this.InstData.InstId;
		}

		// Token: 0x04021F6B RID: 139115
		[Nullable(2)]
		protected DreamLinkBossInstanceData InstData;

		// Token: 0x04021F6C RID: 139116
		[Nullable(2)]
		protected DreamLinkData ActivityDataBase;

		// Token: 0x04021F6D RID: 139117
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<DreamLinkBossInstanceData, int> ToggleFunction;

		// Token: 0x0200BE09 RID: 48649
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A80F RID: 239631
			public const int Toggle = 0;

			// Token: 0x0403A810 RID: 239632
			public const int TxtTitleB = 1;

			// Token: 0x0403A811 RID: 239633
			public const int TxtScoreB = 2;

			// Token: 0x0403A812 RID: 239634
			public const int PanelDoneB = 3;

			// Token: 0x0403A813 RID: 239635
			public const int PanelLockB = 4;

			// Token: 0x0403A814 RID: 239636
			public const int RedDotB = 5;

			// Token: 0x0403A815 RID: 239637
			public const int TxtTitleA = 6;

			// Token: 0x0403A816 RID: 239638
			public const int PanelDoneA = 7;

			// Token: 0x0403A817 RID: 239639
			public const int PanelLockA = 8;

			// Token: 0x0403A818 RID: 239640
			public const int RedDotA = 9;
		}
	}
}
