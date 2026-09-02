using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel
{
	// Token: 0x020043C3 RID: 17347
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTravelTabDynamicScrollItem : UiPanelBase, IDynamicScrollItem<MapTravelAreaData>
	{
		// Token: 0x0602E1D9 RID: 188889 RVA: 0x00AD7ACF File Offset: 0x00AD5CCF
		public MapTravelTabDynamicScrollItem(ActivityMapTravelData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x0602E1DA RID: 188890 RVA: 0x00AD7AE0 File Offset: 0x00AD5CE0
		public UniTask Init(UUIItem actor)
		{
			MapTravelTabDynamicScrollItem.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MapTravelTabDynamicScrollItem.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0602E1DB RID: 188891 RVA: 0x00AD7B2C File Offset: 0x00AD5D2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E1DC RID: 188892 RVA: 0x00AD7B98 File Offset: 0x00AD5D98
		protected override UniTask OnBeforeStartAsync()
		{
			MapTravelTabDynamicScrollItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapTravelTabDynamicScrollItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E1DD RID: 188893 RVA: 0x00AD7BDB File Offset: 0x00AD5DDB
		public AUIBaseActor GetUsingItem(MapTravelAreaData data)
		{
			if (data.IsUnlock)
			{
				return this.GetItemActor(1);
			}
			return this.GetItemActor(0);
		}

		// Token: 0x0602E1DE RID: 188894 RVA: 0x00AD7BF4 File Offset: 0x00AD5DF4
		private AUIBaseActor GetItemActor(int key)
		{
			return base.GetItem(key).GetOwner() as AUIBaseActor;
		}

		// Token: 0x0602E1DF RID: 188895 RVA: 0x00AD7C08 File Offset: 0x00AD5E08
		public void Update(MapTravelAreaData data, int index)
		{
			this.Data = data;
			this.LockItem.SetUiActive(!data.IsUnlock);
			this.NormalItem.SetUiActive(data.IsUnlock);
			if (!data.IsUnlock)
			{
				this.LockItem.RefreshByData(data, index);
			}
			else
			{
				this.NormalItem.RefreshByData(data, index);
			}
			Func<MapTravelAreaData, int, bool> isSelectedOn = this.IsSelectedOn;
			if (isSelectedOn != null && isSelectedOn(data, index))
			{
				this.SetSelected(true, false);
				return;
			}
			this.SetSelected(false, false);
		}

		// Token: 0x0602E1E0 RID: 188896 RVA: 0x00AD7C8C File Offset: 0x00AD5E8C
		public void SetSelected(bool bOn, bool bFireEvent)
		{
			this.LockItem.SetToggleState(bOn, bFireEvent && !this.Data.IsUnlock);
			this.NormalItem.SetToggleState(bOn, bFireEvent && this.Data.IsUnlock);
		}

		// Token: 0x0602E1E1 RID: 188897 RVA: 0x00AD7CCB File Offset: 0x00AD5ECB
		public void BindSelectedCallBack(Action<MapTravelAreaData, int> selectCallback)
		{
			this.SelectedCallBack = selectCallback;
		}

		// Token: 0x0602E1E2 RID: 188898 RVA: 0x00AD7CD4 File Offset: 0x00AD5ED4
		public void BindIsSelectedOn(Func<MapTravelAreaData, int, bool> isSelectedOn)
		{
			this.IsSelectedOn = isSelectedOn;
		}

		// Token: 0x0602E1E3 RID: 188899 RVA: 0x00AD7CDD File Offset: 0x00AD5EDD
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x0401A169 RID: 106857
		[Nullable(2)]
		private MapTravelTabItem NormalItem;

		// Token: 0x0401A16A RID: 106858
		[Nullable(2)]
		private MapTravelTabItemLock LockItem;

		// Token: 0x0401A16B RID: 106859
		[Nullable(2)]
		protected MapTravelAreaData Data;

		// Token: 0x0401A16C RID: 106860
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Action<MapTravelAreaData, int> SelectedCallBack;

		// Token: 0x0401A16D RID: 106861
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Func<MapTravelAreaData, int, bool> IsSelectedOn;

		// Token: 0x0401A16E RID: 106862
		protected ActivityMapTravelData ActivityBaseData;

		// Token: 0x0200A62B RID: 42539
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04033628 RID: 210472
			public const int NormalItem = 0;

			// Token: 0x04033629 RID: 210473
			public const int LockItem = 1;
		}
	}
}
