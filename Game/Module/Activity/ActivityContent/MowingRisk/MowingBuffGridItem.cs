using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200669C RID: 26268
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MowingBuffGridItem : GridProxyAbstract<IMowingBuffGridItemData>
	{
		// Token: 0x06041994 RID: 268692 RVA: 0x010D1948 File Offset: 0x010CFB48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
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
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041995 RID: 268693 RVA: 0x010D1AF8 File Offset: 0x010CFCF8
		protected override UniTask OnBeforeStartAsync()
		{
			MowingBuffGridItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingBuffGridItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041996 RID: 268694 RVA: 0x010D1B3B File Offset: 0x010CFD3B
		protected override void OnStart()
		{
			base.GetExtendToggle(6).CanExecuteChange.Bind(new Func<bool>(this.HandleCanExecuteChange));
		}

		// Token: 0x06041997 RID: 268695 RVA: 0x010D1B5A File Offset: 0x010CFD5A
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(6).CanExecuteChange.Unbind();
		}

		// Token: 0x06041998 RID: 268696 RVA: 0x010D1B70 File Offset: 0x010CFD70
		public override void Refresh(IMowingBuffGridItemData data, bool isSelected, int gridIndex)
		{
			this.PassData = data;
			this.SetSpriteByPath(data.QualityPath, base.GetSprite(0), false, null, null);
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(data.IconPath != null);
			}
			if (!string.IsNullOrEmpty(data.IconPath))
			{
				base.SetTextureByPath(data.IconPath, texture, null, null);
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.NameTextId, Array.Empty<object>());
			base.GetSprite(3).SetUIActive(data.IsShowBackground);
			base.GetItem(5).SetUIActive(false);
			base.GetExtendToggle(6).SetToggleStateForce(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(4).SetUIActive(true);
			UiPanelBase lockPanel = this.LockPanel;
			if (lockPanel != null)
			{
				lockPanel.SetUiActive(!data.IsUnlock);
			}
			MowingBuffLevelPanel levelPanel = this.LevelPanel;
			if (levelPanel != null)
			{
				levelPanel.SetUiActive(data.LevelContent != null);
			}
			MowingBuffLevelPanel levelPanel2 = this.LevelPanel;
			if (levelPanel2 != null)
			{
				levelPanel2.RefreshByLevelContent(data.LevelContent);
			}
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
		}

		// Token: 0x06041999 RID: 268697 RVA: 0x010D1CC9 File Offset: 0x010CFEC9
		private void OnClick(EToggleState _)
		{
			ModelBase<MowingRiskModel>.Instance.CurrentChosenOverviewBuffId = new int?(this.PassData.BuffId);
			Singleton<EventSystem>.Instance.Emit(EEventName.MowingBasicBuffGridItemClick);
		}

		// Token: 0x0604199A RID: 268698 RVA: 0x010D1CF5 File Offset: 0x010CFEF5
		private bool HandleCanExecuteChange()
		{
			return !this.PassData.IsChosen;
		}

		// Token: 0x0604199B RID: 268699 RVA: 0x010D1D05 File Offset: 0x010CFF05
		public bool CheckNeedPlayUnlockSequence()
		{
			return !ModelBase<MowingRiskModel>.Instance.HasBuffIdRecord(this.PassData.BuffId);
		}

		// Token: 0x0604199C RID: 268700 RVA: 0x010D1D20 File Offset: 0x010CFF20
		public void PlayUnlockEffect()
		{
			MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
			instance.RecordBuffId(this.PassData.BuffId);
			EMowingBuffType? buffTypeByBuffId = instance.GetBuffTypeByBuffId(this.PassData.BuffId);
			int? num = null;
			if (buffTypeByBuffId != null)
			{
				switch (buffTypeByBuffId.GetValueOrDefault())
				{
				case EMowingBuffType.BasicLow:
					num = new int?(7);
					break;
				case EMowingBuffType.BasicHigh:
					num = new int?(8);
					break;
				case EMowingBuffType.Super:
					num = new int?(9);
					break;
				}
			}
			if (num != null)
			{
				base.GetItem(num.Value).SetUIActive(true);
			}
		}

		// Token: 0x04024A22 RID: 150050
		private IMowingBuffGridItemData PassData;

		// Token: 0x04024A23 RID: 150051
		[Nullable(2)]
		private UiPanelBase LockPanel;

		// Token: 0x04024A24 RID: 150052
		[Nullable(2)]
		private MowingBuffLevelPanel LevelPanel;

		// Token: 0x0200C6A6 RID: 50854
		[NullableContext(0)]
		private class EItemComponent
		{
			// Token: 0x0403D2A2 RID: 250530
			public const int QualitySprite = 0;

			// Token: 0x0403D2A3 RID: 250531
			public const int ItemTexture = 1;

			// Token: 0x0403D2A4 RID: 250532
			public const int BottomText = 2;

			// Token: 0x0403D2A5 RID: 250533
			public const int BgSprite = 3;

			// Token: 0x0403D2A6 RID: 250534
			public const int TopAdditionItem = 4;

			// Token: 0x0403D2A7 RID: 250535
			public const int BottomAdditionItem = 5;

			// Token: 0x0403D2A8 RID: 250536
			public const int ExtendToggle = 6;

			// Token: 0x0403D2A9 RID: 250537
			public const int UnlockBlueEffectItem = 7;

			// Token: 0x0403D2AA RID: 250538
			public const int UnlockPurpleEffectItem = 8;

			// Token: 0x0403D2AB RID: 250539
			public const int UnlockGoldEffectItem = 9;
		}
	}
}
