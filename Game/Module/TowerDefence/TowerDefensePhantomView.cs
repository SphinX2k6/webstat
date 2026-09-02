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

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED8 RID: 20184
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomView : UiViewBase
	{
		// Token: 0x06034224 RID: 213540 RVA: 0x00D08DCA File Offset: 0x00D06FCA
		public TowerDefensePhantomView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034225 RID: 213541 RVA: 0x00D08DD4 File Offset: 0x00D06FD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034226 RID: 213542 RVA: 0x00D09050 File Offset: 0x00D07250
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseOnClickOnePhantom, new Action<int>(this.HandleClickOnePhantom));
			Singleton<EventSystem>.Instance.Add(EEventName.DissolvePrewar, new Action(this.HandleDissolvePrewar));
			Singleton<EventSystem>.Instance.Add(EEventName.TowerDefensePhantomChanged, new Action(this.HandleTowerDefensePhantomChanged));
		}

		// Token: 0x06034227 RID: 213543 RVA: 0x00D090B4 File Offset: 0x00D072B4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseOnClickOnePhantom, new Action<int>(this.HandleClickOnePhantom));
			Singleton<EventSystem>.Instance.Remove(EEventName.DissolvePrewar, new Action(this.HandleDissolvePrewar));
			Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefensePhantomChanged, new Action(this.HandleTowerDefensePhantomChanged));
		}

		// Token: 0x06034228 RID: 213544 RVA: 0x00D09118 File Offset: 0x00D07318
		private UniTask InitLockItem()
		{
			TowerDefensePhantomView.<InitLockItem>d__8 <InitLockItem>d__;
			<InitLockItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLockItem>d__.<>4__this = this;
			<InitLockItem>d__.<>1__state = -1;
			<InitLockItem>d__.<>t__builder.Start<TowerDefensePhantomView.<InitLockItem>d__8>(ref <InitLockItem>d__);
			return <InitLockItem>d__.<>t__builder.Task;
		}

		// Token: 0x06034229 RID: 213545 RVA: 0x00D0915C File Offset: 0x00D0735C
		private UniTask InitPhantomIconScroll()
		{
			TowerDefensePhantomView.<InitPhantomIconScroll>d__9 <InitPhantomIconScroll>d__;
			<InitPhantomIconScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPhantomIconScroll>d__.<>4__this = this;
			<InitPhantomIconScroll>d__.<>1__state = -1;
			<InitPhantomIconScroll>d__.<>t__builder.Start<TowerDefensePhantomView.<InitPhantomIconScroll>d__9>(ref <InitPhantomIconScroll>d__);
			return <InitPhantomIconScroll>d__.<>t__builder.Task;
		}

		// Token: 0x0603422A RID: 213546 RVA: 0x00D091A0 File Offset: 0x00D073A0
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefensePhantomView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefensePhantomView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603422B RID: 213547 RVA: 0x00D091E3 File Offset: 0x00D073E3
		protected override void OnBeforeDestroy()
		{
			this.Args = null;
		}

		// Token: 0x0603422C RID: 213548 RVA: 0x00D091EC File Offset: 0x00D073EC
		private UniTask RefreshIconScroll(bool isFirstTime)
		{
			TowerDefensePhantomView.<RefreshIconScroll>d__12 <RefreshIconScroll>d__;
			<RefreshIconScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshIconScroll>d__.<>4__this = this;
			<RefreshIconScroll>d__.isFirstTime = isFirstTime;
			<RefreshIconScroll>d__.<>1__state = -1;
			<RefreshIconScroll>d__.<>t__builder.Start<TowerDefensePhantomView.<RefreshIconScroll>d__12>(ref <RefreshIconScroll>d__);
			return <RefreshIconScroll>d__.<>t__builder.Task;
		}

		// Token: 0x0603422D RID: 213549 RVA: 0x00D09238 File Offset: 0x00D07438
		private void RefreshSkillItems()
		{
			List<ITowerDefensePhantomSkillItemData> list = ControllerBase<TowerDefenseController>.Instance.BuildPhantomSkillLayoutData();
			ITowerDefensePhantomSkillItemData data = (list.Count > 0) ? list[0] : null;
			ITowerDefensePhantomSkillItemData data2 = (list.Count > 1) ? list[list.Count - 1] : null;
			this.RefreshOneSkillItem(10, 11, 12, data);
			this.RefreshOneSkillItem(13, 14, 15, data2);
		}

		// Token: 0x0603422E RID: 213550 RVA: 0x00D0929C File Offset: 0x00D0749C
		[NullableContext(2)]
		private void RefreshOneSkillItem(int itemComp, int titleComp, int descComp, ITowerDefensePhantomSkillItemData data)
		{
			UUIItem item = base.GetItem(itemComp);
			if (data == null)
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return;
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(titleComp);
			if (StringUtils.IsEmpty(data.SkillTextId))
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
			}
			else
			{
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.SkillTextId, Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(descComp), data.DescriptionTextId, data.DescriptionArgs);
		}

		// Token: 0x0603422F RID: 213551 RVA: 0x00D0932C File Offset: 0x00D0752C
		private void RefreshConfirmButton(bool isLocked)
		{
			if (isLocked)
			{
				this.ConfirmButtonItem.SetUiActive(false);
				this.ConfirmButtonItem.SetLocalTextNew("TowerDefence_lock", Array.Empty<object>());
				return;
			}
			if (!ControllerBase<TowerDefenseController>.Instance.CheckCurrentPhantomIsOccupiedInUi())
			{
				this.ConfirmButtonItem.SetUiActive(true);
				this.ConfirmButtonItem.SetEnableClick(true);
				this.ConfirmButtonItem.SetFunction(new Action<int>(this.HandleClickConfirmPhantom));
				this.ConfirmButtonItem.SetLocalTextNew("TowerDefence_confirm", Array.Empty<object>());
				return;
			}
			if (ControllerBase<TowerDefenseController>.Instance.CheckSelfPhantomCancelAble(this.Args.RoleCfgId))
			{
				this.ConfirmButtonItem.SetUiActive(true);
				this.ConfirmButtonItem.SetEnableClick(true);
				this.ConfirmButtonItem.SetLocalTextNew("Text_GoDownText_Text", Array.Empty<object>());
				this.ConfirmButtonItem.SetFunction(new Action<int>(this.HandleClickCancelPhantom));
				return;
			}
			this.ConfirmButtonItem.SetUiActive(true);
			this.ConfirmButtonItem.SetEnableClick(false);
			this.ConfirmButtonItem.SetLocalTextNew("PrefabTextItem_266690258_Text", Array.Empty<object>());
		}

		// Token: 0x06034230 RID: 213552 RVA: 0x00D09438 File Offset: 0x00D07638
		private void RefreshOther()
		{
			ITowerDefensePhantomOtherData towerDefensePhantomOtherData = ControllerBase<TowerDefenseController>.Instance.BuildPhantomOtherData();
			if (towerDefensePhantomOtherData != null)
			{
				bool isLocked = towerDefensePhantomOtherData.IsLocked;
				this.ConfirmButtonItem.SetUiActive(!isLocked);
				this.RefreshConfirmButton(isLocked);
				this.PhantomLockItem.SetUiActive(isLocked);
				this.SetSpriteByPath(towerDefensePhantomOtherData.TypeIconPath, base.GetSprite(4), false, null, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), towerDefensePhantomOtherData.TypeTextId, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), towerDefensePhantomOtherData.NameTextId, Array.Empty<object>());
			}
		}

		// Token: 0x06034231 RID: 213553 RVA: 0x00D094D4 File Offset: 0x00D076D4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (this.PhantomIconScroll == null)
			{
				return null;
			}
			UUIItem grid = this.PhantomIconScroll.GetGrid(0);
			if (grid == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				grid,
				grid
			};
		}

		// Token: 0x06034232 RID: 213554 RVA: 0x00D0950B File Offset: 0x00D0770B
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06034233 RID: 213555 RVA: 0x00D09514 File Offset: 0x00D07714
		private void HandleClickOnePhantom(int id)
		{
			ControllerBase<TowerDefenseController>.Instance.SetCurrentTowerDefensePhantomIdInUiTemp(id);
			this.RefreshIconScroll(false);
			this.RefreshSkillItems();
			this.RefreshOther();
		}

		// Token: 0x06034234 RID: 213556 RVA: 0x00D09538 File Offset: 0x00D07738
		private void HandleClickConfirmPhantom(int _)
		{
			int roleCfgId = this.Args.RoleCfgId;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.TowerDefenseSelfPhantomConfirm, roleCfgId);
			base.CloseMe(null);
		}

		// Token: 0x06034235 RID: 213557 RVA: 0x00D0956C File Offset: 0x00D0776C
		private void HandleClickCancelPhantom(int _)
		{
			int roleCfgId = this.Args.RoleCfgId;
			ControllerBase<TowerDefenseController>.Instance.SetCurrentTowerDefensePhantomIdInUiTemp(0);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.TowerDefenseSelfPhantomConfirm, roleCfgId);
			base.CloseMe(null);
		}

		// Token: 0x06034236 RID: 213558 RVA: 0x00D095A8 File Offset: 0x00D077A8
		private void HandleDissolvePrewar()
		{
			base.CloseMe(null);
		}

		// Token: 0x06034237 RID: 213559 RVA: 0x00D095B1 File Offset: 0x00D077B1
		private void HandleTowerDefensePhantomChanged()
		{
			this.RefreshIconScroll(false);
			this.RefreshOther();
		}

		// Token: 0x0401E1B6 RID: 123318
		[Nullable(2)]
		private ITowerDefensePhantomViewArgs Args;

		// Token: 0x0401E1B7 RID: 123319
		private ButtonItem ConfirmButtonItem;

		// Token: 0x0401E1B8 RID: 123320
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<TowerDefencePhantomIconItem, PhantomSmallItemGrid> PhantomIconScroll;

		// Token: 0x0401E1B9 RID: 123321
		[Nullable(2)]
		private TowerDefensePhantomLockItem PhantomLockItem;

		// Token: 0x0200AE80 RID: 44672
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x040362E2 RID: 221922
			public const int CloseButton = 0;

			// Token: 0x040362E3 RID: 221923
			public const int PhantomIconScroll = 1;

			// Token: 0x040362E4 RID: 221924
			public const int PhantomIconItem = 2;

			// Token: 0x040362E5 RID: 221925
			public const int NameText = 3;

			// Token: 0x040362E6 RID: 221926
			public const int TypeSprite = 4;

			// Token: 0x040362E7 RID: 221927
			public const int TypeText = 5;

			// Token: 0x040362E8 RID: 221928
			public const int PhantomSkillLayout = 6;

			// Token: 0x040362E9 RID: 221929
			public const int ConfirmButtonItem = 7;

			// Token: 0x040362EA RID: 221930
			public const int PhantomTipsItem = 8;

			// Token: 0x040362EB RID: 221931
			public const int PhantomLockItem = 9;

			// Token: 0x040362EC RID: 221932
			public const int NormalSkillItem = 10;

			// Token: 0x040362ED RID: 221933
			public const int NormalSkillTitleText = 11;

			// Token: 0x040362EE RID: 221934
			public const int NormalSkillDescText = 12;

			// Token: 0x040362EF RID: 221935
			public const int AdvancedSkillItem = 13;

			// Token: 0x040362F0 RID: 221936
			public const int AdvancedSkillTitleText = 14;

			// Token: 0x040362F1 RID: 221937
			public const int AdvancedSkillDescText = 15;
		}
	}
}
