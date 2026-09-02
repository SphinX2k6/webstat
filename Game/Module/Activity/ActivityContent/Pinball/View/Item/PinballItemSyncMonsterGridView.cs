using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x0200660D RID: 26125
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemSyncMonsterGridView : PinballItemView, ISyncGridProxy<IPinballItemSyncMonsterGridViewData>, ISyncGridProxy
	{
		// Token: 0x17009F43 RID: 40771
		// (get) Token: 0x06041474 RID: 267380 RVA: 0x010BF5F7 File Offset: 0x010BD7F7
		// (set) Token: 0x06041475 RID: 267381 RVA: 0x010BF5FF File Offset: 0x010BD7FF
		public int GridIndex { get; set; }

		// Token: 0x06041476 RID: 267382 RVA: 0x010BF608 File Offset: 0x010BD808
		protected override void OnStart()
		{
			base.OnStart();
			base.GetItemToggle().bLockStateOnSelect = true;
		}

		// Token: 0x06041477 RID: 267383 RVA: 0x010BF61C File Offset: 0x010BD81C
		public void Refresh(IPinballItemSyncMonsterGridViewData data)
		{
			IPinballItemDataMonster itemData = data.ItemData;
			this.SyncGridData = data;
			this.RefreshToggleState(true);
			this.ApplyWithTask(itemData);
		}

		// Token: 0x06041478 RID: 267384 RVA: 0x010BF645 File Offset: 0x010BD845
		void ISyncGridProxy.Refresh(object data)
		{
			this.Refresh((IPinballItemSyncMonsterGridViewData)data);
		}

		// Token: 0x06041479 RID: 267385 RVA: 0x010BF653 File Offset: 0x010BD853
		void ISyncGridProxy.CreateByActor(AActor actor)
		{
			base.CreateByActor(actor, null);
		}

		// Token: 0x0604147A RID: 267386 RVA: 0x010BF65D File Offset: 0x010BD85D
		void ISyncGridProxy.CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0604147B RID: 267387 RVA: 0x010BF668 File Offset: 0x010BD868
		private void ApplyWithTask(IPinballItemDataMonster data)
		{
			PinballItemSyncMonsterGridView.<>c__DisplayClass10_0 CS$<>8__locals1 = new PinballItemSyncMonsterGridView.<>c__DisplayClass10_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("PinballItemSyncMonsterGridView.Apply", delegate()
			{
				PinballItemSyncMonsterGridView.<>c__DisplayClass10_0.<<ApplyWithTask>b__0>d <<ApplyWithTask>b__0>d;
				<<ApplyWithTask>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<ApplyWithTask>b__0>d.<>4__this = CS$<>8__locals1;
				<<ApplyWithTask>b__0>d.<>1__state = -1;
				<<ApplyWithTask>b__0>d.<>t__builder.Start<PinballItemSyncMonsterGridView.<>c__DisplayClass10_0.<<ApplyWithTask>b__0>d>(ref <<ApplyWithTask>b__0>d);
				return <<ApplyWithTask>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x0604147C RID: 267388 RVA: 0x010BF6B0 File Offset: 0x010BD8B0
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

		// Token: 0x0604147D RID: 267389 RVA: 0x010BF6ED File Offset: 0x010BD8ED
		public void Clear()
		{
		}

		// Token: 0x04024889 RID: 149641
		[Nullable(2)]
		private IPinballItemSyncMonsterGridViewData SyncGridData;
	}
}
