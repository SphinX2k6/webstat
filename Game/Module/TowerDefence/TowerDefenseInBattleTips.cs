using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC7 RID: 20167
	public class TowerDefenseInBattleTips : UiTickViewBase
	{
		// Token: 0x06034185 RID: 213381 RVA: 0x00D04B7A File Offset: 0x00D02D7A
		[NullableContext(1)]
		public TowerDefenseInBattleTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034186 RID: 213382 RVA: 0x00D04B8C File Offset: 0x00D02D8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034187 RID: 213383 RVA: 0x00D04C38 File Offset: 0x00D02E38
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseInBattleTips.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseInBattleTips.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034188 RID: 213384 RVA: 0x00D04C7B File Offset: 0x00D02E7B
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x06034189 RID: 213385 RVA: 0x00D04C83 File Offset: 0x00D02E83
		protected override void OnAfterDestroy()
		{
			ControllerBase<TowerDefenseController>.Instance.TryReopenInBattleTip();
		}

		// Token: 0x0603418A RID: 213386 RVA: 0x00D04C90 File Offset: 0x00D02E90
		private void Refresh()
		{
			this.ShowingLevel = ModelBase<TowerDefenseModel>.Instance.GetCurrentPhantomLevelInBattle();
			PhantomSmallItemGrid parameters = ControllerBase<TowerDefenseController>.Instance.BuildPhantomIconInBattleData();
			SmallItemGrid iconItem = this.IconItem;
			if (iconItem != null)
			{
				iconItem.Apply<PhantomSmallItemGrid>(parameters);
			}
			ITowerDefenseTipsContentInBattle towerDefenseTipsContentInBattle = ControllerBase<TowerDefenseController>.Instance.BuildPhantomTipsInBattleData();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), towerDefenseTipsContentInBattle.TitleTextId, Array.Empty<object>());
			if (towerDefenseTipsContentInBattle.DescArgs != null && towerDefenseTipsContentInBattle.DescArgs.Count > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), towerDefenseTipsContentInBattle.DescTextId, towerDefenseTipsContentInBattle.DescArgs);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), towerDefenseTipsContentInBattle.DescTextId, Array.Empty<object>());
		}

		// Token: 0x0603418B RID: 213387 RVA: 0x00D04D41 File Offset: 0x00D02F41
		protected override void OnAfterPlayStartSequence()
		{
			this.PlaySequenceStream().ContinueWith(delegate()
			{
				ControllerBase<TowerDefenseController>.Instance.ResetCurrentPhantomLevelUpFlag(this.ShowingLevel);
				base.CloseMe(null);
			});
		}

		// Token: 0x0603418C RID: 213388 RVA: 0x00D04D5C File Offset: 0x00D02F5C
		private UniTask PlaySequenceStream()
		{
			TowerDefenseInBattleTips.<PlaySequenceStream>d__10 <PlaySequenceStream>d__;
			<PlaySequenceStream>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceStream>d__.<>1__state = -1;
			<PlaySequenceStream>d__.<>t__builder.Start<TowerDefenseInBattleTips.<PlaySequenceStream>d__10>(ref <PlaySequenceStream>d__);
			return <PlaySequenceStream>d__.<>t__builder.Task;
		}

		// Token: 0x0401E172 RID: 123250
		private const int WAITING_TO_CLOSE = 2000;

		// Token: 0x0401E173 RID: 123251
		[Nullable(2)]
		private SmallItemGrid IconItem;

		// Token: 0x0401E174 RID: 123252
		private int ShowingLevel = 1;

		// Token: 0x0200AE62 RID: 44642
		private class EComponent
		{
			// Token: 0x04036237 RID: 221751
			public const int IconItem = 0;

			// Token: 0x04036238 RID: 221752
			public const int StateSprite = 1;

			// Token: 0x04036239 RID: 221753
			public const int TitleText = 2;

			// Token: 0x0403623A RID: 221754
			public const int DescText = 3;
		}
	}
}
