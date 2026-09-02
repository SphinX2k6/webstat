using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.ItemGrid
{
	// Token: 0x02005E6E RID: 24174
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonItemSimpleGrid : GridProxyAbstract<TItem>
	{
		// Token: 0x0603CCBE RID: 249022 RVA: 0x00F6FE73 File Offset: 0x00F6E073
		public int GetItemId()
		{
			return this.ItemConfigId;
		}

		// Token: 0x0603CCBF RID: 249023 RVA: 0x00F6FE7B File Offset: 0x00F6E07B
		public CommonItemSimpleGrid()
		{
			this.ClickCallback = delegate(int itemConfigId)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemConfigId, true, null);
			};
		}

		// Token: 0x0603CCC0 RID: 249024 RVA: 0x00F6FEB4 File Offset: 0x00F6E0B4
		public CommonItemSimpleGrid(AActor commonItemActor = null)
		{
			this.ClickCallback = delegate(int itemConfigId)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemConfigId, true, null);
			};
			if (commonItemActor != null)
			{
				this.CreateThenShowByActor(commonItemActor);
			}
		}

		// Token: 0x0603CCC1 RID: 249025 RVA: 0x00F6FF04 File Offset: 0x00F6E104
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CCC2 RID: 249026 RVA: 0x00F70070 File Offset: 0x00F6E270
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.CloseItemTips, new Action<int, int>(this.OnCloseItemTips));
		}

		// Token: 0x0603CCC3 RID: 249027 RVA: 0x00F7008E File Offset: 0x00F6E28E
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseItemTips, new Action<int, int>(this.OnCloseItemTips));
		}

		// Token: 0x0603CCC4 RID: 249028 RVA: 0x00F700AC File Offset: 0x00F6E2AC
		private void OnCloseItemTips(int itemId, int i)
		{
			if (itemId != this.ItemConfigId)
			{
				return;
			}
			base.GetExtendToggle(4).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603CCC5 RID: 249029 RVA: 0x00F700C9 File Offset: 0x00F6E2C9
		private void OnToggleClick(EToggleState state)
		{
			if (this.ClickCallback == null)
			{
				return;
			}
			if (state == EToggleState.ETT_Checked)
			{
				this.ClickCallback(this.ItemConfigId);
			}
		}

		// Token: 0x0603CCC6 RID: 249030 RVA: 0x00F700E9 File Offset: 0x00F6E2E9
		public void ResetToggleClick()
		{
			base.GetExtendToggle(4).OnStateChange.Clear();
			base.GetExtendToggle(4).OnStateChange.Add(new Action<EToggleState>(this.OnToggleClick));
		}

		// Token: 0x0603CCC7 RID: 249031 RVA: 0x00F7011C File Offset: 0x00F6E31C
		private void UpdateView()
		{
			UUITexture texture = base.GetTexture(1);
			base.SetItemIcon(texture, this.ItemConfigId, this.BelongViewName, null);
			UUISprite sprite = base.GetSprite(0);
			base.SetItemQualityIcon(sprite, this.ItemConfigId, this.BelongViewName, CommonDefine.EQualityIconType.BackgroundSprite, null);
		}

		// Token: 0x0603CCC8 RID: 249032 RVA: 0x00F70164 File Offset: 0x00F6E364
		public override void Refresh(TItem data, bool isSelect, int gridIndex)
		{
			InventoryDefine.IGetItemData itemData = data.ItemData;
			int count = data.Count;
			this.RefreshItem(itemData.ItemId, count);
		}

		// Token: 0x0603CCC9 RID: 249033 RVA: 0x00F7018C File Offset: 0x00F6E38C
		public void SetQualityActive(bool isShow)
		{
			base.GetSprite(0).SetUIActive(isShow);
		}

		// Token: 0x0603CCCA RID: 249034 RVA: 0x00F7019B File Offset: 0x00F6E39B
		public void SetCanReceiveActive(bool isShow)
		{
			base.GetSprite(5).SetUIActive(false);
		}

		// Token: 0x0603CCCB RID: 249035 RVA: 0x00F701AA File Offset: 0x00F6E3AA
		public void SetLockReceiveActive(bool isShow)
		{
			base.GetSprite(6).SetUIActive(isShow);
		}

		// Token: 0x0603CCCC RID: 249036 RVA: 0x00F701B9 File Offset: 0x00F6E3B9
		public void SetReceivedActive(bool isShow)
		{
			base.GetItem(7).SetUIActive(isShow);
		}

		// Token: 0x0603CCCD RID: 249037 RVA: 0x00F701C8 File Offset: 0x00F6E3C8
		public void SetBelongViewName(EUiViewName viewName)
		{
			this.BelongViewName = new EUiViewName?(viewName);
		}

		// Token: 0x0603CCCE RID: 249038 RVA: 0x00F701D6 File Offset: 0x00F6E3D6
		public void RefreshItem(int itemConfigId, int itemCount = 0)
		{
			this.ItemConfigId = itemConfigId;
			this.UpdateView();
			this.SetCount(itemCount);
		}

		// Token: 0x0603CCCF RID: 249039 RVA: 0x00F701EC File Offset: 0x00F6E3EC
		[NullableContext(1)]
		public void BindClickCallback(Action<int> clickCallback)
		{
			this.ClickCallback = clickCallback;
		}

		// Token: 0x0603CCD0 RID: 249040 RVA: 0x00F701F5 File Offset: 0x00F6E3F5
		private void SetCount(int count = 0)
		{
			if (count == 0)
			{
				this.GetCountItem().SetUIActive(false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(this.GetCountText(), this.CountTextId, new <>z__ReadOnlySingleElementList<object>(count));
			this.GetCountItem().SetUIActive(true);
		}

		// Token: 0x0603CCD1 RID: 249041 RVA: 0x00F70234 File Offset: 0x00F6E434
		private UUIText GetCountText()
		{
			return base.GetText(2);
		}

		// Token: 0x0603CCD2 RID: 249042 RVA: 0x00F7023D File Offset: 0x00F6E43D
		private UUIItem GetCountItem()
		{
			return base.GetItem(3);
		}

		// Token: 0x0603CCD3 RID: 249043 RVA: 0x00F70246 File Offset: 0x00F6E446
		[NullableContext(1)]
		public void SetCountTextId(string textId)
		{
			this.CountTextId = textId;
		}

		// Token: 0x0603CCD4 RID: 249044 RVA: 0x00F70250 File Offset: 0x00F6E450
		public UniTask RefreshItemAsync(int itemConfigId, int itemCount = 0)
		{
			CommonItemSimpleGrid.<RefreshItemAsync>d__27 <RefreshItemAsync>d__;
			<RefreshItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshItemAsync>d__.<>4__this = this;
			<RefreshItemAsync>d__.itemConfigId = itemConfigId;
			<RefreshItemAsync>d__.itemCount = itemCount;
			<RefreshItemAsync>d__.<>1__state = -1;
			<RefreshItemAsync>d__.<>t__builder.Start<CommonItemSimpleGrid.<RefreshItemAsync>d__27>(ref <RefreshItemAsync>d__);
			return <RefreshItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CCD5 RID: 249045 RVA: 0x00F702A4 File Offset: 0x00F6E4A4
		private UniTask UpdateViewAsync()
		{
			CommonItemSimpleGrid.<UpdateViewAsync>d__28 <UpdateViewAsync>d__;
			<UpdateViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateViewAsync>d__.<>4__this = this;
			<UpdateViewAsync>d__.<>1__state = -1;
			<UpdateViewAsync>d__.<>t__builder.Start<CommonItemSimpleGrid.<UpdateViewAsync>d__28>(ref <UpdateViewAsync>d__);
			return <UpdateViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04022260 RID: 139872
		private int ItemConfigId;

		// Token: 0x04022261 RID: 139873
		[Nullable(1)]
		private string CountTextId = "ShowCount";

		// Token: 0x04022262 RID: 139874
		private EUiViewName? BelongViewName;

		// Token: 0x04022263 RID: 139875
		private Action<int> ClickCallback;

		// Token: 0x0200BE7A RID: 48762
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403AA69 RID: 240233
			SpriteQuality,
			// Token: 0x0403AA6A RID: 240234
			TextureIcon,
			// Token: 0x0403AA6B RID: 240235
			TextCount,
			// Token: 0x0403AA6C RID: 240236
			NumItem,
			// Token: 0x0403AA6D RID: 240237
			ToggleClick,
			// Token: 0x0403AA6E RID: 240238
			CanReceiveSprite,
			// Token: 0x0403AA6F RID: 240239
			LockSprite,
			// Token: 0x0403AA70 RID: 240240
			ReceivedItem
		}
	}
}
