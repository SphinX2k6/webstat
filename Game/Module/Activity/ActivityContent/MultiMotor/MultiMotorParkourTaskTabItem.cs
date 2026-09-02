using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006662 RID: 26210
	public class MultiMotorParkourTaskTabItem : GridProxyAbstract<int>
	{
		// Token: 0x06041737 RID: 268087 RVA: 0x010CC4C8 File Offset: 0x010CA6C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041738 RID: 268088 RVA: 0x010CC5D1 File Offset: 0x010CA7D1
		protected override void OnStart()
		{
			base.GetExtendToggle(0).bLockStateOnSelect = true;
		}

		// Token: 0x06041739 RID: 268089 RVA: 0x010CC5E0 File Offset: 0x010CA7E0
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (data == 0)
			{
				this.RefreshAsGlobalTab();
				return;
			}
			this.RefreshAsLevelTab(data);
		}

		// Token: 0x0604173A RID: 268090 RVA: 0x010CC5FC File Offset: 0x010CA7FC
		private void RefreshAsGlobalTab()
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComRomeText_05");
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, delegate(bool _)
			{
				base.GetUiExtendToggleSpriteTransition(3).SetAllStateSprite(base.GetSprite(1).GetSprite());
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "MultiMotorGlobalTask", Array.Empty<object>());
			MultiMotorData activityData = this.ActivityData;
			bool uiactive = activityData != null && activityData.HasGlobalRewardRedDot;
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0604173B RID: 268091 RVA: 0x010CC690 File Offset: 0x010CA890
		private void RefreshAsLevelTab(int levelId)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			MultiMotorLevelData multiMotorLevelData = null;
			MultiMotorData activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.LevelDataMap.TryGetValue(levelId, out multiMotorLevelData);
			}
			OnlineMotorLevel? onlineMotorLevel = (multiMotorLevelData != null) ? multiMotorLevelData.Config : null;
			if (onlineMotorLevel == null)
			{
				return;
			}
			this.SetSpriteByPath(onlineMotorLevel.Value.LevelRomanSprite, base.GetSprite(1), false, null, delegate(bool _)
			{
				base.GetUiExtendToggleSpriteTransition(3).SetAllStateSprite(base.GetSprite(1).GetSprite());
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), onlineMotorLevel.Value.Name, Array.Empty<object>());
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(multiMotorLevelData != null && multiMotorLevelData.HasRewardRedDot);
		}

		// Token: 0x0604173C RID: 268092 RVA: 0x010CC760 File Offset: 0x010CA960
		private void OnToggleClick(EToggleState _)
		{
			Action<int> onToggleCallback = this.OnToggleCallback;
			if (onToggleCallback == null)
			{
				return;
			}
			onToggleCallback(this.Data);
		}

		// Token: 0x0604173D RID: 268093 RVA: 0x010CC778 File Offset: 0x010CA978
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0604173E RID: 268094 RVA: 0x010CC790 File Offset: 0x010CA990
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0604173F RID: 268095 RVA: 0x010CC7A8 File Offset: 0x010CA9A8
		[NullableContext(1)]
		public override object GetKey(int data, int displayIndex)
		{
			return data;
		}

		// Token: 0x0402498A RID: 149898
		private int Data;

		// Token: 0x0402498B RID: 149899
		[Nullable(2)]
		public MultiMotorData ActivityData;

		// Token: 0x0402498C RID: 149900
		[Nullable(1)]
		public Action<int> OnToggleCallback = delegate(int data)
		{
		};

		// Token: 0x0200C686 RID: 50822
		private class EComponents
		{
			// Token: 0x0403D209 RID: 250377
			public const int ToggleRoot = 0;

			// Token: 0x0403D20A RID: 250378
			public const int SpriteNum = 1;

			// Token: 0x0403D20B RID: 250379
			public const int TextName = 2;

			// Token: 0x0403D20C RID: 250380
			public const int SpriteTransitionNum = 3;

			// Token: 0x0403D20D RID: 250381
			public const int ItemRedDot = 4;
		}
	}
}
