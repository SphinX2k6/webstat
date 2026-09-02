using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006611 RID: 26129
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemSyncWeaponGridView : PinballItemView, ISyncGridProxy<IPinballItemSyncWeaponGridViewData>, ISyncGridProxy
	{
		// Token: 0x17009F54 RID: 40788
		// (get) Token: 0x060414A4 RID: 267428 RVA: 0x010BF7D5 File Offset: 0x010BD9D5
		// (set) Token: 0x060414A5 RID: 267429 RVA: 0x010BF7DD File Offset: 0x010BD9DD
		public int GridIndex { get; set; }

		// Token: 0x060414A6 RID: 267430 RVA: 0x010BF7E6 File Offset: 0x010BD9E6
		protected override void OnStart()
		{
			base.OnStart();
			base.GetItemToggle().bLockStateOnSelect = true;
		}

		// Token: 0x060414A7 RID: 267431 RVA: 0x010BF7FC File Offset: 0x010BD9FC
		public void Refresh(IPinballItemSyncWeaponGridViewData data)
		{
			PinballWeaponData weaponData = data.WeaponData;
			this.SyncGridData = data;
			this.RefreshToggleState(true);
			PinballItemDataWeapon data2 = new PinballItemDataWeapon
			{
				Type = EPinballItemType.Weapon,
				Id = weaponData.Id,
				IncId = weaponData.IncId,
				IsUnavailable = new bool?(!data.CanEquip),
				RoleId = new int?(weaponData.RoleId),
				IsLocked = new bool?(weaponData.GetIsLock()),
				IsRecommendedWeapon = new bool?(data.CanEquip && this.CheckIsRecommendedWeapon(weaponData, data.RoleId))
			};
			this.ApplyWithTask(data2);
		}

		// Token: 0x060414A8 RID: 267432 RVA: 0x010BF8A3 File Offset: 0x010BDAA3
		void ISyncGridProxy.Refresh(object data)
		{
			this.Refresh((IPinballItemSyncWeaponGridViewData)data);
		}

		// Token: 0x060414A9 RID: 267433 RVA: 0x010BF8B1 File Offset: 0x010BDAB1
		void ISyncGridProxy.CreateByActor(AActor actor)
		{
			base.CreateByActor(actor, null);
		}

		// Token: 0x060414AA RID: 267434 RVA: 0x010BF8BB File Offset: 0x010BDABB
		void ISyncGridProxy.CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x060414AB RID: 267435 RVA: 0x010BF8C8 File Offset: 0x010BDAC8
		private bool CheckIsRecommendedWeapon(PinballWeaponData weaponData, int roleId)
		{
			if (weaponData.RoleId != 0)
			{
				return false;
			}
			int roleWeaponMaxQuality = ModelBase<PinballModel>.Instance.ActivityData.GetRoleWeaponMaxQuality(roleId);
			return weaponData.Quality == roleWeaponMaxQuality;
		}

		// Token: 0x060414AC RID: 267436 RVA: 0x010BF8FC File Offset: 0x010BDAFC
		private void ApplyWithTask(IPinballItemDataWeapon data)
		{
			PinballItemSyncWeaponGridView.<>c__DisplayClass11_0 CS$<>8__locals1 = new PinballItemSyncWeaponGridView.<>c__DisplayClass11_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("PinballItemSyncWeaponGridView.Apply", delegate()
			{
				PinballItemSyncWeaponGridView.<>c__DisplayClass11_0.<<ApplyWithTask>b__0>d <<ApplyWithTask>b__0>d;
				<<ApplyWithTask>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<ApplyWithTask>b__0>d.<>4__this = CS$<>8__locals1;
				<<ApplyWithTask>b__0>d.<>1__state = -1;
				<<ApplyWithTask>b__0>d.<>t__builder.Start<PinballItemSyncWeaponGridView.<>c__DisplayClass11_0.<<ApplyWithTask>b__0>d>(ref <<ApplyWithTask>b__0>d);
				return <<ApplyWithTask>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x060414AD RID: 267437 RVA: 0x010BF944 File Offset: 0x010BDB44
		public void RefreshToggleState(bool bJumpToEnd)
		{
			if (this.SyncGridData == null)
			{
				return;
			}
			EToggleState state = this.SyncGridData.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle itemToggle = base.GetItemToggle();
			if (itemToggle == null)
			{
				return;
			}
			itemToggle.SetToggleState(state, false, false, bJumpToEnd);
		}

		// Token: 0x060414AE RID: 267438 RVA: 0x010BF984 File Offset: 0x010BDB84
		[NullableContext(2)]
		public UUIItem GetWeaponItemToggleRootUiItem()
		{
			UUIExtendToggle itemToggle = base.GetItemToggle();
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (itemToggle != null) ? new TWeakObjectPtr<UUIItem>?(itemToggle.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x060414AF RID: 267439 RVA: 0x010BF9C8 File Offset: 0x010BDBC8
		public void Clear()
		{
		}

		// Token: 0x04024893 RID: 149651
		[Nullable(2)]
		private IPinballItemSyncWeaponGridViewData SyncGridData;
	}
}
