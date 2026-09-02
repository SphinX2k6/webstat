using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064BF RID: 25791
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TabGroupGridItem : GridProxyAbstract<ITabGroupData>
	{
		// Token: 0x06040A03 RID: 264707 RVA: 0x01090F50 File Offset: 0x0108F150
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06040A04 RID: 264708 RVA: 0x01090FEC File Offset: 0x0108F1EC
		protected override UniTask OnBeforeStartAsync()
		{
			TabGroupGridItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TabGroupGridItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040A05 RID: 264709 RVA: 0x01091030 File Offset: 0x0108F230
		public override UniTask RefreshAsync(ITabGroupData data, bool isSelected, int gridIndex)
		{
			TabGroupGridItem.<RefreshAsync>d__5 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<TabGroupGridItem.<RefreshAsync>d__5>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040A06 RID: 264710 RVA: 0x0109107B File Offset: 0x0108F27B
		private TabGridItem OnCreateTabItem()
		{
			return new TabGridItem
			{
				OnChildToggleCallback = this.OnChildToggleCallback
			};
		}

		// Token: 0x06040A07 RID: 264711 RVA: 0x0109108E File Offset: 0x0108F28E
		public void SelectFirstTab()
		{
			this.TabLayout.SelectGridProxy(0, true);
		}

		// Token: 0x04024320 RID: 148256
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<MotorChallengePlayData, MenuTabToggleItem> OnChildToggleCallback;

		// Token: 0x04024321 RID: 148257
		private GenericLayout<TabGridItem, MotorChallengePlayData> TabLayout;

		// Token: 0x04024322 RID: 148258
		[Nullable(2)]
		private ITabGroupData Data;
	}
}
