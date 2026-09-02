using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C5 RID: 22469
	[NullableContext(1)]
	[Nullable(0)]
	public class KeySettingPanel : UiPanelBase
	{
		// Token: 0x060391BB RID: 233915 RVA: 0x00E79308 File Offset: 0x00E77508
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x060391BC RID: 233916 RVA: 0x00E79344 File Offset: 0x00E77544
		protected override UniTask OnBeforeStartAsync()
		{
			KeySettingPanel.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KeySettingPanel.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060391BD RID: 233917 RVA: 0x00E79387 File Offset: 0x00E77587
		protected override void OnBeforeDestroy()
		{
			this.KeySettingRowBaseItem = null;
			this.DynamicScrollView = null;
			this.DetailEnableKeySettingRow = null;
			this.SelectedKeySettingRow = null;
			this.OnWaitInput = null;
			this.KeySettingScrollingFlag = 0;
		}

		// Token: 0x060391BE RID: 233918 RVA: 0x00E793B4 File Offset: 0x00E775B4
		private KeySettingRowContainerItem OnItemCreate(KeySettingRowData data, UUIItem uiItem, int index)
		{
			KeySettingRowContainerItem keySettingRowContainerItem = new KeySettingRowContainerItem();
			keySettingRowContainerItem.BindOnToggleStateChanged(new Action<KeySettingRowContainerItem, EToggleState>(this.OnToggleStateChanged));
			keySettingRowContainerItem.BindOnHover(new Action<KeySettingRowData>(this.OnHover));
			keySettingRowContainerItem.BindOnUnHover(new Action<KeySettingRowData>(this.OnUnHover));
			keySettingRowContainerItem.BindOnWaitInput(new Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem>(this.OnWaitKeyInput));
			return keySettingRowContainerItem;
		}

		// Token: 0x060391BF RID: 233919 RVA: 0x00E7940E File Offset: 0x00E7760E
		private void OnToggleStateChanged(KeySettingRowContainerItem keySettingRowContainerItem, EToggleState state)
		{
			if (state == EToggleState.ETT_UnChecked)
			{
				keySettingRowContainerItem.SetDetailItemVisible(false);
				this.DetailEnableKeySettingRow = null;
				return;
			}
			KeySettingRowContainerItem detailEnableKeySettingRow = this.DetailEnableKeySettingRow;
			if (detailEnableKeySettingRow != null)
			{
				detailEnableKeySettingRow.SetDetailItemVisible(false);
			}
			this.DetailEnableKeySettingRow = keySettingRowContainerItem;
			this.DetailEnableKeySettingRow.SetDetailItemVisible(true);
		}

		// Token: 0x060391C0 RID: 233920 RVA: 0x00E79447 File Offset: 0x00E77647
		[NullableContext(2)]
		private void OnHover(KeySettingRowData keySettingRowData)
		{
			Action<KeySettingRowData> onHoverCallback = this.OnHoverCallback;
			if (onHoverCallback == null)
			{
				return;
			}
			onHoverCallback(keySettingRowData);
		}

		// Token: 0x060391C1 RID: 233921 RVA: 0x00E7945A File Offset: 0x00E7765A
		[NullableContext(2)]
		private void OnUnHover(KeySettingRowData keySettingRowData)
		{
			Action<KeySettingRowData> onUnHoverCallback = this.OnUnHoverCallback;
			if (onUnHoverCallback == null)
			{
				return;
			}
			onUnHoverCallback(keySettingRowData);
		}

		// Token: 0x060391C2 RID: 233922 RVA: 0x00E7946D File Offset: 0x00E7766D
		private void OnWaitKeyInput(KeySettingRowData keySettingRowData, KeySettingRowKeyItem keySettingRowKeyItem, KeySettingRowContainerItem keySettingRowContainerItem)
		{
			Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem> onWaitInput = this.OnWaitInput;
			if (onWaitInput == null)
			{
				return;
			}
			onWaitInput(keySettingRowData, keySettingRowKeyItem, keySettingRowContainerItem);
		}

		// Token: 0x060391C3 RID: 233923 RVA: 0x00E79482 File Offset: 0x00E77682
		[NullableContext(2)]
		public void SelectKeySettingRow(KeySettingRowContainerItem keySettingRowContainerItem = null)
		{
			KeySettingRowContainerItem selectedKeySettingRow = this.SelectedKeySettingRow;
			if (selectedKeySettingRow != null)
			{
				selectedKeySettingRow.SetSelected(false);
			}
			this.SelectedKeySettingRow = keySettingRowContainerItem;
			KeySettingRowContainerItem selectedKeySettingRow2 = this.SelectedKeySettingRow;
			if (selectedKeySettingRow2 == null)
			{
				return;
			}
			selectedKeySettingRow2.SetSelected(true);
		}

		// Token: 0x060391C4 RID: 233924 RVA: 0x00E794AE File Offset: 0x00E776AE
		public void BindOnWaitInput(Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem> onWaitInput)
		{
			this.OnWaitInput = onWaitInput;
		}

		// Token: 0x060391C5 RID: 233925 RVA: 0x00E794B7 File Offset: 0x00E776B7
		public void BindOnHover([Nullable(new byte[]
		{
			1,
			2
		})] Action<KeySettingRowData> onHoverCallback)
		{
			this.OnHoverCallback = onHoverCallback;
		}

		// Token: 0x060391C6 RID: 233926 RVA: 0x00E794C0 File Offset: 0x00E776C0
		public void BindOnUnHover([Nullable(new byte[]
		{
			1,
			2
		})] Action<KeySettingRowData> onUnHoverCallback)
		{
			this.OnUnHoverCallback = onUnHoverCallback;
		}

		// Token: 0x060391C7 RID: 233927 RVA: 0x00E794CC File Offset: 0x00E776CC
		public void Refresh(List<KeySettingRowData> keySettingRowDataList, EInputControllerType inputControllerType)
		{
			foreach (KeySettingRowData keySettingRowData in keySettingRowDataList)
			{
				keySettingRowData.IsExpandDetail = false;
			}
			ModelBase<MenuModel>.Instance.KeySettingInputControllerType = inputControllerType;
			DynamicScrollView<KeySettingRowContainerItem, KeySettingRowBaseItem, KeySettingRowData> dynamicScrollView = this.DynamicScrollView;
			if (dynamicScrollView != null)
			{
				dynamicScrollView.RefreshByData(keySettingRowDataList.ToArray(), false, false);
			}
			this.KeySettingRowDataList = keySettingRowDataList;
			this.DetailEnableKeySettingRow = null;
		}

		// Token: 0x060391C8 RID: 233928 RVA: 0x00E7954C File Offset: 0x00E7774C
		public void RefreshRow(KeySettingRowData keySettingRowData)
		{
			int index = this.KeySettingRowDataList.IndexOf(keySettingRowData);
			DynamicScrollView<KeySettingRowContainerItem, KeySettingRowBaseItem, KeySettingRowData> dynamicScrollView = this.DynamicScrollView;
			KeySettingRowContainerItem keySettingRowContainerItem = (dynamicScrollView != null) ? dynamicScrollView.GetScrollItemFromIndex(index) : null;
			if (keySettingRowContainerItem == null)
			{
				return;
			}
			keySettingRowContainerItem.Update(keySettingRowData, index);
		}

		// Token: 0x060391C9 RID: 233929 RVA: 0x00E79588 File Offset: 0x00E77788
		[return: Nullable(2)]
		public KeySettingRowContainerItem GetRowByData(KeySettingRowData data, bool needScrollTo = false)
		{
			int num = this.KeySettingRowDataList.IndexOf(data);
			DynamicScrollView<KeySettingRowContainerItem, KeySettingRowBaseItem, KeySettingRowData> dynamicScrollView = this.DynamicScrollView;
			if (dynamicScrollView == null)
			{
				return null;
			}
			if (needScrollTo && this.KeySettingScrollingFlag == 0)
			{
				this.KeySettingScrollingFlag = 1;
				dynamicScrollView.ScrollToItemIndex(num - 3, true, false).ContinueWith(delegate()
				{
					this.KeySettingScrollingFlag = 2;
				});
			}
			if (this.KeySettingScrollingFlag == 1)
			{
				return null;
			}
			this.KeySettingScrollingFlag = 0;
			dynamicScrollView.AddListenerOnItemClear(num, delegate
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "MenuView");
			});
			return dynamicScrollView.GetScrollItemFromIndex(num);
		}

		// Token: 0x060391CA RID: 233930 RVA: 0x00E7961C File Offset: 0x00E7781C
		public void StopScroll()
		{
			base.GetUIDynScrollViewComponent(0).StopMovement();
		}

		// Token: 0x04020827 RID: 133159
		private const int SCROLL_TO_OFFSET = 3;

		// Token: 0x04020828 RID: 133160
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<KeySettingRowContainerItem, KeySettingRowBaseItem, KeySettingRowData> DynamicScrollView;

		// Token: 0x04020829 RID: 133161
		[Nullable(2)]
		private KeySettingRowBaseItem KeySettingRowBaseItem;

		// Token: 0x0402082A RID: 133162
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem> OnWaitInput;

		// Token: 0x0402082B RID: 133163
		[Nullable(2)]
		private Action<KeySettingRowData> OnHoverCallback;

		// Token: 0x0402082C RID: 133164
		[Nullable(2)]
		private Action<KeySettingRowData> OnUnHoverCallback;

		// Token: 0x0402082D RID: 133165
		[Nullable(2)]
		private KeySettingRowContainerItem DetailEnableKeySettingRow;

		// Token: 0x0402082E RID: 133166
		[Nullable(2)]
		private KeySettingRowContainerItem SelectedKeySettingRow;

		// Token: 0x0402082F RID: 133167
		private List<KeySettingRowData> KeySettingRowDataList = new List<KeySettingRowData>();

		// Token: 0x04020830 RID: 133168
		private int KeySettingScrollingFlag;

		// Token: 0x0200B843 RID: 47171
		[NullableContext(0)]
		public class EChildType
		{
			// Token: 0x04038FE7 RID: 233447
			public const int DynamicScrollView = 0;

			// Token: 0x04038FE8 RID: 233448
			public const int TemplateItem = 1;
		}
	}
}
