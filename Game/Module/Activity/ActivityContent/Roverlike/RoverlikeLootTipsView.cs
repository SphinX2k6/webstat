using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200640F RID: 25615
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLootTipsView : UiViewBase
	{
		// Token: 0x060404EC RID: 263404 RVA: 0x0107B77F File Offset: 0x0107997F
		public RoverlikeLootTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060404ED RID: 263405 RVA: 0x0107B788 File Offset: 0x01079988
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnBtnSelfClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060404EE RID: 263406 RVA: 0x0107B8B4 File Offset: 0x01079AB4
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeLootTipsView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeLootTipsView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060404EF RID: 263407 RVA: 0x0107B8F8 File Offset: 0x01079AF8
		protected override void OnStart()
		{
			AUIBaseActor gridActor = base.GetItem(3).GetOwner() as AUIBaseActor;
			this.BeforeStarLayout = new GenericLayout<RoverlikeLootTipsStarItem, bool>(base.GetHorizontalLayout(1), new Func<RoverlikeLootTipsStarItem>(this.CreateStarItem), gridActor, false, true);
			this.AfterStarLayout = new GenericLayout<RoverlikeLootTipsStarItem, bool>(base.GetHorizontalLayout(2), new Func<RoverlikeLootTipsStarItem>(this.CreateStarItem), gridActor, false, true);
		}

		// Token: 0x060404F0 RID: 263408 RVA: 0x0107B95C File Offset: 0x01079B5C
		protected override void OnBeforeShow()
		{
			RoverlikeLootGainEntry roverlikeLootGainEntry = this.OpenParam as RoverlikeLootGainEntry;
			if (roverlikeLootGainEntry == null)
			{
				return;
			}
			this.RefreshTips(roverlikeLootGainEntry);
		}

		// Token: 0x060404F1 RID: 263409 RVA: 0x0107B980 File Offset: 0x01079B80
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x060404F2 RID: 263410 RVA: 0x0107B989 File Offset: 0x01079B89
		private void OnBtnSelfClick()
		{
			ControllerBase<RoverlikeController>.Instance.OpenGameInfoView(new EUiTabViewName?(EUiTabViewName.RoverlikeDetailRoleTabView));
		}

		// Token: 0x060404F3 RID: 263411 RVA: 0x0107B9A0 File Offset: 0x01079BA0
		private void RefreshTips(RoverlikeLootGainEntry entry)
		{
			RoverRogueLoot? lootConfig = ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(entry.ConfigId);
			if (lootConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), lootConfig.Value.Name, Array.Empty<object>());
			RoverlikeLootTipsIconItem iconItem = this.IconItem;
			if (iconItem != null)
			{
				iconItem.Refresh(lootConfig.Value.Icon);
			}
			GenericLayout<RoverlikeLootTipsStarItem, bool> beforeStarLayout = this.BeforeStarLayout;
			if (beforeStarLayout != null)
			{
				beforeStarLayout.RefreshByData(this.BuildStars(entry.LootLv - 1, lootConfig.Value.MaxLevel), null, false);
			}
			GenericLayout<RoverlikeLootTipsStarItem, bool> afterStarLayout = this.AfterStarLayout;
			if (afterStarLayout == null)
			{
				return;
			}
			afterStarLayout.RefreshByData(this.BuildStars(entry.LootLv, lootConfig.Value.MaxLevel), null, false);
		}

		// Token: 0x060404F4 RID: 263412 RVA: 0x0107BA6C File Offset: 0x01079C6C
		private List<bool> BuildStars(int level, int maxLevel)
		{
			int num = Math.Max(0, level);
			List<bool> list = new List<bool>();
			for (int i = 0; i < maxLevel; i++)
			{
				list.Add(i < num);
			}
			return list;
		}

		// Token: 0x060404F5 RID: 263413 RVA: 0x0107BA9E File Offset: 0x01079C9E
		private RoverlikeLootTipsStarItem CreateStarItem()
		{
			return new RoverlikeLootTipsStarItem();
		}

		// Token: 0x040240AE RID: 147630
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeLootTipsStarItem, bool> BeforeStarLayout;

		// Token: 0x040240AF RID: 147631
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeLootTipsStarItem, bool> AfterStarLayout;

		// Token: 0x040240B0 RID: 147632
		[Nullable(2)]
		private RoverlikeLootTipsIconItem IconItem;

		// Token: 0x0200C479 RID: 50297
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C792 RID: 247698
			public const int TxtName = 0;

			// Token: 0x0403C793 RID: 247699
			public const int StarLayoutBefore = 1;

			// Token: 0x0403C794 RID: 247700
			public const int StarLayoutAfter = 2;

			// Token: 0x0403C795 RID: 247701
			public const int StarTemplate = 3;

			// Token: 0x0403C796 RID: 247702
			public const int IconContainer = 4;

			// Token: 0x0403C797 RID: 247703
			public const int BtnSelf = 5;
		}
	}
}
