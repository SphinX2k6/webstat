using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED4 RID: 20180
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefencePhantomIconItem : SmallItemGrid, IGridProxy<PhantomSmallItemGrid>
	{
		// Token: 0x170089B8 RID: 35256
		// (get) Token: 0x0603420C RID: 213516 RVA: 0x00D08935 File Offset: 0x00D06B35
		// (set) Token: 0x0603420D RID: 213517 RVA: 0x00D0893D File Offset: 0x00D06B3D
		public IScrollViewDelegate<IGridProxy<PhantomSmallItemGrid>, PhantomSmallItemGrid> ScrollViewDelegate { get; set; }

		// Token: 0x170089B9 RID: 35257
		// (get) Token: 0x0603420E RID: 213518 RVA: 0x00D08946 File Offset: 0x00D06B46
		// (set) Token: 0x0603420F RID: 213519 RVA: 0x00D0894E File Offset: 0x00D06B4E
		public int GridIndex { get; set; }

		// Token: 0x170089BA RID: 35258
		// (get) Token: 0x06034210 RID: 213520 RVA: 0x00D08957 File Offset: 0x00D06B57
		// (set) Token: 0x06034211 RID: 213521 RVA: 0x00D0895F File Offset: 0x00D06B5F
		public int DisplayIndex { get; set; }

		// Token: 0x06034212 RID: 213522 RVA: 0x00D08968 File Offset: 0x00D06B68
		public void Clear()
		{
			TowerDefensePhantomIconCornerMark cornerMark = this.CornerMark;
			if (cornerMark != null)
			{
				cornerMark.Destroy(null);
			}
			this.CornerMark = null;
			TowerDefensePhantomUnavailableMask occupiedMask = this.OccupiedMask;
			if (occupiedMask != null)
			{
				occupiedMask.Destroy(null);
			}
			this.OccupiedMask = null;
		}

		// Token: 0x06034213 RID: 213523 RVA: 0x00D0899C File Offset: 0x00D06B9C
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06034214 RID: 213524 RVA: 0x00D0899E File Offset: 0x00D06B9E
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06034215 RID: 213525 RVA: 0x00D089A0 File Offset: 0x00D06BA0
		public object GetKey(PhantomSmallItemGrid data, int displayIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x06034216 RID: 213526 RVA: 0x00D089B0 File Offset: 0x00D06BB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034217 RID: 213527 RVA: 0x00D08B1C File Offset: 0x00D06D1C
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefencePhantomIconItem.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefencePhantomIconItem.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034218 RID: 213528 RVA: 0x00D08B5F File Offset: 0x00D06D5F
		public void Refresh(PhantomSmallItemGrid data, bool isSelected, int gridIndex)
		{
			this.RefreshInternalAsync(data, isSelected, gridIndex);
		}

		// Token: 0x06034219 RID: 213529 RVA: 0x00D08B6C File Offset: 0x00D06D6C
		private UniTask RefreshInternalAsync(PhantomSmallItemGrid data, bool isSelected, int gridIndex)
		{
			TowerDefencePhantomIconItem.<RefreshInternalAsync>d__23 <RefreshInternalAsync>d__;
			<RefreshInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshInternalAsync>d__.<>4__this = this;
			<RefreshInternalAsync>d__.data = data;
			<RefreshInternalAsync>d__.<>1__state = -1;
			<RefreshInternalAsync>d__.<>t__builder.Start<TowerDefencePhantomIconItem.<RefreshInternalAsync>d__23>(ref <RefreshInternalAsync>d__);
			return <RefreshInternalAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603421A RID: 213530 RVA: 0x00D08BB8 File Offset: 0x00D06DB8
		private UniTask TryPlayUnlockAsync(bool isLocked)
		{
			TowerDefencePhantomIconItem.<TryPlayUnlockAsync>d__24 <TryPlayUnlockAsync>d__;
			<TryPlayUnlockAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryPlayUnlockAsync>d__.<>4__this = this;
			<TryPlayUnlockAsync>d__.isLocked = isLocked;
			<TryPlayUnlockAsync>d__.<>1__state = -1;
			<TryPlayUnlockAsync>d__.<>t__builder.Start<TowerDefencePhantomIconItem.<TryPlayUnlockAsync>d__24>(ref <TryPlayUnlockAsync>d__);
			return <TryPlayUnlockAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603421B RID: 213531 RVA: 0x00D08C03 File Offset: 0x00D06E03
		private void OnClick(EToggleState toggleState)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.TowerDefenseOnClickOnePhantom, this.CachedTowerDefencePhantomId);
		}

		// Token: 0x0401E1AF RID: 123311
		private int CachedTowerDefencePhantomId;

		// Token: 0x0401E1B0 RID: 123312
		private TowerDefensePhantomIconCornerMark CornerMark;

		// Token: 0x0401E1B1 RID: 123313
		private TowerDefensePhantomUnavailableMask OccupiedMask;

		// Token: 0x0200AE7B RID: 44667
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x040362C8 RID: 221896
			public const int QualitySprite = 0;

			// Token: 0x040362C9 RID: 221897
			public const int IconTexture = 1;

			// Token: 0x040362CA RID: 221898
			public const int NameItem = 2;

			// Token: 0x040362CB RID: 221899
			public const int NameText = 3;

			// Token: 0x040362CC RID: 221900
			public const int BackgroundSprite = 4;

			// Token: 0x040362CD RID: 221901
			public const int BottomItem = 5;

			// Token: 0x040362CE RID: 221902
			public const int LockItem = 6;

			// Token: 0x040362CF RID: 221903
			public const int Root = 7;
		}
	}
}
