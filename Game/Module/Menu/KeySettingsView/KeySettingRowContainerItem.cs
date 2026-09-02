using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C8 RID: 22472
	[NullableContext(1)]
	[Nullable(0)]
	public class KeySettingRowContainerItem : UiPanelBase, IDynamicScrollItem<KeySettingRowData>
	{
		// Token: 0x060391D6 RID: 233942 RVA: 0x00E797FC File Offset: 0x00E779FC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060391D7 RID: 233943 RVA: 0x00E79858 File Offset: 0x00E77A58
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnStateChanged));
			}
			if (extendToggle != null)
			{
				extendToggle.OnHover.Add(new Action(this.OnHover));
			}
			if (extendToggle != null)
			{
				extendToggle.OnUnHover.Add(new Action(this.OnUnHover));
			}
			this.SetActive(true);
		}

		// Token: 0x060391D8 RID: 233944 RVA: 0x00E798CC File Offset: 0x00E77ACC
		protected override void OnBeforeDestroy()
		{
			this.KeySettingRowData = null;
			this.KeySettingRowKeyItem = null;
			this.KeySettingRowTypeItem = null;
			this.OnWaitInput = null;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnStateChanged));
			}
			if (extendToggle != null)
			{
				extendToggle.OnHover.Remove(new Action(this.OnHover));
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnUnHover.Remove(new Action(this.OnUnHover));
		}

		// Token: 0x060391D9 RID: 233945 RVA: 0x00E79951 File Offset: 0x00E77B51
		private void OnStateChanged(EToggleState state)
		{
			Action<KeySettingRowContainerItem, EToggleState> onToggleStateChanged = this.OnToggleStateChanged;
			if (onToggleStateChanged == null)
			{
				return;
			}
			onToggleStateChanged(this, state);
		}

		// Token: 0x060391DA RID: 233946 RVA: 0x00E79965 File Offset: 0x00E77B65
		private void OnHover()
		{
			Action<KeySettingRowData> onHoverCallback = this.OnHoverCallback;
			if (onHoverCallback == null)
			{
				return;
			}
			onHoverCallback(this.KeySettingRowData);
		}

		// Token: 0x060391DB RID: 233947 RVA: 0x00E7997D File Offset: 0x00E77B7D
		private void OnUnHover()
		{
			Action<KeySettingRowData> onUnHoverCallback = this.OnUnHoverCallback;
			if (onUnHoverCallback == null)
			{
				return;
			}
			onUnHoverCallback(this.KeySettingRowData);
		}

		// Token: 0x060391DC RID: 233948 RVA: 0x00E79995 File Offset: 0x00E77B95
		public void BindOnToggleStateChanged(Action<KeySettingRowContainerItem, EToggleState> onToggleStateChanged)
		{
			this.OnToggleStateChanged = onToggleStateChanged;
		}

		// Token: 0x060391DD RID: 233949 RVA: 0x00E7999E File Offset: 0x00E77B9E
		public void BindOnHover([Nullable(new byte[]
		{
			1,
			2
		})] Action<KeySettingRowData> onHoverCallback)
		{
			this.OnHoverCallback = onHoverCallback;
		}

		// Token: 0x060391DE RID: 233950 RVA: 0x00E799A7 File Offset: 0x00E77BA7
		public void BindOnUnHover([Nullable(new byte[]
		{
			1,
			2
		})] Action<KeySettingRowData> onUnHoverCallback)
		{
			this.OnUnHoverCallback = onUnHoverCallback;
		}

		// Token: 0x060391DF RID: 233951 RVA: 0x00E799B0 File Offset: 0x00E77BB0
		public UniTask Init(UUIItem actor)
		{
			KeySettingRowContainerItem.<Init>d__17 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<KeySettingRowContainerItem.<Init>d__17>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060391E0 RID: 233952 RVA: 0x00E799FB File Offset: 0x00E77BFB
		public void ClearItem()
		{
			this.KeySettingRowData = null;
		}

		// Token: 0x060391E1 RID: 233953 RVA: 0x00E79A04 File Offset: 0x00E77C04
		public void Update(KeySettingRowData data, int index)
		{
			EInputControllerType keySettingInputControllerType = ModelBase<MenuModel>.Instance.KeySettingInputControllerType;
			this.KeySettingRowData = data;
			EKeySettingRowType rowType = data.GetRowType();
			if (rowType != EKeySettingRowType.KeyType)
			{
				if (rowType == EKeySettingRowType.KeySetting)
				{
					UUIExtendToggle extendToggle = base.GetExtendToggle(0);
					if (extendToggle != null)
					{
						extendToggle.SetSelfInteractive(true);
					}
					this.KeySettingRowKeyItem.Refresh(data, keySettingInputControllerType);
					base.GetItem(2).SetUIActive(true);
					base.GetItem(1).SetUIActive(false);
				}
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
				if (extendToggle2 != null)
				{
					extendToggle2.SetSelfInteractive(false);
				}
				this.KeySettingRowTypeItem.Refresh(data);
				base.GetItem(2).SetUIActive(false);
				base.GetItem(1).SetUIActive(true);
			}
			this.SetSelected(false);
			this.SetToggleState(data.IsExpandDetail);
		}

		// Token: 0x060391E2 RID: 233954 RVA: 0x00E79ABC File Offset: 0x00E77CBC
		private UniTask NewKeySettingRowKeyItem()
		{
			KeySettingRowContainerItem.<NewKeySettingRowKeyItem>d__20 <NewKeySettingRowKeyItem>d__;
			<NewKeySettingRowKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewKeySettingRowKeyItem>d__.<>4__this = this;
			<NewKeySettingRowKeyItem>d__.<>1__state = -1;
			<NewKeySettingRowKeyItem>d__.<>t__builder.Start<KeySettingRowContainerItem.<NewKeySettingRowKeyItem>d__20>(ref <NewKeySettingRowKeyItem>d__);
			return <NewKeySettingRowKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x060391E3 RID: 233955 RVA: 0x00E79AFF File Offset: 0x00E77CFF
		private void OnWaitKeyInput(KeySettingRowData keySettingRowData, KeySettingRowKeyItem keySettingRowKeyItem)
		{
			Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem> onWaitInput = this.OnWaitInput;
			if (onWaitInput == null)
			{
				return;
			}
			onWaitInput(keySettingRowData, keySettingRowKeyItem, this);
		}

		// Token: 0x060391E4 RID: 233956 RVA: 0x00E79B14 File Offset: 0x00E77D14
		public void BindOnWaitInput(Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem> onWaitInput)
		{
			this.OnWaitInput = onWaitInput;
		}

		// Token: 0x060391E5 RID: 233957 RVA: 0x00E79B20 File Offset: 0x00E77D20
		private UniTask NewKeySettingRowTypeItem()
		{
			KeySettingRowContainerItem.<NewKeySettingRowTypeItem>d__23 <NewKeySettingRowTypeItem>d__;
			<NewKeySettingRowTypeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewKeySettingRowTypeItem>d__.<>4__this = this;
			<NewKeySettingRowTypeItem>d__.<>1__state = -1;
			<NewKeySettingRowTypeItem>d__.<>t__builder.Start<KeySettingRowContainerItem.<NewKeySettingRowTypeItem>d__23>(ref <NewKeySettingRowTypeItem>d__);
			return <NewKeySettingRowTypeItem>d__.<>t__builder.Task;
		}

		// Token: 0x060391E6 RID: 233958 RVA: 0x00E79B64 File Offset: 0x00E77D64
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(KeySettingRowData data)
		{
			EKeySettingRowType rowType = data.GetRowType();
			if (rowType == EKeySettingRowType.KeyType)
			{
				return base.GetItem(1).GetOwner() as AUIBaseActor;
			}
			if (rowType != EKeySettingRowType.KeySetting)
			{
				return null;
			}
			return base.GetItem(2).GetOwner() as AUIBaseActor;
		}

		// Token: 0x060391E7 RID: 233959 RVA: 0x00E79BA7 File Offset: 0x00E77DA7
		public void SetSelected(bool bSelected)
		{
			KeySettingRowKeyItem keySettingRowKeyItem = this.KeySettingRowKeyItem;
			if (keySettingRowKeyItem == null)
			{
				return;
			}
			keySettingRowKeyItem.SetSelected(bSelected);
		}

		// Token: 0x060391E8 RID: 233960 RVA: 0x00E79BBA File Offset: 0x00E77DBA
		public void SetDetailItemVisible(bool bVisible)
		{
			KeySettingRowKeyItem keySettingRowKeyItem = this.KeySettingRowKeyItem;
			if (keySettingRowKeyItem != null)
			{
				keySettingRowKeyItem.SetDetailItemVisible(bVisible);
			}
			this.SetToggleState(bVisible);
		}

		// Token: 0x060391E9 RID: 233961 RVA: 0x00E79BD5 File Offset: 0x00E77DD5
		private void SetToggleState(bool bChecked)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(bChecked ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x04020831 RID: 133169
		[Nullable(2)]
		public KeySettingRowData KeySettingRowData;

		// Token: 0x04020832 RID: 133170
		[Nullable(2)]
		private KeySettingRowKeyItem KeySettingRowKeyItem;

		// Token: 0x04020833 RID: 133171
		[Nullable(2)]
		private KeySettingRowTypeItem KeySettingRowTypeItem;

		// Token: 0x04020834 RID: 133172
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private Action<KeySettingRowData, KeySettingRowKeyItem, KeySettingRowContainerItem> OnWaitInput;

		// Token: 0x04020835 RID: 133173
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<KeySettingRowContainerItem, EToggleState> OnToggleStateChanged;

		// Token: 0x04020836 RID: 133174
		[Nullable(2)]
		private Action<KeySettingRowData> OnHoverCallback;

		// Token: 0x04020837 RID: 133175
		[Nullable(2)]
		private Action<KeySettingRowData> OnUnHoverCallback;

		// Token: 0x0200B849 RID: 47177
		[NullableContext(0)]
		public class EChildType
		{
			// Token: 0x04038FFA RID: 233466
			public const int Toggle = 0;

			// Token: 0x04038FFB RID: 233467
			public const int KeyTypeItem = 1;

			// Token: 0x04038FFC RID: 233468
			public const int KeySettingItem = 2;
		}
	}
}
